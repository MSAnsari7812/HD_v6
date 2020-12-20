using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Net;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Management;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Configuration;
using CMSObject;

namespace CMSDAL
{
   
    public class MsgClass
    {




        public void ShowPopUpMsgE(Page mypage, string Msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("swal({   title: 'Error!',   text: '" + Msg + "',   type: 'error',   confirmButtonText: 'Close' });");

            ScriptManager.RegisterStartupScript(mypage, typeof(Page), "showalert", sb.ToString(), true);
        }
        public void ShowPopUpMsgS(Page mypage, string Msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("swal({   title: 'Success!',   text: '" + Msg + "',   type: 'success',   confirmButtonText: 'Close' }); ");
            ScriptManager.RegisterStartupScript(mypage, typeof(Page), "showalert", sb.ToString(), true);
        }
        public void ShowPopUpTimer(Page mypage, string Msg, string url)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("swal({title: '" + Msg + "',text: 'I will close in 3 seconds.',timer: 3000,showConfirmButton: false});" +
                "setTimeout(function() { window.open('" + url + "','_self');}, 3000); ");
            ScriptManager.RegisterStartupScript(mypage, typeof(Page), "showalert", sb.ToString(), true);
        }
        public void ShowPopUpMsgM(Page mypage, string Msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("sweetAlert('Oops...','" + Msg + "', 'error');");
            ScriptManager.RegisterStartupScript(mypage, typeof(Page), "showalert", sb.ToString(), true);
        }
    }
    public class CMSClass
    {
        public string GenrateComplainID(string id)
        {
            string rv = "HD-";
            if (id.Length == 1) id = "000" + id;
            if (id.Length == 2) id = "00" + id;
            if (id.Length == 3) id = "0" + id;

            rv = rv + id;
            return rv;
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable ptab;

            SqlConnection sc = openconn();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, sc);
                DataSet ds = new DataSet();

                da.Fill(ds, "ptab");
                ptab = ds.Tables["ptab"];
                return ptab;
            }
            catch
            {
                ptab = null;
                return ptab;
            }

        }

        public DateTime getdateInFormat(string dtstr)
        {
            string[] d = dtstr.Split('/');
            return Convert.ToDateTime(d[1] + "/" + d[0] + "/" + d[2]);
        }

        public static string cs = ConfigurationManager.ConnectionStrings["cls"].ConnectionString;

       

        public DateTime GetDateTime()
        {
            DateTime dt = DateTime.UtcNow;
            dt = (dt.AddHours(5)).AddMinutes(30);
            return dt;
        }

        public double RoundDown(double number, int decimalPlaces)
        {
            return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
        }




        public string SendEmail(string toAddress, string subject, string body)
        {

            DataTable dt = new DataTable();
            string sql = "select * from NotificationSettingTab where sid=1";
            CMSClass cc = new CMSClass();
            string rvalue = "Sending Failed";

            dt = cc.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                if (!dt.Rows[0]["emailstatus"].ToString().Equals("1"))
                {

                    rvalue = "Email Notification Not Activated.";     

                }
                else
                {

                    string senderID = dt.Rows[0]["emailsenderid"].ToString(); ;// use sender's email id here..
                     string senderPassword = dt.Rows[0]["emailsenderpassword"].ToString(); // sender password here...
                    try
                    {
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        client.Timeout = 20000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                        

                        MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                        message.IsBodyHtml = true;
                        client.Send(message);
                        rvalue= "Mail Send";
                    }
                    catch (Exception ex)
                    {

                       rvalue= ex.Message.ToString();
                    }

                    
                }
            }
            return rvalue;
        }




        public SqlConnection openconn()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                return conn;
            }
            catch
            {

                return null;
            }
            //
            // TODO: Add constructor logic here
            //
        }





        public string findfun(string sql)
        {
            try
            {
                string x = "0";
                SqlConnection conn = openconn();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (conn.State.ToString() == "Open")
                    conn.Close();
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    x = dr[0].ToString();
                }
                else
                {
                    x = "0";
                }

                conn.Close();


                return x;
            }
            catch { return "0"; }
        }
        public bool IsItNumberInt(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            // Regex isnumber = new Regex(@"((\d+)((\.\d{1,2})?))$");
            return !isnumber.IsMatch(inputvalue);
        }

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { return false; } // just dismiss errors but return false

        }


        public int Inst_update(string sql)
        {
            int x = 0;
            try
            {
                SqlConnection conn = openconn();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (conn.State.ToString() == "Open")
                    conn.Close();

                conn.Open();
                x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
            }
            catch
            {
                return 0;
            }

        }



        public void Export(string fileName, GridView gv)
        {
            string style = @"<style> .text { mso-number-format:\@; } </style> ";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // Create a form to contain the grid
                    Table table = new Table();

                    // add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }

                    // add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    // add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    // render the table into the htmlwriter
                    table.RenderControl(htw);
                    HttpContext.Current.Response.Write(style);
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }
        public void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is Label)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
                }
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
        }


        public SqlDataReader getdataReader(string sql)
        {
            string x = "0";
            SqlConnection conn = openconn();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (conn.State.ToString() == "Open")
                conn.Close();
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                return dr;
            }
            else
            {

                return dr;
            }
            conn.Close();


        }

    }
  
}
