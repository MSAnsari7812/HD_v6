using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CMSObject;
using CMSDAL;

public partial class LoginPage : System.Web.UI.Page
{
    LoginClass lc = new LoginClass();
    CMSClass cc = new CMSClass();
    protected void Page_PreInit(object sender, EventArgs e)
    {

        if (Application["mpage"] != null)
            this.MasterPageFile = Application["mpage"].ToString();
        // do the bartman
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                lc = (LoginClass)Session["info"];

                sb.Append("<h5><span class='text-info'>Welcome </span>" + lc.name.ToUpper() + "</h1></br>");
                sb.Append("<h5><span class='text-info'>Account Role : </span> " + lc.role.ToUpper() + "</h1></br>");
                sb.Append("<h5><span class='text-info'>Email ID :</span> " + lc.commemail + "</h1></br>");
                sb.Append("<h5><span class='text-info'>Mobile NO :</span> " + lc.commmobileno + "</h1></br>");
                //sb.Append("<h3><span class='text-info'>User ID :</span> " + lc.username + "</h1></br>");

                sb.Append("<h5><span class='text-info'>Today : </span> " + cc.GetDateTime().ToString("dd MMM yyyy hh:mm") + "</h1></br>");

                Literal1.Text = sb.ToString();
            }
            catch(Exception er) {
                MsgClass mc = new MsgClass();
                mc.ShowPopUpMsgE(this, er.Message.ToString());
            }
        }

    }
}