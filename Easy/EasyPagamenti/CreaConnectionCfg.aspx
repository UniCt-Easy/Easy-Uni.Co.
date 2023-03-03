<%@ Page language="c#" Inherits="EasyWebReport.Installa" CodeFile="CreaConnectionCfg.aspx.cs" %>
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
			<h3>Creazione file di Configurazione</h3><br /><br /><br />

			<span>Server</span><br />
			<asp:TextBox id="txtServer" tabIndex="1" runat="server" Width="328px"></asp:TextBox><br /><br /><br />
			
			<span>Database</span><br />
			<asp:TextBox id="txtDB" tabIndex="2" runat="server" Width="328px"></asp:TextBox><br /><br /><br />
			
			<span>Codice Dipartimento</span><br />
			<asp:TextBox id="txtCodiceDipartimento" tabIndex="3" runat="server" Width="328px"></asp:TextBox><br /><br /><br />
			
			<span>User</span><br />
			<asp:TextBox id="txtUser" tabIndex="4" runat="server" Width="328px"></asp:TextBox><br /><br /><br />
			
			<span>Password</span><br />
			<asp:TextBox id="txtPassword" tabIndex="5" runat="server" Width="328px"></asp:TextBox><br /><br /><br />

			<span>Directory per l'accesso ai Report</span><br />
			<asp:TextBox id="txtReport" tabIndex="6" runat="server" Width="328px"></asp:TextBox><br /><br /><br />

			<span>Nome del file: ec_conn_</span><asp:TextBox id="txtExtName" tabIndex="7" runat="server" Width="328px"></asp:TextBox>.xml<br /><br /><br />
			

			<asp:Button id="BtnOk" tabIndex="8" runat="server" Width="161px" Text="Crea file di configurazione"></asp:Button><br /><br /><br />

			<asp:Label id="labMsg" runat="server" Width="440px" Height="32px"></asp:Label>
		</form>
	</body>
</html>