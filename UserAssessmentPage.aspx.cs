using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BusinessObject;
using BusinessLogic;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserAssessmentPage : System.Web.UI.Page
{
    public static int myScore = 0;
    public static int countofQuestions;
    public static int startingQuestion = 1;
    public string answercheck;
    public static int rowno = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserBO ob = new UserBO();
            
            try
            {
                ob.userid = Session["User"].ToString();
                ob.coursecode = Session["CourseSelected"].ToString();
            }
            catch
            {
                Response.Redirect("UserMain.aspx");
            }
            clsBLL logicob = new clsBLL();
            if (logicob.iscourseopenedBLL(ob) == "Y")
            {

                DataTable questiontable = logicob.QuestionTableCreatorBLL(ob);
                countofQuestions = questiontable.Rows.Count;
                if (countofQuestions > 0)
                {
                    startingQuestion = 1;
                    rowno = startingQuestion - 1;
                    displayQuestion(questiontable);
                }
                else
                {
                    QuestionText.Text = "Sorry There are no questions for this course";
                }

                test.DataSource = questiontable;
                test.DataBind();
                SubmitQuestions.Visible = false;
            }
            else { Response.Redirect("UserMain.aspx"); }
        }
        

    }

    protected void displayQuestion(DataTable dat)
    {
        
        if (rowno >= countofQuestions) { Response.Write("<script>alert('You cannot make this happen');</script>"); }
        else
        {
            QuestionText.Text = dat.Rows[rowno][2].ToString();
            OptionA.Text = dat.Rows[rowno][3].ToString();
            OptionB.Text = dat.Rows[rowno][4].ToString();
            OptionC.Text = dat.Rows[rowno][5].ToString();
            OptionD.Text = dat.Rows[rowno][6].ToString();
            QuestionNumber.Text = startingQuestion.ToString();
        }
    }

    protected void rightindicpicbutton_Click(object sender, EventArgs e)
    {
        rowno = startingQuestion - 1;
        startingQuestion++;
        if (startingQuestion > countofQuestions)
        {
            Response.Write("<script>alert('You are completed with your Questions click on submit');</script>");
            SubmitQuestions.Visible = true;
        }
        else
        {

            if (OptionA.Checked) { answercheck = "A"; }
            else if (OptionB.Checked) { answercheck = "B"; }
            else if (OptionC.Checked) { answercheck = "C"; }
            else if (OptionD.Checked) { answercheck = "D"; }
            else { answercheck = "N"; }

            UserBO ob = new UserBO();
            ob.coursecode = Session["CourseSelected"].ToString();

            clsBLL logicob = new clsBLL();
            DataTable questiontable = logicob.QuestionTableCreatorBLL(ob);

            StatusBar.Text = questiontable.Rows[rowno][7].ToString();

            logicob.updateAnsweredBLL(rowno, answercheck, Session["CourseSelected"].ToString());

                displayQuestion(questiontable);

            if (OptionA.Checked) { OptionA.Checked = false; }
            else if (OptionB.Checked) { OptionB.Checked = false; }
            else if (OptionC.Checked) { OptionC.Checked = false; }
            else if (OptionD.Checked) { OptionD.Checked = false; }
        }
    }



    protected void leftindicpicbutton_Click(object sender, EventArgs e)
    {
        rowno = startingQuestion - 2;
        startingQuestion--;
        if (startingQuestion < 1) { Response.Write("<script>alert('You cannot go back');</script>"); }
        else
        {
            UserBO ob = new UserBO();
            ob.coursecode = Session["CourseSelected"].ToString();

            clsBLL logicob = new clsBLL();
            DataTable questiontable = logicob.QuestionTableCreatorBLL(ob);

            displayQuestion(questiontable);

            if (OptionA.Checked) { OptionA.Checked = false; }
            else if (OptionB.Checked) { OptionB.Checked = false; }
            else if (OptionC.Checked) { OptionC.Checked = false; }
            else if (OptionD.Checked) { OptionD.Checked = false; }
        }
    }

    protected void SubmitQuestions_Click(object sender, EventArgs e)
    {
        if (OptionA.Checked) { answercheck = "A"; }
        else if (OptionB.Checked) { answercheck = "B"; }
        else if (OptionC.Checked) { answercheck = "C"; }
        else if (OptionD.Checked) { answercheck = "D"; }
        else { answercheck = "N"; }

        UserBO ob = new UserBO();
        ob.coursecode = Session["CourseSelected"].ToString();

        clsBLL logicob = new clsBLL();
        DataTable questiontable = logicob.QuestionTableCreatorBLL(ob);

        logicob.updateAnsweredBLL(rowno, answercheck, Session["CourseSelected"].ToString());

        Session["questioncount"] = countofQuestions;
        Response.Redirect("UserPresentTestCalculus.aspx");
    }
}