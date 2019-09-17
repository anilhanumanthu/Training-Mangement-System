using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BusinessLogic;
using BusinessObject;
using System.Data;
using DataLinkLayer;

public partial class AdminMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try { AdminID.Text = Session["User"].ToString(); }
        catch { Response.Redirect("LoginPage.aspx"); }
        string str = Session["User"].ToString();
        UserBO ob4 = new UserBO();
        ob4.userid = Session["User"].ToString();

        clsBLL ob5 = new clsBLL();
        int admin1 = ob5.FindUserTypeBLL(ob4);
        if (admin1 != 1) { Session["User"] = null; Response.Redirect("LoginPage.aspx"); }

        string name = ob5.firstnamerBLL(str);

        AdminName.Text = name;


        if (!IsPostBack)
        {
            clsBLL ob1 = new clsBLL();
            List<string> skillList = ob1.FirstBLL();
            List<string> skillList2 = ob1.First2BLL();
            List<string> skillList3 = ob1.First3BLL();
            try
            {
                skillCard1.Text = skillList[0];
                skillCard2.Text = skillList2[0];
                skillCard3.Text = skillList3[0];
            }
            catch
            {
                skillCard1.Text = "none";
                skillCard2.Text = "none";
                skillCard3.Text = "none";
            }

            Adminsearchshowstat.Visible = false;
        }


    }
    protected void PriorityChanger_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        ob.userid = PriorityRequestedID.Text;

        clsBLL ob1 = new clsBLL();
        int modified = ob1.AdminBuilderBLL(ob);
        if (modified == 1)
        {
            StatusBar.Text = "Priority Created";
        }
        else
        {
            StatusBar.Text = "Priority Not-Created";
        }

    }
    protected void SkillSearchButton_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        ob.skillName = SkillSearch.Text;

        clsBLL ob1 = new clsBLL();
        string skillList = ob1.SkillSearchBLL(ob);
        string[] sl;
        try
        {
            sl = skillList.Split(' ');
        }
        catch { sl = null; }

        if (sl.Length == 1 && sl[0] != "") { skillCard1.Text = sl[0]; skillCard2.Text = "none-Found"; skillCard3.Text = "none-Found"; }
        else { skillCard1.Text = "none-Found"; skillCard2.Text = "none-Found"; skillCard3.Text = "none-Found"; }
    }

    protected void skillCardButton1_Click(object sender, EventArgs e)
    {

        UserBO obj = new UserBO();
        obj.skillName = skillCard1.Text.Trim();
        clsBLL dt = new clsBLL();
        DataTable dataTable = dt.CourseContentBLL(obj);

        CoursesGrid.DataSource = dataTable;
        CoursesGrid.DataBind();

    }
    protected void skillCardButton2_Click(object sender, EventArgs e)
    {
        UserBO obj = new UserBO();
        obj.skillName = skillCard2.Text.Trim();
        clsBLL dt = new clsBLL();
        DataTable dataTable = dt.CourseContentBLL(obj);

        CoursesGrid.DataSource = dataTable;
        CoursesGrid.DataBind();
    }
    protected void skillCardButton3_Click(object sender, EventArgs e)
    {
        UserBO obj = new UserBO();
        obj.skillName = skillCard3.Text.Trim();
        clsBLL dt = new clsBLL();
        DataTable dataTable = dt.CourseContentBLL(obj);

        CoursesGrid.DataSource = dataTable;
        CoursesGrid.DataBind();
    }

    protected void CoursesGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["selectedGrid"] = CoursesGrid.SelectedRow.Cells[1].Text;
        Response.Redirect("AdminCourseDetails.aspx");

    }
    protected void AddCourseMaterial_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminAddCourseMaterial.aspx");
    }
    protected void AddCourseQuestions_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminAddCourseQuestions.aspx");
    }

    protected void Adminshowstat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = Adminshowstat.Rows[rowIndex];

            string now = row.Cells[0].Text;
            string now1 = row.Cells[1].Text;

            Session["AdminSelectedUser"] = now;
            Session["AdminSelectedUserCourse"] = now1;

            Response.Redirect("AdminSelectedUser.aspx");
        }
    }

    protected void UserIDSearcherButton_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        ob.userid = UserIDSearcher.Text;

        clsBLL ob1 = new clsBLL();
        DataTable information = ob1.UserIDSearcherBLL(ob);

        Adminshowstat.Visible = false;
        Adminsearchshowstat.Visible = true;
        Adminsearchshowstat.DataSource = information;
        Adminsearchshowstat.DataBind();
    }

    protected void Adminsearchshowstat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = Adminsearchshowstat.Rows[rowIndex];

            string now = row.Cells[0].Text;
            string now1 = row.Cells[1].Text;

            Session["AdminSelectedUser"] = now;
            Session["AdminSelectedUserCourse"] = now1;

            Response.Redirect("AdminSelectedUser.aspx");
        }
    }
}