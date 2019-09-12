function Tent(pTextBox) {
    /*
    Evento client collegato generalmente all’evento focus del textbox pTextBox. 
    Ha il solo compito di cambiare classe del CSS globale di pTextBox (masterpage.css), 
    sostituendo quella base con “focused”.    
    */

    if (pTextBox == null) return;
    if (pTextBox.readOnly) return;
    $("#" + pTextBox.id).addClass("focused");

    $(".lastfocused").removeClass("lastfocused");
    $("#" + pTextBox.id).addClass("lastfocused");
};


function Tlv(pTextBox) {
    /*
    Evento client collegato generalmente all’evento blur del textbox pTextBox. 
    Ha il solo compito di cambiare classe del CSS globale di pTextBox (masterpage.css), 
    sostituendola con “” (che precedentemente era impostata su “focused”).    
    */

    if (pTextBox == null) return;
    if (pTextBox.readOnly) return;
    if (pTextBox.disabled) return;

    $("#" + pTextBox.id).removeClass("focused");

};



function StPrv(pTextBox) {
    /*
    Rientra nella gestione dell'elenco. Memorizza il valore precedente del textbox pTextBox in
    ElmPreviousValue (textbox nascosto - variabile globale istanziata a runtime) sulla base di
    ElmPreservePreviousValue
    */
    //alert('preserve vale:'+document.getElementById(ElmPreservePreviousValue).value);

    if (!document.getElementById(ElmPreservePreviousValue)) return;

    var lPreservePreviousValue = (document.getElementById(ElmPreservePreviousValue).value == "S" ? true : false);
    if (!lPreservePreviousValue) {
        //alert('memorizzo:'+pTextBox.value);
        document.getElementById(ElmPreviousValue).value = pTextBox.value;
        return true;
    }
    else {
        document.getElementById(ElmPreservePreviousValue).value = 'N';
        return false;
    }
};

function TMod(pTextBox) {
    /*
    Ritorna true se il testo di pTextBox risulta modificato rispetto al contenuto del textbox
    ElmPreviousValue.
    */
    if (document.getElementById(ElmPreviousValue).value == pTextBox.value) {
        //i valori sono uguali
        if (TextBoxIdForList == pTextBox.id && !RecordIsSelected && pTextBox.value != '')
            return true;
        else
            return false;
    }
    else
        return true;
};


function EnableClientContent() {
    //f += "alert('enable client content: imposto preserve a S');\r\n";
    //if (document.getElementById(ElmPreservePreviousValue))
    //    document.getElementById(ElmPreservePreviousValue).value = 'S';

    //enable($('#_ctl0_CHP_PC_DIV'));
    //enable($('#_ctl0_ToolBar_Div'));
    //enable($('#_ctl0_Div_CHPList'));

    //for(el in ShowClientMessage_disabled){
    // el.disabled=true;
    //};





    return false;
}




function disable_divs_atstart() {
    disable_at_start($("#_ctl0_CHP_PC_DIV"), ShowClientMessage_disabled);
    disable_at_start($("#_ctl0_ToolBar_Div"), ShowClientMessage_disabled);
    disable_at_start($("#_ctl0_Div_CHPList"), ShowClientMessage_disabled);
};



function DisableControls() {
    /*
    Disabilita i controlli del Content, della toolbar e dell'elenco principale
    utilizzando le div globali (i cui id vengono istanziati a runtime):
    - ElmContent per il form principale;
    - ElmToolbar per la toolbar dei comandi;
    - ElmList per l'elenco principale.
    Richiama la disable_at_start
    */
    if (document.getElementById(ElmContent) != null)
        disable_at_start(document.getElementById(ElmContent), ControlsArray);
    if (document.getElementById(ElmToolbar) != null)
        disable_at_start(document.getElementById(ElmToolbar), ControlsArray);
    if (document.getElementById(ElmList) != null)
        disable_at_start(document.getElementById(ElmList), ControlsArray);
    return;
};


function EnableControls() {
    /*
    Abilita i controlli del Content, della toolbar e dell'elenco principale
    utilizzando le div globali (i cui id vengono istanziati a runtime):
    - ElmContent per il form principale;
    - ElmToolbar per la toolbar dei comandi;
    - ElmList per l'elenco principale.
    Richiama la enable
    */

    if (document.getElementById(ElmContent) != null)
        enable(document.getElementById(ElmContent));
    if (document.getElementById(ElmToolbar) != null)
        enable(document.getElementById(ElmToolbar));
    if (document.getElementById(ElmList) != null)
        enable(document.getElementById(ElmList));
    return;
};


function disable_at_start(el, arr_dis) {
    /*
    Disabilita ricorsivamente la collection di controlli el.
    */
    if (el == null) return;

    try {
        if (el.disabled)
            arr_dis.push(el);
        else
            el.disabled = true;
    }
    catch (E) { }
    if (el.childNodes && el.childNodes.length > 0) {
        for (var x = 0; x < el.childNodes.length; x++) {
            disable_at_start(el.childNodes[x], arr_dis);
        }
    }
};



function disable(el) {
    /*
    Disabilita ricorsivamente la collection di controlli el
    */
    if (!el) return;
    try {
        el.disabled = true;
    } catch (E) { }
    if (el.childNodes && el.childNodes.length > 0) {
        for (var x = 0; x < el.childNodes.length; x++) {
            disable(el.childNodes[x]);
        }
    }
};

function enable(el) {
    /*
    Abilita ricorsivamente la collection di controlli el    
    */
    if (!el) return;
    if (el.classname) {
        el.className = el.className.replace(new RegExp('(^|\\s)ui-state-disabled(\\s|$)'), ' ');
        el.disabled = false;
    }

    if (el.childNodes && el.childNodes.length > 0) {
        for (var x = 0; x < el.childNodes.length; x++) {
            enable(el.childNodes[x]);
        }
    }
};


function hide(x) {
    /*
    Nasconde il controllo x
    */
    $('#' + x).hide('slide', {}, 1000, null);
    //document.getElementById(x).style.display='none';
    return false;
};

function show(x) {
    /*
    Mostra il controllo x
    */
    $('#' + x).show('slide', {}, 1000, null);
    //document.getElementById(x).style.display='';
    return false;
};


