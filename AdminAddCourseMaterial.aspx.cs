using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessObject;
using BusinessLogic;
using System.Web.UI.HtmlControls;

public partial class AdminAddCourseMaterial : System.Web.UI.Page
{
    static String FileLocation;

    static string FileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void Add_Material_Click(object sender, EventArgs e)
    {

        UserBO ok = new UserBO();
        ok.coursecode = coursecodemat.Text;
        clsBLL ok1 = new clsBLL();
        int kira = ok1.verifycoursecodeBLL(ok);

        if (kira == 1)
        {

            if (uploadpdf() == true)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString2"].ConnectionString.ToString());
                SqlCommand cmd = new SqlCommand("[Uploadpdf]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coursecode", coursecodemat.Text);
                cmd.Parameters.AddWithValue("@filename", Filenamenat.Text);
                cmd.Parameters.AddWithValue("@filelocation", FileLocation);
                con.Open();
                cmd.ExecuteNonQuery();
                coursecodemat.Text = "";
                Filenamenat.Text = "";
                Response.Redirect("AdminAddCourseMaterial.aspx");
            }
        }
        else
        {
            Statusindicator.Text = "CourseCode does not exist";
        }
    }


    private Boolean uploadpdf()
    {
        Boolean resumesaved = false;
        if (FileUpload1.HasFile == true)
        {

            String contenttype = FileUpload1.PostedFile.ContentType;

            if (contenttype == "application/pdf")
            {
                int filesize;
                filesize = FileUpload1.PostedFile.ContentLength;
                FileName = Filenamenat.Text;
                FileUpload1.SaveAs(Server.MapPath("~/CourseFiles/") + FileName + ".pdf");

                FileLocation = "CourseFiles/" + FileName + ".pdf";
                resumesaved = true;
                Statusindicator.Text = "";
            }
            else
            {
                Statusindicator.Text = "Upload Resume in PDF Format Only";
            }

        }
        else
        {
            Statusindicator.Text = "Kindly Upload Resume Before Apply in PDF Format";
        }


        return resumesaved;
    }

    protected void Delete_Material_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        ob.coursematerial = Filenamenat.Text;
        clsBLL ok1 = new clsBLL();
        int kira = ok1.updatetheQuestionBLL(ob);

        if (kira == 1) { Statusindicator.Text = "deleted"; Response.Redirect("AdminAddCourseMaterial.aspx"); }
        else { Statusindicator.Text = "not deleted"; }
    }




    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridView1.Rows[rowIndex];

            string country = row.Cells[3].Text;

            myframe.Attributes.Add("src", country);
    
        }
    }
}