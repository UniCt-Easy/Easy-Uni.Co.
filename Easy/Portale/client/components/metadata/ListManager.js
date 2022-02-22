
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


/// <reference path="MetaApp.js" />
/**
 * @module ListManager
 * @description
 * Manages the graphics and the logic of an html List Manager
 */
(function() {

    // utilizzo GridControl per costruire la griglia
    var GridController;
    var getData = appMeta.getData;
    var Deferred = appMeta.Deferred;
    var locale = appMeta.localResource;
    var q = window.jsDataQuery;
    var utils = appMeta.utils;

    /**
     * @constructor ListManager
     * @description
     * Initializes a ListManager control
     * @param {string} tableName
     * @param {string} listType
     * @param {jsDataQuery} filter
     * @param {boolean} isModal
     * @param {Html node} rootElement
     * @param {MetaPage} metaPage
     * @param {boolean} filterLocked true if filter can't be changed during row selection
     * @param {DataTable} toMerge. It contains the Rows to "merge" with those found in DB
     */
    function ListManager(tableName, listType, filter, isModal, rootElement, metaPage, filterLocked, toMerge, sort) {

        this.filterLocked = filterLocked || false;
        this.toMerge = toMerge;
        this.tableName = tableName;
        this.listType = listType;
        this.sort = sort;
        this.filter = filter;
        this.isModal = isModal;
        this.rootElement = rootElement || document.body;
        this.metaPage = metaPage;

        GridController = appMeta.CustomControl("gridx");

        this.lastTableRequested = null;

        // var ausiliarie per costruire i bottoni del footer
        this.totpages = 0;
        this.currentPageDisplayed = 1;
        this.numberOfPagesInFooter = appMeta.config.listManager_numberOfPagesInFooter;
        this.nRowPerPage = appMeta.config.listManager_nRowPerPage;
        this.myfooter = null;
        this.showFooter = true;

        return this;
    }

    ListManager.prototype = {
        constructor: ListManager,

        /**
         *
         */
        positionInPage:function() {
            this.dialogNotmodalId = "dialog" + utils.getUnivoqueId();
            // l'elenco occuperà metà dell'altezza
            this.currentRootElement = $('<div class="searchzoneList" id="' + this.dialogNotmodalId + '">'); // in alternativa aggiungi pure classe container di bootstrap, centra il tutto container
            // aggiungo label per il titolo, dove mostro il num di righe totali + paginazione
            var $lblTile = $("<label class='risultati' id='" + this.dialogNotmodalId + "_title'>");
            $(this.currentRootElement).append($lblTile);

            // aggiungo bottone per la chiusura
            var $closeIcon = $('<i class="fa fa-window-close">');
            var $span = $('<div class="searchClose">');
            $span.append($closeIcon);
            $span.on("click", _.partial(this.hideControl, this));
            this.closeEl = $span;
            $(this.currentRootElement).append($span);

            // lo appendo al mio rootElement esterno
            $(this.rootElement).prepend(this.currentRootElement);
        },

        /**
         *
         */
        positionModal:function() {
            this.myModalUnivoqueId = "#mymodal" + utils.getUnivoqueId();
            this.defModal = Deferred("ListManager-modal");
            this.currentRootElement = $('<div class="listManagerContainer">'); // in alternativa aggiungi pure classe "container" di bootstrap, centra il tutto container

            $(this.rootElement).append(this.currentRootElement);
        },

        /**
         *
         * @param visble
         */
        setShowFooter:function (visible) {
            this.showFooter = visible;
        },

        /**
         *
         */
        init:function() {
            if (this.isModal) this.positionModal();
            if (!this.isModal) this.positionInPage();
            // a seconda se modale o non appendo i vari html ad un nuovo root. così non serve if dopo.
            this.myRootListManger = $("<div data-tag='" + this.tableName + "." + this.listType + "' class='autoChooseDataTag'>");
            // aggiungo al mio root corrente il div dinamico con la griglia e il footer.
            $(this.currentRootElement).append(this.myRootListManger);
            this.loader = new appMeta.LoaderControl(this.myRootListManger, appMeta.localResource.loader_waitListLoading);
        },

        /**
         * A seguito di un cambio di sort riesegue la query paginata
         */
        sortPaginationChange:function(newSort) {
            var def = Deferred('doPaginatedNewSort');
            this.newSort = newSort;
            if (this.totpages > 1) {
                return this.createList()
                    .then(function () {
                       return def.resolve(true);
                    });
            }
            return def.resolve(false);
        },

        /**
         * @method show
         * @public
         * @description ASYNC
         * Builds and shows a listManger control, and returns a Promise
         * @param {DataTable} dataTablePaged
         * @param {int} totPage
         * @param {int} totRows
         * @returns {Deferred}
         */
        show: function (dataTablePaged, totPage, totRows) {
            var self = this;
            var def = Deferred("show-ListManager");

            var res = self.createList(dataTablePaged, totPage, totRows)
                .then(function () {
                    self.hideWaitingIndicator();
                    // caso autochoose modale
                    if (self.isModal) {
                        self.buildModal();
                        self.adjustSizeModal();
                        self.loader.hideControl();
                        return self.defModal.promise();
                    }
                    self.adjustSizeNotModal();
                    self.metaPage.eventManager.trigger(appMeta.EventEnum.listCreated, self, "show");
                    return def.resolve();
                });

            return def.from(res).promise();
        },

        adjustSizeNotModal:function() {
        },


        /**
         * @method adjustSizeModal
         * @private
         * @description SYNC.
         * Adjusts the size and the position of the modal based on its content (based on the grid)
         */
        adjustSizeModal:function () {
            var screenW  = $(window).width();
            // attuale width del rect bianco della mdoale
            var currwcont = parseInt($(this.myModalUnivoqueId + ' .modal-content').css("width").replace("px",""));
            // new width come griglia contenuta. tolgo 10 così appare la scrollabr
            var newcontint = parseInt(this.gridControl.mytable.css("width").replace("px","")) - 10;
            // la new width non può uscire dallo schermo
            if (newcontint > screenW) newcontint = screenW - 50;
            // left attuale metà schermo meno metà della content bianca, posizionata al centro
            var actualeft = (screenW - currwcont)/ 2;
            // calcolo qaunto devo spostare a sx il content bianco
            var widthAdded = newcontint - currwcont;

            // fisso altezza in base allo schermo
            var h = ($(window).height() - 100).toString() + "px";
            $(this.myModalUnivoqueId + ' .modal-content').css("height", h);

            if (widthAdded <= 0) return;
            var newleftint = (widthAdded / 2);
            // se vado troppo a sx rimetto 50 px avanti
            if (newleftint > actualeft) newleftint = actualeft - 50;
            var newleft = (-newleftint).toString() + "px";
            var newcontw = (newcontint).toString() + "px"; // -10 così appare la scroll orizz

            // asegno nuove prop css calcolate
            $(this.myModalUnivoqueId + ' .modal-content').css("width", newcontw);
            $(this.myModalUnivoqueId + ' .modal-content').css("left", newleft);
        },

        /**
         * @method addBtnCloseNotModal
         * @private
         * @description SYNC. DEPRECATED
         * Adds the close button for the not modal case
         */
        addBtnCloseNotModal:function () {
            if (!this.isModal){
                var $button = $('<button class="btn btn-secondary" style="float: right">');
                $button.text(appMeta.localResource.close);
                $button.on("click", _.partial(this.hideControl, this));
                $(this.currentRootElement).append($button);
            }
        },

        /**
         * @method getModalHtml
         * @private
         * @description SYNC
         * Builds and returns the html string for a modal form
         * @returns {string}
         */
        getModalHtml:function () {
            var modalHtml = "<div class='modal'  id=" + this.myModalUnivoqueId.substr(1) + " tabindex='-1' role='dialog' data-backdrop='static' data-keyboard='false'" +
                " style='display:none;'>" +
                "<div class='modal-dialog modal-lg'>" +
                "<div class='modal-content'  >" +
                "<div class='modal-header'>"+
                "<h4 class='modal-title'>" + this.title + "</h4>" +
                "<button type='button' class='close modal-white-close'>" +
                "<span aria-hidden='true'>&times;</span></button>" +
                "</div>" +
                "<div class='modal-body' style='overflow-x: auto;'></div>" +
                "<div class='modal-footer bg-default'></div>" +
                "</div>" +
                "</div>" +
                "</div>";

            return modalHtml;
        },

        /**
         * @method buildModal
         * @private
         * @description SYNC
         * Builds the modal control. Ataches also the event to the controls
         * @returns {boolean}
         */
        buildModal:function () {
            // prendo il template html della modale e lo aggiungo al rootElement
            var currModal = $(this.getModalHtml());
            $(this.currentRootElement).append(currModal);
            // una volta aggiunto al currentRootElement, lo popolo con i dati parametrici che ho calcolato nella createList
            $(this.myModalUnivoqueId + ' .modal-body').append($(this.myRootListManger));
            // evento di close sul tastino x
            $(this.myModalUnivoqueId  + ' .modal-header').find("button")
                .data("mdlModalWin", this)
                .on("click", this.closeModalBtnEv);
            $(this.myModalUnivoqueId  + ' .modal-footer').append($(this.myfooter));
            $(this.myModalUnivoqueId).modal('show');
            if (this.metaPage.eventManager) return this.metaPage.eventManager.trigger(appMeta.EventEnum.showModalWindow, this, "buildModal");

            return true;

        },


        /**
         * @method hideControl
         * @private
         * @description SYNC
         * Hides and removes the control itself.
         * Called by btn close, attached with partial, and by the private method closeListManager()
         * @param {ListManager} that the instance itself
         */
        hideControl:function (that) {
            if (that.currentRootElement){
                if (that.isModal) $(this.myModalUnivoqueId).modal('hide'); // inovoco hide così rimuove lo sofndo non cliccabile
                that.currentRootElement.remove();
            }
            if (that.metaPage.eventManager) that.metaPage.eventManager.trigger(appMeta.EventEnum.listManagerHideControl, that, "hideControl");
        },

        /**
         * @method closeModalBtnEv
         * @private
         * @description SYNC
         * Called by the button close of the modal
         */
        closeModalBtnEv:function () {
            var that = $(this).data("mdlModalWin");
            that.closeListManager(); // non passo nulla, poichè nella modale se chiudo con il close non deve comunicare nulla al chiamante.
        },

        /**
         * @method createList
         * @private
         * @description ASYNC
         * Creates the grid and the footer
         * @param {DataTable} dataTablePaged
         * @param {int} totPage
         * @param {int} totRows
         * @returns {Deferred}
         */
        createList: function(dataTablePaged, totPage, totRows) {
            var self = this;
            var def = Deferred("listManager.createList");
            // mostro il loader
            this.loader.showControl();

            // la prima volta le passa metaPage sullo show  qaundo chiama l'elenco poichè già ha fatto la query e non la rifaccio
            if (dataTablePaged) {
                var res = self.loadCore(dataTablePaged, totPage, totRows);
            } else {
                // passo qui, quando premo i pulsanti di navigazione della paginazione, quindi qui si ricalcola il dt
                // oppure se eseguo un oridnamento sulla griglia e ci sono più pagine
                var res = getData.getPagedTable(this.tableName, this.currentPageDisplayed, this.nRowPerPage, this.filter, this.listType, this.newSort)
                    .then(function(dtp, totp, totr) {
                        // nel momento in cui torno la riga alla metapage viene fatta della logica sulla riga seelzionata
                        // su relazioni etc.. quindi recupera dalla table la proprietà dataset, che in questo caso non avrebbe perchè
                        // getPagedTable() torna solo un datatable, e lo devo quindi associare al ds corrente della metapage
                        dtp.dataset = self.metaPage.state.DS;
                        return self.loadCore(dtp, totp, totr);
                    });
            }

            return def.from(res).promise()
        },

        /**
         * @method getTitle
         * @private
         * @description SYNC
         * Returns the title the column of the Autochoose used for the title (in modal case)
         * @returns {string}
         */
        getTitle:function () {
            return this.metaPage.titleAutochoose || "" ;
        },

        /**
         * Given the dataTablePaged fills th grid
         * @method loadCore
         * @private
         * @description ASYNC
         * @param {DataTable} dataTablePaged
         * @param {int} totPage
         * @param {int} totRows
         * @returns {Deferred}
         */
        loadCore:function (dataTablePaged, totPage, totRows) {
            var self = this;
            var def = Deferred("loadCore");
            self.totpages = totPage;
            self.title =  self.getTitle() + " - " + self.getNumberOfRowOnTot(totRows); // calcolo titolo dinamicamente. utilizzato nelc aso modale usualmente
            if (!self.isModal) $("#" +  this.dialogNotmodalId + "_title").text(self.getNumberOfRowOnTot(totRows));
            if ( $(self.myModalUnivoqueId  + ' .modal-title').length) $(this.myModalUnivoqueId  + ' .modal-title').text(self.title);
            // "dataTablePaged" è il DataTable calcolato da getPagedTable()
            if (!dataTablePaged) return def.resolve(null);
            // salvo le proprietà delle colonne precedenti
            if (!!self.lastTableRequested &&
                !!self.lastTableRequested.columns &&
                !!dataTablePaged &&
                !!dataTablePaged.columns){
                dataTablePaged.columns = Object.assign({}, self.lastTableRequested.columns);
            }
            self.lastTableRequested = dataTablePaged;
            // se c'è la tab toMerge prova a fare il merge delle righe in base al filtro notEntityChild
            self.checkToMerge(dataTablePaged);
            // inizializzo il controllo griglia se già non è stato fatto
            self.getGridInstance(dataTablePaged);
            self.gridControl.dataTable = dataTablePaged;
            var  metaToConsider = appMeta.getMeta(dataTablePaged.tableForReading());
            // il be fa la describeCol, ma il programmatore pottebbe non imlementare.
			// ripeto qui, quella client veloce, e se non fosse implementata sul js prenderebbe quella in cache eventualmente
			//popolo la griglia
            var res = metaToConsider.describeColumns(self.gridControl.dataTable, self.listType)
                .then(function() {
                    return self.gridControl.fillControl();
                }).then(function() {
                    // aggiungo eventi
                    self.gridControl.addEvents(self, self, false);
                    // popolo il footer con i bottoni di navigazione
                    if (self.showFooter) self.buildFooter();
                    // nascondo loader, una volta caricati i dati
                    self.loader.hideControl();
                    return true;
                });

            return def.from(res).promise()
        },

        /**
         * @method getNumberOfRowOnTot
         * @private
         * @description SYNC
         * Returns the string "Results xx" or "Results from zzz to yyy of xxx", where "xxx" is rowsShowed
         * @param {string} rowsShowed. should be a number
         */
        getNumberOfRowOnTot:function (rowsShowed) {
            // se sono più del totale msotrato paginato mostro "xx di 100"
            var from = (this.currentPageDisplayed - 1) * this.nRowPerPage;
            var to = from + this.nRowPerPage;
            if (to > rowsShowed) to = rowsShowed;
            if (rowsShowed > this.nRowPerPage) rowsShowed = locale.from + " " + from + " " + locale.to + " " + to + " " + locale.of + " " + rowsShowed;
            return locale.getNumberOfRows(rowsShowed)
        },

        /**
         * @method checkToMerge
         * @public
         * @description SYNC
         * Merges/UnMarges rows contained in "toMerge" table in "dt", based on toMerge notEntityChild filter
         * @param {DataTable} dt, dataTable where the rows of toMerge table must be merged
         */
        checkToMerge:function (dt) {

            if (!this.toMerge) return;

            var self = this;
            // è un jsDataQuery
            var noChildFilter = appMeta.metaModel.notEntityChild(this.toMerge);

            // Delete from list those who have not the filter property in the ToMerge Table
            var toExclude = this.toMerge.select(q.not(noChildFilter));
            _.forEach(toExclude, function (r) {
                var  cond = getData.getWhereKeyClause(r.getRow(), self.toMerge , self.toMerge, false);

                var toDelete = dt.select(cond);
                if (toDelete.length > 0) {
                    toDelete[0].getRow().del();
                    toDelete[0].getRow().acceptChanges();
                }
            });

            // Add to list those who are not present in the list and are present in the ToMerge table
            var toAdd = this.toMerge.select(noChildFilter);
            _.forEach(toAdd, function (r) {
                var cond = getData.getWhereKeyClause(r.getRow(), self.toMerge , self.toMerge, false);
                var toInsert = dt.select(cond);
                // Removes eventually present row from DT
                _.forEach(toInsert, function (rIns) {
                    rIns.getRow().del();
                    rIns.getRow().acceptChanges();
                });

                var newRow = dt.newRow();
                _.forEach(self.toMerge.columns, function (c) {
                    if(dt.columns[c.name]){
                        newRow[c.name] = r.getRow().current[c.name];
                    }
                });

                // newRow già aggiunge la riga dt.add(newRow);

            });
        },


        /**
         * @method buildFooter
         * @private
         * @description SYNC
         * Builds the footer:
         * << < 1 2 3 4 5 > >>
         * <table>
         *  <tr>
         *   <td><button  onclick="event()">aaa</button></td>
         *   ...
         *  </tr>
         * </table>
         */
        buildFooter:function () {
            // inizializzo oggetto footer

            if (this.myfooter) this.myfooter.remove();
            this.myfooter = $('<table>');

            if(this.totpages <= 1 ) return true;

            // unica riga dell' elemento footer
            var $tr = $("<tr>");

            // calcolo bottoni di avanzamento
            var upperLimit;
            if(( this.currentPageDisplayed + this.numberOfPagesInFooter - 1) > this.totpages)
                upperLimit = this.totpages;
            else
                upperLimit = this.currentPageDisplayed + this.numberOfPagesInFooter - 1;

            // Inserisco bottone   "<<"
            this.buildButtonFooter($tr,
                "<<",
                !(this.currentPageDisplayed > 1),
                _.partial(this.showPreviousPages, this));

            // Inserisco bottone   "<"
            this.buildButtonFooter($tr,
                "<",
                !(this.currentPageDisplayed > 1),
                _.partial(this.goPreviousPage, this));

            var startIndex = upperLimit - this.numberOfPagesInFooter + 1;
            if (startIndex < 1) {
                startIndex = 1;
            }
            // mostro i bottoni delle pagine cliccabili. tranne quello della pag corrente, che sarà disabilitato
            for(var pageIndex = startIndex; pageIndex <= upperLimit; pageIndex++) {
                this.buildButtonFooter($tr,
                    pageIndex,
                    (pageIndex === this.currentPageDisplayed),
                    _.partial(this.goToPage, this, pageIndex));
            }

            // Inserisco bottone   ">"
            this.buildButtonFooter($tr,
                ">",
                !(this.currentPageDisplayed < this.totpages),
                _.partial(this.goNextPage, this));

            // Inserisco bottone   ">>"
            this.buildButtonFooter($tr,
                ">>",
                !(upperLimit < this.totpages),
                _.partial(this.showNextPages, this));

            // Aggiungo la riga creata sull'oggetto parent
            $($tr).appendTo(this.myfooter);

            // applico lo stile
            this.myfooter.addClass(appMeta.cssDefault.listManagerFooter);

            // ogni volta rimetto footer
            if (this.isModal){
                if  ($('.modal-footer').length) {
                    $('.modal-footer').find("table").remove();
                    $('.modal-footer').append($(this.myfooter));
                }
            } else {
                var $fooDiv = $("<div>");
                $fooDiv.addClass(appMeta.cssDefault.listManagerFooterCont);

                this.myfooter.appendTo($fooDiv);
                $fooDiv.appendTo(this.myRootListManger);
            }

            return true;
        },

        /**
         * @method buildButtonFooter
         * @private
         * @description SYNC
         * Builds a button located on the footer of the control.
         * @param {Html element} $tr tr html element where add the new td element
         * @param {string} txt the text of the button
         * @param {boolean} isDisabled
         * @param {Function} partial the event attached to the button
         */
        buildButtonFooter: function ($tr, txt, isDisabled, partial) {
            var $td = $("<td>");
            var $button = $('<button class="btn btn-secondary">');
            $button.text(txt);
            $button.prop("disabled", isDisabled);
            $button.on("click", partial);
            $($button).appendTo($td);
            $td.appendTo($tr);
        },

        /**
         * @method showNextPages
         * @private
         * @description ASYNC
         * Attached on click event on button >>" in the footer, to go ahead if possible of "numberOfPagesInFooter" pages
         * @param {ListManager} that
         * @return  {Deferred}
         */
        showNextPages:function (that) {
            if (that.currentPageDisplayed + that.numberOfPagesInFooter > that.totpages) {
                that.currentPageDisplayed = that.totpages;
            } else {
                that.currentPageDisplayed += that.numberOfPagesInFooter;
            }
            return that.createList();
        },

        /**
         * @method showPreviousPages
         * @private
         * @description ASYNC
         * Attached on click event on button "<<" in the footer, to go down if possible of "numberOfPagesInFooter" pages
         * @param {ListManager} that
         * @return  {Deferred}
         */
        showPreviousPages:function (that) {
            that.currentPageDisplayed -= that.numberOfPagesInFooter;
            if ( that.currentPageDisplayed < 1 )  that.currentPageDisplayed =1;
            return that.createList();
        },

        /**
         * @method goNextPage
         * @private
         * @description ASYNC
         * Attached on click event on button ">" in the footer, to go to the next page
         * @param {ListManager} that
         */
        goNextPage:function (that) {
            that.currentPageDisplayed  = that.currentPageDisplayed + 1;
            if (that.currentPageDisplayed > that.totpages) that.currentPageDisplayed = that.totpages;
            return that.createList();
        },

        /**
         * @method goToPage
         * @private
         * @description ASYNC
         * Attached on click event on button "nPage" in the footer, to go at the page nPage
         * @param {ListManager} that
         * @param {number} nPage
         * @return  {Deferred}
         */
        goToPage:function (that, nPage){
            that.currentPageDisplayed = nPage;
            return that.createList();
        },

        /**
         * @method goPreviousPage
         * @public
         * @description ASYNC
         * Attached on click event on button "<" in the footer, to go in the previous page
         * @param {ListManager} that
         * @return  {Deferred}
         */
        goPreviousPage:function(that){
            if(that.currentPageDisplayed > 1)  that.currentPageDisplayed -= 1;
            return that.createList();
        },


        // *** START Methods MetaPage Interface ***

        /**
         * @method canSelect
         * @public
         * @description ASYNC
         * Return a deferred boolena true if control can select a row
         * @param {DataTable} dataTable
         * @param {DataRow} row
         * @returns {Deferred}
         */
        canSelect: function (dataTable, row) {
            //TODO richiamare il canSelect della MetaPage
            var deferred = Deferred("canSelect");
            return deferred.resolve(true).promise();
        },

        /**
         * @method rowSelect
         * @public
         * @description ASYNC
         * Dispatches a row select through listeners if the control is not modal, otherwise it resolve immediately the deferred
         * @param {Html node} sender  object generating the event
         * @param {DataTable} dataTable
         * @param {ObjectRow} row
         * @returns {Deferred}
         */
        rowSelect: function (sender, dataTable, row) {
            if (this.isModal) {
                // Nel caso modale, se il grid ospitato lancia un rowselect non deve fare nulla. Torno la deferred poichè l'interfaccia della rowSelect prevede torni un Deferred.
                // Al click su una riga infatti viene invocato il click su grid, il grid chiama la setRow -> ed invoca la rowSelect sulla metPage chiamante,
                // quindi in questo caso la metaPage è ListManager e proprio questo metodo rowSelect() ; lui deve quindi tornare una Deferred altrimenti va in errore.

                // per il mobile la selezione avviene al singolo click
                if (appMeta.isMobile) {
                   this.closeAndResolveDeferred(row)
                }
                return Deferred("rowSelect").resolve();
            }
            // qui invece viene invocato la rowSelct sulla MetaPage vera e propria e lei torna Deferred
            // Di qua passa quando il listManager non è modale, ossia è associato ad un form elenco sulla tabella principale
            var dtRow = row ? (row.getRow ? row.getRow() : null) : null;

            var self = this;
            // console.log("rowSelect " + appMeta.logger.getTimeMs());
            return this.metaPage.warnUnsaved()
                .then(function (res) {
                    if (res) {
                        return Deferred("rowSelect").from(self.metaPage.selectRow(dtRow, self.listType)).promise();
                    }
                    self.gridControl.resetSelectedRow();
                    return Deferred("rowSelect").resolve()
                });
        },

        /**
         * @method rowDblClick
         * @private
         * @description SYNC
         * Handker for the dbClick event on the grid of listManager
         * @param {GridControl} sender
         * @param {DataTable} dataTable
         * @param {ObjectRow} row
         */
        rowDblClick: function (sender, dataTable, row){
            this.closeListManager(dataTable, row);
        },

        closeAndResolveDeferred:function(row) {
            this.hideControl(this);
            this.defModal.resolve(row);
        },

        /**
         * @method closeListManager
         * @public
         * @description SYNC
         * Hides/removes the control graphically and resolve the deferred with the row selected.
         * It distinguishes 2 cases:
         * 1. modal resolve the "defModal" Deferred, instead
         * 2. not modal call a selectRow on metapage
         * @param {DataTable} dataTable
         * @param {ObjectRow} row
         */
        closeListManager:function (dataTable, row) {
            if (this.isModal) {
                this.closeAndResolveDeferred(row);
            } else {
                // alla chiusura se non è modale lancia la rowSelect su metaPage
                // this.metaPage.rowSelect(null, dataTable, row);
                var dtRow = row ? (row.getRow ? row.getRow() : null) : null;
                var self = this;
                return this.metaPage.warnUnsaved()
                    .then(function (res) {
                        if (res) {
                            self.hideControl(self);
                            return Deferred("closeListManager").from(self.metaPage.selectRow(dtRow, self.listType)).promise();
                        }
                        self.gridControl.resetSelectedRow();
                        return Deferred("closeListManager").resolve()
                    });
            }
        },


        showWaitingIndicator:function (msg) {
            if (this.metaPage) return this.metaPage.showWaitingIndicator(msg);
        },

        hideWaitingIndicator:function (handler) {
            if (this.metaPage) this.metaPage.hideWaitingIndicator(handler);
        },

        /**
         * Create an instance of gridControl
         * @param {DataTable} dt
         */
        getGridInstance:function (dt) {
            if (!this.gridControl) {
                this.gridControl = new GridController(this.myRootListManger, this.metaPage.helpForm, dt, null, this.listType);
                this.gridControl.init();
            }
        }
        // *** END Methods MetaPage Interface  ***

    };

    window.appMeta.ListManager = ListManager;

}());
