<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DigiOz MySQL DLL Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Select City" Width="105px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="115px">
            <asp:ListItem>Seattle</asp:ListItem>
            <asp:ListItem>London</asp:ListItem>
            <asp:ListItem>ALL</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <br />
        <asp:Label ID="lblOut" runat="server" Height="213px" Width="419px"></asp:Label></div>
    </form>
</body>
</html>
