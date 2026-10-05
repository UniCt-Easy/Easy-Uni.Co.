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
		setCookie(cookiePageName + "scrollsave", id);
		setCookie(cookiePageName + "scrolletop", st);
    }

	
});

window.addEventListener('beforeunload', function (e) {
	var activeHeaders = document.querySelectorAll('.ui-accordion-header.active');
	var texts = Array.from(activeHeaders).map(el => el.textContent.trim());
	var accordions = texts.join(',');
	if (accordions != "") {
		setCookie(cookiePageName + "accordions", accordions);
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
	var accordions = getCookie(cookiePageName + "accordions");
	if (accordions != "") {
		var targetTexts = accordions.split(',').map(text => text.trim());
		document.querySelectorAll('.ui-accordion-header').forEach(header => {
		  if (targetTexts.includes(header.textContent.trim())) {
			header.classList.add('active');
			var next = header.nextElementSibling;
			if (next) {
			  next.classList.add('active');
			}
		  }
		});
	}
	requestAnimationFrame(() => {
		var id = getCookie(cookiePageName + "scrollsave");
		var st = getCookie(cookiePageName + "scrolletop");
		if (id != "") {
			var eTop = $("#" + id).offset().top;
			var curr = parseInt(eTop) - parseInt(st);
			$(window).scrollTop(curr);
			document.getElementById('__SCROLLPOSITIONY').value = curr;
		}
	});
});