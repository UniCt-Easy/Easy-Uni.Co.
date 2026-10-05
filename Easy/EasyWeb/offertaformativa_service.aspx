<%@ Page Language="C#" AutoEventWireup="true" CodeFile="offertaformativa_service.aspx.cs" Inherits="EasyWebReport.offertaformativa_service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://cdn.datatables.net/2.3.4/css/dataTables.dataTables.min.css" rel="stylesheet" />
    <title>Offerta Formativa</title>
</head>
<body>
    <h1>Offerta Formativa</h1>
    <form id="parameters" runat="server">
        <div class="datapage">
            &nbsp;
            <div class="dataform">
                <div class="dataline">
                    <asp:Label ID="Label2" runat="server" Text="Anno" AssociatedControlID="aa"></asp:Label>
                    <asp:TextBox ID="aa" runat="server"></asp:TextBox>
                </div>
<%--                <asp:Label ID="Label3" runat="server" Text="Dipartimento (facoltativo)" AssociatedControlID="dep"></asp:Label>
                <asp:TextBox ID="dep" runat="server"></asp:TextBox>--%>
            </div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Aggiorna" />
    </form>
    <div id="data" class="datatable" runat="server"></div>
</body>
</html>

<script type="text/javascript">
    function toggleDetail(id, rowElement) {
        var el = document.getElementById(id);
        var isVisible = el.style.display === "block";

        el.style.display = isVisible ? "none" : "block";

        if (isVisible) {
            rowElement.classList.remove("table-primary");
        } else {
            rowElement.classList.add("table-primary");
        }
    }
</script>

