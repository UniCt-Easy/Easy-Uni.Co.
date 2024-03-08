<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="mandate_default_new02.aspx.cs" Inherits="mandate_default_new02" Title="Richiesta d'ordine" %>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <cc1:hwButton ID="B1" runat="server" Text="Ordina per stato" Tag="maindosearch.webdefaultstatuses" class="btn btn-primary" />
            <cc1:hwButton ID="B2" runat="server" Text="Storico Buoni  Approvati" Tag="approvati" class="btn btn-primary" OnClick="B2_Click" />
            <!-- da rivedere la posizione    -->
        </div>
    </div>

    <!-- da rivedere la posizione    -->
    <div  id="showAvanzaStatoShow" class ="modal fade">
        <div class="modal-dialog" style="width: 50%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div  class="modal-body">
                    <div id='showAvanzaStatoBody'></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Chiudi</button>     
                </div>
            </div>
        </div>
    </div>

    <ul id="mainTabControl" class="nav nav-tabs nav-justified">
        <li><a data-toggle="tab" href="#tabmain">Principale</a></li>
        <li><a data-toggle="tab" href="#tabdettagli">Dettagli</a></li>
        <li><a data-toggle="tab" href="#tabmagazzino">Magazzino</a></li>
        <li><a data-toggle="tab" href="#taballegati">Allegati</a></li>
        <li ID="liconsip" runat="server" ClientIDMode="static"><a data-toggle="tab" href="#tabconsip">CONSIP</a></li>
        <li><a data-toggle="tab" href="#tabpericolosita">Pericolosità</a></li>
    </ul>

    <div class="tab-content">
        <div id="tabmain" class="tab-pane fade in active">
            <div class="row">
                <div class="col-12">
                    <div class="row">
                        <div class="col-md-6 mt-md-3">
                            <label for="DrpStatus">Stato Corrente</label>
                            <cc1:hwDropDownList ID="DrpStatus" CssClass="form-control" Tag="mandate.idmandatestatus?mandateview.idmandatestatus" runat="server" AutoPostBack="True" TabIndex="40"></cc1:hwDropDownList>
                        </div>
                        <div class="col-6 col-md-4 mt-md-5 mt-3">
                            <label for="btnAvanzaStato"></label>
                            <asp:Button runat="server" ID="btnAvanzaStato" class="btn btn-primary" Tag="" Text="" ToEnable="True" Visible="False" />
                        </div>
                        <div class="col-6 col-md-2 mt-md-5 mt-3 text-right">
                            <cc1:hwButton ID="btnStampaOrdine"  runat="server" Tag="stampaordine" class="btn btn-primary" Text="Stampa Ordine" Visible="False"></cc1:hwButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label for="idmankind">Tipo contratto</label>
                            <cc1:hwDropDownList ID="idmankind" Tag="mandate.idmankind" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="10"></cc1:hwDropDownList><br />
                        </div>
                        <div class="col-6 col-md-3">
                            <label for="yman">Esercizio</label>
                            <cc1:hwTextBox ID="yman" runat="server" CssClass="form-control" Tag="mandate.yman.year" TabIndex="20"></cc1:hwTextBox>
                        </div>
                        <div class="col-6 col-md-3">
                            <label for="nman">Numero</label>
                            <cc1:hwTextBox ID="nman" runat="server" CssClass="input-md form-control" Tag="mandate.nman" TabIndex="30"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Responsabile del fondo</legend>
                                <div class="row">
                                    <div class="col-md-12 autochoose">
                                        <cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" ID="grpResponsabile" runat="server" Tag="AutoChoose.txtResponsabile.lista.(financeactive='S')">
                                            <cc1:hwButton ID="btnResponsabile" runat="server" Text="Responsabile" class="btn btn-primary" Tag="choose.manager.lista.(active='S')" />
                                            <cc1:hwTextBox TabIndex="20" ID="txtResponsabile" CssClass="form-control input-md" Tag="manager.title?x" runat="server"></cc1:hwTextBox>
                                        </cc1:hwPanel>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <label for="description">Descrizione</label>
                            <cc1:hwTextBox CssClass="input-md form-control" TextMode="MultiLine" Rows="3" runat="server" ID="description" Tag="mandate.description" TabIndex="90"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label for="cigcode">Codice Identificativo di Gara(CIG)</label>
                            <cc1:hwTextBox CssClass="form-control" ID="cigcode" runat="server" TabIndex="140" Tag="mandate.cigcode"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="adate" class="control-label">Data contabile</label>
                            <cc1:hwTextBox TabIndex="230" CssClass="form-control" ID="adate" runat="server" Tag="mandate.adate"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <cc1:hwPanel GroupingText="Fornitore" CssClass="stdfieldset form-group" ID="HwPanel2" runat="server" Tag="AutoChoose.txtCredDeb.lista.(active='S')">
                                <div class="row">
                                    <div class="col-md-12">
                                        <cc1:hwTextBox ID="txtCredDeb" runat="server" CssClass="form-control input-md" TabIndex="80" Tag="registrymainview.title?mandateview.registry"></cc1:hwTextBox>
                                    </div>
                                </div>
                            </cc1:hwPanel>
                        </div>
                        <div class="col-md-6 mt-md-2">
                            <label for="applierannotations">Note del richiedente</label>
                            <cc1:hwTextBox TabIndex="130" ID="applierannotations" runat="server" CssClass="form-control"
                                        Rows="5"
                                        Tag="mandate.applierannotations" TextMode="MultiLine"></cc1:hwTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mt-5">
                            <label for="txtregistryreference">Riferimento</label>
                            <cc1:hwTextBox TabIndex="120" ID="txtregistryreference" runat="server" CssClass="form-control"
                                        Rows="4"
                                        Tag="mandate.registryreference" TextMode="MultiLine"></cc1:hwTextBox>
                        </div>
                        <div class="col-md-6 mt-3">
                            <fieldset>
                                <legend></legend>
                                <div class="row">
                                    <div class="col-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label for="txtimponibile" class="control-label">Imponibile</label>
                                            </div>
                                            <div class="col-md-12">
                                                <cc1:hwTextBox TabIndex="200" class="form-control" ID="txtimponibile" runat="server" ReadOnly="True" Style="text-align: right"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label for="txtiva" class="control-label">Iva</label>
                                            </div>
                                            <div class="col-md-12">
                                                <cc1:hwTextBox TabIndex="210" CssClass="form-control" ID="txtiva" runat="server" ReadOnly="True" Style="text-align: right"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6 offset-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label for="txttotale" class="control-label">Totale</label>
                                            </div>
                                            <div class="col-md-12">
                                                <cc1:hwTextBox TabIndex="220" CssClass="form-control" ID="txttotale" runat="server" ReadOnly="True" Style="text-align: right"></cc1:hwTextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
			
            <div class="row">
                <div class="col-md-6">

                    <div class="row">
                        <div class="panel-group col-12">
                            <div class="accordion">
                                <h3>Ufficio</h3>
                                <div id="tabUfficioCollegatoBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabDocumentoCollegatoHead">
                                    <div class="panel-body row form-horizontal">
                                        <div class="col-md-6">
                                                <label for="officecode">Codice Ufficio</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="officecode" runat="server" Tag="office.code?mandateview.officecode" TabIndex="60"></cc1:hwTextBox><br />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="officedescription">Ufficio</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="officedescription" runat="server" Tag="office.description?mandateview.officedescription" TabIndex="70"></cc1:hwTextBox><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="panel-group col-12">
                            <div class="accordion">
                                <h3>Documento Collegato</h3>
                                <div id="tabDocumentoCollegatoBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabDocumentoCollegatoHead">
                                    <div class="panel-body row form-horizontal">
                                        <div class="col-md-6">
                                            <label for="doc">Documento</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="doc" runat="server" Tag="mandate.doc" TabIndex="60"></cc1:hwTextBox><br />
                                        </div>
                                        <div class="col-md-6">
                                            <label for="docdate">Data</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="docdate" runat="server" Tag="mandate.docdate" TabIndex="70"></cc1:hwTextBox><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="panel-group col-12">
                            <div class="accordion">
                                <h3>Consegna</h3>
                                <div id="tabConsegnaBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabConsegnaHead">
                                    <div class="panel-body row form-horizontal">
                                        <div class="col-md-12">
                                            <label for="hwdeliveryexpiration">Termine</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="hwdeliveryexpiration" runat="server" Tag="mandate.deliveryexpiration" TabIndex="100"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                    <div class="panel-body row">
                                        <div class="col-md-12">
                                            <label for="Hwdeliveryaddress">Indirizzo</label>
                                            <cc1:hwTextBox TabIndex="110" class="form-control" ID="Hwdeliveryaddress" runat="server" Tag="mandate.deliveryaddress" TextMode="MultiLine"></cc1:hwTextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="row">
                        <div class="panel-group col-12">
                            <div class="accordion">
                                <h3>Scadenza</h3>
                                <div id="tabScadenzaBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabScadenzaHead">
                                    <div class="panel-body row form-horizontal">
                                        <div class="col-md-8">
                                            <label for="idexpirationkind">Tipo</label>
                                            <cc1:hwDropDownList ID="idexpirationkind" CssClass="form-control" Tag="mandate.idexpirationkind" runat="server" AutoPostBack="True" TabIndex="150"></cc1:hwDropDownList>
                                        </div>
                                        <div class="col-md-4">
                                            <label for="paymentexpiring">Scadenza</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="paymentexpiring" runat="server" Tag="mandate.paymentexpiring" TabIndex="160"></cc1:hwTextBox><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="panel-group col-12">
                            <div class="accordion">
                                <h3>Valuta</h3>
                                <div id="tabValutaBody" class="panel-collapse collapse" role="tabpanel" aria-labelledby="tabValutaHead">
                                    <div class="panel-body row form-horizontal">
                                        <div class="col-md-6">
                                            <label for="idcurrency">Valuta</label>
                                            <cc1:hwDropDownList ID="idcurrency" CssClass="form-control" Tag="mandate.idcurrency" runat="server" AutoPostBack="True" TabIndex="170"></cc1:hwDropDownList>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="exchangerate">Tasso di Cambio</label>
                                            <cc1:hwTextBox CssClass="form-control" ID="exchangerate" runat="server" Tag="mandate.exchangerate.fixed.5...1" TabIndex="180"></cc1:hwTextBox><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div id="tabdettagli" class="tab-pane fade">
            <div title="Dettagli">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwButton ID="HwButton1" runat="server" Tag="insert.defaultnew02" Text="Inserisci" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
                                    <cc1:hwButton ID="HwBtnInsCopia" data-gridcmd="maininsertcopy" runat="server" Tag="copiadettaglio" Text="Inserisci Copia" class="btn btn-primary" TabIndex="215"></cc1:hwButton>
                                    <cc1:hwButton ID="btnedit" runat="server" Tag="edit.defaultnew02" Text="Modifica" class="btn btn-info" TabIndex="220"></cc1:hwButton>
                                    <cc1:hwButton ID="HwButton2" runat="server" Tag="delete.defaultnew02" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwDataGridWeb ID="datagridDettagli" runat="server" Tag="mandatedetail.lista.single" TabIndex="240"></cc1:hwDataGridWeb>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <div id="tabmagazzino" class="tab-pane fade">
            <div title="Magazzino">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="Panel4" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <cc1:hwButton runat="server" ID="btnMagazzino" Tag="choose.store.default" Text="Magazzino" class="btn btn-primary" TabIndex="209"></cc1:hwButton>
                                        </div>
                                        <div class="col-md-6">
                                            <cc1:hwDropDownList CssClass="form-control" runat="server" ID="cmbmagazzino" Tag="mandate.idstore" AutoPostBack="True" TabIndex="50"></cc1:hwDropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <div id="taballegati" class="tab-pane fade">
            <div title="Allegati">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="Panel2" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwButton ID="btnInsAllegato" runat="server" Tag="insert.defaultnew02" Text="Inserisci" class="btn btn-primary" TabIndex="210"></cc1:hwButton>
                                    <cc1:hwButton ID="HwEditAllegato" runat="server" Tag="edit.defaultnew02" Text="Modifica" class="btn btn-info" TabIndex="220"></cc1:hwButton>
                                    <cc1:hwButton ID="HwCancAllegato" runat="server" Tag="delete.defaultnew02" Text="Elimina" class="btn btn-danger" TabIndex="230"></cc1:hwButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwDataGridWeb ID="HwDataGridAllegati" runat="server" Tag="mandateattachment.lista.default" TabIndex="240"></cc1:hwDataGridWeb>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <div id="tabconsip" runat="server" ClientIDMode="static" class="tab-pane fade">
            <div title="Consip" id="Tab1Folder3">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="Panel3" runat="server">
                            <div class="row">
                            <p>Informazioni su <a href="#" onclick="window.open('http://www.acquistinretepa.it')">https://www.acquistinretepa.it/</a> </p>
                            </div>
                            <div class="row">
                            <asp:Label ID="LabelConsip" runat="server" for="cmbConsip" Text="Label"></asp:Label>
                            <br />
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwDropDownList ID="cmbConsip" data-id="cmbConsip"  Tag="mandate.idconsipkind" runat="server" OnSelectedIndexChanged="cmbConsip_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True" TabIndex="250"></cc1:hwDropDownList><br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10">
                                    <cc1:hwTextBox CssClass="form-control" data-id="txtConsipMotive"  TextMode="MultiLine" Rows="6" ID="txtConsipMotive"  runat="server" Tag="mandate.consipmotive" TabIndex="100"></cc1:hwTextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button id="btnConsip" runat="server" UseSubmitBehavior="false" Text="Modifica" OnClientClick="javascript:doModifica();return false;" ></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                            <asp:Label ID="LabelConsipExt" runat="server" for="cmbConsipExt" Text="Label"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <cc1:hwDropDownList ID="cmbConsipExt" Tag="mandate.idconsipkind_ext" OnSelectedIndexChanged="cmbConsipExt_SelectedIndexChanged" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="250"></cc1:hwDropDownList><br />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <div id="tabpericolosita" class="tab-pane fade">
            <div title="Pericolosità">
                <div class="row">
                    <div class="col-md-12">
                        <!-- Riga vuota-->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwCheckBox runat="server" ID="HwCheckDanger" ThreeState="false" Tag="mandate.flagdanger:S:N" Text="Riguarda materiale pericoloso/radioattivo" TabIndex="501"></cc1:hwCheckBox>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div id="myModal" class="modal fade">
        <div class="modal-dialog" style="width: 100%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Dichiarazione consip</h4>
                </div>
                <div id='ConsipDynBody' class="modal-body">
                    <div class="form-group">
                        <label for="consipMotiveArea">Descrizione</label>
                        <textarea id="consipMotiveArea" readonly data-id="consipMotiveArea" class="form-control input-lg" rows="3"></textarea>                    
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Annulla</button>
                    <button type="button" class="btn btn-primary" onclick="saveConsip();">Ok</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


    <asp:Content ContentPlaceHolderID="JScriptAfterLibs"  runat="server">
    
    <script type="text/javascript">
		var template, consipMotive, ctrlList = [], tokenList, ctrlDynCount = 0;

		function saveConsip() {
			var res = $('[data-id="consipMotiveArea"]').val();
			$('[data-id="txtConsipMotive"]').val(res);
			$("#myModal").modal('hide');
			destroyModifica();
		}

		function avanzastato(idcustomuser, idflowchart, idmankind, yman, nman) {
            /*
            Mostra i stati di avanzamento della richiesta.
            Effettua una chiamata AJAX alla pagina
            ManageAvanzamentoStati.aspx con parametro action = call_nexgetnextoffice. 
            La chiamata restituisce il tag del button cliccato dal cliente.
            */
			var xmlHttpObj = CreateXmlHttpRequestObject();
			XMLRequestURL = "ManageAvanzamentoStati.aspx?action=call_getnextoffice&idcustomuser='" + idcustomuser + "'&idflowchart='" + idflowchart + "'&idmankind='" + idmankind + "'&yman=" + yman + "&nman=" + nman;
			xmlHttpObj.open("GET", XMLRequestURL, false);
			var doc = xmlHttpObj.responseXML;
			xmlHttpObj.send(null);

			xslHttpObj = CreateXmlHttpRequestObject();
			xslHttpObj.open("GET", XSLTRequestURL, false);
			var stylesheet = xslHttpObj.responseXML;
			xslHttpObj.send(null);

			var xsltProc = CreateXSLTProcessObject();

			if (window.ActiveXObject || "ActiveXObject" in window) {
				//Questo codice è stato aggiunto perchè usando IE l'istr.:doc.transformNode(stylesheet); sporcava il documento, facendo fallire: if (HTML=="***"), successivo,
				if (doc.getElementsByTagName("htmlcode")[0].text == "***") {
					var HTML = "***";
				}
				else {
					var HTML = doc.transformNode(stylesheet);
				}
			}
			else {
				xsltProc.importStylesheet(xslHttpObj.responseXML);
				//TotalPages and PageTitle No longer used -- All the Table is created on the server
				var html = xsltProc.transformToFragment(xmlHttpObj.responseXML, document);
				var HTML = new XMLSerializer().serializeToString(html);
				// Strip Unwanted chars (FF)
				HTML = HTML.replace(/&amp;/gi, "&");
				HTML = HTML.replace(/&lt;/gi, "<");
				HTML = HTML.replace(/&gt;/gi, ">");
			}


			if (HTML == "***") {
				__doPostBack('do_command', "scelta.0");
			}
			else {
				$('#showAvanzaStatoBody').html(HTML);
				$("[data-getnext]").click(doCmd);
				$("#showAvanzaStatoShow").modal('show');
			}
		}

		function initModifica() {
			for (var i = 0; i < ctrlList.length; i++) {
				$("#" + ctrlList[i]).off('change', UpdateTemplateFromControls).remove();
			}
			$("[data-id='consipDyinamiContainer']").remove();
			ctrlList = [];
			tokenList = [];
			ctrlDynCount = 0;
		}



		function addLabel(targetDiv, token, target) {
			var $label = $("<label>").text(token).attr("for", target)
			targetDiv.append($label);
		}

		function addCombo(targetDiv, token, list) {
			var myDiv = $('<div> </div>').addClass('form-group');

			var idCombo = 'idComboConsipDyn' + ctrlDynCount;
			addLabel(myDiv, token, idCombo);
			var s = $('<select id="' + idCombo + '" data-id="' + token + '" />').addClass('form-control').on('change', UpdateTemplateFromControls);
			for (var val in list) {
				$('<option />', { value: val, text: list[val] }).appendTo(s);
			}
			ctrlList[ctrlDynCount] = idCombo;
			tokenList[ctrlDynCount] = token;
			ctrlDynCount += 1;
			myDiv.append(s);
			targetDiv.append(myDiv);
		}
		function addTextBox(targetDiv, token, tipo) {
			var myDiv = $('<div> </div>').addClass('form-group');
			var idTxt = 'idtxtConsipDyn' + ctrlDynCount;
			addLabel(myDiv, token, idTxt);
			if (tipo === 'c' || tipo === 'n') {
				if (tipo === 'c') {
					s = $('<input data-enterdec="c" id="' + idTxt + '" data-id="' + token + '" />')
						.on('focus', GenEnterDec).on('change', GenLeaveNoTagDec)
						.addClass('form-control').on('change', UpdateTemplateFromControls);
				}
				else {
					s = $('<input data-enternum="n" id="' + idTxt + '" data-id="' + token + '" />')
						.on('focus', GenEnterNum).on('change', GenLeaveNoTagNum)
						.addClass('form-control').on('change', UpdateTemplateFromControls);
				}

			}
			else {
				s = $('<textarea id="' + idTxt + '" data-id="' + token + '" />').addClass('form-control').on('change', UpdateTemplateFromControls);
			}
			ctrlList[ctrlDynCount] = idTxt;
			tokenList[ctrlDynCount] = token;
			ctrlDynCount += 1;
			myDiv.append(s);
			targetDiv.append(myDiv);
		}
		var suspendUpdate = false;
		function doModifica() {
			suspendUpdate = true;
			initModifica();
			var idConsip = $('[data-id="cmbConsip"] ').val();
			var conKind = ConsipList.find(function (el) { return el.key == idConsip; })

			template = conKind.val
			consipMotive = $('[data-id="txtConsipMotive"]').val();
			FillControlsFromTemplate(template);

			var start = decodifica(template, consipMotive); //Dictionary<string, string> 
			for (var k in start) {
				if (start[k] == '%<' + k + '>%') {
					start[k] = '';
				};
			}
			UpdateTemplateFromDictionary(start);
			$('[data-id="consipMotiveArea"]').text(consipMotive);
			suspendUpdate = false;

			$("#myModal").modal('show');
		}


		function FillControlsFromTemplate(templ) {
			var mainDiv = $('<div data-id="consipDyinamiContainer">');
			var tokens = calcola(templ);
			for (var i = 0; i < tokens.length; i++) {
				var str = tokens[i];
				var sl = str.toLowerCase();
				if (sl === 'categoria') {
					//add a combo 
					addCombo(mainDiv, str, ConsipCategoryList);
				}
				else {
					var tipo = "g";
					if (sl.indexOf("€") >= 0 || sl.indexOf("euro") >= 0 || sl.indexOf("importo") >= 0
						|| sl.indexOf("prezzo") >= 0 || sl.indexOf("costo") >= 0) {
						tipo = "c";
					}
					if (sl.indexOf("quantità") >= 0 || sl.indexOf("quantita") >= 0 || sl.indexOf("numero") >= 0) {
						tipo = "n";
					}
					//add a textbox
					addTextBox(mainDiv, str, tipo);
				}
			}
			$('#ConsipDynBody').append(mainDiv);
		}

		function UpdateTemplateFromControls() {
			if (suspendUpdate) return;
			var s = template;
			for (var i = 0; i < tokenList.length; i++) {
				var k = tokenList[i];
				var valore;
				if (k.trim().toLowerCase() == "categoria") {
					if ($('#' + ctrlList[i]).val() !== null) {
						valore = $('#' + ctrlList[i]).find('option:selected').text();
						s = s.replace("%<" + k + ">%", valore);
					}
				}
				else {
					valore = $('#' + ctrlList[i]).val();
					s = s.replace("%<" + k + ">%", valore);
				}
			}

			consipMotive = s;
			$('[data-id="consipMotiveArea"]').val(s);

		}

		function calcola(s) {
			var l = [];
			var start = 0, index = s.indexOf('%<', start);
			while (index > 0) {
				var closing = s.indexOf(">%", index + 2);
				if (closing < 0) break;
				l.push(s.substr(index + 2, closing - (index + 2)));
				start = index + 2;
				index = s.indexOf("%<", start);
			}
			return l;
		}

		//restituisce un Dictionary<string, string>
		function decodifica(template, s) {
			var l = calcola(template); //string[]
			var res = {}; //Dictionary<string, string>
			var r = new RegExp(calcolaRegExp(template));
			var groups = r.exec(s);
			for (var i = 1; i <= l.length; i++) {
				res[l[i - 1]] = groups[i];
			}

			return res;
		}


		function UpdateTemplateFromDictionary(start) {
			for (var k in start) {
				var i = tokenList.indexOf(k);
				if (k.trim().toLowerCase() === "categoria") {
					$('#' + ctrlList[i] + " option").each(
						function (index) {
							this.selected = ($(this).text() === start[k]);
							return;
						});
				} else {
					$('#' + ctrlList[i]).val(start[k]);
				}
			}

		}
		function regExpEscape(s) {
			return s.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
		}
		function calcolaRegExp(template) {
			var R = "";
			var start = 0;
			var index = template.indexOf("%<", start);
			var lastPos = 0;
			while (index > 0) {
				if (lastPos != index) {
					if (lastPos == 0) {
						//R = "^";
					}
					var before = template.substr(lastPos, index - lastPos);
					R += regExpEscape(before);
				}
				var closing = template.indexOf(">%", index + 2);
				if (closing < 0) break;
				R += "([\\w\\W]*)";
				start = closing + 2;
				lastPos = start;
				index = template.indexOf("%<", start);
			}
			if (lastPos < template.length) {
				R += regExpEscape(template.substr(lastPos));
			}
			return R;
		}
	</script>


</asp:Content>
