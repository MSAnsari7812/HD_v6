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
                LoadData();
                lblReqID.Text = Request.QueryString["reqid"].ToString();
                hfcid.Value = Request.QueryString["cid"].ToString();
                req = wc.GetUserRequest(hfcid.Value, "ALL", "ALL", "ALL");
                if (req.Count>0)
                {
                    lblName.Text = req[0].Name;
                    lblDesignation.Text = req[0].Designation;
                    lblReqCategory.Text = req[0].RequestCategory;
                    lblReqSubject.Text = req[0].RequestSubject;
                }
            }

        }
    }
    protected void LoadData()
    {
        ddlccategory.DataSource = wc.GetComplaintcategory();
        ddlccategory.DataBind();
        ddlsubject.DataSource = wc.GetSubjectList();
        ddlsubject.DataBind();
    }
    WS_CMS wc = new WS_CMS();
    List<UserViewRequest> req = new List<UserViewRequest>();
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
       
        MsgClass mc = new MsgClass();
        LoginClass l = new LoginClass();
        l =(LoginClass)Session["info"];
     ReturnMessageClass rm= wc.UpdateRequestCategory(hfcid.Value,ddlccategory.SelectedItem.Value,ddlsubject.SelectedValue);
        if (rm.Message.Contains("success"))
        {
            mc.ShowPopUpTimer(this,"Request Category Successfully Modify","ViewRequest.aspx");
        }
        else
        {
            mc.ShowPopUpMsgE(this,"Request Modification Failed");
        }
    }
}