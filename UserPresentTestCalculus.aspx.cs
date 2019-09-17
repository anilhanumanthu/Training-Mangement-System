using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BusinessObject;
using BusinessLogic;
using System.Data;
using System.Web.UI.WebControls;

public partial class UserPresentTestCalculus : System.Web.UI.Page
{
    public static int passgrade = 70;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        clsBLL obj = new clsBLL();
        ob.userid = Session["User"].ToString();
        ob.coursecode = Session["CourseSelected"].ToString();
        ob.maxquestioncount = Session["questioncount"].ToString();

        int score_achieved = Convert.ToInt32(obj.scorecardBLL(ob));

        ob.score = score_achieved.ToString();

        StatusBar.Text = score_achieved.ToString() +" / "+ob.maxquestioncount.ToString();

        DataTable questiontable = obj.QuestionTableCreatorBLL(ob);

        afterAnswered.DataSource = questiontable;
        afterAnswered.DataBind();

        int myavg = (score_achieved / Convert.ToInt32(Session["questioncount"])) * 100;

        if(myavg > passgrade) { ob.status = "passed"; }
        else { ob.status = "Progress"; }

        ob.completiondate = DateTime.Today.ToString("dd-MM-yyyy");


        obj.updateStatusBLL(ob);
        

    }
}