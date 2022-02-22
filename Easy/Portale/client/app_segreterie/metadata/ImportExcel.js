
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
    /**
     * @constructor ImportExcel
     * @description
     * Esegue caricamento delle elzioni. chiama servizio di terze parti dal backend
     */
    function ImportExcel() {}

    ImportExcel.prototype = {
        constructor: ImportExcel,

        // idsParent ci sta alla prima posizione la chaive dell' oggetto principale
        importFileIntoTable:function(metaPage, file, spName, idsParent, headerRowPosition, tableName, parentKey ) {
            var reader = new FileReader();
            var self = this;

            if (!metaPage.state.currentRow) {
                return  metaPage.showMessageOk('Nessuna riga principale selezionata');
            }
            var id = idsParent[0];
            var waitingHandler ;

            var def = Deferred("importFileIntoTable");
            if (!file) {
                return def.resolve();
            }

            metaPage.showMessageOkCancel("Vuoi importare il file?")
                .then(function (res) {
                    if (res) {
                        reader.onload = (function (mydef) {
                            return  function (e) {
                                var data = e.target.result;
                                data = new Uint8Array(data);
                                var arr = [];
                                for (var i = 0; i !== data.length; ++i) {
                                    arr[i] = String.fromCharCode(data[i]);
                                }
                                var bstr = arr.join("");
                                var workbook = XLSX.read(bstr, {type: "binary", cellText: false, cellDates: true, raw: true});
                                //Convert the cell value to Json
                                var sheet_name_list = workbook.SheetNames;
                                // aggiungo {defval:""} altrimenti vengono skppate le colonne vuote e il json non voene ben formattato
                                var result = XLSX.utils.sheet_to_json(workbook.Sheets[sheet_name_list[0]], {
                                    defval: "",
                                    raw: false,
                                    rawNumbers: true,
                                    dateNF: "dd/mm/yyyy",
                                    range: headerRowPosition
                                });
                                self.importExcel(metaPage, result, spName, idsParent)
                                   .then(function () {
                                           waitingHandler =  metaPage.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
                                           return appMeta.getData.runSelectIntoTable(metaPage.state.DS.tables[tableName], metaPage.q.eq(parentKey, id));
                                       }).then(function() {
                                           return metaPage.freshForm(false, false);
                                       }).then(function() {
                                          metaPage.hideWaitingIndicator(waitingHandler);
                                          mydef.resolve()
                                       });
                            };
                        })(def);

                        reader.readAsArrayBuffer(file);

                    } else {
                        def.resolve();
                    }
                });

            def.promise()
        },

        importExcel:function(metaPage, items, spName, idsParent) {
            var def = Deferred("importExcel");
            var ds = new jsDataSet.DataSet("temp");
            var tSource = ds.newTable("_temp" + new Date().getTime());

            var normalizeColumnName = function(cname) {
                return cname
                    .replace(/\./g, "")
                    .replace(/\//g, "")
                    .replace(/ /g, "")
                    .toLowerCase()
            };

            if (items.length) {
                var waitingHandler = metaPage.showWaitingIndicator("Attendi l'importazione del file");
                // --> dal 1o item recupero le colonne
                var item1 = items[0];
                _.forEach(Object.keys(item1), function(key) {
                    if (key.startsWith("__EMPTY")) {
                        return true;
                    }
                    tSource.setDataColumn(normalizeColumnName(key), "String");
                });

                // ---> Add delle righe
                _.forEach(items, function(item) {
                    var objrow = {};
                    _.forEach(Object.keys(item), function(key) {
                        if (!key.startsWith("__EMPTY")) {
                            var v = item[key];
                            // formatto bene il numero per l'export. tolgo separatore di miglaiia e virgola diventa .
                            if (v && isNaN(v)) {
                                // se il rimpiazzo del punto e la traformazione della vrgola portano il valore ad essere un numero allora considero il nuovo valore
                                // Es: 3.799,1 => 3799.1
                                var vNUM = v.toString().replace(/\./g, "").replace(',', '.');
                                if (!isNaN(vNUM)) {
                                    v = vNUM
                                }
                            }

                            if (v) {
                                v = v.toString();
                            }
                            objrow[normalizeColumnName(key)] = v;
                        }
                    });
                    tSource.add(objrow);
                });


                appMeta.callWebService("importExcel",
                    {
                        spName: spName,
                        ds: getDataUtils.getJsonFromJsDataSet(ds, true),
                        idsParent:idsParent
                    }).then(function (msg) {
                        metaPage.hideWaitingIndicator(waitingHandler);
                        def.from(metaPage.showMessageOk(msg));
                    });
                return def.promise();
            }
            return def.resolve();
        },

    };

    appMeta.ImportExcel = new ImportExcel();
}());
