<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="NewRequest.aspx.cs" Inherits="UserRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
  
    <asp:updatepanel runat="server">
        <ContentTemplate>
       
       <div class="container-fluid">
            <h3 class="text-center border-bottom">New Request</h3>   
         
            <div class="row">
              
                 <div class="col-lg-4">
                     <div class="container-fluid border">
                        
        
                         <div class="row">
                <div class="col-lg-12 form-group">
                    <label class="col-form-label-lg">Current Date (mm/dd/yyyy)</label>
                           <asp:TextBox ID="txtcdate" CssClass="form-control" 
                              
                                runat="server" Enabled="False"></asp:TextBox>
         
                   
                </div>

              
            </div>
      
       
                         <div class="row">
                <div class="col-lg-12 form-group">
                    <label class="col-form-label-lg">Complaint Category</label>
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
                        ErrorMessage="Select Complaint Category"></asp:RequiredFieldValidator>
                </div>

              
            </div>
                             <div class="row">
                <div class="col-lg-12 form-group">
                    <label class="col-form-label-lg">Complaint Title / Subject</label>
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
                </div>

              
            </div>
                     
                         <div class="row">
                <div class="col-lg-12 form-group">
                    <label class="col-form-label-lg">Complain Description</label>
                    <asp:TextBox ID="txtComplaint" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        SetFocusOnError="true"
                         ForeColor="Red"
                        ControlToValidate="txtComplaint"
                        ValidationGroup="l1"
                    Display="Dynamic"
                        ErrorMessage="Enter Valid Complaint"></asp:RequiredFieldValidator>
                    </div>

              
            </div>
                                        <div class="row">
                <div class="col-lg-12 form-group">
                    <label class="col-form-label-lg">Any Remark</label>
                    <asp:TextBox ID="txtremark" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
             
                    </div>

              
            </div>
        
                            <div class="row">
                <div class="col-lg-12 form-group">
                      <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <img src="../Images/progress3.gif" style="height:60px;width:auto" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <br />
                    <asp:LinkButton ID="lbSubmit" ValidationGroup="l1" CssClass="btn btn-group-lg btn-primary w-100" runat="server" OnClick="lbSubmit_Click">Register</asp:LinkButton>
                  
                </div>

              
            </div>


        </div>    
                </div>
                 <div class="col-lg-4">

                </div>
            </div>
        
           
        </div>
      </ContentTemplate>
    </asp:updatepanel>     
</asp:Content>

