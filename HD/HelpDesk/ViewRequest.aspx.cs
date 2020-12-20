using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSObject;
using CMSDAL;
using System.Data;

public partial class UserViewRequest : System.Web.UI.Page
{
    LoginClass lc = new LoginClass();
    WS_CMS wc = new WS_CMS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetRequestList("ALL","ALL","ALL");  
        }
    }
    MsgClass mc = new MsgClass();
    protected void GetRequestList(string id,string dt1,string dt2)
    {
        try
        {
            ListView1.DataSource = wc.GetUserRequest(id, dt1, dt2);
           
            ListView1.DataBind();
           
           
             
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,er.Message.ToString());
        }

    }

 
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        GetRequestList("ALL",txtfromdatedate.Text, txttodate.Text);
    }

    protected void ListView1_DataBound(object sender, EventArgs e)
    {
        foreach (ListViewItem il in ListView1.Items)
        {
            HiddenField hf = (HiddenField)il.FindControl("hfassignstatus");
            HiddenField hfenggname = (HiddenField)il.FindControl("hfenggname");
            HyperLink hl = (HyperLink)il.FindControl("hlassignengg");
            Label ae = (Label)il.FindControl("lblassignengg");

            if (hf.Value.Equals("Assign"))
            {
                //hl.Enabled = false;
                hl.Text = "Change";
                //hl.ForeColor = System.Drawing.Color.DarkGreen;
               ae.Text= "<strong>Engineer Name : <span style='color:#ff1a1a'> <b>" + hfenggname.Value + "</b></span></strong>";
                ae.ForeColor= System.Drawing.Color.DarkGreen;


            }
            else
            {
                ae.Text = "Not Assign";

                //hl.Enabled = true;
                hl.Text = "Assign";
                //hl.CssClass = "btn btn-sm btn-danger";
            }

            foreach (ListViewItem lvi in ListView1.Items)
            {

                Label l = (Label)lvi.FindControl("Label7");
                if (l.Text.Equals("Open"))
                {
                    l.CssClass = "w10Red";
                }
                else if (l.Text.Equals("Pending"))
                {
                    l.CssClass = "w10Yellow";
                }
                else
                { l.CssClass = "w10Green"; }


            }

        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CMSClass cd = new CMSClass();
            GridView gv = new GridView();

            DataTable dt = new DataTable();
           dt = wc.GenerateRequestReport("ALL", txtfromdatedate.Text, txttodate.Text);
           
            gv.DataSource = dt;
            gv.DataBind();
            string fname = "cmsreport_" + DateTime.Now.ToShortDateString().Replace("/", "")+".xls";
            cd.Export(fname, gv);
        }
        catch(Exception er) {
            mc.ShowPopUpMsgE(this,er.Message.ToString());
        }
       
    }
}