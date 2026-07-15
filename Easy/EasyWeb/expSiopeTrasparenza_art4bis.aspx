<%@ Page Language="C#" AutoEventWireup="true" CodeFile="expSiopeTrasparenza_art4bis.aspx.cs" Inherits="expSiopeTrasparenza_art4bis" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SIOPE Pagamenti</title>
<style>
        body {
            font-family: "Segoe UI", Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 20px;
        }
        .datapage h1 {
            text-align: center;
            color: #003366;
            margin-bottom: 20px;
        }
        .dataform {
            margin-bottom: 15px;
        }
        .dataline {
            margin: 8px 0;
        }
        .dataline label {
            display: inline-block;
            width: 80px;
            font-weight: bold;
        }
        .datatable {
            margin-top: 30px;
        }
        table.table {
            width: 100%;
            border-collapse: collapse;
            background: #fff;
            font-size: 14px;
        }
        table.table th, table.table td {
            border: 1px solid #ddd;
            padding: 8px 12px;
        }
        table.table th {
            background: #e6f0ff;
            text-align: center;
        }
        table.table tr:nth-child(even) td {
            background: #f9f9f9;
        }
        table.table tr:hover td {
            background: #f1f7ff;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="datapage">
            <h1>Esportazione pagamenti SIOPE(art. 4-bis)</h1>
            &nbsp;
        <div class="dataform">
            <div class="dataline">
                <asp:Label ID="Label2" runat="server" Text="Anno" AssociatedControlID="anno"></asp:Label>
                <asp:TextBox ID="anno" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="dataform">
                <asp:Label ID="Label1" runat="server" Text="Trimestre di Riferimento     " AssociatedControlID="ddlTrimestre"  Font-Bold="true"></asp:Label>
                <asp:DropDownList ID="ddlTrimestre" runat="server">
                    <asp:ListItem Value="">-- seleziona o vedi tutto --</asp:ListItem>
                      <asp:ListItem Value="1">I trimestre (Gen–Mar)</asp:ListItem>
                      <asp:ListItem Value="2">II trimestre (Apr–Giu)</asp:ListItem>
                      <asp:ListItem Value="3">III trimestre (Lug–Set)</asp:ListItem>
                      <asp:ListItem Value="4">IV trimestre (Ott–Dic)</asp:ListItem>
                </asp:DropDownList>
        </div>

        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Richiedi informazioni" />
        
        <div id="mydata" class="datatable" runat="server">
        </div>
    </form>
</body>
</html>

