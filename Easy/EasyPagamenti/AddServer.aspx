<%@ Page language="c#" Inherits="EasyWebReport.AddServer" CodeFile="AddServer.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>AddServer</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label3" style="Z-INDEX: 98; LEFT: 56px; POSITION: absolute; TOP: 16px" runat="server"
				Width="328px">Aggiunta di un server al servizio di Web Reporting</asp:Label><INPUT id="txtPWD" style="Z-INDEX: 99; LEFT: 56px; WIDTH: 264px; POSITION: absolute; TOP: 400px; HEIGHT: 22px"
				type="password" size="38" name="txtPWD">
			<asp:Label id="LabelPasswordCfg" style="Z-INDEX: 100; LEFT: 56px; POSITION: absolute; TOP: 48px" runat="server"
				Width="328px">Password di abilitazione alla configurazione</asp:Label>
			<INPUT style="Z-INDEX: 101; LEFT: 56px; WIDTH: 328px; POSITION: absolute; TOP: 72px; HEIGHT: 22px"
				type="password" size="49" name="txtPwdSystem">
			<asp:TextBox id="txtCodice" style="Z-INDEX: 102; LEFT: 56px; POSITION: absolute; TOP: 192px"
				runat="server" Width="328px"></asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 56px; POSITION: absolute; TOP: 112px" runat="server">Nome del Dipartimento da aggiungere</asp:Label>
			<asp:TextBox id="txtDip" style="Z-INDEX: 104; LEFT: 56px; POSITION: absolute; TOP: 136px" runat="server"
				Width="328px"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 56px; POSITION: absolute; TOP: 168px" runat="server">Codice del dipartimento (che sarà poi usato per selezionarlo)</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 106; LEFT: 56px; POSITION: absolute; TOP: 224px" runat="server">IP del server del dipartimento</asp:Label>
			<asp:TextBox id="txtIP" style="Z-INDEX: 109; LEFT: 56px; POSITION: absolute; TOP: 240px" runat="server"></asp:TextBox>
			<asp:Label id="Label6" style="Z-INDEX: 110; LEFT: 56px; POSITION: absolute; TOP: 272px" runat="server">Nome del db</asp:Label>
			<asp:TextBox id="txtDB" style="Z-INDEX: 111; LEFT: 56px; POSITION: absolute; TOP: 288px" runat="server"
				Width="200px"></asp:TextBox>
			<asp:Label id="Label7" style="Z-INDEX: 112; LEFT: 56px; POSITION: absolute; TOP: 328px" runat="server">Utente da usare per la connessione al DB (preferibilmente un utente di SOLA LETTURA)</asp:Label>
			<asp:TextBox id="txtUser" style="Z-INDEX: 113; LEFT: 56px; POSITION: absolute; TOP: 344px" runat="server"
				Width="264px"></asp:TextBox>
			<asp:Label id="Label8" style="Z-INDEX: 114; LEFT: 56px; POSITION: absolute; TOP: 376px" runat="server"
				Width="536px">Password da usare per la connessione al DB</asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 115; LEFT: 272px; POSITION: absolute; TOP: 440px" runat="server"
				Width="176px" Text="Aggiungi il server"></asp:Button>
			<asp:Label id="labMsg" style="Z-INDEX: 116; LEFT: 64px; POSITION: absolute; TOP: 472px" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
