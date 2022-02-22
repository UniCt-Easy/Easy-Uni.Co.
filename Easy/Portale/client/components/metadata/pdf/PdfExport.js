
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


(function () {
    var Deferred = appMeta.Deferred;
    var getDataUtils = appMeta.getDataUtils;
    var jsPDF = jspdf.jsPDF;
    /**
     * @constructor PdfExport
     * @description
     * Esegue export pdf della pagina. campi + griglie
     */
    function PdfExport() {
        this.top = 15;
        this.left = 10;
        this.rowSpace = 12;
        this.titleFontSize = 16;
        this.textFontSize = 12;
        this.tableRowHeigth = 30;
        this.sheetFormat = 'a2';

    }

    PdfExport.prototype = {
        constructor: PdfExport,

        initDoc:function() {
            this.doc = new jsPDF('portrait', 'pt', this.sheetFormat);
            this.doc.setFontSize(this.titleFontSize);
        },

        /**
         * ask for the pdf export.
         * @param {MetaPage} metaPage
         */
        exportToPdf:function (metaPage) {
            this.metaPage = metaPage;
            var self = this;
            metaPage.showMessageOkCancel("Vuoi ottenere un report pdf di questa pagina?")
                .then(function (res) {
                    if (res) {
                        self.doExportPdf();
                    }
                });
        },

        /**
         * Execute pdf export
         */
        doExportPdf:function(){

            var self = this;
            this.initDoc();

            this.printRow(this.metaPage.name);

            this.doc.setFontSize(this.textFontSize);

            var ctrlsGrid = [];
            $(this.metaPage.rootElement + "  [data-tag]")
                .each(function () {
                    var el = $(this);
                    var ctrl = $(el).data("customController");
                    var ctrlType = $(el).data("customControl");

                    if (!ctrl) {
                        self.printPdfForStandardCtrl(el);
                        return;
                    }

                    switch (ctrlType) {
                        case 'combo':
                            self.printPdfForComboCtrl(el);
                            break;
                        case 'gridx':
                        case 'gridxchild':
                            // inserisco in array e stampo alla fine
                            ctrlsGrid.push(el);
                            break;
                    }
                });

            // stampa le griglie dopo i campi principali
            _.forEach(ctrlsGrid, function (el) {
                var ctrlType = $(el).data("customControl");
                if (ctrlType === 'gridx') {
                    // self.printGridControl(el);
                    // anche per le gird nomrali utilizzo plugin "autoTable"
                    self.printGridChildControl(el);
                }

                if (ctrlType === 'gridxchild') {
                    self.printGridChildControl(el);
                }
            });

            this.doc.save(this.metaPage.name.split(/\s+/).join('') + '.pdf')
        },

        /**
         * pritn values for dropDown (html select)
         * @param el
         */
        printPdfForComboCtrl:function (el) {
            var helpForm = this.metaPage.helpForm;
            var eltag = $(el).data("tag");
            var tag = helpForm.getStandardTag(eltag); // recupero il tag, serve per prendere tabella e colonna
            var tableName = helpForm.getTableName(tag);
            var columnName = helpForm.getColumnName(tag);
            var dc = this.metaPage.state.DS.tables[tableName].columns[columnName];
            var text = '';
            var optionSelected = $('#' + $(el).attr('id') + ' option:selected');
            var value = '';
            if (optionSelected && optionSelected.length) {
                value = optionSelected.text();
            }
            text = dc.caption + ': ' + value;
            this.printRow(text);
        },

        /**
         * print grid with grid child nested
         * @param el
         */
        printGridChildControl: function(el) {
            var self =this;
            var eltag = $(el).data("tag");

            // aggiungo nuovo foglio
            this.doc.addPage(this.sheetFormat, 'landscape');
            this.top = 15;
            this.left = 40;
            var helpForm = this.metaPage.helpForm;

            var tableName = helpForm.getField(eltag, 0);

            this.printRow('Tabella ' + tableName);

            // torna array di datacolum che sono le colonne visibili
            var getDataColumnsFromTable = function (tname) {
                var dataTable = self.metaPage.state.DS.tables[tname];
                return _.sortBy(
                    _.filter(dataTable.columns,
                        function (c) {
                            if (!c.caption) return false;
                            if (c.caption === "") return false;
                            if (c.caption.startsWith(".")) return false;
                            if (c.listColPos === -1) return false;
                            return true;
                        }),
                    'listColPos');
            };

            // torna array di array, in cui l'elemento sono i valori della riga
            var getRowsFromTable = function (tname, filter) {
                var dataBody = [];
                var rows = self.metaPage.state.DS.tables[tname].rows;
                if (filter) {
                    rows = self.metaPage.state.DS.tables[tname].select(filter);
                }
                _.forEach(rows, function (row) {
                    var myRow = [];
                    var cols = getDataColumnsFromTable(tname);
                    _.forEach(cols, function (col) {
                        var value = row[col.name] !== null && row[col.name] !== undefined ? row[col.name] : ' ';

                        if (col.ctype === "DateTime" && value) {
                            value = value.getDate().toString() + '/' +value.getMonth().toString() + '/' + value.getFullYear().toString()
                        }

                        myRow.push(value.toString()); // toString altrimenti non stampa i numeri
                    });
                    dataBody.push(myRow);
                });
                return dataBody;
            };

            var maincols = getDataColumnsFromTable(tableName);

            this.doc.autoTable({
                theme: 'grid',
                head: [maincols.map(function (c) {return c.caption.split(/\s+/).join('')})],
                body: getRowsFromTable(tableName),
                columns: maincols.map(function (c) {
                    return {
                        title: c.caption.split(/\s+/).join(''),
                        dataKey: c.name
                    }
                }),
                startY: 20,
                didParseCell:function (dataEvent) {
                    var rows = dataEvent.table.body;
                    // altezza righe dinamica in base al contenuto delle colonne nipoti
                    if (dataEvent.row.section === 'body') {
                        // dataEvent.row.height = 300
                    }
                },
                didDrawCell: function (data) {
                    var childTables =  $(el).data("childtables");
                    // dataKey è il nome della colonna, che ritrovo su columncal
                    // data.column.raw è un obj con titel: e dataKey
                    if (data.cell.section === 'body') {
                        // data.cell.styles.minCellHeight
                        data.cell.width = 400;
                        // vedo se la colonna corrente è child
                        var childTable = _.find(childTables, {columncalc : data.column.dataKey});
                        if (childTable) {

                            var tname = childTable.tablename;

                            // recupero la relazione
                            var childRel = _.find(self.metaPage.state.DS.tables[tableName].childRelations(), {childTable: tname});

                            // prendo riga e colonna corrente, così individuo la cella
                            // var valueInCell = data.row.cells[data.column.dataKey].raw;

                            // recupero la riga padre
                            var currRow = self.metaPage.state.DS.tables[tableName].rows[data.row.index];
                            var childFilter = childRel.getChildFilter(currRow);

                            var childcols = getDataColumnsFromTable(tname);
                            data.row.height = 300;

                            // var childRows = objRow.getRow().getChildInTable(calcChildObj.tablename);

                            self.doc.autoTable({
                                startY: data.cell.y ,
                                margin: { left: data.cell.x },
                                tableWidth: data.cell.width ,
                                body: getRowsFromTable(tname, childFilter),
                                columns: childcols.map(function (c) {
                                    return {
                                        title: c.caption.split(/\s+/).join(''),
                                        dataKey: c.name
                                    }
                                }),

                            })
                        }
                    }
                },
            });
        },

        /**
         * Print grid
         * @param {html node} el
         */
        printGridControl: function(el) {
            var self = this;
            var eltag = $(el).data("tag");

            // aggiungo nuovo foglio
            this.doc.addPage(this.sheetFormat, 'landscape');
            this.top = 10;
            var helpForm = this.metaPage.helpForm;

            var tableName = helpForm.getField(eltag, 0);
            var listtype = helpForm.getField(eltag, 1);
            var edittype = helpForm.getField(eltag, 2);

            this.printRow('Tabella ' + tableName);

            var dataTable = this.metaPage.state.DS.tables[tableName];
            var cols = _.sortBy(
                _.filter(dataTable.columns,
                    function (c) {
                        if (!c.caption) return false;
                        if (c.caption === "") return false;
                        if (c.caption.startsWith(".")) return false;
                        if (c.listColPos === -1) return false;
                        return true;
                    }),
                'listColPos');
            var headers = this.createHeaders(cols.map(function (c) {
                return c.caption.split(/\s+/).join('');
            }));

            // array di righe , che sono oggetti del tipo {col1: value1, col2: value2} in cui col1 col2 sono le stesse dell'header
            var data = [];
            _.forEach(this.metaPage.state.DS.tables[tableName].rows, function (row) {
                var myRow = {};
                _.forEach(cols, function (col) {
                    var value = row[col.name] !== null && row[col.name] !== undefined ? row[col.name] : ' ';
                    var caption = col.caption.split(/\s+/).join('');
                    myRow[caption] = value.toString(); // toString altrmenti non stampa i numeri
                });
                data.push(myRow);
            });

            this.doc.table(this.left, this.top, data, headers,
                {
                    fontSize: this.textFontSize,
                    autoSize:true
                });
        },

        createHeaders:function(keys) {
            var result = [];
            for (var i = 0; i < keys.length; i += 1) {
                result.push({
                    id: keys[i],
                    name: keys[i],
                    prompt: keys[i],
                    align: "center",
                    width: 100,
                    height: 200,
                    padding: 1
                });
            }
            return result;
        },

        generateData: function(amount) {
            var result = [];
            var data = {
                coin: "100",
                game_group: "GameGrouppppppppppppppppppppppppppppppppp",
                game_name: "XPTO2",
                game_version: "25",
                machine: "20485861",
                vlt: "0"
            };
            for (var i = 0; i < amount; i += 1) {
                data.id = (i + 1).toString();
                result.push(Object.assign({}, data));
            }
            return result;
        },

        printRow: function (text) {
            this.doc.text(text, this.left, this.top);
            this.top += this.rowSpace;
        },

        printPdfForStandardCtrl:function (el) {
            var text = "";
            var helpForm = this.metaPage.helpForm;

            var tagName = el.get(0).tagName;
            var value = $(el).val();
            var eltag = $(el).data("tag");

            var tag = helpForm.getStandardTag(eltag); // recupero il tag, serve per prendere tabella e colonna
            var tableName = helpForm.getTableName(tag);
            var columnName = helpForm.getColumnName(tag);
            var dc = this.metaPage.state.DS.tables[tableName].columns[columnName];
            switch (tagName.toUpperCase()) {
                case "INPUT":
                    switch ($(el).attr("type").toUpperCase()) {
                        case "TEXT":
                        case "DATE":
                        case "PASSWORD":
                        case "TEXTAREA":
                            text = dc.caption + ': ' + value;
                            this.printRow(text);
                            break;
                        case "CHECKBOX":

                            break;
                        case "RADIO":

                            break;

                    }
                    break;
                case "TEXTAREA":
                    text = dc.caption + ': ' + value;
                    this.printRow(text);
                    break;
                case "DIV":
                case "SPAN":
                    console.log(el.data('customControl'));
                    break;
            }
        }

    };

    appMeta.PdfExport = new PdfExport();
}());
