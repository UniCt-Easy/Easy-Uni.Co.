
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rilevazionianac_service.aspx.cs" Inherits="EasyWebReport.rilevazionianac_service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ANAC</title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="datapage">
            <h1>Esportazione Rilevazioni ANAC</h1>
            &nbsp;
        <div class="dataform">
            <div class="dataline">
                <asp:Label ID="Label2" runat="server" Text="Anno" AssociatedControlID="anno"></asp:Label>
                <asp:TextBox ID="anno" runat="server"></asp:TextBox>
            </div>
            <asp:Label ID="Label3" runat="server" Text="Codice CIG(facoltativo)" AssociatedControlID="cig"></asp:Label>
            <asp:TextBox ID="cig" runat="server"></asp:TextBox>
        </div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Richiedi informazioni" />
        
        <div id="mydata" class="datatable" runat="server">
        </div>
    </form>
</body>
</html>
