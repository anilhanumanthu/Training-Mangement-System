
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

public partial class RegistrationPage : System.Web.UI.Page
{
    int usertyper = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
            clsBLL obj = new clsBLL();
            if (obj.AdminCounterBLL() >= 1)
            {
                usertyper = 2;
            }

            if (usertyper == 2)
            {
                UserTypeDropRegister.Visible = false;
                UserTypeDropRegister1.Visible = true;
            }
            else
            {
                UserTypeDropRegister1.Visible = false;
                UserTypeDropRegister.Visible = true;
            }
        
    }

    protected void RegisterButton_Click1(object sender, EventArgs e)
    {
        if (FNameRegister.Text == "" || FNameRegister.Text.Any(char.IsDigit))
        {
            FNameRegister.BackColor = Color.Red;
        }
        else
        {
            FNameRegister.BackColor = Color.White;
        }
        if (LNameRegister.Text == "" || LNameRegister.Text.Any(char.IsDigit))
        {
            LNameRegister.BackColor = Color.Red;
        }
        else
        {
            LNameRegister.BackColor = Color.White;
        } if (AgeRegister.Text == "")
        {
            AgeRegister.BackColor = Color.Red;
        }
        else
        {
            AgeRegister.BackColor = Color.White;
        } if (GenderDropRegister.Text == "")
        {
            GenderDropRegister.BackColor = Color.Red;
        }
        else
        {
            GenderDropRegister.BackColor = Color.White;
        } if (ContactTelRegister.Text == "")
        {
            ContactTelRegister.BackColor = Color.Red;
        }
        else
        {
            ContactTelRegister.BackColor = Color.White;
        } if (UserIDRegister.Text == "")
        {
            UserIDRegister.BackColor = Color.Red;
        }
        else
        {
            UserIDRegister.BackColor = Color.White;
        } if (PasswordRegister.Text == "")
        {
            PasswordRegister.BackColor = Color.Red;
        }
        else
        {
            PasswordRegister.BackColor = Color.White;
        } if (MailIDRegister.Text == "" || MailIDRegister.Text.Length <= 10)
        {
            MailIDRegister.BackColor = Color.Red;
        }
        else
        {
            MailIDRegister.BackColor = Color.White;
        } if (UserTypeDropRegister.Text == "" || UserTypeDropRegister.Text.Any(char.IsDigit))
        {
            UserTypeDropRegister.BackColor = Color.Red;
        }
        else
        {
            UserTypeDropRegister.BackColor = Color.White;
        }


        UserBO ob1 = new UserBO();
        ob1.fname = FNameRegister.Text.Trim();
        ob1.lname = LNameRegister.Text.Trim();
        try
        {
            ob1.age = Convert.ToInt32(AgeRegister.Text);
        }
        catch
        {
            ob1.age = 0;
        }
        if (ob1.age == 0) { Response.Write("<script>alert('age must be an Integer')</script>"); }
        ob1.gender = GenderDropRegister.Text;
        ob1.contactno = ContactTelRegister.Text.Trim();
        ob1.userid = UserIDRegister.Text.Trim();
        ob1.password = PasswordRegister.Text.Trim();
        ob1.mailID = MailIDRegister.Text.Trim();

        if (usertyper == 2) { ob1.userType = UserTypeDropRegister1.Text; }
        else { ob1.userType = UserTypeDropRegister.Text; }

        clsBLL ob2 = new clsBLL();
        clsBLL ob3 = new clsBLL();

        int verifyUser = ob2.VerifyUserIDBLL(ob1);
        int result = ob3.InsertRegisterData(ob1);


        if (FNameRegister.Text.Any(char.IsDigit) || ob1.lname == "" || ob1.contactno == "" || MailIDRegister.Text.Length <= 10 || ob1.userid == "" || ob1.password == "" || ob1.mailID == "" || FNameRegister.Text.Contains(" ") || LNameRegister.Text.Contains(" ") || LNameRegister.Text.Any(char.IsDigit) || UserTypeDropRegister.Text.Any(char.IsDigit)) { Response.Write("<script>alert('Looks like there is some error check the deatails u have entered');</script>"); Response.Write("<script> return DivChange();</script>"); }


        if (verifyUser == 1)
        {
            Response.Write("<script>alert('Sir There is already a UserId that You have entered')</script>");
        }
        else if (verifyUser == 0)
        {
            if (UserIDRegister.Text == "" || FNameRegister.Text == "" || LNameRegister.Text == "" || AgeRegister.Text == "" || GenderDropRegister.Text == "" || ContactTelRegister.Text == "" || PasswordRegister.Text == "" || MailIDRegister.Text == "" || UserTypeDropRegister.Text == "") { Response.Write("<script>alert('Sir some values are missing check the boxes that are in red')</script>"); }
            else if (result == 1)
            {
                StatusRegistration.Text = "Registration SuccessFul";
                Response.Write("<script>alert('Registration SuccessFul')</script>");
                Server.Transfer("LoginPage.aspx");
            }
            else if (result == 0)
            {
                StatusRegistration.Text = "Registration Un-SuccessFul";
                Response.Write("<script>return DivChange();</script>");
            }

        }



    }
}