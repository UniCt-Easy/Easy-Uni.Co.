<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="ExportParameter_Default.aspx.cs" Inherits="ExportParameter_Default" Title="Esportazione" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
<center>
<br />
<HelpWeb:hwLabel runat="server" ID="exporttitle" Font-Size="Large"></HelpWeb:hwLabel>
<br />
<br />
<fieldset style="text-align: left; width: 90%; background-color: #eaeaea;">
<legend>Parametri Esportazione</legend>
    <br />
<center>
    <table width="95%" border="0" cellpadding="0" cellspacing="0">
    <tr valign="top">
        <td style="width: 95%">
            <center>
            <asp:PlaceHolder runat="server" ID="ParamsForm">
            </asp:PlaceHolder>
            </center>
            &nbsp;<br />
            <br />
        </td>
    </tr>
    <tr>
        <td style="width: 95%">
            <center>
            <HelpWeb:hwButton style="width: 150px;text-align:center;height: 35px" runat="server" ID="HwButton0" Text="Esporta" Tag="esporta" />
            <br />
            <br />
            </center>
        </td>
    </tr>
    
    </table>
</center>    
</fieldset>
</center>

</asp:Content>
