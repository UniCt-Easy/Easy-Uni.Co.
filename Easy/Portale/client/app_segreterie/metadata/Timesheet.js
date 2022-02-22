
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
 * @module Timesheet
 * @description
 * Contiene il codice per realizzare un timesheet. Utilizza le librerie online di infragistcis per creare excel.
 */
(function () {

    var q = window.jsDataQuery;
    var utils = appMeta.utils;

    var ETemplateType = {
        HORIZON: "HORIZON",
        PON: "PON"
    };

    /**
     * @constructor Timesheet
     * @description
     * Chiamato da una subPage, che una caller Page con tabella dove recuperare le info su registry.
     * ==> La pagina chiamante deve avere le tabelle, contratto, contrattokind e inquadramento.
     */
    function Timesheet() {
        this.COLOR_MONTH = "#ff3333";
        this.COLOR_ROW_PROG = "#efeff5";
        this.COLOR_ROW_TOTAL = "#c0c0d8";
        this.COLOR_CELL_FRONTESPIZIO = "#ff3333";
        this.offsetX = 1;
        this.offsetY = 2;
        this.offsetXYear = -1;
        this.offsetYYear = 10;

        this.HorizonInitialY = 5;

        this.PON_logo_path = 'assets/PONLogo.png';

        // logo uni in caso hor
        this.topLeftLogoHOR = 'F2';
        this.bottomRigthLogoHOR = 'H8';
        // pon logo
        this.topLeftLogoPON = 'C2';
        this.bottomRigthLogoPON = 'K9';
    }

    Timesheet.prototype = {
        constructor: Timesheet,

        /**
         *
         * @param opts
         * @returns {*}
         */
        buildAndGetTimesheet:function(opts) {
            this.metaPageState = opts.state;
            var def = appMeta.Deferred("buildAndGetTimesheet");
			var self = this;

			var filterTeachOrProj = q.or(opts.filterProgetti, q.eq('progetto', 'Teaching activities'));

            var filter = q.and(
                q.eq("anno", opts.year),
                q.eq("idreg", opts.idreg),
				filterTeachOrProj
            );
            var currDt = null;
            appMeta.getData.runSelect('timesheetview', 'idreg,anno,data,ore,giorno,mese,progetto,workpackage,dipartimento,responsabile', filter, null)
                .then(function (dt) {
                    currDt  = dt;
                    return self.getLogo(opts);
                }).then(function (logoBase64) {
                    // crea datatable
                    return def.from(self.buildTimesheetTable(currDt, opts, logoBase64));
                }).fail(function (err) {
                    def.reject(err);
                });

            return def.promise();
        },

        /**
         *
         * @param {string} imgUrl
         * @param {Function} callback
         */
        getBase64Image: function(imgUrl, callback) {
            var img = new Image();
            // onload fires when the image is fully loadded, and has width and height
            img.onload = function(){
                var canvas = document.createElement("canvas");
                canvas.width = img.width;
                canvas.height = img.height;
                var ctx = canvas.getContext("2d");
                ctx.drawImage(img, 0, 0);
                var dataURL = canvas.toDataURL("image/png");
                dataURL = dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
                callback(dataURL); // the base64 string
            };

            // set attributes and src
            img.setAttribute('crossOrigin', 'anonymous'); //
            img.src = imgUrl;
        },

        /**
         *
         * @returns {Deferred(string)}
         */
        getLogo: function(opts) {
            var def = appMeta.Deferred("getLogo");
            // meccanismo di cache del logo
            /*if (appMeta.logoBase64) {
                return def.resolve(appMeta.logoBase64);
            }*/
            if (opts.idtimesheettemplate === ETemplateType.HORIZON) {
                return def.from(this.downloadLogo());
            }
            if (opts.idtimesheettemplate === ETemplateType.PON) {
                return def.from(this.getPONlogo());
            }
        },

        /**
         *
         * @returns {Deferred(string)}
         */
        getPONlogo:function() {
            // è un img locale al sito
            var def = appMeta.Deferred("getPONlogo");
            var imgUrl = this.PON_logo_path;
            this.getBase64Image(imgUrl, function(logoBase64){
                appMeta.logoBase64 =  "data:image/png;base64," + logoBase64;
                def.resolve(appMeta.logoBase64);
            });
            return def.promise();
        },

        /**
         * call ws "downloadLogo" to downloading uni logo
         * @returns {*}
         */
        downloadLogo:function() {
            var def = appMeta.Deferred("downloadLogo");
            appMeta.callWebService("downloadLogo", {})
                .then(function (logoBase64) {
                    appMeta.logoBase64 = "data:image/png;base64," + logoBase64;
                    def.resolve(appMeta.logoBase64);
                })
                .fail(function(){
                    console.log("missing timesheet logo");
                    def.resolve(null);
                });
            return def.promise();
        },

        /**
         * ASYNC
         * @param {DataTable} dtInput
         * @param {Object} opts
         * @param {string} logoBase64
         * @returns {*}
         */
        buildTimesheetTable: function (dtInput, opts, logoBase64) {
            var def = appMeta.Deferred("buildTimesheetTable");
            // ragruppo per progetto e poi per workpackage, ma Teaching activities va per ultimo
            dtInput.rows = _.sortBy(dtInput.rows, function (r) {
                if (r.progetto === 'Teaching activities') return "zzz";
                return r.progetto;
            });

            var objGrouped = this.calcObjGrouped(dtInput.rows, ["progetto", "workpackage"]);
            // 1. init file excel
            var workbook = new $.ig.excel.Workbook($.ig.excel.WorkbookFormat.excel2007);

            try {
                // 1o foglio con dettaglio dell'anno
                if (opts.riepilogoanno) {
                    var sheet = workbook.worksheets().add(opts.year.toString());
                    this.addYearResumeSheet(sheet, objGrouped, dtInput, opts, logoBase64);
                }
                // se c'è l'instestazione su tutti i fogli allora traslo la Y per i mesi
                if (opts.intestazioneallsheet){
                    this.offsetY += this.offsetYYear;
                }
                // 2. aggiungo i fogli, 1 per mese
                for (var monthCounter = 1; monthCounter <= 12; monthCounter++) {
                    this.calcTimeSheetTable(workbook, objGrouped, monthCounter, dtInput, opts, logoBase64);
                }
                // Salva file excel
                this.saveWorkbook(workbook, "TimeSheet_" + opts.year + "_" + opts.idreg + ".xlsx");
            } catch (e) {
                return def.reject("Errore nella generazione del timesheet: " + e.message);
            }
            return def.resolve();
        },

        /**
         * @method saveWorkbook
         * @private
         * @description ASYNC
         * @param {string} workbook
         * @param {string} name
         */
        saveWorkbook: function (workbook, name) {
            try {
                workbook.save({ type: 'blob' }, function (data) {
                    saveAs(data, name);
                }, function (error) {

                });
            } catch (e) {
                throw new Error(e.__message);
            }
        },

        /**
         * @method addYearResumeSheet
         * @private
         * @description SYNC
         * resume for each month
         * @param {Sheet} sheet
         * @param {Object} obj
         * @param {string} dtInput
         * @param {Object} opts
         */
        addYearResumeSheet: function(sheet, obj, dtInput, opts, logoBase64) {
            this.addSheetLogo(sheet,opts, logoBase64);
            this.buildFrontespizio(sheet, opts, dtInput);
            this.createHeadersYear(sheet, opts.year);
            this.addDataYearResume(sheet, obj, dtInput, opts);
        },

        addDataYearResume: function(sheet, obj, dtInput, opts) {
            var self = this;
            var rowIndex = 2; // le prime 2 sono header  1 per giorni + 1 vuota
            // 2. scorro i progetti
            _.forOwn(obj, function (el, pkey) {
                var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, pkey, el, dtInput);
                rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
            });
            this.addRowOtherActivitiesMonth(sheet, rowIndex, dtInput, opts.year);
            if (opts.showactivitiesrow) {
                rowIndex++;
                this.addLastRowWithTotalActivitiesMonth(sheet, rowIndex, dtInput);
            }
            rowIndex++;
            this.addLastRowWithTotalMonth(sheet, rowIndex, dtInput, opts.year);
        },

        /**
         * @method addSheetLogo
         * @private
         * @param {Worksheet} sheet
         * @param {Object} opts
         * @param {string} logoBase64
         */
        addSheetLogo:function(sheet, opts, logoBase64) {
            try {
                if (!logoBase64) {
                    return;
                }
                // default oppure progetto di tipo horizon
                var topLeftLogo = this.topLeftLogoHOR;
                var bottomRigthLogo = this.bottomRigthLogoHOR;

                if (opts.idtimesheettemplate === ETemplateType.PON) {
                    topLeftLogo = this.topLeftLogoPON;
                    bottomRigthLogo = this.bottomRigthLogoPON;
                }
                var imageShape = new $.ig.excel.WorksheetImage(logoBase64);
                imageShape.topLeftCornerCell(sheet.getCell(topLeftLogo));
                imageShape.bottomRightCornerCell(sheet.getCell(bottomRigthLogo));
                sheet.shapes().add(imageShape);
            } catch (e) {}
        },

        /**
         * @method addLastRowWithTotalMonth
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         * @param year
         */
        addLastRowWithTotalMonth: function (sheet, rowIndex, dtInput, year) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + this.offsetYYear, posX(0) + this.offsetXYear,
                posY(rowIndex) + this.offsetYYear, posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.value("Total hours");
            var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            xlRow.cellFormat().font().bold(true);
            var globalTot = 0;
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var daysInMonth = this.getNumDaysInMonth(counterMonth);
                var totalMonth = 0;
                for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                    var d = new Date(year, counterMonth - 1, counterDay);
                    var tot = _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: counterMonth }), 'ore');
                    // sab domenica e g di sospensione inserisco ore reali, per altri giorni anche, ma se sono meno di 8 avrò le other activities, quindi totale 8
                    if (!this.isZeroOtherActivitiesDay(d) && tot < 8) {
                        tot = 8;
                    }
                    totalMonth += tot;
                }
                globalTot += totalMonth;
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, totalMonth);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            }

            // totale globale
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, globalTot);
        },

        /**
         * @method addLastRowWithTotalActivitiesMonth
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         */
        addLastRowWithTotalActivitiesMonth: function (sheet, rowIndex, dtInput) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + this.offsetYYear, posX(0) + this.offsetXYear,
                posY(rowIndex) + this.offsetYYear, posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.value("Activities hours");
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
			var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            xlRow.cellFormat().font().bold(true);
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex,
                    _.sumBy(_.filter(dtInput.rows, { mese: counterMonth }), 'ore'));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            }

            // aggiungo cella per il totale
            var total = _.sumBy(dtInput.rows, 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX, total);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
        },

        /**
         * @method addRowOtherActivitiesMonth
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         * @param year
         */
        addRowOtherActivitiesMonth: function (sheet, rowIndex, dtInput, year) {
            // 1. aggiungo riga per "Other activities"
            // calcolata per giorno come differenza riseptto ad un numero fisso di 8ore
            var posY = this.posY.bind(this) ;
            var posX = this.posX.bind(this) ;
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + this.offsetYYear, posX(0) + this.offsetXYear,
                posY(rowIndex) + this.offsetYYear, posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.value("Other activities");
            var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var totalYear = 0;
            // calcolo la somma per ogni messi stando attenti a non considerare sabato domenica e giorni di sospensione
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var daysInMonth = this.getNumDaysInMonth(counterMonth);
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                var totalMonth = 0;
                for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                    var d = new Date(year, counterMonth - 1, counterDay);
                    var maxDayHour = 8;
                    var diff = maxDayHour - _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: counterMonth }), 'ore');
                    if (diff < 0 || this.isZeroOtherActivitiesDay(d)) {
                        diff = 0;
                    }
                    totalMonth += diff;
                }
                xlRow.setCellValue(dataCellIndex, totalMonth);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
                totalYear += totalMonth;
            }

            // aggiungo cella per il totale
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, totalYear);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
        },

        /**
         * @method getProgettoTimeSheetYear
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param progettokey
         * @param progettoObj
         * @param dtInput
         * @returns {number}
         */
        getProgettoTimeSheetYear: function (sheet, rowIndex, progettokey, progettoObj, dtInput) {
            var self = this;
            // 1. aggiungo riga del progetto
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var currRowIndex = 0;
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + this.offsetYYear, posX(0) + this.offsetXYear,
                posY(rowIndex) + this.offsetYYear, posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.value(progettokey);
            var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
			for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
					var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
					xlRow.setCellValue(dataCellIndex, this.getDaySumProjectMonth(dtInput, progettokey, counterMonth));
					sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
					sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
			}

            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey}), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, total);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            // 2. scorro i workpackege del progetto e creo riga
            _.forOwn(progettoObj.group, function (el, wpkey) {
                if (wpkey !== 'Teaching activities') {
                    currRowIndex++;
                    self.getWorkpackageTimeSheetMonth(sheet, currRowIndex + rowIndex, wpkey, progettokey, dtInput);
                }
            });

            // contatore di riga successiva da passare al chiamante il quale deve aggiungere altre righe
            return currRowIndex;
        },

        buildFrontespizioHorizon:function(sheet, opts, dtInput) {
            var year = opts.year;
            var secondHeaderColX = 3;
            this.HorizonInitialY = 5;
            var mergedCell = sheet.mergedCellsRegions().add(1, 1, 1, 5);
            mergedCell.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCell.cellFormat().font().height(16 * 28);
            mergedCell.cellFormat().font().bold(true);
            mergedCell.value("Timesheet summary");

            sheet.columns(this.offsetX + this.offsetXYear).setWidth(200, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            sheet.columns(this.offsetX + this.offsetXYear + 1).setWidth(300, $.ig.excel.WorksheetColumnWidthUnit.pixel);

            var xlRowTitleProj = sheet.rows(this.HorizonInitialY);
            xlRowTitleProj.setCellValue(this.offsetX + this.offsetXYear, 'Title of the action (acronym)');
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            xlRowTitleProj.setCellValue(this.offsetX + this.offsetXYear  + 1, this.getProgetti(dtInput));
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear + 1).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowTitleProj.cells(this.offsetX + this.offsetXYear + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            this.HorizonInitialY++;
            var xlRowFullName = sheet.rows(this.HorizonInitialY);
            xlRowFullName.setCellValue(this.offsetX + this.offsetXYear, 'Full name of beneficiary');
            xlRowFullName.cells(this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowFullName.cells(this.offsetX + this.offsetXYear).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullName.cells(this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullName.cells(this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullName.setCellValue(this.offsetX + this.offsetXYear  + 1, this.getBeneficiari(dtInput));
            xlRowFullName.cells(this.offsetX + this.offsetXYear + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);


            xlRowFullName.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX, 'Ruolo/Qualifica');
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowFullName.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX + 1, this.getRuoloQualifica(dtInput));
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullName.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            this.HorizonInitialY++;
            var xlRowFullEmployee = sheet.rows(this.HorizonInitialY);
            xlRowFullEmployee.setCellValue(this.offsetX + this.offsetXYear, 'Full name employee');
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowFullEmployee.setCellValue(this.offsetX + this.offsetXYear  + 1, this.getEmployee());
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            // CLASSE
            xlRowFullEmployee.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX, 'Classe');
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowFullEmployee.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX + 1, this.getClasse());
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullEmployee.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            this.HorizonInitialY++;
            var xlRowHeadOfDept = sheet.rows(this.HorizonInitialY);

            xlRowHeadOfDept.setCellValue(this.offsetX + this.offsetXYear, 'Head of Dept.');
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowHeadOfDept.setCellValue(this.offsetX + this.offsetXYear  + 1, this.getHeadOfDept());
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            // SCATTO
            xlRowHeadOfDept.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX, 'Scatto');
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowHeadOfDept.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX + 1, this.getScatto());
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowHeadOfDept.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            this.HorizonInitialY++;
            // Year
            var xlRowYear = sheet.rows(this.HorizonInitialY);
            xlRowYear.setCellValue(this.offsetX + this.offsetXYear, 'year');
            xlRowYear.cells(this.offsetX + this.offsetXYear).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowYear.cells(this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowYear.cells(this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowYear.cells(this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowYear.setCellValue(this.offsetX + this.offsetXYear  + 1, year);
            xlRowYear.cells(this.offsetX + this.offsetXYear + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowYear.cells(this.offsetX + this.offsetXYear + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowYear.cells(this.offsetX + this.offsetXYear + 1).cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);

            // Full part time
            var xlRowFullParTime = sheet.rows( this.HorizonInitialY);
            xlRowFullParTime.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullParTime.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowFullParTime.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullParTime.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX, 'Full/part-time');
            xlRowFullParTime.cells(this.offsetX + this.offsetXYear + secondHeaderColX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowFullParTime.setCellValue(this.offsetX + this.offsetXYear + secondHeaderColX + 1, this.getFullTmePartime());
            xlRowFullParTime.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowFullParTime.cells(this.offsetX + this.offsetXYear + secondHeaderColX + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            this.HorizonInitialY++;
            var xlRowtotalWorkedH = sheet.rows(this.HorizonInitialY);
            xlRowtotalWorkedH.setCellValue(this.offsetX + this.offsetXYear, 'Total worked hours');
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            xlRowtotalWorkedH.setCellValue(this.offsetX + this.offsetXYear + 1, this.getTotalWorkedHours(dtInput, year));
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear + 1).cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear + 1).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRowtotalWorkedH.cells(this.offsetX + this.offsetXYear + 1).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
        },

        buildFrontespizioPON:function(sheet, opts, dtInput) {
            // TODO
        },

        /**
         * @method buildFrontespizio
         * @private
         * @description SYNC
         * @param sheet
         * @param opts
         * @param dtInput
         */
        buildFrontespizio: function(sheet, opts, dtInput) {
            switch (opts.idtimesheettemplate ) {
                case ETemplateType.HORIZON:
                    this.buildFrontespizioHorizon(sheet, opts, dtInput);
                    break;
                case ETemplateType.PON:
                    this.buildFrontespizioPON(sheet, opts, dtInput);
                    break;
                default:
                    this.buildFrontespizioHorizon(sheet, opts, dtInput);
            }
        },

        /**
         * @method getTotalWorkedHours
         * @private
         * @description SYNC
         * @param dtInput
         * @param year
         * @returns {number}
         */
        getTotalWorkedHours: function(dtInput, year) {
            var globalTot = 0;
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var daysInMonth = this.getNumDaysInMonth(counterMonth);
                var totalMonth = 0;
                for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                    var d = new Date(year, counterMonth - 1, counterDay);
                    var tot = _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: counterMonth }), 'ore');
                    // sab domenica e g di sospensione inserisco ore reali, per altri giorni anche, ma se sono meno di 8 avrò le other activities, quindi totale 8
                    if (!this.isZeroOtherActivitiesDay(d) && tot < 8) {
                        tot = 8;
                    }
                    totalMonth += tot;
                }
                globalTot += totalMonth;
            }
            return globalTot;
        },

        /**
         * @method getFromToContratto
         * @private
         * @description SYNC
         * @param rowContratto
         * @returns {string}
         */
        getFromToContratto: function (rowContratto) {
            var fromTo = [];
            if (rowContratto && rowContratto.start) {
                fromTo.push('Dal ' + rowContratto.start.toLocaleDateString());
                if (rowContratto.stop) {
                    fromTo.push('al ' + rowContratto.stop.toLocaleDateString());
                } else {
                    fromTo.push('- In corso');
                }
            }
            return fromTo.join(" ");
        },

        /**
         * @method getRuoloQualifica
         * @private
         * @description SYNC
         * @returns {string}
         */
        getRuoloQualifica:function() {
            var contratto = this.metaPageState.callerPage.getDataTable('contratto');
            var contrattokind = this.metaPageState.callerPage.getDataTable('contrattokind');
            var self = this;
            // torna la singola qualifica
            var getTitle = function (idcontrattokind) {
                var rows = contrattokind.select(q.eq('idcontrattokind', idcontrattokind));
                if (rows.length) {
                    return rows[0].title;
                }
                return '';
            };
            return _.reduce(contratto.rows, function(acc, row) {
                if (row.idcontrattokind) {
                    acc += " " + self.getFromToContratto(row);
                    acc += ": " + getTitle(row.idcontrattokind) + "\n";
                }
                return acc;
            }, '');
        },

        /**
         * @method getClasse
         * @private
         * @description SYNC
         * @returns {string}
         */
        getClasse:function() {
            var contratto = this.metaPageState.callerPage.getDataTable('contratto');
            var inquadramento = this.metaPageState.callerPage.getDataTable('inquadramento');
            var self = this;
            // torna la singola qualifica
            var getTitle = function (idinquadramento) {
                var rows = inquadramento.select(q.eq('idinquadramento', idinquadramento));
                if (rows.length) {
                    return rows[0].title;
                }
                return '';
            };
            return _.reduce(contratto.rows, function(acc, row) {
                if (row.idinquadramento) {
                    acc += " " + self.getFromToContratto(row);
                    acc += ": " + getTitle(row.idinquadramento) + "\n";
                }
                return acc;
            }, '');
        },

        /**
         * @method getFullTmePartime
         * @private
         * @description SYNC
         * @returns {*}
         */
        getFullTmePartime: function(){
            var contratto = this.metaPageState.callerPage.getDataTable('contratto');
            var self = this;
            var fullTime = 'FullTime';
            var partTime = 'PartTime';
            return _.reduce(contratto.rows, function(acc, row) {
                var partime = row.partime;
                var tempdef = row.tempdef;
                var res = '';
                // analizzo prima campo partime
                if (partime) {
                    if (partime === 100) {
                        res = fullTime;
                    }
                    if (partime < 100) {
                        res = partTime;
                    }
                }

                // se non è partime analizzo campo tempoDef
                if (!res && tempdef) {
                    res = partTime;
                    if (tempdef === 'S') {
                        res = fullTime;
                    }
                }

                if (res) {
                    acc += " " + self.getFromToContratto(row);
                    acc += ":" + res + "\n";
                }
                return acc;
            }, '');
        },

        /**
         * @method getScatto
         * @private
         * @description SYNC
         * @returns {string}
         */
        getScatto: function() {
            var contratto = this.metaPageState.callerPage.getDataTable('contratto');
            var self = this;
            return _.reduce(contratto.rows, function(acc, row) {
                if (row.scatto) {
                    acc += " " + self.getFromToContratto(row);
                    acc += ": " + row.scatto + "\n";
                }
                return acc;
            }, '');
        },

        /**
         * @method getProgetti
         * @private
         * @description SYNC
         * @param dtInput
         * @returns {string}
         */
        getProgetti: function(dtInput) {
            return this.getConatenationByValue(dtInput,'progetto');
        },

        /**
         * @method getBeneficiari
         * @private
         * @description SYNC
         * @param dtInput
         * @returns {string}
         */
        getBeneficiari: function(dtInput) {
            return this.getConatenationByValue(dtInput, 'dipartimento');
        },

        /**
         * @method getConatenationByValue
         * @private
         * @description SYNC
         * @param dtInput
         * @param field
         * @returns {string}
         */
        getConatenationByValue:function(dtInput, field){
            // uniq trova le chiavi uniche di field, la map prende solo le colonne field, e reduce costrusice la stringa
            return _.reduce(
                _.map(
                    _.uniqBy(dtInput.rows, field), field),
                function(acc, value, key ){
                    if (value) {
                        acc += value + "\n";
                    }
                    return acc;
                }, '');
        },

        /**
         * @method getEmployee
         * @private
         * @description SYNC
         * @returns {string}
         */
        getEmployee: function() {
            if (this.metaPageState.callerState.currentRow) {
                return this.metaPageState.callerState.currentRow.title;
            }
        },

        getHeadOfDept: function() {
            // TODO
            return '';
        },

        /**
         * @method createHeadersYear
         * @private
         * @description SYNC
         * @param sheet
         * @param year
         */
        createHeadersYear: function(sheet, year) {
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            this.columnIndexMonth = 2;
            sheet.columns(this.columnIndexMonth + this.offsetX + this.offsetXYear).setWidth(150, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            var mergedCellMonth = sheet.mergedCellsRegions().add(posY(0) + this.offsetYYear,
                posX(0) + this.offsetXYear,
                posY(1) + this.offsetYYear,
                posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellMonth.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellMonth.value(year.toString());
            mergedCellMonth.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellMonth.cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1));
            mergedCellMonth.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellMonth.cellFormat().font().height(16 * 22);
            mergedCellMonth.cellFormat().font().bold(true);
            var xlRowDayString = sheet.rows(this.offsetY + this.offsetYYear);
            xlRowDayString.cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1));
            xlRowDayString.cellFormat().font().bold(true);

            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var valueMonthString = this.getMonthColumnName(counterMonth);
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                sheet.columns(dataCellIndex).setWidth(150, $.ig.excel.WorksheetColumnWidthUnit.pixel);
                xlRowDayString.setCellValue(dataCellIndex, valueMonthString);
                sheet.rows(this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
                sheet.rows(this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                xlRowDayString.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }

            var mergedCellTotal = sheet.mergedCellsRegions().add(
                posY(0) + this.offsetYYear, posX(counterMonth + this.columnIndexMonth) + this.offsetXYear,
                posY(1) + this.offsetYYear, posX(counterMonth + this.columnIndexMonth) + this.offsetXYear);
            mergedCellTotal.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellTotal.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellTotal.cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1));
            mergedCellTotal.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.value("total");
        },

        /**
         * @method calcTimeSheetTable
         * @private
         * @description SYNC
         * @param workbook
         * @param obj
         * @param month
         * @param dtInput
         * @param opts
         */
        calcTimeSheetTable: function (workbook, obj, month, dtInput, opts, logoBase64) {
            // aggiungo 1 singolo foglio per il mese
            var year = opts.year;
            var showactivitiesrow = opts.showactivitiesrow;

            var sheet = workbook.worksheets().add(this.getMonthColumnName(month));

            if (opts.intestazioneallsheet){
                this.addSheetLogo(sheet, opts, logoBase64);
                this.buildFrontespizio(sheet, opts, dtInput);
            }

            this.createHeaders(sheet, month, year);
            var self = this;
            var rowIndex = 2; // le prime 2 sono header  1 per giorni + 1 per stringa giorno
            // 2. scorro i progetti
            _.forOwn(obj, function (el, pkey) {
                var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, pkey, el, dtInput, month);
                rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
            });
            this.addRowOtherActivities(sheet, rowIndex, dtInput, month, year);
            if (showactivitiesrow) {
                rowIndex++;
                this.addLastRowWithTotalActivities(sheet, rowIndex, dtInput, month, year);
            }
            rowIndex++;
            this.addLastRowWithTotal(sheet, rowIndex, dtInput, month, year);
        },

        /**
         * @method posX
         * @private
         * @description SYNC
         * @param posx
         * @returns {number}
         */
        posX: function (posx) {
            return posx + this.offsetX;
        },

        /**
         * @method posY
         * @private
         * @description SYNC
         * @param posy
         * @returns {number}
         */
        posY: function (posy) {
            return posy + this.offsetY;
        },

        /**
         * @method createHeaders
         * @private
         * @description SYNC
         * @param sheet
         * @param month
         * @param year
         */
        createHeaders: function (sheet, month, year) {
            // 1. aggiungo la riga di intestazione con i giorni
            // creo colonne
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            this.columnIndexMonth = 2;
            sheet.columns(this.columnIndexMonth + this.offsetX).setWidth(200, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            var mergedCellMonth = sheet.mergedCellsRegions().add(posY(0), posX(0), posY(1), posX(this.columnIndexMonth));
            mergedCellMonth.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellMonth.value(this.getMonthColumnName(month));
            mergedCellMonth.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellMonth.cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1));
            mergedCellMonth.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellMonth.cellFormat().font().height(16 * 22);
            mergedCellMonth.cellFormat().font().bold(true);
            var daysInMonth = this.getNumDaysInMonth(month);
            var xlRowDayString = sheet.rows(this.offsetY);
            var xlRowDayNumber = sheet.rows(1 + this.offsetY);
            xlRowDayString.cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1));
            xlRowDayString.cellFormat().font().bold(true);

            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var d = new Date(year, month - 1, counterDay);
                var valueDayString = moment(d).format('dddd').substr(0, 3);
                var valueDayNumber = d.getDate();
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRowDayString.setCellValue(dataCellIndex, valueDayString);
                sheet.rows(this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
                sheet.rows(this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                xlRowDayNumber.setCellValue(dataCellIndex, valueDayNumber);
                if (valueDayString.toUpperCase() === "SUN") {
                    sheet.rows(1 + this.offsetY).cells(dataCellIndex).cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo("red"));
                }
                xlRowDayString.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                xlRowDayNumber.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }

            var mergedCellTotal = sheet.mergedCellsRegions().add(
                posY(0), posX(counterDay + this.columnIndexMonth),
                posY(1), posX(counterDay + this.columnIndexMonth));
            mergedCellTotal.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellTotal.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellTotal.cellFormat().font().colorInfo(new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1));
            mergedCellTotal.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.value("total");
        },

        /**
         * @method getMonthColumnName
         * @private
         * @description SYNC
         * torna il nome del mese dato il suo indice da 1 a 12
         * Ad esempio per 1 torna january
         * @param month
         * @returns {string}
         */
        getMonthColumnName: function (month) {
            return moment(month, 'M').format('MMMM');
        },

        /**
         * @method addLastRowWithTotal
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         * @param month
         * @param year
         */
        addLastRowWithTotal: function (sheet, rowIndex, dtInput, month, year) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.value("Total hours");
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            xlRow.cellFormat().font().bold(true);
            var daysInMonth = this.getNumDaysInMonth(month);
            var globalTot = 0;
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var d = new Date(year, month - 1, counterDay);
                var tot = _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: month }), 'ore');
                // sab domenica e g di sospensione inserisco ore reali, per altri giorni anche, ma se sono meno di 8 avrò le other activities, quindi totale 8
                if (!this.isZeroOtherActivitiesDay(d) && tot < 8) {
                    tot = 8;
                }
                globalTot += tot;
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, tot);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            }

            // totale globale
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, globalTot);
        },

        /**
         * @method addLastRowWithTotalActivities
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         * @param month
         */
        addLastRowWithTotalActivities: function (sheet, rowIndex, dtInput, month) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.value("Activities hours");
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            var daysInMonth = this.getNumDaysInMonth(month);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex,
                    _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: month }), 'ore'));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            }

            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows, { mese: month }), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, total);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
        },

        /**
         * @method addRowOtherActivities
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         * @param month
         * @param year
         */
        addRowOtherActivities: function (sheet, rowIndex, dtInput, month, year) {
            // 1. aggiungo riga per "Other activities"
            // calcolata per giorno come differenza riseptto ad un numero fisso di 8ore
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.value("Other activities");
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var maxDayHour = 8;
            var total = 0;
            var daysInMonth = this.getNumDaysInMonth(month);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var d = new Date(year, month - 1, counterDay);
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                var diff = maxDayHour - _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: month }), 'ore');
                if (diff < 0 || this.isZeroOtherActivitiesDay(d)) {
                    diff = 0;
                }
                xlRow.setCellValue(dataCellIndex, diff);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
                total += diff;
            }

            // aggiungo cella per il totale
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, total);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
        },

        // sabato domenica e giorni di sospensione hanno zero in other activities
        isZeroOtherActivitiesDay: function (d) {
            var valueDayString = moment(d).format('dddd').substr(0, 3);
            if (valueDayString.toUpperCase() === "SUN" ||
                valueDayString.toUpperCase() === "SAT" || this.isSospensioneDay(d)) {
                return true;
            }
            return false;
        },

        /**
         * @method isSospensioneDay
         * @private
         * @description SYNC
         * @param d
         * @returns {boolean}
         */
        isSospensioneDay: function (d) {
            var isSospensione = false;
            if (appMeta.appMain.dtSospensioni) {
                // torna true se ricade fuori dalla sospensione
                isSospensione = !_.every(appMeta.appMain.dtSospensioni.rows, function (rowSosp) {
                    if (rowSosp.start && rowSosp.stop) return !(moment(d).isAfter(moment(rowSosp.start)) && moment(d).isBefore(moment(rowSosp.stop)));
                    return true;
                });
            }
            return isSospensione;
        },

        /**
         * @method getProgettoTimeSheet
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param progettokey
         * @param progettoObj
         * @param dtInput
         * @param month
         * @returns {number}
         */
        getProgettoTimeSheet: function (sheet, rowIndex, progettokey, progettoObj, dtInput, month) {
            var self = this;
            // 1. aggiungo riga del progetto
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var currRowIndex = 0;
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.value(progettokey);
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var daysInMonth = this.getNumDaysInMonth(month);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, this.getDaySumProject(dtInput, progettokey, month, counterDay));
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            }
            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, mese: month }), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, total);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            // 2. scorro i workpackege del progetto e creo riga
            _.forOwn(progettoObj.group, function (el, wpkey) {
                if (wpkey !== 'Teaching activities') {
                    currRowIndex++;
                    self.getWorkpackageTimeSheet(sheet, currRowIndex + rowIndex, wpkey, progettokey, dtInput, month);
                }
            });

            // contatore di riga successiva da passare al chiamante il quale deve aggiungere altre righe
            return currRowIndex;
        },

        /**
         * @method getDaySumProject
         * @private
         * @description SYNC
         * @param dtInput
         * @param progettokey
         * @param month
         * @param day
         * @returns {number}
         */
        getDaySumProject: function (dtInput, progettokey, month, day) {
            return _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, mese: month, giorno: day }), 'ore');
        },

        /**
         * @method getDaySumProjectMonth
         * @private
         * @description SYNC
         * @param dtInput
         * @param progettokey
         * @param month
         * @returns {number}
         */
        getDaySumProjectMonth: function (dtInput, progettokey, month) {
            return _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, mese: month }), 'ore');
        },

        /**
         * @method getWorkpackageTimeSheetMonth
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param workpackagekey
         * @param progettokey
         * @param dtInput
         */
        getWorkpackageTimeSheetMonth: function (sheet, rowIndex, workpackagekey, progettokey, dtInput) {
            // 1. aggiungo riga del workpackage
            var posY = this.posY.bind(this) ;
            var posX = this.posX.bind(this) ;
            var mergedCellWPName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + this.offsetYYear, posX(0) + this.offsetXYear,
                posY(rowIndex) + this.offsetYYear, posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellWPName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellWPName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellWPName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellWPName.value(workpackagekey);
            var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, this.getDaySumWorkpackageMonth(dtInput, progettokey, workpackagekey, counterMonth));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }
            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey }), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, total);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
        },

        /**
         * @method getWorkpackageTimeSheet
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param workpackagekey
         * @param progettokey
         * @param dtInput
         * @param month
         */
        getWorkpackageTimeSheet: function (sheet, rowIndex, workpackagekey, progettokey, dtInput, month) {
            // 1. aggiungo riga del workpackage
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellWPName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellWPName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellWPName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellWPName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellWPName.value(workpackagekey);

            var xlRow = sheet.rows(rowIndex + this.offsetY);
            var daysInMonth = this.getNumDaysInMonth(month);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, this.getDaySumWorkpackage(dtInput, progettokey, workpackagekey, month, counterDay));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }
            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows,
                { progetto: progettokey, workpackage: workpackagekey, mese: month }), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, total);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
        },

        /**
         * @method getDaySumWorkpackage
         * @private
         * @description SYNC
         * @param dtInput
         * @param progettokey
         * @param workpackagekey
         * @param month
         * @param day
         * @returns {number}
         */
        getDaySumWorkpackage: function (dtInput, progettokey, workpackagekey, month, day) {
            return _.sumBy(
                _.filter(dtInput.rows, {
                        progetto: progettokey,
                        workpackage: workpackagekey,
                        mese: month,
                        giorno: day
                    }
                ),
                'ore');
        },

        /**
         * @method getDaySumWorkpackageMonth
         * @private
         * @description SYNC
         * @param dtInput
         * @param progettokey
         * @param workpackagekey
         * @param month
         * @returns {number}
         */
        getDaySumWorkpackageMonth: function (dtInput, progettokey, workpackagekey, month) {
            return _.sumBy(
                _.filter(dtInput.rows, {
                        progetto: progettokey,
                        workpackage: workpackagekey,
                        mese: month
                    }
                ),
                'ore');
        },

        /**
         * @method calcObjGrouped
         * @private
         * @description SYNC
         * @param rows
         * @param columns
         * @returns {object}
         */
        calcObjGrouped: function (rows, columns) {
            var self = this;
            // se non ho colonne torno direttamente le righe
            if (!columns || !columns.length) return rows;
            // prendo nome della colonna
            return _.mapValues(
                _.groupBy(rows, columns[0]),
                function (values) {
                    return { group: self.calcObjGrouped(values, columns.slice(1)) };
                });
        },

        /**
         * @method calcObjGrouped
         * @private
         * @description SYNC
         * 1=gen
         * 12=dic
         * @param {number} month
         * @returns {number}
         */
        getNumDaysInMonth: function (month) {
            var date = new Date(2020, month - 1, 1);
            return moment(date).daysInMonth();
        }
    };

    appMeta.Timesheet = new Timesheet();
}());
