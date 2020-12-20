using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CMSObjectClass
/// </summary>
namespace CMSObject
{
    public class LoginClass
    {
        public int lid { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public string commemail { get; set; }
        public string commmobileno { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string batch { get; set; }
        public string rollno { get; set; }
        public string bid { get; set; }

        public string roomid { get; set; }
        public string building { get; set; }
        public string room { get; set; }
        public string ErrorMassage { get; set; }

        public LoginClass()
        {

            username = "Guest";
            role = "User";
            ErrorMassage = "Failed";
        }
    }
    public class ComplainClass
    {
        public int cid { get; set; }
        public DateTime cdate { get; set; }
        public string cname { get; set; }
        public string cemail { get; set; }
        public string cmobileno { get; set; }
        public string ccategory { get; set; }
        public string buildingname { get; set; }
        public string roomno { get; set; }
        public string complaint { get; set; }
        public string cremark { get; set; }
    }
    public class ComplainStatusClass
    {
        public int csid { get; set; }
        public int cid { get; set; }
        public string status { get; set; }
        public DateTime sdate { get; set; }
        public string remark { get; set; }
    }
    public class ComplainAssignmentClass
    {
        public int caid { get; set; }
        public int cid { get; set; }
        public int id { get; set; }

        public DateTime cdate { get; set; }

    }
    public class CommonReturnMsg
    {
        public int id { get; set; }
        public string msg { get; set; }
    }
    public class NotificationClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Emailid { get; set; }
        public string SmsText { get; set; }
        public string EmailText { get; set; }
        public string EmailSubject { get; set; }


    }
    public class MailClientClass
    {
        public string Sender_EmailID { get; set; }
        public string Sender_Password { get; set; }
    }

    public class UserViewRequest
    {
        public int cid { get; set; }
        public string ReqID { get; set; }
        public string RequestDate { get; set; }
        public string RequestCategory { get; set; }
        public string RequestSubject { get; set; }
        public string RequestDescription { get; set; }
        public string UserRemarks { get; set; }
        public string CMSRemarks { get; set; }
        public string RequestRemarks { get; set; }
        public string EnggName { get; set; }
        public string EnggEmail { get; set; }
        public string EnggMobile { get; set; }
        public string AssignStatus { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public string RequestDateTime { get; set; }
        public string RequestDuration { get; set; }
        public string UserProduct { get; set; }
        public string Name { get; set; }
        public string BuildingName { get; set; }
        public string Room { get; set; }
        public string Designation { get; set; }
        public string CommEmail { get; set; }
        public string CommMobile { get; set; }
        public string EnggAssignDate { get; set; }
        public string RequestStatusLastDate { get; set; }
    }

    public class EngineerViewRequest
    {
        public int cid { get; set; }
        public string ReqID { get; set; }
        public string RequestDate { get; set; }
        public string RequestCategory { get; set; }
        public string RequestSubject { get; set; }
        public string RequestDescription { get; set; }
        public string UserRemarks { get; set; }
        public string CMSRemarks { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }

    }

    public class UserRoleClass
    {
        public string RoleName { get; set; }
        public string Priority { get; set; }
    }
    public class DesignationClass
    {
        public string Designation { get; set; }
    }
    public class CategoryClass
    {
        public int catID { get; set; }
        public string Category { get; set; }
    }
    public class NewRegistrationClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Batch { get; set; }
        public string RollNo { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CommEmail { get; set; }
        public string CommMobileNo { get; set; }
        public string BuildingName { get; set; }
        public string Room { get; set; }
        public string BID { get; set; }
        public string UserName { get; set; }
        public string RoomID { get; set; }
        public string Password { get; set; }
        public string ErrorMassage { get; set; }


    }
    public class ImportUsers
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
    }
    public class ReturnMessageClass
    {
        public string id { get; set; }
        public string Message { get; set; }

    }

    public class ProductClass
    {

        public string pid { get; set; }
        public string pname { get; set; }
        public string pcategory { get; set; }
        public string pdescription { get; set; }

    }
    public class UserProductClass
    {
        public string lpid { get; set; }
        public string lid { get; set; }
        public string pid { get; set; }
        public string psrno { get; set; }
        public string name { get; set; }
        public string pname { get; set; }
        public string pcategory { get; set; }
        public string pdescription { get; set; }

    }
    public class ProductCategoryClass
    {
        public string pcatid { get; set; }
        public string pcategory { get; set; }
    }

    public class Inventory:LoginClass 
    {
        public string invid { get; set; }
        public string pcmodel { get; set; }
        public string pcserialno { get; set; }
        public string pcstatus { get; set; }
        public string pcproblem { get; set; }

        public string monitormodel { get; set; }
        public string monitorserialno { get; set; }
        public string monitorstatus { get; set; }
        public string monitorproblem { get; set; }

        public string keyboardmodel { get; set; }
        public string keyboardserialno { get; set; }
        public string keyboardstatus { get; set; }
        public string keyboardproblem { get; set; }

        public string mousemodel { get; set; }
        public string mouseserialno { get; set; }
        public string mousestatus { get; set; }
        public string mouseproblem { get; set; }

        public string upsmodel { get; set; }
        public string upsserialno { get; set; }
        public string upsstatus { get; set; }
        public string upsproblem { get; set; }

        public string printermodel { get; set; }
        public string printerserialno { get; set; }
        public string printerstatus { get; set; }
        public string printerproblem { get; set; }

        public string scannermodel { get; set; }
        public string scannerserialno { get; set; }
        public string scannerstatus { get; set; }
        public string scannerproblem { get; set; }

        public string laptopmodel { get; set; }
        public string laptopserialno { get; set; }
        public string laptopstatus { get; set; }
        public string laptopproblem { get; set; }

        public string projectormodel { get; set; }
        public string projectorserialno { get; set; }
        public string projectorstatus { get; set; }
        public string projectorproblem { get; set; }

    }

}