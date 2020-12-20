<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="Admin_UserManagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">

<style>
    .table th{
        text-align:center;
        background-color:cornflowerblue;
    }
</style>
   <div class="row text-lg-center">
       <div class="col-lg-12">
       <h3>User Management</h3>
           </div>
     </div>
    <br />
    <div class="row">
        <div class="col-lg-2">        </div>
          <div class="col-lg-8">  
              <div class="row">
                    <div class="col-lg-3">     <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary w-100" runat="server" OnClick="LinkButton1_Click">View</asp:LinkButton>
      </div>
                   <div class="col-lg-3">     <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary w-100" runat="server" OnClick="LinkButton2_Click">New</asp:LinkButton>
        </div>
                   <div class="col-lg-3">    <a class="btn btn-secondary w-100"  href="UpdateUserRole.aspx">Role Manager</a>
         </div>
                   <div class="col-lg-3">        <a class="btn btn-secondary w-100"  href="ImportData.aspx">Import Users</a>
           </div>
              </div>
          </div>
          <div class="col-lg-2">        </div>
    </div>
          <br />
    <div class="row">
        <div class="col-lg-12">

      
  
    <asp:hiddenfield runat="server" ID="hflid" Value="0"></asp:hiddenfield>
         <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">
            <div align="right"> 
             <input  id="myInput" type="text" placeholder="Search.."></div>
            <div class="table-responsive" style="height:450px;width:auto">
                
            <asp:GridView ID="GridView1" ClientIDMode="Static" CssClass="table table-bordered table-hover dataTables_scrollHead" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                <EmptyDataTemplate>
                    <h3 class="text-center">No Record Found</h3>
                </EmptyDataTemplate>
                <Columns>
                      <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" Height="30" Width="30"
                                CommandArgument='<%# Eval("lid") %>' CommandName="ED"
                                 ImageUrl="../Images/editicon.jpg" runat="server" />
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField DataField="role" HeaderText="User Role" />
                    <asp:BoundField DataField="username" HeaderText="User Name" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                    <asp:BoundField DataField="name" HeaderText="Full Name" />
                    <asp:BoundField DataField="commmobileno" HeaderText="Mobile No" />
                    <asp:BoundField DataField="commemail" HeaderText="Email ID" />
                       <asp:BoundField DataField="designation" HeaderText="Designation" />
                    <asp:BoundField DataField="Building" HeaderText="Building Name" />
                       <asp:BoundField DataField="room" HeaderText="Room" />
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" Height="30" Width="30"
                                OnClientClick="return confirm('Are you sure?');"
                                CommandArgument='<%# Eval("lid") %>' CommandName="DEL"
                                 ImageUrl="../Images/del.jpg" runat="server" />
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="container-fluid">
                <div class="row form-group">
                    <div class="col-4">
                        <label>User Name<span class="RedColor">(*)</span></label>
                        <asp:TextBox ID="txtUserName" CssClass="form-control"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="txtUserName"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                             ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                         </div>
               
                    <div class="col-4 form-group">
                        <label>Password<span class="RedColor">(*)</span></label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="txtPassword"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                             ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                         </div>
                      <div class="col-4 form-group">
                        <label>Status<span class="RedColor">(*)</span></label>
                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                            <asp:ListItem Value="N/A">Select Status</asp:ListItem>
                             <asp:ListItem Value="Active">Active</asp:ListItem>
                              <asp:ListItem Value="DeActive">DeActive</asp:ListItem>
                             
                         </asp:DropDownList>  

                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="ddlStatus"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                               InitialValue="N/A"
                             ErrorMessage="Select Status"></asp:RequiredFieldValidator>
                      </div>
                </div>
                <div class="row">
                    <div class="col-3 form-group">
                        <label>Full Name<span class="RedColor">(*)</span></label>
                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="txtName"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                             ErrorMessage="Enter Full Name"></asp:RequiredFieldValidator>
                    </div>
             
                    <div class="col-3 form-group">
                        <label>Mobile No<span class="RedColor">(*)</span></label>
                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" TextMode="Number" MaxLength="10" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="txtMobileNo"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                             ErrorMessage="Enter Mobile No"></asp:RequiredFieldValidator>
                         </div>
                     <div class="col-3 form-group">
                        <label>Email ID<span class="RedColor">(*)</span></label>
                        <asp:TextBox ID="txtEmailID" CssClass="form-control" TextMode="Email"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="txtEmailID"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                             ErrorMessage="Enter E-Mail ID"></asp:RequiredFieldValidator>
                           </div>
                     <div class="col-3 form-group">
                        <label>Uer Role<span class="RedColor">(*)</span></label>
                         <asp:DropDownList ID="ddlRole" DataTextField="rolename" DataValueField="rolename"
                             AppendDataBoundItems="true" CssClass="form-control" runat="server">
                             <asp:ListItem Value="N/A">Select Role</asp:ListItem>
                          
                            
                         </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            Display="Dynamic"
                            ForeColor="Red"
                            ControlToValidate="ddlRole"
                            ValidationGroup="l1"
                            SetFocusOnError="true"
                              InitialValue="N/A"
                             ErrorMessage="Select User Role"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row form-group">
                       <div class="col-3 form-group">
                            <label>Building / Block <span class="RedColor">*</span></label>
                <asp:DropDownList ID="ddlbuilding" CssClass="form-control"
                    DataTextField="buildingname" DataValueField="bid"
                     AppendDataBoundItems="true"
                     runat="server">
                    <asp:ListItem Value="-1">Select Building</asp:ListItem>
                     <asp:ListItem Value="0">Not Applicable</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="ddlbuilding"
                     InitialValue="-1"
                    ValidationGroup="l1"
                     ErrorMessage="Select Building Name"></asp:RequiredFieldValidator>
            
                           </div>
                     <div class="col-3 form-group">
                            <label>Room No <span class="RedColor">*</span></label>
                 <asp:TextBox ID="txtroomno" runat="server" CssClass="form-control" placeholder="Room NO"
                     Text="0"
                      TextMode="Number" ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="txtroomno"
                     
                    ValidationGroup="l1"
                     ErrorMessage="Enter Room No"></asp:RequiredFieldValidator>
                           </div>
                     <div class="col-lg-3">
                <label>Designation </label>
                <asp:DropDownList ID="ddlDesignation" CssClass="form-control"
                    DataTextField="designation" DataValueField="designation"
                     AppendDataBoundItems="true"
                     runat="server">
                    <asp:ListItem Value="0">Select Designation</asp:ListItem>
                      <asp:ListItem Value="N/A">Not Applicable</asp:ListItem>
                </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                     Display="Dynamic"
                     ForeColor="Red"
                     SetFocusOnError="true"
                     ControlToValidate="ddlDesignation"
                     InitialValue="0"
                    ValidationGroup="l1"
                     ErrorMessage="Select Designation"></asp:RequiredFieldValidator>
                         </div>
                </div>
                <div class="row form-group">
                    <div class="col-1">
                        <asp:LinkButton ID="LinkButton3" OnClientClick="return Confirm('Are you sure?');"
                            CssClass="btn btn-primary" ValidationGroup="l1"
                             runat="server" OnClick="LinkButton3_Click">Save</asp:LinkButton>
                    </div>
                     <div class="col-1">
                        <asp:LinkButton ID="LinkButton4" OnClientClick="return Confirm('Are you sure?');"
                            CssClass="btn btn-danger" 
                             runat="server" OnClick="LinkButton4_Click">Reset</asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
              </div>
    </div>
    <script>
$(document).ready(function(){
  $("#myInput").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#GridView1 tr").filter(function () {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });
});
</script>
</asp:Content>

