using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CMSDAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CMSObject;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// Summary description for WS_CMS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_CMS : System.Web.Services.WebService
{

    CMSClass cm = new CMSClass();
    WS_Notification n = new WS_Notification();
    HttpResponse resp;
    [WebMethod]
    public LoginClass CheckLogin(string username, string password)
    {
        LoginClass lc = new LoginClass();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Checklogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);



            cmd.Parameters.Add("@lid", SqlDbType.Char, 500);
            cmd.Parameters["@lid"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@r", SqlDbType.Char, 500);
            cmd.Parameters["@r"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            ReturnMessageClass rm = new ReturnMessageClass();
            rm.id = (string)cmd.Parameters["@lid"].Value.ToString().Trim();// 1 or 0
            rm.Message = (string)cmd.Parameters["@r"].Value.ToString().Trim();// Success or Failed
            con.Close();

            if (rm.Message.Trim().Contains("expired"))
            {
                lc.status = "expired";
                lc.ErrorMassage = rm.Message;
            }
            else if (rm.Message.Trim().Contains("failed"))
            {
                lc.status = "failed";
                lc.ErrorMassage =rm.Message;
            }
             else // if (rm.Message.Trim().Contains("success"))
            {
                lc = GetHDUsers(int.Parse(rm.id), "ALL");
                lc.status = "Success";
            }
            return lc;
        }
        catch (Exception er)
        {
            lc.status = "Error";
            lc.ErrorMassage =er.Message.ToString();
            return lc;
        }

    }

  

    public string RandomPassword()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(4, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, false));
        return builder.ToString();
    }
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }
    [WebMethod]
    public LoginClass ChangePassword(string EmailID, string oldPassword= "Forgot",string newPassword="0")
    {
        LoginClass lc = new LoginClass();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_ChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@emailid", EmailID);
            cmd.Parameters.AddWithValue("@oldpassword", oldPassword);
            cmd.Parameters.AddWithValue("@newpassword", newPassword);



            cmd.Parameters.Add("@lid", SqlDbType.Char, 500);
            cmd.Parameters["@lid"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            ReturnMessageClass rm = new ReturnMessageClass();
            rm.id = (string)cmd.Parameters["@lid"].Value.ToString().Trim();// 1 or 0
            rm.Message = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed
            con.Close();

            if (!rm.Message.Trim().Contains("Failed"))
            {
                lc = GetHDUsers(int.Parse(rm.id), "ALL");

            }
            else
            {
                lc.ErrorMassage = rm.Message;
            }
            return lc;
        }
        catch (Exception er)
        {
            lc.ErrorMassage = er.Message.ToString();
            return lc;
        }

    }

    [WebMethod(MessageName = "WithUserID")]
    public LoginClass ChangePassword(int UserID, string oldPassword = "Forgot", string newPassword = "0")
    {
        LoginClass lc = new LoginClass();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_ChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@oldpassword", oldPassword);
            cmd.Parameters.AddWithValue("@newpassword", newPassword);



            cmd.Parameters.Add("@lid", SqlDbType.Char, 500);
            cmd.Parameters["@lid"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            ReturnMessageClass rm = new ReturnMessageClass();
            rm.id = (string)cmd.Parameters["@lid"].Value.ToString().Trim();// 1 or 0
            rm.Message = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed
            con.Close();

            if (!rm.Message.Trim().Contains("Failed"))
            {
                lc = GetHDUsers(int.Parse(rm.id), "ALL");

            }
            else
            {
                lc.ErrorMassage = rm.Message;
            }
            return lc;
        }
        catch (Exception er)
        {
            lc.ErrorMassage = er.Message.ToString();
            return lc;
        }

    }


    public string ResetPassword(string emailid)
    {
        string retmsg = "";
        string password = RandomPassword();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_ResetPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@emailid", emailid);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
           
           string msg = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed
            con.Close();

       

        if (msg.Contains("Success"))
        {
            WS_Notification wsn = new WS_Notification();
            string mbody = "Your Temporary Login Password <strong>: " + password+"</strong> "+
                    " <br/> Please Change your password after login....";

           string x=WS_Notification.NotificationByEmail(emailid, "Help Desk Password Reset Notification", mbody);
            if (x.Contains("Mail Send"))
                retmsg = "password successfully send to your registered email id.";
            else
                    retmsg = "password sending failed please try again.";
            }
        else
        {
            retmsg = "Your given email id not registered with us.";
        }
        }
        catch(Exception er) {
            Application["lasterror"] = er.Message.ToString();
            retmsg= "Error : "+er.Message.ToString();
        }
        return retmsg;
        }


    [WebMethod]
    public List<LoginClass> GetHDUsersList(int lid=0,string role="ALL")
    {
        string jstr = "";
        List<LoginClass> Loginusers = new List<LoginClass>();
      
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
          
            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetUserList", conn);

                if (lid>0)
                    sqlComm.Parameters.AddWithValue("@lid", lid);
                if (!role.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@role", role);
                
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

          foreach(DataRow dr in dt.Rows)
            {
                LoginClass lc = new LoginClass();
              

                lc.lid = int.Parse(dr["lid"].ToString());
                lc.name = dr["name"].ToString();
                lc.username = dr["username"].ToString();
                lc.password = dr["password"].ToString();
                lc.email = dr["email"].ToString();
                lc.mobileno = dr["mobileno"].ToString();
                lc.commemail = dr["commemail"].ToString();
                lc.commmobileno = dr["commmobileno"].ToString();

                lc.designation= dr["designation"].ToString();
                lc.building = dr["buildingname"].ToString();
                lc.room = dr["room"].ToString();
                lc.bid = dr["bid"].ToString();
                lc.roomid = dr["roomid"].ToString();
                lc.role = dr["rolename"].ToString();

                Loginusers.Add(lc);
            }
            con.Close();

          
        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
              resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return Loginusers;
    }


    [WebMethod]
    public List<LoginClass> GetHDEnggList(int lid = 0)
    {
        string jstr = "";
        List<LoginClass> Loginusers = new List<LoginClass>();

        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {

                SqlCommand sqlComm = new SqlCommand("Proc_GetEnggList", conn);

                if (lid > 0)
                    sqlComm.Parameters.AddWithValue("@lid", lid);
              

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                LoginClass lc = new LoginClass();


                lc.lid = int.Parse(dr["lid"].ToString());
                lc.name = dr["name"].ToString();
              
                lc.email = dr["email"].ToString();
                lc.mobileno = dr["mobileno"].ToString();
                lc.commemail = dr["commemail"].ToString();
                lc.commmobileno = dr["commmobileno"].ToString();
                lc.role = dr["role"].ToString();

                Loginusers.Add(lc);
            }
          

        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return Loginusers;
    }




    [WebMethod]
    public List<UserRoleClass> GetUserRole(string rolename="ALL")
    {
        string jstr = "";
        List<UserRoleClass> roleList = new List<UserRoleClass>();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();

            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                string sql = "select * from userroletab where 1=1 ";

                if (!rolename.Equals("ALL"))
                    sql = sql + " and rolename='" + rolename + "' ";   
                    
                    sql=sql+" order by rolepriority asc";
                SqlCommand sqlComm = new SqlCommand(sql, conn);


                sqlComm.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
               UserRoleClass rc = new UserRoleClass();


                rc.RoleName = dr["rolename"].ToString();
                rc.Priority = dr["rolepriority"].ToString();
             

                roleList.Add(rc);
            }
            con.Close();


        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return roleList;
    }
 
    [WebMethod]
    public List<DesignationClass> GetDesignation()
    {
        string jstr = "";
        List<DesignationClass> DesignationList = new List<DesignationClass>();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();

            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                string sql = "select * from designationtab order by designation asc";
                SqlCommand sqlComm = new SqlCommand(sql, conn);


                sqlComm.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                DesignationClass rc = new DesignationClass();


                rc.Designation = dr["designation"].ToString();



                DesignationList.Add(rc);
            }
            con.Close();


        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return DesignationList;
    }



    [WebMethod]
    public LoginClass GetHDUsers(int lid = 0, string role = "ALL")
    {
        string jstr = "";

        LoginClass lc = new LoginClass();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();

            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetUserList", conn);

                if (lid > 0)
                    sqlComm.Parameters.AddWithValue("@lid", lid);
                if (!role.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@dt1", role);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }
         
            foreach (DataRow dr in dt.Rows)
            {
              
               

                lc.lid = int.Parse(dr["lid"].ToString());
                lc.name = dr["name"].ToString();
                lc.designation = dr["designation"].ToString();
                lc.username = dr["username"].ToString();
                lc.password = dr["password"].ToString();
                lc.status = dr["status"].ToString();
                lc.email = dr["email"].ToString();
                lc.mobileno = dr["mobileno"].ToString();
                lc.commemail = dr["commemail"].ToString();
                lc.commmobileno = dr["commmobileno"].ToString();
                lc.role = dr["rolename"].ToString();
                lc.ErrorMassage = "Success";
               
            }
            con.Close();
           

        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("../errorpage.aspx");
        }
        return lc;
    }


    [WebMethod]
    public LoginClass GetLoginUserByID(string id)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            LoginClass lc = new LoginClass();
            string sql = "select lid,name,username,'****'+right(password,4) password,email,mobileno,commemail,commmobileno,role from userlogintab where lid=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lc.lid = int.Parse(dr["lid"].ToString());
             
                lc.name = dr["name"].ToString();
                lc.password = dr["password"].ToString();
                lc.username = dr["username"].ToString();
                lc.email = dr["email"].ToString();
                lc.mobileno = dr["mobileno"].ToString();
                lc.commemail = dr["commemail"].ToString();
                lc.commmobileno = dr["commmobileno"].ToString();
                lc.role = dr["role"].ToString();
            }
            con.Close();


            return lc;
        }
        catch (Exception er)
        {
            return null;
        }

    }

    [WebMethod]
    public LoginClass GetUserInfoByID(string lid)
    {
        try
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
           LoginClass ui = new LoginClass();
            string sql = "select * from vwuser where lid=@lid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@lid", lid);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

           foreach(DataRow dr in dt.Rows)
            {
               
                ui.lid = int.Parse(dr["lid"].ToString());
                ui.name = dr["name"].ToString();
                ui.batch = dr["batch"].ToString();
                ui.designation = dr["designation"].ToString();

                ui.rollno = dr["rollno"].ToString();
                ui.email = dr["email"].ToString();
                ui.mobileno = dr["mobileno"].ToString();
                ui.commemail = dr["commemail"].ToString();
                ui.commmobileno = dr["commmobileno"].ToString();

                ui.bid = dr["bid"].ToString();

                ui.mobileno = dr["roomid"].ToString();
                ui.building = dr["buildingname"].ToString();
                ui.room = dr["room"].ToString();

            }
            con.Close();


            return ui;
        }
        catch (Exception er)
        {
            return null;
        }

    }

    [WebMethod]
    public List<UserViewRequest> GetRequestReports(string Userid, string Enggid, string dt1, string dt2)
    {
        List<UserViewRequest> lv = new List<UserViewRequest>();
        UserViewRequest uvr;
        try
        {


            DataTable dt = new DataTable("ViewRequestTab");
            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                SqlCommand sqlComm = new SqlCommand("Proc_getadvancereport", conn);

                if (!Userid.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@lid", Userid);
                if (!Enggid.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@enggid", Enggid);
                if (!dt1.Equals("ALL") && dt1.Length>0)
                    sqlComm.Parameters.AddWithValue("@dt1", dt1);
                if (!dt2.Equals("ALL") && dt2.Length > 0)
                    sqlComm.Parameters.AddWithValue("@dt2", dt2);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }



            foreach (DataRow dr in dt.Rows)
            {
                uvr = new UserViewRequest();
                uvr.cid = int.Parse(dr["cid"].ToString());
                uvr.ReqID = dr["reqid"].ToString();
                uvr.RequestDate = dr["requestDateString"].ToString();
                uvr.RequestCategory = dr["requestCategory"].ToString();
                uvr.RequestSubject = dr["requestSubject"].ToString();
                uvr.RequestDescription = dr["RequestDescription"].ToString();
                uvr.UserRemarks = dr["userRemarks"].ToString();
                uvr.RequestRemarks = uvr.CMSRemarks = dr["cmsremark"].ToString();
                uvr.EnggName = dr["enggname"].ToString();
                uvr.EnggEmail = dr["enggcommemail"].ToString();
                uvr.EnggMobile = dr["enggcommmobile"].ToString();
                uvr.AssignStatus = dr["assignstatus"].ToString();
                uvr.Status = dr["requeststatus"].ToString();
                uvr.RequestDateTime = dr["requestdatetime"].ToString();
                uvr.RequestDuration = dr["requestduration"].ToString();
                uvr.UserProduct = dr["userproduct"].ToString();
                uvr.BuildingName = dr["buildingname"].ToString();
                uvr.Room = dr["room"].ToString();
                uvr.Name = dr["name"].ToString();
                uvr.Designation = dr["designation"].ToString();
                uvr.CommEmail = dr["commemail"].ToString();
                uvr.CommMobile = dr["commmobileno"].ToString();
                uvr.EnggAssignDate = dr["enggassigndate"].ToString();
                uvr.RequestStatusLastDate = dr["requeststatuslastdate"].ToString();
                uvr.Error = "No Error";
                lv.Add(uvr);
            }



            return lv;
        }
        catch (Exception er)
        {
            //uvr = new UserViewRequest();
            //uvr.Error="Error : "+er.Message.ToString();
            //lv.Add(uvr);
            return null;
        }

    }
    [WebMethod]
    public ReturnMessageClass UpdateRequestCategory(string cid, string catid, string subid)
    {
        ReturnMessageClass rm = new ReturnMessageClass();
        try
        {
            string cond = "";
            string sql = "";

            if (!catid.Equals("0"))
                cond += " catid = " + catid;

            if (!subid.Equals("0"))
                cond += ", subid = " + subid;

            sql += "update ComplainTab set " + cond + " where cid=" + cid;

            int i = cm.Inst_update(sql);

            if (i > 0)
                rm.Message = "success";
            else
                rm.Message = "failed";
        }
        catch(Exception er) {
            rm.Message = er.Message.ToString().Trim();
        }
        return rm;
    }

    [WebMethod]
    public List<UserViewRequest> GetUserRequest(string cid="ALL",string Userid="ALL",string dt1="ALL",string dt2="ALL",string status="ALL")
    {
        List<UserViewRequest> lv = new List<UserViewRequest>();
        UserViewRequest uvr;
        try
        {
            
            
            DataTable dt = new DataTable("ViewRequestTab");
            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                SqlCommand sqlComm = new SqlCommand("Proc_getrequest", conn);
                if (!cid.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@cid", cid);
                if (!Userid.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@lid", Userid);
                if(!dt1.Equals("ALL"))
                sqlComm.Parameters.AddWithValue("@dt1", dt1);
                if (!dt2.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@dt2",dt2);

                if (!status.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@status", status);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

           

           foreach(DataRow dr in dt.Rows)
            {
                uvr = new UserViewRequest();
                uvr.cid =int.Parse(dr["cid"].ToString());
                uvr.ReqID =dr["reqid"].ToString();
                uvr.RequestDate = dr["requestDateString"].ToString();
                uvr.RequestCategory = dr["requestCategory"].ToString();
                uvr.RequestSubject = dr["requestSubject"].ToString();
                uvr.RequestDescription = dr["RequestDescription"].ToString();
                uvr.UserRemarks = dr["userRemarks"].ToString();
              uvr.RequestRemarks= uvr.CMSRemarks = dr["cmsremark"].ToString();
                uvr.EnggName = dr["enggname"].ToString();
                uvr.EnggEmail = dr["enggcommemail"].ToString();
                uvr.EnggMobile = dr["enggcommmobile"].ToString();
                uvr.AssignStatus = dr["assignstatus"].ToString();
                uvr.Status = dr["requeststatus"].ToString();
                uvr.RequestDateTime = dr["requestdatetime"].ToString();
                uvr.RequestDuration = dr["requestduration"].ToString();
                uvr.UserProduct = dr["userproduct"].ToString();
                uvr.BuildingName = dr["buildingname"].ToString();
                uvr.Room = dr["room"].ToString();
                uvr.Name = dr["name"].ToString();
                uvr.Designation = dr["designation"].ToString();
                uvr.CommEmail = dr["commemail"].ToString();
                uvr.CommMobile = dr["commmobileno"].ToString();
                uvr.EnggAssignDate = dr["enggassigndate"].ToString();
                uvr.RequestStatusLastDate = dr["requeststatuslastdate"].ToString();
                uvr.Error = "No Error";
                lv.Add(uvr);
            }
          


            return lv;
        }
        catch (Exception er)
        {
            //uvr = new UserViewRequest();
            //uvr.Error="Error : "+er.Message.ToString();
            //lv.Add(uvr);
           return null;
        }

    }

    [WebMethod]
    public DataTable GenerateRequestReport(string Userid, string dt1, string dt2)
    {
       
        try
        {


            DataTable dt = new DataTable("ViewRequestTab");
            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                SqlCommand sqlComm = new SqlCommand("Proc_getrequest", conn);

                if (!Userid.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@id", Userid);
                if (!dt1.Equals("ALL") && dt1.Length>0)
                    sqlComm.Parameters.AddWithValue("@dt1", dt1);
                if (!dt2.Equals("ALL") && dt1.Length > 0)
                    sqlComm.Parameters.AddWithValue("@dt2", dt2);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }
            string[] colname = { "ReqID", "Name","Designation","Requestdatestring", "requestsubject", "Request", "userremark", "cmsremark", "enggname" };

            dt = dt.DefaultView.ToTable(true, colname);

            dt.Columns[0].ColumnName = "Request ID";
            dt.Columns[1].ColumnName = "Person Name";
            //dt.Columns[2].ColumnName = "EMail ID";
            //dt.Columns[3].ColumnName = "Mobile No";
            dt.Columns[2].ColumnName = "Designation";
            dt.Columns[3].ColumnName = "Request Date";
            dt.Columns[4].ColumnName = "Request Subject";
            dt.Columns[5].ColumnName = "Request Description";
            dt.Columns[6].ColumnName = "User Remark";
            dt.Columns[7].ColumnName = "Help Desk Remark";
            dt.Columns[8].ColumnName = "Engineer Name";

            return dt;
        }
        catch (Exception er)
        {
           return null;
        }

    }


    [WebMethod]
    public List<EngineerViewRequest> GetEngineerRequest(string EngineerID,string RequestStatus)
    {
        List<EngineerViewRequest> lv = new List<EngineerViewRequest>();
        EngineerViewRequest uvr;
        try
        {


            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CMSClass.cs))
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetRequestByEngineerID", conn);

                if(!EngineerID.Equals("0"))
                    sqlComm.Parameters.AddWithValue("@EnggID", EngineerID);

                if (!RequestStatus.Equals("ALL"))
                    sqlComm.Parameters.AddWithValue("@RequestStatus",RequestStatus);
              

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }



            foreach (DataRow dr in dt.Rows)
            {
                uvr = new EngineerViewRequest();
                uvr.cid = int.Parse(dr["cid"].ToString());
                uvr.ReqID = dr["reqid"].ToString();
                uvr.RequestDate = dr["requestDateString"].ToString();
                uvr.RequestCategory = dr["requestCategory"].ToString();
                uvr.RequestSubject = dr["requestSubject"].ToString();
                uvr.RequestDescription = dr["RequestDescription"].ToString();
                uvr.UserRemarks = dr["userRemarks"].ToString();
                uvr.CMSRemarks = dr["cmsremark"].ToString();
              
                uvr.Status = dr["requeststatus"].ToString();
                uvr.Error = "No Error";
                lv.Add(uvr);
            }



            return lv;
        }
        catch (Exception er)
        {
            //uvr = new UserViewRequest();
            //uvr.Error="Error : "+er.Message.ToString();
            //lv.Add(uvr);
            Application["lasterror.aspx"] = er.Message.ToString();
            Context.Response.Redirect("../errorpage.aspx");
            return null;
        }

    }



    [WebMethod]
    public DataTable GetComplaintcategory()
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            DataSet ds = new DataSet();
            LoginClass lc = new LoginClass();
            string sql = "select catid,category from categorytab";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataReader dr;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            con.Close();


            return ds.Tables[0];
        }
        catch (Exception er)
        {
            return null;
        }

    }

    [WebMethod]
    public DataTable GetSubjectList()
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            DataSet ds = new DataSet();
            LoginClass lc = new LoginClass();
            string sql = "select subid,subject from subjecttab order by subject";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            SqlDataReader dr;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);
            con.Close();


            return ds.Tables[0];
        }
        catch (Exception er)
        {
            return null;
        }

    }


    [WebMethod]
    public CommonReturnMsg NewComplain(int cid,string lid, DateTime cdate,string catid,string subid, string complain, string cremark)
    {
        try
        {
            LoginClass login = new LoginClass();
            login = (LoginClass)Session["info"];


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_NewRequest", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@lid", lid);
            cmd.Parameters.AddWithValue("@clid",login.lid);
            cmd.Parameters.AddWithValue("@cdate", cdate);
          
            cmd.Parameters.AddWithValue("@catid", catid);
            cmd.Parameters.AddWithValue("@subid", subid);
            cmd.Parameters.AddWithValue("@complain", complain);
            cmd.Parameters.AddWithValue("@remark", cremark);

            cmd.Parameters.Add("@r", SqlDbType.Char, 500);
            cmd.Parameters["@r"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@rcid", SqlDbType.Char, 500);
            cmd.Parameters["@rcid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string r = (string)cmd.Parameters["@r"].Value;// Success or Failed
            string rcid = (string)cmd.Parameters["@rcid"].Value;
            con.Close();

            rm.id = int.Parse(rcid.Trim());
            rm.msg = r.Trim();
           LoginClass lc = new LoginClass();
            lc =GetUserInfoByID(lid);
            NotificationClass nc = new NotificationClass();

            nc.Name = lc.name;
            nc.MobileNo = lc.commmobileno;
            nc.SmsText = "Message from Help Desk, Your request successfully generated.Request ID : " + cm.GenrateComplainID(rm.id.ToString());
            StringBuilder email = new StringBuilder();
            email.Append("");
            email.Append("Your request Successfully generated from Help Desk portal.</br>Request ID : " + cm.GenrateComplainID(rm.id.ToString()));
            
            nc.EmailSubject = "Help Desk - Notification";

            nc.Emailid = lc.commemail; nc.EmailText = email.ToString();
            Notification(nc);
            return rm;
        }
        catch (Exception er)
        {
            rm.id = 0;
            rm.msg = er.Message.ToString();

            return rm;
        }

    }
    protected string Notification(NotificationClass nc)
    {
        string msg = "Success";
        try
        {

         Task.Run(() => WS_Notification.NotificationBySMS(nc.MobileNo, nc.SmsText));
          //WS_Notification.NotificationBySMS(nc.MobileNo, nc.SmsText);

        }
        catch
        {
            msg += "Failed to Sending SMS ";
        }
        try
        {
     Task.Run(() => WS_Notification.NotificationByEmail(nc.Emailid, nc.EmailSubject, nc.EmailText));

        //WS_Notification.NotificationByEmail(nc.Emailid, nc.EmailSubject, nc.EmailText);
        }
        catch
        {
            msg += "Failed to Sending E-Mail ";
        }

        return msg;

    }
    CommonReturnMsg rm = new CommonReturnMsg();
    [WebMethod]
    public DataTable GetComplainant(string prefixText)
    {

        try
        {
            CMSClass cm = new CMSClass();
            string sql = "";
            if (!prefixText.Equals("ALL"))
                sql = "select * from vwALLuser where roleName='User' and  lid=" + prefixText + " order by name";
            else
                sql = "select * from vwALLuser   order by name";



            DataTable dt = new DataTable();
            dt = cm.GetDataTable(sql);


            return dt;
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public string Get_ComplainCount(string str)
    {

        try
        {
            CMSClass cm = new CMSClass();
            string sql = "";
            if (!str.Equals("ALL"))
                sql = "select count(cid) from vwcomplain ";
            else if (!str.Equals("Open"))
                sql = "select count(cid) from vwcomplain where status='Open'";
            else if (!str.Equals("Assign"))
                sql = "select count(cid) from vwcomplain where status='Assign'";
            else if (!str.Equals("Pending"))
                sql = "select count(cid) from vwcomplain where status='Pending'";
            else if (!str.Equals("Close"))
                sql = "select count(cid) from vwcomplain where status='Close'";


            string rv = cm.findfun(sql);


            return rv;
        }
        catch
        {
            return "0";
        }
    }

    [WebMethod]
    public DataTable GetBuilding()
    {
        DataTable dt = new DataTable();
        string sql = "select buildingname,bid from buildingtab order by buildingname";
        dt = cm.GetDataTable(sql);

        return dt;
    }
    [WebMethod]
    public DataTable GetRoom()
    {
        DataTable dt = new DataTable();
        string sql = "select roomid,room from roomtab order by roomid asc";
        dt = cm.GetDataTable(sql);

        return dt;
    }
    [WebMethod]
    public string CreateNewUser(NewRegistrationClass nrc)
    {
        string r = "Failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_UserRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;

          
        
            cmd.Parameters.AddWithValue("@name", nrc.Name);
            cmd.Parameters.AddWithValue("@designation", nrc.Designation);
            cmd.Parameters.AddWithValue("@email", nrc.Email);
            cmd.Parameters.AddWithValue("@mobileno", nrc.MobileNo);
            cmd.Parameters.AddWithValue("@commemail", nrc.CommEmail);
            cmd.Parameters.AddWithValue("@commmobileno", nrc.CommMobileNo);
            cmd.Parameters.AddWithValue("@bid", nrc.BID);
            cmd.Parameters.AddWithValue("@room", nrc.Room);
            cmd.Parameters.AddWithValue("@batch", nrc.Batch);
            cmd.Parameters.AddWithValue("@rollno", nrc.RollNo);
            cmd.Parameters.AddWithValue("@UserName", nrc.UserName);
            cmd.Parameters.AddWithValue("@password", nrc.Password);

            cmd.Parameters.Add("@r", SqlDbType.Char, 500);
            cmd.Parameters["@r"].Direction = ParameterDirection.Output;
          
            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@r"].Value.ToString().Trim();// Success or Failed
          
            con.Close();


            return r;
        }
        catch(Exception er)
        {
            return er.Message.ToString().Trim();
        }
    }
    [WebMethod]
    public string DeleteUser(int userid=0)
    {
        string r = "Failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_deleteuser", con);
           
            cmd.CommandType = CommandType.StoredProcedure;
            if (userid > 0)
                cmd.Parameters.AddWithValue("@lid",userid);
         

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'"," ").Trim();
        }
    }

    [WebMethod]
    public string AssignEngineer(string cid,string EnggId,string EnggName,string clid=null)
    {
        try
        {
          

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_complainassign", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cid",cid);
            cmd.Parameters.AddWithValue("@lid",EnggId);
            cmd.Parameters.AddWithValue("@clid", clid);

            cmd.Parameters.Add("@r", SqlDbType.Char, 500);
            cmd.Parameters["@r"].Direction = ParameterDirection.Output;
          
            cmd.ExecuteNonQuery();
            string r = (string)cmd.Parameters["@r"].Value.ToString().Trim();// Success or Failed
       
            con.Close();
            LoginClass lc = new LoginClass();
            LoginClass eid = new LoginClass();
            NotificationClass nc = new NotificationClass();
            NotificationClass nc1 = new NotificationClass();
            if (r.Contains("Success"))
            {

                lc = GetUserDetailsByCID(cid);
                eid = GetLoginUserByID(EnggId);
            }

            if (!lc.ErrorMassage.Equals("Failed"))
            {
                nc.Name = lc.name;
                nc.MobileNo = lc.commmobileno;
                nc.SmsText = "Message from Help Desk, Your request ID No HD-" + cid + " Assign to the Engineer " + EnggName;
                StringBuilder email = new StringBuilder();
                email.Append("");
                email.Append("Your request id no HD-" + cid + " Assign to the Engineer " + EnggName);

                nc.EmailSubject = "CMS Notification -Engineer Assign Against " + cid;

                nc.Emailid = lc.commemail; nc.EmailText = email.ToString();

                Notification(nc);

                nc1.Emailid = eid.commemail;
                nc1.MobileNo = eid.commmobileno;
                nc1.SmsText = "Help Desk Assign Request "+cid+" to You - Hepl Desk Notification";
                nc1.EmailSubject = "Assign Request Notification Mail.";
                nc1.EmailText = "Help Desk assign request " + cid + " to you please check and solve as soon as possible.";
                Notification(nc1);
            }
            return "Success";
        }
        catch (Exception er)
        {
           return "Failed with Error : "+ er.Message.ToString();
        }

    }


    [WebMethod]
    public string UpdateRequestStatus(string cid, string status, string remark)
    {
        try
        {
            LoginClass login = (LoginClass)Session["info"];
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_UpdateRequestStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cid",int.Parse(cid));
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@clid",login.lid);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            string r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();
            LoginClass lc = new LoginClass();
            NotificationClass nc = new NotificationClass();
            if (r.Contains("Success"))
            {

                lc =  GetUserDetailsByCID(cid);

            }
            if (!lc.ErrorMassage.Equals("Failed"))
            {
                nc.Name = lc.name;
                nc.MobileNo = lc.commmobileno;
                nc.SmsText = "Message from Help Desk,Your request Id No HD-"+cid+" Status has been "+status+" with Remarks of "+remark;
                StringBuilder email = new StringBuilder();
                email.Append("");
                email.Append("Your request id no HD-" + cid + " Status has been " + status);
                email.Append("</br> with Remark of " + remark);

                nc.EmailSubject = "Help Desk Notification - Request Update on request id HD-" + cid;

                nc.Emailid = lc.commemail; nc.EmailText = email.ToString();
                Notification(nc);
            }
            return "Success";
        }
        catch (Exception er)
        {
            return "Failed with Error : " + er.Message.ToString();
        }

    }

    [WebMethod]
    public string UpdateHDUser(LoginClass lc)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_UpdateLogininfo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@lid", lc.lid);
          
            cmd.Parameters.AddWithValue("@username",lc.username);
            cmd.Parameters.AddWithValue("@password",lc.password);
            cmd.Parameters.AddWithValue("@name",lc.name);
            cmd.Parameters.AddWithValue("@commemail",lc.commemail);
            cmd.Parameters.AddWithValue("@commmobileno",lc.commmobileno);
            cmd.Parameters.AddWithValue("@bid", lc.bid);
            cmd.Parameters.AddWithValue("@roomid", lc.roomid);
            cmd.Parameters.AddWithValue("@role",lc.role);
            cmd.Parameters.AddWithValue("@status",lc.status);
            cmd.Parameters.AddWithValue("@designation", lc.designation);
            cmd.Parameters.AddWithValue("@batch", lc.batch);
            cmd.Parameters.AddWithValue("@rollno", lc.rollno);



            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@msg", SqlDbType.Char, 500);
            cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            ReturnMessageClass rm = new ReturnMessageClass();

            rm.Message = (string)cmd.Parameters["@msg"].Value.ToString().Trim();// Success or Failed
            rm.id= (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();
            con.Close();

            if (rm.Message.Contains("Succ"))
                return "Success";
            else
                return rm.Message;
        }
        catch (Exception er)
        {
            return "Failed with Error : " + er.Message.ToString();
        }

    }

    [WebMethod]
    public string ImportUsers(DataTable imp)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_ImportUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tyUsersTab", imp);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
         
            cmd.ExecuteNonQuery();

            ReturnMessageClass rm = new ReturnMessageClass();

       
            rm.Message = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();
            con.Close();

            if (rm.Message.Contains("Succ"))
                return "Success";
            else
                return rm.Message;
        }
        catch (Exception er)
        {
            return "Failed with Error : " + er.Message.ToString();
        }

    }



    [WebMethod]
    public string DeleteRequest(string  cid,string clid)
    {
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_DeleteRequest", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@clid", clid);

            cmd.Parameters.AddWithValue("@cid",cid);
           



            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
        
            cmd.ExecuteNonQuery();

             string msg = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();
            con.Close();

            if (msg.Contains("Succ"))
                return "Success";
            else
                return msg;
        }
        catch (Exception er)
        {
            return "Failed with Error : " + er.Message.ToString();
        }

    }
    [WebMethod]
    public LoginClass GetUserDetailsByCID(string cid)
    {
        DataTable dt = new DataTable();
        string sql = "select * from vwrequest where cid='" + cid + "'";

        dt = cm.GetDataTable(sql);
      LoginClass  l = new LoginClass();
        foreach (DataRow dr in dt.Rows)
        {
            l.name = dr["name"].ToString();
            l.commemail = dr["commemail"].ToString();
            l.commmobileno = dr["commmobileno"].ToString();
            l.designation = dr["designation"].ToString();
            l.ErrorMassage = "Success"; 
        }

        if (dt.Rows.Count == 0)
            l.ErrorMassage = "Failed";

        return l;
    }
    [WebMethod]
    public string UpdateCategory(CategoryClass cat,string action="Insert")
    {
        string r = "failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_UpdateCategory", con);

            cmd.CommandType = CommandType.StoredProcedure;
          
                cmd.Parameters.AddWithValue("@Catid", cat.catID);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@category", cat.Category);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'", " ").Trim();
        }
    }

    [WebMethod]
    public string UpdateDesignation(DesignationClass des, string action = "Insert")
    {
        string r = "failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_UpdateDesignation", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@designation",des.Designation);
            cmd.Parameters.AddWithValue("@action", action);
          

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'", " ").Trim();
        }
    }
    [WebMethod]
    public string UpdateUserRole(UserRoleClass role, string action = "Insert")
    {
        string r = "failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_UpdateUserRole", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Rolename", role.RoleName);
            cmd.Parameters.AddWithValue("@Rolepriority", role.Priority);
            cmd.Parameters.AddWithValue("@action", action);


            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'", " ").Trim();
        }
    }
    [WebMethod]
    public List<ProductClass> GetProduct(string pid = "0",string pcat="ALL")
    {
        string jstr = "";
        List<ProductClass> products = new List<ProductClass>();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
             using (con)
            {
                SqlCommand sqlComm = new SqlCommand("proc_GetProduct", con);
            
                sqlComm.Parameters.AddWithValue("@pid", pid);
                sqlComm.Parameters.AddWithValue("@pcat", pcat);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }


            foreach (DataRow dr in dt.Rows)
            {
                ProductClass pc = new ProductClass();


                pc.pid = dr["pid"].ToString();
                pc.pname = dr["pname"].ToString();
                pc.pcategory = dr["pcategory"].ToString();
                pc.pdescription = dr["pdescription"].ToString();
               
                products.Add(pc);
            }
            con.Close();


        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return products;
    }

    [WebMethod]
    public string UpdateProduct(ProductClass pc, string action)
    {
        string r = "Failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_updateproduct", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", pc.pid);
            cmd.Parameters.AddWithValue("@pname", pc.pname);
            cmd.Parameters.AddWithValue("@pcategory", pc.pcategory);
            cmd.Parameters.AddWithValue("@pdescription", pc.pdescription);

            cmd.Parameters.AddWithValue("@action", action);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'", " ").Trim();
        }
    }

    [WebMethod]
    public string UpdateUserProduct(UserProductClass pc,string action)
    {
        string r = "Failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_updateuserproduct", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@lpid", pc.lpid);
            cmd.Parameters.AddWithValue("@lid", pc.lid);
            cmd.Parameters.AddWithValue("@pid", pc.pid);
            cmd.Parameters.AddWithValue("@psrno", pc.psrno);
          
            cmd.Parameters.AddWithValue("@action", action);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'", " ").Trim();
        }
    }
    [WebMethod]
    public List<UserProductClass> GetUserProduct(string lpid = "0",string lid = "0",string pid="0",string cat="ALL")
    {
        string jstr = "";
        List<UserProductClass> products = new List<UserProductClass>();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();


       
            using (con)
            {
                SqlCommand sqlComm = new SqlCommand("proc_GetUserProduct", con);
                sqlComm.Parameters.AddWithValue("@lpid", lpid);
                sqlComm.Parameters.AddWithValue("@lid",lid);
                sqlComm.Parameters.AddWithValue("@pid",pid);
                sqlComm.Parameters.AddWithValue("@pcat",cat);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                UserProductClass pc = new UserProductClass();
                pc.lpid = dr["lpid"].ToString();
                pc.lid = dr["lid"].ToString();
                pc.name = dr["name"].ToString();
                pc.pid = dr["pid"].ToString();
                pc.psrno = dr["psrno"].ToString();
                pc.pname = dr["pname"].ToString();
                pc.pcategory = dr["pcategory"].ToString();
                pc.pdescription = dr["pdescription"].ToString();

                products.Add(pc);
            }
            con.Close();


        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return products;
    }

    [WebMethod]
    public DataTable GetUserProductPrintable(string lid = "0")
    {
        string jstr = "";
        List<UserProductClass> products = new List<UserProductClass>();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();



            using (con)
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetUserProductPrintable", con);
                sqlComm.Parameters.AddWithValue("@lid", lid);
             

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            con.Close();


        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return dt;
    }


    [WebMethod]
    public List<ProductCategoryClass> GetProductCategory(string pcatid = "0", string pcat = "ALL")
    {
        string jstr = "";
        List<ProductCategoryClass> products = new List<ProductCategoryClass>();
        DataTable dt = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            using (con)
            {
                SqlCommand sqlComm = new SqlCommand("proc_GetProductCategory", con);

                sqlComm.Parameters.AddWithValue("@pcatid", pcatid);
                sqlComm.Parameters.AddWithValue("@pcategory", pcat);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }


            foreach (DataRow dr in dt.Rows)
            {
                ProductCategoryClass pc = new ProductCategoryClass();


                pc.pcatid = dr["pcatid"].ToString();
              
                pc.pcategory = dr["pcategory"].ToString();
           

                products.Add(pc);
            }
            con.Close();


        }
        catch (Exception er)
        {
            Application["lasterror"] = er.Message.ToString();
            resp = Context.Response;
            resp.Redirect("errorpage.aspx");
        }
        return products;
    }

    [WebMethod]
    public string UpdateProductCategory(ProductCategoryClass pc, string action)
    {
        string r = "Failed";
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_updateproductCategory", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pcatid", pc.pcatid);
          
            cmd.Parameters.AddWithValue("@pcategory", pc.pcategory);
        

            cmd.Parameters.AddWithValue("@action", action);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            r = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();


            return r;
        }
        catch (Exception er)
        {
            return er.Message.ToString().Replace("'", " ").Trim();
        }
    }
    [WebMethod]
    public ReturnMessageClass UpdateInventory(InventoryClass InvObj, string action)
    {
        string r = "Failed";
        ReturnMessageClass rm = new ReturnMessageClass();
        try
        {
            CMSClass cm = new CMSClass();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_updateinventory", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@invid", int.Parse(InvObj.InvID));
            cmd.Parameters.AddWithValue("@buildingName", InvObj.BuildingName);
            cmd.Parameters.AddWithValue("@product", InvObj.Product);
            cmd.Parameters.AddWithValue("@room", InvObj.Room);
            cmd.Parameters.AddWithValue("@model", InvObj.Model);
            cmd.Parameters.AddWithValue("@serialno", InvObj.SerialNo);
            cmd.Parameters.AddWithValue("@status", InvObj.Status);
            cmd.Parameters.AddWithValue("@problem", InvObj.Problem);

            cmd.Parameters.AddWithValue("@action", action);

            cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
            cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            rm.Message = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();// Success or Failed

            con.Close();



        }
        catch (Exception er)
        {
            rm.Message.ToString().Replace("'", " ").Trim();
        }

        return rm;

    }

    [WebMethod]
    public List<Inventory> GetInventory(string invid="0",string buildingName="ALL",string room="ALL")
    {
        DataTable dt = new DataTable();
        string cond = "";
         List<Inventory> inv = new List<Inventory>();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            using (con)
            {
                SqlCommand sqlComm = new SqlCommand("proc_GetInventory", con);

                sqlComm.Parameters.AddWithValue("@InvID", invid);
                sqlComm.Parameters.AddWithValue("@buildingName",buildingName);
                sqlComm.Parameters.AddWithValue("@room",room);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                inv.Add(new Inventory
                {
                    invid = dr["invid"].ToString(),
                    building = dr["buildingname"].ToString()
                ,
                    room = dr["room"].ToString()
                ,
                    username = dr["username"].ToString()

                ,
                    pcmodel = dr["pcmodel"].ToString()
                ,
                    pcserialno = dr["pcserialno"].ToString()
                ,
                    pcstatus = dr["pcstatus"].ToString()
                ,
                    pcproblem = dr["pcproblem"].ToString()

                ,
                    monitormodel = dr["monitormodel"].ToString()
                ,
                    monitorserialno = dr["monitorserialno"].ToString()
                ,
                    monitorstatus = dr["monitorstatus"].ToString()
                ,
                    monitorproblem = dr["monitorproblem"].ToString()

                ,
                    keyboardmodel = dr["keyboardmodel"].ToString()
                ,
                    keyboardserialno = dr["keyboardserialno"].ToString()
                ,
                    keyboardstatus = dr["keyboardstatus"].ToString()
                ,
                    keyboardproblem = dr["keyboardproblem"].ToString()

                ,
                    mousemodel = dr["mousemodel"].ToString()
                ,
                    mouseserialno = dr["mouseserialno"].ToString()
                ,
                    mousestatus = dr["mousestatus"].ToString()
                ,
                    mouseproblem = dr["mouseproblem"].ToString()

                ,
                    upsmodel = dr["upsmodel"].ToString()
                ,
                    upsserialno = dr["upsserialno"].ToString()
                ,
                    upsstatus = dr["upsstatus"].ToString()
                ,
                    upsproblem = dr["upsproblem"].ToString()


                ,
                    printermodel = dr["printermodel"].ToString()
                ,
                    printerserialno = dr["printerserialno"].ToString()
                ,
                    printerstatus = dr["printerstatus"].ToString()
                ,
                    printerproblem = dr["printerproblem"].ToString()

                ,
                    scannermodel = dr["scannermodel"].ToString()
                ,
                    scannerserialno = dr["scannerserialno"].ToString()
                ,
                    scannerstatus = dr["scannerstatus"].ToString()
                ,
                    scannerproblem = dr["scannerproblem"].ToString()

                ,
                    laptopmodel = dr["laptopmodel"].ToString()
                ,
                    laptopserialno = dr["laptopserialno"].ToString()
                ,
                    laptopstatus = dr["laptopstatus"].ToString()
                ,
                    laptopproblem = dr["laptopproblem"].ToString()

                ,
                    projectormodel = dr["projectormodel"].ToString()
                ,
                    projectorserialno = dr["projectorserialno"].ToString()
                ,
                    projectorstatus = dr["projectorstatus"].ToString()
                ,
                    projectorproblem = dr["projectorproblem"].ToString()
                });
            }


            }
        catch { }
     

        
        return inv;
    }

    public List<InventoryClass> GetInventoryProduct(string pname, string iid="0")
    {
        DataTable dt = new DataTable();
        string cond = "";
        List<InventoryClass> inv = new List<InventoryClass>();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cls"].ConnectionString.ToString());
            con.Open();
            using (con)
            {
                SqlCommand sqlComm = new SqlCommand("proc_GetInventory", con);
                sqlComm.Parameters.AddWithValue("@invid",iid);
                sqlComm.Parameters.AddWithValue("@p",pname);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(dt);
            }

            foreach (DataRow dr in dt.Rows)
            {
                inv.Add(new InventoryClass
                {
                    InvID = dr["invid"].ToString(),
                    BuildingName = dr["buildingname"].ToString()
                ,
                    Room = dr["room"].ToString()
                ,
                    Model = dr["model"].ToString()
                ,
                    SerialNo = dr["serialno"].ToString()
                ,
                    Status = dr["status"].ToString()
                ,
                    Problem = dr["problem"].ToString()

               
                });
            }


        }
        catch { }



        return inv;
    }

}
