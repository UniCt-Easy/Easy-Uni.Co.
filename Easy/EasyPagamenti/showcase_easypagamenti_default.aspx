<%@ Page Title="" Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="showcase_easypagamenti_default.aspx.cs" Inherits="showcase_easypagamenti_default" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" runat="Server">
    <div class="row">
        <div class="col-md-4">
            <div class="row">
				<div class="col-md-12">
					<cc1:hwPanel GroupingText="Cataloghi Disponibili" CssClass="gbox scheduler-border form-group" Style="text-align: center;" ID="grpVetrina" runat="server" Tag="">
						<div class="row">
							<div class="col-md-12">
								<cc1:hwLabel runat="server" ID="lbl01" Text="Cliccare sul nome della Sezione per selezionarla:"></cc1:hwLabel>
							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<asp:PlaceHolder runat="server" ID="showcases"></asp:PlaceHolder>
							</div>
						</div>
					</cc1:hwPanel>
				</div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <button type="button" id="btnMostraCarello" class="btn btn-primary btn-block" onclick="javascript:showcart();">Mostra Carrello</button>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <button type="button" id="btnSvuotaCarrello" class="btn btn-primary btn-block" onclick="javascript:emptycart();">Svuota Carrello</button>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwLabel runat="server" ID="HwLabel1" Text="Per aggiungere la voce al carrello, utilizzare il pulsante 'Chiudi' oppure 'Vai a Pagamento'"></cc1:hwLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwButton ID="Pagamento" runat="server" Tag="VaiAPagamento" Text="Vai a Pagamento" Style="width: 100%;"></cc1:hwButton>
                </div>
            </div>

            <div class="row">
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwLabel runat="server" ID="HwLabel2" Text="Per abilitare la funzione di ricerca del browser premere Ctrl+F o F3"></cc1:hwLabel>
                </div>
            </div>
        </div>

        <div class="col-md-8">
            <cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" Style="text-align: center;" ID="HwPanel1" runat="server" Tag="">
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwLabel runat="server" ID="titoloVetrina" Text="Selezionare una Sezione dall'elenco"></cc1:hwLabel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwLabel ID="lblStore" runat="server"></cc1:hwLabel>
                        <!--  Magazzino:   -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwLabel ID="LabAddress" runat="server"></cc1:hwLabel>
                        <!--  Indirizzo: -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:PlaceHolder runat="server" ID="items"></asp:PlaceHolder>
                    </div>
                </div>
            </cc1:hwPanel>

        </div>

    </div>


    <div id="addtocart" class="modal fade">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="modal-dialog" style="width: 100%">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Messaggio</h4>
                        </div>
                        <div class="modal-body">
                            <div id='addtocartbody'></div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        

    <div id="showMessagePrezzoUnitario" class="modal fade" role="dialog">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="modal-dialog" style="width: auto">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Avviso</h4>
                        </div>
                        <div class="modal-body">
                            <p>Specificare il prezzo Unitario</p>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="showMessagePrezzoUnitarioAnn" class="modal fade" role="dialog">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="modal-dialog" style="width: auto">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Avviso</h4>
                        </div>
                        <div class="modal-body">
                            <p>Specificare la descrizione aggiuntiva richiesta</p>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   


    <div id="showCaseShow" class="modal fade">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="modal-dialog" style="width: 100%">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Carrello corrente</h4>
                        </div>
                        <div class="modal-body">
                            <div id='showCaseBody'></div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
    <div id="showCaseEmpty" class ="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Svuotamento Carrello</h4>
                </div>
                <div class="modal-body">
                    <p>Si desidera svuotare il carrello corrente?</p>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onclick="doemptycart();">Si</button>
                    <button id="btnAnnullaSvuota" type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
   </div>
  

    <div id="showCaseEmptyDone" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Svuotamento Carrello</h4>
                </div>
                <div class="modal-body">
                    <div id="showCaseEmptyDoneMsg"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content2"  ContentPlaceHolderID="JScriptAfterLibs"  runat="server">
