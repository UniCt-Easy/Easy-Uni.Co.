<%@ Page Language="C#" AutoEventWireup="true" CodeFile="expSiopeTrasparenza.aspx.cs" Inherits="expSiopeTrasparenza" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SIOPE Pagamenti</title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="datapage">
            <h1>Esportazione pagamenti SIOPE</h1>
            &nbsp;
        <div class="dataform">
            <div class="dataline">
                <asp:Label ID="Label2" runat="server" Text="Anno" AssociatedControlID="anno"></asp:Label>
                <asp:TextBox ID="anno" runat="server"></asp:TextBox>
            </div>
        </div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Richiedi informazioni" />
        
        <div id="mydata" class="datatable" runat="server">
        </div>
    </form>
</body>
</html>
