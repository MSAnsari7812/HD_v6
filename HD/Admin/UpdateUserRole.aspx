<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.master" AutoEventWireup="true" CodeFile="UpdateUserRole.aspx.cs" Inherits="Admin_UserProduct" %>


<asp:Content ID="Content2" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

      
    <h3 class="text-center border-bottom">Role Management</h3>
    <div class="container-fluid">
    <div class="row">
        
        <div class="col-lg-4">
              <div class="container-fluid">
                     <div class="row">
                <div class="col-lg-12 form-group">
                    <asp:HiddenField runat="server" ID="hfrolename" Value="0"></asp:HiddenField>
                    <label class="col-form-label-lg">Role Title. </label>
                    <asp:TextBox ID="txtRoleTitle" CssClass="form-control"  runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtRoleTitle"
                        ValidationGroup="l1"
                       
                          Display="Dynamic"
                        ErrorMessage="Enter Role Title."></asp:RequiredFieldValidator>
                    </div>
                   </div>
                 <div class="row">
                <div class="col-lg-12 form-group">
                    <label class="col-form-label-lg">Select Role Priority </label>
                    <asp:DropDownList ID="ddlPriority" CssClass="form-control"
                        AppendDataBoundItems="true"
                      
                         runat="server">
                        <asp:ListItem Value="0">Select Priority</asp:ListItem>
                         <asp:ListItem Value="1">High</asp:ListItem>
                         <asp:ListItem Value="2">Medium</asp:ListItem>
                         <asp:ListItem Value="3">Low</asp:ListItem>
                     
                    </asp:DropDownList>     
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="ddlPriority"
                        ValidationGroup="l1"
                         InitialValue="0"
                          Display="Dynamic"
                        ErrorMessage="Select Priority from list."></asp:RequiredFieldValidator>
                   <small class="RedColor">* High - 1  ,Medium - 2, Low - 3</small>
                </div>
</div>
            
              
            
              <div class="row">
                <div class="col-lg-12 form-group">
                    <asp:LinkButton ID="lbSave" CssClass="btn btn-primary" runat="server" OnClick="lbSave_Click">Save/Update</asp:LinkButton>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <img src="../Images/progress3.gif" style="height:30px;width:auto;" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                      </div>
                   </div>

            </div>   
           
        </div>
         <div class="col-lg-8">
             <asp:GridView ID="GridView1" AutoGenerateColumns="False" CssClass="table table-bordered" runat="server" BackColor="White" 
                 BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand">
                  <Columns>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:ImageButton ID="ImageButton1" Width="30"
                                   CommandArgument='<%# Eval("rolename") %>' 
                                    CommandName='ED'
                                   ImageUrl="~/Images/editicon.jpg" runat="server" />
                               <asp:ImageButton ID="ImageButton2" Width="30"
                                   CommandArgument='<%# Eval("rolename") %>' 
                                    CommandName='DEL'
                                   ImageUrl="~/Images/del.jpg" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="rolename" HeaderText="Role Name" SortExpression="rolename" />
                      
                      <asp:BoundField DataField="priority" HeaderText="Priority" SortExpression="priority" />
                  </Columns>
                  <FooterStyle BackColor="White" ForeColor="#000066" />
                  <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                  <RowStyle ForeColor="#000066" />
                  <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#007DBB" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#00547E" />
              </asp:GridView>
        </div></div>
    </div>
              </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

