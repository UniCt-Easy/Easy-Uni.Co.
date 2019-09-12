<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="vetrina_default.aspx.cs" Inherits="vetrina_default" Title="Vetrina" %>
<%@ Register Assembly="HelpWeb" Namespace="HelpWeb" TagPrefix="HelpWeb" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">
<table width="100%">
<tr>
<td style="width:20%;"  valign="top">
<fieldset>
<legend>Vetrine Disponibili</legend>
    <br />
    Cliccare sul nome della vetrina per selezionarla:<br />
    <br />
<center><asp:PlaceHolder runat="server" ID="showcases"></asp:PlaceHolder></center>
</fieldset>
<br />
<center><input style="width:140px;" type="button" value="Mostra Carrello" onclick="showcart();"/>
<br /><br />
<input type="button" style="width:140px;" value="Svuota Carrello" onclick="emptycart();"/>
<br />
</center>
    <center>
        &nbsp;</center>
    <center>
        Per prenotare gli articoli in carrello, utilizzare il pulsante "Chiudi"<br />
        Per abilitare la funzione di ricerca del browser premere Ctrl+F o F3<br />
    </center>
</td>
<td style="width:80%;"  valign="top">
<center>
        <asp:Label runat="server" id="titoloVetrina" Font-Size="Medium" Text="Selezionare una vetrina dall'elenco" Font-Bold="False"></asp:Label>&nbsp;</center>
    <center>
        &nbsp;</center>
    <center><asp:Label ID="lblStore" runat="server"></asp:Label>&nbsp;</center>
    <center><asp:Label ID="LabAddress" runat="server" ></asp:Label>&nbsp;</center>
<asp:PlaceHolder runat="server" ID="items">
</asp:PlaceHolder>
</td>
</tr>
</table>



<div id="addtocart" style="	overflow: auto;max-height:900px; 
        border:1px solid grey; text-align:left; position: fixed;  display: none; 
        background-color: #dadada; width: auto; left: auto; top:20%;font-size:13px;">

</div>
</asp:Content>


<asp:Content  ContentPlaceHolderID="JScriptAfterLibs"  runat="server">
<script type="text/javascript">
function inc(ptxt)
{
    /*
    Incrementa il valore del contenuto di ptxt
    E' associata al pulsante "+"  di ciascun articolo della vetrina
    */
    var val=document.getElementById(ptxt).value;
    var num=parseInt(val);
    num++;
    document.getElementById(ptxt).value=num;
}

function dec(ptxt)
{
    /*
    Decrementa il valore del contenuto di ptxt
    E' associata al pulsante "-"  di ciascun articolo della vetrina
    */

    var val=document.getElementById(ptxt).value;
    var num=parseInt(val);
    num--;
    if(num<0)return;
    document.getElementById(ptxt).value=num;
}

function addtocart(pid,idstore,price,idstock)
{
    /*
    Funzione legata all'evento click del pulsante "Aggiungi" associato a ciascun articolo.
    Crea una popup (div floating) che riassume l'articolo che si sta per aggiungere al carrello
    contenente due pulsanti "Procedi" e "Annulla"
    */
    var outhtml="";
    var units=document.getElementById("quant"+idstock).value;
    if(units==null) return;
    var nunits=parseInt(units);
    var idstore=parseInt(idstore);
    if(nunits==0||nunits==null||nunits<0) return;
    
    doaddtocart(pid,units,idstore,price,idstock);
    
    /*

    outhtml+="<div style=\"width:100% ;background-color: blue; color: white;\"><center><strong>Attenzione</strong></center></div><br>";
    outhtml+="<center>Si stanno aggiungendo i seguenti articoli al carrello:<br><br>";
    outhtml+="<strong>Codice:</strong>"+code+"<br><br> <strong>Descrizione:</strong> "+unescape(description)+"<br><br> <strong>Quantità</strong>:"+units+"<br><br><br>";
    outhtml+="<input id=\"btnadd\" type=\"button\" value=\"Procedi\" onclick=\"doaddtocart(" + pid + ","+ units + "," + idstore +",'"+price+ "',"+idstock+");\">&nbsp;&nbsp;";
    outhtml+="<input type=\"button\" value=\"Annulla\" onclick=\"canceladd();\"></center><br>";
    
    var addtocartdiv=document.getElementById("addtocart");
    //DisableControls();
    addtocartdiv.disabled=false;
    
    $('#addtocart').html( outhtml );
    //$('#addtocart').show('fast','slide',null);
    document.getElementById("addtocart").style.display="block";

    document.getElementById("btnadd").focus();
    //enable(document.getElementById("addtocart"));
    
    */
    return;
}


