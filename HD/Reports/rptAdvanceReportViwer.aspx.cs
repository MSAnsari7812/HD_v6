using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_rptComplainFormViewer : System.Web.UI.Page
{
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
            LoadDropdown();
            LoadData("ALL", "ALL", "ALL", "ALL");
         
        }
    }

    protected void LoadDropdown()
    {
        ddlUsers.DataSource = ws.GetHDUsersList(0,"User");
        ddlUsers.DataBind();
        ddlEngg.DataSource = ws.GetHDEnggList(0);
        ddlEngg.DataBind();

    }

    WS_CMS ws = new WS_CMS();
    protected void LoadData(string lid,string enggid,string dt1,string dt2)
    {try
        {
            List<CMSObject.UserViewRequest> ur = new List<CMSObject.UserViewRequest>();

            ur = ws.GetRequestReports(lid, enggid, dt1, dt2); //ws.GetDailyWorkSheetReport1(DropDownList1.SelectedValue, ddlsystem.SelectedValue, ddlsubtask.SelectedValue);

            ReportParameterCollection parameterlist = new ReportParameterCollection();

            parameterlist.Add(new ReportParameter("fromDate", dt1));
            parameterlist.Add(new ReportParameter("ToDate", dt2));
            parameterlist.Add(new ReportParameter("UserName", ddlUsers.SelectedItem.Text));
            parameterlist.Add(new ReportParameter("EnggName", ddlEngg.SelectedItem.Text));

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.SetParameters(parameterlist);
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("rptDataSet", ur));
            ReportViewer1.LocalReport.Refresh();
        }
        catch {
        }


    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string dt1 = (TextBox1.Text.Length > 0) ? TextBox1.Text : "ALL";
        string dt2 = (TextBox2.Text.Length > 0) ? TextBox2.Text : "ALL";
        LoadData(ddlUsers.SelectedValue,ddlEngg.SelectedValue,dt1,dt2);
    }
}