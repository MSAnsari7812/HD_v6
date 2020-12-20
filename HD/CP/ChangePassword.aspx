<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UserMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Users_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
        <h3 class="text-center border-bottom">Change Password</h3>
        <div class="row form-group">
            <div class="col-lg-4">
                <label>Old Password</label>
                <asp:TextBox ID="txtOldPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    ControlToValidate="txtOldPassword"

                     ErrorMessage="Enter Old Password"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="row form-group">
            <div class="col-lg-4">
                <label>New Password</label>
                <asp:TextBox ID="txtNewPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    ControlToValidate="txtNewPassword"

                     ErrorMessage="Enter Old Password"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="row form-group">
            <div class="col-lg-4">
                <label>Confirm New Password</label>
                <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ForeColor="Red"
                    SetFocusOnError="true"
                    ControlToValidate="txtConfirmPassword"

                     ErrorMessage="Enter Old Password"></asp:RequiredFieldValidator>

                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                     ForeColor="Red"
                    SetFocusOnError="true"
                    ControlToCompare="txtNewPassword"
                    ControlToValidate="txtConfirmPassword"
                    ErrorMessage="password does not match"></asp:CompareValidator>

            </div>
        </div>
         <div class="row">
            <div class="col-lg-12">
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" OnClick="LinkButton1_Click">Click to Change</asp:LinkButton>

            </div>
        </div>
    </div>
</asp:Content>

