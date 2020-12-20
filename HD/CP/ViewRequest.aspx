<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewRequest.aspx.cs" Inherits="UserViewRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
  
    <style>
     
    </style>
  <h3 class="text-center border-bottom">View Request</h3>     <div>


        <asp:ListView ID="ListView1" runat="server"
             OnDataBound="ListView1_DataBound"
             OnItemCommand="ListView1_ItemCommand" InsertItemPosition="None">
            <ItemTemplate>
                <div id="hdboxsmall" class=" d-block badge-light p-2 mb-3 border border-dark font-weight-bold rounded">
              <div class="table-responsive">
                      <table id="hdtab" class="table table-bordered-sm">
                    <thead>
                        <th>
                           Request ID 
                        </th>
                        <th>
                            Request Date
                        </th>
                    </thead>
                     <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server"  Text='<%#Eval("reqid") %>'></asp:Label> 
                        </td>
                        <td>
                  <asp:Label ID="Label2"  runat="server" Text='<%#Eval("requestdate") %>'></asp:Label>
               
                        </td>
                    </tr>
                     <thead>
                        <th>
                           Subject  
                        </th>
                        <th>
                            Description
                        </th>
                    </thead>
                    <tr>
                        <td>
<asp:Label ID="Label3" runat="server"
                  
                    Text='<%#Eval("requestsubject") %>'></asp:Label>
                        </td>
                        <td>
 <asp:Label ID="Label4" runat="server" Text='<%#Eval("requestdescription") %>'></asp:Label>
                        </td>
                    </tr>
                           <thead>
                        <th>
                          Delete Request
                        </th>
                        <th>
                            Edit Request
                        </th>
                    </thead>  
                  <tr>
                      <td style="text-align:center"> 
                           <asp:LinkButton ID="lbDelete"   OnClientClick="return confirm('Want to delete this request?')" CommandArgument='<%#Eval("cid") %>' CommandName="Del" runat="server">
                          <asp:ImageButton ID="ImgButtonDelete" 
                              ImageUrl="~/Images/del2.png" style="height:30px;"
                              
                          AlternateText="Delete"    runat="server" />
                         <br /> Click To Delete </asp:LinkButton>
                           
                       <%--   <asp:LinkButton ID="lbDelete" CssClass="btn btn-danger" CommandArgument='<%#Eval("cid") %>' CommandName="Del" runat="server"> Delete Request</asp:LinkButton>--%>
</td>
                       <td>
                           <a  class="btn btn-link text-primary"  data-toggle="modal" onclick="openpopup('<%# Eval("cid") %>');" 
                               data-target="#myModal">
                           <img src="../Images/editicon2.jpg" style="height:30px" />
                               <br />
                               Click To Edit
                             </a>
                       
                         
                          
                          <%-- <asp:LinkButton ID="LinkButton1" class="btn btn-primary"
                               CommandArgument='<%#Eval("cid") %>' CommandName="Change"
                                runat="server">Change Request Status</asp:LinkButton>--%>
                      
                            </td>
                  </tr>
                  
                </table>
                <table id="hdtab" class="table table-bordered">
                      <thead>
                        <th>Engineer Name</th>
                        <th>Help Desk Remark</th>
                           <th>Status</th>
                    </thead>
                      <tr>
                            <td><asp:Label ID="Label7" runat="server" Text='<%#Eval("EnggName") %>'></asp:Label></td>
                      
                        <td>
                             <asp:Label ID="Label5" runat="server" Text='<%#Eval("cmsremarks") %>'></asp:Label>
                           
                            <td>
                            <h3>  
                                 <asp:Label ID="Label6" ClientIDMode="Static"  Width="100%"   runat="server"  Text='<%#Eval("Status") %>'></asp:Label>
                                </h3>
 </td>  
                            </td>
                    </tr>
                </table>
</div>
         
            </div>
                    </ItemTemplate>
        </asp:ListView>

    </div> 
  <script>
    

      function openpopup(cid)
      {
          // alert(cid);
          $("#hfcid").val(cid);
          $("#myModal").modle('show');
      }
      function Success() {
          // alert(cid);
         
          $("#myModal").modle('hide');
      }
     
  </script>
 <div class="modal" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

          
      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title">Change Request Status</h4>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
          <asp:HiddenField ID="hfcid" ClientIDMode="Static" Value="0" runat="server" />
          <div class="alert alert-info">
             If your request is not completed then you can change the request status
          </div>
          
          <asp:DropDownList ID="ddlRequestStatus" ClientIDMode="Static" CssClass="form-control alert-dark font-weight-bold" runat="server">
                                    
                    <asp:ListItem Selected="True">Pending</asp:ListItem>
                 
                </asp:DropDownList>
          <br />
          <asp:TextBox ID="txtComments" ClientIDMode="Static" CssClass="form-control text-lg-left" placeholder="Remarks/Comments" runat="server"></asp:TextBox>
          </div>

      <!-- Modal footer -->
      <div class="modal-footer">
          <asp:UpdateProgress ID="UpdateProgress1" runat="server">
              <ProgressTemplate>
                  <img src="../Images/progress3.gif" height="60" />
              </ProgressTemplate>
          </asp:UpdateProgress>
          <asp:LinkButton ID="LinkButton1" ClientIDMode="Static" CssClass="btn btn-danger"
           OnClick="LinkButton1_Click"
               OnClientClick="return confirm('Are You Sure?');" runat="server">Change</asp:LinkButton>
   
      </div>

          </ContentTemplate>
        </asp:UpdatePanel>
    </div>
  </div>
</div>
 <script>
    
 </script>
  
</asp:Content>

