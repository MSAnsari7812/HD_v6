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
            loadBuilding();
            loadRoom();
            LoadData();
         
        }
    }

    private void loadBuilding()
    {
        ddlBuildingName.DataSource = ws.GetBuilding();
        ddlBuildingName.DataBind();

        ddlBuildingName.Items.Insert(0, "ALL");


    }
    private void loadRoom()
    {
        ddlRoom.DataSource = ws.GetRoom();
        ddlRoom.DataBind();
        ddlRoom.Items.Insert(0, "ALL");

    }

    WS_CMS ws = new WS_CMS();
    protected void LoadData()
    {try
        {
            List<CMSObject.Inventory> ur = new List<CMSObject.Inventory>();

            ur = ws.GetInventory("0",ddlBuildingName.SelectedValue,ddlRoom.SelectedValue); //ws.GetDailyWorkSheetReport1(DropDownList1.SelectedValue, ddlsystem.SelectedValue, ddlsubtask.SelectedValue);
            ReportParameterCollection parameterlist = new ReportParameterCollection();

            parameterlist.Add(new ReportParameter("prBuildingName", ddlBuildingName.SelectedValue));
            parameterlist.Add(new ReportParameter("prRoom",ddlRoom.SelectedValue));
            ReportViewer1.LocalReport.SetParameters(parameterlist);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.DataSources.Clear();
         
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ur));
            ReportViewer1.LocalReport.Refresh();
        }
        catch {
        }


    }



    protected void lbSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}