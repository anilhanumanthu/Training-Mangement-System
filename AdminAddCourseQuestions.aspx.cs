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

public partial class AdminAddCourseQuestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
            {

                SqlCommand cmd = new SqlCommand("select CourseCode from Course", con);
                con.Open();

                CourseCodeDropList.DataSource = cmd.ExecuteReader();
                CourseCodeDropList.DataTextField = "CourseCode";
                CourseCodeDropList.DataValueField = "CourseCode";
                CourseCodeDropList.DataBind();
            }
        }
    }


    protected void SubmitQuestion_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();

        clsBLL obj = new clsBLL();

        if (QuestionBox.Text == null || QuestionBox.Text == "" || Option1Box.Text == "" || Option1Box.Text == null || Option2Box.Text == "" || Option2Box.Text == null || Option3Box.Text == "" || Option3Box.Text == null || Option4Box.Text == "" || Option4Box.Text == null)
        {
            Response.Write("<script>alert('Some values aren missing in the required field');</script>");
            Server.Transfer("AdminAddCourseQuestions.aspx");
        }

        ob.coursecode = CourseCodeDropList.Text;

        ob.qno = obj.QuestionnumberfinderBLL(ob.coursecode) + 1;

        ob.question = QuestionBox.Text;
        ob.option1 = Option1Box.Text;
        ob.option2 = Option2Box.Text;
        ob.option3 = Option3Box.Text;
        ob.option4 = Option4Box.Text;
        ob.questAns = CorrectOptionDropList.Text;


        int m = obj.InsertQuestionBLL(ob);

        if(m == 1) { statuslabel.Text = "inserted";
            QuestionBox.Text = "";
            Option1Box.Text = "";
            Option2Box.Text = "";
            Option3Box.Text = "";
            Option4Box.Text = "";
        }
        else { statuslabel.Text = "can't insert"; }


        


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
            {

                SqlCommand cmd = new SqlCommand("select * from QuestionBank where (CourseID ='" + CourseCodeDropList.Text + "')", con);
                con.Open();

                QuestionsData.DataSource = cmd.ExecuteReader();
                QuestionsData.DataBind();
            }



    }

    protected void QuestionsData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = QuestionsData.Rows[rowIndex];

            int qnodel = Convert.ToInt32(row.Cells[1].Text);
            string coursedel = row.Cells[2].Text;

            UserBO ob = new UserBO();
            ob.qno = qnodel;
            ob.coursecode = coursedel;

            clsBLL obj = new clsBLL();

            if (obj.deletetheQuestionBLL(ob) == 1)
            {
                if (obj.updatetheQuestionBLL(ob) >= 0)
                {
                    Response.Write("<script>alert('Deleted QuestionSuccessfully');</script>");

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userdataConnectionString"].ConnectionString.ToString()))
                    {

                        SqlCommand cmd = new SqlCommand("select * from QuestionBank where (CourseID ='" + CourseCodeDropList.Text + "')", con);
                        con.Open();

                        QuestionsData.DataSource = cmd.ExecuteReader();
                        QuestionsData.DataBind();
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Question can't be deleted');</script>");
            }

        }
    }
}