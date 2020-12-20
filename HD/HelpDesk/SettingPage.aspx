<%@ Page Title="" Language="C#" MasterPageFile="~/Helpdesk/Helpdesk.master"
     AutoEventWireup="true" CodeFile="SettingPage.aspx.cs" Inherits="HelpDesk_SettingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <asp:hiddenfield ID="hfid" runat="server" Value="0"></asp:hiddenfield>
      <p class="h4 border-bottom">New Setting  <asp:HyperLink ID="HyperLink1" CssClass="float-right" NavigateUrl="~/HelpDesk/Dashboard.aspx" runat="server">Home</asp:HyperLink></p>
    <label>Select Option</label>
    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" 
        CssClass="form-control bg-info text-white"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="Building">Building Management</asp:ListItem>
           <asp:ListItem Value="Room">Room Management</asp:ListItem>
           <asp:ListItem Value="Subject">Manage Nature of The Complaint</asp:ListItem>
          <asp:ListItem Value="Category">Manage Complaint Category</asp:ListItem>
          <asp:ListItem Value="Designation">User Designation Category</asp:ListItem>
        <asp:ListItem Value="Notification">Set Notification Status</asp:ListItem>
        
    </asp:DropDownList>
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="vwBuilding" runat="server">
            
              <p class="h4 border-bottom text-danger"><asp:Label ID="lblmsg" runat="server" Text="New Building Entry"></asp:Label></p>
            <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-4 col-sm-12 form-group">
                      
                        <asp:TextBox ID="txtBuildingName" CssClass="form-control" placeholder="Enter Building Name" runat="server"></asp:TextBox>
                    
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtBuildingName"
                        ValidationGroup="l1"
                    Display="Dynamic"
                        ErrorMessage="Enter Building Name"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="lbSaveBuilding" ValidationGroup="l1" CssClass="btn btn-danger m-2"  runat="server" OnClick="lblSaveBuilding_Click" OnClientClick="return confirm('Are You Sure?');">Save</asp:LinkButton>
                        <asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="Reset" OnClick="Button1_Click" OnClientClick="return confirm('Are You Sure?');" />
                       </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-sm-12 p-2  table-responsive">

                        <asp:GridView ID="GridView1" 
                           CssClass="table table-bordered"
                            runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="bid" DataSourceID="GetBuilding" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                         <asp:BoundField DataField="buildingname" HeaderText="Building Name" SortExpression="buildingname" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CommandName="Ed" CommandArgument='<%#Eval("bid")+":"+Eval("buildingname") %>' runat="server">Edit</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton2" CommandName="Del" OnClientClick="return confirm('Are you sure ?');"  CommandArgument='<%#Eval("bid") %>' runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="GetBuilding" runat="server" ConnectionString="<%$ ConnectionStrings:cls %>" SelectCommand="SELECT * FROM [BuildingTab] ORDER BY [buildingname]"></asp:SqlDataSource>

                    </div>
                </div>
            </div>
            

        </asp:View>
          <asp:View ID="vwRoom" runat="server">
          
              <p class="h4 border-bottom text-danger"><asp:Label ID="Label1" runat="server" Text="New Room No Entry"></asp:Label></p>
            <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-4 col-sm-12 form-group">
                      
                        <asp:TextBox ID="txtroom" TextMode="Number" CssClass="form-control" placeholder="Enter Room No" runat="server"></asp:TextBox>
                    
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtroom"
                        ValidationGroup="l2"
                    Display="Dynamic"
                        ErrorMessage="Enter Building Name"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="lbSaveRoom" ValidationGroup="l2" CssClass="btn btn-danger m-2"  runat="server" OnClick="lblSaveRoom_Click" OnClientClick="return confirm('Are You Sure?');">Save</asp:LinkButton>
                       <asp:Button ID="Button2" CssClass="btn  btn-primary" runat="server" Text="Reset" OnClick="Button2_Click" OnClientClick="return confirm('Are You Sure?');" />
                         </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-sm-12 p-2  table-responsive">

                        <asp:GridView ID="GridView2" 
                           CssClass="table table-bordered"
                            runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="roomid" DataSourceID="GetRoomTab" ForeColor="#333333" GridLines="None"  AllowPaging="True" AllowSorting="True" OnRowCommand="GridView2_RowCommand">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                         <asp:BoundField DataField="Room" HeaderText="Room No" SortExpression="room" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" CommandName="Ed" CommandArgument='<%#Eval("roomid")+":"+Eval("room") %>' runat="server">Edit</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton5" CommandName="Del" OnClientClick="return confirm('Are you sure ?');"  CommandArgument='<%#Eval("roomid") %>' runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="GetRoomTab" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cls %>"
                             SelectCommand="SELECT * FROM [RoomTab] ORDER BY convert(int,[Room])"></asp:SqlDataSource>

                    </div>
                </div>
            </div>
          

        </asp:View>
          <asp:View ID="vwSubject" runat="server">
               <p class="h4 border-bottom text-danger"><asp:Label ID="Label2" runat="server" Text="Nature of The Complaint"></asp:Label></p>
            <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-4 col-sm-12 form-group">
                      
                        <asp:TextBox ID="txtSubject"  CssClass="form-control" placeholder="Enter Perticular" runat="server"></asp:TextBox>
                    
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtroom"
                        ValidationGroup="l3"
                    Display="Dynamic"
                        ErrorMessage="Enter Subject / Issue"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="lbSaveSubject" ValidationGroup="l3" CssClass="btn btn-danger m-2"  runat="server" OnClick="lbSaveSubject_Click" OnClientClick="return confirm('Are You Sure?');">Save</asp:LinkButton>
                       <asp:Button ID="Button3" CssClass="btn  btn-primary" runat="server" Text="Reset" OnClick="Button3_Click" OnClientClick="return confirm('Are You Sure?');" />
                         </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-sm-12 p-2  table-responsive">

                        <asp:GridView ID="GridView3" 
                           CssClass="table table-bordered"
                            runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="subid" DataSourceID="GetSubjectTab" ForeColor="#333333" GridLines="None"  AllowPaging="True" AllowSorting="True" OnRowCommand="GridView3_RowCommand">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                         <asp:BoundField DataField="subject" HeaderText="Subject / Issues" SortExpression="subject" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" CommandName="Ed" CommandArgument='<%#Eval("subid")+":"+Eval("subject") %>' runat="server">Edit</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton5" CommandName="Del" OnClientClick="return confirm('Are you sure ?');"  CommandArgument='<%#Eval("subid") %>' runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="GetSubjectTab" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cls %>"
                             SelectCommand="SELECT * FROM [SubjectTab] ORDER BY subid"></asp:SqlDataSource>

                    </div>
                </div>
            </div>
         

        </asp:View>
          <asp:View ID="vwNotification" runat="server">
               <p class="h4 border-bottom text-danger"><asp:Label ID="Label3" runat="server" Text="Manage Notification"></asp:Label></p>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-2 col-sm-4 form-group">
                        <asp:HiddenField ID="hfnotificationid" Value="0" runat="server" />
                      <label>Email Notification (On/Off)</label>
                        <asp:DropDownList ID="ddlemailstatus" CssClass="form-control" runat="server">
                            <asp:ListItem Value="1">ON</asp:ListItem>
                             <asp:ListItem Value="0">OFF</asp:ListItem>
                        </asp:DropDownList>  
                        
                    </div>
                    <div class="col-lg-2 col-sm-4 form-group">
                        <label>SMS Notification (On/Off)</label>
                           <asp:DropDownList ID="ddlsms" CssClass="form-control" runat="server">
                            <asp:ListItem Value="1">ON</asp:ListItem>
                             <asp:ListItem Value="0">OFF</asp:ListItem>
                        </asp:DropDownList>  
                        
                     </div>
                    <div class="col-lg-2 col-sm-4 form-group">
                      
                       <br />
                        <asp:LinkButton ID="lbsmsemail" CssClass="btn btn-danger m-2"  runat="server" OnClick="lbsmsemail_Click">Save</asp:LinkButton>
                     <asp:Button ID="Button4" PostBackUrl="SettingPage.aspx" CssClass="btn  btn-primary" runat="server" Text="Reset" />   
                    </div>
                </div>
              
            </div>
         

        </asp:View>
           <asp:View ID="vwCategory" runat="server">
            
              <p class="h4 border-bottom text-danger"><asp:Label ID="Label4" runat="server" Text="Request Category"></asp:Label></p>
            <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-4 col-sm-12 form-group">
                        <asp:HiddenField ID="hfcatid" Value="0" runat="server" />
                        <asp:TextBox ID="txtCategory" CssClass="form-control" placeholder="Enter Request Category" runat="server"></asp:TextBox>
                    
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtCategory"
                        ValidationGroup="l1"
                    Display="Dynamic"
                        ErrorMessage="Enter Category Name"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="lbSaveCategory" ValidationGroup="l1" CssClass="btn btn-danger m-2"  runat="server" OnClick="lbSaveCategory_Click" OnClientClick="return confirm('Are You Sure?');">Save</asp:LinkButton>
                       <asp:Button ID="Button5" CssClass="btn  btn-primary" runat="server" Text="Reset" OnClick="Button5_Click" OnClientClick="return confirm('Are You Sure?');" />
                         </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-sm-12 p-2  table-responsive">

                        <asp:GridView ID="GVCategory" 
                           CssClass="table table-bordered"
                            runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Catid" DataSourceID="GetCategory" ForeColor="#333333" GridLines="None" OnRowCommand="GVCategory_RowCommand" AllowPaging="True" AllowSorting="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                         <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnCatEdit" CommandName="Ed" CommandArgument='<%#Eval("catid")+":"+Eval("category") %>' runat="server">Edit</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="BtnCatDelete" CommandName="Del" OnClientClick="return confirm('Are you sure ?');"  CommandArgument='<%#Eval("catid") %>' runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="GetCategory" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cls %>" 
                            SelectCommand="SELECT * FROM [categoryTab] ORDER BY [category] desc"></asp:SqlDataSource>

                    </div>
                </div>
            </div>
            

        </asp:View>
            <asp:View ID="vwDesignation" runat="server">
            
              <p class="h4 border-bottom text-danger"><asp:Label ID="Label5" runat="server" Text="Designation"></asp:Label></p>
            <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-4 col-sm-12 form-group">
                      
                        <asp:TextBox ID="txtDesignation" CssClass="form-control" placeholder="Enter Designation" runat="server"></asp:TextBox>
                    
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtDesignation"
                        ValidationGroup="l1"
                    Display="Dynamic"
                        ErrorMessage="Enter Designation"></asp:RequiredFieldValidator>
                        <asp:LinkButton ID="LinkButton3" ValidationGroup="l1" CssClass="btn btn-danger m-2"  runat="server" OnClick="lbSaveDesignation_Click" OnClientClick="return confirm('Are You Sure?');">Save</asp:LinkButton>
                       <asp:Button ID="Button6" CssClass="btn  btn-primary" runat="server" Text="Reset"  OnClick="Button6_Click" OnClientClick="return confirm('Are You Sure?');" />
                         </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-sm-12 p-2  table-responsive">

                        <asp:GridView ID="GVDesignation" 
                           CssClass="table table-bordered"
                            runat="server" AutoGenerateColumns="False" CellPadding="4"  DataSourceID="GetDesignation" ForeColor="#333333" GridLines="None" OnRowCommand="GVDesignation_RowCommand" AllowPaging="True" AllowSorting="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                         <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation" />
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnDesEdit" CommandName="Ed" CommandArgument='<%#Eval("designation")+":"+Eval("designation") %>' runat="server">Edit</asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="BtnDesDelete" CommandName="Del" OnClientClick="return confirm('Are you sure ?');"  CommandArgument='<%#Eval("designation") %>' runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="GetDesignation" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cls %>" 
                            SelectCommand="SELECT * FROM [DesignationTab] ORDER BY [Designation] asc"></asp:SqlDataSource>

                    </div>
                </div>
            </div>
            

        </asp:View>
    </asp:MultiView>
</asp:Content>

