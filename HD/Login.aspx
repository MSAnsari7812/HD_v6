<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Help Desk Login</title>
      <link href="bs/CSS/CommCSS.css" rel="stylesheet" />
    <link href="bs/CSS/CSS.css" rel="stylesheet" />
    <link href="bs/CSS/sweetalert.css" rel="stylesheet" />
    <style>
        .card{
            margin-left:auto;
            margin-right:auto;
            margin-top:5%;
            width:300px;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            <Scripts>
                 <asp:ScriptReference  Path="bs/JS/jquery.js" />
                        <asp:ScriptReference  Path="bs/JS/popper.min.js" />
                 <asp:ScriptReference  Path="bs/JS/bootstrap.min.js" />
         
                <asp:ScriptReference  Path="bs/JS/sweetalert.min.js" />
            </Scripts>

        </asp:ToolkitScriptManager>
   <%--  <div class="container-fluid">
        <div class="col-lg-4">
         
        </div>
         <div class="col-lg-4">--%>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <center>
 <div class="card">
  <img class="card-img-top" style="height:200px;width:auto" src="Images/Complaint.jpg" alt="Card image">
  <div class="card-body text-left">
    <h4 class="card-title alert-heading text-center">Help Desk Login</h4>
  <div class="form-group">
  <%--  <label for="email">User Name</label>--%>
  
        <asp:TextBox ID="txtusername" class="form-control text-center" placeholder="Enter User Name" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
          Display="Dynamic" ValidationGroup="l"
           ForeColor="Red"
          ControlToValidate="txtusername"

           runat="server" ErrorMessage="Enter Valid UserName/Email ID"></asp:RequiredFieldValidator>
  </div>
  <div class="form-group">
  <%--  <label for="pwd">Password</label>--%>
     
      <asp:TextBox ID="txtpassword" class="form-control text-center"  placeholder="Enter password" runat="server" TextMode="Password" OnTextChanged="txtpassword_TextChanged" ></asp:TextBox>
    <a class="btn btn-link text-left" href="ForgotPassword.aspx">Forgot Password</a>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
          Display="Dynamic" ValidationGroup="l"
           ForeColor="Red"
          ControlToValidate="txtpassword"

           runat="server" ErrorMessage="Enter Valid Password"></asp:RequiredFieldValidator>
  </div>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server">
              <ProgressTemplate>
                <center>  <img src="Images/progress3.gif" width="40" /></center>
              </ProgressTemplate>
          </asp:UpdateProgress>
      <asp:LinkButton ID="lbsubmit" ValidationGroup="l" class="btn btn-primary w-100" runat="server" OnClick="lbsubmit_Click">Login
         
      </asp:LinkButton>
 <br />
      <a class="page-link mt-3 bg-danger text-center text-white" href="NewUserRegistration.aspx">New User</a>
  
  
  </div>
</div></center>
                             </ContentTemplate>
             </asp:UpdatePanel>
       <%--       </div>
         <div class="col-lg-4">
            
        </div>
    </div>--%>
    </form>
</body>
     
</html>
