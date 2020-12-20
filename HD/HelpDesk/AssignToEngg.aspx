<%@ Page Title="" Language="C#" MasterPageFile="~/Helpdesk/Helpdesk.master" AutoEventWireup="true" CodeFile="AssignToEngg.aspx.cs" Inherits="Admin_AssignToEngg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
      <style>
       .table  td{
             text-align:left;
         }
      </style>
        <asp:HiddenField ID="hfcid" Value="0" runat="server" />
          <p class="h4 border-bottom">Assign Engineer  
              </p>
 
          <div class="row">
              <div class="col-lg-6 text-left">
                
                <table id="tb_left" class="table table-bordered">
                     <tr>
                        <td><b>Request ID</b></td>
                        <td>
                           <asp:label runat="server" ID="lblReqID"></asp:label>

                        </td>
                    </tr>
                    <tr>
                        <td><b>Name</b></td>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td><b>Designation</b></td>
                        <td>
                            <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td><b>Select Engineer<br />
&nbsp;Name</b></td>
                        <td>
                                  <asp:dropdownlist
                     ID="ddlEnggList"
                      runat="server" class="form-control" AppendDataBoundItems="True" DataSourceID="getEngineerList" DataTextField="Name" DataValueField="lid" style="font-weight: 700; color: #003366" OnDataBound="ddlEnggList_DataBound">
                     <asp:ListItem Value="0">Select Engineer</asp:ListItem>
                    
                 </asp:dropdownlist>
                 <asp:SqlDataSource ID="getEngineerList" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:cls %>" 
                     SelectCommand="SELECT [lid], [Name] FROM [UserLoginTab] WHERE ([role] like '%Engineer%') ORDER BY [Name]">
                    
                 </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:linkbutton class="btn btn-danger" runat="server"
                                 OnClientClick="return confirm('Are You Sure?')"
                                  OnClick="Unnamed1_Click" CssClass="btn btn-primary">Submit</asp:linkbutton>
          
                        </td>
                    </tr>
                </table>
              </div>
              </div>

    

    </div>
</asp:Content>

