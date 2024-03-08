//in questa personalizzazione di easyweb se una pagina è stata scrollata, 
//si apre la pagina di dettaglio e si ritorna alla pagina precedente 
// si perde la posizione di scroll che è un problema per l'utente
//utilizziamo un cookie per memorizzare la posizione di scroll

$(document).click(function (event) {
    var i=1;
    var id = getParentId(event.target, i);
	
    if ((id != "") && (id!=undefined)) {
		var a = $("#" + id).offset().top;
		var b = $(window).scrollTop();
		var st = parseInt(a) - parseInt(b);
		setCookie("scrollsave", id);
		setCookie("scrolletop", st);
    }
});

function getParentId(ele, i)
{
	if(i > 15)
		return "";
	
	if(ele.id == "mainhwlist")
		return "";
	
	if (ele.id == "")
		return getParentId(ele.parentNode, i++);
	
	return ele.id;
}

$(document).ready(function() {
    var id = getCookie("scrollsave");
    var st = getCookie("scrolletop");
    if (id != "") {
        var eTop = $("#" + id).offset().top;
        var curr = parseInt(eTop) - parseInt(st);
        $(window).scrollTop(curr);
		document.getElementById('__SCROLLPOSITIONY').value = curr;
    }
});