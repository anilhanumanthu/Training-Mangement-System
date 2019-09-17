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

public partial class AdminCourseDetails : System.Web.UI.Page
{
    string skillmodified, descriptionmodified;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UserBO ob = new UserBO();
            ob.coursecode = Session["selectedGrid"].ToString();

            clsBLL obj = new clsBLL();

            List<string> ListofDet = obj.CourseDetailsPageBLL(ob);

            Editor.Visible = false;
            Viewer.Visible = true;
            Deleted.Visible = false;

            CourseCodeDet.Text = ListofDet[0].ToString();
            CourseDescriptionDet.Text = ListofDet[1].ToString();
            descriptionmodified = CourseDescriptionDet.Text; 
            SkillNameDet.Text = ListofDet[2].ToString();
            skillmodified = SkillNameDet.Text;
            CourseDateDet.Text = ListofDet[3].ToString();
            CourseTimeDet.Text = ListofDet[4].ToString();
            CourseAddedByDet.Text = ListofDet[5].ToString();
            OtherReferencesDet.Text = ListofDet[6].ToString();
        }
        catch
        {
            Response.Redirect("LoginPage.aspx");
        }

    }

    protected void ViewLinkButton_Click(object sender, EventArgs e)
    {
        Editor.Visible = false;
        Viewer.Visible = true;
        Deleted.Visible = false;
    }

    protected void EditLinkButton_Click(object sender, EventArgs e)
    {
        Editor.Visible = true;
        Viewer.Visible = false;
        Deleted.Visible = false;

    }

    protected void DeleteLinkButton_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        ob.coursecode = Session["selectedGrid"].ToString();

        clsBLL obj = new clsBLL();
        obj.DeleteCourseBLL(ob);

        Editor.Visible = false;
        Viewer.Visible = false;
        Deleted.Visible = true;
    }
    protected void UpdateCourse_Click(object sender, EventArgs e)
    {
        UserBO ob4 = new UserBO();
        ob4.userid = Session["User"].ToString();

        ob4.coursecodetobechanged = CourseCodeDet.Text;

        if (CourseInsert.Text.Trim() == null || CourseInsert.Text.Trim() == "")
        {
            Response.Write("<script>alert('There is Something Wrong!!!');</script>");
            Server.Transfer("AdminCourseDetails.aspx");
        }

        if (CourseDescriptionInsert.Text.Trim() == null || CourseDescriptionInsert.Text.Trim() == "")
        {
            CourseDescriptionInsert.Text = descriptionmodified;
        }

        ob4.coursecode = CourseInsert.Text;
        ob4.coursedescription = CourseDescriptionInsert.Text;
        ob4.skillName = skillmodified;

        ob4.coursedate = DateTime.Today.ToString("dd-MM-yyyy");
        ob4.coursetime = DateTime.Now.ToString("HH:mm:ss");

        ob4.otherreference = OtherReferenceInsert.Text;


        clsBLL ob5 = new clsBLL();
        ob4.courseaddedby = ob5.firstnamerBLL(ob4.userid);


        int response = ob5.CourseUpdateBLL(ob4);
        if (response == 1) { Response.Write("<script>alert('Done Man!!!');</script>"); Server.Transfer("AdminMainPage.aspx"); }
        else { Response.Write("<script>alert('Oops Man!!!');</script>"); }
    }
}