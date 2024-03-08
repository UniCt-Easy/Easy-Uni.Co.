<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="CodeResend.aspx.cs" Inherits="CodeResend" %>


<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
	<div class="row">
		<div class="col-md-8 col-md-offset-2">
			<h2 style="text-align :center">Reinvio Codice di Attivazione</h2>
		</div>
	</div>
	<div class="row">
		<div class="col-md-8 col-md-offset-2">
			<asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></asp:Label>
			<asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>
		</div>
	</div>
	<div id="campi" runat="server">
		<div class="row mb-15">
			<div class="col-md-8 col-md-offset-2">
				<h4 style="width:80%;margin:auto;margin-top:15px;text-align:center;">Inserisci la email con la quale ti sei registrato</h4>   
			</div>
		</div>
		<div class="row">
			<div class="col-md-8 col-md-offset-2">
				<div class="row" style="margin-top:25px;">
					<div class="col-md-1">
						<asp:Label ID="lblEmail" TabIndex="99" runat="server">Email:</asp:Label>
					</div>
					<div class="col-md-5 col-6">
						<asp:TextBox ID="txtEmail" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" 
							runat="server" MaxLength="50" ToolTip="Inserisci la Email con la quale ti sei registrato" TabIndex="3"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" TabIndex="99" runat="server"
							ErrorMessage="Inserire la Email con la quale ti sei registrato" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
					</div>
					<div class="col-md-6 col-6">
						<button ID="InviamiPassword" runat="server" style="float:right" type="submit">Inviami un Nuovo Codice</button>
					</div>
				</div>
			</div>
		</div>
	</div>
	<br/>
	<br/>
	<div class="row">
		<div class="col-md-8 col-md-offset-2">
			<a ID="LinkLogin" runat="server" class="btn btn-default" href="LoginServizi.aspx">Torna alla Login</a>
			<a ID="LinkAttiva" runat="server" style="display:none;" class="btn btn-info" href="ActivateAccount.aspx">Vai ad Attivazione</a>
		</div>
	</div>
</asp:Content>