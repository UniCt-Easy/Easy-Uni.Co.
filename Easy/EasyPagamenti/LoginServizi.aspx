<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="LoginServizi.aspx.cs" Inherits="EasyPagamenti.LoginServizi" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >
    <div class="row">
		<div class="col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
			<div class="row mb-15">
				<div class="text-center col-md-12">
					<h2>Easy Pagamenti</h2>
				</div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></asp:Label>
                    <asp:Label ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></asp:Label>
                </div>
            </div>
            <fieldset>
                <legend>Inserire i dati necessari  per accedere ai servizi.</legend>
	            <div class="row mb-15">
		            <div class="text-center col-md-12">
			            <asp:HyperLink Style="text-align: center;" ID="HyperLink1" runat="server" Font-Size="Medium" Target="_blank" NavigateUrl="~/FAQ.pdf">FAQ Registrazione</asp:HyperLink>
		            </div>
	            </div>
                <div class="row">
		            <div class="col-6">
                        <!-- ================================= Nome Utente ================================= -->
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblNomeUtente" TabIndex="99" runat="server">Nome Utente:</asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:TextBox ID="txtNomeUtente" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" runat="server" MaxLength="50" ToolTip="username fornita dall'amministratore" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="99" runat="server" ErrorMessage="Digitare il Nome Utente" ControlToValidate="txtNomeUtente"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- ================================= Password ================================= -->
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblPassword" TabIndex="99" runat="server">Password:</asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:TextBox ID="txtPassword" TabIndex="3" runat="server" MaxLength="50" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" ToolTip="Password fornita dal segretario amministrativo" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" TabIndex="99" runat="server" ErrorMessage="Digitare la password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblMessaggioPass" TabIndex="99" runat="server"></asp:Label>
                            </div>
                        </div>

                        <!-- ================================= Data ================================= -->
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblData" runat="server">Data:</asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:TextBox ID="txtDataContabile" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" Style="text-align: right;" TabIndex="4" runat="server" MaxLength="12" ToolTip="Data Contabile"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RequiredFieldValidator ID="Label4" runat="server" TabIndex="99" ControlToValidate="txtDataContabile" ErrorMessage="Inserire la Data Contabile"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- ================================= Dipartimento ================================= -->
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label3" runat="server" Visible="false">Codice Dipartimento:</asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:TextBox ID="txtCodiceDipartimento" runat="server" onfocus="document.getElementById(this.id).className='focused';" onblur="document.getElementById(this.id).className='';" MaxLength="50" ToolTip="Codice del dipartimento" TabIndex="5" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:RequiredFieldValidator ID="Label5" runat="server" TabIndex="99" ControlToValidate="txtCodiceDipartimento" ErrorMessage=""> </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="text-center col-6" style="margin-top:20px">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <!-- ================================= Login ================================= -->
                        <div class="row">
                            <div class="col-md-12" style="margin-top: 20px;">
                                <%--<asp:ImageButton ID="ImageButton1" TabIndex="6" runat="server" ImageUrl="~/Immagini/SendChat.gif" />--%>
                                <asp:Button ID="buttonSub" runat="server" CssClass="btn btn-success" Style="width: 60%;" Text="Login" />
                            </div>
                        </div>

                        <!-- ================================= Reimposta ================================= -->
                        <div class="row">
                            <div class="col-md-12" style="margin-top: 20px;">
                                <div id="PasswordDimenticata" style="display:block" runat="server">
                                    <label style="display: block; margin-bottom: 0px;">Hai dimenticato la password ?</label>
                                    <a href="PasswordReset.aspx" class="btn btn-info" Style="width: 60%;">Reimposta</a>
                                </div>
                            </div>
                        </div>

                        <!-- ================================= Registrati ================================= -->
                        <div class="row">
                            <div class="col-md-12" style="margin-top: 20px;">
                                <label style="display: block; margin-bottom: 0px;">Non hai un Account ?</label>
                                <a href="RegistraAccount.aspx" class="btn btn-info"  Style="width: 60%;">Registrati</a>
                            </div>
                        </div>

                        <!-- ================================= Nuovo Codice ================================= -->
                        <div class="row">
                            <div class="col-md-12" style="margin-top: 20px;">
                                <label style="display: block; margin-bottom: 0px;">Non hai ricevuto il codice di attivazione ?</label>
                                <a id="LinkResend" runat="server" style="display: none; width: 60%;" class="btn btn-info" href="CodeResend.aspx">Invia Nuovo Codice</a>
                            </div>
                        </div>

                        <!-- ================================= Nuovo Codice ================================= -->
                        <div class="row">
                            <div class="col-md-12" style="margin-top: 20px;">
                                <label style="display: block; margin-bottom: 0px;">Hai ricevuto il codice di attivazione ?</label>
                                <a id="LinkActivate" runat="server" style="display: none; width: 60%;" class="btn btn-info" href="ActivateAccount.aspx">Attiva Account</a>
                            </div>
                        </div>
                    </div>
	            </div>                
            </fieldset>
        </div>
    </div>
</asp:Content>