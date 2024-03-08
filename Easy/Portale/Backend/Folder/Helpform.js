//Gets the Nth field in a list of dot separated fields
function GetField(S, N) {
    if (S === null) return null;
    S = S.trim();  
    try {
        var Field = S.split('.');
        if (Field.length > N) {
            return Field[N].trim();
        }
        else {
            return null;
        }
    } catch (e) {
        return null;
    }
}


//Get ComboBox Tag gives parenttable.parentfield
function GetLookup(tag) {
    if (tag === null) return null;
    var S = tag.trim();
    var pos = S.indexOf(':');
    if (pos === -1) return S;
    var tablecolumn = S.substring(0, pos).trim();
    if (tablecolumn.indexOf('.') === -1) return null;
    return tablecolumn;
}


/* ds dataset
   el elemento da riempire
*/
function fillControl(ds,el) {
    var tag = $(el).data("tag");
    var Table = GetField(tag, 0);
    var Column = GetField(tag, 1);
    //alert("Tabella = " + Table + ", Colonna = " + Column + ".");
    console.log( "Tabella = " + Table + ", Colonna = " + Column + ".");
    
    // 1) scegliere la tabella nel dataset  >>ottengo un DataTable
    // 2) scegliere la riga nella tabella >>  table.lastSelectedRow ove table è il DataTable  >> DataRow >>prima riga
    // 3) prendere il valore dalla colonna  >>object con il relativo tipo
    // 4) formattarlo in base a... tag, tipo del dato    >>
    // 5) mettere il valore formattato nel textbox  >> $(el).text("valore");
    
}

/* ds dataset
   container elemento i cui discendenti saranno riempiti
*/
function fillControls(ds, container) {
    //document.getElementById("contenitore");
    //$('[id*="contenitore"]').each(function () {
    //    alert("Controllo: " + this);
    //    if (!div(this)) { fillControl(this); } 
    //});
    var kids = $(container)
            .find('data(tag)')
            .each(function ()
            {
                fillControl(ds, this);
            });

}





$("#container").click(function (event) {
    $("*").removeClass("hilite");
    var kids = $(event.target).children();
    var len = kids.addClass("hilite").length;

    $("#results span:first").text(len);
    $("#results span:last").text(event.target.tagName);

    event.preventDefault();
});