<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apregistry_service.aspx.cs" Inherits="EasyWebReport.apregistry_service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta name="robots" content="noindex">
    <title>Incarichi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="datapage">
        <h1>Esportazione incarichi</h1>
        &nbsp;
        <div class="dataform">
        <div class="dataline">
        <asp:Label ID="Label2" runat="server" Text="Anno" AssociatedControlID="anno"></asp:Label>
        <asp:TextBox ID="anno" runat="server"></asp:TextBox></div>
        </div>
        <div class="dataform">
        <asp:Label ID="Label1" runat="server" Text="Tipologia incarichi"></asp:Label>
        <asp:RadioButtonList ID="rdbTipo" runat="server">
            <asp:ListItem Value="C">Consulenti</asp:ListItem>
            <asp:ListItem Value="D">Dipendenti</asp:ListItem>
        </asp:RadioButtonList>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Richiedi informazioni" />
        </div>
        <div id="mydata" class="datatable" runat="server">
        </div>
    </form>
</body>
</html>
