using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CallManagementSystem : System.Web.UI.MasterPage
{
    CMSDAL.CMSClass cc = new CMSDAL.CMSClass();
    CMSDAL.MsgClass mc = new CMSDAL.MsgClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["info"] == null)
            Response.Redirect("../logout.aspx");

        if (!Page.IsPostBack)
        {
            try
            {
                lblTodaysDateTime.Text = cc.GetDateTime().ToString("dd MMM yyyy hh:mm");
            }
            catch(Exception er) {
                lblmsg.Text = er.Message.ToString();
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "JCall1", "ShowAlert();", false);

            }
            }
    }
}
