<%@ Page language="c#" Inherits="EasyWebReport.Installa" CodeFile="Installa.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Installa</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 121; LEFT: 64px; POSITION: absolute; TOP: 112px" runat="server">Nome del server per il db di SISTEMA</asp:Label>&nbsp;
			<asp:TextBox id="txtServer" style="Z-INDEX: 102; LEFT: 56px; POSITION: absolute; TOP: 144px" tabIndex="1" runat="server" Width="328px"></asp:TextBox>
			
			<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 56px; POSITION: absolute; TOP: 176px" runat="server" Width="240px">Nome del db di SISTEMA</asp:Label>
			<asp:TextBox id="txtDB" style="Z-INDEX: 104; LEFT: 56px; POSITION: absolute; TOP: 200px" tabIndex="2" runat="server" Width="328px"></asp:TextBox>
			
			<asp:Label id="Label3" style="Z-INDEX: 105; LEFT: 56px; POSITION: absolute; TOP: 24px" runat="server" Width="328px">Configurazione del servizio di Web Report</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 106; LEFT: 56px; POSITION: absolute; TOP: 48px" runat="server" Width="328px">Password di abilitazione alla configurazione</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 107; LEFT: 56px; POSITION: absolute; TOP: 240px" runat="server">Utente per l'accesso al db di SISTEMA</asp:Label>
			<asp:TextBox id="txtUser" style="Z-INDEX: 108; LEFT: 56px; POSITION: absolute; TOP: 264px" tabIndex="3" runat="server" Width="328px"></asp:TextBox>
			
			<asp:Label id="Label6" style="Z-INDEX: 109; LEFT: 56px; POSITION: absolute; TOP: 304px" runat="server">Password per accesso al db di SISTEMA</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 110; LEFT: 56px; POSITION: absolute; TOP: 440px" runat="server" Width="320px">Directory per l'accesso ai Report</asp:Label>
			<asp:TextBox id="txtReport" style="Z-INDEX: 111; LEFT: 56px; POSITION: absolute; TOP: 464px" tabIndex="6" runat="server" Width="328px"></asp:TextBox>
			
			<asp:Button id="BtnOk" style="Z-INDEX: 112; LEFT: 147px; POSITION: absolute; TOP: 501px" runat="server" Width="161px" Text="Accetta le modifiche"></asp:Button>
			<asp:Label id="labMsg" style="Z-INDEX: 114; LEFT: 64px; POSITION: absolute; TOP: 536px" runat="server" Width="440px" Height="32px"></asp:Label>
			<INPUT style="Z-INDEX: 115; LEFT: 56px; WIDTH: 328px; POSITION: absolute; TOP: 72px; HEIGHT: 22px" type="password" size="49" name="txtPwdSystem">
			<INPUT style="Z-INDEX: 117; LEFT: 56px; WIDTH: 328px; POSITION: absolute; TOP: 328px; HEIGHT: 22px" tabIndex="4" type="password" size="49" name="txtPWD">
			<asp:Label id="Label9" style="Z-INDEX: 118; LEFT: 456px; POSITION: absolute; TOP: 200px" runat="server" Width="264px" Height="104px">Ricordarsi di aggiungere i permessi dell'utente impersonato alla directory cfg prima di usare questo form e poi, alla fine, di TOGLIERLI!!</asp:Label>
			<asp:Label id="Label10" style="Z-INDEX: 119; LEFT: 456px; POSITION: absolute; TOP: 168px" runat="server">NOTA IMPORTANTE</asp:Label>
			<asp:Label id="labUsr" style="Z-INDEX: 120; LEFT: 456px; POSITION: absolute; TOP: 72px" runat="server" Width="272px" Height="43px">Label</asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
		</form>
	</body>
</html>
