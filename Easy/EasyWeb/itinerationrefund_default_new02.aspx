﻿<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="itinerationrefund_default_new02.aspx.cs" Inherits="itinerationrefund_default_new02" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server" >

<div>
    <div class="row">
        <div class="col-md-3 col-lg-2">
            <cc1:hwButton runat="server" ID="btnClassificazione" Tag="choose.itinerationrefundkind.default" TabIndex="-1" class="btn btn-primary" Text="Rimborso Spese" />
        </div>
        <div class="col-md-9 col-lg-4">
            <cc1:hwDropDownList runat="server" AutoPostBack="true" ID="cmbClassificazione"  CssClass="form-control" Tag="itinerationrefund.iditinerationrefundkind" TabIndex="1"></cc1:hwDropDownList>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="grpDatiGenerali" runat="server">
                <fieldset>
                    <legend>Dati Generali</legend>
                    <div class="row">
                        <div class="col-md-12">
                            <label for="txtDescrizione">Descrizione</label>
                            <cc1:hwTextBox runat="server" ID="txtDescrizione" CssClass="form-control" Rows="4" Tag="itinerationrefund.description" TextMode="MultiLine" TabIndex="2"></cc1:hwTextBox>
                        </div>
                    </div>
                    <!-- chiude Descrizione-->

                    <asp:Panel ID="grpDataInizioFine" runat="server">
                        <div class="row">
                            <div class="col-6 col-md-3">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="txtDataInizio">Data Inizio:</label>
                                        <div class="it-datepicker-wrapper theme-dark">
                                            <cc1:hwTextBox runat="server" ID="txtDataInizio" CssClass="form-control it-date-datepicker" data-date-format="dd/mm/yy" Tag="itinerationrefund.starttime.g" TabIndex="3"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6 col-md-3">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="txtDataFine">Data Fine:</label>
                                        <div class="it-datepicker-wrapper theme-dark">
                                            <cc1:hwTextBox runat="server" ID="txtDataFine" CssClass="form-control it-date-datepicker" data-date-format="dd/mm/yy" Tag="itinerationrefund.stoptime.g" TabIndex="4"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
						<div class="row">
							<cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" ID="grpValuta" runat="server" Tag="AutoChoose.txtValuta.default.(active='S')" Style="width: 100%">
								<div class="col-md-2 ">
									<cc1:hwButton runat="server" ID="btnValuta" class="btn btn-primary" Tag="choose.currency.lista.(active='S')" data-toggle="tooltip" data-placement="top" title="Inserire alcune lettere per filtrare la ricerca e premere sul bottone Valuta" CssClass="w-100 btn btn-primary" TabIndex="-1" Text="Valuta:" />
								</div>

								<div class="col-md-4">
									<cc1:hwTextBox TabIndex="300" ID="txtValuta" CssClass="form-control input-md" Tag="currency.description?x" runat="server"></cc1:hwTextBox>
								</div>

									<asp:Panel ID="grpCambio" runat="server">
										<div class="col-md-2">
											<label for="txtCambio">Tasso di Cambio:</label>
										</div>
										<div class="col-md-4">
											<cc1:hwTextBox runat="server" ID="txtCambio" CssClass="form-control" Tag="itinerationrefund.exchangerate.fixed.8...1" TabIndex="-1"></cc1:hwTextBox>
										</div>
									</asp:Panel>
							</cc1:hwPanel>



						</div>
                    </asp:Panel>
                </fieldset>
                <!-- chiude Dati Generali-->
            </asp:Panel>
        </div>

        <br />
        <br />
    </div>
        <ul id="mainTabControl" class="nav nav-tabs nav-justified">
        <li><a data-toggle="tab" href="#tabspesa">Spesa</a></li>
        <li ID="tballegati" runat="server"><a data-toggle="tab" href="#taballegati">Allegati</a></li>
    </ul>
	<div class="tab-content">
		<div id="tabspesa" class="tab-pane fade in active">
			
				<asp:Panel ID="grpApplicabilita" runat="server">
					<fieldset>
						<legend>Applicabilità</legend>
						<div class="row">
							<div class="col-md-4">
								<cc1:hwRadioButton runat="server" ID="rdbAnticipo" AutoPostBack="true" Tag="itinerationrefund.flagadvancebalance:A" Text="Anticipo" TabIndex="-1" />
							</div>
							<div class="col-md-4">
								<cc1:hwRadioButton runat="server" ID="rdbSaldo" AutoPostBack="true" Tag="itinerationrefund.flagadvancebalance:S" TabIndex="-1" Text="Saldo" />
							</div>
						</div>
					</fieldset>
				</asp:Panel>
			
			<!-- chiude la prima sezione-->
			<br />
			
			<div class="row">
				<div class="col-md-12">
					<asp:Panel ID="grpLocalita" runat="server">
						<fieldset>
							<legend>Località</legend>
							<div class="row">
								<div class="col-md-4">
									<cc1:hwRadioButton runat="server" AutoPostBack="true" OnCheckedChanged="rdoItaly_CheckedChanged" ID="rdoItaly"
										Tag="itinerationrefund.flag_geo:I" Text="Italia" TabIndex="-1" />
								</div>
								<div class="col-md-4">
									<cc1:hwRadioButton runat="server" AutoPostBack="true" ID="rdoUe" OnCheckedChanged="rdoUe_CheckedChanged"
										Tag="itinerationrefund.flag_geo:U" TabIndex="-1" Text="Unione Europea" />
								</div>
								<div class="col-md-4">
									<cc1:hwRadioButton runat="server" AutoPostBack="true" ID="rdoExtraUe" OnCheckedChanged="rdoExtraUe_CheckedChanged"
										Tag="itinerationrefund.flag_geo:E" TabIndex="-1" Text="Fuori dall'Unione Europea" />
								</div>
							</div>
						</fieldset>
						<div class="row">
							<div class="col-md-3">
								<cc1:hwButton ID="btnArea" runat="server" TabIndex="-1" CssClass="w-100 btn btn-primary" Tag="choose.foreigncountry.default" Text="Località Estera:" />
							</div>
							<div class="col-md-9">
								<cc1:hwDropDownList ID="cmbArea" runat="server" AutoPostBack="true" CssClass="form-control" TabIndex="5" Tag="itinerationrefund.idforeigncountry"></cc1:hwDropDownList>
							</div>
						</div>
					</asp:Panel>
					<br />
					<br />
					<asp:Panel ID="grpLimite" runat="server">
						<div class="row">
							<div class="col-md-12">
								<fieldset>
									<legend>Limite Massimo per Classe di Spesa</legend>
									<div class="row">
										<div class="col-md-3 col-lg-2">
											<label for="txtLimiteMax">Importo</label>
										</div>
										<div class="col-md-6 col-lg-6">
											<cc1:hwTextBox runat="server" ID="txtLimiteMax" CssClass="form-control" TabIndex="-1" ReadOnly="true"></cc1:hwTextBox>
										</div>
									</div>
								</fieldset>
							</div>
						</div>
					</asp:Panel>
				</div>
			</div>
				
			<!-- chiude la seconda sezione-->


			<asp:Panel ID="grpDocCollegato" runat="server">
				<div class="row">
					<div class="col-md-12">
						<fieldset>
							<legend>Documento collegato</legend>

							<asp:Panel ID="grpEtichetteDescrValuta" runat="server">
								<div class="row">
									<div class="col-md-8">
									</div>
									<div class="col-md-2">
										<label for="txtImportoDocValuta">in valuta</label>
									</div>
									<div class="col-md-2">
										<label for="txtImportoDocEUR">in €</label>
									</div>
								</div>
							</asp:Panel>

							<div class="row">
								<div class="col-md-1">
									<label for="">Documento</label>
								</div>
								<div class="col-md-3">
									<cc1:hwTextBox runat="server" ID="txtDocumento" CssClass="form-control" Tag="itinerationrefund.doc" TabIndex="6"></cc1:hwTextBox>
								</div>
								<div class="col-md-1">
									<label for="txtDataDoc">Data</label>
								</div>
								<div class="col-md-2">
									<div class="it-datepicker-wrapper theme-dark">
										<cc1:hwTextBox runat="server" ID="txtDataDoc" CssClass="form-control it-date-datepicker" data-date-format="dd/mm/yy" Tag="itinerationrefund.docdate.g" TabIndex="3"></cc1:hwTextBox>
									</div>
								</div>
								<div class="col-md-1">
									<label for="">Importo</label>
								</div>
								<div class="col-md-2">
									<cc1:hwTextBox runat="server" data-change_customfun="CalcImpDocEuro" ID="txtImportoDocValuta" Tag="itinerationrefund.docamount_c.fixed.8...1" CssClass="form-control" TabIndex="8"></cc1:hwTextBox>
								</div>
								<div class="col-md-2">
									<cc1:hwTextBox runat="server" ID="txtImportoDocEUR" CssClass="form-control" Tag="itinerationrefund.docamount.c" TabIndex="8"></cc1:hwTextBox>
								</div>
							</div>




						</fieldset>

					</div>
				</div>
			</asp:Panel>

			<!-- Importi -->
			<asp:Panel ID="grpImporti" runat="server">
				<div class="row">
					<div class="col-md-12 col-lg-8">
						<fieldset>
							<legend>Importo</legend>
							<asp:Panel ID="etichetteDescrizioneImporto" runat="server">
								<div class="row">
									<div class="col-4">
									</div>
									<div class="col-4">
										<label for="">in valuta</label>
									</div>
									<div class="col-4">
										<label for="">in €</label>
									</div>
								</div>
							</asp:Panel>

							<asp:Panel ID="PanelImportoRichiesto" runat="server">
								<div class="row">
									<div class="col-4">
										<label for="txtImportoRichiestoEUR">Richiesto</label>
									</div>
									<div class="col-4">
										<cc1:hwTextBox runat="server" data-change_customfun="CalcImpRichEuro" ID="txtImportoRichiestoValuta" Tag="itinerationrefund.requiredamount_c.fixed.8...1" TabIndex="9" CssClass="form-control"></cc1:hwTextBox>
									</div>
									<div class="col-4">
										<cc1:hwTextBox runat="server" ID="txtImportoRichiestoEUR" Tag="itinerationrefund.requiredamount.c" TabIndex="-1" CssClass="form-control"></cc1:hwTextBox>
									</div>
								</div>
							</asp:Panel>

							<asp:Panel ID="grpImportoAccordato" runat="server">
								<div class="row">
									<div class="col-4">
										<label for="txtImportoEffettivoEUR">Accordato</label>
									</div>
									<div class="col-4">
										<cc1:hwTextBox runat="server" data-change_customfun="CalcImpEffEuro" ID="txtImportoEffettivoValuta" Tag="itinerationrefund.amount_c.fixed.8...1" CssClass="form-control" ReadOnly="true" TabIndex="-1"></cc1:hwTextBox>
									</div>
									<div class="col-4">
										<cc1:hwTextBox runat="server" ID="txtImportoEffettivoEUR" Tag="itinerationrefund.amount.c" TabIndex="-1" CssClass="form-control"></cc1:hwTextBox>
									</div>
								</div>
							</asp:Panel>

							<asp:Panel ID="PanelImportoNonRendicontabile" runat="server">
								<div class="row">
									<div class="col-8">
										<label for="txtnoaccount">Importo non rendicontabile</label>
									</div>
									<div class="col-4">
										<cc1:hwTextBox runat="server" ID="txtnoaccount" CssClass="form-control" Tag="itinerationrefund.noaccount"></cc1:hwTextBox>
									</div>
								</div>
							</asp:Panel>
						</fieldset>
					</div>
				</div>

				<div class="row">
					<div class="col-md-6 col-lg-4">
						<asp:Panel ID="grpAnticipo" runat="server">
							<fieldset>
								<legend>Anticipo</legend>
								<div class="row">
									<div class="col-md-12">
										<label for="txtPercAnticipoItaliaEstero">Percentuale</label>
										<cc1:hwTextBox runat="server" ID="txtPercAnticipoItaliaEstero" CssClass="form-control" Tag="itinerationrefund.advancepercentage.fixed.4..%.100" TabIndex="10"></cc1:hwTextBox>
									</div>
								</div>
								<div class="row">
									<div class="col-md-12">
										<label for="txtAnticipo">Importo</label>
										<cc1:hwTextBox runat="server" ID="txtAnticipo" Tag="" TabIndex="-1" CssClass="form-control" ReadOnly="true"></cc1:hwTextBox>
									</div>
								</div>
							</fieldset>
						</asp:Panel>
					</div>
				</div>
			</asp:Panel>
			<!-- Fine Importi -->

			<br />

			<asp:Panel ID="grpResponsabile" runat="server">
				<div class="row">
					<div class="panel-group col-12">
						<div class="accordion">
							<h3>Comunicazione per il Responsabile</h3>
							<div id="tabComunicazioneResponsabileBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabComunicazioneResponsabileHead">
								<div class="panel-body row form-horizontal">
									<div class="col-md-12">
										<div class="row">
											<div class="col-12">
												<cc1:hwTextBox runat="server" ID="txtComunicazioni" Tag="itinerationrefund.webwarn" CssClass="form-control" TextMode="MultiLine" Rows="4" TabIndex="11"></cc1:hwTextBox>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</asp:Panel>
		</div>
		<div id="taballegati" class="tab-pane fade">
			<div title="Allegati">
				<div class="row">
					<div class="col-md-12">
						<asp:Panel ID="Panel2" runat="server">
							<div class="row">
								<div class="col-md-12">
									<cc1:hwButton ID="btnInsAllegato" runat="server" Tag="insert.default" Text="Inserisci" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
									<cc1:hwButton ID="HwEditAllegato" runat="server" Tag="edit.default" Text="Modifica" class="btn btn-info" TabIndex="220"></cc1:hwButton>
									<cc1:hwButton ID="HwCancAllegato" runat="server" Tag="delete.default" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
								</div>
							</div>
							<div class="row">
								<div class="col-md-12">
									<cc1:hwDataGridWeb ID="HwDataGridAllegati" runat="server" Tag="itinerationrefundattachment.single.default" TabIndex="240"></cc1:hwDataGridWeb>
								</div>
							</div>
						</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<script type="text/javascript">

    function CalcImpEffEuro() {
        var TassoCambio=null;
        var ImpEffValuta;
        ImpEffValuta = GetObjectFromString("Decimal", document.getElementById("<%=txtImportoEffettivoValuta.ClientID%>").value, "fixed.8...1");
        var tCambio = document.getElementById("<%=txtCambio.ClientID%>");
        if (tCambio) {
            TassoCambio = GetObjectFromString("Decimal", tCambio.value, "fixed.8...1");
        }

        if (ImpEffValuta == null) ImpEffValuta = new Object();
        if (TassoCambio == null) TassoCambio = new Object();

        if (ImpEffValuta.Obj == null) ImpEffValuta.Obj = 0;
        if (TassoCambio.Obj == null) TassoCambio.Obj = 1;

        var InEur = new Object();
        InEur.Obj = ImpEffValuta.Obj * TassoCambio.Obj;
        InEur.TypeName = "Decimal";

        document.getElementById("<%=txtImportoEffettivoEUR.ClientID%>").value = StringValue(InEur, "c.2...1");

        return;
    }

    function CalcImpRichEuro() {
        var TassoCambio;
        var ImpRichValuta;
        ImpRichValuta = GetObjectFromString("Decimal", document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value, "fixed.8...1");
        var tCambio = document.getElementById("<%=txtCambio.ClientID%>");
        if (tCambio) {
            TassoCambio = GetObjectFromString("Decimal", tCambio.value, "fixed.8...1");
        }

        if (ImpRichValuta == null) ImpRichValuta = new Object();
        if (TassoCambio == null) TassoCambio = new Object();

        if (ImpRichValuta.Obj == null) ImpRichValuta.Obj = 0;
        if (TassoCambio.Obj == null) TassoCambio.Obj = 1;

        var InEur = new Object();
        InEur.Obj = ImpRichValuta.Obj * TassoCambio.Obj;
        InEur.TypeName = "Decimal";
		document.getElementById("<%=txtImportoRichiestoEUR.ClientID%>").value = StringValue(InEur, "c.2...1");
        // Se l'importo richiesto in euro supera il limite max, imposta il richiesto uguale al limite
        <%-- 
        var LimiteMax;
        var LMax = document.getElementById("<%=txtLimiteMax.ClientID%>");
        
        if (LMax) {
            LimiteMax = GetObjectFromString("Decimal", LMax.value, "fixed.5...1");
        }
        if (LimiteMax == null) return;
        
        if ((LimiteMax.Obj > 0) && (InEur.Obj > LimiteMax.Obj)) {
            var newimportRich = new Object();
            newimportRich.Obj = LimiteMax.Obj;
            newimportRich.TypeName = "Decimal";
            document.getElementById("<%=txtImportoRichiestoEUR.ClientID%>").value = StringValue(newimportRich, "c.2...1");
            //valorizza importo richiesto in valuta
            if (TassoCambio.Obj == 1) {
                document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value = StringValue(newimportRich, "c.2...1");
            }
            else {
                var newRichiestoValuta = new Object();
                newRichiestoValuta.Obj = LimiteMax.Obj / TassoCambio.Obj;//se null viena impostato a 1
                newRichiestoValuta.TypeName = "Decimal";
                document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value = StringValue(newRichiestoValuta, "c.2...1");
            }
        }
        else {
            document.getElementById("<%=txtImportoRichiestoEUR.ClientID%>").value = StringValue(InEur, "c.2...1");
        }       --%>
        return;
    }

    function CalcImpDocEuro() {
        var TassoCambio;
        var ImpDocValuta;
        ImpDocValuta = GetObjectFromString("Decimal", document.getElementById("<%=txtImportoDocValuta.ClientID%>").value, "fixed.8...1");
        var tCambio = document.getElementById("<%=txtCambio.ClientID%>");
        if (tCambio) {
            TassoCambio = GetObjectFromString("Decimal", tCambio.value, "fixed.8...1");
        }

        if (ImpDocValuta == null) ImpDocValuta = new Object();
        if (TassoCambio == null) TassoCambio = new Object();

        if (ImpDocValuta.Obj == null) ImpDocValuta.Obj = 0;
        if (TassoCambio.Obj == null) TassoCambio.Obj = 1;

        var InEur = new Object();
        InEur.Obj = ImpDocValuta.Obj * TassoCambio.Obj;
        InEur.TypeName = "Decimal";

        document.getElementById("<%=txtImportoDocEUR.ClientID%>").value = StringValue(InEur, "c.2...1");
		document.getElementById("<%=txtImportoRichiestoEUR.ClientID%>").value = StringValue(InEur, "c.2...1");
		document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value = StringValue(ImpDocValuta, "fixed.8...1");
        // Se l'importo documento in euro supera il limite max, imposta il richiesto uguale al limite
<%--        var LimiteMax;
        var LMax = document.getElementById("<%=txtLimiteMax.ClientID%>");
        
        if (LMax) {
            LimiteMax = GetObjectFromString("Decimal", LMax.value, "fixed.5...1");
        }
        if (LimiteMax == null) return;
        if ((LimiteMax.Obj > 0) && (InEur.Obj > LimiteMax.Obj)) {
            var newimportRich = new Object();
            newimportRich.Obj = LimiteMax.Obj;
            newimportRich.TypeName = "Decimal";
            document.getElementById("<%=txtImportoRichiestoEUR.ClientID%>").value = StringValue(newimportRich, "c.2...1");
            //valorizza importo richiesto in valuta
            if(TassoCambio.Obj == 1){
                document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value = StringValue(newimportRich, "c.2...1");
            }
            else{
                var newRichiestoValuta = new Object();
                newRichiestoValuta.Obj = LimiteMax.Obj / TassoCambio.Obj;//se null viena impostato a 1
                newRichiestoValuta.TypeName = "Decimal";
                document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value = StringValue(newRichiestoValuta, "c.2...1");
            }
        }
        else {
            document.getElementById("<%=txtImportoRichiestoEUR.ClientID%>").value = StringValue(InEur, "c.2...1");
            document.getElementById("<%=txtImportoRichiestoValuta.ClientID%>").value = StringValue(ImpDocValuta, "c.2...1");
        }--%>
        return;

    }

</script>

</asp:Content>