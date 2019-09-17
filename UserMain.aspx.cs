using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using DataLinkLayer;
using BusinessLogic;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;


public partial class UserMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try { UserID.Text = Session["User"].ToString(); }
        catch { Response.Redirect("LoginPage.aspx"); }
        string str = Session["User"].ToString();
        UserBO ob4 = new UserBO();
        ob4.userid = Session["User"].ToString();

        clsBLL ob5 = new clsBLL();

        int user1 = ob5.FindUserTypeBLL(ob4);
        if (user1 == 1) {Session["User"] = null; Response.Redirect("LoginPage.aspx"); }

        string name = ob5.firstnamerBLL(str);

        UserName.Text = name;


        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
            {
                SqlCommand cmd = new SqlCommand("select CourseCode,Status,Score from Scores where (UserID ='" + Session["User"].ToString() + "')", con);
                con.Open();
                CoursesAccepted.DataSource = cmd.ExecuteReader();
                CoursesAccepted.DataBind();
            }
        
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
        {
            SqlCommand cmd = new SqlCommand("select SkillName from SkillSet", con);
            con.Open();
            UserSkillSearchResult.DataSource = cmd.ExecuteReader();
            UserSkillSearchResult.DataBind();
        }
    }


    protected void UserSkillSearchButton_Click(object sender, EventArgs e)
    {
        
            UserBO ob = new UserBO();
            ob.skillName = UserSkillSearch.Text;

            clsBLL ob1 = new clsBLL();
            
            UserSkillSearchResult.DataSource = ob1.SkillSearchTableBLL(ob);
            UserSkillSearchResult.DataBind();
        
    }

    protected void UserSkillSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = UserSkillSearchResult.Rows[rowIndex];
            
            string skilluserselect = row.Cells[1].Text;

            UserBO ob = new UserBO();
            ob.skillName = skilluserselect;

            clsBLL obj = new clsBLL();
            if(obj.getCoursesofSkillBLL(ob).Rows.Count == 0) { StatusBar.Text = "no item found"; UserCourseDetailsView.DataSource = null; UserCourseDetailsView.DataBind(); }
            else
            {
                UserCourseDetailsView.DataSource = obj.getCoursesofSkillBLL(ob);
                UserCourseDetailsView.DataBind();
                StatusBar.Text = "";
            }
                    

        }
    }
    
    protected void UserCourseDetailsView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = UserCourseDetailsView.Rows[rowIndex];

            UserBO ob = new UserBO();
            ob.userid = Session["User"].ToString();
            ob.coursecode = row.Cells[1].Text;
            ob.registered = "Y";
            ob.courseopened = "N";
            clsBLL obj = new clsBLL();
            if (obj.isregisteredBLL(ob) == 0)
            { 
                obj.onregistrationcourseBLL(ob);
                obj.activateStatusBLL(ob);
            }
            Session["CourseSelected"] = row.Cells[1].Text;

            Response.Redirect("UserSelectedCoursePage.aspx");
        }
    }

}