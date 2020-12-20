using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CMSDAL;
using System.Data;

/// <summary>
/// Summary description for WS_Notification
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WS_Notification : System.Web.Services.WebService
{
   



    [WebMethod]
    public static string NotificationByEmail(string EmailID, string SubjectTitle, string MsgBody)
    {
        string msg = "Sending Failed";


        CMSClass tp = new CMSClass();
        msg = tp.SendEmail(EmailID, SubjectTitle, MsgBody);

        return msg;
    }
   static string authKey = "";
    [WebMethod]
    public static string NotificationBySMS(string MobileNo, string Msg)
    {


        DataTable dt = new DataTable();
        string sql = "select * from NotificationSettingTab where sid=1";
        CMSClass cc = new CMSClass();
        string rvalue = "Sending Failed";

        dt = cc.GetDataTable(sql);

        if (dt.Rows.Count > 0)
        {
            if (!dt.Rows[0]["smsstatus"].ToString().Equals("1"))
            {

                rvalue = "SMS Notification Not Activated.";

            }
            else
            {

                authKey = dt.Rows[0]["smskey"].ToString();
                //Multiple mobiles numbers separated by comma
                string mobileNumber = MobileNo;
                //Sender ID,While using route4 sender id should be 6 characters long.
                string senderId = dt.Rows[0]["smssenderid"].ToString(); ;
                //Your message to send, Add URL encoding here.
                string message = HttpUtility.UrlEncode(Msg);

                //Prepare you post parameters
                System.Text.StringBuilder sbPostData = new System.Text.StringBuilder();
                sbPostData.AppendFormat("authkey={0}", authKey);
                sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                sbPostData.AppendFormat("&message={0}", message);
                sbPostData.AppendFormat("&sender={0}", senderId);
                sbPostData.AppendFormat("&route={0}", "4");

                try
                {
                    //Call Send SMS API
                    string sendSMSUri = "http://sms.arihantwebconsultancy.com/api/sendhttp.php";
                    //Create HTTPWebrequest
                    System.Net.HttpWebRequest httpWReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(sendSMSUri);
                    //Prepare and Add URL Encoded data
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    byte[] data = encoding.GetBytes(sbPostData.ToString());
                    //Specify post method
                    httpWReq.Method = "POST";
                    httpWReq.ContentType = "application/x-www-form-urlencoded";
                    httpWReq.ContentLength = data.Length;
                    
                    using (System.IO.Stream stream = httpWReq.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    //Get the response
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)httpWReq.GetResponse();
                    System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
                    string responseString = reader.ReadToEnd();

                    //Close the response
                    reader.Close();
                    response.Close();


                    rvalue="Successfully Send";

                }
                catch (SystemException ex)
                {

                    rvalue="Message Not Send";

                }
            }
        }


        return rvalue;
    }

}