<script type="text/javascript">
    function inc(ptxt) {
        /*
        Incrementa il valore del contenuto di ptxt
        E' associata al pulsante "+"  di ciascun articolo della vetrina
        */
        var val = document.getElementById(ptxt).value;
        var num = parseInt(val);
        num++;
        document.getElementById(ptxt).value = num;
    }

    function dec(ptxt) {
        /*
        Decrementa il valore del contenuto di ptxt
        E' associata al pulsante "-"  di ciascun articolo della vetrina
        */

        var val = document.getElementById(ptxt).value;
        var num = parseInt(val);
        num--;
        if (num < 0) return;
        document.getElementById(ptxt).value = num;
        
    }

    function visualizza_messaggio() {
        $("#showMessagePrezzoUnitario").modal("show");
    }

    function visualizza_messaggioAnn() {
        $("#showMessagePrezzoUnitarioAnn").modal("show");
    }

	function addtocart(pid, idstore, price, idstock, idupb, idestimkind, paymentexpiring, idivakind, annotations, insinfo, straliquota, idinvkind, competencystart, competencystop, idupb_iva, idshowcase, idsor1, idsor2, idsor3) {
        /*
        Funzione legata all'evento click del pulsante "Aggiungi" associato a ciascun articolo.
        Crea una popup (div floating) che riassume l'articolo che si sta per aggiungere al carrello
        contenente due pulsanti "Procedi" e "Annulla"
        */
        var aliquota = parseFloat(straliquota.replace(',', '.'))
        var outhtml = "";
        var units = document.getElementById("quant" + idstock).value;
        if (units == null) return;
        var nunits = parseInt(units);
        var idstore = parseInt(idstore);
        var idivakind = parseInt(idivakind);
        if (nunits == 0 || nunits == null || nunits < 0) return;

        if (insinfo == "S") {
            //var oAnnotation = GetObjectFromString("String", annotations, "dataannotation.2...1").Obj;
            var InputAnnotations = document.getElementById("annotations" + idstock).value;
            //var a = escape(encodeURIComponent(InputAnnotations));  // ~!@#$&*()=:/,;?+'
            if (InputAnnotations == null || InputAnnotations == "") {
                visualizza_messaggioAnn();
                return;
            }
        }

        var iva = 0;
        var oPrice = GetObjectFromString("Decimal", price, "fixed.2...1").Obj;
        if (oPrice == 0) {
            var InputPrice = document.getElementById("price" + idstock).value;
            if (InputPrice == null) {                
                return;
            }
            var qPrice = GetObjectFromString("Decimal", InputPrice, "fixed.2...1");
            if (qPrice == null || qPrice.Obj == 0 || qPrice.Obj < 0) {
                visualizza_messaggio();
                return;
            }
            oPrice = qPrice.Obj;
            //si aspetta prezzo ivato inserito dal cliente quindi scorpora iva
            var imponibile = oPrice / (((aliquota * 100) + 100) / 100)
            iva = oPrice - imponibile;
            oPrice = imponibile;
        } else {
            //il prezzo era pre-inserito quindi imponibile
            iva = oPrice * aliquota;
        }
        //alert(oPrice);  //sempre imponibile
        //alert(iva);
		doaddtocart(pid, units, idstore, oPrice, idstock, idupb, idestimkind, paymentexpiring, idivakind, escape(encodeURIComponent(InputAnnotations)), insinfo, iva, idinvkind, competencystart, competencystop, idupb_iva, idshowcase, idsor1, idsor2, idsor3);
    }


	function doaddtocart(pid, nunits, idstore, price, idstock, idupb, idestimkind, paymentexpiring, idivakind, annotations, insinfo, iva, idinvkind, competencystart, competencystop, idupb_iva, idshowcase, idsor1, idsor2, idsor3) {
        /*
        Funzione associata all'onclick del pulsante "Procedi". Aggiunge, mediante chiamata AJAX alla
        pagina "ManageCart.aspx" l'articolo avente id pid, con quantità nunits e magazzino idstore.
        La suddetta pagina restituirà un messaggio di ritorno, che notifica l'avvenuto inserimento 
        dell'articolo.  
        */
        var xmlHttpObj = CreateXmlHttpRequestObject();
        var oPrice = { TypeName: "Decimal", Obj: price };
        var oIva = { TypeName: "Decimal", Obj: iva };
        XMLRequestURL = "ManageCart.aspx?action=add&idlist=" + pid + "&units=" + nunits + "&idstore=" + idstore + "&price="
                        + StringValue(oPrice, "fixed.2...1") + "&idstock=" + idstock
                        + "&idupb=" + idupb + "&idestimkind=" + idestimkind + "&paymentexpiring=" + paymentexpiring + "&idivakind=" + idivakind + "&annotations=" +
                        annotations + "&insinfo=" + insinfo + "&iva=" + StringValue(oIva, "fixed.2...1") +
            "&idinvkind=" + idinvkind + "&competencystart=" + competencystart + "&competencystop=" + competencystop + "&idupb_iva=" + idupb_iva + "&idshowcase=" + idshowcase +
			"&idsor1=" + idsor1 + "&idsor2=" + idsor2 + "&idsor3=" + idsor3;

        xmlHttpObj.open("GET", XMLRequestURL, false);
        var doc = xmlHttpObj.responseXML;
        xmlHttpObj.send(null);

        xslHttpObj = CreateXmlHttpRequestObject();
        xslHttpObj.open("GET", XSLTRequestURL, false);
        var stylesheet = xslHttpObj.responseXML;
        xslHttpObj.send(null);

        var xsltProc = CreateXSLTProcessObject();
        if (window.ActiveXObject || "ActiveXObject" in window) {
            var HTML = doc.transformNode(stylesheet);

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
            $("#addtocartbody").html(HTML);
            $("#addtocart").modal("show");
        return;
    }

    function canceladd() {
        /*
        Nel caso in cui si prema il pulsante annulla, viene nascosta la div
        che mostra il messaggio di conferma dell'inserimento degli articoli
        nel carrello.
        */

        //$('#addtocart').html( "" );
        //$('#addtocart').hide('slide',{},500,null);
        document.getElementById("addtocart").style.display = "none";
        //EnableControls();

        return;
    }

    function showcart() {
        /*
        Mostra il carrello corrente. Effettua una chiamata AJAX alla pagina
        ManageCart.aspx con parametro action=show. La chiamata restituisce la
        situazione corrente del carrello.
        */
        var xmlHttpObj = CreateXmlHttpRequestObject();
        XMLRequestURL = "ManageCart.aspx?action=show";

        xmlHttpObj.open("GET", XMLRequestURL, false);
        var doc = xmlHttpObj.responseXML;
        xmlHttpObj.send(null);

        xslHttpObj = CreateXmlHttpRequestObject();
        xslHttpObj.open("GET", XSLTRequestURL, false);
        var stylesheet = xslHttpObj.responseXML;
        xslHttpObj.send(null);

        var xsltProc = CreateXSLTProcessObject();
        if (window.ActiveXObject || "ActiveXObject" in window) {
            var HTML = doc.transformNode(stylesheet);
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
            $(":text[data-enterdec]").focus(GenEnterDec).change(GenLeaveNoTagDec);

        }

        $('#showCaseBody').html(HTML);
        $("#showCaseShow").modal('show');
    }

    function emptycart() {
        $("#showCaseEmpty").modal('show');
      

    }

    function doemptycart() {
        $("#showCaseEmpty").modal('hide');

        /*
        Funzione collegata all'onclick del pulsante "Ok" mostrato dalla funzione precedente.
        Effettua una chiamata AJAX alla pagina ManageCart.aspx con parametro action=empty
        Restituisce un messaggio al termine dell'operazione che notifica l'avvenuto 
        svuotamento del carrello.
        */
        var xmlHttpObj = CreateXmlHttpRequestObject();
        XMLRequestURL = "ManageCart.aspx?action=empty";

        xmlHttpObj.open("GET", XMLRequestURL, false);
        var doc = xmlHttpObj.responseXML;
        xmlHttpObj.send(null);

        xslHttpObj = CreateXmlHttpRequestObject();
        xslHttpObj.open("GET", XSLTRequestURL, false);
        var stylesheet = xslHttpObj.responseXML;
        xslHttpObj.send(null);

        var xsltProc = CreateXSLTProcessObject();
        if (window.ActiveXObject || "ActiveXObject" in window) {
            var HTML = doc.transformNode(stylesheet);
        }
        else {
            xsltProc.importStylesheet(xslHttpObj.responseXML);
            //TotalPages and PageTitle No longer used -- All the Table is created on the server
            var html = xsltProc.transformToFragment(xmlHttpObj.responseXML, document);
            var HTML = new XMLSerializer().serializeToString(html);

            HTML = HTML.replace(/&amp;/gi, "&");
            HTML = HTML.replace(/&lt;/gi, "<");
            HTML = HTML.replace(/&gt;/gi, ">");
        }

        
        //DisableControls();
        $('#showCaseEmptyDoneMsg').html(HTML);
        $("#showCaseEmptyDone").modal('show')
        return;

    }
</script>
</asp:Content>