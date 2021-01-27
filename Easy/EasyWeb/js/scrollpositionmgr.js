//in questa personalizzazione di easyweb se una pagina è stata scrollata, 
//si apre la pagina di dettaglio e si ritorna alla pagina precedente 
// si perde la posizione di scroll che è un problema per l'utente
//utilizziamo un cookie per memorizzare la posizione di scroll

$(document).ready(function() {
    var s=getCookie("scrollsave");
	//console.log(s + ' - ' + $('form').attr('action'));
    //se c'è il cookie
    if ( s != "" ) {
        //splitto il cookie per avere scroll e nome
        var p=s.split("§");
		var act=$('form').attr('action');
		act=act.replace('./', '')
        //se la pagina è quella di cui abbiamo salvato lo scroll
		//console.log(p[1] + ' = ' + $('form').attr('action') + ' -> ' + (p[1] == act));
        if (p[1] == act) {
            //eseguo lo scroll
			console.log("scrolltop" + p[0]);
            $(document).scrollTop( p[0] );
            //cancello il cookie perchè ho scrollato
			console.log("cancello cookie");
            setCookie("scrollsave", "");
        }
    }

    //prima di lasciare la pagina se ho scrollato salvo lo scroll in un cookie
    $(window).on("beforeunload", function() {
		//console.log("beforeunload");
        if ($(document).scrollTop() > 0) {
			var act=$('form').attr('action');
			act=act.replace('./', '')
			//console.log("setcookie");
            setCookie("scrollsave", $(document).scrollTop() + "§" + act);
        }
    });
});