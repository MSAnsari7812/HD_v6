<%@ Page Title="" Language="C#" MasterPageFile="~/Helpdesk/Helpdesk.master" AutoEventWireup="true" CodeFile="EditRequest.aspx.cs" Inherits="Admin_AssignToEngg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
      <style>
       .table  td{
             text-align:left;
         }
      </style>
        <asp:HiddenField ID="hfcid" Value="0" runat="server" />
          <p class="h4 border-bottom">Modify Request 
              </p>
 
          <div class="row">
              <div class="col-lg-4 text-left">
                
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
                        <td><b>Request Category</b></td>
                        <td>
                            <asp:Label ID="lblReqCategory" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td><b>Request Subject</b></td>
                        <td>
                            <asp:Label ID="lblReqSubject" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="bg-info font-weight-bold font-italic">
                            Select New Category and Subject
                        </td>
                    </tr>
                     <tr>
                        <td>   <label class="col-form-label-lg">Complaint Category</label></td>
                        <td>
                             
                    <asp:DropDownList ID="ddlccategory" AppendDataBoundItems="true"
                         DataTextField="category" DataValueField="catid"
                         CssClass="form-control"
                        runat="server">
                        <asp:ListItem Value="0">Select Category</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="ddlccategory"
                        ValidationGroup="l1"
                         InitialValue="0"
                          Display="Dynamic"
                        ErrorMessage="Select Complaint Category"></asp:RequiredFieldValidator></td>
                    </tr>
                     <tr>
                        <td> <label class="col-form-label-lg">Complaint Title / Subject</label></td>
                        <td>
                                  <asp:DropDownList ID="ddlsubject" AppendDataBoundItems="true" 
                        DataTextField="subject" DataValueField="subid"
                         CssClass="form-control"
                        runat="server">
                        <asp:ListItem Value="0">Select Subject</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="ddlccategory"
                        ValidationGroup="l1"
                         InitialValue="0"
                          Display="Dynamic"
                        ErrorMessage="Select Subject"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:linkbutton class="btn btn-danger" ValidationGroup="l1" runat="server" ID="btnUpdate" OnClick="Unnamed1_Click" CssClass="btn btn-primary">Submit</asp:linkbutton>
          
                        </td>
                    </tr>
                </table>
              </div>
              </div>

    

    </div>
</asp:Content>

