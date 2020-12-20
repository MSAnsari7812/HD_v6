using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSDAL;
using CMSObject;

public partial class Admin_AssignToEngg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["cid"] != null) {
                lblReqID.Text ="Req. ID "+ Request.QueryString["reqid"].ToString();
                hfcid.Value = Request.QueryString["cid"].ToString();

            }

        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        WS_CMS wc = new WS_CMS();
        MsgClass mc = new MsgClass();
        WS_Notification wn = new WS_Notification();
       LoginClass lc = new LoginClass();

        try
        {

            lc = wc.GetUserDetailsByCID(hfcid.Value);
            string str = "Not Send";
            if (cksms.Checked == true)
            {
                if (TextBox1.Text.Length > 0)
                    str = WS_Notification.NotificationBySMS(lc.commmobileno,TextBox1.Text);
                else
                    mc.ShowPopUpMsgM(this, "Type SMS Message.");
            }
            if (ckemail.Checked == true)
            {
                if (TextBox2.Text.Length > 0)
                    str =WS_Notification.NotificationByEmail(lc.commemail, "Help Desk - Notification", TextBox2.Text);
                else
                    mc.ShowPopUpMsgM(this, "Type Email Message.");
            }

            if (cksms.Checked == true || ckemail.Checked == true)
            {
                if (str.Contains("Not") || str.Contains("Failed")) {
                    mc.ShowPopUpMsgM(this, str);
                }
                else
                {
                    mc.ShowPopUpMsgS(this, str);
                    TextBox1.Text = TextBox2.Text = "";
                }
            }
          
        }
        catch(Exception er) {

            mc.ShowPopUpMsgE(this, er.Message.ToString());
        }
           
    }
}