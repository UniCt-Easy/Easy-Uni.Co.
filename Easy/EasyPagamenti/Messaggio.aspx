<%@ Page language="c#" MasterPageFile="~/MetaMasterBootstrap.master" Inherits="Messaggio" CodeFile="Messaggio.aspx.cs" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
	<center>
		<br />
		<br />
		<br />
		<asp:Label id="lblMessaggio" style="font-family: Arial, Microsoft Sans Serif; font-size: 21px; font-weight: bold;" runat="server"></asp:Label>
	</center>
	<center>&nbsp;</center>
	<center>
		<br />
		<br />
		<asp:Button runat="server" id="ImageButton1" class="btn btn-default" Text="Vai alla Homepage"></asp:Button >
	</center>
</asp:Content>