using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSObject;
using Newtonsoft.Json;
using CMSDAL;

public partial class Admin_UserManagment : System.Web.UI.Page
{
    WS_CMS ws = new WS_CMS();
    CMSClass cc = new CMSClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           MultiView1.SetActiveView(View1);
            LoadUsers();
            LoadRole();
            LoadBuilding();
            LoadDesignation();
        }
    }
    protected void LoadRole()
    {
        ddlRole.DataSource = ws.GetUserRole();
        ddlRole.DataBind();

    }
    protected void LoadUsers()
    {
       
        GridView1.DataSource= ws.GetHDUsersList(0, "ALL");
        GridView1.DataBind();

    }
    MsgClass mc = new MsgClass();
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().Equals("DEL"))
        {
            // string sql = "delete from userlogintab where role<>'Super User' and lid=" + e.CommandArgument.ToString();
            //int i=cc.Inst_update(sql);
            string msg = ws.DeleteUser(int.Parse(e.CommandArgument.ToString()));


            if (msg.Contains("Succe"))
            {
                mc.ShowPopUpMsgS(this,"Delete Successfull");
                LoadUsers();
            }
            else if (msg.Contains("cant"))
            {
                mc.ShowPopUpMsgS(this, msg);
            }
            else
            {
                mc.ShowPopUpMsgM(this,"Failed To Delete.");
            }


        }
        else if(e.CommandName.ToString().Equals("ED"))
        {
            Display(e.CommandArgument.ToString());
            if (hflid.Value.Equals("0"))
                MultiView1.SetActiveView(View1);
            else
                MultiView1.SetActiveView(View2);
        }
    }

    protected void Display(string lid)
    {
       
        var obj =ws.GetHDUsers(int.Parse(lid),"ALL");

        if (obj.role.Equals("Super User"))
        {
            mc.ShowPopUpMsgM(this,"Super User cannot edit.");
        }
        else
        {
            if (!obj.lid.Equals("0"))
            {
                hflid.Value = obj.lid.ToString();
                txtName.Text = obj.name;
                txtUserName.Text = obj.username;
                txtPassword.Text = obj.password;
                txtEmailID.Text = obj.commemail;
                txtMobileNo.Text = obj.commmobileno;

                txtroomno.Text = obj.roomid;
                try
                {
                    ddlbuilding.SelectedValue = obj.bid;
                }
                catch { }
                try
                {
                    ddlDesignation.SelectedValue = obj.designation;
                }
                catch { }

                ddlRole.SelectedValue = obj.role;
                ddlStatus.SelectedValue = obj.status;
            }
        }

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        LoadUsers();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
       Clear();
    }
    protected void LoadBuilding()
    {
        WS_CMS cm = new WS_CMS();

        ddlbuilding.DataSource = cm.GetBuilding();
        ddlbuilding.DataBind();
    }

    protected void LoadDesignation()
    {
        WS_CMS cm = new WS_CMS();

        ddlDesignation.DataSource = cm.GetDesignation();
        ddlDesignation.DataBind();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        LoginClass l = new LoginClass();
        l.lid = int.Parse(hflid.Value);
       
        l.name = txtName.Text;
        l.username = txtUserName.Text;
        l.password = txtPassword.Text;
        l.email = txtEmailID.Text;
        l.mobileno = txtMobileNo.Text;
        l.commemail= txtEmailID.Text;
        l.commmobileno= txtMobileNo.Text;
        l.role = ddlRole.SelectedValue;
        l.status = ddlStatus.SelectedValue;
        l.bid = ddlbuilding.SelectedValue;
        l.roomid = txtroomno.Text;
        l.designation = ddlDesignation.SelectedValue;




        string msg = ws.UpdateHDUser(l);
        if (msg.Contains("Succ"))
        { mc.ShowPopUpMsgS(this, "Update Successfull");
            LoadUsers();Clear();
            MultiView1.SetActiveView(View1);

        }
        else
            mc.ShowPopUpMsgM(this, msg);

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       foreach(GridViewRow gr in GridView1.Rows)
        {
            ImageButton imdel = (ImageButton)gr.FindControl("ImageButton1");
            ImageButton imedit = (ImageButton)gr.FindControl("ImageButton2");
            string uname = gr.Cells[2].Text;
            string role = gr.Cells[1].Text;

           
            LoginClass l = new LoginClass();
            l = (LoginClass)Session["info"];
            if (l.username.Equals(uname))
            {
                imdel.Visible = false;
            }

        }
    }
    protected void Clear()
    {
      txtroomno.Text=txtEmailID.Text = txtMobileNo.Text = txtName.Text = txtPassword.Text = txtUserName.Text = String.Empty;
     ddlbuilding.SelectedIndex=ddlDesignation.SelectedIndex=ddlRole.SelectedIndex = ddlStatus.SelectedIndex = 0;
        LoadUsers();
        hflid.Value = "0";

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Clear(); 
    }
}