<%@ page language="c#" MasterPageFile="MetaMaster.master" inherits="EasyWebReport.InserisciParametriExp" CodeFile ="~/InserisciParametriExp.aspx.cs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CHP_PC" runat="Server">
<center>
    <br />
    <asp:Label ID="TitoloExp" runat="server" style="font-family: Microsoft Sans Serif, Arial; font-size: 24px; font-weight: bold;"></asp:Label>&nbsp;

</center>
    <center>
    <br />
		<asp:label id="Label1" runat="server" style="font-family: Microsoft Sans Serif, Arial; font-size: 18px; font-weight: bold;" >Inserire i parametri.</asp:label>
    <br />
    <br />
		<asp:table id="Table1" style="width: 900px; color: #333333; font-family: Microsoft Sans Serif, Arial; background-color: #aaaaaa;text-align: left;" runat="server" height="25" width="31" CellSpacing="5" GridLines="Horizontal" ></asp:table>
    <br />
		<asp:Label id="Label2" style="font-family: Microsoft Sans Serif, Arial; font-size: 12px; " runat="server" Width="392px">Per visualizzare l'esportazione è necessario avere Excel Installato</asp:Label><br />
    <br />
		<asp:button style="background-color: #aaaaaa;border: 1px solid gray;font-size: 12px;font-family: Microsoft Sans Serif, Arial;" id="btnNewIndex" runat="server" Width="140px" Height="40px"
										Text="Indice Report" OnClick="btnNewIndex_Click" ></asp:button>
		<asp:button style="background-color: #aaaaaa;border: 1px solid gray;font-size: 12px;font-family: Microsoft Sans Serif, Arial;" id="btnVisualizzaReport" runat="server" Width="145px" Height="40px"
		Text="Visualizza Esportazione" OnClick="btnVisualizzaReport_Click" ></asp:button>
    </center>
</asp:Content>