using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessObject;
using System.Data;

public partial class AdminSelectedUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        UserBO ob = new UserBO();

        ob.coursecode = Session["AdminSelectedUserCourse"].ToString();
        ob.userid = Session["AdminSelectedUser"].ToString();


        

        clsBLL obj = new clsBLL();
        List<string> mylist =  obj.getScoreDetailsBLL(ob);

        DataTable questiontable = obj.QuestionTableCreatorBLL(ob);
        int countofQuestions = questiontable.Rows.Count;

        int a;
        try {a = Convert.ToInt32((Convert.ToDouble(mylist[3]) / countofQuestions) * 100); } catch { a = 0; }

        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "draw(" + a + ")", true);

        userid.Text = mylist[0];
        Coursecode.Text = mylist[1];
        date.Text = mylist[2];
        score.Text = "("+mylist[3]+"/"+countofQuestions.ToString() + ")";
        Percentage.Text = a.ToString();
        status.Text = mylist[4];
        

    }
}