<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="RegistraAccount.aspx.cs" Inherits="RegistraAccount" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">
    <style type="text/css">
    	.privacyinfo {
    		height: 100px;
    		overflow-y: scroll;
    		white-space: normal;
    		border: 1px solid #ccc;
    		padding: 5px 8px;
    		font-size: 1rem;
            border-radius: 4px;
    	}
        .privacyinfo p {
            margin-bottom: 0;
        }

        .privacyinfo::-webkit-scrollbar {
            width: 8px;
        }

        .privacyinfo::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }

        .privacyinfo::-webkit-scrollbar-thumb {
            background: #999;
            border-radius: 10px;
        }

        .privacyinfo::-webkit-scrollbar-thumb:hover {
            background: #b30000;
        }
    </style>
    <div class="row">
		<div class="col-md-10 col-md-offset-1 col-lg-8 col-lg-offset-2">
            <div class="row mb-15">
                <div class="text-center col-md-12">
                    <h2>Easy Pagamenti</h2>
                </div>
            </div>
            <div class="row mb-25">
                <cc1:hwLabel ID="lblMessaggio" CssClass="errormessage" runat="server" TabIndex="99"></cc1:hwLabel>
                <cc1:hwLabel ID="labExtMessage" runat="server" CssClass="errormessage" TabIndex="99"></cc1:hwLabel>
                <div id="campi" runat="server" style="margin-top: 25px;">
                    <div class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblUserName" TabIndex="99" runat="server">Nome Utente*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtUserName"  runat="server" MaxLength="50" ToolTip="Scegli un nome utente" TabIndex="1"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" TabIndex="99" runat="server" ErrorMessage="Inserire il Nome Utente" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblPassword" TabIndex="99" runat="server">Password*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtPassword"  TextMode="Password" runat="server" MaxLength="50" ToolTip="Scegli una password" TabIndex="2"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" TabIndex="99" runat="server" ErrorMessage="Inserire la Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-25">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="Label1" TabIndex="99" runat="server">Conferma Password*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtConfermaPassword"  TextMode="Password" runat="server" MaxLength="50" ToolTip="Ridigita la password" TabIndex="3"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" TabIndex="99" runat="server" ErrorMessage="Inserire di nuovo la Password" ControlToValidate="txtConfermaPassword"></asp:RequiredFieldValidator>
                        </div>
                    </div>
					
					<div class="row">
						<div class="col-md-12">
							<h3>Seleziona il tuo profilo*</h3>
						</div>
					</div>	

					<div id="contenttiporesidenza" class="row mb-25">
						<div class="col-md-12 pl-25">
							<asp:RadioButtonList ID="rbTipoUtente" onchange="MostraNascondiText();" TabIndex="4" runat="server">
								<asp:ListItem Value="1">Persona fisica</asp:ListItem>
								<asp:ListItem Value="2">Persona Giuridica</asp:ListItem>
							</asp:RadioButtonList>
						</div>
					</div>
					
					<div class="row">
						<div class="col-md-12">
							<h3>Inserisci le informazioni sulla residenza*</h3>
						</div>
					</div>	
					
                    <div id="contenttiporesidenza" class="row mb-15">
						<div class="col-12">
                            <div class="row">
                                <div class="col-md-12 mb-25 pl-25">
                                    <asp:RadioButtonList ID="rdbtiporesidenza" onchange="MostraNascondiText();" TabIndex="5" runat="server">
                                        <asp:ListItem Value="I">Residente in Italia</asp:ListItem>
                                        <asp:ListItem Value="X">Residenti fuori dall'UE</asp:ListItem>
                                        <asp:ListItem Value="J">Residenti in altri paesi dell'UE</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div id="contentIndirizzo" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblIndirizzo" TabIndex="99" runat="server">Indirizzo residenza*:</cc1:hwLabel>
                                </div>
                                <div class="col-sm-12">
                                    <cc1:hwTextBox ID="txtIndirizzo" runat="server" MaxLength="100" ToolTip="Inserisci la via o la piazza dell'indirizzo" TabIndex="6"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div id="contentluogoIndirizzo" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblLuogoIndirizzo" TabIndex="99" runat="server">Città residenza*:</cc1:hwLabel>
                                </div>
                                <div class="col-sm-12">
                                    <cc1:hwTextBox ID="txtLuogoIndirizzo" runat="server" MaxLength="150" ToolTip="Seleziona Città dell'indirizzo" TabIndex="7"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div id="contentCAP" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblCAP" TabIndex="99" runat="server">CAP:</cc1:hwLabel>
                                </div>
                                <div class="col-sm-12">
                                    <cc1:hwTextBox ID="txtCAP" runat="server" MaxLength="150" ToolTip="CAP" TabIndex="8"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div id="contentnazioneIndirizzo" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblNazioneIndirizzo" TabIndex="99" runat="server">Nazione di residenza*:</cc1:hwLabel>
                                </div>
                                <div class="col-sm-8">
                                    <cc1:hwTextBox ID="txtNazioneIndirizzo"  runat="server" MaxLength="150" ToolTip="Seleziona Nazione dell'indirizzo" TabIndex="9"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div id="contentLocalitaIndirizzo" class="row">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblLocalitaIndirizzo" TabIndex="99" runat="server">Localita residenza:</cc1:hwLabel>
                                </div>
                                <div class="col-sm-8">
                                    <cc1:hwTextBox ID="txtLocalitaIndirizzo"  runat="server" MaxLength="150" ToolTip="Seleziona Località dell'indirizzo ove necessario" TabIndex="10"></cc1:hwTextBox>
                                </div>                     
                            </div>
						</div>
                    </div>

                    <div id="contentmail" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblEmail" TabIndex="99" runat="server">Email*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtEmail" runat="server" MaxLength="200" ToolTip="Inserisci una Email" TabIndex="11"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" TabIndex="99" runat="server" ErrorMessage="Inserire la Email" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="contentpec" class="row mb-10" >
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblPec" TabIndex="99" runat="server">PEC:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtPec" runat="server" MaxLength="200" ToolTip="Inserisci la tua PEC" TabIndex="12"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div id="contentnome" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblNome" TabIndex="99" runat="server">Nome*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtNome" runat="server" MaxLength="50" ToolTip="Inserisci il tuo nome" TabIndex="13"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" TabIndex="99" runat="server" ErrorMessage="Inserire il Nome" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="contentcognome" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblCognome" TabIndex="99" runat="server">Cognome*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtCognome" runat="server" MaxLength="50" ToolTip="Inserisci il tuo Cognome" TabIndex="14"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" TabIndex="99" runat="server" ErrorMessage="Inserire il Cognome" ControlToValidate="txtCognome"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="contentdenominazione" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lbldenominazione" TabIndex="99" runat="server">Denominazione*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtdenominazione" runat="server" MaxLength="50" ToolTip="Inserisci la denominazione" TabIndex="15"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" TabIndex="99" runat="server" ErrorMessage="Inserire la Denominazione" ControlToValidate="txtdenominazione"></asp:RequiredFieldValidator>
                        </div>
                    </div>
        

                    <div id="contentdatanascita" class="row mb-25">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblDataDiNascita" TabIndex="99" runat="server">Data di Nascita*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12 mb-10">
                            <cc1:hwTextBox ID="txtDataDiNascita" runat="server" MaxLength="50" ToolTip="Inserisci Data di Nascita" TabIndex="16"></cc1:hwTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" TabIndex="99" runat="server" ErrorMessage="Inserire Data di Nascita" ControlToValidate="txtDataDiNascita"></asp:RequiredFieldValidator>
                        </div>
                    </div>
					
					<div class="row">
						<div class="col-md-12">
							<h3>Luogo di nascita</h3>
						</div>
					</div>	
					
                    <div id="contenttiporesidenza" class="row">
						<div class="col-12">
                            <div class="row">
                                <div class="col-md-12 mb-25 pl-25">
                                    <asp:RadioButtonList ID="rdbItaliaEstero" onchange="MostraNascondiText();" TabIndex="17" runat="server">
                                        <asp:ListItem Value="I">Nato in Italia</asp:ListItem>
                                        <asp:ListItem Value="E">Nato fuori dall'Italia</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
        
                            <div id="contentSesso" class="row">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <cc1:hwLabel ID="labSesso" TabIndex="99" runat="server">Sesso*:</cc1:hwLabel>
                                    </div>
                                    <div class="col-md-10">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:RadioButtonList ID="rdbSesso" TabIndex="18" runat="server">
                                            <asp:ListItem Value="M">Maschile</asp:ListItem>
                                            <asp:ListItem Value="F">Femminile</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" TabIndex="99" runat="server"
                                            ErrorMessage="Inserire il sesso" ControlToValidate="rdbSesso"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                           </div>

                            <div id="contentluogonascita" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblLuogoNascita" TabIndex="99" runat="server">Città di nascita*:</cc1:hwLabel>                
                                </div>
                                <div class="col-sm-12">
                                    <cc1:hwTextBox ID="txtLuogoNascita"  runat="server" MaxLength="150" ToolTip="Seleziona Città di Nascita" TabIndex="19"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div id="contentnazionenascita" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblNazione" TabIndex="99" runat="server">Nazione di nascita*:</cc1:hwLabel>                
                                </div>
                                <div class="col-sm-12">
                                    <cc1:hwTextBox ID="txtNazione"  runat="server" MaxLength="150" ToolTip="Seleziona Nazione di Nascita" TabIndex="20"></cc1:hwTextBox>
                                </div>
                            </div>
                            <div id="contentLocalita" class="row mb-10">
                                <div class="col-sm-12">
                                    <cc1:hwLabel ID="lblLocalita" TabIndex="99" runat="server">Località di nascita:</cc1:hwLabel>                
                                </div>
                                <div class="col-sm-12">
                                    <cc1:hwTextBox ID="txtLocalita"   runat="server" MaxLength="150" ToolTip="Seleziona Località di Nascita ove necessario" TabIndex="21"></cc1:hwTextBox>
                                </div>
                            </div>
                        </div>
                    </div>   

                    <div ID="contentpiva" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblpartitaiva" TabIndex="99" runat="server">Partita IVA*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtpartitaiva" runat="server" MaxLength="50" ToolTip="Inserisci Partita IVA" TabIndex="22"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div id="contentcf" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblCodiceFiscale" TabIndex="99" runat="server">Codice Fiscale*:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtCodiceFiscale" runat="server" MaxLength="50" ToolTip="Inserisci Codice Fiscale" TabIndex="23"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div id="contentcfestero" class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblCFestero" TabIndex="99" runat="server">Codice Fiscale Estero:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtCFestero" runat="server" MaxLength="50" ToolTip="Inserisci CF estero o identificativo IVA" TabIndex="24"></cc1:hwTextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" TabIndex="99" runat="server" ErrorMessage="Inserire Codice Fiscale  estero o identificativo IVA" ControlToValidate="txtCodiceFiscale"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>

                    <div id="contentcodicedestinatario" class="row mb-25">
                        <div class="col-sm-12">
                            <cc1:hwLabel ID="lblcodicedestinatario" TabIndex="99" runat="server">Codice Destinatario:</cc1:hwLabel>
                        </div>
                        <div class="col-sm-12">
                            <cc1:hwTextBox ID="txtcodicedestinatario" runat="server" MaxLength="7" ToolTip="Inserisci il codice destinatario per la fatturazione elettronica" TabIndex="25"></cc1:hwTextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" TabIndex="99" runat="server" ErrorMessage="Inserire Codice Fiscale  estero o identificativo IVA" ControlToValidate="txtCodiceFiscale"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>

                    <div id="contentsplitpayment" class="row mb-25">
                        <div class="col-sm-12">
                            <cc1:hwCheckBox ID="CheckBoxSplitPayment" runat="server" ToolTip="Specificare se soggetto a split payment" TabIndex="26"></cc1:hwCheckBox>
                            <cc1:hwLabel ID="lblSplitPayment" TabIndex="99" runat="server">la Società/Ente, ai sensi del decreto legge n. 50/2017, convertito dalla legge n. 96/2017, e, in ogni caso, fino a revoca/modifica della presente dichiarazione è soggetto/a allo split payment, in quanto rientrante in una delle categorie previste: </cc1:hwLabel>
                        </div>
                        <div>
                            <br>
                            <br>
                        </div>
                    </div>

                    <div id="contentsplitpayment" class="row mb-25">
                        <div class="col-sm-12">
							(*) campi obbligatori
						</div>
					</div>
					
                    <div class="row">
                        <div class="col-sm-12">
                            <div style="width: 100%; text-align: center;"><strong>Consenso al trattamento dei dati personali e sensibili </strong></div>
                        </div>
                    </div>

                    <div class="row mb-10">
                        <div class="col-sm-12">
                            <cc1:hwTextBox  ID="TextBoxConsensoPrivacy" runat="server" TextMode="MultiLine" Rows="4" class="input-mini" Width="100%" TabIndex="27" style="display:none"></cc1:hwTextBox>
                            <div ID="Div1" runat="server" class="privacyinfo" Width="100%"></div>
                        </div>
                    </div>


                    <div class="row mb-25">
                        <div class="col-sm-12">
                            <cc1:hwCheckBox ID="Consenso" runat="server" ThreeState="false" TabIndex="28" CssClass="input-sm form-control" Text="Il sottoscritto esprime il proprio consenso al trattamento dei propri dati per le finalità relative al presente pagamento." />
                        </div>
                    </div>
					
                    <div class="row mb-25">
                        <div class="col-sm-12">
							<input class="btn btn-info" style="margin-right: 15px; float: right" type="submit" value="Registrati" />
                        </div>
                    </div> 
                </div>        
            </div>
            <div class="row">
                <div class="col-sm-12">
					<a id="AttivaAccount" runat="server" style="display: none;" class="btn btn-info" href="ActivateAccount.aspx">Attiva Account</a>
                </div>
            </div>     
            <div class="row mb-25">
                <div class="col-12">
					<a class="btn btn-default" href="LoginServizi.aspx">Torna alla Login</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="JScriptAfterLibs" runat="server">
    <script type="text/javascript">

		function MostraNascondiText() {
			var rbl = document.getElementById("<%=rbTipoUtente.ClientID%>");
			var rdbTipoRes = document.getElementById("<%=rdbtiporesidenza.ClientID%>");
			var rdbTipoNascita = document.getElementById("<%=rdbItaliaEstero.ClientID%>");

			var valore = $(rbl).find('input:checked').val();
			var tipoIndirizzo = $(rdbTipoRes).find('input:checked').val();
			var tipoNascita = $(rdbTipoNascita).find('input:checked').val();

			if (tipoIndirizzo == "I") {
				document.getElementById("contentIndirizzo").style.display = "block";
				document.getElementById("contentluogoIndirizzo").style.display = "block";
				document.getElementById("contentCAP").style.display = "block";
				document.getElementById("contentnazioneIndirizzo").style.display = "none";
				document.getElementById("contentLocalitaIndirizzo").style.display = "block";

			} else if (tipoIndirizzo == "X" || tipoIndirizzo == "J") {
				document.getElementById("contentIndirizzo").style.display = "block";
				document.getElementById("contentluogoIndirizzo").style.display = "none";
				document.getElementById("contentCAP").style.display = "none";
				document.getElementById("contentnazioneIndirizzo").style.display = "block";
				document.getElementById("contentLocalitaIndirizzo").style.display = "block";
			} else {
				document.getElementById("contentIndirizzo").style.display = "none";
				document.getElementById("contentluogoIndirizzo").style.display = "none";
				document.getElementById("contentCAP").style.display = "none";
				document.getElementById("contentnazioneIndirizzo").style.display = "none";
				document.getElementById("contentLocalitaIndirizzo").style.display = "none";
			}

			if (valore == 1) {//Persona Fisica

				document.getElementById("contentpiva").style.display = "none";
				document.getElementById("contentnome").style.display = "block";
				document.getElementById("contentcognome").style.display = "block";
				document.getElementById("contentdenominazione").style.display = "none";
				document.getElementById("contentdatanascita").style.display = "block";


				document.getElementById("contentSesso").style.display = "block";

				if (tipoNascita == "I") {
					document.getElementById("contentluogonascita").style.display = "block";
					document.getElementById("contentnazionenascita").style.display = "none";
					document.getElementById("<%=txtNazione.ClientID%>").value = "";

					document.getElementById("contentLocalita").style.display = "block";

				} else if (tipoNascita == "E") {
					document.getElementById("contentluogonascita").style.display = "none";
					document.getElementById("<%=txtLuogoNascita.ClientID%>").value = "";

					document.getElementById("contentnazionenascita").style.display = "block";
					document.getElementById("contentLocalita").style.display = "block";
				} else {
					document.getElementById("contentluogonascita").style.display = "none";
					document.getElementById("<%=txtLuogoNascita.ClientID%>").value = "";
					document.getElementById("contentnazionenascita").style.display = "none";
					document.getElementById("<%=txtNazione.ClientID%>").value = "";
					document.getElementById("contentLocalita").style.display = "none";

				}



				document.getElementById("contentpec").style.display = "block";
				document.getElementById("contentcodicedestinatario").style.display = "block";
				document.getElementById("contentsplitpayment").style.display = "none";

				document.getElementById("contentcf").style.display = "block";
				document.getElementById("contentcfestero").style.display = "block";
				document.getElementById("contentmail").style.display = "block";
			} else if (valore == 2) { //Persona Giuridica
				document.getElementById("contentpiva").style.display = "block";
				document.getElementById("contentnome").style.display = "none";
				document.getElementById("contentcognome").style.display = "none";
				document.getElementById("contentdenominazione").style.display = "block";
				document.getElementById("contentdatanascita").style.display = "none";
				document.getElementById("contentSesso").style.display = "none";


				document.getElementById("contentpec").style.display = "block";
				document.getElementById("contentcodicedestinatario").style.display = "block";
				document.getElementById("contentsplitpayment").style.display = "block";

				document.getElementById("contentluogonascita").style.display = "none";
				document.getElementById("<%=txtLuogoNascita.ClientID%>").value="";

                document.getElementById("contentnazionenascita").style.display = "none";
                document.getElementById("<%=txtNazione.ClientID%>").value="";
                document.getElementById("contentLocalita").style.display = "none";
                

                document.getElementById("contentcf").style.display = "block";
                document.getElementById("contentcfestero").style.display = "block";
                document.getElementById("contentmail").style.display = "block";

            } else  {
                document.getElementById("contentpiva").style.display = "none";
                document.getElementById("contentnome").style.display = "none";
                document.getElementById("contentcognome").style.display = "none";
                document.getElementById("contentdenominazione").style.display = "none";
                document.getElementById("contentdatanascita").style.display = "none";
                document.getElementById("contentcf").style.display = "none";//Li nascondiamo solo per uniformare il comportamento
                document.getElementById("contentcfestero").style.display = "none";
                document.getElementById("contentmail").style.display = "none";
                document.getElementById("contentSesso").style.display = "none";

                document.getElementById("contentpec").style.display = "none";
                document.getElementById("contentcodicedestinatario").style.display = "none";
                document.getElementById("contentsplitpayment").style.display = "none";

                document.getElementById("contentluogonascita").style.display = "none";
                document.getElementById("<%=txtLuogoNascita.ClientID%>").value="";
                document.getElementById("contentnazionenascita").style.display = "none";
                document.getElementById("<%=txtNazione.ClientID%>").value="";
                document.getElementById("contentLocalita").style.display = "none";
            }
            
        }

        function attivaSelezioneCitta(idTxt,currentSN) {
            $(idTxt).autocomplete({  
                source: function (request, responce) {  
                    $.ajax({  
                        url: "RegistraAccount.aspx/GetCities",  
                        method: "post",  
                        contentType: "application/json;charset=utf-8",  
                        data: JSON.stringify({ city: request.term, currentSN:currentSN  }),  
                        dataType: 'json',  
                        timeout: 20000,
                        delay:400,
                        minLength:3,
                        change: function (event, ui) {
                            if(!ui.item){
                                $(event.target).val("");
                            }
                        }, 
                   

                        success: function (data) {
                            xhr = null;
                            var mapped = $.map(data.d,
                                function(item) {
                                    return {
                                        label: item.description + "(" + item.province + ")"
                                    }
                                }
                            );
                            $(idTxt).data("allowedValues", data.d);
                            responce(mapped);
                        },  
                       
                        error: function (err) {  
                            //alert(err);  
                        }  
                    });  
                }  
            });
            $(idTxt).focus(function () {
                $(idTxt).autocomplete("search", "");
            });

            $(idTxt).blur(function () {
                var allowed = $(idTxt).data("allowedValues");
                if (!allowed) {
                    $(idTxt).val("");
                }
                var curr = $(idTxt).val();
                var item = allowed.find(item =>  item.description + "(" + item.province + ")" == curr);
                if (!item) {
                    $(idTxt).val("");
                }
            });

        }
        function attivaSelezioneNazione(idTxt,currentSN) {
            $(idTxt).autocomplete({  
                source: function (request, responce) {  
                    $.ajax({  
                        url: "RegistraAccount.aspx/GetNations",  
                        method: "post",  
                        contentType: "application/json;charset=utf-8",  
                        data: JSON.stringify({ nation: request.term, currentSN:currentSN }),  
                        dataType: 'json',  
                        timeout: 20000,
                        delay:400,
                        minLength:3,
                        change: function (event, ui) {
                            if(!ui.item){
                                $(event.target).val("");
                            }
                        }, 
                       
                        success: function (data) {
                            xhr = null;
                            var mapped = $.map(data.d,
                                function(item) {
                                    return {
                                        label: item.description
                                    }
                                }
                            );
                            $(idTxt).data("allowedValues", data.d);
                            responce(mapped);
                        },  
                       
                        error: function (err) {  
                            //alert(err);  
                        }  
                    });  
                }  
            });
            $(idTxt).focus(function () {
                $(idTxt).autocomplete("search", "");
            });

            $(idTxt).blur(function () {
                var allowed = $(idTxt).data("allowedValues");
                if (!allowed) {
                    $(idTxt).val("");
                }
                var curr = $(idTxt).val();
                var item = allowed.find(item => item.description == curr);
                if (!item) {
                    $(idTxt).val("");
                }
            });
        }
        $(function () {
          
            $.ajaxSetup({
                timeout: 20000,
            });
        //var valoreselezionato = $(rbl).find('input:checked').val();
        //alert(valoreselezionato);

        var textarea = document.getElementById('<%=TextBoxConsensoPrivacy.ClientID %>');
        if (textarea) textarea.scrollTop = textarea.scrollHeight;

        attivaSelezioneCitta("#<%=txtLuogoNascita.ClientID%>", "S");
		attivaSelezioneCitta("#<%=txtLuogoIndirizzo.ClientID%>", "S");
		attivaSelezioneNazione("#<%=txtNazioneIndirizzo.ClientID%>", "N");
		attivaSelezioneNazione("#<%=txtNazione.ClientID%>", "S");
		MostraNascondiText();

		});



	</script>

</asp:Content>