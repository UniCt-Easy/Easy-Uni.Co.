<%@ Page Language="C#" AutoEventWireup="true" CodeFile="expNextFm.aspx.cs" Inherits="expNextFm" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>NEXT.FM Gestione patrimoniale</title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="datapage">
            <h1>Esportazione dati patrimoniali</h1>
            &nbsp;
        <div class="dataform">
            <div class="dataline">
                <asp:Label ID="Label2" runat="server" Text="RFID" AssociatedControlID="RFID"></asp:Label>
                &nbsp;<asp:TextBox ID="RFID" runat="server"></asp:TextBox>
                &nbsp;(all ritorna tutti)</div>
        </div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Richiedi dati" />
        
        <div id="mydata" class="datatable" runat="server">
        </div>
    </form>
</body>
</html>
