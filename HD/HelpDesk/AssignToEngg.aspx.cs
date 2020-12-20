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
                lblReqID.Text = Request.QueryString["reqid"].ToString();
                hfcid.Value = Request.QueryString["cid"].ToString();
                lc = wc.GetUserDetailsByCID(hfcid.Value);
                if (lc != null)
                {
                    lblName.Text = lc.name;
                    lblDesignation.Text = lc.designation;
                }
                
               
            }

        }
    }
    WS_CMS wc = new WS_CMS();
    LoginClass lc = new LoginClass();
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
       
        MsgClass mc = new MsgClass();
        LoginClass l = new LoginClass();
        l =(LoginClass)Session["info"];
      string s= wc.AssignEngineer(hfcid.Value, ddlEnggList.SelectedItem.Value, ddlEnggList.SelectedItem.Text,l.lid.ToString());
        if (s.Contains("Success"))
        {




            mc.ShowPopUpTimer(this,"Request Assign Successfull","ViewRequest.aspx");
        }
        else
        {
            mc.ShowPopUpMsgE(this,s);
         }
    }

    protected void ddlEnggList_DataBound(object sender, EventArgs e)
    {
        ddlEnggList.Items.Add(new ListItem { Text = "-----------------", Value = "0" });
        ddlEnggList.Items.Add(new ListItem { Text = "Not Assign", Value = "-1" });
    }
}