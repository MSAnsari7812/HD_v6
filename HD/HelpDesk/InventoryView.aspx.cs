using CMSObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HelpDesk_InventoryMaster : System.Web.UI.Page
{
    WS_CMS ws = new WS_CMS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = ws.GetInventory();
            GridView1.DataBind();
              

        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<InventoryClass> ic = new List<InventoryClass>();
        string invid = e.CommandArgument.ToString();
        if (e.CommandName.Equals("ED"))
        {
            Response.Redirect(String.Format("InventoryNewEdit.aspx?invid={0}", invid),false);
           
        }
       
       

    }






    protected void InvExport_Click(object sender, ImageClickEventArgs e)
    {
        CMSDAL.CMSClass cm = new CMSDAL.CMSClass();
        cm.Export("InventorySheet.xls",GridView1);
    }
}