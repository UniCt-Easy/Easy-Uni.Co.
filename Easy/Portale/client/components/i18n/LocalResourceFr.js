
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


/**
 * @module LocalResourceFr
 * @description
 * Collection of the localized strings . FRANCAISE
 */
(function () {

    /**
     * @constructor LocalResourceFr
     * @description
     */
    function LocalResourceFr() {
        "use strict";
    }

    LocalResourceFr.prototype = {
        constructor: LocalResourceFr,
        error : "Erreur",
        alert : "Avertissement",
        ok : "Ok",
        of : "de",
        cancel : "Annulation",
        eliminate : "Cancellation",
        confirm: "Confirmation",
        close : "Fermè",
        changesUnsaved : "Ci sono modifiche ai dati non salvate. Si desidera perdere le modifiche?",
        emptyKeyMsg : "Un campo chiave non può essere vuoto o duplicato.",
        emptyFieldMsg : "Un determinato campo non può essere vuoto.",
        stringTooLong : "Campo troppo lungo",
        noDataSelected : "Aucun date selection" ,

        start: 'Debut',
        end: 'Fin',
        infoevent: 'Info event',

        networkConnectionError : "Errore di connessione con il server. Controllare la connessione e riprovare",
        itemChooseNotSelectable : "La voce scelta non potoeva essere selezionata",

        rowSelectedNoMoreInDb : "La riga selezionata non è più presente nel db",
        noElementFound:"Nessun elemento trovato",

        sameValuesForTheKey: "E' stata inserita una riga con la stessa chiave primaria di un altra esistente. " +
        " E' necessario modificare i dati immessi per salvarli.",

        noPrimaryDataSelected: "Nessuna riga principale selezionata",
        selectRowInAGrid: "Seleziona una riga da modificare",

        requiredRow_not_found: "Riga richesta non trovata sul tree",
        selectedRowIsNotOperative: "La riga selezionata non è operativa",

        // label bottoni standard
        editButton : "Corrige",
        deleteButton : "Annule",
        insertButton : "Ajoute",
        unlinkButton : "Unlink",

        // form title suffux
        searchTitle : "Recherche",
        changeTitle : "Changez",
        insertTitle : "Insertion",

        // Main Command button label, la chiave è il tag
        mainsetsearch : "Allè a la recherche",
        maindosearch : "Recherche",
        maininsert : "Neuf",
        maininsertcopy : "Créer une copie",
        mainsave : "Sauve",
        mainselect : "Sélection",
        maindelete : "Eliminè",
        editnotes : "Edita Note",
        mainclose : "Fermeè",
        showlast: "ligne information",

        emptyField: "Svuota campi",

        isValidFieldMandatory: "Attenzione! Il campo S%field%S è obbligatorio",
        isValidMaxLength: "Attenzione! il campo S%field%S è al massimo di S%maxlenght%S caratteri",

        multiSelect_addRows: "Aggiungi",
        multiSelect_removeRows : "Rimuovi",
        multiSelect_addRowsTitle: "Da aggiungere",
        multiSelect_toolbarButtonsTitle:  "E' possibile selzionare_ TODO",
        multiSelect_lbl_toAdd: "Da aggiungere",
        multiSelect_lbl_added: "Aggiunti",
        multiSelect_lbl_descrtiption: "Ctrl/Shift + Click &egrave; possibile selezionare o deselezionare una o pi&ugrave; righe di un elenco. \<BR\> Con il tasto destro &egrave; possibile selezionare o deselezionare tutte le righe di un elenco",
        multiSelect_lbl_wait: "Attendi caricamento delle tabelle",

        procedureMessage_btn_nosave : "Non salvare",
        procedureMessage_btn_ignoreandsave : "Ignora i messaggi e salva lo stesso",
        procedureMessage_modal_title: "Elenco errori ed avvertimenti",

        // header columns
        prodMess_id: "Id",
        prodMess_lonMsg: "Messaggio",
        prodMess_type: "Tipo",

        // messaggi su indicatori di attesa
        loader_waitListLoading:"Caricamento lista dei risultati",

        modalLoader_wait_search: "Ricerca in corso",
        modalLoader_wait_save: "Salvataggio in corso",
        modalLoader_wait_insertcopy: "Copia in corso, attendi per modificare e salvare",
        modalLoader_wait_metapage_loading: "Caricamento pagina",
        modalLoader_wait_metapageDetail_loading: "Caricamento pagina di dettaglio",
        modalLoader_wait_insert: "Creazione nuova riga, attendi prima di poter modificare",
        modalLoader_wait_delete: "Cancellazione della riga selezionata in corso",
        modalLoader_wait_page_update:"Attendi aggiornamento pagina",
        modalLoader_wait_tree_updating: "Aggiornamento albero",
        modalLoader_wait_tree_node_search : "Ricerca nodo sull'albero",
        modalLoader_wait_unlink_row : "Unlink della riga selezionata",
        modalLoader_wait_valuesSearching : "Ricerca valori in corso",

        // server error
        serverUnracheable: "Rete non disponibile, o web server non raggiungibile ",
        serverErrorInternal : "Errore interno nel server, metodo: ",

        saveSuccesfully: "Dati salvati correttamente",

        adding_row: "Aggiungo riga..",
        newEvent: "Nuovo evento per",

        calendarWrongConfig: "La tabella del calendario non contiene le giuste colonne configurate. Contatta lo sviluppatore!",
        calendarNotRowCorrect : "Nel controllo calendario gli eventi non sono oggetti della tabella. Contatta lo sviluppatore!",
        agenda : "Agenda",
        details: "Dettagli",

        // Attachment
        download_attach: "Scarica allegato",
        upload_attach : "Carica",
        noAttachmentToUpload: "Devi specificare un allegato!",
        attachment : "allegato",
        tableAttachNotAvailable: "Non è presente la colonna S%cname%S sulla tabella principale della pagina",
        waitAttachLoading: "Attendi il caricamento dell'allegato",
        attachSent : "L'allegato è stato inviato correttamente, continua le tue modifiche e poi premi salva per confermare!",
        downloadAttachWaiting: "Download in corso",
        removeAttachWaiting : "Rimozione allegato in corso",
        removeAttach : "Rimuovi allegato",
        tableNotMatch: "La tabella principale non corrisponde a quella configurata sul tag del controllo di upload",
        //attachRemoved : "L'allegato è stato rimosso."

        // BEGIN STRING with the replacement
        calendarEventResizeEnd:  "Vuoi modificare la fine dell'evento S%eventTitle%S data-fine: S%endDate%S",
        calendarEventMoveEventQuestion : "Stai modificando l'evento S%eventTitle%S mettendo data inizio: S%startDate%S data-fine: S%endDate%S",

        errorListingTypeNull : "ListingType è nullo sulla tabella S%searchTableName%S con il filtro S%filter%S nella MetaPage S%title%S",
        errorLoadingMetaData: "Errore nel caricamento del metadato  S%searchTableName%S è necessario riavviare l'applicazione",
        commandExecutionError: "Errore nell'esecuzione del comando S%command%S",
        entityNotfound: "Entità S%unaliased%S non trovata nel form S%formTitle%S",
        gridControlTagWrong : "DataGrid con tag S%gridTag%S nel form  S%formTitle%S è sbagliato",
        deleteRowConfirm : "Confermi la cancellazione della riga dalla tabella S%tableName%S?",
        cantUnlinkDataTable: "Impossibile unlink. DataTable S%sourceTableName%S  non " + decodeURI('%C3%A8') + " child di  S%primaryTableName%S",
        missingTableDataSet: "La tabella  S%tableName%S  non " + decodeURI('%C3%A8') + " presente sul DataSet",
        moreThenRow: "Errore: c'" + decodeURI('%C3%A8') + " più di una riga nella tabella S%tableName%S",
        gridDataNoValid : "La tabella S%tableName%S contiene dati non validi. Contattare il servizio di assistenza",
        cancelObjInsert: "Annullo l'inserimento dell'oggetto S%formTitle%S nella tabella S%tableName%S?",
        deleteObjInsert : "Cancello l'oggetto S%formTitle%S nella tabella S%tableName%S?",
        formNoMainTreeView : "Il form S%formTitle%S non ha un treeview principale",
        invalidData : "La tabella S%tableName%S contiene dati non validi. Contattare il servizio di assistenza",
        noRowSelected : "Nessuna riga selezionata sulla tabella S%tableName%S",

        rowCouldBeDetached: "La riga selezionata potrebbe essere in stato detached",
        rowCouldBeDetachedOrDeleted: "La riga selezionata potrebbe essere in stato detached o deleted",
        copyPressedMsg : "E' stato premuto il tasto inserisci copia. Si desidera davvero creare una copia dei dati già salvati?",
        noRowOnTable: "Nella tabella S%searchTableName%S non è stata trovata alcuna riga.\r\n",
        filterWas: "La condizione di ricerca impostata era: S%mergedFilter%S \r\n",
        listName: "Nome Elenco",
        onDate: "il",
        createdByStr:  "Creato da S%user%S",
        createdOnStr:  "Creato il S%time%S",
        modifiedByStr:  "Modificato da S%user%S",
        modifiedOnStr: "Modificato il S%time%S",
        result: "Risultati: S%count%S"
    };
    
    appMeta.localResourceFr = LocalResourceFr;
}());


