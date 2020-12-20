using CMSDAL;
using CMSObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRequest : System.Web.UI.Page
{
    WS_CMS ws = new WS_CMS();
    CMSClass cc = new CMSClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadData();
            txtcdate.Text = cc.GetDateTime().ToShortDateString();
            loadComplainantList();
        }
    }

    protected void loadComplainantList()
    {
        DataTable dt = new DataTable();

        dt = ws.GetComplainant("ALL");
        ddlComplainantName.DataSource = dt;
        ddlComplainantName.DataBind();




    }

    CommonReturnMsg rm = new CommonReturnMsg();
    protected void LoadData()
    {
        ddlccategory.DataSource = cws.GetComplaintcategory();
        ddlccategory.DataBind();
        ddlsubject.DataSource = cws.GetSubjectList();
        ddlsubject.DataBind();
    }
    MsgClass mc = new MsgClass();
    WS_CMS cws = new WS_CMS();
    protected void lbSubmit_Click(object sender, EventArgs e)
    {
        lbSubmit.Enabled = false;
       
      
        try
        {
               rm = cws.NewComplain(0,ddlComplainantName.SelectedValue,
                  Convert.ToDateTime(cc.GetDateTime()),
                 ddlccategory.SelectedValue,
                 ddlsubject.SelectedValue,
                  txtComplaint.Text, txtremark.Text);

            if (rm.msg.Contains("Succ"))
            {
                mc.ShowPopUpTimer(this, "Help Desk ID : " +rm.id, "ViewRequest.aspx");
              
            }
            else
                mc.ShowPopUpMsgM(this, rm.msg);
        }
        catch (Exception er)
        {
            mc.ShowPopUpMsgE(this, rm.msg);
        }
    }
    protected void Clear()
    {
         txtcdate.Text = txtComplaint.Text = 
           txtremark.Text = String.Empty;
     ddlsubject.SelectedIndex=   ddlccategory.SelectedIndex = 0;
        lbSubmit.Enabled = true;

    }
}