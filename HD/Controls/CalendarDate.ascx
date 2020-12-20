<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarDate.ascx.cs" Inherits="CalenderWebControl" %>
   <style>
       .TimeStyle
       {
        font:800 14px verdana;
        margin:3px;
       }
       .TimeStyle span{
           color:orangered;
       }
    
   </style>
    <div class="form-inline" style="position:relative; top: 0px; left: 0px; height: 261px; width: 347px;" >
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="25px" ReadOnly="True"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" 
             AlternateText="Cal" runat="server" ImageUrl="CalenderIcon.png" OnClick="ImageButton1_Click" Width="33px" Height="20px" />
       <br />

          <div class="cal">
        <asp:Calendar ID="Calendar1" Visible="False" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="336px" BorderWidth="1px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
            <TodayDayStyle BackColor="#CCCCCC" BorderColor="#99FF66" />
        </asp:Calendar></div>
      
    </div>
         
           