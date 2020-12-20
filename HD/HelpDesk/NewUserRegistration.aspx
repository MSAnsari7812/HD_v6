﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Helpdesk/Helpdesk.master" AutoEventWireup="true" CodeFile="NewUserRegistration.aspx.cs" Inherits="NewUserRegistration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" runat="server">
    <div class="container">

          <p class="h4 border-bottom mt-5">New Registration</p>
        <div class="row form-group">
            <div class="col-lg-6">
                <label>Building / Block <span class="RedColor">*</span></label>
                <asp:DropDownList ID="ddlbuilding" CssClass="form-control"
                    DataTextField="buildingname" DataValueField="bid"
                     AppendDataBoundItems="true"
                     runat="server">
                    <asp:ListItem Value="0">Select Building</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="ddlbuilding"
                     InitialValue="0"
                    ValidationGroup="l1"
                     ErrorMessage="Select Building Name"></asp:RequiredFieldValidator>
            
            </div>
             <div class="col-lg-6">
                <label>Room No <span class="RedColor">*</span></label>
                 <asp:TextBox ID="txtroomno" runat="server" CssClass="form-control" placeholder="Room NO" TextMode="Number" ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtroomno"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Room No"></asp:RequiredFieldValidator>
                  </div>
        </div>
         <div class="row form-group">
            <div class="col-lg-12">
                <label>Full Name <span class="RedColor">*</span></label>
                   <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Full Name"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtName_FilteredTextBoxExtender"
                    FilterType="LowercaseLetters,UppercaseLetters,Custom"
                     runat="server" Enabled="True" TargetControlID="txtName" ValidChars=" ">
                </asp:FilteredTextBoxExtender>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtName"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Name"></asp:RequiredFieldValidator>

            </div>
        </div>
         <div class="row form-group">
            <div class="col-lg-6">
                <label>Batch No</label>
                   <asp:TextBox ID="txtBatchNo" runat="server" CssClass="form-control" placeholder="Batch No"></asp:TextBox>
            
            </div>
              <div class="col-lg-6">
                <label>Roll No</label>
  <asp:TextBox ID="txtRollNo" runat="server" placeholder="Roll No" CssClass="form-control" TextMode="Number"></asp:TextBox>
            
            </div>
        </div>
         <div class="row form-group">
            <div class="col-lg-6">
                <label>Email ID<span class="RedColor">*</span></label>
                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control" placeholder="Email ID"></asp:TextBox>
           
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtEmailID"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Email ID"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtEmailID"
                     
                    ValidationGroup="l1"
                    ErrorMessage="Enter Valid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  </div>
                
               
               <div class="col-lg-6">
                <label>Mobile No<span class="RedColor">*</span></label>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Mobile No"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtMobileNo"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Mobile No"></asp:RequiredFieldValidator>
                     </div>
            
        </div>
        <div class ="row from-group">
            <div class="col-lg-4">
              <label>User Name<span class="RedColor">*</span></label>
                        <asp:TextBox ID="txtUserName" runat="server" 
                          
                            CssClass="form-control" placeholder="Enter Login ID"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtUserName"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                </div>
            <div class="col-lg-4">
              <label>Password<span class="RedColor">*</span></label>
                        <asp:TextBox ID="txtPassword" runat="server" 
                            TextMode="Password"
                            CssClass="form-control" placeholder="Password"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtPassword"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                     </div>
             <div class="col-lg-4">
              <label>Re-Type Password<span class="RedColor">*</span></label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" 
                            TextMode="Password"
                            CssClass="form-control" placeholder="Password"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtConfirmPassword"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Re-Type Password"></asp:RequiredFieldValidator>

             <asp:CompareValidator ID="CompareValidator1" runat="server" 
                     ForeColor="Red"
                    SetFocusOnError="true"  ValidationGroup="l1"
                    ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword"
                    ErrorMessage="password does not match"></asp:CompareValidator>


                     </div>
            </div>
       
         
         <div class="row form-group">
            <div class="col-lg-12">
                <br />
                <asp:LinkButton ID="lbSubmit" CssClass="btn btn-group-lg btn-primary w-100" ValidationGroup="l1" runat="server" OnClick="lbSubmit_Click">Register</asp:LinkButton>
            </div>
        </div>
       
    </div>
</asp:Content>

