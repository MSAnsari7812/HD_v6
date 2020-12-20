<%@ Page Title="" Language="C#" MasterPageFile="~/Helpdesk/Helpdesk.master" AutoEventWireup="true" CodeFile="ViewRequest.aspx.cs" Inherits="UserViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContentPlaceHolder" Runat="Server">
    <style>
       th,td{
            text-align:center;

        }
        .img-fluid {
            margin-top: 20px;
        }
    </style>

    <div class="row border border-dark">
        <div class="col-lg-4 form-group">
                  <label>From Date</label>
            <asp:TextBox ID="txtfromdatedate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
        </div>
         <div class="col-lg-4 form-group">
            <label>To Date</label>
            <asp:TextBox ID="txttodate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
        </div>
         <div class="col-lg-1 pt-3 float-left">
            
             <asp:ImageButton ID="ImageButton1" runat="server"
                  ImageAlign="Middle" ImageUrl="~/Images/search.png" Width="60" style="margin-top:0px;"
                 CssClass="img-fluid"
                  OnClick="ImageButton1_Click" />
        </div>
         <div class="col-lg-1 pt-3 float-left">
                       <asp:ImageButton ID="ImageButton2" runat="server" style="margin-top:10px;"
                  ImageAlign="Middle" ImageUrl="~/Images/Excel-icon.png" Width="45px"
                 CssClass="img-fluid" Height="39px" OnClick="ImageButton2_Click"
                  />
        </div>
    </div>

  


    <p class="h4 border-bottom">Request</p>
  <div class="table-responsive">
     
        
        <asp:ListView ID="ListView1" runat="server" OnDataBound="ListView1_DataBound">
            <ItemTemplate>
                <div class="d-block badge-light p-2 mb-3 border border-dark font-weight-bold rounded">
                  <div class="alert alert-heading alert-info"> <asp:HiddenField ID="hfassignstatus" value='<%#Eval("AssignStatus") %>' runat="server" />
                    <asp:HiddenField ID="hfenggname" value='<%#Eval("EnggName") %>' runat="server" />
               <p>Req. ID : <asp:Label ID="Label1" runat="server"  Text='<%#Eval("reqid") %>'></asp:Label>
                      <asp:HyperLink ID="HyperLink1" CssClass=" text-left text-nowrap" NavigateUrl='<%# string.Format("EditRequest.aspx?cid={0}&reqid={1}",
                    HttpUtility.UrlEncode(Eval("cid").ToString()), HttpUtility.UrlEncode(Eval("reqid").ToString())) %>' runat="server">
                           <img src="../Images/editicon2.jpg" style="height:20px;width:auto" />
                       </asp:HyperLink>
                  <asp:Label ID="Label7" ClientIDMode="Static"   runat="server"  Text='<%#Eval("Status") %>'></asp:Label>
                   
                    <asp:Label ID="Label2" CssClass="float-right" runat="server" Text='<%#Eval("requestdate") %>'></asp:Label>
               </p></div> 
      <hr />
                    <table id="hdtab" class="table table-bordered table-sm">
                        <thead>
                               <th>Category</th>
                            <th>Subject</th>
                             <th>Description</th>
                             <th>Hepl Desk Remarks</th>
                            
                        </thead>
                        <tbody>
                        <tr>
                              <td>
<asp:Label ID="Label6" runat="server"
                  
                    Text='<%#Eval("requestcategory") %>'></asp:Label>
                            </td>
                            <td>
<asp:Label ID="Label3" runat="server"
                  
                    Text='<%#Eval("requestsubject") %>'></asp:Label>
                            </td>
                            <td>
<asp:Label ID="Label4" runat="server" Text='<%#Eval("requestdescription") %>'></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="Label5" runat="server" Text='<%#Eval("cmsremarks") %>'></asp:Label>
                            </td>
                        </tr></tbody>
                    </table>



<div class="alert alert-secondary">



            <div class="row">
        <div class="col-6">    
              <asp:Label ID="lblassignengg" runat="server" Text="Not Assign"></asp:Label> 
                         
                      <asp:HyperLink ID="hlassignengg" CssClass="text-left btn btn-sm btn-success text-nowrap" NavigateUrl='<%# string.Format("AssignToEngg.aspx?cid={0}&reqid={1}",
                    HttpUtility.UrlEncode(Eval("cid").ToString()), HttpUtility.UrlEncode(Eval("reqid").ToString())) %>' runat="server">Click To Assign</asp:HyperLink>
           
           </div>
                <div class="col-4">

                </div>
                 <div class="col-2">
                    
                      <asp:HyperLink ID="hlnotify" CssClass="btn btn-success btn-sm" style="float:right" NavigateUrl='<%# string.Format("Notification.aspx?cid={0}&reqid={1}",
                    HttpUtility.UrlEncode(Eval("cid").ToString()), HttpUtility.UrlEncode(Eval("reqid").ToString())) %>' runat="server">Send Notification</asp:HyperLink>
           </div>
          </div>
          </div>
            </div>
                    </ItemTemplate>
            <EmptyDataTemplate>
                <div class="alert alert-info text-center">No Request Found..</div>
            </EmptyDataTemplate>
        </asp:ListView>

    </div>

    
      
  
</asp:Content>

