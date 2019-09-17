using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BusinessObject;
using BusinessLogic;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class UserSelectedCoursePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TakeAssessment.Visible = false;

    }



    protected void TakeCourse_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
        {

            SqlCommand cmd = new SqlCommand("select FileName,FileLocation from CourseMaterial where (CourseCode ='" + Session["CourseSelected"].ToString() + "')", con);
            con.Open();

            CourseDataMaterial.DataSource = cmd.ExecuteReader();
            CourseDataMaterial.DataBind();
        }
    }




    protected void CourseDataMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        myframe.Visible = true;
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = CourseDataMaterial.Rows[rowIndex];

            string country = row.Cells[2].Text;

            TakeAssessment.Visible = true;

            UserBO ob = new UserBO();
            ob.userid = Session["User"].ToString();
            ob.coursecode = Session["CourseSelected"].ToString();
            clsBLL obj = new clsBLL();
            obj.onupdateQuantifierBLL(ob);

            myframe.Attributes.Add("src", country);

        }
    }
    protected void TakeAssessment_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserAssessmentPage.aspx");
    }
}