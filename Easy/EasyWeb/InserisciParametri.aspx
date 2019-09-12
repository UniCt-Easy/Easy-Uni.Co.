<%@ page language="c#" MasterPageFile="MetaMaster.master" inherits="EasyWebReport.InserisciParametri" CodeFile ="~/InserisciParametri.aspx.cs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CHP_PC" runat="Server">
<center>
        <asp:Label ID="TitoloStampa" runat="server" style="font-family: Microsoft Sans Serif, Arial; font-size: 24px; font-weight: bold;"></asp:Label>&nbsp;</center>
    <center>
        <br />

        <asp:label id="Label1" style="font-family: Microsoft Sans Serif, Arial; font-size: 18px; font-weight: bold;" runat="server" Width="385px" Font-Size="Large">Inserire i parametri</asp:label><br />
    <br />
        <asp:table style="width: 900px; color: #333333; font-family: Microsoft Sans Serif, Arial; background-color: #aaaaaa;text-align: left;" id="Table1" runat="server" CellSpacing="5" GridLines="Horizontal" 
		height="25" width="31"></asp:table>
    <br />
		
        <asp:Label id="Label2" style="font-family: Microsoft Sans Serif, Arial; font-size: 12px; " runat="server" Width="392px">Per visualizzare il report è necessario avere acrobat reader installato. Se lo si desidera, è possibile scaricarlo cliccando il bottone giallo a destra.</asp:Label>
		<asp:HyperLink id="HyperLink1" runat="server" Width="88px" Height="32px" NavigateUrl="http://www.adobe.com/products/acrobat/readstep2.html"
		imageurl="Immagini/getacro.gif">HyperLink</asp:HyperLink><br />
    <br />
            
		<asp:button id="btnNewIndex" runat="server" Width="140px" Height="40px"
		Text="Indice Report" style="background-color: #aaaaaa;border: 1px solid gray;font-size: 12px;font-family: Microsoft Sans Serif, Arial;" OnClick="btnNewIndex_Click" ></asp:button>
		<asp:button id="btnVisualizzaReport" style="background-color: #aaaaaa;border: 1px solid gray;font-size: 12px;font-family: Microsoft Sans Serif, Arial;" runat="server" Width="140px" Height="40px"
		Text="Visualizza Report" OnClick="btnVisualizzaReport_Click" ></asp:button>
    </center>
</asp:Content>