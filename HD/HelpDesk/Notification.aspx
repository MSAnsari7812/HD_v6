<%@ Page Title="" Language="C#" MasterPageFile="~/Helpdesk/Helpdesk.master" AutoEventWireup="true" CodeFile="Notification.aspx.cs" Inherits="Admin_AssignToEngg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
        <asp:HiddenField ID="hfcid" Value="0" runat="server" />
        <div class="row">
            <div class="col-lg-4 col-sm-12 col-md-12">
                 <p class="h4 border-bottom">Notification   </p>
  <div class="row" runat="server" id="divreqid">
              <div class="col-lg-12 form-group">
                  <p>
<%--                  <strong class="alert-info"> Request ID : </strong> --%>  
                      <asp:label runat="server" CssClass="btn btn-outline-info" ID="lblReqID"></asp:label>
                  </p>
              </div>
      </div>
              
       <div class="row">
             <div class="col-lg-12 font-weight-bold form-group">
                 <label>
                    Type SMS Message(160 Character only)
                    <asp:CheckBox ID="cksms"   runat="server" /> <span class="alert-warning">Check for Send</span>
                 </label>
                 <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="MultiLine" MaxLength="160" runat="server">

                 </asp:TextBox>
                
             </div>
            </div>
       <div class="row">
            <div class="col-lg-12 font-weight-bold form-group">
                 <label>
                    Type Email Notification <asp:CheckBox ID="ckemail"  runat="server" /> <span class="alert-warning">Check for Send</span>
                 </label>
                 <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="MultiLine" MaxLength="160" runat="server">

                 </asp:TextBox>
                
             </div>
            </div>
       <div class="row">
             <div class="col-lg-1">
                 <asp:linkbutton ID="lbsubmit" class="btn btn-danger" runat="server" OnClick="Unnamed1_Click">
                     Send Notification

                 </asp:linkbutton>
             </div>
        </div>
            </div>
        </div>
      

    </div>
</asp:Content>

