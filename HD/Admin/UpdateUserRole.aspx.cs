using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSObject;

public partial class Admin_UserProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
              
              
        

                LoadUserProduct();
            }
            catch(Exception er) {
                Application["lasterror"] = er.Message;

                mc.ShowPopUpMsgE(this,er.Message.ToString());
            }
        }
    }
    
    CMSDAL.MsgClass mc = new CMSDAL.MsgClass();
    WS_CMS ws = new WS_CMS();
  
   
   
    protected void LoadUserProduct()
    {
        GridView1.DataSource = ws.GetUserRole();
        GridView1.DataBind();
    }

    protected void lbSave_Click(object sender, EventArgs e)
    {
       UserRoleClass up = new UserRoleClass();
        up.RoleName = txtRoleTitle.Text;
        up.Priority = ddlPriority.SelectedValue;
      
        string action = "Insert";

        if (hfrolename.Value!="0")
        {
            action = "Update";
        }

       string str= ws.UpdateUserRole(up, action);

        if (str.Equals("success"))
        { mc.ShowPopUpMsgS(this, "Successfully Saved."); Reset(); }
        else
            mc.ShowPopUpMsgM(this, "Failed to Save");

    }
    protected void Reset()
    {

        txtRoleTitle.Text = "";
        ddlPriority.SelectedIndex = 0;
        LoadUserProduct();
       

    }

  

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            List<UserRoleClass> pc = new List<UserRoleClass>();
            pc = ws.GetUserRole(e.CommandArgument.ToString());
            if (e.CommandName.Equals("ED"))
            {

               txtRoleTitle.Text=hfrolename.Value = pc[0].RoleName;
                ddlPriority.SelectedValue = pc[0].Priority;

            }
            else if (e.CommandName.Equals("DEL"))
            {


                string str = ws.UpdateUserRole(pc[0], "Delete");
                if (str.Equals("success"))
                {
                    mc.ShowPopUpMsgS(this, "Delete Successfull.");
                    Reset();
                }
                else
                {
                    mc.ShowPopUpMsgM(this, "Failed to Delete");
                }
            }
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,er.Message.ToString().Trim());
        }
    }
}