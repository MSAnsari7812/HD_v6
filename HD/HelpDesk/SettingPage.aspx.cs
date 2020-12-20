using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSDAL;
using System.Data;
using CMSObject;

public partial class HelpDesk_SettingPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MultiView1.SetActiveView(vwBuilding);
            SetNotificationStatus();
        }
    }
    protected void SetNotificationStatus()
    {
        string sql = "select * from notificationsettingtab";

        DataTable dt = new DataTable();

        dt = cm.GetDataTable(sql);

        foreach (DataRow dr in dt.Rows)
        {
            hfnotificationid.Value = dr["nid"].ToString();
            ddlemailstatus.SelectedValue = dr["emailstatus"].ToString();
            ddlsms.SelectedValue = dr["smsstatus"].ToString();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList1.SelectedValue=="Building") MultiView1.SetActiveView(vwBuilding);
       else if (DropDownList1.SelectedValue == "Room") MultiView1.SetActiveView(vwRoom);
        else if (DropDownList1.SelectedValue== "Subject") MultiView1.SetActiveView(vwSubject);
        else if (DropDownList1.SelectedValue == "Notification") MultiView1.SetActiveView(vwNotification);
        else if (DropDownList1.SelectedValue == "Category") MultiView1.SetActiveView(vwCategory);
        else if (DropDownList1.SelectedValue == "Designation") MultiView1.SetActiveView(vwDesignation);

    }
   CMSClass cm = new CMSClass();

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName.ToString();
        string[] strarg = e.CommandArgument.ToString().Split(':');
        string sql = "";
        if (cmd.Equals("Del"))
        {
            sql = "delete from buildingtab where bid="+strarg[0];
            cm.Inst_update(sql);
            GridView1.DataBind();
        }
        else if (cmd.Equals("Ed"))
        {
            hfid.Value = strarg[0];
            txtBuildingName.Text = strarg[1];
            lblmsg.Text = "Edit Building ID : "+hfid.Value;
        }

      

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName.ToString();
        string[] strarg = e.CommandArgument.ToString().Split(':');
        string sql = "";
        if (cmd.Equals("Del"))
        {
            sql = "delete from roomtab where roomid=" + strarg[0];
            cm.Inst_update(sql);
            GridView2.DataBind();
        }
        else if (cmd.Equals("Ed"))
        {
            hfid.Value = strarg[0];
            txtBuildingName.Text = strarg[1];
            lblmsg.Text = "Edit Room ID : " + hfid.Value;
        }



    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName.ToString();
        string[] strarg = e.CommandArgument.ToString().Split(':');
        string sql = "";
        if (cmd.Equals("Del"))
        {
            sql = "delete from subjecttab where subid=" + strarg[0];
            cm.Inst_update(sql);
            GridView3.DataBind();
        }
        else if (cmd.Equals("Ed"))
        {
            hfid.Value = strarg[0];
            txtBuildingName.Text = strarg[1];
            lblmsg.Text = "Edit Subject ID : " + hfid.Value;
        }



    }
    MsgClass mc = new MsgClass();
    protected void lblSaveBuilding_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "";
            if (hfid.Value.Equals("0"))
                sql = "insert into buildingtab values('" + txtBuildingName.Text + "')";
            else
                sql = "Update buildingtab set buildingname='" + txtBuildingName.Text + "' where bid=" + hfid.Value;

            int i = cm.Inst_update(sql);
            if (i != 0)
            {
                mc.ShowPopUpMsgS(this, "Building Name Saved.");
            }
            else
                mc.ShowPopUpMsgM(this, "Not Save");

            GridView1.DataBind();
            hfid.Value = "0";
            txtBuildingName.Text = "";
        }
        catch(Exception er) {

            mc.ShowPopUpMsgE(this, er.Message.ToString().Trim());
        }
       
    }

    protected void lblSaveRoom_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "";
            if (hfid.Value.Equals("0"))
                sql = "insert into roomtab values('" + txtroom.Text + "')";
            else
                sql = "Update roomtab set room='" + txtroom.Text + "' where bid=" + hfid.Value;

            int i = cm.Inst_update(sql);
            if (i != 0)
            {
                mc.ShowPopUpMsgS(this, "Room No Saved.");
            }
            else
                mc.ShowPopUpMsgM(this, "Not Save");

            GridView2.DataBind();
            hfid.Value = "0";
            txtBuildingName.Text = "";
        }
        catch (Exception er)
        {

            mc.ShowPopUpMsgE(this, er.Message.ToString().Trim());
        }
    }

    protected void lbSaveSubject_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "";
            if (hfid.Value.Equals("0"))
                sql = "insert into subjecttab values('" + txtSubject.Text + "')";
            else
                sql = "Update subjecttab set subject='" + txtSubject.Text + "' where subid=" + hfid.Value;

            int i = cm.Inst_update(sql);
            if (i != 0)
            {
                mc.ShowPopUpMsgS(this, "Subject / Issue Saved.");
            }
            else
                mc.ShowPopUpMsgM(this, "Not Save");

            GridView3.DataBind();
            hfid.Value = "0";
            txtBuildingName.Text = "";
        }
        catch (Exception er)
        {

            mc.ShowPopUpMsgE(this, er.Message.ToString().Trim());
        }
    }

    protected void lbsmsemail_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "";
            sql = "Update NotificationSettingTab set emailstatus='" + ddlemailstatus.SelectedValue + "',smsstatus='"+ddlsms.SelectedValue+"' where nid=" + hfnotificationid.Value;

            int i = cm.Inst_update(sql);
            if (i != 0)
            {
                mc.ShowPopUpMsgS(this, "Notification Saved.");
            }
            else
                mc.ShowPopUpMsgM(this, "Not Save");

          
           hfnotificationid.Value = "0";
            SetNotificationStatus();
        }
        catch (Exception er)
        {

            mc.ShowPopUpMsgE(this, er.Message.ToString().Trim());
        }
    }

    protected void lbSaveCategory_Click(object sender, EventArgs e)
    {
        try
        {
            WS_CMS ws = new WS_CMS();
            CategoryClass cat = new CategoryClass();
            string action = "Insert";
            cat.Category = txtCategory.Text;
            cat.catID =int.Parse(hfcatid.Value);
            if (hfid.Value != "0")
                action = "Update";

            string rvalue = ws.UpdateCategory(cat,action);
            if (rvalue.Equals("success"))
            {
                mc.ShowPopUpMsgS(this, action + " Successfully Done");
            }
            else
            {
                mc.ShowPopUpMsgM(this, action + "Failed");
            }
        }
        catch(Exception er) { mc.ShowPopUpMsgE(this, er.Message.ToString()); }
    }

    protected void GVCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string cmd = e.CommandName.ToString();
            string[] strarg = e.CommandArgument.ToString().Split(':');
            string sql = "";
            if (cmd.Equals("Del"))
            {
                sql = "delete from Categorytab where catid=" + strarg[0];
                cm.Inst_update(sql);
                GVCategory.DataBind();
            }
            else if (cmd.Equals("Ed"))
            {
                hfcatid.Value = strarg[0];
                txtCategory.Text = strarg[1];
                lblmsg.Text = "Edit Category ID : " + hfcatid.Value;
            }
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,er.Message.ToString());
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtBuildingName.Text = "";
        hfid.Value = "0";
        GridView1.DataBind();
        GridView1.SelectedIndex = -1;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        txtroom.Text = "";
        hfid.Value = "0";
        GridView2.DataBind();
        GridView2.SelectedIndex = -1;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        txtSubject.Text = "";
        hfid.Value = "0";
        GridView3.DataBind();
        GridView3.SelectedIndex = -1;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        txtCategory.Text = "";
        hfcatid.Value = "0";
        GVCategory.DataBind();
        GVCategory.SelectedIndex = -1;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        txtDesignation.Text = "";
        hfid.Value = "0";
        GVDesignation.DataBind();
        GVDesignation.SelectedIndex = -1;
    }
    protected void GVDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string cmd = e.CommandName.ToString();
            string[] strarg = e.CommandArgument.ToString().Split(':');
            string sql = "";
            if (cmd.Equals("Del"))
            {
                sql = "delete from Designationtab where designation=" + strarg[0];
                cm.Inst_update(sql);
                GVDesignation.DataBind();
            }
            else if (cmd.Equals("Ed"))
            {
                hfid.Value = strarg[0];
                txtDesignation.Text = strarg[1];
                lblmsg.Text = "Edit Designation : " + hfid.Value;
            }
        }
        catch (Exception er)
        {
            mc.ShowPopUpMsgE(this, er.Message.ToString());
        }

    }

    protected void lbSaveDesignation_Click(object sender, EventArgs e)
    {
        try
        {
            WS_CMS ws = new WS_CMS();
            DesignationClass des = new DesignationClass();
            string action = "Insert";
            des.Designation = txtDesignation.Text;
            
            if (hfid.Value != "0")
                action = "Update";

            string rvalue = ws.UpdateDesignation(des, action);
            if (rvalue.Equals("success"))
            {

                mc.ShowPopUpMsgS(this, action + " Successfully Done");
                Button6_Click(sender, e);
            }
            else
            {
                mc.ShowPopUpMsgM(this, action + "Failed");
            }
        }
        catch (Exception er) { mc.ShowPopUpMsgE(this, er.Message.ToString()); }
    }

}