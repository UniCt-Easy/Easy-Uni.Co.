//in questa personalizzazione di easyweb se una pagina è stata scrollata, 
//si apre la pagina di dettaglio e si ritorna alla pagina precedente 
// si perde la posizione di scroll che è un problema per l'utente
//utilizziamo un cookie per memorizzare la posizione di scroll

//var elementScrollIntoView = "";

$(document).click(function (event) {
    setCookie("scrollsave", "");
    var id = event.target.id;
    if (id == "") {
        id = event.target.parentNode.id;
        if (id == "") {
            id = event.target.parentNode.parentNode.id;
            if (id == "") {
                id = event.target.parentNode.parentNode.parentNode.id;
                if (id == "") {
                    id = event.target.parentNode.parentNode.parentNode.parentNode.id;
                }
            }
        }
    }
    if (id != "") {
        var a = $("#" + id).offset().top;
        var b = $(window).scrollTop();
        var st = parseInt(a) - parseInt(b)
        setCookie("scrollsave", id);
        setCookie("scrolletop", st);
    }
});

$(document).ready(function() {
    var id = getCookie("scrollsave");
    var st = getCookie("scrolletop");
    if (id != "") {
        var eTop = $("#" + id).offset().top;
        var curr = parseInt(eTop) - parseInt(st);
        $(window).scrollTop(curr);
    }
});