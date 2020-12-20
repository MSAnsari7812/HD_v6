<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ImportData.aspx.cs" Inherits="ImportData" Title="Import Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="container">
     <p class="text-center h3">Bulk Import Users</p>
         <p class="text-center">  <a href="../ImportUser.xls" target="_blank">Download Excel Format</a></p>
    
        
        <br />
 <div class="row" align="center">
      <div class="col-lg-3"> </div>
     <div class="col-lg-6">  
        <table class="table table-bordered">
            <tr>
                <th>
                    Select .xls File
                </th>
                <td>
                     <asp:FileUpload ID="FileUpload1" onchange="this.form.submit()" runat="server" />
     <%--  <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="FileUpload1"
    runat="server" Display="Dynamic" ForeColor="Red" />--%>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.xlsx)$"
    ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid excel file."
    Display="Dynamic" />
                </td>
          
                <td colspan="2">
 <asp:Button ID="Button6" runat="server" CssClass="btn btn-success"
               Text="Import" OnClick="Button6_Click" />
           <asp:ConfirmButtonExtender ID="Button6_ConfirmButtonExtender" runat="server" 
               ConfirmText="Are You Sure?" Enabled="True" TargetControlID="Button6">
           </asp:ConfirmButtonExtender>
                </td>
            </tr>
        </table>
     
      
         </div>
            <div class="col-lg-3"> </div>
        
         </div>
  <br />
        <br />
   <div class="row">
       <div class="col-lg-12">

     
       <asp:GridView ID="GridView1" CssClass="table table-bordered text-center" runat="server" BackColor="White" 
           BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
           <RowStyle ForeColor="#000066" />
           <FooterStyle BackColor="White" ForeColor="#000066" />
           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
       </asp:GridView>
             </div>
   </div>
</div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

