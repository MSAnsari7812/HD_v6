using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class errorpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Exception er = (Exception)Application["lasterror"];
            errormsg.InnerHtml = "Description : " + er.Message + "<br/>Error : " + er.InnerException.Message.ToString();
        }
        catch {
           
            errormsg.InnerHtml = Application["lasterror"].ToString();
        }

    }
}