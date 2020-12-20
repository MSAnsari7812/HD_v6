using CMSObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HelpDesk_AddEditInventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            loadBuilding(); loadRoom();
            DisplayProductList();
            
            if (Request.QueryString["InvID"] != null)
            {
                hdInvID.Value = Request.QueryString["InvID"].ToString();
                ddlProductName.SelectedIndex = 1;
                LoadDataForUpdate();
            }
         
        }

    }
    private void loadBuilding()
    {
        ddlBuildingName.DataSource = ws.GetBuilding();
        ddlBuildingName.DataBind();

        ddlBuildingName.Items.Insert(0, "Select Buidling");


    }
    private void loadRoom()
    {
        ddlRoomno.DataSource = ws.GetRoom();
        ddlRoomno.DataBind();
        ddlRoomno.Items.Insert(0, "Select Room");

    }
    WS_CMS ws = new WS_CMS();
   
    protected void DisplayProductList()
    {
        ddlProductName.Items.Clear();
        ddlProductName.Items.Add("Select Product");
        ddlProductName.Items.Add("PC");
        ddlProductName.Items.Add("Monitor");
        ddlProductName.Items.Add("KeyBoard");
        ddlProductName.Items.Add("Mouse");
        ddlProductName.Items.Add("UPS");
        ddlProductName.Items.Add("Printer");
        ddlProductName.Items.Add("Scanner");
        ddlProductName.Items.Add("Laptop");
        ddlProductName.Items.Add("Projector");

    }



    protected void lbUpdate_Click(object sender, EventArgs e)
    {

        InventoryClass inv = new InventoryClass();
        ReturnMessageClass rm = new ReturnMessageClass(); ;
        try
        {
            string action = "None";
            inv.InvID = hdInvID.Value;
            inv.BuildingName = ddlBuildingName.SelectedItem.Text;
            inv.Room = ddlRoomno.SelectedItem.Text;
            inv.Product = ddlProductName.SelectedValue;
            inv.Model = txtPCModel.Text;
            inv.SerialNo = txtPCSerialNo.Text;
            inv.Status = txtPCCurrentStatus.Text;
            inv.Problem = txtPCProblem.Text;

            if (hdInvID.Value.Equals("0"))
                action = "Insert";
            else
                action = "Update";


            rm = ws.UpdateInventory(inv, action);

            if (rm.Message.Equals("success"))
            {

                inv.ShowPopUpMsgS(this, action + "Successfully.");


                Reset();

              
               

            }
            else
            {
                inv.ShowPopUpMsgM(this, rm.Message);
            }
        }
        catch
        {
            inv.ShowPopUpMsgE(this, rm.Message);
        }

    }

    protected void LoadDataForUpdate()

    {
        List<InventoryClass> ic = new List<InventoryClass>();
        try
        {

            if (!hdInvID.Value.Equals("0"))
            {
                ic = ws.GetInventoryProduct(ddlProductName.SelectedValue, hdInvID.Value);
                if (ic.Count > 0)
                {
                    txtPCModel.Text = ic[0].Model;
                    txtPCSerialNo.Text = ic[0].SerialNo;
                    txtPCCurrentStatus.Text = ic[0].Status;
                    txtPCProblem.Text = ic[0].Problem;
                    ddlBuildingName.SelectedValue = ic[0].BuildingName;
                    ddlRoomno.SelectedValue = ic[0].Room;


                }
            }

        }
        catch (Exception er)
        {
            ic[0].ShowPopUpMsgE(this, er.Message.ToString());
        }
    }

    protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
    {

        LoadDataForUpdate();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        InventoryClass inv = new InventoryClass();
        ReturnMessageClass rm = new ReturnMessageClass(); ;
        try
        {
            string action = "None";
            inv.InvID = hdInvID.Value;
            inv.BuildingName = ddlBuildingName.SelectedItem.Text;
            inv.Room = ddlRoomno.SelectedItem.Text;
            inv.Product = ddlProductName.SelectedValue;
            inv.Model = txtPCModel.Text;
            inv.SerialNo = txtPCSerialNo.Text;
            inv.Status = txtPCCurrentStatus.Text;
            inv.Problem = txtPCProblem.Text;

            if (!hdInvID.Value.Equals("0"))
                action = "Delete";


            rm = ws.UpdateInventory(inv, action);

            if (rm.Message.Equals("success"))
            {

                inv.ShowPopUpMsgS(this, action + " Successfully.");

                Reset();

            }
            else
            {
                inv.ShowPopUpMsgM(this, rm.Message);
            }
        }
        catch
        {
            inv.ShowPopUpMsgE(this, rm.Message);
        }

    }

   
    protected void Reset()
    {
        hdInvID.Value = "0";
        txtPCModel.Text = txtPCProblem.Text = txtPCSerialNo.Text = txtPCCurrentStatus.Text = "";
        ddlRoomno.SelectedIndex = ddlProductName.SelectedIndex = ddlBuildingName.SelectedIndex = 0;

    }

   

    protected void btnnew_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void btview_Click(object sender, EventArgs e)
    {
        Response.Redirect("inventoryview.aspx",false);
    }
}