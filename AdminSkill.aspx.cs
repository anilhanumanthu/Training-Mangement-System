using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BusinessObject;
using BusinessLogic;

public partial class AdminSkill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddSkill_Click(object sender, EventArgs e)
    {
        if (SkillBox.Text == "")
        {
            SkillBox.BackColor = Color.Red;

        }

        UserBO obj = new UserBO();
        obj.skillName = SkillBox.Text;

        clsBLL obj1 = new clsBLL();
        int result;
        int result1 = obj1.SkillVerifyBLL(obj);
        if (result1 == 0)
        {
            result = obj1.InsertSkillBLL(obj);
            if (result == 1)
            {
                StatusBar.Text = "Skill Added Successfully!!!";
                Response.Write("<script>alert('Skill Added Successfully!!!');</script>");
                Server.Transfer("AdminSkill.aspx");
            }
            else
            {
                StatusBar.Text = "Skill not-Added!!!";
            }
        }
        else
        {
            StatusBar.Text = "Skill You Entered Al-Ready Exists";
        }
    }
    protected void DeleteSkill_Click(object sender, EventArgs e)
    {
        UserBO ob = new UserBO();
        ob.skillName = SkillBox.Text;

        clsBLL obj = new clsBLL();
        int rew = obj.DeleteSkillBLL(ob);


        if (rew == 1)
        {
            StatusBar.Text = "Done";
            Response.Redirect("AdminSkill.aspx");
        }
        else { StatusBar.Text = "Not Deleted"; }
    }
}