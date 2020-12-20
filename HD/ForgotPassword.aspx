<%@ Page Title="" Language="C#" MasterPageFile="~/CallManagementSystem.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Admin_ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">

       
        <div class="col-lg-4">

        </div>
        <div class="col-lg-4">
            <br />
            <h1 class="text-center">Generate Password</h1>
            <asp:TextBox ID="txtEmailID" placeholder="Enter Your Registered Email ID" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                Display="Dynamic"
                ForeColor="Red"
                SetFocusOnError="true"
                ControlToValidate="txtEmailID"

                 ErrorMessage="*"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtEmailID"
                      
                    ErrorMessage="Enter Valid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               
            <br />
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-secondary w-100" runat="server" OnClick="LinkButton1_Click">Generate Password</asp:LinkButton>
            


             </div>
        <div class="col-lg-4">

        </div>
             </div>
    </div>
</asp:Content>

