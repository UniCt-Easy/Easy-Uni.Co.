<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="ReportParameter_default.aspx.cs" Inherits="ReportParameter_default" Title="Stampa report" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">

    <center>
<br />
<HelpWeb:hwLabel runat="server" ID="reporttitle" Font-Size="Large"></HelpWeb:hwLabel>
<br />
<br />
<fieldset style="text-align: left; width: 90%; background-color: #f6f7f9;">
<legend>Parametri Stampa</legend>
    <table border="0" cellpadding="0" cellspacing="0">
    <tr valign="top">
        <td width="95%">
            <center>
            <asp:PlaceHolder runat="server" ID="ParamsForm">
            </asp:PlaceHolder>
            </center>
            &nbsp;<br />
            <br />
            
        </td>
    </tr>
    <tr>
        <td width="95%">
            <center>
            <HelpWeb:hwButton style="width: 150px;text-align:center;height: 35px" runat="server" ID="HwButton0" Text="Visualizza Report" class="btn btn-primary" Tag="stampa" />
            <table style="opacity:0">
            <tr>
            <td width="85%">
            <asp:Label style="FONT-SIZE: 12px; FONT-FAMILY: Microsoft Sans Serif, Arial" id="Label2" runat="server" Width="392px">
            Per visualizzare il report è necessario avere acrobat reader installato. Se lo si desidera, è possibile scaricarlo cliccando il bottone giallo a destra.</asp:Label>
            </td>
            </tr>
            </table>
            </center>
        </td>
    </tr>
    
    </table>
</fieldset>
</center>
</asp:Content>
