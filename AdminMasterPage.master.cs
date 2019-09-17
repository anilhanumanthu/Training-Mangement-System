using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){ 
            if (Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();

        Session.RemoveAll();
        Session.Clear();
        Session["User"] = null;
        Response.Redirect("LoginPage.aspx");
    }
}