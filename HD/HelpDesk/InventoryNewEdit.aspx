<%@ Page Title="" Language="C#" MasterPageFile="~/HelpDesk/Helpdesk.master" AutoEventWireup="true" CodeFile="InventoryNewEdit.aspx.cs" Inherits="HelpDesk_AddEditInventory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <div class="container-fluid">
        <div class="row">
        <div class="col-lg-12 h3 text-center">
            Inventory Management
            <div class="float-left">

            
              <asp:LinkButton ID="btnnew" CssClass="btn btn-info " runat="server" OnClick="btnnew_Click">ADD New</asp:LinkButton>
              <asp:LinkButton ID="btview" CssClass="btn btn-secondary" runat="server" OnClick="btview_Click" >View</asp:LinkButton>
           
            </div>
        </div>
    </div>
        <br />
        <br />
        <br />
  
              <div class="row">
            <div class="col-lg-2">
                <label>Building Name</label>
                <asp:DropDownList ID="ddlBuildingName" CssClass="form-control"
                    DataTextField="buildingname" DataValueField="buildingname"
                     runat="server">
                    <asp:ListItem>Select Building</asp:ListItem>
                </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="ddlBuildingName"
                        ValidationGroup="l1"
                         InitialValue="Select Building"
                          Display="Dynamic"
                        ErrorMessage="Select Building Name from list."></asp:RequiredFieldValidator>
            </div>
             <div class="col-lg-2">
                  <label>Room</label>
                <asp:DropDownList ID="ddlRoomno" CssClass="form-control"
                    DataTextField="Room" DataValueField="Room"
                     runat="server">
                    <asp:ListItem>Select Room</asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="ddlRoomno"
                        ValidationGroup="l1"
                         InitialValue="Select Room"
                          Display="Dynamic"
                        ErrorMessage="Select Room no from list."></asp:RequiredFieldValidator>
  
             </div>
             <div class="col-lg-2">
                 <label>Select Product</label>
                   <asp:DropDownList ID="ddlProductName" CssClass="form-control"
                       
                     
                         runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                 
                    </asp:DropDownList>     
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="ddlProductName"
                        ValidationGroup="l1"
                         InitialValue="Select Product"
                          Display="Dynamic"
                        ErrorMessage="Select Product Name from list."></asp:RequiredFieldValidator>
             </div>
             <div class="col-lg-2"></div>
             <div class="col-lg-2"></div>
             <div class="col-lg-2"></div>
        </div>
        
         <div class="row">
            <div class="col-lg-2">
                <label>Model</label>
                <asp:TextBox ID="txtPCModel" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="col-lg-2">
                   <label>Serial No</label>
                <asp:TextBox ID="txtPCSerialNo" CssClass="form-control" runat="server"></asp:TextBox>
        
             </div>
             <div class="col-lg-2">
                    <label>Current Status</label>
                <asp:TextBox ID="txtPCCurrentStatus" CssClass="form-control" runat="server"></asp:TextBox>
        
             </div>
             <div class="col-lg-2">
                   <label>Problem</label>
                <asp:TextBox ID="txtPCProblem" CssClass="form-control" runat="server"></asp:TextBox>
        

             </div>
           
        </div>
        <div class="row">
              <div class="col-lg-1">
                 <br />
                 <asp:HiddenField runat="server" value="0" ID="hdInvID"></asp:HiddenField>
                 <asp:LinkButton ID="lbUpdate" ValidationGroup="l1" runat="server" CssClass="btn btn-success" OnClick="lbUpdate_Click">Save</asp:LinkButton>
            </div>
                   <div class="col-lg-1">
                       <br />
                   <asp:LinkButton ID="LinkButton1" ValidationGroup="l1"  runat="server" CssClass="btn btn-danger" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                  <asp:ConfirmButtonExtender ID="LinkButton1_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure?" Enabled="True" TargetControlID="LinkButton1">
                 </asp:ConfirmButtonExtender>
             </div>
        </div>

     

    </div>
</asp:Content>

