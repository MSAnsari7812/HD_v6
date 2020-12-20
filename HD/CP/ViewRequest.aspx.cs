using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSObject;
using CMSDAL;
using System.Web.Services;

public partial class UserViewRequest : System.Web.UI.Page
{
    LoginClass lc = new LoginClass();
    WS_CMS wc = new WS_CMS();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if(Application["mpage"]!=null)
        this.MasterPageFile = Application["mpage"].ToString();
        // do the bartman
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lc = (LoginClass)Session["info"];
          
            GetRequestList();  
        }
    }
    MsgClass mc = new MsgClass();
    protected void GetRequestList()
    {
        try
        {
            lc = (LoginClass)Session["info"];
            IList<UserViewRequest> lv = new List<UserViewRequest>();

         ListView1.DataSource=   wc.GetUserRequest("ALL",lc.lid.ToString(), "ALL", "ALL");
            ListView1.DataBind(); 
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,er.Message.ToString());
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Access Cell values.
           // int customerId = int.Parse(e.Row.Cells[6].Text);
            string status = e.Row.Cells[6].Text;

            if (status.Equals("Open"))
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
               // e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#2eb82e");
            }
           
        }
    }

    protected void ListView1_DataBound(object sender, EventArgs e)
    {
        foreach (ListViewItem lvi in ListView1.Items)
        {

            Label l = (Label)lvi.FindControl("Label6");
            if (l.Text.Equals("Open"))
            {
                l.CssClass = "ReqOpen";
            }
            else if (l.Text.Equals("Pending"))
            {
                l.CssClass = "ReqPending";
            }
            else 
            { l.CssClass = "ReqClose"; }



        }
    }
    WS_CMS ws = new WS_CMS();
   
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
     
        lc = (LoginClass)Session["info"];
        string cid = e.CommandArgument.ToString();
        string cmd = e.CommandName.ToString();
        if (cmd.Equals("Del"))
        {
            string msg = ws.DeleteRequest(cid, lc.lid.ToString());

            if (msg.Contains("Success"))
            {
                mc.ShowPopUpMsgS(this, "Delete Successfull");
                GetRequestList();
            }
            else if (msg.Equals("Failed"))
                mc.ShowPopUpMsgM(this, "Delete Action Failed ");
            else
                mc.ShowPopUpMsgE(this, msg);

        }
       
    }

   

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string str = txtComments.Text;
        if (str.Length == 0)
            str = "Change Request Status By User.";
       string msg= ws.UpdateRequestStatus(hfcid.Value, ddlRequestStatus.SelectedValue, str);
        if (msg.Contains("Succ"))
        {
            mc.ShowPopUpMsgS(this, "Successfully Changed");
            GetRequestList();
            ddlRequestStatus.SelectedIndex = 0;
            hfcid.Value = "0";
            //Page.ClientScript.RegisterStartupScript(this.GetType(),"closepopupkey", "Success()", true);

        }
        else
        {
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "closepopupkey", "Failed()", true);

  mc.ShowPopUpMsgE(this, "Not change with "+msg);
        }
    }




}