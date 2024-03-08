/**
/**
 * @module Timesheet
 * @description
 * Contiene il codice per realizzare un timesheet. Utilizza le librerie online di infragistcis per creare excel.
 */
(function () {

    var localResource = appMeta.localization;
    var q = window.jsDataQuery;
    var utils = appMeta.utils;
    var ETemplateType = {
        HORIZON: "HORIZON",
        PON: "PON",
        PNRR: "PNRR",
        PNC: "PNC",
        MISE: "MISE",
        PORCAMPANIA: "PORCAMPANIA",
        EMPIR: "EMPIR"
    };

    var pdfData = null;
    var pdfName = "";
    /**
     * @constructor Timesheet
     * @description
     * Chiamato da una subPage, che una caller Page con tabella dove recuperare le info su registry.
     * ==> La pagina chiamante deve avere le tabelle, registrylegalstatus, position e inquadramento.
     */
    function Timesheet() {

        this.pdf = false;
        this.signed = false;
        this.signedAllowed = true;

        this.COLOR_MONTH = "#ff3333";
        this.COLOR_ROW_PROG = "#efeff5";
        this.COLOR_ROW_TOTAL = "#c0c0d8";
        this.COLOR_CELL_FRONTESPIZIO = "#ff3333";
        this.COLOR_CELL_ERRORE = "#ff3333";

        this.verbose = true;

        // logo uni in caso HORIZON
        this.topLeftLogoHOR = 'F2';
        this.bottomRigthLogoHOR = 'H8';

        // logo PON
        this.topLeftLogoPON = 'E2';
        this.bottomRigthLogoPON = 'M9';
        this.PON_logo_path = 'assets/PONLogo.png';

        // logo PNRR
        this.topLeftLogoPNRR = 'E2';
        this.bottomRigthLogoPNRR = 'O9';
        this.PNRR_logo_path = 'assets/PNRRLogo.png';

        // logo PNC 
        this.PNC_logo_path = 'assets/PNCLogo.png';
        this.topLeftLogoPNC = 'E2';
        this.bottomRigthLogoPNC = 'O9';

        // logo PORCAMPANIA
        this.topLeftLogoPORCAMPANIA = 'E2';
        this.bottomRigthLogoPORCAMPANIA = 'O9';
        this.PORCAMPANIA_logo_path = 'assets/PORCAMPANIALogo.png';


        //posizione logo ateneo mesi
        this.timesheetLogoCellTL = 'AA2';
        this.timesheetLogoCellBR = 'AC8';

        //posizione logo ateneo anno
        this.timesheetLogoCellTLYear = 'N2';
        this.timesheetLogoCellBRYear = 'P8';

    }

    Timesheet.prototype = {
        constructor: Timesheet,

        /**
         * 1 - Metodo principale che ottiene i dati, chiama il metodo per la costruzione dell'excel e lo restituisce'
         * @param opts
         * @returns {*}
         */
        buildAndGetTimesheet: function (opts) {
            var waitingHandler = opts.metaPage.showWaitingIndicator("Attendi generazione timesheet");

            this.metaPageState = opts.state;
            this.opts = opts;
            this.pdf = opts.output == 'P' || opts.output == 'F';

            this.signed = opts.output == 'F';
            this.signedAllowed = true;

            this.offsetX = 1;
            //Y di partenza delle tabelle con i mesi
            this.offsetY = 2;
            this.offsetXYear = 0;
            //Y di partenza della tabella dell'anno e dei mesi se c'è l'intestazione in tutti i fogli
            this.offsetYYear = 10;

            var def = appMeta.Deferred("buildAndGetTimesheet");
            var self = this;

            //prendo solo i progetti spuntati e le teaching e other activites dalla vista ...
            var filterTeachOrProj = q.or(opts.filterProgetti, q.eq('progetto', 'Teaching activities'), q.eq('progetto', 'Other activities'), q.eq('progetto', 'Other Research Activities'));
            if (opts.idprogetto) {
                filterTeachOrProj = q.or(opts.filterProgetti, q.eq('progetto', 'Teaching activities'), q.eq('progetto', 'Other activities'), q.eq('progetto', 'Other Research Activities'), q.eq('idprogetto', opts.idprogetto));
            }

            var filter = q.and(
                q.eq("anno", opts.year),
                q.eq("idreg", opts.idreg),
                filterTeachOrProj
            );
            if (opts.idtimesheettemplate === ETemplateType.PNRR || opts.idtimesheettemplate === ETemplateType.PNC || opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                //... ma se è il template pnrr devo prendere tutto
                filter = q.and(
                    q.eq("anno", opts.year),
                    q.eq("idreg", opts.idreg)
                );
            }

            var currDt = null;

            appMeta.getData.runSelect('timesheetview', 'idreg,anno,data,ore,giorno,mese,progetto,cup,workpackage,dipartimento,responsabile,idprogetto,idreg_aziende_fin, codiceidentificativo, istituto, start, stop, nome, cognome, cf, oredivisionecostostipendio, tipo, titolo', filter, null)
                .then(function (dt) {
                    currDt = dt;
                    return self.getLogo(opts);
                })
                .then(function (logoBase64) {
                    // crea datatable

                    let filteroremaxgg = q.and([
                        q.eq("idreg", opts.idreg),
                        q.or(q.isNull("start"), q.le("start", new Date(opts.year, 11, 31))),
                        q.or(q.isNull("stop"), q.ge("stop", new Date(opts.year, 0, 1)))
                    ]);
                    appMeta.getData.runSelect("getoremaxgg", "*", filteroremaxgg, null)
                        .then(function (getoremaxgg) {
                            self.maxHoursPerDayTable = getoremaxgg;
                            opts.metaPage.hideWaitingIndicator(waitingHandler);
                            return def.from(self.buildTimesheetTable(currDt, opts, logoBase64))
                        }).fail(function (err) {
                            opts.metaPage.hideWaitingIndicator(waitingHandler);
                            def.reject(err);
                        });
                });

            return def.promise();
        },

        /**
         *
         * @param {string} imgUrl
         * @param {Function} callback
         */
        getBase64Image: function (imgUrl, callback) {
            var img = new Image();
            // onload fires when the image is fully loadded, and has width and height
            img.onload = function () {
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
        getLogo: function (opts) {
            var def = appMeta.Deferred("getLogo");

            if (!appMeta.logoBase64) {
                this.downloadLogo();
            }
            //template senza logo
            if (opts.idtimesheettemplate === ETemplateType.HORIZON || opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.EMPIR) {
                return def.resolve();
            }
            if (opts.idtimesheettemplate === ETemplateType.PON) {
                return def.from(this.getLogoFile(this.PON_logo_path));
            }
            if (opts.idtimesheettemplate === ETemplateType.PNRR) {
                return def.from(this.getLogoFile(this.PNRR_logo_path));
            }
            if (opts.idtimesheettemplate === ETemplateType.PNC) {
                return def.from(this.getLogoFile(this.PNC_logo_path));
            }
            if (opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                return def.from(this.getLogoFile(this.PORCAMPANIA_logo_path));
            }

        },

        /**
         *
         * @returns {Deferred(string)}
         */
        getLogoFile: function (imgUrl) {
            // è un img locale al sito
            var def = appMeta.Deferred("getPONlogo");
            this.getBase64Image(imgUrl, function (logoBase64Url) {
                logoBase64Url = "data:image/png;base64," + logoBase64Url
                return def.resolve(logoBase64Url);
            });
            return def.promise();
        },

        /**
         * call ws "downloadLogo" to downloading logo of Istitute if is not present in configuration
         * @returns {*}
         */
        downloadLogo: function () {
            var def = appMeta.Deferred("downloadLogo");
            if (appMeta.config.logoBase64) {
                appMeta.logoBase64 = appMeta.config.logoBase64;
                if (appMeta.config.timesheetLogoCellTL) 
                    this.timesheetLogoCellTL = appMeta.config.timesheetLogoCellTL;
                if (appMeta.config.timesheetLogoCellBR) 
                    this.timesheetLogoCellBR = appMeta.config.timesheetLogoCellBR;
                if (appMeta.config.timesheetLogoCellTLYear)
                    this.timesheetLogoCellTLYear = appMeta.config.timesheetLogoCellTLYear;
                if (appMeta.config.timesheetLogoCellBRYear)
                    this.timesheetLogoCellBRYear = appMeta.config.timesheetLogoCellBRYear;
                def.resolve(null);
            }
            else {
                appMeta.callWebService("downloadLogo", {})
                    .then(function (logoBase64) {
                        appMeta.logoBase64 = "data:image/png;base64," + logoBase64;
                        def.resolve(appMeta.logoBase64);
                    })
                    .fail(function () {
                        console.log("missing timesheet logo");
                        def.resolve(null);
                    });
                return def.promise();
            }
        },

        /**
         * ASYNC
         * 2 - Metodo per la costruzione dell'excel
         * @param {DataTable} dtInput
         * @param {Object} opts
         * @param {string} logoBase64
         * @returns {*}
         */
        buildTimesheetTable: function (dtInput, opts, logoBase64) {
            var waitingHandler = opts.metaPage.showWaitingIndicator("Attendi generazione timesheet");
            var self = this;

            var def = appMeta.Deferred("buildTimesheetTable");

            if (!opts.idprogetto && (opts.idtimesheettemplate === ETemplateType.PNC || opts.idtimesheettemplate === ETemplateType.PNRR || opts.idtimesheettemplate === ETemplateType.PON || opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA)) {
                return def.reject("Occorre selezionare un progetto principale.");
            } else {
                // ragruppo per progetto e poi per workpackage, ma Teaching activities va per ultimo
                dtInput.rows = _.sortBy(dtInput.rows, function (r) {
                    if (r.progetto === 'Other Research Activities') return "zzzx";
                    if (r.progetto === 'Other activities') return "zzzy";
                    if (r.progetto === 'Teaching activities') return "zzzz";
                    return r.progetto;
                });

                //se devo unire le attività didattiche con le altre attività
                if (opts.collapseteachingother == true) {
                    //scelgo la lingua
                    if (opts.idtimesheettemplate === ETemplateType.HORIZON || opts.idtimesheettemplate === ETemplateType.EMPIR)
                        this.lang = 'en';
                    else
                        this.lang = 'it';
                    _.forEach(dtInput.rows, function (r) {
                        if (self.lang == 'it') {
                            if (r.progetto === 'Other activities') r.progetto = "Attività ordinaria";
                            if (r.progetto === 'Teaching activities') r.progetto = "Attività ordinaria";
                        } else {
                            if (r.progetto === 'Other activities') r.progetto = "Institutional activities";
                            if (r.progetto === 'Teaching activities') r.progetto = "Institutional activities";
                       }
                    });
                }

                //per i template MISE, PON, POR tutti gli altri progetti finiscono in un rigo solo (tutti template in italiano)
                if (opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PON || opts.idtimesheettemplate === ETemplateType.POR || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                    _.forEach(dtInput.rows, function (r) {
                        if (r.idprogetto != opts.idprogetto && r.idprogetto != 99999 && r.idprogetto != 99998)
                            r.progetto = "Altri progetti finanziati";
                    });
                }

                var objGrouped;
                //raggruppo per ...
                if (opts.multilineType == true) {
                    //... progetto e workpackage e tipo
                    objGrouped = this.calcObjGrouped(dtInput.rows, ["progetto", "workpackage", "tipo"]);
                } else {
                    //... progetto e workpackage
                    objGrouped = this.calcObjGrouped(dtInput.rows, ["progetto", "workpackage"]);
                }


                // 1. init file excel
                var workbook = new $.ig.excel.Workbook($.ig.excel.WorkbookFormat.excel2007);

                try {
                    appMeta.utils._if(!this.metaPageState.callerPage)
                        ._then(function () {
                            //recupero i contratti dell'impiegato
                            var filter = q.eq("idreg", self.metaPageState.currentRow.idreg);
                            //query su timesheetview con il filtro calcolato
                            return appMeta.getData.runSelect("registrylegalstatus", "*", filter)
                                .then(function (dt) {
                                    self.contratto = dt;
                                    self.contrattokind = appMeta.currApp.currentMetaPage.getDataTable('position');
                                    self.inquadramento = appMeta.currApp.currentMetaPage.getDataTable('inquadramento');

                                   if (self.verbose)
                                        console.log("scaricati contratti");
                                    return true;
                                })
                        })
                        ._else(function () {
                            self.contratto = self.metaPageState.callerPage.getDataTable('registrylegalstatus');
                            self.contrattokind = self.metaPageState.callerPage.getDataTable('position');
                            self.inquadramento = self.metaPageState.callerPage.getDataTable('inquadramento');
                            return true;
                        })
                        .then(function () {

                            if (opts.idtimesheettemplate === ETemplateType.HORIZON) {
                                self.COLOR_MONTH = "#ff3333"; //rosso
                                self.COLOR_MONTH_FONT = new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1);//bianco
                                self.getFrontespizioData(opts, dtInput);
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PNRR) {
                                self.COLOR_MONTH = "#DCE6F1"; //azzurrino
                                self.COLOR_MONTH_FONT = null; //nero
                                self.offsetYYear = 18;
                                self.getFrontespizioData(opts, dtInput);
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PON) {
                                self.COLOR_MONTH = "#DCE6F1";//azzurrino
                                self.COLOR_MONTH_FONT = null;//nero
                                self.offsetYYear = 21;
                                self.getFrontespizioData(opts, dtInput);
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PNC) {
                                self.COLOR_MONTH = "#008200"; //verde
                                self.COLOR_MONTH_FONT = new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1);//bianco
                                self.offsetYYear = 18;
                                self.getFrontespizioData(opts, dtInput);
                            }

                            if (opts.idtimesheettemplate === ETemplateType.MISE) {
                                self.COLOR_MONTH = "#FFFFFF";//bianco
                                self.COLOR_MONTH_FONT = null;//nero
                                self.offsetYYear = 21;
                                self.getFrontespizioData(opts, dtInput);
                            }

                            if (opts.idtimesheettemplate === ETemplateType.EMPIR) {
                                self.COLOR_MONTH = "#FFFFFF";//bianco
                                self.COLOR_MONTH_FONT = null;//nero
                                self.offsetYYear = 16;
                                self.getFrontespizioData(opts, dtInput);
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                                self.COLOR_MONTH = "#99CCFF"; //azzurro
                                self.COLOR_MONTH_FONT = null; //nero
                                self.COLOR_ROW_TOTAL = "#CCCCFF";
                                self.offsetYYear = 26;
                                self.getFrontespizioData(opts, dtInput);
                            }

                            // 1o foglio con dettaglio dell'anno
                            if (opts.riepilogoanno) {
                                var sheet = workbook.worksheets().add(opts.year.toString());
                                self.addYearResumeSheet(sheet, objGrouped, dtInput, opts, logoBase64);
                            }
                            // se c'è l'instestazione su tutti i fogli allora traslo la Y per i mesi
                            if (opts.intestazioneallsheet) {
                                self.offsetY += self.offsetYYear;
                            }
                            // 2. aggiungo i fogli, 1 per mese
                            if (opts.mese) {
                                //2.1 opzione mese singolo
                                self.calcTimeSheetTable(workbook, objGrouped, opts.mese, dtInput, opts, logoBase64);
                            }
                            else {
                                //2.2 opzione anno intero
                                let startMonth = 1;
                                let stopMonth = 12;

                                if (opts.idsal) {
                                    //2.3 opzione sal, riduco ai soli mesi che lo riguardano
                                    let sal = appMeta.currApp.currentMetaPage.getDataTable('salelenchiview').select(q.eq('idsal', self.opts.idsal));
                                    if (sal.length) {
                                        let begin = new Date(self.opts.year, 0, 1);
                                        let end = new Date(self.opts.year, 11, 31);
                                        if (begin.getTime() < sal[0].start.getTime())
                                            begin = sal[0].start;
                                        if (end.getTime() > sal[0].sal_stop.getTime())
                                            end = sal[0].sal_stop;
                                        startMonth = begin.getMonth() + 1;
                                        stopMonth = end.getMonth() + 1;
                                    }
                                }

                                for (var monthCounter = startMonth; monthCounter <= stopMonth; monthCounter++) {
                                    self.calcTimeSheetTable(workbook, objGrouped, monthCounter, dtInput, opts, logoBase64);
                                }

                            }
                            // Salva file excel
                            if (self.pdf) {
                                self.docConvPdf(workbook, "TimeSheet_" + opts.year + "_" + opts.idreg + ".xlsx", self.signed);
                            } else {
                                self.saveWorkbook(workbook, "TimeSheet_" + opts.year + "_" + opts.idreg + ".xlsx");
                            }

                            opts.metaPage.hideWaitingIndicator(waitingHandler);

                        });

                } catch (e) {
                    if (this.verbose)
                        console.log("Errore nella generazione del timesheet: " + e.message);

                    opts.metaPage.hideWaitingIndicator(waitingHandler);

                    return def.reject("Errore nella generazione del timesheet: " + e.message);
                }
                return def.resolve();
            }
        },

        /**
         * @method saveWorkbook
         * @private
         * @description ASYNC
         *  5 - salva il file excel
         * @param {string} workbook
         * @param {string} name
         */
        saveWorkbook: function (workbook, name) {
            try {
                if (this.verbose)
                    console.log("5 - salva il file excel");
                workbook.save({ type: 'blob' }, function (data) {
                    saveAs(data, name);
                }, function (error) {

                });
            } catch (e) {
                if (this.verbose)
                    console.log(e.__message);

                throw new Error(e.__message);
            }
        },

        base64ToBlob: function (base64String, contentType) {
            // Split the base64 string to get the data and the encoding type (e.g., "data:image/png;base64,").
            const [header, data] = base64String.split(',');

            // Decode the base64 data to a byte array.
            const byteCharacters = atob(data);

            // Convert the byte array to an ArrayBuffer.
            const byteArray = new Uint8Array(byteCharacters.length);
            for (let i = 0; i < byteCharacters.length; i++) {
                byteArray[i] = byteCharacters.charCodeAt(i);
            }

            // Create a Blob using the ArrayBuffer and specified content type.
            return new Blob([byteArray], { type: contentType });
        },

        pdfLayerInject: function () {
            var divPdfLayer = '<div id="pdfLayer"><div id="pdfSignContainer"><div class="row"><div class="col-md-3 text-right"><label class="col-form-label">Username</label></div><div class="col-md-9"><input id="sign_username" type="text" class="form-control" /></div></div><div class="row"><div class="col-md-3 text-right"><label class="col-form-label">Password</label></div><div class="col-md-9"><input id="sign_password" type="password" class="form-control" /></div></div><div class="row"><div class="col-md-3 text-right"><label class="col-form-label">Otp</label></div><div class="col-md-9"><input id="sign_otp" class="form-control" /></div></div><div class="row"><div class="col-md-12"><div class="custom-control custom-radio"><label class="col-form-label">Formato:</label><input id="sign_typeP" type="radio" name="sign_type" class="custom-control-input" value="P" checked /><label>PAdES (pdf)</label><input id="sign_typeC" type="radio" name="sign_type" class="custom-control-input" value="C" /><label>CAdES (p7m)</label></div></div></div><div class="row" id="errUsername" style="margin-top:10px; display:none"><div class="col-md-12"><label class="col-form-label" style="color:red!important">Username obbligatoria</label></div></div><div class="row" id="errPassword" style="margin-top: 10px; display: none"><div class="col-md-12"><label class="col-form-label" style="color:red!important">assword obbligatoria</label></div></div><div class="row" id="errOtp" style="margin-top: 10px; display: none"><div class="col-md-12"><label class="col-form-label" style="color:red!important">Otp obbligatorio</label></div></div><div class="row" style="margin-top: 20px;"><div class="col-md-6 text-left"><input class="btn btn-primary" type="button" value="Firma Pdf" onclick="appMeta.Timesheet.doSignPdf()"></div><div class="col-md-6 text-right"><input class="btn btn-secondary" type="button" value="Download Pdf" onclick="appMeta.Timesheet.doNotSignPdf()"></div></div></div></div>';
            $('#progettotimesheet_personale_outputF').parent().parent().append(divPdfLayer);
        },

        pdfLayerRemove: function () {
            $('#pdfLayer').remove();
        },

        docConvPdf: function (workbook, name, signed) {
            var self = this;
            try {
                if (this.verbose)
                    console.log("5 - salva il file excel");

                var waitingHandler = appMeta.currApp.currentMetaPage.showWaitingIndicator("Creazione del documento pdf in corso");

                workbook.save({ type: 'blob' }, function (blobData) {

                    var formData = new FormData();
                    formData.append("file", blobData, name);

                    $.ajax({
                        url: appMeta.appMainConfig.docConvPdf_url,
                        type: "POST",
                        headers: {
                            "psk": appMeta.appMainConfig.docConvPdf_psk
                        },
                        "processData": false,
                        "contentType": false,
                        "data": formData,
                        success: function (data) {
                            appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);

                            if (signed && self.signedAllowed) {
                                // Data & Name
                                pdfData = data;
                                pdfName = name;

                                // SHOW POPUP
                                self.pdfLayerInject();
                            }
                            else {
                                if (signed && !self.signedAllowed)
                                    alert("Firma remota non consentita perchè il timesheet presenta degli errori. Correggere gli errori e provare nuovamente.");
                                // Fa partire il dowload del documento PDF
                                const downloadLink = document.createElement("a");
                                downloadLink.href = 'data:application/pdf;base64,' + data;  //URL.createObjectURL(blob);
                                downloadLink.download = name.replace(".xlsx", ".pdf");
                                document.body.appendChild(downloadLink);
                                downloadLink.click();
                                document.body.removeChild(downloadLink);
                            }
                        },
                        error: function (error) {
                            alert("Servizio di generazione PDF momentaneamente non disponibile. Riprovare più tardi");
                            appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);
                        }
                    });
                }, function (error) {
                    alert(error);
                });
            } catch (e) {
                var mess = e.message;
                if (e.__message)
                    mess = e.__message;
                if (this.verbose)
                    console.log(mess);

                throw new Error(mess);
            }
        },

        doNotSignPdf: function () {
            // Hide Layer
            this.pdfLayerRemove();

            // Hide Errors
            $('#errUsername').hide();
            $('#errPassword').hide();
            $('#errOtp').hide();

            // Fa partire il dowload del documento PDF
            const downloadLink = document.createElement("a");
            downloadLink.href = 'data:application/pdf;base64,' + pdfData;  //URL.createObjectURL(blob);
            downloadLink.download = name.replace(".xlsx", ".pdf");
            document.body.appendChild(downloadLink);
            downloadLink.click();
            document.body.removeChild(downloadLink);
        },

        doSignPdf: async function () {
            let self = this;

            $('#errUsername').hide();
            $('#errPassword').hide();
            $('#errOtp').hide();

            var sign_username = $('#sign_username')[0].value;
            var sign_password = $('#sign_password')[0].value;
            var sign_otp = $('#sign_otp')[0].value;
            var sign_type = "P";

            if (sign_username == "") {
                $('#errUsername').show();
                return;
            }
            if (sign_password == "") {
                $('#errPassword').show();
                return;
            }
            if (sign_otp == "") {
                $('#errOtp').show();
                return;
            }
            if ($('#sign_typeP')[0].checked)
                sign_type = 'P';
            if ($('#sign_typeC')[0].checked)
                sign_type = 'C';

            var waitingHandler = appMeta.currApp.currentMetaPage.showWaitingIndicator("Firma remota del documento pdf in corso");
            // WebService Firma
            appMeta.callWebService("signFile", {
                byteStream: pdfData,
                username: sign_username,
                password: sign_password,
                otp: sign_otp,
                type: sign_type
            }).then(function (res) {
                appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);
                // Se la result è un errore, ovvero un messaggio, contiene per forza degli spazi
                // altrimenti se ok, è uno stringone del pdf, quindi non contiene mai spazi
                if (res.includes(" ")) {
                    alert(res);
                }
                else {
                    // Create a temporary link element
                    var link = document.createElement('a');
                    link.href = "data:application/pdf;base64," + res;
                    if (sign_type == "P")
                        link.download = pdfName.replace(".xlsx", ".pdf");
                    else
                        link.download = pdfName.replace(".xlsx", ".p7m");

                    // Programmatically click the link to start the download and remove
                    link.click();
                    URL.revokeObjectURL(link.href);
                    self.pdfLayerRemove();
                }
            });
        },

        addBorder: function (sheet, y, maxcol, top) {
            //bordi orizzontali
            for (var counter = 0; counter <= maxcol; counter++) {
                if (top)
                    sheet.rows(y).cells(counter).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                else
                    sheet.rows(y).cells(counter).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            }
            //bordi verticali
            if (!top)
                for (var countery = 0; countery <= y; countery++) {
                    sheet.rows(countery).cells(0).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                    sheet.rows(countery).cells(maxcol).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                }
        },

        /**
         * @method addYearResumeSheet
         * @private
         * @description SYNC
         * 3 - Foglio di riepilogo per l'anno
         * @param {Sheet} sheet
         * @param {Object} obj
         * @param {string} dtInput
         * @param {Object} opts
         */
        addYearResumeSheet: function (sheet, obj, dtInput, opts, logoBase64) {
            if (this.verbose)
                console.log("3 - Foglio di riepilogo per l'anno");

            this.addBorder(sheet, 0, 18, true);
            this.addSheetLogo(sheet, opts, logoBase64, true);
            this.buildFrontespizio(sheet, opts, dtInput, 16);
            this.createHeadersYear(sheet, opts.year);
            this.addDataYearResume(sheet, obj, dtInput, opts);

        },

        /**
         * 3.1 - Tutte le righe dei progetti per il riepilogo dell'anno
         * @param {any} sheet
         * @param {any} obj
         * @param {any} dtInput
         * @param {any} opts
         */
        addDataYearResume: function (sheet, obj, dtInput, opts) {
            if (this.verbose)
                console.log("3.1 - Tutte le righe dei progetti per il riepilogo dell'anno");
            var self = this;
            var rowIndex = 2; // le prime 2 sono header  1 per giorni + 1 vuota

            //aggiungo anche l'idprogetto e l'ente finanziatore
            if (opts.multilineType) {
                _.forEach(obj, function (o) {
                    o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].progetto;
                    o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].cup;
                    o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idprogetto;
                    o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idreg_aziende_fin;
                });
            } else {
                _.forEach(obj, function (o) {
                    o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].progetto;
                    o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].cup;
                    o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idprogetto;
                    o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idreg_aziende_fin;
                });
            }

            // 2. scorro i progetti
            if (opts.idtimesheettemplate === ETemplateType.PNRR || opts.idtimesheettemplate === ETemplateType.PNC || opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {


                //2.1 aggiungo prima la riga del progetto principale
                let objPrg = _.filter(obj, function (o) { return o.idprogetto == opts.idprogetto });
                _.forEach(objPrg, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });


                //se è MISE e PORCAMPANIA ragruppa tutti gli altri insieme
                if (opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {

                    //poi quella dei progetti dello stesso ente finanziatore
                    let objFinEq = _.filter(obj, function (o) { return o.idprogetto != opts.idprogetto });
                    _.forEach(objFinEq, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });
                }
                else {
                    //PNRR e PNC

                    //2.2 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    //poi quella dei progetti dello stesso ente finanziatore
                    let objFinEq = _.filter(obj, function (o) { return o.idreg_aziende_fin == self.dataPnrr.enteFinanziatore && o.idprogetto != opts.idprogetto });
                    _.forEach(objFinEq, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    //2.3 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI:");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    //2.4 poi quella dei progetti con ente finanziatore diverso
                    let objFinNeq = _.filter(obj, function (o) { return o.idreg_aziende_fin != self.dataPnrr.enteFinanziatore });
                    _.forEach(objFinNeq, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });
                }

            } else {
                //HORIZON o EMPIR 

                if (opts.idtimesheettemplate === ETemplateType.EMPIR) {
                    self.getRowText(sheet, rowIndex, "In case of absence, indicate one of the reason codes below");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                }

                _.forOwn(obj, function (el, pkey) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.showOtherActivitiesrow) {
                this.addRowOtherActivitiesMonth(sheet, rowIndex, dtInput, opts.year);
                rowIndex++;
            }

            if (opts.showactivitiesrow) {
                this.addLastRowWithTotalActivitiesMonth(sheet, rowIndex, dtInput);
                rowIndex++;
            }
            this.addLastRowWithTotalMonth(sheet, rowIndex, dtInput, opts.year, opts);

            //il piè di pagina
            if (opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                rowIndex = this.buildPiedipagina(sheet, opts, dtInput, 16, rowIndex + this.offsetY + this.offsetYYear, null);
            }

            this.addBorder(sheet, rowIndex + this.offsetY + this.offsetYYear + 1, 18, false);

        },

        /**
         * @method addSheetLogo
         * @private
         * @param {Worksheet} sheet
         * @param {Object} opts
         * @param {string} logoBase64
         */
        addSheetLogo: function (sheet, opts, logoBase64, isYear) {
            try {

                //logo tipo progetto
                if (logoBase64) {

                    var topLeftLogo = this.topLeftLogoHOR;
                    var bottomRigthLogo = this.bottomRigthLogoHOR;

                    if (opts.idtimesheettemplate === ETemplateType.PON) {
                        topLeftLogo = this.topLeftLogoPON;
                        bottomRigthLogo = this.bottomRigthLogoPON;
                    }
                    if (opts.idtimesheettemplate === ETemplateType.PNRR ) {
                        topLeftLogo = this.topLeftLogoPNRR;
                        bottomRigthLogo = this.bottomRigthLogoPNRR;
                    }
                    if (opts.idtimesheettemplate === ETemplateType.PNC) {
                        topLeftLogo = this.topLeftLogoPNC;
                        bottomRigthLogo = this.bottomRigthLogoPNC;
                    }
                    if (opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                        topLeftLogo = this.topLeftLogoPORCAMPANIA;
                        bottomRigthLogo = this.bottomRigthLogoPORCAMPANIA;
                    }

                    var imageShape = new $.ig.excel.WorksheetImage(logoBase64);
                    imageShape.topLeftCornerCell(sheet.getCell(topLeftLogo));
                    imageShape.bottomRightCornerCell(sheet.getCell(bottomRigthLogo));
                    sheet.shapes().add(imageShape);
                }

                //logo ateneo
                if (appMeta.logoBase64) {
                    var imageShape = new $.ig.excel.WorksheetImage(appMeta.logoBase64);

                    if (isYear) {
                        imageShape.topLeftCornerCell(sheet.getCell(this.timesheetLogoCellTLYear));
                        imageShape.bottomRightCornerCell(sheet.getCell(this.timesheetLogoCellBRYear));
                    } else {
                        imageShape.topLeftCornerCell(sheet.getCell(this.timesheetLogoCellTL));
                        imageShape.bottomRightCornerCell(sheet.getCell(this.timesheetLogoCellBR));
                    }

                    if (opts.idtimesheettemplate === ETemplateType.HORIZON) {
                        imageShape.topLeftCornerCell(sheet.getCell('N2'));
                        imageShape.bottomRightCornerCell(sheet.getCell('P6'));
                    }

                    if (opts.idtimesheettemplate === ETemplateType.EMPIR) {
                        imageShape.topLeftCornerCell(sheet.getCell('B2'));
                        imageShape.bottomRightCornerCell(sheet.getCell('G8'));
                    }

                    sheet.shapes().add(imageShape);
                }
            } catch (e) { }
        },

        getMaxHourPerDay: function (date) {
            var role = localResource.schedulerNoRoleDefined;
            var maxHoursPerDay = this.maxHoursPerDay;
            var self = this;
            if (this.maxHoursPerDayTable) {
                _.forEach(this.maxHoursPerDayTable.rows, function (rowMaxDay) {
                    // se la data è compresa nell'intervallo allora torno il max numero di ore configurato su quell'intervallo
                    if (
                        (moment(date).isSameOrAfter(moment(rowMaxDay.start)) || !rowMaxDay.start) &&
                        (moment(date).isSameOrBefore(moment(rowMaxDay.stop)) || !rowMaxDay.stop)
                    ) {
                        maxHoursPerDay = (rowMaxDay.oremaxgg !== undefined && rowMaxDay.oremaxgg !== null) ? rowMaxDay.oremaxgg : self.maxHoursPerDay;
                        role = rowMaxDay.title;
                        // trovo il num di ore , esco dal ciclo
                        return false;
                    }
                });
            }

            return {
                role: role,
                maxHoursPerDay: maxHoursPerDay
            };
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
        addLastRowWithTotalMonth: function (sheet, rowIndex, dtInput, year, opts) {
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
            mergedCellProgName.value(this.lang == 'it' ? "Ore totali" : "Total hours");
            var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            xlRow.cellFormat().font().bold(true);
            var globalTot = 0;
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var isRed = false;
                var daysInMonth = this.getNumDaysInMonth(counterMonth, year);
                var totalMonth = 0;
                for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                    var d = new Date(year, counterMonth - 1, counterDay);
                    //ore rendicontate
                    var tot = _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: counterMonth }), 'ore');
                    //ore massime lavorabili
                    var maxHoursPerDayRole = this.getMaxHourPerDay(d);
                    var maxHours = maxHoursPerDayRole.maxHoursPerDay;

                    //SE ho calcolato la riga delle altre attività per differenza con le massime, allora ...
                    //...tranne che sabato, domenica e i gorni di sospensione se ha rendicontato meno delle ore lavorate/lavorabili ...
                    if (!this.isZeroOtherActivitiesDay(d) && tot < maxHours && opts.showOtherActivitiesrow) {
                        //...il mio totale sono le ore lavorate/lavorabili ...
                        tot = maxHours
                    }

                    if (maxHoursPerDayRole.role == 'Timbrature') {
                        //se ha sforato le timbrature...
                        if (tot > maxHours) {
                            //...la coloro di rosso
                            isRed = true;
                            //... metto il totale di quanto timbrato 
                            tot = maxHours;
                            //...blocco la firma
                            this.signedAllowed = false;
                        }
                    }

                    if (maxHoursPerDayRole.role == 'Consolidamenti') {
                        //se ha sforato oppure non saturato il consolidamento...
                        if (tot != maxHours) {
                            //...la coloro di rosso
                            isRed = true;
                            //... metto il totale di quanto consolidato 
                            tot = maxHours;
                            //...blocco la firma
                            this.signedAllowed = false;
                        }
                    }

                    //solo porcampania consegna anche il riepilogo annuale e quindi verifico l'assenza delle ore
                    if (opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                        //La vista in caso di utilizzo di timbrature restituisce questi ruoli speciali in caso di assenza
                        if (maxHoursPerDayRole.role == 'Consolidamento assente' || maxHoursPerDayRole.role == 'Timbratura assente') {
                            //...la coloro di rosso
                            isRed = true;
                            //... lascio il totale di quanto rendicontato 
                            //...blocco la firma
                            this.signedAllowed = false;
                        }
                    }

                    totalMonth += tot;
                }
                globalTot += totalMonth;
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, totalMonth);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_ERRORE : this.COLOR_ROW_TOTAL));
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
            mergedCellProgName.value(this.lang == 'it' ? "Ore totali in attività di ricerca" : "Total research activities hours");
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
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, total);
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
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
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
                var isRed = false;
                var daysInMonth = this.getNumDaysInMonth(counterMonth, year);
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                var totalMonth = 0;
                for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                    var d = new Date(year, counterMonth - 1, counterDay);
                    //ore massime lavorabili
                    var maxHoursPerDayRole = this.getMaxHourPerDay(d);
                    var maxDayHour = maxHoursPerDayRole.maxHoursPerDay;
                    var diff = maxDayHour - _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: counterMonth }), 'ore');
                    if (diff && diff < 0 && maxHoursPerDayRole.role == 'Timbrature') {
                        //se è una timbratura la segnalo in rosso e lascio il numero negativo
                        isRed = true;
                    } else {
                        //se se è sabato, domenica o interruzione 
                        //if(this.isZeroOtherActivitiesDay(d)) {
                        diff = 0;
                    }
                    totalMonth += diff;
                }
                xlRow.setCellValue(dataCellIndex, totalMonth);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_FRONTESPIZIO : this.COLOR_ROW_PROG));
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
         * 3.2 - Metodo per disegnare le righe del progetto nel riepilogo annuale
         * @param sheet
         * @param rowIndex
         * @param progettokey
         * @param progettoObj
         * @param dtInput
         * @returns {number}
         */
        getProgettoTimeSheetYear: function (sheet, rowIndex, progettokey, progettoObj, dtInput, opts) {
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
            //per i progetti pnrr ma non i tre "progetti speciali" che non sono progetti aggiungo il cup
            if ((opts.idtimesheettemplate === ETemplateType.PNRR || opts.idtimesheettemplate === ETemplateType.PNC)
                && progettokey !== 'Teaching activities' && progettokey !== 'Other activities' && progettokey !== 'Other Research Activities' && progettokey !== 'Attività ordinaria' && progettokey !== 'Institutional activities') {

                mergedCellProgName.value(progettokey + '; CUP:' + progettoObj.cup + ';');

            } else {

                mergedCellProgName.value(progettokey);

                if (opts.idtimesheettemplate === ETemplateType.MISE && progettoObj.idprogetto == opts.idprogetto) 
                    mergedCellProgName.value("Attività progetto");

                if (opts.idtimesheettemplate === ETemplateType.EMPIR && progettokey !== 'Institutional activities')
                    mergedCellProgName.value("Hours worked on project " + progettokey);

                if (this.lang == 'it' && progettokey == 'Teaching activities') {
                    mergedCellProgName.value('Attività di didattica');
                }
                if (this.lang == 'it' && progettokey == 'Other activities') {
                    mergedCellProgName.value('Altre attività');
                }
                if (this.lang == 'it' && progettokey == 'Other Research Activities') {
                    mergedCellProgName.value('Altre attività di ricerca');
                }
            }
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
            var total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey }), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, total);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            //se è stata indicata l'opzione di visualizzare i workpackage e non ho applicato il collasso su una riga sola del progetto corrente
            if (opts.withWorkpackage == true && progettokey != "Altri progetti finanziati") {
                // 2. scorro i workpackege del progetto e creo riga
                _.forOwn(progettoObj.group, function (el, wpkey) {
                    if (wpkey !== 'Teaching activities' && wpkey !== 'Other activities' && wpkey !== 'Other Research Activities') {
                        if (opts.multilineType == true) {
                            _.forOwn(el.group, function (elType, wpkeyType) {
                                currRowIndex++;
                                self.getWorkpackageTimeSheetMonth(sheet, currRowIndex + rowIndex, wpkey, progettokey, dtInput, opts, wpkeyType);
                            });
                        } else {
                            currRowIndex++;
                            self.getWorkpackageTimeSheetMonth(sheet, currRowIndex + rowIndex, wpkey, progettokey, dtInput, opts);
                        }
                    }
                });
            }

            // contatore di riga successiva da passare al chiamante il quale deve aggiungere altre righe
            return currRowIndex;
        },

        /**
         * Aggiunge una riga con solo un testo
         * @param {any} sheet
         * @param {any} rowIndex
         * @param {any} text
         */
        getRowText: function (sheet, rowIndex, text, month) {
            var self = this;
            // 1. aggiungo riga del progetto
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            let offsetYYear = 0;
            let offsetXYear = 0;
            if (!month) {
                offsetYYear = this.offsetYYear;
                offsetXYear = this.offsetXYear;
            }
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + offsetYYear, posX(0) + offsetXYear,
                posY(rowIndex) + offsetYYear, posX(this.columnIndexMonth) + offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.value(text);
            var xlRow = sheet.rows(rowIndex + this.offsetY + offsetYYear);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            for (var counterMonth = 1; counterMonth <= (!month ? 13 : self.getNumDaysInMonth(month, self.opts.year) + 1) ; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + offsetXYear;
                xlRow.setCellValue(dataCellIndex, '');
                sheet.rows(rowIndex + this.offsetY + offsetYYear).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY + offsetYYear).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
                if (counterMonth == (!month ? 13 : self.getNumDaysInMonth(month, self.opts.year) + 1 ))
                    sheet.rows(rowIndex + this.offsetY + offsetYYear).cells(dataCellIndex).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            }
        },


        //---------------------------------INIZIO FRONTESPIZIO-----------------------------------------------

        /**
         * @method buildFrontespizio
         * @private
         * @description SYNC
         * @param sheet
         * @param opts
         * @param dtInput
         */
        buildFrontespizio: function (sheet, opts, dtInput, maximumX, mese) {

            //imposto la lingua
            this.lang = 'en'
            moment.locale(this.lang);

            switch (opts.idtimesheettemplate) {
                case ETemplateType.HORIZON:
                    this.buildFrontespizioHorizon(sheet, opts, dtInput, mese);
                    break;
                case ETemplateType.PON:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPON(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PNRR:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPNRR(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PNC:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPNRR(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.MISE:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioMISE(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PORCAMPANIA:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPORCAMPANIA(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.EMPIR:
                    this.lang = 'en'
                    moment.locale(this.lang);
                    this.buildFrontespizioEMPIR(sheet, opts, dtInput, maximumX, mese);
                    break;
                default:
                    this.buildFrontespizioHorizon(sheet, opts, dtInput, mese);
            }

        },

        /**
         * Metodo per il recupero dati del Frontespizio
         * @returns
         */
        getFrontespizioData: function (opts, dtInput) {
            let self = this;

            let begin = new Date(self.opts.year, 0, 1);
            let end = new Date(self.opts.year, 11, 31);
            self.dataPnrr = null;
            if (dtInput.rows.length) {

                let principalProjectRows = dtInput.select(q.eq('idprogetto', opts.idprogetto));
                if (principalProjectRows.length) {
                    self.dataPnrr = {
                        'cup': principalProjectRows[0].cup ? principalProjectRows[0].cup : '',
                        'codice': principalProjectRows[0].codiceidentificativo ? principalProjectRows[0].codiceidentificativo : '',
                        'denominazione': principalProjectRows[0].description ? principalProjectRows[0].description : '',
                        'titolo': principalProjectRows[0].titolo ? principalProjectRows[0].titolo : '',
                        'progetto': principalProjectRows[0].progetto ? principalProjectRows[0].progetto : '',
                        'enteFinanziatore': principalProjectRows[0].idreg_aziende_fin ? principalProjectRows[0].idreg_aziende_fin : '',
                        'istituto': principalProjectRows[0].istituto ? principalProjectRows[0].istituto : '',
                        'nome': principalProjectRows[0].nome ? principalProjectRows[0].nome : '',
                        'cognome': principalProjectRows[0].cognome ? principalProjectRows[0].cognome : '',
                        'cf': principalProjectRows[0].cf ? principalProjectRows[0].cf : '',
                        'start': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin),//principalProjectRows[0].start ? appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(principalProjectRows[0].start) : '',
                        'stop': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end),//principalProjectRows[0].stop ? appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(principalProjectRows[0].stop) : '',
                        'oredivisionecostostipendio': principalProjectRows[0].oredivisionecostostipendio ? principalProjectRows[0].oredivisionecostostipendio : '',
                    }
                }
            }

            if (self.dataPnrr == null) {
                self.dataPnrr = {
                    'cup': '',
                    'codice': '',
                    'denominazione': '',
                    'titolo': '',
                    'enteFinanziatore': '',
                    'istituto': '',
                    'nome': '',
                    'cognome': '',
                    'cf': '',
                    'start': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin),
                    'stop': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end),
                    'oredivisionecostostipendio': '1500',
                }
            }

            //inizio e fine
            if (self.opts.mese) {
                begin = new Date(self.opts.year, self.opts.mese - 1, 1);
                self.dataPnrr.start = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin);
                end = new Date(self.opts.year, self.opts.mese - 1, self.getNumDaysInMonth(self.opts.mese, self.opts.year));
                self.dataPnrr.stop = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end);
            }

            if (self.opts.idsal) {
                let sal = appMeta.currApp.currentMetaPage.getDataTable('salelenchiview').select(q.eq('idsal', self.opts.idsal));
                if (sal.length) {
                    if (begin.getTime() < sal[0].start.getTime())
                        begin = sal[0].start;
                    self.dataPnrr.start = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin);
                    if (end.getTime() > sal[0].sal_stop.getTime())
                        end = sal[0].sal_stop;
                    self.dataPnrr.stop = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end);
                }
            }

            //totale
            self.dataPnrr.tot = _.sumBy(
                _.filter(dtInput.rows, function (r) {
                    return r.progetto == self.dataPnrr.progetto && r.data >= begin && r.data <= end;
                })
                , 'ore');

            //recupero il contratto al primo giorno del timesheet ---------------------------------------------------
            var contrattoCurr = _.find(self.contratto.rows, function (row) {
                return begin < (row.stop ? row.stop : new Date(2100, 0, 1))
                    && end > (row.start ? row.start : new Date(1900, 0, 1))
                    && row.idposition;
            });
            if (contrattoCurr) {
                var contrattokindCurrs = self.contrattokind.select(q.eq('idposition', contrattoCurr.idposition));
                if (contrattokindCurrs.length) {
                    let contrattokindCurr = contrattokindCurrs[0];
                    if (contrattokindCurr.tipopersonale == 'D' || contrattokindCurr.tipopersonale == 'R') {

                        //docente
                        self.dataPnrr.categoria = 'Docente'

                        self.dataPnrr.figuraContrattuale = 'Personale non contrattualizzato';
                        self.dataPnrr.livello = '';
                        if (contrattokindCurr.codeposition == '07_SW_PORD')
                            self.dataPnrr.livello = 'ALTO (Professore Ordinario)';
                        if (contrattokindCurr.codeposition == '07_SW_PASC' || contrattoCurr.codeposition == '07_SW_PASN')
                            self.dataPnrr.livello = 'MEDIO (Professore Associato)';
                        if (contrattokindCurr.codeposition == '07_SW_RICN' || contrattoCurr.codeposition == '07_SW_RICC' || contrattoCurr.codeposition == 'RUT')
                            self.dataPnrr.livello = 'BASSO (Ricercatore)';

                        self.dataPnrr.classe = contrattoCurr.incomeclass
                        self.dataPnrr.scatto = contrattoCurr.livello
                        self.dataPnrr.fullTime = (contrattoCurr.tempdef ? contrattoCurr.tempdef : 'N') == 'N' ? 'Full-Time' : 'Part-Time'
                    } else {

                        //pta
                        self.dataPnrr.categoria = 'Impiegato'
                        var getTitle = function (idposition) {
                            var rows = self.contrattokind.select(q.eq('idposition', idposition));
                            if (rows.length) {
                                return rows[0].title;
                            }
                            return '';
                        };

                        self.dataPnrr.figuraContrattuale = getTitle(contrattoCurr.idposition);
                        self.dataPnrr.livello = '';
                        self.dataPnrr.classe = 0
                        self.dataPnrr.scatto = contrattoCurr.livello
                        self.dataPnrr.fullTime = (contrattoCurr.partime ? contrattoCurr.partime : 100) == 100 ? 'Full-Time' : 'Part-Time'


                    }
                }
            }
        },


        //----------------------------FRONTESPIZIO ORIZON --------------------------------------
        buildFrontespizioHorizon: function (sheet, opts, dtInput, month) {
            let self = this;
            var year = opts.year;
            var secondHeaderColX = 3;
            this.HorizonInitialY = 5;

            let posXLabelLeft = this.offsetX + this.offsetXYear;
            let posXLabelRight = posXLabelLeft + (month ? 5 : 4);
            let posXContentRight = posXLabelRight + (month ? 4 : 2);

            var mergedCell = sheet.mergedCellsRegions().add(1, 1, 1, 5);
            mergedCell.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCell.cellFormat().font().height(16 * 28);
            mergedCell.cellFormat().font().bold(true);
            mergedCell.value("Timesheet summary");

            sheet.columns(posXLabelLeft).setWidth(200, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            sheet.columns(posXLabelLeft + 1).setWidth(300, $.ig.excel.WorksheetColumnWidthUnit.pixel);


            let applyStyleLabelLeft = function (region) {
                region.cellFormat().fill($.ig.excel.CellFill.createSolidFill(self.COLOR_CELL_FRONTESPIZIO));
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            };

            let applyStylecontentlLeft = function (region) {
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            };

            //titolo del progetto
            var xlRowTitleProj = sheet.rows(this.HorizonInitialY);
            xlRowTitleProj.setCellValue(posXLabelLeft, 'Title of the action (acronym)');
            applyStyleLabelLeft(xlRowTitleProj.cells(posXLabelLeft));
            xlRowTitleProj.cells(posXLabelLeft).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelLeft + 1,
                this.HorizonInitialY, posXLabelLeft + 2
            );
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.progetto);


            this.HorizonInitialY++;//-----------------------------------------

            //beneficiario
            let cell = sheet.rows(this.HorizonInitialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('Full name of beneficiary');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelLeft + 1,
                this.HorizonInitialY, posXLabelLeft + 2
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.istituto);

            //Ruolo
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelRight,
                this.HorizonInitialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value('Ruolo/Qualifica');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXContentRight +1,
                this.HorizonInitialY, posXContentRight +3
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value(self.dataPnrr.figuraContrattuale);

            this.HorizonInitialY++;//-----------------------------------------

            //impiegato
            cell = sheet.rows(this.HorizonInitialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('Full name employee');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelLeft + 1,
                this.HorizonInitialY, posXLabelLeft + 2
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.getEmployee());

            // CLASSE
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelRight,
                this.HorizonInitialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.value('Classe');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXContentRight + 1,
                this.HorizonInitialY, posXContentRight + 3
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(self.dataPnrr.classe);

            this.HorizonInitialY++; //-----------------------------------------

            //capo dipartimento
            cell = sheet.rows(this.HorizonInitialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('Head of Dept.');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelLeft + 1,
                this.HorizonInitialY, posXLabelLeft + 2
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.getHeadOfDept());

            // scatto
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelRight,
                this.HorizonInitialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.value('Scatto');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXContentRight + 1,
                this.HorizonInitialY, posXContentRight + 3
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(self.dataPnrr.scatto);


            this.HorizonInitialY++; //-----------------------------------------

            //anno
            cell = sheet.rows(this.HorizonInitialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('year');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelLeft + 1,
                this.HorizonInitialY, posXLabelLeft + 2
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(year);

            // Full/part-time
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelRight,
                this.HorizonInitialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value('Full/part-time');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXContentRight + 1,
                this.HorizonInitialY, posXContentRight + 3
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value(self.dataPnrr.fullTime);

            this.HorizonInitialY++;  //-----------------------------------------

            //ore lavorate 
            cell = sheet.rows(this.HorizonInitialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            cell.value(this.lang == 'it' ? "Ore totali lavorate" : 'Total worked hours');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.HorizonInitialY, posXLabelLeft + 1,
                this.HorizonInitialY, posXLabelLeft + 2
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(this.getTotalWorkedHours(dtInput, year, opts, month));

        },

        /**
         * @method getTotalWorkedHours
         * @private
         * @description SYNC
         * @param dtInput
         * @param year
         * @returns {number}
         */
        getTotalWorkedHours: function (dtInput, year, opts, month) {
            let begin = new Date(opts.year, 1 -1 , 1);
            let end = new Date(opts.year, 12 -1, 31);

            if (month) {
                var self = this;
                //inizio e fine mese
                begin = new Date(opts.year, month - 1, 1);
                end = new Date(opts.year, month - 1, this.getNumDaysInMonth(month, opts.year));
            }

            return _.sumBy(
                _.filter(dtInput.rows, function (r) {
                    return /*r.progetto == self.dataPnrr.progetto &&*/ r.data >= begin && r.data <= end;
                })
                , 'ore');
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
        getRuoloQualifica: function () {
            var self = this;
            // torna la singola qualifica
            var getTitle = function (idposition) {
                var rows = self.contrattokind.select(q.eq('idposition', idposition));
                if (rows.length) {
                    return rows[0].title;
                }
                return '';
            };
            return _.reduce(self.contratto.rows, function (acc, row) {
                if (row.idposition) {
                    if (new Date(self.opts.year, 0, 1) < (row.stop ? row.stop : new Date(2100, 0, 1))
                        && new Date(self.opts.year, 11, 31) > (row.start ? row.start : new Date(1900, 0, 1))) {
                        acc += " " + self.getFromToContratto(row);
                        acc += ": " + getTitle(row.idposition) + "\n";
                    }
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
        getClasse: function () {
            var self = this;
            // torna la singola qualifica
            //var getTitle = function (idinquadramento) {
            //    var rows = self.inquadramento.select(q.eq('idinquadramento', idinquadramento));
            //    if (rows.length) {
            //        return rows[0].title;
            //    }
            //    return '';
            //};
            return _.reduce(self.contratto.rows, function (acc, row) {
                if (row.incomeclass) {
                    if (new Date(self.opts.year, 0, 1) < (row.stop ? row.stop : new Date(2100, 0, 1))
                        && new Date(self.opts.year, 11, 31) > (row.start ? row.start : new Date(1900, 0, 1))) {
                        acc += " " + self.getFromToContratto(row);
                        //acc += ": " + getTitle(row.idinquadramento) + "\n";
                        acc += ": " + row.incomeclass + "\n";
                    }
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
        getFullTmePartime: function () {
            var self = this;
            var fullTime = 'Full-Time';
            var partTime = 'Part-Time';
            return _.reduce(self.contratto.rows, function (acc, row) {
                if (new Date(self.opts.year, 0, 1) < (row.stop ? row.stop : new Date(2100, 0, 1))
                    && new Date(self.opts.year, 11, 31) > (row.start ? row.start : new Date(1900, 0, 1))) {
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
                        if (tempdef === 'N') {
                            res = fullTime;
                        }
                    }

                    if (res) {
                        acc += " " + self.getFromToContratto(row);
                        acc += ":" + res + "\n";
                    }
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
        getScatto: function () {
            var self = this;
            return _.reduce(self.contratto.rows, function (acc, row) {
                if (new Date(self.opts.year, 0, 1) < (row.stop ? row.stop : new Date(2100, 0, 1))
                    && new Date(self.opts.year, 11, 31) > (row.start ? row.start : new Date(1900, 0, 1))) {
                    if (row.livello) {
                        acc += " " + self.getFromToContratto(row);
                        acc += ": " + row.livello + "\n";
                    }
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
        getProgetti: function (dtInput) {
            return this.getConatenationByValue(dtInput, 'progetto');
        },

        /**
         * @method getBeneficiari
         * @private
         * @description SYNC
         * @param dtInput
         * @returns {string}
         */
        getBeneficiari: function (dtInput) {
            return this.getConatenationByValue(dtInput, 'istituto');
        },

        /**
         * @method getConatenationByValue
         * @private
         * @description SYNC
         * @param dtInput
         * @param field
         * @returns {string}
         */
        getConatenationByValue: function (dtInput, field) {
            // uniq trova le chiavi uniche di field, la map prende solo le colonne field, e reduce costrusice la stringa
            return _.reduce(
                _.map(
                    _.uniqBy(dtInput.rows, field), field),
                function (acc, value, key) {
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
        getEmployee: function () {
            if (this.metaPageState.callerPage) {
                if (this.metaPageState.callerState.currentRow) {
                    return this.metaPageState.callerState.currentRow.title;
                }
            } else {
                if (this.metaPageState.DS.tables.getregistrydocentiamministrativinomcognview)
                    return this.metaPageState.DS.tables.getregistrydocentiamministrativinomcognview.rows[0].dropdown_title;
                if (this.metaPageState.DS.tables.getregistrydocentiamministrativinomcognmatview)
                    return this.metaPageState.DS.tables.getregistrydocentiamministrativinomcognmatview.rows[0].dropdown_title;
                return '';
            }
        },

        getHeadOfDept: function () {
            // TODO
            return '';
        },

        //---------------------------------FRONTESPIZIO PON-----------------------------------------------

        buildFrontespizioPON: function (sheet, opts, dtInput, maximumX, month) {
            this.addProgetto(sheet, opts, maximumX);
            this.addInfoProgetto(sheet, opts, maximumX, month, dtInput);
        },

        /**
         * @method addProgetto
         * @private
         * @description SYNC
          * Metodo per il PON prima intestazione
        * @param sheet
         * @param opts
         * @param dtInput
         * @param year
         */
        addProgetto: function (sheet, opts, maximumX) {

            let applyRegionStyle = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#89e9fa"));
                region.cellFormat().font().bold(true);
            };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.PnrrInitialY = 9;
            //let maximumX = 14;

            let mergedCellRegion = sheet.mergedCellsRegions().add( // Codice progetto
                0 + this.PnrrInitialY, posX(0),
                0 + this.PnrrInitialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("Codice progetto: " + this.dataPnrr.codice);

            mergedCellRegion = sheet.mergedCellsRegions().add( // CUP
                0 + this.PnrrInitialY, Math.round(maximumX / 2) + 1,
                0 + this.PnrrInitialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("CUP: " + this.dataPnrr.cup);

            mergedCellRegion = sheet.mergedCellsRegions().add( // Denominazione Soggetto
                1 + this.PnrrInitialY, posX(0),
                1 + this.PnrrInitialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("Denominazione Soggetto: " + this.dataPnrr.istituto);

            mergedCellRegion = sheet.mergedCellsRegions().add( // Titolo del progetto
                2 + this.PnrrInitialY, posX(0),
                2 + this.PnrrInitialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("Titolo del progetto: " + this.dataPnrr.titolo);
        },

        /**
         * @method addInfoProgetto
         * @private
         * @description SYNC
         * Metodo per il PON seconda intestazione
         * @param sheet
         * @param opts
         * @param dtInput
         * @param year
         */
        addInfoProgetto: function (sheet, opts, maximumX, month, dtInput) {

            this.columnIndexMonth = 2;
            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);

            this.PnrrInitialY = 13;

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.PnrrInitialY, posX(0),
                0 + this.PnrrInitialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("FIGURA PROFESSIONALE");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.PnrrInitialY, posX(0),
                1 + this.PnrrInitialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Nominativo: " + this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.PnrrInitialY, Math.round(maximumX / 2) + 1,
                1 + this.PnrrInitialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("CF: " + this.dataPnrr.cf);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.PnrrInitialY, posX(0),
                2 + this.PnrrInitialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Contratto applicato: " + this.dataPnrr.figuraContrattuale);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.PnrrInitialY, posX(0),
                3 + this.PnrrInitialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Livello: " + this.dataPnrr.livello);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.PnrrInitialY, posX(0),
                4 + this.PnrrInitialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Monte ore lavorative annuo previsto: " + this.dataPnrr.oredivisionecostostipendio);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.PnrrInitialY, Math.round(maximumX / 2) + 1,
                4 + this.PnrrInitialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO: " + this.dataPnrr.tot);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.PnrrInitialY, posX(0),
                6 + this.PnrrInitialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Periodo dal " + this.dataPnrr.start + " al " + this.dataPnrr.stop);

            this.addOraKind(sheet, opts, maximumX, 'Ricerca Industriale', 1, 8 + this.PnrrInitialY, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Sviluppo Sperimentale', Math.round(maximumX / 2) + 1, 8 + this.PnrrInitialY, month, dtInput);


        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        8 + this.PnrrInitialY, posX(0),
        //        8 + this.PnrrInitialY, Math.round(maximumX / 2)
        //    );
        //    mergedCellRegion.cellFormat().font().bold(true);
        //    mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
        //    mergedCellRegion.value("Ricerca [  ]");


        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        8 + this.PnrrInitialY, Math.round(maximumX / 2) + 1,
        //        8 + this.PnrrInitialY, maximumX
        //    );
        //    mergedCellRegion.cellFormat().font().bold(true);
        //    mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
        //    mergedCellRegion.value("Sviluppo Sperimentale [  ]");
        },

        //---------------------------------FRONTESPIZIO EMPIR-----------------------------------------------

        buildFrontespizioEMPIR: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyle = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let applyRegionStyleContent = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posX = this.posX.bind(this);
            this.initialY = 8;
            let posXLabelLeft = posX(0);
            let posXContentLeft = posX(0) + 3;
            let posXContentRight = (month ? 21 : 11);

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posXLabelLeft,
                0 + this.initialY, posXContentRight
            );
            //applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value('IMPORTANT NOTE : This timesheet shall not only record the time spent on a specific project, but shall reconcile the total working time of one person');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXLabelLeft,
                3 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Name of staff member');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXContentLeft,
                3 + this.initialY, posXContentRight
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXLabelLeft,
                4 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Name of Beneficiary/ Partner');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXContentLeft,
                4 + this.initialY, posXContentRight
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value('');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXLabelLeft,
                5 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Total of working hours *');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft,
                5 + this.initialY, posXContentRight
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio + ' per year');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posXLabelLeft,
                6 + this.initialY, posXContentLeft -1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Calendar Year');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posXContentLeft,
                6 + this.initialY, posXContentRight
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);

            // -------------------------------------------------
            if (month) {
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    7 + this.initialY, posXLabelLeft,
                    7 + this.initialY, posXContentLeft - 1
                );
                applyRegionStyle(mergedCellRegion);
                mergedCellRegion.value('Calendar Month');

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    7 + this.initialY, posXContentLeft,
                    7 + this.initialY, posXContentRight
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(month);
            }

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posXLabelLeft,
                8 + this.initialY, posXContentRight
            );
            mergedCellRegion.value('* indicate number of working hours per day, week or month');

            // -------------------------------------------------

        },

        //---------------------------------FRONTESPIZIO MISE-----------------------------------------------

        buildFrontespizioMISE: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyle = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posX = this.posX.bind(this);
            this.initialY = 1;
            let posXLabelLeft = posX(0);
            let posXContentLeft = posX(0) + 3;
            let posXContentRight = (month ? 20 : 12);

            // SCHEDA DI REGISTRAZIONE DELLE PRESENZE – PERSONALE DIPENDENTE
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posXLabelLeft,
                0 + this.initialY, posXContentRight
            );
            //applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('SCHEDA DI REGISTRAZIONE DELLE PRESENZE – PERSONALE DIPENDENTE');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posXLabelLeft,
                1 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Ore lavorate');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posXContentLeft,
                1 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Dal:' + this.dataPnrr.start + ' al:' + this.dataPnrr.stop);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXLabelLeft,
                2 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Per l\'esecuzione del progetto n.');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXContentLeft,
                2 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.codice + ' CUP:' + this.dataPnrr.cup);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXLabelLeft,
                3 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Decreto');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXContentLeft,
                3 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('n.             del:');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXLabelLeft,
                5 + this.initialY, posXContentLeft
            );
            mergedCellRegion.value('Periodo dal ' + this.dataPnrr.start + ' al ' + this.dataPnrr.stop);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft + 1,
                5 + this.initialY, posXContentLeft + 2
            );
            mergedCellRegion.value('SAL n. ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft + 3,
                5 + this.initialY, posXContentLeft + 3
            );
            applyRegionStyle(mergedCellRegion);
            //mergedCellRegion.value('SAL n. ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft + 5,
                5 + this.initialY, posXContentLeft + (month ? 8 : 7)
            );
            mergedCellRegion.value('ANNO SOLARE:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft + (month ? 9 : 8),
                5 + this.initialY, posXContentLeft + (month ? 10 : 8)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXLabelLeft,
                7 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Ricerca e Sviluppo:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXContentLeft,
                7 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            //mergedCellRegion.value('SAL n. ');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posXLabelLeft,
                9 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Nominativo:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posXContentLeft,
                9 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                11 + this.initialY, posXLabelLeft,
                11 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Categoria dipendente:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                11 + this.initialY, posXContentLeft,
                11 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.categoria);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                13 + this.initialY, posXLabelLeft,
                13 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Livello dipendente:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                13 + this.initialY, posXContentLeft,
                13 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.livello);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                15 + this.initialY, posXLabelLeft,
                15 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Contratto applicato:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                15 + this.initialY, posXContentLeft,
                15 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.figuraContrattuale);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                17 + this.initialY, posXLabelLeft,
                17 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Monte ore lavorative annuo previsto:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                17 + this.initialY, posXContentLeft,
                17 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                19 + this.initialY, posXLabelLeft,
                19 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.value('Sede di svolgimento delle attività:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                19 + this.initialY, posXContentLeft,
                19 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('');


        },


        //---------------------------------FRONTESPIZIO PORCAMPANIA-----------------------------------------------

        buildFrontespizioPORCAMPANIA: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyle = function (region) {
                region.cellFormat().font().bold(true);
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posX = this.posX.bind(this);
            this.initialY = 9;
            let posXLabelLeft = posX(0);
            let posXContentLeft = posX(0) + 3;
            let posXContentRight = maximumX;

            // -------------------------------------------------

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posXLabelLeft,
                2 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('POR CAMPANIA FESR 2014/2020                                                                                                                                                                                                  Allegato A.2 – PROSPETTO DI RIEPILOGO DEI TIME SHEET MENSILI');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXLabelLeft,
                4 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('POR CAMPANIA FESR 2014/2020 – ASSE 1 – O.S 1.2\r\n“Avviso Pubblico per la selezione di Progetti di Ricerca e Sviluppo per Sistemi e Tecnologie Abilitanti per l’Industria dell’Aerospazio”');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXLabelLeft,
                5 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            //mergedCellRegion.cellFormat().alignment($.ig.excel.VerticalCellAlignment.center);
            mergedCellRegion.value('Progetto ' + this.dataPnrr.titolo);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posXLabelLeft,
                7 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('GESTORE _____________________________\r\nBENEFICIARIO ' + this.dataPnrr.istituto);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posXLabelLeft,
                9 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('PERSONALE DIPENDENTE');

            // -------------------------------------------------
            mergedCellRegion = sheet.mergedCellsRegions().add(
                11 + this.initialY, posXContentLeft,
                11 + this.initialY, posXContentLeft + 2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('NOME');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                11 + this.initialY, posXContentLeft + 3,
                11 + this.initialY, posXContentLeft + 5
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('COGNOME');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, posXLabelLeft,
                12 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.cellFormat().font().bold(true);
           mergedCellRegion.value('Nominativo:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, posXContentLeft,
                12 + this.initialY, posXContentLeft + 2
            );
            mergedCellRegion.value(this.dataPnrr.nome);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, posXContentLeft + 3,
                12 + this.initialY, posXContentRight
            );
            mergedCellRegion.value(this.dataPnrr.cognome);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                13 + this.initialY, posXLabelLeft,
                13 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('Qualifica:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                13 + this.initialY, posXContentLeft,
                13 + this.initialY, posXContentRight
            );
            mergedCellRegion.value(this.dataPnrr.categoria);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                14 + this.initialY, posXLabelLeft,
                14 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('Livello:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                14 + this.initialY, posXContentLeft,
                14 + this.initialY, posXContentLeft+2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('ALTO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                14 + this.initialY, posXContentLeft +3,
                14 + this.initialY, posXContentLeft +5
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('MEDIO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                14 + this.initialY, posXContentLeft+6,
                14 + this.initialY, posXContentLeft+8
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('BASSO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                15 + this.initialY, posXContentLeft,
                15 + this.initialY, posXContentLeft+2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.livello == 'ALTO (Professore Ordinario)' ? 'X' : '');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                15 + this.initialY, posXContentLeft + 3,
                15 + this.initialY, posXContentLeft + 5
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.livello == 'MEDIO (Professore Associato)' ? 'X' : '');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                15 + this.initialY, posXContentLeft + 6,
                15 + this.initialY, posXContentLeft + 8
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.livello == 'BASSO (Ricercatore)' ? 'X' : '');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                16 + this.initialY, posXLabelLeft,
                16 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('Contratto applicato:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                16 + this.initialY, posXContentLeft,
                16 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value(this.dataPnrr.figuraContrattuale);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                17 + this.initialY, posXLabelLeft,
                17 + this.initialY, posXContentLeft - 1
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('Monte ore lavorative annuo previsto:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                17 + this.initialY, posXContentLeft,
                17 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio);

        },

        //---------------------------------FRONTESPIZIO PNRR-----------------------------------------------

        applyRegionOrCellStyleLabel: function (regionOrCell) {
            regionOrCell.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.right);
            regionOrCell.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));
            regionOrCell.cellFormat().font().bold(true);
            regionOrCell.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            regionOrCell.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            regionOrCell.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            regionOrCell.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
        },

        buildFrontespizioPNRR: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyleContent = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.PnrrInitialY = 10;

            let posXContentLeft = posX(0) + 2;
            let posXLabelRight = Math.round(maximumX / 2) - Math.round(maximumX / 4);
            let posXContentRight = Math.round(maximumX / 2) + 7;

            // TIMESHEET PER RENDICONTAZIONE PERSONALE
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.PnrrInitialY, posX(0),
                0 + this.PnrrInitialY, posXContentRight - 4
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value('TIMESHEET PER RENDICONTAZIONE PERSONALE');

            if (month) {
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.PnrrInitialY, posXContentRight - 3,
                    0 + this.PnrrInitialY, posXContentRight - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value('MESE');

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.PnrrInitialY, posXContentRight,
                    0 + this.PnrrInitialY, posXContentRight + 2
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(this.getMonthColumnName(month));
            }

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.PnrrInitialY, (month ? posXContentRight + 3 : posXContentRight - 3),
                0 + this.PnrrInitialY, (month ? posXContentRight + 5 : posXContentRight - 2)
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('ANNO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.PnrrInitialY, (month ? posXContentRight + 5 : posXContentRight - 2) + 1,
                0 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);


            // TITOLO DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.PnrrInitialY, posX(0),
                2 + this.PnrrInitialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('TITOLO DEL PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.PnrrInitialY, posXContentLeft,
                2 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.titolo);

            // CUP DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.PnrrInitialY, posX(0),
                3 + this.PnrrInitialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('CUP DEL PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.PnrrInitialY, posXContentLeft,
                3 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cup);

            // CODICE DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.PnrrInitialY, posX(0),
                4 + this.PnrrInitialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('CODICE DEL PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.PnrrInitialY, posXContentLeft,
                4 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.codice);

            // DENOMINAZIONE SOGGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.PnrrInitialY, posX(0),
                5 + this.PnrrInitialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('DENOMINAZIONE SOGGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.PnrrInitialY, posXContentLeft,
                5 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.istituto);

            //SEPARATORE FIGURA PROFESSIONALE

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.PnrrInitialY, posX(0),
                6 + this.PnrrInitialY, maximumX
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().italic(true);
            mergedCellRegion.value("Figura Professionale");


            //NOME

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.PnrrInitialY, posX(0),
                7 + this.PnrrInitialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("NOME");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.PnrrInitialY, posXContentLeft,
                7 + this.PnrrInitialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.nome);

            //COGNOME

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.PnrrInitialY, posXLabelRight,
                7 + this.PnrrInitialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("COGNOME");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.PnrrInitialY, posXContentRight,
                7 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cognome);

            //CODICE FISCALE

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.PnrrInitialY, posX(0),
                8 + this.PnrrInitialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("CODICE FISCALE");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.PnrrInitialY, posXContentLeft,
                8 + this.PnrrInitialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cf);

            //ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.PnrrInitialY, posXLabelRight,
                8 + this.PnrrInitialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value(opts.mese || month ? "ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL MESE IN OGGETTO" : "ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO");

            //se ho chiesto un mese specifico ho già calcolato il totale
            let totOreMese = this.dataPnrr.tot;
            //...altrimenti lo devo calcolare per il mese specifico e comunque solo sul foglio del mese
            if (!opts.mese && month) {
                var self = this;
                //inizio e fine mese
                let begin = new Date(opts.year, month - 1, 1);
                let end = new Date(opts.year, month - 1, this.getNumDaysInMonth(month, opts.year));
                //totale
                totOreMese = _.sumBy(
                    _.filter(dtInput.rows, function (r) {
                        return r.progetto == self.dataPnrr.progetto && r.data >= begin && r.data <= end;
                    })
                    , 'ore');
            }

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.PnrrInitialY, posXContentRight,
                8 + this.PnrrInitialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(totOreMese);


        },

        //---------------------------------FINE FRONTESPIZIO-----------------------------------------------

        //---------------------------------INIZIO PIEDIPAGINA-----------------------------------------------

        /**
         * @method buildPiedipagina
         * @private
         * @description SYNC
         * @param sheet
         * @param opts
         * @param dtInput
         */
        buildPiedipagina: function (sheet, opts, dtInput, maximumX, rowIndex, month) {
            switch (opts.idtimesheettemplate) {
                case ETemplateType.HORIZON:
                    //this.buildPiedipaginaHorizon(sheet, opts, dtInput);
                    return rowIndex + 0;
                    break;
                case ETemplateType.PON:
                    this.buildPiedipaginaPON(sheet, opts, dtInput, maximumX, rowIndex);
                    return rowIndex + 15;
                    break;
                case ETemplateType.PNRR:
                    this.buildPiedipaginaPNRR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return rowIndex + 13;
                    break;
                case ETemplateType.PNC:
                    this.buildPiedipaginaPNRR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return rowIndex + 13;
                    break;
                case ETemplateType.MISE:
                    this.buildPiedipaginaMISE(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return rowIndex + 8;
                    break;
                case ETemplateType.PORCAMPANIA:
                    this.buildPiedipaginaPORCAMPANIA(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return rowIndex + 8;
                    break;
                case ETemplateType.EMPIR:
                    this.buildPiedipaginaEMPIR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return rowIndex + 8;
                    break;
                default:
                    //this.buildPiedipaginaHorizon(sheet, opts, dtInput);
                    return rowIndex + 0;
            }
        },

        buildPiedipaginaPORCAMPANIA: function (sheet, opts, dtInput, maximumX, rowIndex) {

            let applyRegionStyle = function (region) {
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 2,
                rowIndex + 4, 4
            );
            mergedCellRegion.value('Firma del Dipendente');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 10,
                rowIndex + 4, 22
            );
            mergedCellRegion.value('Firma del Responsabile Amministrativo');

            //seconda riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 2,
                rowIndex + 5, 4
            );
            applyRegionStyle(mergedCellRegion);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 10,
                rowIndex + 5, maximumX - 1
            );
            applyRegionStyle(mergedCellRegion);

        },

        buildPiedipaginaEMPIR: function (sheet, opts, dtInput, maximumX, rowIndex) {

            let applyRegionStyle = function (region) {
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 2,
                rowIndex + 4, 4
            );
            mergedCellRegion.value('Date and signature of staff member');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 10,
                rowIndex + 4, 22
            );
            mergedCellRegion.value('Date and signature of person in charge of the work');

            //seconda riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 2,
                rowIndex + 5, 4
            );
            applyRegionStyle(mergedCellRegion);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 10,
                rowIndex + 5, maximumX - 1
            );
            applyRegionStyle(mergedCellRegion);

        },

        buildPiedipaginaMISE: function (sheet, opts, dtInput, maximumX, rowIndex) {

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, 3
            );
            mergedCellRegion.value('Data e firma dell\'addetto al progetto');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 4,
                rowIndex + 2, 19
            );
            mergedCellRegion.value('Sigla del Direttore Amministrativo o Responsabile del Personale ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 22,
                rowIndex + 2, 29
            );
            mergedCellRegion.value('Sigla del Responsabile del progetto');

            this.addBorder(sheet, rowIndex + 4, maximumX + 2, false);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 6, 0,
                rowIndex + 6, maximumX
            );
            mergedCellRegion.value('Il personale coinvolto nell’attuazione del progetto dichiara di aver preso visione dell’informativa sul trattamento dei dati personali pubblicata nella sezione dedicata alla misura in oggetto del sito istituzionale del Ministero dello sviluppo economico.');


        },

        buildPiedipaginaPON: function (sheet, opts, dtInput, maximumX, rowIndex) {

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, 7
            );
            mergedCellRegion.value('Personale dipendente assunto con stabile sede presso il laboratorio sito in (località)');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 8,
                rowIndex + 2, 21
            );
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 23,
                rowIndex + 2, 23
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);

            //seconda riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 1,
                rowIndex + 4, 9
            );
            mergedCellRegion.value('Personale dipendente assunto altrove e trasferito/distaccato presso il laboratorio sito in (località)');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 10,
                rowIndex + 4, 21
            );
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 23,
                rowIndex + 4, 23
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);

            //terza riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 9, 1,
                rowIndex + 9, 4
            );
            mergedCellRegion.value('Data e firma dell\'addetto al progetto');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 9, 24,
                rowIndex + 9, maximumX
            );
            //mergedCellRegion.value('Firma del Direttore amministrativo/Direttore del personale/Legale rappresentante *');
            mergedCellRegion.value('Firma del Direttore del Dipartimento');

            //quarta riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 13, 24,
                rowIndex + 13, maximumX
            );
            mergedCellRegion.value('Visto del responsabile del progetto');

            //qunta riga

            //mergedCellRegion = sheet.mergedCellsRegions().add(
            //    rowIndex + 15, 1,
            //    rowIndex + 15, 4
            //);
            //mergedCellRegion.value('* in alternativa');

        },

        buildPiedipaginaPNRR: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

            //DI CUI IMPUTATE AL PROGETTO LE SEGUENTI ORE SUDDIVISE PER TIPOLOGIA DI ATTIVITA':

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("DI CUI IMPUTATE AL PROGETTO LE SEGUENTI ORE SUDDIVISE PER TIPOLOGIA DI ATTIVITA':");

            //CONTEGGIO ORE PER TIPO
            this.addOraKind(sheet, opts, maximumX, 'Ricerca Fondamentale', 4, rowIndex + 3, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Ricerca Industriale', 12, rowIndex + 3, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Sviluppo Sperimentale', 20, rowIndex + 3, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Formazione', 28, rowIndex + 3, month, dtInput);

            //SEDE OPERATIVA IN CUI E' STATA SVOLTA L'ATTIVITA': 

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 1,
                rowIndex + 5, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("SEDE OPERATIVA IN CUI E' STATA SVOLTA L'ATTIVITA':");

            //firma left
            this.writeRiquadroFirma(sheet, "FIRMATO DA (nome e cognome della figura professionale)", 1, Math.round(maximumX / 2) - 6, rowIndex + 7);

            //firma right            
            this.writeRiquadroFirma(sheet, "FIRMATO DA (nome e cognome del Supervisore)", Math.round(maximumX / 2) - 5, maximumX, rowIndex + 7);
        },

        writeRiquadroFirma: function (sheet, label, posXleft, posiXRigt, posY) {

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                posY, posXleft,
                posY, posiXRigt
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(label);

            let currRow = sheet.rows(posY + 1);
            currRow.cells(posXleft).cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            currRow.cells(posiXRigt).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                posY + 2, posXleft,
                posY + 2, posiXRigt
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('data:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                posY + 3, posXleft,
                posY + 3, posiXRigt
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('firma:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                posY + 4, posXleft,
                posY + 4, posiXRigt
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
        },

        /**
         * @method addOraKind
         * @private
         * @description SYNC
         * Metodo per le celle con il tipo di ora
         * @param sheet
         * @param opts
         * @param dtInput
         * @param year
         */
        addOraKind: function (sheet, opts, maximumX, label, Xpos, Ypos, month, dtInput) {
            try {

                var self = this;
                let begin = new Date(opts.year, 0, 1);
                let end = new Date(opts.year, 11, 31);
                if (month) { 
                    //inizio e fine mese
                    begin = new Date(opts.year, month - 1, 1);
                    end = new Date(opts.year, month - 1, this.getNumDaysInMonth(month, opts.year));
                }
                //totale
                totOreMese = _.sumBy(
                    _.filter(dtInput.rows, function (r) {
                        return r.progetto == self.dataPnrr.progetto && r.data >= begin && r.data <= end && (r.tipo ? r.tipo : 'Ricerca Fondamentale') == label;
                    })
                    , 'ore');

                let mergedCellRegion = sheet.mergedCellsRegions().add(
                    Ypos, Xpos,
                    Ypos, Xpos + 4
                );
                mergedCellRegion.cellFormat().font().bold(true);
                mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                mergedCellRegion.value(label);

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    Ypos, Xpos + 5,
                    Ypos, Xpos + 6
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                mergedCellRegion.value(totOreMese);
            } catch (e) {
                if (this.verbose)
                    console.log("Errore nella generazione del timesheet: " + e.message);

                opts.metaPage.hideWaitingIndicator(waitingHandler);

            }


        },

        //---------------------------------FINE PIEDIPAGINA-----------------------------------------------

        /**
         * @method createHeadersYear
         * @private
         * @description SYNC
         * @param sheet
         * @param year
         */
        createHeadersYear: function (sheet, year) {
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            this.columnIndexMonth = 2;

            //allargo la seconda e terza colonna (Per l'header e per i titoli dei porgetti)
            sheet.columns(this.columnIndexMonth + this.offsetX + this.offsetXYear - 1).setWidth(120, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            sheet.columns(this.columnIndexMonth + this.offsetX + this.offsetXYear).setWidth(150, $.ig.excel.WorksheetColumnWidthUnit.pixel);

            var mergedCellMonth = sheet.mergedCellsRegions().add(posY(0) + this.offsetYYear,
                posX(0) + this.offsetXYear,
                posY(1) + this.offsetYYear,
                posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellMonth.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellMonth.value(year.toString());
            mergedCellMonth.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellMonth.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            mergedCellMonth.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellMonth.cellFormat().font().height(16 * 22);
            mergedCellMonth.cellFormat().font().bold(true);

            var xlRowDayString = sheet.rows(this.offsetY + this.offsetYYear);
            xlRowDayString.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            xlRowDayString.cellFormat().font().bold(true);

            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var valueMonthString = this.getMonthColumnName(counterMonth);
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                sheet.columns(dataCellIndex).setWidth(80, $.ig.excel.WorksheetColumnWidthUnit.pixel);
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
            mergedCellTotal.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            mergedCellTotal.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.value(this.lang == 'it' ? "totale" : "total");
        },

        /**
         * @method calcTimeSheetTable
         * @private
         * @description SYNC
         * 4 - disegna il foglio del mese
         * @param workbook
         * @param obj
         * @param month
         * @param dtInput
         * @param opts
         */
        calcTimeSheetTable: function (workbook, obj, month, dtInput, opts, logoBase64) {
            if (this.verbose)
                console.log("4 - disegna il foglio del mese");
            // aggiungo 1 singolo foglio per il mese
            var year = opts.year;
            var showactivitiesrow = opts.showactivitiesrow;

            var sheet = workbook.worksheets().add(this.getMonthColumnName(month));

            this.addBorder(sheet, 0, 37, true);

            if (opts.intestazioneallsheet) {
                this.addSheetLogo(sheet, opts, logoBase64, false);
                this.buildFrontespizio(sheet, opts, dtInput, this.getNumDaysInMonth(month, this.opts.year) +4, month);
            }

            this.createHeaders(sheet, month, year);
            var self = this;
            var rowIndex = 2; // le prime 2 sono header  1 per giorni + 1 per stringa giorno
            // 2. scorro i progetti
            if (opts.idtimesheettemplate === ETemplateType.PNRR || opts.idtimesheettemplate === ETemplateType.PNC || opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {

                //aggiungo anche l'idprogetto e l'ente finanziatore (se non l'ho già fatto per il riepilogo anno)
                if (!opts.riepilogoanno) {
                    if (opts.multilineType) {
                        _.forEach(obj, function (o) {
                            o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].progetto;
                            o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].cup;
                            o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idprogetto;
                            o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idreg_aziende_fin;
                        });
                    } else {
                        _.forEach(obj, function (o) {
                            o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].progetto;
                            o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].cup;
                            o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idprogetto;
                            o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idreg_aziende_fin;
                        });
                    }
                }

                //2.1 aggiungo prima la riga del progetto principale
                let objPrg = _.filter(obj, function (o) { return o.idprogetto == opts.idprogetto });
                _.forEach(objPrg, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                //se è MISE o PORCAMPANIA ragruppa tutti gli altri insieme
                if (opts.idtimesheettemplate === ETemplateType.MISE || opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {

                    //poi quella defli altri progetti
                    let objFinEq = _.filter(obj, function (o) { return o.idprogetto != opts.idprogetto });
                    _.forEach(objFinEq, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    //solo per MISE aggiungo le righe malattia,ferie e permessi
                    if (opts.idtimesheettemplate === ETemplateType.MISE) {
                        self.getRowText(sheet, rowIndex, "Malattia", month);
                        rowIndex += 1;
                        self.getRowText(sheet, rowIndex, "Ferie", month);
                        rowIndex += 1;
                        self.getRowText(sheet, rowIndex, "Permessi", month);
                        rowIndex += 1;
                    }

                }
                else {
                     //PNRR e PNC

                    //2.2 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    //poi quella dei progetti dello stesso ente finanziatore
                    let objFinEq = _.filter(obj, function (o) { return o.idreg_aziende_fin == self.dataPnrr.enteFinanziatore && o.idprogetto != opts.idprogetto });
                    _.forEach(objFinEq, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    //2.3 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI:", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    //2.4 poi quella dei progetti con ente finanziatore diverso
                    let objFinNeq = _.filter(obj, function (o) { return o.idreg_aziende_fin != self.dataPnrr.enteFinanziatore });
                    _.forEach(objFinNeq, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    //solo per PNRR aggiungo la riga ferie e malattie
                    if (opts.idtimesheettemplate === ETemplateType.PNRR) {
                        self.getRowText(sheet, rowIndex, "Altro (Malattia, Ferie, Permessi, …)", month);
                        rowIndex += 1; 
                    }

                }

            } else {
                //HORIZON o EMPIR 

                if (opts.idtimesheettemplate === ETemplateType.EMPIR) {
                    self.getRowText(sheet, rowIndex, "In case of absence, indicate one of the reason codes below", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                }

                _.forOwn(obj, function (el, pkey) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, pkey, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            //riga delle altre attività calcolate fittizie
            if (opts.showOtherActivitiesrow) {
                //visualizzo la riga con la differenza delle ore dei progetti con il massimale del giorno per idposition su una riga intitolata ad "altre attività"
                this.addRowOtherActivities(sheet, rowIndex, dtInput, month, year);
                rowIndex++;
            }

            //riga con il totale delle attività di ricerca
            if (showactivitiesrow) {
                this.addLastRowWithTotalActivities(sheet, rowIndex, dtInput, month, year);
                rowIndex++;
            }

            //visualizza il totale giornaliero
            this.addLastRowWithTotal(sheet, rowIndex, dtInput, month, year, opts);

            //il piè di pagina
            rowIndex = this.buildPiedipagina(sheet, opts, dtInput, this.getNumDaysInMonth(month, this.opts.year) + 4, rowIndex + this.offsetY, month);

            this.addBorder(sheet, rowIndex + 1, 37, false);

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

            //allargo la seconda e terza colonna (Per l'header e per i titoli dei porgetti)
            sheet.columns(this.columnIndexMonth + this.offsetX + this.offsetXYear - 1).setWidth(120, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            sheet.columns(this.columnIndexMonth + this.offsetX).setWidth(200, $.ig.excel.WorksheetColumnWidthUnit.pixel);

            //colonna del mese
            var mergedCellMonth = sheet.mergedCellsRegions().add(
                posY(0), posX(0),
                posY(1), posX(this.columnIndexMonth)
            );
            mergedCellMonth.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellMonth.value(this.getMonthColumnName(month));
            mergedCellMonth.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellMonth.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            mergedCellMonth.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellMonth.cellFormat().font().height(16 * 22);
            mergedCellMonth.cellFormat().font().bold(true);

            //colonne dei giorni
            var daysInMonth = this.getNumDaysInMonth(month, year);
            var xlRowDayString = sheet.rows(this.offsetY);
            var xlRowDayNumber = sheet.rows(1 + this.offsetY);
            xlRowDayString.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
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
                sheet.columns(dataCellIndex).setWidth(30, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            }

            //colonna del totale
            var mergedCellTotal = sheet.mergedCellsRegions().add(
                posY(0), posX(counterDay + this.columnIndexMonth),
                posY(1), posX(counterDay + this.columnIndexMonth)
            );
            mergedCellTotal.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellTotal.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellTotal.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            mergedCellTotal.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.value(this.lang == 'it' ? "totale" : "total");
            sheet.columns(posX(counterDay + this.columnIndexMonth)).setWidth(40, $.ig.excel.WorksheetColumnWidthUnit.pixel);

            //le tre colonne successive le stringo al massimo per gestire le intestazioni più larghe di 1 (mesi di 30) o 3 gg (febbraio)
            sheet.columns(posX(counterDay + this.columnIndexMonth) + 1).setWidth(5, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            sheet.columns(posX(counterDay + this.columnIndexMonth) + 2).setWidth(5, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            sheet.columns(posX(counterDay + this.columnIndexMonth) + 3).setWidth(5, $.ig.excel.WorksheetColumnWidthUnit.pixel);

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
        addLastRowWithTotal: function (sheet, rowIndex, dtInput, month, year, opts) {
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
            mergedCellProgName.value(this.lang == 'it' ? "Ore totali" : "Total hours");
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            xlRow.cellFormat().font().bold(true);
            var daysInMonth = this.getNumDaysInMonth(month, year);
            var globalTot = 0;
            var isRed = false;
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var d = new Date(year, month - 1, counterDay);
                //ore rendicontate
                var tot = _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: month }), 'ore');
                //ore massime lavorabili
                var maxHoursPerDayRole = this.getMaxHourPerDay(d);
                var maxHours = maxHoursPerDayRole.maxHoursPerDay;

                //SE ho calcolato la riga delle altre attività per differenza con le massime, allora ...
                //...tranne che sabato, domenica e i gorni di sospensione se ha rendicontato meno delle ore lavorate/lavorabili ...
                if (!this.isZeroOtherActivitiesDay(d) && tot < maxHours && opts.showOtherActivitiesrow) {
                    //...il mio totale sono le ore lavorate/lavorabili ...
                    tot = maxHours
                }

                if (maxHoursPerDayRole.role == 'Timbrature') {
                    //se ha sforato le timbrature...
                    if (tot > maxHours) {
                        //...la coloro di rosso
                        isRed = true;
                        //... lascio il totale di quanto rendicontato 
                        tot = maxHours;
                        //...blocco la firma
                        this.signedAllowed = false;
                    }
                }

                if (maxHoursPerDayRole.role == 'Consolidamenti') {
                    //se ha sforato oppure non saturato il consolidamento...
                    if (tot != maxHours) {
                        //...la coloro di rosso
                        isRed = true;
                        //... lascio il totale di quanto rendicontato 
                        tot = maxHours;
                        //...blocco la firma
                        this.signedAllowed = false;
                    }
                }

                //La vista in caso di utilizzo di timbrature restituisce questi ruoli speciali in caso di assenza
                if (maxHoursPerDayRole.role == 'Consolidamento assente' || maxHoursPerDayRole.role == 'Timbratura assente') {
                    //...la coloro di rosso
                    isRed = true;
                    //... lascio il totale di quanto rendicontato 
                    //...blocco la firma
                    this.signedAllowed = false;
                }

                globalTot += tot;
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, tot);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_ERRORE : this.COLOR_ROW_TOTAL));
                //lo resetto per il giorno dopo
                isRed = false;
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
         * @param year
         */
        addLastRowWithTotalActivities: function (sheet, rowIndex, dtInput, month, year) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.value(this.lang == 'it' ? "Ore totali in attività di ricerca" : "Total research activities hours");
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            var daysInMonth = this.getNumDaysInMonth(month, year);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex,
                    _.sumBy(
                        _.filter(
                            dtInput.rows,
                            function (o) {
                                return o.giorno == counterDay && o.mese == month && !(o.progetto === 'Other activities' /*|| o.progetto === 'Other Research Activities'*/ || o.progetto === 'Teaching activities')
                            }
                            //{ giorno: counterDay, mese: month }
                        )
                        , 'ore'));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            }

            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(
                dtInput.rows, function (o) {
                    return o.mese == month && !(o.progetto === 'Other activities' /*|| o.progetto === 'Other Research Activities'*/ || o.progetto === 'Teaching activities')
                }
                //{ mese: month }
            ), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, total);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
        },

        /**
         * @method addRowOtherActivities
         * @private
         * @description metodo che fa la differenza delle ore lavorate con le ore rendicontate di ricerca e didattica
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
            var daysInMonth = this.getNumDaysInMonth(month, year);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var isRed = false;
                var d = new Date(year, month - 1, counterDay);
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                //ore massime lavorabili
                var maxHoursPerDayRole = this.getMaxHourPerDay(d);
                var maxDayHour = maxHoursPerDayRole.maxHoursPerDay;
                var diff = maxDayHour - _.sumBy(_.filter(dtInput.rows, { giorno: counterDay, mese: month }), 'ore');

                //se è una timbratura e ho sforato (diff negativo) ...
                if (diff && diff < 0 && maxHoursPerDayRole.role == 'Timbrature') {
                    //...la segnalo in rosso e lascio il numero negativo
                    isRed = true;
                }

                //se è una Consolidamento e ho sforato (diff negativo) o non saturato (diff positivo)...
                if (diff && diff != 0 && maxHoursPerDayRole.role == 'Consolidamenti') {
                    //...la segnalo in rosso e lascio il numero negativo
                    isRed = true;
                }

                //se è un massimale che viene dalla configurazione si può superare ...
                if (diff && diff > 0 && maxHoursPerDayRole.role != 'Timbrature' && maxHoursPerDayRole.role != 'Consolidamenti') {
                    //... ma devo impostare le altre ore a zero (non possono essere negative)
                    diff = 0;
                }

                xlRow.setCellValue(dataCellIndex, diff);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_ERRORE : this.COLOR_ROW_PROG));
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
            if (
                valueDayString.toUpperCase() === "SUN" ||
                valueDayString.toUpperCase() === "SAT" ||
                valueDayString.toUpperCase() === "SAB" ||
                valueDayString.toUpperCase() === "DOM" ||
                this.isSospensioneDay(d)) {
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
         * 4.1 disegna le righe dei progetti per il mese
         * @param sheet
         * @param rowIndex
         * @param progettokey
         * @param progettoObj
         * @param dtInput
         * @param month
         * @param year
         * @returns {number}
         */
        getProgettoTimeSheet: function (sheet, rowIndex, progettokey, progettoObj, dtInput, month, year, opts) {
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
            if ((opts.idtimesheettemplate === ETemplateType.PNRR || opts.idtimesheettemplate === ETemplateType.PNC)
                && progettokey !== 'Teaching activities' && progettokey !== 'Other activities' && progettokey !== 'Other Research Activities' && progettokey !== 'Attività ordinaria' && progettokey !== 'Institutional activities') {

                mergedCellProgName.value(progettokey + '; CUP:' + progettoObj.cup + ';');

            } else {

                mergedCellProgName.value(progettokey);

                if (opts.idtimesheettemplate === ETemplateType.MISE && progettoObj.idprogetto == opts.idprogetto)
                    mergedCellProgName.value("Attività progetto");

                if (opts.idtimesheettemplate === ETemplateType.EMPIR && progettokey !== 'Institutional activities')
                    mergedCellProgName.value("Hours worked on project " + progettokey);

                if (this.lang == 'it' && progettokey == 'Teaching activities') {
                    mergedCellProgName.value('Attività di didattica');
                }
                if (this.lang == 'it' && progettokey == 'Other activities') {
                    mergedCellProgName.value('Altre attività');
                }
                if (this.lang == 'it' && progettokey == 'Other Research Activities') {
                    mergedCellProgName.value('Altre attività di ricerca');
                }
            }
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var daysInMonth = this.getNumDaysInMonth(month, year);
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

            //se è stata indicata lopzione di visualizzare i workpackage e non ho applicato il collasso su una riga sola del progetto corrente
            if (opts.withWorkpackage == true && progettokey != "Altri progetti finanziati") {
                // 2. scorro i workpackege del progetto e creo riga
                _.forOwn(progettoObj.group, function (el, wpkey) {
                    if (wpkey !== 'Teaching activities' && wpkey !== 'Other activities' && wpkey !== 'Other Research Activities') {
                        if (opts.multilineType == true) {
                            _.forOwn(el.group, function (elType, wpkeyType) {
                                currRowIndex++;
                                self.getWorkpackageTimeSheet(sheet, currRowIndex + rowIndex, wpkey, progettokey, dtInput, month, year, opts, wpkeyType);
                            });
                        } else {
                            currRowIndex++;
                            self.getWorkpackageTimeSheet(sheet, currRowIndex + rowIndex, wpkey, progettokey, dtInput, month, year, opts);
                        }
                    }
                });
            }

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
        getWorkpackageTimeSheetMonth: function (sheet, rowIndex, workpackagekey, progettokey, dtInput, opts, type) {
            // 1. aggiungo riga del workpackage
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellWPName = sheet.mergedCellsRegions().add(
                posY(rowIndex) + this.offsetYYear, posX(0) + this.offsetXYear,
                posY(rowIndex) + this.offsetYYear, posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellWPName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellWPName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellWPName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            let title = workpackagekey;
            if (opts.idtimesheettemplate === ETemplateType.EMPIR)
                title = "Hours worked on project " + progettokey + ' grids ' + workpackagekey;
            mergedCellWPName.value(title + (type ? ' - ' + type : ''));

            var xlRow = sheet.rows(rowIndex + this.offsetY + this.offsetYYear);
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, this.getDaySumWorkpackageMonth(dtInput, progettokey, workpackagekey, counterMonth, type));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }
            // aggiungo cella per il totale
            var total = 0;
            if (type)
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey, tipo: type }), 'ore');
            else
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey }), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, total);
            sheet.rows(rowIndex + this.offsetY + this.offsetYYear).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
        },

        /**
         * @method getWorkpackageTimeSheet
         * @private
         * @description SYNC
         * in base all'opzione di separare le ore per tipo genera una o più righe, poi restituirà il numero di righe creato
         * @param sheet
         * @param rowIndex
         * @param workpackagekey
         * @param progettokey
         * @param dtInput
         * @param month
         * @param year
         */
        getWorkpackageTimeSheet: function (sheet, rowIndex, workpackagekey, progettokey, dtInput, month, year, opts, type) {
            // 1. aggiungo riga del workpackage
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellWPName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellWPName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellWPName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellWPName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);

            let title = workpackagekey;
            if (opts.idtimesheettemplate === ETemplateType.EMPIR)
                title = "Hours worked on project " + progettokey + ' grids ' + workpackagekey;
            mergedCellWPName.value(title + (type ? ' - ' + type : '' ) );

            var xlRow = sheet.rows(rowIndex + this.offsetY);
            var daysInMonth = this.getNumDaysInMonth(month, year);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, this.getDaySumWorkpackage(dtInput, progettokey, workpackagekey, month, counterDay, type));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }
            // aggiungo cella per il totale
            var total = 0;
            if(type)
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey, mese: month, tipo: type }), 'ore');
             else
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey, mese: month }), 'ore');
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
        getDaySumWorkpackage: function (dtInput, progettokey, workpackagekey, month, day, type) {
            if (type)
                return _.sumBy(_.filter(dtInput.rows, {
                    progetto: progettokey,
                    workpackage: workpackagekey,
                    mese: month,
                    giorno: day,
                    tipo: type
                }), 'ore');
            else
                return _.sumBy(_.filter(dtInput.rows, {
                    progetto: progettokey,
                    workpackage: workpackagekey,
                    mese: month,
                    giorno: day
                }),'ore');
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
        getDaySumWorkpackageMonth: function (dtInput, progettokey, workpackagekey, month, type) {
            if (type)
                return _.sumBy(_.filter(dtInput.rows, {
                    progetto: progettokey,
                    workpackage: workpackagekey,
                    mese: month,
                    tipo: type
                }), 'ore');
            else
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
            //clono l'array
            const arrayClonato = columns.slice();
            // prendo nome della colonna
            return _.mapValues(
                _.groupBy(rows, arrayClonato.shift()),//restituisce il primo elemento e lo elimina contestualmente dall'array
                function (values) {
                    return { group: self.calcObjGrouped(values, arrayClonato) };
                });
        },

        /**
         * @method getNumDaysInMonth
         * @private
         * @description SYNC
         * 1=gen
         * 12=dic
         * @param {number} month
         * @param {number} year Anno di elaborazione, serve per calcolare correttamente i giorni di febbraio (bisestile o no)
         * @returns {number}
         */
        getNumDaysInMonth: function (month, year) {
            year = year ? year : 2020;
            let date = new Date(year, month - 1, 1);
            return moment(date).daysInMonth();
        }
    };

    appMeta.Timesheet = new Timesheet();
}());
