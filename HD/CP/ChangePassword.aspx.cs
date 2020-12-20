using CMSDAL;
using CMSObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_ChangePassword : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {

        if (Application["mpage"] != null)
            this.MasterPageFile = Application["mpage"].ToString();
        // do the bartman
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MsgClass mc = new MsgClass();
        WS_CMS ws = new WS_CMS();
       
        LoginClass lc = new LoginClass();
        lc = (LoginClass)Session["info"];
        lc = ws.ChangePassword(lc.lid,txtOldPassword.Text,txtConfirmPassword.Text);
        if (lc.ErrorMassage.Contains("Success"))
        {
            mc.ShowPopUpTimer(this,"Password change successfull.", "Dashboard.aspx");
          
        }
        else
        {
            mc.ShowPopUpMsgM(this, "Password not change try again.");
        }

    }
}