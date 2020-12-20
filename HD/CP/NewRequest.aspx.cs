using CMSDAL;
using CMSObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRequest : System.Web.UI.Page
{
    CMSClass cc = new CMSClass();
    LoginClass lc = new LoginClass();
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
           
        
         
            LoadData();
            txtcdate.Text = cc.GetDateTime().ToString();

        }
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
          
           

            rm = cws.NewComplain(0,lc.lid.ToString(),
                  Convert.ToDateTime(cc.GetDateTime()),
                 ddlccategory.SelectedValue,
                 ddlsubject.SelectedValue,
                  txtComplaint.Text, txtremark.Text);

            if (rm.msg.Contains("Succ"))
            {
                mc.ShowPopUpMsgS(this,"Help Desk ID : "+rm.id);
                Clear();
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