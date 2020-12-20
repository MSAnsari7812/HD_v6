<%@ Page Title="" Language="C#" MasterPageFile="~/HelpDesk/Helpdesk.master" AutoEventWireup="true" CodeFile="InventoryView.aspx.cs" Inherits="HelpDesk_InventoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    
<div class="container-fluid">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="col-12">
            <a ID="lbNew" class="btn btn-success m-1 float-left" href="AddEditInventory.aspx" >ADD Inventory</a>
            <asp:ImageButton ID="InvExport" runat="server" Height="33px" ImageUrl="~/Images/Excel-icon.png" OnClick="InvExport_Click" style="margin-left: 25px;margin-top:10px" Width="36px" />
        </div>
    </div>
   
    <div class="row">
        <div class="col-lg-12 ">
            <div class="table-responsive-lg table-responsive">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <center>
                                    <img src="../Images/progress3.gif" style="height:auto;width:100px" />
                                </center>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                 
            <asp:GridView ID="GridView1" CssClass="table table-bordered" ClientIDMode="Static"  runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                       <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" Height="30" Width="30"
                                CommandArgument='<%# Eval("invid") %>' CommandName="ED"
                                 ImageUrl="../Images/editicon.jpg" runat="server" />
                        </ItemTemplate>

                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="building" SortExpression="building" HeaderText="Building"  />
                     <asp:BoundField DataField="Room" SortExpression="Room" HeaderText="Room" />
                     <asp:BoundField DataField="username" SortExpression="username" HeaderText="User Name" />

<asp:BoundField DataField="pcmodel" SortExpression="pcmodel" HeaderText="PC Model" />
<asp:BoundField DataField="pcserialno" SortExpression="pcserialno" HeaderText="PC Serial No" />
<asp:BoundField DataField="pcstatus" SortExpression="pcstatus" HeaderText="PC Status" />
<asp:BoundField DataField="pcproblem" SortExpression="pcproblem" HeaderText="PC Problem" />



                    <asp:BoundField DataField="monitormodel" SortExpression="monitormodel" HeaderText="PC Model" />
<asp:BoundField DataField="monitorserialno" SortExpression="monitorserialno" HeaderText="PC Serial No" />
<asp:BoundField DataField="monitorstatus" SortExpression="monitorstatus" HeaderText="PC Status" />
<asp:BoundField DataField="monitorproblem" SortExpression="monitorproblem" HeaderText="PC Problem" />

   <asp:BoundField DataField="keyboardmodel" SortExpression="keyboardmodel" HeaderText="Keyboard Model" />
<asp:BoundField DataField="keyboardserialno" SortExpression="keyboardserialno" HeaderText="Keyboard Serial No" />
<asp:BoundField DataField="keyboardstatus" SortExpression="keyboardstatus" HeaderText="Keyboard Status" />
<asp:BoundField DataField="keyboardproblem" SortExpression="keyboardproblem" HeaderText="Keyboard Problem" />

<asp:BoundField DataField="mousemodel" SortExpression="mousemodel" HeaderText="Mouse Model" />
<asp:BoundField DataField="mouseserialno" SortExpression="mouseserialno" HeaderText="Mouse Serial No" />
<asp:BoundField DataField="mousestatus" SortExpression="mousestatus" HeaderText="Mouse Status" />
<asp:BoundField DataField="mouseproblem" SortExpression="mouseproblem" HeaderText="Mouse Problem" />

                
                 
                    <asp:BoundField DataField="upsmodel" SortExpression="upsmodel" HeaderText="UPS Model" />
<asp:BoundField DataField="upsserialno" SortExpression="upsserialno" HeaderText="UPS Serial No" />
<asp:BoundField DataField="upsstatus" SortExpression="upsstatus" HeaderText="UPS Status" />
<asp:BoundField DataField="upsproblem" SortExpression="upsproblem" HeaderText="UPS Problem" />

                    <asp:BoundField DataField="printermodel" SortExpression="printermodel" HeaderText="Printer Model" />
<asp:BoundField DataField="printerserialno" SortExpression="printerserialno" HeaderText="Printer Serial No" />
<asp:BoundField DataField="printerstatus" SortExpression="printerstatus" HeaderText="Printer Status" />
<asp:BoundField DataField="printerproblem" SortExpression="printerproblem" HeaderText="Printer Problem" />

                    <asp:BoundField DataField="scannermodel" SortExpression="scannermodel" HeaderText="Scanner Model" />
<asp:BoundField DataField="scannerserialno" SortExpression="scannerserialno" HeaderText="Scanner Serial No" />
<asp:BoundField DataField="scannerstatus" SortExpression="scannerstatus" HeaderText="Scanner Status" />
<asp:BoundField DataField="scannerproblem" SortExpression="scannerproblem" HeaderText="Scanner Problem" />

<asp:BoundField DataField="laptopmodel" SortExpression="laptopmodel" HeaderText="Laptop Model" />
<asp:BoundField DataField="laptopserialno" SortExpression="laptopserialno" HeaderText="Laptop Serial No" />
<asp:BoundField DataField="laptopstatus" SortExpression="laptopstatus" HeaderText="Laptop Status" />
<asp:BoundField DataField="laptopproblem" SortExpression="laptopproblem" HeaderText="Laptop Problem" />

                    <asp:BoundField DataField="projectormodel" SortExpression="projectormodel" HeaderText="Projector Model" />
<asp:BoundField DataField="projectorserialno" SortExpression="projectorserialno" HeaderText="Projector Serial No" />
<asp:BoundField DataField="projectorstatus" SortExpression="projectorstatus" HeaderText="Projector Status" />
<asp:BoundField DataField="projectorproblem" SortExpression="projectorproblem" HeaderText="Projector Problem" />

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
                           </ContentTemplate>
                  
                    <triggers>
                        <asp:PostBackTrigger ControlID="InvExport" />
                    </triggers>
                  
                </asp:UpdatePanel>
                </div>
        </div>
    </div>
     
       
</div>
     <script>
     $(document).ready(function () {
                    $("#<%=GridView1.ClientID%>").prepend($("<thead></thead>").append($(this).find("tr:first")))
                    $("#<%=GridView1.ClientID%>").DataTable({
                        dom: 'Bfrtip',
                        lengthMenu: [
                   [5, 25, 50, -1],
                   ['5 rows', '25 rows', '50 rows', 'Show all']
                        ],
                        buttons: [
                           'pageLength', 'excel', 'pdf', 'print'
                        ]


                    });
                });
</script>
</asp:Content>

