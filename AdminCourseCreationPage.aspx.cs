using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BusinessLogic;
using BusinessObject;
using DataLinkLayer;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminCourseCreationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
        {

            SqlCommand cmd = new SqlCommand("select SkillName from SkillSet", con);
            con.Open();

            SkillSetDropDown.DataSource = cmd.ExecuteReader();
            SkillSetDropDown.DataTextField = "SkillName";
            SkillSetDropDown.DataValueField = "SkillName";
            SkillSetDropDown.DataBind();
        }
        }
    }
    protected void CourseInsertion_Click(object sender, EventArgs e)
    {
        
        
        UserBO ob4 = new UserBO(); ob4.userid = Session["User"].ToString();

        if(CourseCode.Text.Trim() == null || CourseCode.Text.Trim() == "" || CourseDescription.Text.Trim() == null || CourseDescription.Text.Trim() == "")
        {
            Response.Write("<script>alert('There is Something Wrong!!!');</script>");
            Server.Transfer("AdminCourseCreationPage.aspx");
        }

        ob4.coursecode = CourseCode.Text;
        ob4.coursedescription = CourseDescription.Text;
        ob4.skillName = SkillSetDropDown.Text;

        ob4.coursedate = DateTime.Today.ToString("dd-MM-yyyy");
        ob4.coursetime = DateTime.Now.ToString("HH:mm:ss");

        ob4.coursecodetobechanged = Other_Reference.Text;


        clsBLL ob5 = new clsBLL();
        ob4.courseaddedby = ob5.firstnamerBLL(ob4.userid);


        int response = ob5.CourseInsertionBLL(ob4);
        if(response == 1) { Response.Write("<script>alert('Done Man!!!');</script>"); Server.Transfer("AdminCourseCreationPage.aspx"); }
        else { Response.Write("<script>alert('Oops Man!!!');</script>"); }
        
    }
}