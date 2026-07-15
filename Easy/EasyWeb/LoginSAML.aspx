<%@ Page Language="c#" MasterPageFile="~/MetaMasterBootstrap.master" Inherits="EasyWebReport.LoginSAML" CodeFile="LoginSAML.aspx.cs" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">

	<div class="row">
		<div class="col-md-8 offset-md-2">
			<div class="row mt-2">
				<div class="col-md-12 text-center">
					<asp:HyperLink Style="text-align: center;" ID="HyperLink1" runat="server" Font-Size="Medium"
						Target="_blank" NavigateUrl="~/EasyWeb Impostazioni Browser.pdf">Istruzioni per la configurazione del browser</asp:HyperLink>
				</div>
			</div>
			<div class="row mt-2">
				<div class="text-center col-md-12">
					<h2>Servizio Web Easy</h2>
				</div>
			</div>
			<div class="row mt-2">
				<div class="col-md-12 serverinfo">
					<asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></asp:Label>
					<asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>
				</div>
			</div>

			<hr />

			<div class="row mt-4">
				<div class="col-md-12">
					<h5>Inserire i dati necessari  per accedere ai servizi.</h5>
				</div>
			</div>

			<div class="row">
				<div class="col-md-12 pl-5">
					<div class="row">
						<div class="col-12 col-sm-4">
							<asp:Label ID="lblNomeUtente" TabIndex="99" runat="server">Nome Utente:</asp:Label>
						</div>
						<div class="col-6 col-sm-4">
							<asp:TextBox ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Login fornita dal servizio SSO" TabIndex="2" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
						</div>
					</div>
					<div class="row">
						<div class="col-12 col-sm-4">
							<asp:Label ID="lblData" runat="server">Data Contabile</asp:Label>:
						</div>
						<div class="col-6 col-sm-4">
							<asp:TextBox ID="txtDataContabile" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" Style="text-align: right;" TabIndex="4" runat="server" MaxLength="12" ToolTip="Data Contabile"></asp:TextBox>
						</div>
						<div class="col-6 col-sm-4">
							<asp:RequiredFieldValidator ID="Label4" runat="server" TabIndex="99" ControlToValidate="txtDataContabile"
								ErrorMessage="Inserire la Data Contabile"></asp:RequiredFieldValidator>
						</div>
					</div>
					<div class="row">
						<div class="col-12 col-sm-4">
							<asp:Label ID="Label3" runat="server">Codice Dipartimento:</asp:Label>
						</div>
						<div class="col-6 col-sm-4">
							<asp:DropDownList ID="cmbDipartimento" runat="server" TabIndex="5"></asp:DropDownList>
						</div>
						<div class="col-6 col-sm-4">
						</div>
					</div>
				</div>
			</div>
			<div class="row mt-3">
				<div class="col-6 offset-3 col-sm-4 offset-sm-4 text-center">
					<asp:Button ID="btnOk" TabIndex="6" runat="server" CssClass="btn btn-primary min100" Text="Accedi" OnClick="btnOk_Click" />
				</div>
			</div>
		</div>
	</div>
	<%
		try { System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "__errorLog.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - FromSso: " + (Session["FromSso"] ?? "").ToString() + "\r\n"); } catch { }
		try { System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "__errorLog.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - sso: " + (Session["sso"] ?? "").ToString() + "\r\n"); } catch { }
		if (Session["FromSso"] != null)
		{
			Session["FromSso"] = null;
	%>
	<script>
		if (document.getElementById('_ctl0_CHP_PC_txtNomeUtente').value != '') {
			if (document.getElementById('_ctl0_CHP_PC_txtDataContabile').value != '') {
				const select = document.getElementById('_ctl0_CHP_PC_cmbDipartimento');
				if (select.options.length > 0) {
					document.getElementById("_ctl0_CHP_PC_btnOk").click();
				}
			}
		}
	</script>
	<%}%>
</asp:Content>
