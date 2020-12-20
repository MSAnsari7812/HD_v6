<%@ Page Title="" Language="C#" MasterPageFile="~/HelpDesk/Helpdesk.master" AutoEventWireup="true" CodeFile="rptInventoryReportViwer.aspx.cs" Inherits="Admin_rptComplainFormViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="~/Controls/CalendarDate.ascx" TagPrefix="uc1" TagName="CalendarDate" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
        <br />

       <div class="row">
           <div class="col-lg-4">
               <table class="table table-bordered table-sm">
                   <tr>
                       <td>
                          <strong> Select Building </strong>
                       </td>
                       <td>
                             <asp:DropDownList ID="ddlBuildingName" CssClass="form-control"
                    DataTextField="buildingname" DataValueField="buildingname"
                     runat="server">
                    <asp:ListItem>ALL</asp:ListItem>
                </asp:DropDownList>
                       </td>
                   </tr>
                     <tr>
                       <td>
                          <strong> Select Room </strong>
                       </td>
                       <td>
                             <asp:DropDownList ID="ddlRoom" CssClass="form-control"
                    DataTextField="room" DataValueField="room"
                     runat="server">
                    <asp:ListItem>ALL</asp:ListItem>
                </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2" class="text-left">
                           <asp:LinkButton ID="lbSearch" CssClass="btn btn-sm btn-primary" runat="server" OnClick="lbSearch_Click">Search</asp:LinkButton>
                       </td>
                   </tr>
               </table>
               </div>
            <div class="col-lg-8">
                <h1 class="text-capitalize text-center text-primary font-italic font-weight-bold">Inventory Report</h1>
            </div>
           </div>
       <div class="row">
           <div class="col-lg-12">


               <br />


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
         WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1200px" Height="500px">
        <LocalReport ReportPath="Reports\rptInventory.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
           </div>
       </div>
   </div>
         
              
         


</asp:Content>

