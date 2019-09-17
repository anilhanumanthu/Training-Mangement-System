using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using DataLinkLayer;
using BusinessLogic;
using System.Threading;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        UserBO ob1 = new UserBO();
        ob1.userid = UserLogin.Text;
        ob1.password = PassLogin.Text;

        clsBLL ob2 = new clsBLL();
        clsBLL ob3 = new clsBLL();
        int result = ob2.VerifyLoginData(ob1);
        int typeuser = ob3.FindUserTypeBLL(ob1);

        if (result == 1)
        {
            StatusLogin.Text = "Login SuccessFul";

            if (typeuser == 1) {
                Session["User"]=ob1.userid;
                Response.Redirect("AdminMainPage.aspx"); }
            else { Session["User"] = ob1.userid; Response.Redirect("UserMain.aspx"); }

        }
        else
        {
            StatusLogin.Text = "UnAuthorised Credentials";
        }
    }
}