using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    CMSDAL.MsgClass mc = new CMSDAL.MsgClass();
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        WS_CMS ws = new WS_CMS();
        string msg = ws.ResetPassword(txtEmailID.Text);
        if (msg.Contains("successfully"))
        {
            mc.ShowPopUpTimer(this, msg, "Login.aspx");
        }
        else if (msg.Contains("failed") || msg.Contains("not"))
        {
            mc.ShowPopUpMsgM(this,msg);
        }
        else
        { mc.ShowPopUpMsgE(this, msg); }
    }
}