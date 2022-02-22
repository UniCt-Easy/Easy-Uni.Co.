
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
 * @module GridControlXEdit
 * @description
 * Manages the graphics and the logic of an html Grid with editing in palce.
 */
(function () {
    var Deferred = appMeta.Deferred;
    var GridControlX = appMeta.CustomControl("gridx");
    var directionScoll = {
        none: 0,
        up: 1,
        down: 2
    };

    /**
     * @constructor GridControlXEdit
     * @description
     * Initializes the html grid control
     * @param {Html node} el
     * @param {HelpForm} helpForm
     * @param {DataTable} table. this is the table corresponding to the tableName configured in the tag at the position 0
     * (see function HelpForm.preScanCustomControl for the initialization)
     * @param {DataTable} primaryTable
     * @param {string} listType. if it is called by in a listmanager, listType is passed
     * Contains all data of a grid
     */
    function GridControlXEdit(el, helpForm, table, primaryTable, listType) {
        GridControlX.apply(this, [el, helpForm, table, primaryTable, listType]);
    }

    GridControlXEdit.prototype = _.extend(
        new GridControlX(), {

            constructor: GridControlXEdit,

            superClass: GridControlX.prototype,

            init: function () {
                this.superClass.init.call(this);
                if (this.helpForm.existsDataAttribute(this.el, "mdleditinplacecolumns")) {
                    this.editInPlaceColumns = $(this.el).data("mdleditinplacecolumns").split(";");
                }

                this.rowInPag = 200;
                this.rowGroupedInPag = 10;
                this.currPage = 0;
                this.loadedGroup = [];
                this.loadedRowsIndex = [];
                this.lastScrollLeft = 0;
            },

            /**
             * @method addMyEvents
             * @private
             * @description SYNC
             * Adds the "click" and "dblclick" events to the rows of the grid
             */
            addMyEvents: function () {
                this.superClass.addMyEvents.call(this);
                this.mytable.find("tr:not(:has(>th)):not([data-mdlgrouped]):not(.table-in-cell-tr) > td").on("click", _.partial(this.cellEdit, this));
            },

            /**
             * @method removeEvents
             * @private
             * @description SYNC
             * Removes all the events from grid rows
             */
            removeEvents: function () {
                this.superClass.removeEvents.call(this);
                this.mytable.find("tr:not(:has(>th)):not([data-mdlgrouped]):not(.table-in-cell-tr) > td").off("click", _.partial(this.cellEdit, this));
            },


            /**
             *
             * @param {ObjectRow} row
             * @param {string} colname
             * @param {string} text
             */
            setValueOnDataRow: function (row, colname, text) {
                var tag = this.dataSourceName + "." + colname;
                this.helpForm.getString(text, colname, row, tag, true);
            },

            keyupeditinplace: function (colname, row, that, preText, ev) {
                if (13 === ev.which) { // press ENTER-key
                    var text = $(this).val();
                    // recuperato il valore dalla input lo inserisco sia come testo del grid che come valore sulla riga
                    that.setValueOnDataRow(row, colname, text);
                    // esco dall'editing
                    that.resetEditableTd(text)
                }

                if (27 === ev.which) {  // press ESC-key
                    that.resetEditableTd(preText)
                }
            },

            selectOption:function(colname, row, that, preText, ev) {
                that.setValueOnDataRow(row, colname, $(this).val());
                // esco dall'editing
                var displayText = $(this).find('option:selected').html();
                that.resetEditableTd(displayText);
            },

            resetEditableTd: function (text) {
                var self = this;
                setTimeout(function () {
                    $(self.tdEditing).html(text);
                    $(self.tdEditing).data('mdlediting', false);
                    self.tdEditing = null;
                }, 200)
            },

            cellEdit: function (that) {
                // clicco su una cella se c'era valorizzato il td corrente
                if (that.tdEditing) {
                    // rimetto il valore originale
                    var text = $(that.tdEditing).data("mdlpretext");
                    $(that.tdEditing).html(text);
                    $(that.tdEditing).data("mdlediting", false);
                }
                // sul td corrente diventa quello editabile
                var preText = $(this).html();
                $(this).data("mdlpretext", preText);
                that.tdEditing = this;
            },

            cellEditable: function () {
                var def = Deferred("cellEditable");
                var self = this;

                // se sto già in editi sulq uel td esco
                var editing = this.helpForm.existsDataAttribute(this.tdEditing, "mdlediting");
                if (editing && $(this.tdEditing).data('mdlediting')) {
                    return def.resolve();
                }
                // se non è un grid con editInPalce esco
                if (!this.editInPlaceColumns) {
                    return def.resolve();
                }

                // recupero riga e colonna del td da editare
                var colname = $(this.tdEditing).data('mdlcolumnname');
                var row = $(this.tdEditing).closest('tr').data('mdldatarowlinked');

                // se non fa parte di quelle che ho input da editare
                if (!self.editInPlaceColumns.includes(colname)) {
                    return def.resolve();
                }
                // variabile che indica che la cella è in fase di editing
                $(this.tdEditing).data("mdlediting", true);

                var preText = $(this.tdEditing).html();
                $(this.tdEditing).data("mdlpretext", preText);
                // creo input editabile
                var id = appMeta.utils.getUnivoqueId();

                // osservo se devo visualizzare select
                if (self.conditionallookupArray[colname]) {

                    var selectObj = $("<select id=" + id + "/>");
                    _.forEach(self.conditionallookupArray[colname], function (option) {
                        var emptyOption = document.createElement("option");
                        emptyOption.textContent = option.displaymember;
                        emptyOption.value = option.valuemember;
                        selectObj.append(emptyOption);
                    });
                    $(this.tdEditing).html("");
                    selectObj.width($(this.tdEditing).width())
                        .height($(this.tdEditing).height())
                        .css({border: "0px", fontSize: "17px"})
                        .val(preText)
                        .appendTo($(this.tdEditing));

                    selectObj.change( _.partial(self.selectOption, colname, row, self, preText));

                    selectObj.click(function () {
                        return false;
                    });

                } else {
                    var inputObj = $("<input type='text' id=" + id + "/>");
                    $(this.tdEditing).html("");
                    inputObj.width($(this.tdEditing).width())
                        .height($(this.tdEditing).height())
                        .css({border: "0px", fontSize: "17px"})
                        .val(preText)
                        .appendTo($(this.tdEditing))
                        .trigger("focus")
                        .trigger("select");

                    // se premo qualceh tasto inovco evento. su invio effettuo modifica del valore sulla riga
                    inputObj.on("keyup", _.partial(self.keyupeditinplace, colname, row, self, preText));

                    inputObj.click(function () {
                        return false;
                    });
                    // se è una colonna data, inserisco calendario
                    var dc = self.dataTable.columns[colname];
                    if (dc.ctype === 'DateTime') {
                        inputObj.datepicker({
                            showOn: "focus",
                            onClose: function () {
                                this.focus();
                            }
                        });
                        inputObj.datepicker('show');
                    }
                }

                return def.resolve();
            },

            /**
             * @method redrawGridForGrouping
             * @private
             * @description SYNC
             * redraws the grid, based on grouping.
             * @param {GridControlX} that
             */
            redrawGridForGrouping: function (that, append, upDown, actualTop) {
                // per ora funziona con un raggruppamento solo
                var rows = that.gridRows;
               /* if (!rows.length) {
                    return;
                }*/

                // rimuovo tutto, ricreo un mytable, per questioni di performance appendo al nuovo mytable al termine
                if (!append) {
                    that.loadedGroup = [];
                    that.loadedRowsIndex = [];
                    that.currPage = 0;
                    if (that.mytable) {
                        that.mytable.off("scroll", _.partial(that.scrollList, that));
                        that.mytable.parent().remove();
                    }
                    that.mytable = $('<table class="table" border="1" style="position:relative; display: block; overflow-y: scroll; max-height: 700px">');
                    that.mytable.on("scroll", _.partial(that.scrollList, that));
                }

                // calcolo raggruppamento per quella specifica colonna.
                // torna ob con chiave colonna , e valore array di rows
                // col1: [a,b,c]
                // col2: [d,e,f]
                //console.log("pre group " + appMeta.logger.getTimeMs());
                var objGrouped = that.calcObjGrouped(rows, that.columnsGrouped);
                //console.log("post group " + appMeta.logger.getTimeMs());

                // ho calcolato nuove colonne nell'header e le inserisco
                if (!append) {
                    that.addHeaders();
                }

                var addEvents = false;
                // console.log("pre render" + appMeta.logger.getTimeMs());
                if (_.isArray(objGrouped)) {

                    if (append && objGrouped.length <= that.rowInPag) {
                        return;
                    }
                    // creo struttura di righe raggruppate. passo 1 come livello di raggruppamento, poi nella ricorsione aumenterò
                    // console.log("pre render " + appMeta.logger.getTimeMs());
                    // appendo al mytable tutta la stringa html
                    var rowsToLoad = _.filter(objGrouped, function (row, index) {
                        if ((index >= that.currPage * that.rowInPag) &&
                            (index < (that.currPage * that.rowInPag) + that.rowInPag)) {
                            if (that.loadedRowsIndex.includes(index)) {
                                return false;
                            }
                            that.loadedRowsIndex.push(index);
                            return true;
                        }
                    });

                    if(rowsToLoad && rowsToLoad.length > 0) {
                        addEvents = true;
                        that.mytable.append(that.createRowsFromObjgrouped(rowsToLoad, 1, null));
                    }
                } else {

                    var numeroGruppi = Object.keys(objGrouped).length;
                    var counterRow = 0;
                    var gruppi = {};
                    console.log("numeroGruppi " + numeroGruppi);
                    // trovo gruppi da visualizzare.
                    _.forEach(objGrouped, function (k, a) {
                        if ( that.loadedGroup.includes(a)) {
                            return true;
                        }
                        // almeno 50 righe
                        if (counterRow < 50) {
                            counterRow += objGrouped[a].group.length;
                            gruppi[a] = objGrouped[a];
                            that.loadedGroup.push(a);
                        }
                    });

                    console.log('appendo gruppi ' + Object.keys(gruppi).length + ' ' + appMeta.logger.getTimeMs());

                    if (Object.keys(gruppi).length > 0) {
                        if (!upDown || upDown === directionScoll.up || upDown === directionScoll.none) {
                            addEvents = true;
                            that.currTrAppended = that.createRowsFromObjgrouped(gruppi, 1, null);
                            that.mytable.append(that.currTrAppended);
                        }
                    }
                }

                //console.log("post render" + appMeta.logger.getTimeMs());
                if (!append) {
                    var $tableCont = $('<div class="tableCont">');
                    $tableCont.append(that.mytable);
                    $(that.el).prepend($tableCont);
                    $($tableCont).insertAfter($(that.$groupingArea));
                }

                if (!rows.length) that.addTableEmptyRow();

                if ( addEvents) {
                    // aggiungo eventi alle righe
                    that.addMyEvents();
                }

                // rimetto scroll dove era
                actualTop = actualTop || 0;
                that.mytable.scrollTop(actualTop);
            },

            /**
             * @method rowClick
             * @private
             * @description ASYNC
             * Manages a row click event
             * "this" is the tr html element that launches the event
             * @param {GridControlX} that
             * @param {boolean} propagate
             * @returns {Deferred}
             */
            rowClick: function (that, propagate) {
                var self = this;
                // distinguo ildoppio click s è o meno gestito come treeNavigator
                var r = $(this).data("mdldatarowlinked");
                var def = Deferred("rowClick");
                if (!r) return def.resolve(true);
                if (r === that.currentRow) {
                    return def.from(that.cellEditable(this));
                } //Riga già selezionata

                if (that.metaPage) {
                    return that.metaPage.canSelect(that.dataTable, r)
                        .then(function (result) {
                            if (result) {
                                if (that.isTreeNavigator) return def.from(that.navigatorClick.call(self, that));
                                that.currentTrRow = this;
                                return def.resolve(that.setRow(r, propagate));
                            }
                            return def.resolve(false);
                        });
                }
                return def.from(that.setRow(r, propagate));
            },

            rowDblClick: function (that) {
                return Deferred("rowDblClick").resolve();
            },

            scrollList: function (that, ev) {

                var sl = $(this).scrollLeft();
                $(".gx-td-grouped-cell").css("padding-left", sl + 10);

                if (that.disableScroll) {
                    that.disableScroll = false;
                    return;
                }

                // se è scroll orizzontale non faccio nulla
                var documentScrollLeft = $(this).scrollLeft();
                if (that.lastScrollLeft !== documentScrollLeft) {
                    that.lastScrollLeft = documentScrollLeft;
                    return;
                }

                var outerHeight = $(this).outerHeight();
                var top = $(this).scrollTop();
                var scrollHeight = $(this).prop('scrollHeight');
                if (outerHeight + top >= scrollHeight) {
                    that.currPage++;
					that._scroll(that, directionScoll.up, top);
                    return
                }

                if (top <= 0 && that.currPage > 0) {
                    that.currPage--;
					// that._scroll(that, directionScoll, top);
                }
            },

			_scroll: function (that, upDown, actualTop) {
                if (!that.scrollRefrershRunning) {
                    // evita lancio scroll multipli
                    that.scrollRefrershRunning = true;
                    // ---> disabilito html
                    $(that.mytable).addClass("gridLoaderScroll");
                    setTimeout(function () {
                        that.redrawGridForGrouping(that, true, upDown, actualTop);
                        // --> riabilito html
                        $(that.mytable).removeClass("gridLoaderScroll");
                        that.scrollRefrershRunning = false;
                    }, 100);
                }
            },
            /**
             * @method innerFillControl
             * @private
             * @description ASYNC
             * Executes the fill of the custom control
             * @method  fillControl
             * @param {html node} el
             * @param {jsDataQuery} filter
             * @returns {Deferred}
             */
            innerFillControl: function (el, filter, propagate) {

                var def = Deferred("innerFillControl");

                if (!this.dataTable) return def.resolve();
                var self = this;

                // caso in cui cambia riga padre, riparto da prima pagina
                if (this.parentCurrentRow &&
                    this.metaPage &&
                    this.parentCurrentRow !== this.metaPage.currentRow) {
                    this.currPage = 0;
                }
                if (!this.parentCurrentRow) {
                    this.currPage = 0;
                }
                if (this.metaPage) {
                    this.parentCurrentRow =  this.metaPage.currentRow;
                }

                // rimane aperto dal costruttore e qui mi aspetto venga fatta la then, quando appunto torna il metodo
                var res = this.defDescribedColumn
                    .then(function () {

                        self.orderedCols = self.getOrderedColumns(self.dataTable);


                        // se è la prima volta allora leggo il layout
                        if (!self.gridLoadedFirstTime) {
                            self.gridLoadedFirstTime = true;
                        }

                        if (self.emptyElement) self.emptyElement.remove(); // rimuovo l'elemnto vuoto, cioè l'header

                        self.gridRows = self.getSortedRows(self.dataTable, filter);

                        self.manageColumnsEvents(el);

                        // solo la prima volta aggiunge la colonna di gruppo configurata dall'esterno
                        if (!self.initialGroupInput) {
                            self.initialGroupInput = true;
                            self.calcInputGrouping();
                        }

                        // ridisegno grid con le righe raggruppate
                        self.redrawGridForGrouping(self);

                        // azioni dopo la selzione dell'indice giusto sulla griglia
                        return self.setRow(self.currentRow, propagate);

                    });

                return def.from(res).promise();

            },


        });

    appMeta.CustomControl("gridxedit", GridControlXEdit);
}());
