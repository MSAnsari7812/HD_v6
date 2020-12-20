using CMSDAL;
using CMSObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  MsgClass mc = new MsgClass();
    LoginClass lc = new LoginClass();
    protected void lbsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Application["mpage"] = "";
            WS_CMS cws = new WS_CMS();
            lc = cws.CheckLogin(txtusername.Text, txtpassword.Text);
            //Your subscription has expired

           if (lc.status.Equals("expired"))
            {
                mc.ShowPopUpMsgM(this, "Your subscription has expired.");
            }
            else if (lc.status == "success")
            {
                Session["info"] = lc;
                if (lc.role.Contains("Admin"))
                {
                    Application["mpage"] = "../Admin/AdminMaster.master";
                   }
                else if (lc.role.Equals("Help Desk"))
                {
                    Application["mpage"] = "../HelpDesk/Helpdesk.master";
                   
                }
                else if (lc.role.Contains("Engineer"))
                {
                    Application["mpage"] = "../Engineer/EngineerMaster.master";
                   }
                else if (lc.role.Equals("User"))
                {
                    Application["mpage"] = "../Users/UserMaster.master";
                  }

                Response.Redirect("CP/dashboard.aspx", true);

            }
            else if (lc.status.Equals("failed"))
            {
                mc.ShowPopUpMsgM(this, "Invalid User Name or Password");
            }
            else
            {
                mc.ShowPopUpMsgE(this, lc.ErrorMassage);
            }


        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,er.Message.ToString().Trim());
        }
    }

    protected void txtpassword_TextChanged(object sender, EventArgs e)
    {
        lbsubmit_Click(sender, e);
    }
}