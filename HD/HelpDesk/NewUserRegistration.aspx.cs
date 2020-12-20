using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSObject;

public partial class NewUserRegistration : System.Web.UI.Page
{
    WS_CMS cm = new WS_CMS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
                    LoadData();
        }
    }
    protected void LoadData()
    {

        ddlbuilding.DataSource = cm.GetBuilding();
        ddlbuilding.DataBind();
      

    }
    CMSDAL.MsgClass mc = new CMSDAL.MsgClass();
    protected void lbSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            NewRegistrationClass nr = new NewRegistrationClass();

            nr.Id = 0;
            nr.Name = txtName.Text;
            nr.Batch = txtBatchNo.Text;
            nr.RollNo = txtRollNo.Text;
            nr.BID = ddlbuilding.SelectedValue;
            nr.Room = txtroomno.Text;
            nr.Email = txtEmailID.Text;
            nr.MobileNo = txtMobileNo.Text;
           
            nr.UserName = txtUserName.Text;
            nr.Password = txtPassword.Text;
            string str = cm.CreateNewUser(nr);

            if (str.Contains("Succ"))
                mc.ShowPopUpTimer(this, "User Successfully Created.Check Email ID for Login Details","Login.aspx");
            else
                mc.ShowPopUpMsgM(this,str.Trim());
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,"Error : "+er.Message.ToString());
        }
    }

   
}