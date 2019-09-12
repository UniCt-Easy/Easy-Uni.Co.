<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowProcedureMessageCollection.aspx.cs" Inherits="ShowProcedureMessageCollection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 301px">
    
        <asp:Table ID="Table3" runat="server" Height="4px" Width="697px">
            <asp:TableRow runat="server" Height="2px">
                <asp:TableCell runat="server" BackColor="#FF6600" Height="2px"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
        <asp:Label ID="lblTitolo" runat="server" Text="EasyProcedureMessage" 
            Font-Size="X-Large" ForeColor="#000099"></asp:Label>
        <asp:Table ID="Table2" runat="server" Height="4px" Width="697px">
            <asp:TableRow runat="server" Height="2px">
                <asp:TableCell runat="server" BackColor="#FF6600" Height="2px"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="Table1" runat="server" Height="60px" Width="820px">
        </asp:Table>
    
    </div>
    </form>
</body>
</html>
