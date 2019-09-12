<%@ Page Language="C#" MasterPageFile="~/MetaMasterBootstrap.master" AutoEventWireup="true" CodeFile="vetrina_default_new02.aspx.cs" Inherits="vetrina_default_new02"  Title=""%>

<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CHP_PC" runat="Server">

    <div class="row">
        <div class="col-md-5">
            <div class="row">
                <cc1:hwPanel GroupingText="Vetrine Disponibili" CssClass="gbox scheduler-border form-group" Style="text-align: center;" ID="grpVetrina" runat="server" Tag="">
                    <div class="row">
                        <cc1:hwLabel runat="server" ID="lbl01" Text="Cliccare sul nome della vetrina per selezionarla:"></cc1:hwLabel>
                    </div>
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="showcases"></asp:PlaceHolder>
                    </div>
                </cc1:hwPanel>
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
                    <cc1:hwLabel runat="server" ID="HwLabel1" Text="Per prenotare gli articoli in carrello, utilizzare il pulsante 'Chiudi'"></cc1:hwLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <cc1:hwLabel runat="server" ID="HwLabel2" Text="Per abilitare la funzione di ricerca del browser premere Ctrl+F o F3"></cc1:hwLabel>
                </div>
            </div>
        </div>

        <div class="col-md-7">
            <cc1:hwPanel GroupingText="" CssClass="gbox scheduler-border form-group" Style="text-align: center;" ID="HwPanel1" runat="server" Tag="">
                <div class="row">
                    <div class="col-md-12">
                        <cc1:hwLabel runat="server" ID="titoloVetrina" Text="Selezionare una vetrina dall'elenco"></cc1:hwLabel>
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

    <div class="row">
        <div class="col-md-12">
            <div id="addtocart" style="text-align: left; ">
            </div>
        </div>
    </div>


   

   <div  id="showCaseShow" class ="modal fade">
    <div class="modal-dialog" style="width: 100%">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Carrello attuale</h4>
            </div>
            <div  class="modal-body">
                <div id='showCaseBody'></div>
            

            
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal">Ok</button>                
            </div>
        </div>
    </div>
   </div>
  
    <div  id="showCaseEmpty" class ="modal fade">
    <div class="modal-dialog" >
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Svuotamento carrello</h4>
            </div>
            <div  class="modal-body">
                <p>Si desidera svuotare il carrello corrente?</p>
            

            
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-primary" onclick="doemptycart();">Si</button>   
                   <button id="btnAnnullaSvuota" type="button" class="btn btn-primary" data-dismiss="modal">No</button>                
            </div>
        </div>
    </div>
   </div>
  

     <div  id="showCaseEmptyDone" class ="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Svuotamento carrello</h4>
            </div>
            <div  class="modal-body">
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

    function addtocart(pid, idstore, price, idstock) {
        /*
        Funzione legata all'evento click del pulsante "Aggiungi" associato a ciascun articolo.
        Crea una popup (div floating) che riassume l'articolo che si sta per aggiungere al carrello
        contenente due pulsanti "Procedi" e "Annulla"
        */
        var outhtml = "";
        var units = document.getElementById("quant" + idstock).value;
        if (units == null) return;
        var nunits = parseInt(units);
        var idstore = parseInt(idstore);
        if (nunits == 0 || nunits == null || nunits < 0) return;

        doaddtocart(pid, units, idstore, price, idstock);

     
    }


    function doaddtocart(pid, nunits, idstore, price, idstock) {
        /*
        Funzione associata all'onclick del pulsante "Procedi". Aggiunge, mediante chiamata AJAX alla
        pagina "ManageCart.aspx" l'articolo avente id pid, con quantità nunits e magazzino idstore.
        La suddetta pagina restituirà un messaggio di ritorno, che notifica l'avvenuto inserimento 
        dell'articolo.  
        */
        var xmlHttpObj = CreateXmlHttpRequestObject();
        XMLRequestURL = "ManageCart.aspx?action=add&idlist=" + pid + "&units=" + nunits + "&idstore=" + idstore + "&price=" + price + "&idstock=" + idstock;

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


        /*
           $("#addtocart").hide("slow");
           $('#addtocart').html( HTML );
           $('#addtocart').show("fast").animate("slow");
        */


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

