<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="rptComplainFormViewer.aspx.cs" Inherits="Admin_rptComplainFormViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="~/Controls/CalendarDate.ascx" TagPrefix="uc1" TagName="CalendarDate" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
       <div class="row">
           <div class="col-2">
               <label>From Date</label>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox1">
               </asp:CalendarExtender>
           </div>
           <div class="col-2">
               <label>To Date</label>
               <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox2">
               </asp:CalendarExtender>
               </div>
           </div>
           <div class="row">
           <div class="col-2">
               <label>Select Officer Name</label>
               <asp:DropDownList ID="ddlUsers" AppendDataBoundItems="true" DataTextField="Name" DataValueField="lid" CssClass="form-control" runat="server">
                   <asp:ListItem>ALL</asp:ListItem>
               </asp:DropDownList>
               </div>
                 <div class="col-2">
                           <label>Select Technician</label>
               <asp:DropDownList ID="ddlEngg" AppendDataBoundItems="true" DataTextField="Name" DataValueField="lid" CssClass="form-control" runat="server">
                   <asp:ListItem>ALL</asp:ListItem>
               </asp:DropDownList>
               </div>
               </div>
               
          <div class="row">
           <div class="col-lg-1">
               <br />

               <asp:LinkButton ID="LinkButton1" CssClass="btn btn-secondary" runat="server" OnClick="LinkButton1_Click">Search</asp:LinkButton>
           </div>
       </div>
       <div class="row">
           <div class="col-lg-12">


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="835px" Height="811px">
        <LocalReport ReportPath="Reports\rptComplaintForm.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
           </div>
       </div>
   </div>
         
              
         


</asp:Content>