function doaddtocart(pid,nunits,idstore,price,idstock)
{
    /*
    Funzione associata all'onclick del pulsante "Procedi". Aggiunge, mediante chiamata AJAX alla
    pagina "ManageCart.aspx" l'articolo avente id pid, con quantità nunits e magazzino idstore.
    La suddetta pagina restituirà un messaggio di ritorno, che notifica l'avvenuto inserimento 
    dell'articolo.  
    */
    var xmlHttpObj = CreateXmlHttpRequestObject();
    XMLRequestURL="ManageCart.aspx?action=add&idlist="+pid+"&units="+nunits+"&idstore="+idstore+"&price="+price+"&idstock="+idstock;

    xmlHttpObj.open("GET",XMLRequestURL, false);
    var doc = xmlHttpObj.responseXML;
    xmlHttpObj.send(null);

    xslHttpObj = CreateXmlHttpRequestObject();
    xslHttpObj.open("GET",XSLTRequestURL, false);
    var stylesheet = xslHttpObj.responseXML;
    xslHttpObj.send(null);

    var xsltProc=CreateXSLTProcessObject();
    if (window.ActiveXObject || "ActiveXObject" in window)
    {
        var HTML = doc.transformNode(stylesheet);

    }
    else
    {
        xsltProc.importStylesheet(xslHttpObj.responseXML);
        //TotalPages and PageTitle No longer used -- All the Table is created on the server
        var html = xsltProc.transformToFragment(xmlHttpObj.responseXML,document);
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

function canceladd()
{
    /*
    Nel caso in cui si prema il pulsante annulla, viene nascosta la div
    che mostra il messaggio di conferma dell'inserimento degli articoli
    nel carrello.
    */
   
    //$('#addtocart').html( "" );
    //$('#addtocart').hide('slide',{},500,null);
	document.getElementById("addtocart").style.display="none";
    //EnableControls();
    
    return;
}

function showcart()
{
    /*
    Mostra il carrello corrente. Effettua una chiamata AJAX alla pagina
    ManageCart.aspx con parametro action=show. La chiamata restituisce la
    situazione corrente del carrello.
    */
    var xmlHttpObj = CreateXmlHttpRequestObject();
    XMLRequestURL="ManageCart.aspx?action=show";

    xmlHttpObj.open("GET",XMLRequestURL, false);
    var doc = xmlHttpObj.responseXML;
    xmlHttpObj.send(null);

    xslHttpObj = CreateXmlHttpRequestObject();
    xslHttpObj.open("GET",XSLTRequestURL, false);
    var stylesheet = xslHttpObj.responseXML;
    xslHttpObj.send(null);

    var xsltProc=CreateXSLTProcessObject();
    if (window.ActiveXObject || "ActiveXObject" in window){    
        var HTML = doc.transformNode(stylesheet);
    }
    else
    {
        xsltProc.importStylesheet(xslHttpObj.responseXML);
        //TotalPages and PageTitle No longer used -- All the Table is created on the server
        var html = xsltProc.transformToFragment(xmlHttpObj.responseXML,document);
        var HTML = new XMLSerializer().serializeToString(html);
        // Strip Unwanted chars (FF)
        HTML = HTML.replace(/&amp;/gi, "&");
        HTML = HTML.replace(/&lt;/gi, "<");
        HTML = HTML.replace(/&gt;/gi, ">");

    }
    
    
    //DisableControls();
    document.getElementById("addtocart").innerHTML="";
    document.getElementById("addtocart").disabled=false;
	$("#addtocart").hide("slow"); 
    $('#addtocart').html( HTML );
	$('#addtocart').show("fast").animate("slow");
    //document.getElementById("addtocart").style.display="block";
    //enable(document.getElementById("addtocart"));
    document.getElementById("btnok").focus();
    
    return;    
}

function emptycart()
{
    /*
    Funzione collegata all'evento click del pulsante "svuota carrello". Mostra un box di conferma.
    */
    var outhtml="";

    outhtml+="<div style=\"width:100% ;background-color: blue; color: white;\"><center><strong>Attenzione</strong></center></div><br>";
    outhtml+="<br><center>Si desidera svuotare il carrello corrente?<br><br>";
    outhtml+="<input type=\"button\" value=\"Ok\" onclick=\"doemptycart();\">&nbsp;&nbsp;";
    outhtml+="<input type=\"button\" value=\"Annulla\" onclick=\"canceladd();\"></center><br>";
    
    var addtocartdiv=document.getElementById("addtocart");
    //DisableControls();
    addtocartdiv.disabled=false;
    
    addtocartdiv.innerHTML=outhtml;
    //$('#addtocart').show('fast','slide',null);
    document.getElementById("addtocart").style.display="block";

    //enable(addtocartdiv);
    return;
    
}

function doemptycart()
{
    /*
    Funzione collegata all'onclick del pulsante "Ok" mostrato dalla funzione precedente.
    Effettua una chiamata AJAX alla pagina ManageCart.aspx con parametro action=empty
    Restituisce un messaggio al termine dell'operazione che notifica l'avvenuto 
    svuotamento del carrello.
    */
    var xmlHttpObj = CreateXmlHttpRequestObject();
    XMLRequestURL="ManageCart.aspx?action=empty";

    xmlHttpObj.open("GET",XMLRequestURL, false);
    var doc = xmlHttpObj.responseXML;
    xmlHttpObj.send(null);

    xslHttpObj = CreateXmlHttpRequestObject();
    xslHttpObj.open("GET",XSLTRequestURL, false);
    var stylesheet = xslHttpObj.responseXML;
    xslHttpObj.send(null);

    var xsltProc=CreateXSLTProcessObject();
    if (window.ActiveXObject || "ActiveXObject" in window)
    {
        var HTML = doc.transformNode(stylesheet);
    }
    else
    {
        xsltProc.importStylesheet(xslHttpObj.responseXML);
        //TotalPages and PageTitle No longer used -- All the Table is created on the server
        var html = xsltProc.transformToFragment(xmlHttpObj.responseXML,document);
        var HTML = new XMLSerializer().serializeToString(html);

        HTML = HTML.replace(/&amp;/gi, "&");
        HTML = HTML.replace(/&lt;/gi, "<");
        HTML = HTML.replace(/&gt;/gi, ">");
    }
    
    
    //DisableControls();
    
    //$('#addtocart').hide('fast','slide',null);
    document.getElementById("addtocart").style.display="none";

    document.getElementById("addtocart").innerHTML="";
    document.getElementById("addtocart").disabled=false;
    document.getElementById("addtocart").innerHTML=HTML;
    //$('#addtocart').show('fast','slide',null);
    document.getElementById("addtocart").style.display="block";

 //enable(document.getElementById("addtocart"));
    
    return;    

}
</script>

</asp:Content>

