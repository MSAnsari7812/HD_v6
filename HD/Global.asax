<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        try
        {
            //  Code that runs on application shutdown
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddHours(-1));
            Response.Cache.SetNoStore();
        }
        catch (Exception er)
        {

            Application["lasterror"] = er;
            // Response.Redirect("../errorpage.aspx");
        }
    }

    void Application_Error(object sender, EventArgs e)
    {
        try
        {
            Application["lasterror"] = Server.GetLastError();
            Response.Redirect("errorpage.aspx");
        }
        catch (Exception er)
        {
            Application["lasterror"] = er;
            Response.Redirect("errorpage.aspx");
        }
    }

    void Session_Start(object sender, EventArgs e)
    {
        //CMSObject.LoginClass lc = new CMSObject.LoginClass();

        //lc.name = "Admin";
        //lc.role = "Help Desk";
        //lc.ErrorMassage = "Testing";

        //Session["info"] = lc;

    }

    void Session_End(object sender, EventArgs e)
    {
        try
        {
            Session["info"] = null;
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        catch {


        }

    }

</script>
