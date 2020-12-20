using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSDAL;
using CMSObject;

public partial class Engineer_ViewRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadRequest();
            MV1.SetActiveView(v1);
        }
    }
    WS_CMS ws = new WS_CMS();
   
    LoginClass luser = new LoginClass();

    protected void LoadRequest()
    {
        luser = (LoginClass)Session["info"];

        GridView1.DataSource = ws.GetEngineerRequest(luser.lid.ToString(), "ALL");
        GridView1.DataBind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName.ToString();
        string[] str = e.CommandArgument.ToString().Split(':');

        if (cmd.Equals("ED"))
        {
            lblRequestID.Text = str[1];
            hfcid.Value = str[0];
            txtComments.Text = String.Empty;
            MV1.SetActiveView(v2);
        }
    }
    MsgClass mc = new MsgClass();
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string str = ws.UpdateRequestStatus(hfcid.Value, DropDownList1.SelectedValue, txtComments.Text);

            if (str.Contains("Success"))
            {
                mc.ShowPopUpMsgS(this, "Status Successfully Updated.");
                lblRequestID.Text = "0";
                txtComments.Text = String.Empty;
                DropDownList1.SelectedIndex = 0;
                hfcid.Value = "0";
                LoadRequest();
                MV1.SetActiveView(v1);
            }
            else
            {
                mc.ShowPopUpMsgM(this,str);
            }
        }
        catch (Exception er)
        {
            mc.ShowPopUpMsgE(this,"Error : "+er.Message.ToString().Trim());
        }
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {

                int statusColIndex = (gr.Cells.Count - 1) - 1;
               
                if (gr.Cells[statusColIndex].Text.Equals("Closed"))
                {
                    LinkButton lb = (LinkButton)gr.FindControl("LinkButton2");
                    lb.Visible = false;
                    gr.Cells[statusColIndex].ForeColor = System.Drawing.Color.ForestGreen;
                    gr.Cells[statusColIndex].BackColor = System.Drawing.Color.LawnGreen;
                }
                else if (gr.Cells[statusColIndex].Text.Equals("Pending"))
                {
                    gr.Cells[statusColIndex].ForeColor = System.Drawing.Color.Yellow;
                    gr.Cells[statusColIndex].BackColor = System.Drawing.Color.Gray;
                }
                else
                {
                    gr.Cells[statusColIndex].ForeColor = System.Drawing.Color.IndianRed;
                    gr.Cells[statusColIndex].BackColor = System.Drawing.Color.OrangeRed;
                }
            }
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this, er.Message.ToString().Trim());
        }
    }

    protected void lbView_Click(object sender, EventArgs e)
    {
        MV1.SetActiveView(v1);
    }
}