<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="PasswordReset.aspx.cs" Inherits="PasswordReset" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
	<div class="row" >
		<div class="col-lg-8 col-md-offset-2">
			<div class="row mb-25">
				<div class="col-12">
					<h2 style="text-align :center">Reset Password</h2>
				</div>
			</div>
			<div class="row">
				<div class="col-12">
					<asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></asp:Label>
                    <asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>
					<div id="campi" runat="server">
                        <h4 style="text-align:center;">Inserisci la email con la quale ti sei registrato</h4>   
						<div class="row" style="margin-top:25px;">
							<div class="col-md-2" style="text-align:right">
								<asp:Label ID="lblEmail" TabIndex="99" runat="server">Email:</asp:Label>
							</div>
							<div class="col-md-4 col-6">
								<asp:TextBox ID="txtEmail" class="fl" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="Inserisci la Email con la quale ti sei registrato" TabIndex="3"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" TabIndex="99" runat="server" ErrorMessage="Inserire la Email con la quale ti sei registrato" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
							</div>
                            <div class="col-6" style="text-align:center">
								<button ID="InviamiPassword" runat="server" type="submit">Inviami una Nuova Password</button>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div style="text-align:center">
				<a ID="LinkAttiva" runat="server" style="display:none;" class="btn btn-success" href="ActivateAccount.aspx">Attiva Account</a>
			</div>
			<br />
			<a ID="LinkLogin" runat="server" class="btn btn-default" href="LoginServizi.aspx">Torna alla Login</a>
        </div>
	</div>
</asp:Content>