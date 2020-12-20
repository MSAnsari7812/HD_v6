<%@ Page Title="" Language="C#" MasterPageFile="~/Engineer/EngineerMaster.master" AutoEventWireup="true" CodeFile="AssignRequests.aspx.cs" Inherits="Engineer_ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
                   <p class="h4 border-bottom">Engineer Assigned Request   
                       <asp:HyperLink ID="HyperLink1" CssClass="float-right" NavigateUrl="~/Engineer/Dashboard.aspx" runat="server">Home</asp:HyperLink></p>

        <div class="row">
            <div class="col-lg-2">
                <asp:linkbutton ID="lbView" runat="server" CSSClass="btn btn-secondary" OnClick="lbView_Click">View Request</asp:linkbutton>
            </div>
           
        </div>
        <asp:multiview ID="MV1" runat="server">
            <asp:View runat="server" ID="v1"> <div class="row">
            <div class="col-lg-12 table-responsive-lg table-responsive-sm p-2">
                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnDataBound="GridView1_DataBound">
                    <Columns>
                       <%-- <asp:BoundField DataField="ReqID" HeaderText="Req ID" ReadOnly="True" SortExpression="ReqID" />--%>
                        <asp:BoundField DataField="requestdate" HeaderText="Date" />
                         <asp:BoundField DataField="ReqID" HeaderText="Req. ID" />
                        <asp:BoundField DataField="RequestCategory" HeaderText="Category" />
                        <asp:BoundField DataField="RequestSubject" HeaderText="Subject / Issue" />
                        <asp:BoundField DataField="RequestDescription" HeaderText="Description" />
                        <asp:BoundField DataField="UserRemarks" HeaderText="User Remarks" />
                        <asp:BoundField DataField="CMSRemarks" HeaderText="CMS Remarks" />
                        <asp:BoundField DataField="Status" HeaderText="Status" >
                        <ItemStyle Font-Bold="True" VerticalAlign="Middle" HorizontalAlign="Center" />
                      
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger"
                                     CommandName="ED"
                                    CommandArgument='<%#String.Format("{0}:{1}",Eval("cid"),Eval("reqid")) %>'
                                    
                                     runat="server">Update Status</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
            </div>
        </div></asp:View>
             <asp:View runat="server" ID="v2">
                     <div class="row">
        <div class="col-lg-12 col-sm-12 my-auto">
            <div class="card card-block w-50 mx-auto p-5">
                <div class="form-inline">
                    <asp:HiddenField ID="hfcid" Value="0" runat="server" />
            <span>Request ID :</span> <asp:Label ID="lblRequestID" runat="server" CssClass="col-form-label-lg form-control ml-3" Text="0"></asp:Label><br />
                </div>
            <label>Comments</label>
            <asp:TextBox ID="txtComments" CssClass="form-control" TextMode="MultiLine" runat="server">

            </asp:TextBox>
                <br />
               <label>Status</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                    <asp:ListItem Selected="True" Value="N/A">Select Status</asp:ListItem>
                    <asp:ListItem>Open</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Closed</asp:ListItem>
                </asp:DropDownList>
            <br />

            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" OnClick="LinkButton1_Click">Submit</asp:LinkButton>
        </div>
</div>
             </div>
             </asp:View>
        </asp:multiview>
     
       
    </div>
    <script type="text/javascript">
                $(document).ready(function () {
                    $("#<%=GridView1.ClientID%>").prepend($("<thead></thead>").append($(this).find("tr:first")))
                    $("#<%=GridView1.ClientID%>").DataTable({
                        dom: 'Bfrtip',
                        lengthMenu: [
                   [10, 25, 50, -1],
                   ['10 rows', '25 rows', '50 rows', 'Show all']
                        ],
                        buttons: [
                           'pageLength', 'colvis', 'copy', 'csv', 'excel', 'pdf', 'print'
                        ]


                    });
                });
       </script>
</asp:Content>

