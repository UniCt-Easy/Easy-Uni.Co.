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
        HORIZON_Y: "HORIZON_Y",
        PON: "PON",
        HORIZON_ERANET_COFUND: "HORIZON_ERANET_COFUND",
        PNRR: "PNRR",
        PNRR_AGE_IT: "PNRR_AGE_IT",
        NBFC_CNR: "NBFC_CNR",
        FSC_MS_5: "FSC_MS_5",
        FSC_MS_3: "FSC_MS_3",
        PATTO_TERR: "PATTO_TERR",
        FSC_MS: "FSC_MS",
        MASE: "MASE",
        PNRR_PF: "PNRR_PF",
        PNC: "PNC",
        MISE: "MISE",
        POR: "POR",
        PORCAMPANIA: "PORCAMPANIA",
        EMPIR: "EMPIR",
        MIMIT: "MIMIT",
        MIMIT_2: "MIMIT_2",
        PORCAMPANIA_21_27: "PORCAMPANIA_21_27",
        MALATTIE_RARE: "MALATTIE_RARE",
        PSRCAMPANIA: "PSRCAMPANIA",
    };

    var pdfData = null;
    var pdfName = "";

    var usignToken = "YOUR_SECRET";
    var usignFileId = "";

    var dataRetrievers = {

        //[ETemplateType.HORIZON]: function () {
        //    console.log("Handling HORIZON template");
        //},

        //[ETemplateType.PNRR]: function () {
        //    console.log("Handling PNRR template");
        //},

        //[ETemplateType.MISE]: function () {
        //    console.log("Handling MISE template");
        //},

        [ETemplateType.PSRCAMPANIA]: function (timesheet) {

            console.log("Retrieving extra data for PSRCAMPANIA");

            var data = {
                sets: {},
                tables: {},
            };


            const datasetConfigs = [
                {
                    name: 'progettoregistry_aziende',
                    editType: 'seg',
                    getFilter: (opts) => appMeta.currApp.q.eq('idprogetto', opts.idprogetto),
                },
                {
                    name: 'registry',
                    editType: 'docenti',
                    getFilter: (opts) => appMeta.currApp.q.eq('idreg', opts.idreg),
                },
            ];
            const tableConfigs = [
                {
                    name: 'costoorariomembroattivitaprogettoperiodoview',
                    getFilter: (opts) => appMeta.currApp.q
                        .and(appMeta.currApp.q.eq('idreg', opts.idreg),
                            appMeta.currApp.q.eq('idprogetto', opts.idprogetto),
                            appMeta.currApp.q.eq('anno', opts.year)),
                },
                {
                    name: 'rendicontattivitaprogettomesetmview',
                    getFilter: (opts) => {
                        const q = appMeta.currApp.q;
                        const filters = [
                            q.eq('idreg', opts.idreg),
                            q.eq('idprogetto', opts.idprogetto),
                            q.eq('anno', opts.year)
                        ];

                        if (opts.mese) {
                            filters.push(q.eq('mese', opts.mese));
                        }

                        return q.and(...filters);
                    }
                }
            ];

            const dsPromises = datasetConfigs.map(cfg => {

                const filter = cfg.getFilter(timesheet.opts);    // valutiamo il filtro

                return appMeta.getData.getDataSet(cfg.name, cfg.editType)
                    .then(emptyDS => appMeta.getData.fillDataSet(emptyDS, cfg.name, cfg.editType, filter))
                    .then(filledDS => {
                        data.sets[cfg.name] = data.sets[cfg.name] || {};
                        data.sets[cfg.name][cfg.editType] = filledDS;
                    });
            });
            const tablePromises = tableConfigs.map(cfg => {

                const filter = cfg.getFilter(timesheet.opts)    // valutiamo il filtro

                return appMeta.getData.runSelect(cfg.name, '*', filter, null)
                    .then(tableData => {
                        data.tables[cfg.name] = data.tables[cfg.name] || {};
                        data.tables[cfg.name] = tableData;
                    });
            });

            const promises = [...dsPromises, ...tablePromises];

            return Promise.all(promises)
                .then(() => {
                    return data;
                })
                .catch((err) => {
                    var tmp = err;
                })
        }
    };

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

            //se per errore non viene indicato il template va in onda horizon
            if (!opts.idtimesheettemplate) opts.idtimesheettemplate = ETemplateType.HORIZON;

            this.metaPageState = opts.state;
            this.opts = opts;
            this.pdf = opts.output == 'P' || opts.output == 'F';

            this.signed = opts.output == 'F';
            this.signedAllowed = true;

            //partenza delle tabelle con i mesi
            this.offsetX = 1;
            this.offsetY = 2;

            //ffset se c'è l'intestazione in tutti i fogli
            this.offsetXYear = 0;
            this.offsetYFrontespizio = 0;

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
            if (
                opts.idtimesheettemplate === ETemplateType.PNRR_PF ||
                opts.idtimesheettemplate === ETemplateType.PNRR || 
                opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT || 
                opts.idtimesheettemplate === ETemplateType.NBFC_CNR ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS_5 ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS ||
                opts.idtimesheettemplate === ETemplateType.MASE ||
                opts.idtimesheettemplate === ETemplateType.PNC ||
                opts.idtimesheettemplate === ETemplateType.MISE ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND ||
                opts.idtimesheettemplate === ETemplateType.MALATTIE_RARE
            ) {
                //... ma se è il template pnrr devo prendere tutto
                filter = q.and(
                    q.eq("anno", opts.year),
                    q.eq("idreg", opts.idreg)
                );
            }

            var currDt = null;

            this.initSignatureLabels(opts)  // questa logica andrebbe spostata in initRequiredData ora che abbiamo il sistema per recuperare dati aggiuntivi
                .then(() => {
                    appMeta.getData.runSelect('timesheetview', '*', filter, null)
                        .then(function (dt) {
                            currDt = dt;
                            return self.getLogo(opts, currDt);
                        })
                        .then(() => {
                            return self.initRequiredData(opts);
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
        getLogo: function (opts, currDt) {
            var def = appMeta.Deferred("getLogo");
            let self = this;

            // Create a mapping for adjusting timesheet logo cell positions (modificatori)
            const timesheetAdjustment = {
                [ETemplateType.HORIZON]: (cellStr) => {
                    const indexes = self.cellStringToIndices(cellStr);
                    return self.indicesToCellString(indexes.rowIndex, indexes.columnIndex - 1);
                },
                [ETemplateType.HORIZON_Y]: (cellStr) => {
                    const indexes = self.cellStringToIndices(cellStr);
                    return self.indicesToCellString(indexes.rowIndex, indexes.columnIndex - 1);
                }
            };

            // questi sarebbero da omogeneizzare per snellire il codice e renderlo più funzionale in tutti i sensi
            const logoAteneoConfig = {
                default:                    { timesheetLogoCellTLYear: 'N2', timesheetLogoCellBRYear: 'P8', timesheetLogoCellTL: 'AA2', timesheetLogoCellBR: 'AC8', maxHeightInCells: 6 },
                [ETemplateType.NBFC_CNR]:   { timesheetLogoCellTLYear: 'N3', timesheetLogoCellBRYear: 'P8', timesheetLogoCellTL: 'AA3', timesheetLogoCellBR: 'AC8', maxHeightInCells: 1 },
                [ETemplateType.HORIZON]:    { timesheetLogoCellTLYear: 'N2', timesheetLogoCellBRYear: 'P8', timesheetLogoCellTL: 'AA2', timesheetLogoCellBR: 'AC8', maxHeightInCells: 4 },
                [ETemplateType.HORIZON_Y]:  { timesheetLogoCellTLYear: 'N2', timesheetLogoCellBRYear: 'P8', timesheetLogoCellTL: 'AA2', timesheetLogoCellBR: 'AC8', maxHeightInCells: 4 },
                [ETemplateType.EMPIR]:      { timesheetLogoCellTLYear: 'B2', timesheetLogoCellBRYear: 'D8', timesheetLogoCellTL: 'B2', timesheetLogoCellBR: 'D8', maxHeightInCells: 6 },
                //[ETemplateType.MISE]:       { timesheetLogoCellTLYear: 'V2', timesheetLogoCellBRYear: 'P8', timesheetLogoCellTL: 'AA2', timesheetLogoCellBR: 'AC8', maxHeightInCells: 6 },
                [ETemplateType.MIMIT_2]:    { timesheetLogoCellTLYear: 'N2', timesheetLogoCellBRYear: 'P8', timesheetLogoCellTL: 'AA2', timesheetLogoCellBR: 'AC8', maxHeightInCells: 6 }
            };

            const logoProgettoConfig = {
                default:                    { topLeftLogoProgettoYear: 'B2', bottomRigthLogoProgettoYear: 'D8', topLeftLogoProgetto: 'B2', bottomRigthLogoProgetto: 'D8' },
                [ETemplateType.HORIZON]:    { topLeftLogoProgettoYear: 'B2', bottomRigthLogoProgettoYear: 'C6', topLeftLogoProgetto: 'B2', bottomRigthLogoProgetto: 'C6' },
                [ETemplateType.HORIZON_Y]:  { topLeftLogoProgettoYear: 'B2', bottomRigthLogoProgettoYear: 'C6', topLeftLogoProgetto: 'B2', bottomRigthLogoProgetto: 'C6' },
                //[ETemplateType.MISE]:       { topLeftLogoProgettoYear: 'O9', bottomRigthLogoProgettoYear: 'Q15', topLeftLogoProgetto: 'AA9', bottomRigthLogoProgetto: 'AC15' },
                [ETemplateType.EMPIR]:      { topLeftLogoProgettoYear: 'F2', bottomRigthLogoProgettoYear: 'G7', topLeftLogoProgetto: 'F2', bottomRigthLogoProgetto: 'J7' }
            };

            const logoTemplateConfig = {
                default:                            { logoTemplatePath: null, logoTemplateTopLeft: 'E2', logoTemplateBottomRigth: 'O9' },
                [ETemplateType.PON]:                { logoTemplatePath: 'assets/PONLogo.png', logoTemplateTopLeft: 'E2', logoTemplateBottomRigth: 'M9' },
                [ETemplateType.PNRR]:               { logoTemplatePath: 'assets/PNRRLogo.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.PNRR_PF]:            { logoTemplatePath: 'assets/PNRRLogo.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.PNRR_AGE_IT]:        { logoTemplatePath: 'assets/loghi_age-it.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.NBFC_CNR]:           { logoTemplatePath: 'assets/NBFC_CNRLogo.png', logoTemplateTopLeft: 'D3', logoTemplateBottomRigth: 'U7' },
                [ETemplateType.FSC_MS_3]:           { logoTemplatePath: 'assets/FSC_MSLogo.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.PATTO_TERR]:         { logoTemplatePath: 'assets/PATTO_TERRLogo.png', logoTemplateTopLeft: 'C2', logoTemplateBottomRigth: 'U7' },
                [ETemplateType.FSC_MS_5]:           { logoTemplatePath: 'assets/FSC_MSLogo.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.FSC_MS]:             { logoTemplatePath: 'assets/FSC_MSLogo.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.PNC]:                { logoTemplatePath: 'assets/PNCLogo.png', logoTemplateTopLeft: 'E2', logoTemplateBottomRigth: 'O9' },
                [ETemplateType.MASE]:               { logoTemplatePath: 'assets/MASELogo.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
                [ETemplateType.PORCAMPANIA]:        { logoTemplatePath: 'assets/PORCAMPANIALogo.png', logoTemplateTopLeft: 'E2', logoTemplateBottomRigth: 'O9' },
                [ETemplateType.PORCAMPANIA_21_27]:  { logoTemplatePath: 'assets/porcampania2127.png', logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'O7' },
                [ETemplateType.MIMIT]:              { logoTemplatePath: 'assets/Logo_Ministero_Imprese_e_Made_in_Italy.png', logoTemplateTopLeft: 'E2', logoTemplateBottomRigth: 'L9' },
                [ETemplateType.MIMIT_2]:            { logoTemplatePath: 'assets/Logo_Ministero_Imprese_e_Made_in_Italy.png', logoTemplateTopLeft: 'E2', logoTemplateBottomRigth: 'L9', },
                [ETemplateType.MALATTIE_RARE]:      { logoTemplatePath: null, logoTemplateTopLeft: 'D2', logoTemplateBottomRigth: 'P9' },
            };

            const logoOverrideExclusions = [];

            //LOGO ATENEO --------------------------------------------------------------------------------------------------------------------

            // Get configuration based on the current template,
            // falling back to the default if nothing specific exists.
            const ateneoConfig = logoAteneoConfig[opts.idtimesheettemplate] || logoAteneoConfig.default;
            self.timesheetLogoCellTLYear = ateneoConfig.timesheetLogoCellTLYear;
            self.timesheetLogoCellBRYear = ateneoConfig.timesheetLogoCellBRYear;
            self.timesheetLogoCellTL = ateneoConfig.timesheetLogoCellTL;
            self.timesheetLogoCellBR = ateneoConfig.timesheetLogoCellBR;
            self.maxHeightInCells = ateneoConfig.maxHeightInCells

            // valutiamo se il logo override è definito
            let principalProjectRows = currDt.select(q.eq('idprogetto', appMeta.currApp.currentMetaPage.state.currentRow.idprogetto));
            let overrideLogo = !!(principalProjectRows?.[0]?.idattach_logot);

            utils._if(!!overrideLogo && !logoOverrideExclusions.includes(opts.idtimesheettemplate))
                ._then(() => {
                    self.getLogoOverride(opts, currDt)
                        .then(imageContent => {

                            var ateneoConfig = logoAteneoConfig[opts.idtimesheettemplate] || logoAteneoConfig.default;
                            var progettoConfig = logoProgettoConfig[opts.idtimesheettemplate] || logoProgettoConfig.default;
                            var templateConfig = logoTemplateConfig[opts.idtimesheettemplate] || logoTemplateConfig.default;

                            // se ci sono modificatori
                            if (timesheetAdjustment[opts.idtimesheettemplate]) {
                                ateneoConfig.timesheetLogoCellBRYear = timesheetAdjustment[opts.idtimesheettemplate](self.timesheetLogoCellBRYear);
                                ateneoConfig.timesheetLogoCellBR = timesheetAdjustment[opts.idtimesheettemplate](self.timesheetLogoCellBR);
                            }

                            var logoCoords = {
                                month: [
                                    { topLeft: ateneoConfig.timesheetLogoCellTL, bottomRight: ateneoConfig.timesheetLogoCellBR },
                                    { topLeft: progettoConfig.topLeftLogoProgetto, bottomRight: progettoConfig.bottomRigthLogoProgetto },
                                    { topLeft: templateConfig.logoTemplateTopLeft, bottomRight: templateConfig.logoTemplateBottomRigth },
                                ],
                                year: [
                                    { topLeft: ateneoConfig.timesheetLogoCellTLYear, bottomRight: ateneoConfig.timesheetLogoCellBRYear },
                                    { topLeft: progettoConfig.topLeftLogoProgettoYear, bottomRight: progettoConfig.bottomRigthLogoProgettoYear },
                                    { topLeft: templateConfig.logoTemplateTopLeft, bottomRight: templateConfig.logoTemplateBottomRigth },
                                ],
                            }

                            if (imageContent) {

                                self.logoOverride = {
                                    imageBase64: imageContent,
                                    area: {
                                        month: {
                                            get topLeft() {
                                                const rowIndex = Math.min(...logoCoords.month.map(obj => self.cellStringToIndices(obj.topLeft).rowIndex));
                                                const columnIndex = Math.min(...logoCoords.month.map(obj => self.cellStringToIndices(obj.topLeft).columnIndex));
                                                return {
                                                    rowIndex,
                                                    columnIndex,
                                                    cellString: self.indicesToCellString(rowIndex, columnIndex)
                                                };
                                            },
                                            get bottomRight() {
                                                const rowIndex = Math.max(...logoCoords.month.map(obj => self.cellStringToIndices(obj.bottomRight).rowIndex));
                                                const columnIndex = Math.max(...logoCoords.month.map(obj => self.cellStringToIndices(obj.bottomRight).columnIndex));
                                                return {
                                                    rowIndex,
                                                    columnIndex,
                                                    cellString: self.indicesToCellString(rowIndex, columnIndex)
                                                };
                                            },
                                            get dimensions() {
                                                return {
                                                    height: this.bottomRight.rowIndex - this.topLeft.rowIndex,
                                                    width: this.bottomRight.columnIndex - this.topLeft.columnIndex
                                                };
                                            }
                                        },
                                        year: {
                                            get topLeft() {
                                                const rowIndex = Math.min(...logoCoords.year.map(obj => self.cellStringToIndices(obj.topLeft).rowIndex));
                                                const columnIndex = Math.min(...logoCoords.year.map(obj => self.cellStringToIndices(obj.topLeft).columnIndex));
                                                return {
                                                    rowIndex,
                                                    columnIndex,
                                                    cellString: self.indicesToCellString(rowIndex, columnIndex)
                                                };
                                            },
                                            get bottomRight() {
                                                const rowIndex = Math.max(...logoCoords.year.map(obj => self.cellStringToIndices(obj.bottomRight).rowIndex));
                                                const columnIndex = Math.max(...logoCoords.year.map(obj => self.cellStringToIndices(obj.bottomRight).columnIndex));
                                                return {
                                                    rowIndex,
                                                    columnIndex,
                                                    cellString: self.indicesToCellString(rowIndex, columnIndex)
                                                };
                                            },
                                            get dimensions() {
                                                return {
                                                    height: this.bottomRight.rowIndex - this.topLeft.rowIndex,
                                                    width: this.bottomRight.columnIndex - this.topLeft.columnIndex
                                                };
                                            }
                                        }
                                    }
                                };

                            }
                            else {

                                delete self.logoOverride;
                            }

                            self.getBottomRightCornerCellModified(
                                self.logoOverride.imageBase64,
                                self.logoOverride.area.year.topLeft.cellString,
                                self.logoOverride.area.month.topLeft.cellString,
                                self.logoOverride.area.year.dimensions.height,
                                self.logoOverride.area.year.dimensions.width,
                                10, 35)
                                .then(positions => {
                                    //riassegno le celle bottom-right ricalcolate in base alle dimensioni del logo
                                    self.logoOverride.area.year.bottomRight_cellString = positions.cellYear;

                                    self.getBottomRightCornerCellModified(
                                        self.logoOverride.imageBase64,
                                        self.logoOverride.area.year.topLeft.cellString,
                                        self.logoOverride.area.month.topLeft.cellString,
                                        self.logoOverride.area.month.dimensions.height,
                                        self.logoOverride.area.month.dimensions.width
                                        , 10, 35)
                                        .then(positions => {
                                            //riassegno le celle bottom-right ricalcolate in base alle dimensioni del logo
                                            self.logoOverride.area.month.bottomRight_cellString = positions.cellMonth;

                                            return def.resolve(imageContent);
                                        })
                                })
                        })
                })
                ._else(() => {
                    self.getLogoAteneo()
                        .then(function (logoAteneo) {
                            self.getBottomRightCornerCell(logoAteneo, self.timesheetLogoCellTLYear, self.timesheetLogoCellTL, self.maxHeightInCells)
                                .then(function (positions) {
                                    self.timesheetLogoCellBRYear = positions.cellYear;
                                    self.timesheetLogoCellBR = positions.cell;

                                    // se ci sono modificatori
                                    if (timesheetAdjustment[opts.idtimesheettemplate]) {
                                        self.timesheetLogoCellBRYear = timesheetAdjustment[opts.idtimesheettemplate](self.timesheetLogoCellBRYear);
                                        self.timesheetLogoCellBR = timesheetAdjustment[opts.idtimesheettemplate](self.timesheetLogoCellBR);
                                    }

                                    //LOGO PROGETTO ----------------------------------------------------------------------------------------------------

                                    // Get configuration based on the current template,
                                    // falling back to the default if nothing specific exists.
                                    const progettoConfig = logoProgettoConfig[opts.idtimesheettemplate] || logoProgettoConfig.default;
                                    self.topLeftLogoProgettoYear = progettoConfig.topLeftLogoProgettoYear;
                                    self.bottomRigthLogoProgettoYear = progettoConfig.bottomRigthLogoProgettoYear;
                                    self.topLeftLogoProgetto = progettoConfig.topLeftLogoProgetto;
                                    self.bottomRigthLogoProgetto = progettoConfig.bottomRigthLogoProgetto;

                                    self.getLogoProgetto(opts, currDt)
                                        .then(function (logoProgetto) {

                                            self.logoProgetto = logoProgetto;

                                            // LOGO TEMPLATE -------------------------------------------------------------------------------------------
                                            const templateConfig = logoTemplateConfig[opts.idtimesheettemplate] || logoTemplateConfig.default;
                                            self.logoTemplatePath = templateConfig.logoTemplatePath;
                                            self.logoTemplateTopLeft = templateConfig.logoTemplateTopLeft || logoTemplateConfig.default.logoTemplateTopLeft
                                            self.logoTemplateBottomRigth = templateConfig.logoTemplateBottomRigth || logoTemplateConfig.default.logoTemplateBottomRigth;

                                            // If no logo path is specified, then there's no template logo to load.
                                            if (!self.logoTemplatePath) {
                                                self.logoTemplate = null;
                                                return def.resolve();
                                            } else {
                                                self.getLogoTemplate(self.logoTemplatePath)
                                                    .then(function (logoTemplateProgetto) {
                                                        self.logoTemplate = logoTemplateProgetto;
                                                        return def.resolve(logoTemplateProgetto);
                                                    });
                                            }
                                        });
                                });
                        });
                });


            return def.promise();
        },

        /**
         *
         * @returns {Deferred(string)}
         */
        getLogoTemplate: function (imgUrl) {
            // è un img locale al sito
            var def = appMeta.Deferred("getLogoTemplate");
            this.getBase64Image(
                imgUrl,
                function (logoBase64Url) {
                    logoBase64Url = "data:image/png;base64," + logoBase64Url
                    return def.resolve(logoBase64Url);
            });
            return def.promise();
        },

        /**
         * call ws "downloadLogo" to downloading logo of Istitute if is not present in configuration
         * @returns {*}
         */
        getLogoAteneo: function () {
            var def = appMeta.Deferred("getLogoAteneo");
            if (appMeta.config.logoBase64) {
                appMeta.logoBase64 = appMeta.config.logoBase64;
                return def.resolve(appMeta.logoBase64);
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
        * call ws "downloadLogoProgetto" to downloading override logo of Project
        * @returns {*}
        */
        getLogoOverride: function (opts, dtInput) {
            var def = appMeta.Deferred("getLogoOverride");

            let principalProjectRows = dtInput.select(q.eq('idprogetto', opts.idprogetto));
            if (principalProjectRows.length && principalProjectRows[0].idattach_logot) {

                appMeta.callWebService("downloadLogoProgetto", { idattach: principalProjectRows[0].idattach_logot })
                    .then(function (logoBase64) {
                        def.resolve("data:image/png;base64," + logoBase64);
                    })
                    .fail(function () {
                        console.log("missing timesheet logo");
                        def.resolve(null);
                    });
                return def.promise();
            } else {
                return def.resolve("getLogoOverride");
            }
        },

        /**
         * call ws "downloadLogoProgetto" to downloading logo of Project
         * @returns {*}
         */
        getLogoProgetto: function (opts, dtInput) {
            var def = appMeta.Deferred("getLogoProgetto");
            let principalProjectRows = dtInput.select(q.eq('idprogetto', opts.idprogetto));
            if (principalProjectRows.length && principalProjectRows[0].idattach) {

                appMeta.callWebService("downloadLogoProgetto", { idattach: principalProjectRows[0].idattach })
                    .then(function (logoBase64) {
                        def.resolve("data:image/png;base64," + logoBase64);
                    })
                    .fail(function () {
                        console.log("missing timesheet logo");
                        def.resolve(null);
                    });
                return def.promise();
            } else {
                return def.resolve(null);
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

            if (!opts.idprogetto) {
                return def.reject("Occorre selezionare un progetto principale.");
            } else {
                // ragruppo per progetto e poi per workpackage, ma Teaching activities va per ultimo
                dtInput.rows = _.sortBy(dtInput.rows, function (r) {
                    if (r.progetto === 'Other Research Activities') return "zzzu";
                    if (r.progetto === 'Other activities') return "zzzv";
                    if (r.progetto === 'Teaching activities') return "zzzw";
                    if (r.tipoprogetto == 'malattia') return "zzzx";
                    if (r.tipoprogetto == 'ferie') return "zzzy";
                    if (r.tipoprogetto == 'permessi') return "zzzz";
                   return r.progetto;
                });

                //se devo unire le attività didattiche con le altre attività
                if (opts.collapseteachingother == true) {
                    //scelgo la lingua
                    if (opts.idtimesheettemplate === ETemplateType.HORIZON || opts.idtimesheettemplate === ETemplateType.HORIZON_Y || opts.idtimesheettemplate === ETemplateType.EMPIR)
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

                //se devo collassare le sospensioni in un unica riga
                if (opts.idtimesheettemplate === ETemplateType.PNRR ||
                    opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT ||
                    opts.idtimesheettemplate === ETemplateType.MALATTIE_RARE) {

                    _.forEach(dtInput.rows, function (r) {
                        if (r.tipoprogetto == 'malattia') r.progetto = "Altro (Malattia, Ferie, Permessi, …)";
                        if (r.tipoprogetto == 'ferie') r.progetto = "Altro (Malattia, Ferie, Permessi, …)";
                        if (r.tipoprogetto == 'permessi') r.progetto = "Altro (Malattia, Ferie, Permessi, …)";
                    });
                }
                if (opts.idtimesheettemplate === ETemplateType.MASE) {
                    _.forEach(dtInput.rows, function (r) {
                        if (r.tipoprogetto == 'malattia') r.progetto = "Altro (malattia, ferie, permessi, etc..) (E)";
                        if (r.tipoprogetto == 'ferie') r.progetto = "Altro (malattia, ferie, permessi, etc..) (E)";
                        if (r.tipoprogetto == 'permessi') r.progetto = "Altro (malattia, ferie, permessi, etc..) (E)";
                    });
                }



                let principalProjectRows = dtInput.select(q.eq('idprogetto', opts.idprogetto));
                let enteFinanziatore = '';
                if (principalProjectRows.length)
                    enteFinanziatore = principalProjectRows[0].idreg_aziende_fin ? principalProjectRows[0].idreg_aziende_fin : '';

                //per alcuni template tutti gli altri progetti finiscono in un rigo solo (tutti template in italiano)
                if (
                    opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND || 
                    opts.idtimesheettemplate === ETemplateType.MIMIT ||
                    opts.idtimesheettemplate === ETemplateType.POR ||
                    opts.idtimesheettemplate === ETemplateType.PORCAMPANIA ||
                    opts.idtimesheettemplate === ETemplateType.FSC_MS_5 ||
                    opts.idtimesheettemplate === ETemplateType.FSC_MS
                ) {
                    _.forEach(dtInput.rows, function (r) {
                        if (r.idprogetto != opts.idprogetto && (r.tipoprogetto == 'ricerca' || r.tipoprogetto == 'fittizio ricerca'))
                            switch (opts.idtimesheettemplate) {
                                case ETemplateType.FSC_MS:
                                    if (r.idreg_aziende_fin == enteFinanziatore)
                                        r.progetto = "Altri progetti finanziati";
                                        else
                                        r.progetto = "Altri progetti";
                                   break;
                                case ETemplateType.FSC_MS_5:
                                    r.progetto = "hpp";
                                    break;
                                case ETemplateType.MIMIT:
                                    r.progetto = "Altre attività non di pertinenza del progetto";
                                    break;
                                default:
                                    r.progetto = "Altri progetti finanziati";
                            }
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

                            //resetto gli standard del costruttore
                            self.COLOR_MONTH = "#ff3333";
                            self.COLOR_ROW_PROG = "#efeff5";
                            self.COLOR_ROW_TOTAL = "#c0c0d8";
                            self.COLOR_CELL_FRONTESPIZIO = "#ff3333";
                            self.COLOR_CELL_ERRORE = "#ff3333";

                            if (opts.idtimesheettemplate === ETemplateType.HORIZON) {
                                self.COLOR_MONTH = "#ff3333"; //rosso
                                self.COLOR_MONTH_FONT = new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1);//bianco
                            }

                            if (opts.idtimesheettemplate === ETemplateType.HORIZON_Y) {
                                self.COLOR_MONTH = "#ffff99"; //giallo
                                self.COLOR_ROW_TOTAL = "#ffcc66"; //giallo scuro 
                                self.COLOR_CELL_FRONTESPIZIO = "#ffff99"; //giallo
                                self.COLOR_MONTH_FONT = null; //nero
                            }

                            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                                self.COLOR_MONTH = "#acb9ca"; //grigio-celestino
                                self.COLOR_ROW_TOTAL = "#d6dce4"; //grigetto 
                                self.COLOR_CELL_FRONTESPIZIO = "#ddebf7"; //celestino
                                self.COLOR_MONTH_FONT = null; //nero
                            }

                            if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5) {
                                self.COLOR_MONTH = "#ffffff"; //bianco
                                self.COLOR_ROW_TOTAL = "#ffffff"; //bianco
                                self.COLOR_CELL_FRONTESPIZIO = "#ffffff"; //bianco
                                self.COLOR_MONTH_FONT = null; //nero
                            }

                            if (opts.idtimesheettemplate === ETemplateType.FSC_MS_3 || opts.idtimesheettemplate === ETemplateType.FSC_MS) {
                                self.COLOR_MONTH = "#99CCFF"; //azzurro
                                self.COLOR_ROW_TOTAL = "#ccccff"; //lilla
                                self.COLOR_CELL_FRONTESPIZIO = "#ccccff"; //lilla
                                self.COLOR_MONTH_FONT = null; //nero
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PNRR ||
                                opts.idtimesheettemplate === ETemplateType.PNRR_PF ||
                                opts.idtimesheettemplate === ETemplateType.MALATTIE_RARE) {
                                self.COLOR_MONTH = "#DCE6F1"; //azzurrino
                                self.COLOR_MONTH_FONT = null; //nero
                            }
                            if (opts.idtimesheettemplate === ETemplateType.MASE ) {
                                self.COLOR_MONTH = "#548235"; //verde militare
                                self.COLOR_MONTH_FONT = new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1);//bianco
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PON) {
                                self.COLOR_MONTH = "#DCE6F1";//azzurrino
                                self.COLOR_MONTH_FONT = null;//nero
                            }

                            if (opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND) {
                                self.COLOR_MONTH = "#eeece1";//giallino
                                self.COLOR_MONTH_FONT = null;//nero
                                self.COLOR_ROW_TOTAL = "#ffffff"; //bianco
                            }

                            if (opts.idtimesheettemplate === ETemplateType.MIMIT) {
                                self.COLOR_MONTH = "#b8cce4";//azzurrino intenso
                                self.COLOR_MONTH_FONT = null;//nero
                            }

                            if (
                                opts.idtimesheettemplate === ETemplateType.PNC ||
                                opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT
                            ) {
                                self.COLOR_MONTH = "#008200"; //verde
                                self.COLOR_MONTH_FONT = new $.ig.excel.WorkbookColorInfo($.ig.excel.WorkbookThemeColorType.light1);//bianco
                            }

                            if (
                                opts.idtimesheettemplate === ETemplateType.MISE ||
                                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                                opts.idtimesheettemplate === ETemplateType.EMPIR ||
                                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                                opts.idtimesheettemplate === ETemplateType.PATTO_TERR
                           ) {
                                self.COLOR_MONTH = "#FFFFFF";//bianco
                                self.COLOR_MONTH_FONT = null;//nero
                            }

                            if (opts.idtimesheettemplate === ETemplateType.PORCAMPANIA) {
                                self.COLOR_MONTH = "#99CCFF"; //azzurro
                                self.COLOR_MONTH_FONT = null; //nero
                                self.COLOR_ROW_TOTAL = "#CCCCFF";
                            }

                            self.getFrontespizioData(opts, dtInput);

                            //setto la variabile che non è stato costruito ancora alcun frontespizio
                            self.isFirstFrontespizio = true;

                            // 1o foglio con dettaglio dell'anno
                            if (opts.riepilogoanno) {
                                var sheet = workbook.worksheets().add(opts.year.toString());
                                self.addYearResumeSheet(sheet, objGrouped, dtInput, opts, logoBase64);
                            }
                            // se NON c'è l'instestazione su tutti i fogli allora tolgo la Y della intestazione per i mesi
                            if (!opts.intestazioneallsheet) {
                                self.offsetY -= self.offsetYFrontespizio;
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
                                        if (begin.getTime() < sal[0].sal_start.getTime())
                                            begin = sal[0].sal_start;
                                        if (end.getTime() > sal[0].sal_stop.getTime())
                                            end = sal[0].sal_stop;
                                        startMonth = begin.getMonth() + 1;
                                        stopMonth = end.getMonth() + 1;
                                    }
                                }

                                for (var monthCounter = startMonth; monthCounter <= stopMonth; monthCounter++) {
                                    self.calcTimeSheetTable(workbook, objGrouped, monthCounter, dtInput, opts, logoBase64, monthCounter == startMonth, monthCounter == stopMonth);
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
                    console.log("5 - Salva il file excel");
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
            var divPdfLayer = "";

            if (this.opts.pdfFirmato == "U") {
                // =====================================================================================
                //                                      U-SIGN
                // =====================================================================================
                divPdfLayer =
                    '<div id="pdfLayer">' +
                        '<div id="pdfSignContainer">' +
                            '<div class="row">' +
                                '<div class="col-md-3"></div>' +
                                '<div class="col-md-9">' +
                                    '<img src="assets/gosign.png" style="height: 60px;margin: -10px 0 -5px -26px;">' +
                                '</div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-md-3 text-right"><label class="col-form-label">E-mail</label></div>' +
                                '<div class="col-md-9"><input id="sign_email" type="text" class="form-control" /></div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-md-3 text-right"><label class="col-form-label">Pin</label></div>' +
                                '<div class="col-md-9"><input id="sign_pin" type="password" class="form-control" /></div>' +
                            '</div>' +
                            '<div class="row" id="usignOtp" style="display: none">' +
                                '<div class="col-md-3 text-right"><label class="col-form-label">Otp</label></div>' +
                                '<div class="col-md-9"><input id="sign_otp" class="form-control" /></div>' +
                            '</div>' +
                            '<div class="row" id="errEmail" style="margin-top:10px; display:none">' +
                                '<div class="col-md-12">' +
                                    '<label class="col-form-label" style="color:red!important">E-mail obbligatoria</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" id="errPin" style="margin-top: 10px; display: none">' +
                                '<div class="col-md-12">' +
                                    '<label class="col-form-label" style="color:red!important">Pin obbligatorio</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" id="errOtp" style="margin-top: 10px; display: none">' +
                                '<div class="col-md-12">' +
                                    '<label class="col-form-label" style="color:red!important">Otp obbligatorio</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" style="margin-top: 20px;">' +
                                '<div class="col-md-6 text-left" id="usignUpload">' +
                                    '<input class="btn btn-primary" type="button" value="Firma Pdf" onclick="appMeta.Timesheet.doSignPdfUSign()">' +
                                '</div>' +
                                '<div class="col-md-6 text-left" id="usignDownload" style="display: none">' +
                                    '<input class="btn btn-primary" type="button" value="Firma Pdf" onclick="appMeta.Timesheet.doDownloadPdfUSign()">' +
                                '</div>' +
                            //se la filigrana è obbligatoria devo spengere qui il download del PDF non firmato perchè non ho più modo di inserirla
                            (this.opts.watermark ?
                                '<div class="col-md-6 text-right"><input class="btn btn-secondary" type="button" value="Chiudi" onclick="appMeta.Timesheet.pdfLayerRemove()"></div>' :
                                '<div class="col-md-6 text-right"><input class="btn btn-secondary" type="button" value="Download Pdf" onclick="appMeta.Timesheet.doNotSignPdf()"></div>') +
                            '</div>' +
                        '</div>' +
                    '</div>';
            }
            else {
                // =====================================================================================
                //                                      ARUBA
                // =====================================================================================
                divPdfLayer =
                    '<div id="pdfLayer">' +
                        '<div id="pdfSignContainer">' +
                            '<div class="row">' +
                                '<div class="col-md-3"></div>' +
                                '<div class="col-md-9 mb-2">' +
                                    '<img src="assets/aruba.png" style="height: 40px; margin-right: 10px;">Aruba Sign' +
                                '</div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-md-3 text-right"><label class="col-form-label">Username</label></div>' +
                                '<div class="col-md-9"><input id="sign_username" type="text" class="form-control" /></div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-md-3 text-right"><label class="col-form-label">Password</label></div>' +
                                '<div class="col-md-9"><input id="sign_password" type="password" class="form-control" /></div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-md-3 text-right"><label class="col-form-label">Otp</label></div>' +
                                '<div class="col-md-9"><input id="sign_otp" class="form-control" /></div>' +
                            '</div>' +
                            '<div class="row">' +
                                '<div class="col-md-12">' +
                                    '<div class="custom-control custom-radio">' +
                                        '<label class="col-form-label">Formato:</label>' +
                                        '<input id="sign_typeP" type="radio" name="sign_type" class="custom-control-input" value="P" checked />' +
                                        '<label>PAdES (pdf)</label>' +
                                        '<input id="sign_typeC" type="radio" name="sign_type" class="custom-control-input" value="C" />' +
                                        '<label>CAdES (p7m)</label>' +
                                    '</div>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" id="errUsername" style="margin-top:10px; display:none">' +
                                '<div class="col-md-12">' +
                                    '<label class="col-form-label" style="color:red!important">Username obbligatoria</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" id="errPassword" style="margin-top: 10px; display: none">' +
                                '<div class="col-md-12">' +
                                    '<label class="col-form-label" style="color:red!important">Password obbligatoria</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" id="errOtp" style="margin-top: 10px; display: none">' +
                                '<div class="col-md-12">' +
                                    '<label class="col-form-label" style="color:red!important">Otp obbligatorio</label>' +
                                '</div>' +
                            '</div>' +
                            '<div class="row" style="margin-top: 20px;">' +
                                '<div class="col-md-6 text-left">' +
                                    '<input class="btn btn-primary" type="button" value="Firma Pdf" onclick="appMeta.Timesheet.doSignPdfAruba()">' +
                                '</div>' +
                            //se la filigrana è obbligatoria devo spengere qui il download del PDF non firmato perchè non ho più modo di inserirla
                            (this.opts.watermark ?
                                '<div class="col-md-6 text-right"><input class="btn btn-secondary" type="button" value="Chiudi" onclick="appMeta.Timesheet.pdfLayerRemove()"></div>' :
                                '<div class="col-md-6 text-right"><input class="btn btn-secondary" type="button" value="Download Pdf" onclick="appMeta.Timesheet.doNotSignPdf()"></div>') +
                            '</div>' +
                        '</div>' +
                    '</div>';
                }

            // Add Layer
            $('body').append(divPdfLayer);
        },

        pdfLayerRemove: function () {
            $('#pdfLayer').remove();
        },

        docConvPdf: function (workbook, name, signed) {
            var self = this;
            try {
                if (this.verbose)
                    console.log("5 - Salva il file pdf");

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

        doSignPdfAruba: async function () {
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
            appMeta.callWebService("signFileAruba", {
                byteStream: pdfData,
                username: sign_username,
                password: sign_password,
                otp: sign_otp,
                type: sign_type,
                signServer: this.opts.pdfFirmato
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

        doSignPdfUSign: async function () {
            let self = this;

            $('#errEmail').hide();
            $('#errPin').hide();

            var sign_email = $('#sign_email')[0].value;
            var sign_pin = $('#sign_pin')[0].value;

            if (sign_email == "") {
                $('#errEmail').show();
                return;
            }
            if (sign_pin == "") {
                $('#errPin').show();
                return;
            }

            // Show Indicator
            var waitingHandler = appMeta.currApp.currentMetaPage.showWaitingIndicator("Creazione del token di firma in corso...");
            
            // ===========================================
            // FASE 1 - CREATE PROCESS
            // ===========================================
            appMeta.callWebService("createProcessUSign", {
                email: sign_email
            }).then(function (res) {
                // res: token, error

                // Hide Indicator
                appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);

                // Check
                if (res.error != "") {
                    alert("Email '" + sign_email + "' errata!");
                    console.log(res.error);
                    return;
                }

                // Token
                usignToken = res.token;

                // Show Indicator
                var waitingHandler = appMeta.currApp.currentMetaPage.showWaitingIndicator("Upload del documento pdf in corso...");
                
                // ===========================================
                // FASE 2 - UPLOAD FILE
                // ===========================================
                appMeta.callWebService("uploadFileUSign", {
                    token: usignToken,
                    fileName: pdfName,
                    byteStream: pdfData
                }).then(function (res) {
                    // res: fileId, error

                    // Hide Indicator
                    appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);

                    // Check
                    if (res.error != "") {
                        alert("Errore nell'upload del file!");
                        console.log(res.error);
                        return;
                    }

                    // File Id
                    usignFileId = res.fileId;

                    // Show Indicator
                    var waitingHandler = appMeta.currApp.currentMetaPage.showWaitingIndicator("Invio OTP in corso...");

                    // ===========================================
                    // FASE 3 - SEND OTP
                    // ===========================================
                    appMeta.callWebService("sendOtpUSign", {
                        token: usignToken
                    }).then(function (res) {
                        // res: error

                        // Hide Indicator
                        appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);

                        // Check
                        if (res.error != "") {
                            alert("Errore nell'invio dell'OTP!");
                            console.log(res.error);
                            return;
                        }

                        $("#sign_email").attr("readonly", "readonly");
                        $("#usignType").hide();
                        $("#usignOtp").show();
                        $("#usignUpload").hide();
                        $("#usignDownload").show();
                    });
                });
            });
        },

        doDownloadPdfUSign: async function () {
            let self = this;

            $('#errPin').hide();
            $('#errOtp').hide();

            var sign_pin = $('#sign_pin')[0].value;
            var sign_otp = $('#sign_otp')[0].value;

            if (sign_pin == "") {
                $('#errPin').show();
                return;
            }
            if (sign_otp == "") {
                $('#errOtp').show();
                return;
            }

            // Show Indicator
            var waitingHandler = appMeta.currApp.currentMetaPage.showWaitingIndicator("Firma remota del documento pdf in corso");

            // ===========================================
            // FASE 4/5 - SIGN PROCESS/DOWNLOAD SINGLE FILE
            // ===========================================
            appMeta.callWebService("downloadSignedFileUSign", {
                token: usignToken,
                fileId: usignFileId,
                pin: sign_pin,
                otp: sign_otp
            }).then(function (res) {
                // res: outStream, error

                // Hide Indicator
                appMeta.currApp.currentMetaPage.hideWaitingIndicator(waitingHandler);

                // Check
                if (res.error != "") {
                    alert("Pin o OTP errato!");
                    console.log(res.error);
                    return;
                }
                                
                // Create a temporary link element
                var link = document.createElement('a');
                link.href = "data:application/pdf;base64," + res.outStream;
                link.download = pdfName.replace(".xlsx", ".pdf");

                // Programmatically click the link to start the download and remove
                link.click();
                URL.revokeObjectURL(link.href);
                self.pdfLayerRemove();
            });
        },

        addBorder: function (sheet, y, maxcol, top) {
            //bordi orizzontali
            for (var counter = 0; counter <= maxcol; counter++) {
                if (top)
                    sheet.rows(y).cells(counter).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                else
                    sheet.rows(this.posY(y)).cells(counter).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
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
                console.log("2 - Crea foglio di riepilogo per l'anno");
            try {

                this.addBorder(sheet, 0, 17, true);
                this.addSheetLogo(sheet, opts, logoBase64, true);
                this.buildFrontespizio(sheet, opts, dtInput, 16);
                this.createHeadersYear(sheet, opts.year);
                this.addDataYearResume(sheet, obj, dtInput, opts);
                //aggiungo la filigrana 
                this.addFiligrana(opts, sheet, true);
            } catch (e) {
                if (this.verbose)
                    console.log("Errore creando il riepilogo per l'anno. Metodo addYearResumeSheet() ");
            }

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
                console.log("3 - Tutte le righe dei progetti per il riepilogo dell'anno");
            var self = this;
            var rowIndex = 2; // le prime 2 sono header  1 per giorni + 1 vuota

            //se ho scelto il collasso di altre attività e insegnamento e contemporaneamente di mostrare le timbrature (altre attività fittizie) devo TOGLIERE le teachig acivities (che sono già incluse nella timbratura)
            //quindi levo le teaching activitties che avendole collassate ora si chiamano attività istituzionali
            let projects = obj;

            if (opts.collapseteachingother == true && opts.showOtherActivitiesrow == true) {
                projects = _.filter(obj, function (o, pkey) {
                    return pkey != "Attività ordinaria" && pkey != "Institutional activities";
                });
            }

            //aggiungo anche l'idprogetto e l'ente finanziatore
            if (opts.multilineType) {
                _.forEach(projects, function (o) {
                    o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].progetto;
                    o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].cup ?
                        o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].cup:'';
                    o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idprogetto;
                    o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idreg_aziende_fin;
                    o.ismur = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].ismur;
                    o.iseu = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].iseu;
                    o.tipoprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].tipoprogetto;
                });
            } else {
                _.forEach(projects, function (o) {
                    o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].progetto;
                    o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].cup ?
                        o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].cup : '';
                    o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idprogetto;
                    o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idreg_aziende_fin;
                    o.ismur = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].ismur;
                    o.iseu = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].iseu;
                    o.tipoprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].tipoprogetto;
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.EMPIR) {
                self.getRowText(sheet, rowIndex, "In case of absence, indicate one of the reason codes below");
                rowIndex += 1; // righe aggiunte per wp + 1 del prog
            }

            // 2. scorro i progetti

            //2.1 aggiungo prima la riga del progetto principale ----------------------------------------------------
            let objPrg = _.filter(projects, function (o) { return o.idprogetto == opts.idprogetto });
            _.forEach(objPrg, function (el) {
                var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
            });

            if (
                //2A) tempalte con una sola riga per tutti gli altri (li ho già collassati prima)
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS_3 ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS_5 ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS ||
                opts.idtimesheettemplate === ETemplateType.PON ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND ||
                opts.idtimesheettemplate === ETemplateType.MIMIT ||
                opts.idtimesheettemplate === ETemplateType.POR ||

                //2C) template con tutti i progetti
                opts.idtimesheettemplate === ETemplateType.HORIZON ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_Y ||
                opts.idtimesheettemplate === ETemplateType.EMPIR ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.MISE ||
                opts.idtimesheettemplate === ETemplateType.PATTO_TERR 
                
            ) {
                //poi quella degli altri progetti 
                let objFinEq = _.filter(projects, function (o) { return o.idprogetto != opts.idprogetto && (o.tipoprogetto == 'ricerca' || o.tipoprogetto == 'didattica' || o.tipoprogetto == 'altro'); });

                if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5)
                    objFinEq = _.filter(projects, function (o) { return o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca'; });

                if (
                    opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                    opts.idtimesheettemplate === ETemplateType.MIMIT_2
                ) {
                    self.getRowText(sheet, rowIndex, "Altre attività non di pertinenza del progetto");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                }

                if (
                    opts.idtimesheettemplate === ETemplateType.PON ||
                    opts.idtimesheettemplate === ETemplateType.MISE
                ) {
                    self.getRowText(sheet, rowIndex, "Altri progetti finanziati");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                }

                _.forEach(objFinEq, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }
            else {
                
                let objFinEq = [];

                //2.2 B) template con gruppo stesso ente finanziatore e poi gruppo tutti gli altri -------------------------------------------------------------------
                //MASE, PNRR, PNRR_PF PNC NBFC_CNR
                if (opts.idtimesheettemplate === ETemplateType.MASE) {
                        self.getRowText(sheet, rowIndex, "Attività svolte su altri progetti finanziati con risorse UE (B)");
                        rowIndex += 1; // righe aggiunte per wp + 1 del prog

                        objFinEq = _.filter(projects, function (o) {
                            return o.iseu == 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                        });

                    } else {
                    //2.2 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    objFinEq = _.filter(projects, function (o) {
                        return o.ismur == 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                    });

                }

                _.forEach(objFinEq, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                let objFinNeq = [];

                if (opts.idtimesheettemplate === ETemplateType.MASE) {
                    self.getRowText(sheet, rowIndex, "Attività svolte su progetti finanziati con altre risorse (C)");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                } else {
                    //2.3 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI:");
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                }
                objFinNeq = _.filter(projects, function (o) {
                    return o.ismur != 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                });

                _.forEach(objFinNeq, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                if (opts.idtimesheettemplate === ETemplateType.PNRR_PF) {

                    //progetto fittizio progetti idprogetto_otherresearchactivities  "Altri progetti di ricerca"
                    let objFittRes = _.filter(projects, function (o) {
                        return o.tipoprogetto == 'fittizio ricerca'
                    });
                    _.forEach(objFittRes, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    self.getRowText(sheet, rowIndex, "");
                    rowIndex += 1;

                    //"Altre attività"
                    let objOther = _.filter(projects, function (o) {
                        return o.tipoprogetto == 'altro'
                    });
                    _.forEach(objOther, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    //"Attività di didattica"
                    let objDida = _.filter(projects, function (o) {
                        return o.tipoprogetto == 'didattica'
                    });
                    _.forEach(objDida, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });

                    self.getRowText(sheet, rowIndex, "");
                    rowIndex += 1;

                    //porgetto fittizio altre attività idprogetto_otheractivities "Ulteriori attività"
                    let objFittOther = _.filter(projects, function (o) {
                        return o.tipoprogetto == 'fittizio altro'
                    });
                    _.forEach(objFittOther, function (el) {
                        var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                        rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                    });
                }
                else {

                    if (opts.idtimesheettemplate === ETemplateType.MASE) {
                        //MASE  - Attività ordinaria (D)
                        let objOther = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'altro' || o.tipoprogetto == 'didattica';
                        });
                        _.forEach(objOther, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });
                    } else {
                        //PNRR e PNC

                        //"Altre attività"
                        let objOther = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'altro';
                        });
                        _.forEach(objOther, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });

                        //"Attività di didattica"
                        let objDida = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'didattica';
                        });
                        _.forEach(objDida, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });
                    }

                }

            }

            //MALATTIE FERIE PERMESSI -----------------------------------------------------------------------------------------------------------

            if (
                opts.idtimesheettemplate === ETemplateType.PNRR ||
                opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT ||
                opts.idtimesheettemplate === ETemplateType.MALATTIE_RARE
            ) {
                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia' || o.tipoprogetto == 'ferie' || o.tipoprogetto == 'permessi'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.MASE) {
                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia' || o.tipoprogetto == 'ferie' || o.tipoprogetto == 'permessi'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                //faccio in modo che in questo primo totale ci sia il totale reale calcolato su ricerca insegnamento e attività ordinaria
                opts.showOtherActivitiesrow = false;

                //visualizza il totale mensile
                this.addLastRowWithTotalActivitiesMonth(sheet, rowIndex, dtInput, opts);
                rowIndex += 1;

                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                let objFerie = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'ferie'
                });
                _.forEach(objFerie, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
                let objPermessi = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'permessi'
                });
                _.forEach(objPermessi, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                self.getRowText(sheet, rowIndex, "Altre assenze");
                rowIndex += 1;
            }

            if (
                opts.idtimesheettemplate === ETemplateType.MISE ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND
            ) {
                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                let objFerie = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'ferie'
                });
                _.forEach(objFerie, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
                let objPermessi = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'permessi'
                });
                _.forEach(objPermessi, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.FSC_MS) {
                let objFerie = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'ferie'
                });
                _.forEach(objFerie, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
                let objPermessi = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'permessi'
                });
                _.forEach(objPermessi, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheetYear(sheet, rowIndex, el.progetto, el, dtInput, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }



            //RIGHE ATTIVABILI CON OPZIONI + TOTALE + PIEDIPAGINA-----------------------------------------------------------------------------------------------------

            if (opts.showOtherActivitiesrow) {
                this.addRowOtherActivitiesMonth(sheet, rowIndex, dtInput, opts);
                rowIndex++;
            }

            if (opts.showactivitiesrow) {
                this.addLastRowWithTotalActivitiesMonth(sheet, rowIndex, dtInput, opts);
                rowIndex++;
            }

            this.addLastRowWithTotalMonth(sheet, rowIndex, dtInput, opts.year, opts);

            //il piè di pagina
            if (
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA ||
                opts.idtimesheettemplate === ETemplateType.PATTO_TERR
            ) {
                rowIndex += this.buildPiedipagina(sheet, opts, dtInput, 16, rowIndex, null);
            }

            this.addBorder(sheet, rowIndex + 1, 17, false);

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
                if (this.logoOverride) {

                    var topLeftCell;
                    var bottomRightCell;

                    if (opts.idtimesheettemplate == ETemplateType.HORIZON ||
                        opts.idtimesheettemplate == ETemplateType.HORIZON_Y ||
                        opts.idtimesheettemplate == ETemplateType.HORIZON_ERANET_COFUND
                    ) {

                        topLeftCell = "B2";
                        bottomRightCell = "Q6";

                    } else {

                        topLeftCell = isYear ? this.logoOverride.area.year.topLeft.cellString : this.logoOverride.area.month.topLeft.cellString;
                        bottomRightCell = isYear ? this.logoOverride.area.year.bottomRight_cellString : this.logoOverride.area.month.bottomRight_cellString;
                    };

                    var imageShapeT = new $.ig.excel.WorksheetImage(this.logoOverride.imageBase64);
                    imageShapeT.topLeftCornerCell(sheet.getCell(topLeftCell));
                    imageShapeT.bottomRightCornerCell(sheet.getCell(bottomRightCell));
                    sheet.shapes().add(imageShapeT);

                    return;
                }

                //logo ateneo
                if (
                    opts.idtimesheettemplate != ETemplateType.PATTO_TERR //logo ateneo già presente nel logo del template
                ) { 
                    if (appMeta.logoBase64) {
                        var imageShape = new $.ig.excel.WorksheetImage(appMeta.logoBase64);
                        if (isYear) {
                            imageShape.topLeftCornerCell(sheet.getCell(this.timesheetLogoCellTLYear));
                            imageShape.bottomRightCornerCell(sheet.getCell(this.timesheetLogoCellBRYear));
                        } else {
                            imageShape.topLeftCornerCell(sheet.getCell(this.timesheetLogoCellTL));
                            imageShape.bottomRightCornerCell(sheet.getCell(this.timesheetLogoCellBR));
                        }
                        sheet.shapes().add(imageShape);
                    }
                }

                //logo template progetto
                if (this.logoTemplate) {
                    var imageShapeT = new $.ig.excel.WorksheetImage(this.logoTemplate);
                    imageShapeT.topLeftCornerCell(sheet.getCell(this.logoTemplateTopLeft));
                    imageShapeT.bottomRightCornerCell(sheet.getCell(this.logoTemplateBottomRigth));
                    sheet.shapes().add(imageShapeT);
                }

                //logo progetto
                if (
                    opts.idtimesheettemplate != ETemplateType.PATTO_TERR //logo ateneo già presente nel logo del template
                ) {
                    if (this.logoProgetto) {
                        var imageShapeP = new $.ig.excel.WorksheetImage(this.logoProgetto);
                        if (isYear) {
                            imageShapeP.topLeftCornerCell(sheet.getCell(this.topLeftLogoProgettoYear));
                            imageShapeP.bottomRightCornerCell(sheet.getCell(this.bottomRigthLogoProgettoYear));
                        } else {
                            imageShapeP.topLeftCornerCell(sheet.getCell(this.topLeftLogoProgetto));
                            imageShapeP.bottomRightCornerCell(sheet.getCell(this.bottomRigthLogoProgetto));
                        }
                        sheet.shapes().add(imageShapeP);
                    }
                }
            } catch (e) {

                if (this.verbose)
                    console.log("Errore aggiungendo i loghi alla pagina. Metodo addSheetLogo() ");

            }
        },

        getBottomRightCornerCell: function (imageBase64, startCellYear, startCell, maxHeightInCells, cellHeight = 20, cellWidth = 64) {

            var def = appMeta.Deferred("getBottomRightCornerCell");
            let self = this;
            // Crea un elemento immagine per ottenere le dimensioni dell'immagine
            var img = new Image();

            img.onload = function () {
                let originalWidth = img.width;
                let originalHeight = img.height;

                // Calcola l'aspect ratio
                let aspectRatio = originalWidth / originalHeight;

                // Limita l'altezza dell'immagine in base al numero massimo di celle in altezza
                let heightInCells = Math.min(originalHeight / cellHeight, maxHeightInCells);
                let widthInCells = (heightInCells * aspectRatio * cellHeight) / cellWidth;

                // Definisci la cella di fine in base alle dimensioni calcolate
                let indexesYear = self.cellStringToIndices(startCellYear);
                let endCellRowYear = indexesYear.rowIndex + Math.ceil(heightInCells);
                let endCellColumnYear = indexesYear.columnIndex + Math.ceil(widthInCells);
                let cellYear = self.indicesToCellString(endCellRowYear, endCellColumnYear);

                // Definisci la cella di fine in base alle dimensioni calcolate
                let indexes = self.cellStringToIndices(startCell);
                let endCellRow = indexes.rowIndex + Math.ceil(heightInCells);
                let endCellColumn = indexes.columnIndex + Math.ceil(widthInCells);
                let cell = self.indicesToCellString(endCellRow, endCellColumn);

                // Restituisci l'oggetto con la riga e la colonna di fine
                def.resolve({ cellYear, cell });
            };

            img.onerror = function () {

                if (this.verbose)
                    console.log("Errore nel ridimensionamento del logo di ateneo");

                //lascio tutto com'è
                cellYear = self.timesheetLogoCellBRYear;
                cell = self.timesheetLogoCellBR;
                def.resolve({ cellYear, cell });

                //def.reject(new Error('Errore nel caricamento dell\'immagine.'));
            };

            // Imposta la sorgente dell'immagine con la stringa base64
            img.src = imageBase64;
            //img.src = 'data:image/png;base64,' + imageBase64.split(',')[1];

            return def.promise();
        },

        getBottomRightCornerCellModified: function (
            imageBase64,
            startCellYear,
            startCell,
            maxHeightInCells,
            maxWidthInCells,  // New parameter for maximum allowed width in cells
            cellHeight = 20,
            cellWidth = 64
        ) {
            var def = appMeta.Deferred("getBottomRightCornerCell");
            let self = this;

            var img = new Image();

            img.onload = function () {
                let originalWidth = img.width;
                let originalHeight = img.height;

                // Natural dimensions in cells (if there were no limits)
                let naturalHeightInCells = originalHeight / cellHeight;
                let naturalWidthInCells = originalWidth / cellWidth;

                // Determine the scaling needed so that neither the height nor the width exceed limits.
                // The scale factor is the fraction by which we must shrink the image.
                let scaleFromHeight = maxHeightInCells / naturalHeightInCells;
                let scaleFromWidth = maxWidthInCells / naturalWidthInCells;
                let scaleFactor = Math.min(scaleFromHeight, scaleFromWidth, 1); // never scale up

                // Determine final dimensions (in cells) by applying the scale factor.
                let scaledHeightInCells = naturalHeightInCells * scaleFactor;
                let scaledWidthInCells = naturalWidthInCells * scaleFactor;

                // Calculate bottom right cell based on startCellYear
                let indexesYear = self.cellStringToIndices(startCellYear);
                let endCellRowYear = indexesYear.rowIndex + Math.ceil(scaledHeightInCells);
                let endCellColumnYear = indexesYear.columnIndex + Math.ceil(scaledWidthInCells);
                let cellYear = self.indicesToCellString(endCellRowYear, endCellColumnYear);

                // Calculate bottom right cell based on startCell
                let indexes = self.cellStringToIndices(startCell);
                let endCellRow = indexes.rowIndex + Math.ceil(scaledHeightInCells);
                let endCellColumn = indexes.columnIndex + Math.ceil(scaledWidthInCells);
                let cellMonth = self.indicesToCellString(endCellRow, endCellColumn);


                def.resolve({ cellYear: cellYear, cellMonth: cellMonth });
            };

            img.onerror = function () {

                if (this.verbose)
                    console.log("Errore nel ridimensionamento del logo di ateneo");

                // Fall back to default cells if there's an error
                let cellYear = self.timesheetLogoCellBRYear;
                let cell = self.timesheetLogoCellBR;
                def.resolve({ cellYear, cell });


            };

            // Set the image source with the base64-encoded string  
            img.src = imageBase64;


            return def.promise();
        },


        cellStringToIndices: function (cellString) {
            // Estrai le lettere della colonna e il numero della riga dalla stringa
            let match = cellString.match(/^([A-Z]+)(\d+)$/);
            if (!match) throw new Error('Formato di cella non valido');

            let columnLetters = match[1];
            let rowIndex = parseInt(match[2], 10) - 1;

            // Converti le lettere della colonna in indice di colonna (0-based)
            let columnIndex = 0;
            for (let i = 0; i < columnLetters.length; i++) {
                columnIndex *= 26;
                columnIndex += (columnLetters.charCodeAt(i) - 'A'.charCodeAt(0) + 1);
            }
            columnIndex -= 1;

            return { rowIndex, columnIndex };
        },

        indicesToCellString: function (rowIndex, columnIndex) {
            // Converti l'indice di colonna (0-based) in lettere della colonna
            let columnLetters = '';
            columnIndex += 1; // Converti da 0-based a 1-based
            while (columnIndex > 0) {
                let remainder = (columnIndex - 1) % 26;
                columnLetters = String.fromCharCode('A'.charCodeAt(0) + remainder) + columnLetters;
                columnIndex = Math.floor((columnIndex - 1) / 26);
            }

            // Converti l'indice di riga (0-based) in numero di riga (1-based)
            let rowIndexString = (rowIndex + 1).toString();

            return columnLetters + rowIndexString;
        },

        getMaxHourPerDay: function (date) {
            var role = localResource.schedulerNoRoleDefined;
            var maxHoursPerDay = this.maxHoursPerDay;

            //se non ci sono max ore per giorno assegno 0
            if (!maxHoursPerDay) maxHoursPerDay = 0;

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
         * @description SYNC RIEPILOGO ANNO
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
                posY(rowIndex), posX(0) + this.offsetXYear,
                posY(rowIndex), posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.value(this.lang == 'it' ? "Ore totali" : "Total hours");

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                mergedCellProgName.value("Totale ore lavorative");
            }

            var xlRow = sheet.rows(rowIndex + this.offsetY);
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
                        }
                    }

                    if (maxHoursPerDayRole.role == 'Consolidamenti') {
                        //se ha sforato oppure non saturato il consolidamento...
                        if (tot != maxHours) {
                            //...la coloro di rosso
                            isRed = true;
                            //... metto il totale di quanto consolidato 
                            tot = maxHours;
                        }
                    }

                    //La vista in caso di utilizzo di timbrature restituisce questi ruoli speciali in caso di assenza
                    if (maxHoursPerDayRole.role == 'Consolidamento assente' || maxHoursPerDayRole.role == 'Timbratura assente') {
                        //...la coloro di rosso
                        isRed = true;
                        //... lascio il totale di quanto rendicontato 
                    }

                    totalMonth += tot;
                }
                globalTot += totalMonth;
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(totalMonth));
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_ERRORE : this.COLOR_ROW_TOTAL));
            }

            // totale globale
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, this.toTimeString(globalTot));
        },

        toTimeString: function (num) { return Math.floor(num) + (num % 1 ? `:${String(Math.round((num % 1) * 60)).padStart(2, '0')}` : '') },

        /**
         * @method addLastRowWithTotalActivitiesMonth
         * @private
         * @description SYNC
         * @param sheet
         * @param rowIndex
         * @param dtInput
         */
        addLastRowWithTotalActivitiesMonth: function (sheet, rowIndex, dtInput, opts) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0) + this.offsetXYear,
                posY(rowIndex), posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);

            mergedCellProgName.value(this.lang == 'it' ? "Ore totali in attività di ricerca" : "Total research activities hours");
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                mergedCellProgName.value("Totale ore produttive");
                mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            }

            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(
                    _.sumBy(_.filter(dtInput.rows,
                        function (o) {
                            return o.mese == counterMonth && (o.tipoprogetto == 'ricerca' || o.tipoprogetto == 'fittizio ricerca');
                        }
                        //{ mese: counterMonth }
                    ), 'ore')));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));

                if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                    sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
                }
           }

            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows,
                function (o) {
                    return (o.tipoprogetto == 'ricerca' || o.tipoprogetto == 'fittizio ricerca');
                }
            ), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, this.toTimeString(total));
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            }

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
        addRowOtherActivitiesMonth: function (sheet, rowIndex, dtInput, opts) {
            // 1. aggiungo riga per "Other activities"
            // calcolata per giorno come differenza riseptto ad un numero fisso di 8ore
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0) + this.offsetXYear,
                posY(rowIndex), posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().font().bold(true);
            if (this.lang == 'it') {
                if (opts.collapseteachingother)
                    mergedCellProgName.value('Attività ordinaria');
                else
                    mergedCellProgName.value('Altre attività');
            }
            else {
                if (opts.collapseteachingother)
                    mergedCellProgName.value("Institutional activities");
                else
                    mergedCellProgName.value("Other activities");
            }

            //se ho scelto il collasso di altre attività e insegnamento e contemporaneamente di mostrare le timbrature (altre attività fittizie) devo TOGLIERE le teachig acivities (che sono già incluse nella timbratura)
            //quindi levo le teaching activitties che avendole collassate ora si chiamano attività istituzionali
            let projectsRows = dtInput.rows;
            if (opts.collapseteachingother == true && opts.showOtherActivitiesrow == true) {
                projectsRows = _.filter(dtInput.rows, function (o) { return o.progetto != "Attività ordinaria" && o.progetto != "Institutional activities" });
            }

            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var totalYear = 0;
            // calcolo la somma per ogni messi stando attenti a non considerare sabato domenica e giorni di sospensione
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var isRed = false;
                var daysInMonth = this.getNumDaysInMonth(counterMonth, opts.year);
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                var totalMonth = 0;
                for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                    var d = new Date(opts.year, counterMonth - 1, counterDay);
                    //ore massime lavorabili
                    var maxHoursPerDayRole = this.getMaxHourPerDay(d);
                    var maxDayHour = this.isZeroOtherActivitiesDay(d) ? 0 : maxHoursPerDayRole.maxHoursPerDay;
                    var diff = maxDayHour - _.sumBy(_.filter(projectsRows, { giorno: counterDay, mese: counterMonth }), 'ore');
                    if (diff && diff < 0 && maxHoursPerDayRole.role == 'Timbrature') {
                        //se è una timbratura la segnalo in rosso e lascio il numero negativo
                        isRed = true;
                    }
                    //else {
                    //    //se se è sabato, domenica o interruzione
                    //    //if(this.isZeroOtherActivitiesDay(d)) {
                    //    diff = 0;
                    //}

                    //se è una Consolidamento e ho sforato (diff negativo) o non saturato (diff positivo)...
                    if (diff && diff != 0 && maxHoursPerDayRole.role == 'Consolidamenti') {
                        //...la segnalo in rosso e lascio il numero negativo
                        isRed = true;
                    }

                    //se è un massimale che viene dalla configurazione si può superare ...
                    if (diff && diff < 0 && maxHoursPerDayRole.role != 'Timbrature' && maxHoursPerDayRole.role != 'Consolidamenti') {
                        //... ma devo impostare le altre ore a zero (non possono essere negative)
                        diff = 0;
                    }

                    totalMonth += diff;
                }
                xlRow.setCellValue(dataCellIndex, this.toTimeString(totalMonth));
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_ERRORE : this.COLOR_ROW_PROG));
                totalYear += totalMonth;
            }

            // aggiungo cella per il totale
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, this.toTimeString(totalYear));
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
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
                posY(rowIndex) , posX(0) + this.offsetXYear,
                posY(rowIndex) , posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            //di base esce il nome del progetto ...
            mergedCellProgName.value(progettokey);

            //modifiche a tutte le righe dei progetti
            if ((
                opts.idtimesheettemplate === ETemplateType.PNRR ||
                opts.idtimesheettemplate === ETemplateType.PNRR_PF ||
                opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT ||
                opts.idtimesheettemplate === ETemplateType.PNC ||
                opts.idtimesheettemplate === ETemplateType.NBFC_CNR ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2
            )
                && progettoObj.tipoprogetto == 'ricerca'
            ) {
                if (progettoObj.cup)
                    mergedCellProgName.value(progettokey + '; CUP:' + progettoObj.cup + ';');
                else
                    mergedCellProgName.value(progettokey);
            }

            if (
                opts.idtimesheettemplate === ETemplateType.EMPIR
                && progettokey !== 'Institutional activities')
                mergedCellProgName.value("Hours worked on project " + progettokey);


            //modifica del rigo del progetto principale
            if (progettoObj.idprogetto == opts.idprogetto) {
                if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5)
                    mergedCellProgName.value("hp");

                if (opts.idtimesheettemplate === ETemplateType.FSC_MS)
                    mergedCellProgName.value("Attività sul progetto");

                if (
                    opts.idtimesheettemplate === ETemplateType.MISE ||
                    opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                    opts.idtimesheettemplate === ETemplateType.MIMIT_2
                )
                    mergedCellProgName.value("Attività progetto");

                if (opts.idtimesheettemplate === ETemplateType.MASE)
                    mergedCellProgName.value("Attività svolta sul Progetto (A)");

            }

            //modifica della altre ore + ore di didattica 
            if (opts.idtimesheettemplate === ETemplateType.MASE) {
                if (progettoObj.tipoprogetto == 'altro' || progettoObj.tipoprogetto == 'didattica') {
                    mergedCellProgName.value("Attività ordinaria (D)");
                }
            }

            //traduzioni in italiano
            if (this.lang == 'it'
                && progettokey == 'Teaching activities') {
                mergedCellProgName.value('Attività di didattica');
            }
            if (this.lang == 'it'
                && progettokey == 'Other activities') {
                mergedCellProgName.value('Altre attività');
            }
            if (this.lang == 'it' &&
                progettokey == 'Other Research Activities') {
                mergedCellProgName.value('Altre attività di ricerca');
            }

            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(this.getDaySumProjectMonth(dtInput, progettokey, counterMonth)));
                sheet.rows(rowIndex + this.offsetY ).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY ).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            }

            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey }), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, this.toTimeString(total));
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            //se è stata indicata l'opzione di visualizzare i workpackage e non ho applicato il collasso su una riga sola del progetto corrente e sono righe di progetti reali (non fittizi)
            if (opts.withWorkpackage == true && progettokey != "Altri progetti finanziati" && progettoObj.tipoprogetto == 'ricerca' && progettoObj.idprogetto == opts.idprogetto) {
                // 2. scorro i workpackege del progetto e creo riga

                progettoObj.group = Object.keys(progettoObj.group)
                    .sort() // Ordina le chiavi in ordine alfabetico
                    .reduce((acc, key) => {
                        acc[key] = progettoObj.group[key];
                        return acc;
                    }, {});

                _.forOwn(progettoObj.group, function (el, wpkey) {
                    if (wpkey !== 'Teaching activities' && wpkey !== 'Other activities' && wpkey !== 'Other Research Activities') {
                        if (opts.multilineType == true /*&& progettoObj.idprogetto == opts.idprogetto*/) {
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
            let offsetXYear = 0;
            if (!month) {
                offsetXYear = this.offsetXYear;
            }
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0) + offsetXYear,
                posY(rowIndex), posX(this.columnIndexMonth) + offsetXYear);
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            mergedCellProgName.value(text);
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            for (var counterMonth = 1; counterMonth <= (!month ? 13 : self.getNumDaysInMonth(month, self.opts.year) + 1) ; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + offsetXYear;
                xlRow.setCellValue(dataCellIndex, '');
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
                if (counterMonth == (!month ? 13 : self.getNumDaysInMonth(month, self.opts.year) + 1 ))
                    sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);

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
                case ETemplateType.HORIZON_Y:
                    this.buildFrontespizioHorizon(sheet, opts, dtInput, mese, true);
                    break;
                case ETemplateType.PON:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPON(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.HORIZON_ERANET_COFUND:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioHORIZON_ERANET_COFUND(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.MIMIT:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioMIMIT(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.MASE:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioMASE(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PNRR_AGE_IT:
                case ETemplateType.PNRR:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPNRR(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.NBFC_CNR:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioNBFC_CNR(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.FSC_MS_5:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioFSC_MS_5(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.FSC_MS_3:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioFSC_MS_3(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PATTO_TERR:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPATTO_TERR(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.FSC_MS:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioFSC_MS(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PNRR_PF:
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
                    this.buildFrontespizioMISE(sheet, opts, dtInput, maximumX, mese, this.logoOverride ? 9 : 1);
                    break;
                case ETemplateType.PORCAMPANIA_21_27:
                case ETemplateType.MIMIT_2:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioMISE(sheet, opts, dtInput, maximumX, mese, 9);
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
                case ETemplateType.MALATTIE_RARE:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioMALATTIE_RARE(sheet, opts, dtInput, maximumX, mese);
                    break;
                case ETemplateType.PSRCAMPANIA:
                    this.lang = 'it'
                    moment.locale(this.lang);
                    this.buildFrontespizioPSRCAMPANIA(sheet, opts, dtInput, maximumX, mese);
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
                        'title_prog_fin': principalProjectRows[0].title_prog_fin ? principalProjectRows[0].title_prog_fin : '',
                        'title_prog_fin_bando': principalProjectRows[0].title_prog_fin_bando ? principalProjectRows[0].title_prog_fin_bando : '',
                        'finanziamento': principalProjectRows[0].finanziamento ? principalProjectRows[0].finanziamento : '',
                        'istituto': principalProjectRows[0].istituto ? principalProjectRows[0].istituto : '',
                        'nome': principalProjectRows[0].nome ? principalProjectRows[0].nome : '',
                        'cognome': principalProjectRows[0].cognome ? principalProjectRows[0].cognome : '',
                        'extmatricula': principalProjectRows[0].extmatricula ? principalProjectRows[0].extmatricula : '',
                        'cf': principalProjectRows[0].cf ? principalProjectRows[0].cf : '',
                        'unitaorganizzativa': principalProjectRows[0].unitaorganizzativa ? principalProjectRows[0].unitaorganizzativa : '',
                        'start': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin),//principalProjectRows[0].start ? appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(principalProjectRows[0].start) : '',
                        'stop': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end),//principalProjectRows[0].stop ? appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(principalProjectRows[0].stop) : '',
                        'oredivisionecostostipendio': principalProjectRows[0].oredivisionecostostipendio ? principalProjectRows[0].oredivisionecostostipendio : 1500,
                    }
                }
            }

            if (self.dataPnrr == null) {
                if (opts.progettoprincipaleRow.length && opts.progettoMembroRow.length) {
                    self.dataPnrr = {
                        'cup': opts.progettoprincipaleRow[0].progetto_cup,
                        'codice': opts.progettoprincipaleRow[0].progetto_codiceidentificativo,
                        'denominazione': opts.progettoprincipaleRow[0].progetto_title,
                        'titolo': opts.progettoprincipaleRow[0].titolobreve,
                        'enteFinanziatore': opts.progettoprincipaleRow[0].progetto_finanziatoretxt,
                        'title_prog_fin': opts.progettoprincipaleRow[0].progetto_progfinanziamentotxt,
                        'title_prog_fin_bando': opts.progettoprincipaleRow[0].progetto_bandoriferimentotxt,
                        'unitaorganizzativa': opts.progettoprincipaleRow[0].progetto_unitaorganizzativa,
                        'finanziamento': '',
                        'istituto': opts.progettoprincipaleRow[0].registryaziende_title,
                        'nome': opts.progettoMembroRow[0].getregistrydocentiamministrativiprj_forename,
                        'cognome': opts.progettoMembroRow[0].surname,
                        'extmatricula': opts.progettoMembroRow[0].getregistrydocentiamministrativiprj_extmatricula,
                        'cf': opts.progettoMembroRow[0].getregistrydocentiamministrativiprj_cf,
                        'start': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin),
                        'stop': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end),
                        'oredivisionecostostipendio': 1500,
                    }

                } else { 
                    self.dataPnrr = {
                        'cup': '',
                        'codice': '',
                        'denominazione': '',
                        'titolo': '',
                        'enteFinanziatore': '',
                        'title_prog_fin': '',
                        'title_prog_fin_bando': '',
                        'unitaorganizzativa': '',
                        'finanziamento': '',
                        'istituto': '',
                        'nome': '',
                        'cognome': '',
                        'extmatricula': '',
                        'cf': '',
                        'start': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin),
                        'stop': appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end),
                        'oredivisionecostostipendio': 1500,
                    }
                }
            }

            //inizio e fine
            if (self.opts.mese) {
                begin = new Date(self.opts.year, self.opts.mese - 1, 1);
                self.dataPnrr.start = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin);
                end = new Date(self.opts.year, self.opts.mese - 1, self.getNumDaysInMonth(self.opts.mese, self.opts.year));
                self.dataPnrr.stop = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end);
            }

            self.dataPnrr.numerosal = '';
            if (self.opts.idsal) {
                let sal = appMeta.currApp.currentMetaPage.getDataTable('salelenchiview').select(q.eq('idsal', self.opts.idsal));
                if (sal.length) {
                    if (begin.getTime() < sal[0].sal_start.getTime())
                        begin = sal[0].sal_start;
                    self.dataPnrr.start = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(begin);
                    if (end.getTime() > sal[0].sal_stop.getTime())
                        end = sal[0].sal_stop;
                    self.dataPnrr.stop = appMeta.currApp.currentMetaPage.stringFromDate_ddmmyyyy(end);

                    self.dataPnrr.numerosal = sal[0].numerosal;
                }
            }

            //totale
            self.dataPnrr.tot = this.toTimeString(_.sumBy(
                _.filter(dtInput.rows, function (r) {
                    return r.progetto == self.dataPnrr.progetto && r.data >= begin && r.data <= end;
                })
                , 'ore'));

            //recupero il contratto al primo giorno del timesheet ---------------------------------------------------

            var contrattiCurr = _.orderBy(_.filter(self.contratto.rows, function (row) {
                return begin < (row.stop ? row.stop : new Date(2100, 0, 1))
                    && end > (row.start ? row.start : new Date(1900, 0, 1))
                    && row.idposition && row.active == 'S';
            }), 'start', 'asc');


            if (contrattiCurr.length) {

                var contrattoCurr = contrattiCurr[0];

                //se ho più contratti,e ho specificato il mese, prendo il secondo
                if (opts.mese && contrattiCurr.length > 1) {
                    contrattoCurr = contrattiCurr[1];
                }

                var contrattokindCurrs = self.contrattokind.select(q.eq('idposition', contrattoCurr.idposition));
                if (contrattokindCurrs.length) {
                    let contrattokindCurr = contrattokindCurrs[0];
                    var getTitle = function (idposition) {
                        var rows = self.contrattokind.select(q.eq('idposition', idposition));
                        if (rows.length) {
                            return rows[0].title;
                        }
                        return '';
                    };

                    if ((contrattoCurr.tempdef ? contrattoCurr.tempdef : 'N') == 'N') {
                        self.dataPnrr.oremax = contrattokindCurr.oremaxtempopieno;
                        self.dataPnrr.oremincompitidida = contrattokindCurr.oremincompitididatempopieno;
                    } else {
                        self.dataPnrr.oremax = contrattokindCurr.oremaxtempoparziale;
                        self.dataPnrr.oremincompitidida = contrattokindCurr.oremincompitididatempoparziale;
                    }

                    self.dataPnrr.figuraContrattualeEsatta = getTitle(contrattoCurr.idposition);
                    if (contrattokindCurr.tipopersonale == 'D' || contrattokindCurr.tipopersonale == 'R') {

                        //docente
                        self.dataPnrr.categoria = 'Docente'

                        self.dataPnrr.figuraContrattuale = 'Personale non contrattualizzato';
                        self.dataPnrr.livello = '';
                        if (contrattokindCurr.codeposition == '07_SW_PORD')
                            self.dataPnrr.livello = 'ALTO (Professore Ordinario)';
                        else if (contrattokindCurr.codeposition == '07_SW_PASC' || contrattoCurr.codeposition == '07_SW_PASN')
                            self.dataPnrr.livello = 'MEDIO (Professore Associato)';
                        else//if (contrattokindCurr.codeposition == '07_SW_RICN' || contrattoCurr.codeposition == '07_SW_RICC' || contrattoCurr.codeposition == 'RUT' || contrattoCurr.codeposition == 'ASS_RIC')
                            self.dataPnrr.livello = 'BASSO (Ricercatore)';

                        self.dataPnrr.classe = contrattoCurr.incomeclass
                        self.dataPnrr.scatto = contrattoCurr.livello
                        self.dataPnrr.fullTime = (contrattoCurr.tempdef ? contrattoCurr.tempdef : 'N') == 'N' ? 'Full-Time' : 'Part-Time'
                    } else {

                        //pta
                        self.dataPnrr.categoria = 'Impiegato'

                        self.dataPnrr.figuraContrattuale = getTitle(contrattoCurr.idposition);
                        self.dataPnrr.livello = '';
                        self.dataPnrr.classe = 0
                        self.dataPnrr.scatto = contrattoCurr.livello
                        self.dataPnrr.fullTime = (contrattoCurr.partime ? contrattoCurr.partime : 100) == 100 ? 'Full-Time' : 'Part-Time'


                    }
                }
            }
        },

        /**
        * retrieve required data according to the template
        * @returns {*}
        */
        initRequiredData: function (opts) {

            self = this;

            var def = appMeta.Deferred("initRequiredData");

            const dataRetriever = dataRetrievers[opts.idtimesheettemplate];

            if (dataRetriever) {

                dataRetriever(self)
                    .then((data) => {

                        if (data) {

                            self.requiredData = data;
                        };

                        def.resolve("initRequiredData");
                    });

            } else {

                return def.resolve(`No retriever defined for "${opts.idtimesheettemplate}"`);
            }

            return def.promise();
        },

        /**
        * retrieve timesheet signature labels from the DB
        * @returns {*}
        */
        initSignatureLabels: function (opts) {

            self = this;

            var def = appMeta.Deferred("initSignatureLabels");

            appMeta.getData.runSelect('timesheettemplate', '*', q.eq("idtimesheettemplate", opts.idtimesheettemplate), null)

                .then(results => {
 
                    if (results.rows.length) {

                        self.signatureLabels = {
                            left: results.rows[0].leftsignaturelabel || "",
                            middle: results.rows[0].middlesignaturelabel || "",
                            right: results.rows[0].rightsignaturelabel || "",
                        };
                    }

                    def.resolve("initSignatureLabels");
                })
                .fail(() => {

                    self.signatureLabels = {
                        left: "",
                        middle: "",
                        right: "",
                    };

                    appMeta.logger.log(appMeta.logger.logType.ERROR, `No configuration found for '${opts.idtimesheettemplate}', using empty defaults for labels`);

                    def.resolve("initSignatureLabels");
                })

            return def.promise();
        },


        //----------------------------FRONTESPIZIO HORIZON --------------------------------------
        buildFrontespizioHorizon: function (sheet, opts, dtInput, month, isYellow) {
            let self = this;
            var year = opts.year;
            var secondHeaderColX = 3;
            this.initialY = 5;

            let posXLabelLeft = this.offsetX + this.offsetXYear;
            let posXLabelRight = posXLabelLeft + (month ? 7 : 6);
            let posXContentRight = posXLabelRight + (month ? 4 : 2);
            let lenContentRight = (month ? 8 : 3);

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
            var xlRowTitleProj = sheet.rows(this.initialY);
            xlRowTitleProj.setCellValue(posXLabelLeft, 'Title of the action (acronym)');
            applyStyleLabelLeft(xlRowTitleProj.cells(posXLabelLeft));
            xlRowTitleProj.cells(posXLabelLeft).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft + 1,
                this.initialY, posXLabelLeft + 4
            );
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.progetto);


            this.initialY++;//-----------------------------------------

            //beneficiario
            let cell = sheet.rows(this.initialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('Full name of beneficiary');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft + 1,
                this.initialY, posXLabelLeft + 4
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.istituto);

            //Ruolo
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelRight,
                this.initialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value('Ruolo/Qualifica');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXContentRight +1,
                this.initialY, posXContentRight + lenContentRight
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value(self.dataPnrr.figuraContrattualeEsatta);

            this.initialY++;//-----------------------------------------

            //impiegato
            cell = sheet.rows(this.initialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('Full name employee');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft + 1,
                this.initialY, posXLabelLeft + 4
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            // CLASSE
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelRight,
                this.initialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.value('Classe');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXContentRight + 1,
                this.initialY, posXContentRight + lenContentRight
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(self.dataPnrr.classe);

            this.initialY++; //-----------------------------------------

            //capo dipartimento
            cell = sheet.rows(this.initialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('Head of Dept.');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft + 1,
                this.initialY, posXLabelLeft + 4
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.value(this.getHeadOfDept());

            // scatto
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelRight,
                this.initialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.value('Scatto');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXContentRight + 1,
                this.initialY, posXContentRight + lenContentRight
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(self.dataPnrr.scatto);


            this.initialY++; //-----------------------------------------

            //anno
            cell = sheet.rows(this.initialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.value('year');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft + 1,
                this.initialY, posXLabelLeft + 4
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(year);

            // Full/part-time
            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelRight,
                this.initialY, posXContentRight
            );
            applyStyleLabelLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value('Full/part-time');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXContentRight + 1,
                this.initialY, posXContentRight + lenContentRight
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.value(self.dataPnrr.fullTime);

            this.initialY++;  //-----------------------------------------

            //ore lavorate 
            cell = sheet.rows(this.initialY).cells(posXLabelLeft);
            applyStyleLabelLeft(cell);
            cell.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            cell.value(this.lang == 'it' ? "Ore totali lavorate" : 'Total worked hours');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft + 1,
                this.initialY, posXLabelLeft + 4
            );
            applyStylecontentlLeft(mergedCellRegion);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(this.toTimeString(this.getTotalWorkedHours(dtInput, year, opts, month)));


            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = this.initialY;

            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
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

        getHeadOfDept: function () {
            // TODO
            return '';
        },

        //---------------------------------FRONTESPIZIO HORIZON_ERANET_COFUND-----------------------------------------------

        buildFrontespizioHORIZON_ERANET_COFUND: function (sheet, opts, dtInput, maximumX, month) {
            this.columnIndexMonth = 2;
            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);

            this.initialY = 6;

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("TIME SHEET PRESENZE DEL PERSONALE DIPENDENTE");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, 3
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Periodo dal " + this.dataPnrr.start + " al " + this.dataPnrr.stop);

            //sal
            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, 4,
                2 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("SAL n. " + this.dataPnrr.numerosal);

            this.addOraKind(sheet, opts, maximumX, 'Ricerca Fondamentale', 1, 4 + this.initialY, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Ricerca Industriale', (month ? 9 : 5), 4 + this.initialY, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Sviluppo Sperimentale', (month ? 17 : 9), 4 + this.initialY, month, dtInput);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Nominativo: " + this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posX(0),
                7 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Contratto applicato: " + this.dataPnrr.figuraContrattuale);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posX(0),
                8 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Livello: " + this.dataPnrr.livello);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posX(0),
                9 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Monte ore lavorative annuo previsto: " + this.dataPnrr.oredivisionecostostipendio);

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 9 + this.initialY;

            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO PON-----------------------------------------------

        buildFrontespizioPON: function (sheet, opts, dtInput, maximumX, month) {
            this.addProgetto(sheet, opts, maximumX, 9, "#89e9fa");
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
        addProgetto: function (sheet, opts, maximumX, initialY, color) {

            let applyRegionStyle = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().fill($.ig.excel.CellFill.createSolidFill(color));
                region.cellFormat().font().bold(true);
            };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.initialY = initialY;
            //let maximumX = 14;

            let mergedCellRegion = sheet.mergedCellsRegions().add( // Codice progetto
                0 + this.initialY, posX(0),
                0 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("Codice progetto: " + this.dataPnrr.codice);

            mergedCellRegion = sheet.mergedCellsRegions().add( // CUP
                0 + this.initialY, Math.round(maximumX / 2) + 1,
                0 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("CUP: " + this.dataPnrr.cup);

            mergedCellRegion = sheet.mergedCellsRegions().add( // Denominazione Soggetto
                1 + this.initialY, posX(0),
                1 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.value("Denominazione Soggetto: " + this.dataPnrr.istituto);

            mergedCellRegion = sheet.mergedCellsRegions().add( // Titolo del progetto
                2 + this.initialY, posX(0),
                2 + this.initialY, maximumX
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

            this.initialY = 13;

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("FIGURA PROFESSIONALE");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posX(0),
                1 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Nominativo: " + this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, Math.round(maximumX / 2) + 1,
                1 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("CF: " + this.dataPnrr.cf);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Contratto applicato: " + this.dataPnrr.figuraContrattuale);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posX(0),
                3 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Livello: " + this.dataPnrr.livello);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Monte ore lavorative annuo previsto: " + this.dataPnrr.oredivisionecostostipendio);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, Math.round(maximumX / 2) + 1,
                4 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO: " + this.dataPnrr.tot);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Periodo dal " + this.dataPnrr.start + " al " + this.dataPnrr.stop);

            this.addOraKind(sheet, opts, maximumX, 'Ricerca Industriale', 1, 8 + this.initialY, month, dtInput);
            this.addOraKind(sheet, opts, maximumX, 'Sviluppo Sperimentale', Math.round(maximumX / 2) + 1, 8 + this.initialY, month, dtInput);


        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        8 + this.initialY, posX(0),
        //        8 + this.initialY, Math.round(maximumX / 2)
        //    );
        //    mergedCellRegion.cellFormat().font().bold(true);
        //    mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
        //    mergedCellRegion.value("Ricerca [  ]");


        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        8 + this.initialY, Math.round(maximumX / 2) + 1,
        //        8 + this.initialY, maximumX
        //    );
        //    mergedCellRegion.cellFormat().font().bold(true);
        //    mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
        //    mergedCellRegion.value("Sviluppo Sperimentale [  ]");

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 8 + this.initialY;

            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO MIMIT-----------------------------------------------

        buildFrontespizioMIMIT: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyle = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().font().bold(true);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
           };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.initialY = 9;

            // CUP

            let mergedCellRegion = sheet.mergedCellsRegions().add( 
                0 + this.initialY, posX(0),
                0 + this.initialY, posX(0) +2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#b8cce4"));//azzurrino intenso
            mergedCellRegion.value("CUP" );

            mergedCellRegion = sheet.mergedCellsRegions().add( 
                0 + this.initialY, posX(0) + 3,
                0 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));//azzurrino
            mergedCellRegion.value(this.dataPnrr.cup);

            // Soggetto proponente

            mergedCellRegion = sheet.mergedCellsRegions().add( 
                1 + this.initialY, posX(0),
                1 + this.initialY, posX(0) + 2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#b8cce4"));//azzurrino intenso
            mergedCellRegion.value("Soggetto Proponente: " );

            mergedCellRegion = sheet.mergedCellsRegions().add( 
                1 + this.initialY, posX(0) + 3,
                1 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));//azzurrino
            mergedCellRegion.value(this.dataPnrr.istituto);

            // Titolo del progetto

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, posX(0) + 2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#b8cce4"));//azzurrino intenso
            mergedCellRegion.value("Titolo del progetto: ");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0) + 3,
                2 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));//azzurrino
            mergedCellRegion.value(this.dataPnrr.titolo);

            //sal

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, posX(0) + 2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#b8cce4"));//azzurrino intenso
            mergedCellRegion.value("SAL n. ");
            
            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0) + 3,
                4 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));//azzurrino
            mergedCellRegion.value(this.dataPnrr.numerosal);

            //nominativo

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, posX(0) + 2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#b8cce4"));//azzurrino intenso
            mergedCellRegion.value("Nominativo ");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0) + 3,
                6 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));//azzurrino
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            //anno

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posX(0),
                7 + this.initialY, posX(0) + 2
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#b8cce4"));//azzurrino intenso
            mergedCellRegion.value("Anno ");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posX(0) + 3,
                7 + this.initialY, Math.round(maximumX / 2)
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill("#DCE6F1"));//azzurrino
            mergedCellRegion.value(this.opts.year);

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 9 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
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

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 10 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO MISE-----------------------------------------------

        //buildFrontespizioMISE: function (sheet, opts, dtInput, maximumX, month, initialY) {

        //    let applyRegionStyle = function (region) {
        //        region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
        //        region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
        //        region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
        //        region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
        //        region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
        //    };

        //    let posX = this.posX.bind(this);
        //    this.initialY = initialY;
        //    let posXLabelLeft = posX(0);
        //    let posXContentLeft = posX(0) + 3;
        //    let posXContentRight = (month ? 20 : 12);

        //    // SCHEDA DI REGISTRAZIONE DELLE PRESENZE – PERSONALE DIPENDENTE
        //    let mergedCellRegion = sheet.mergedCellsRegions().add(
        //        0 + this.initialY, posXLabelLeft,
        //        0 + this.initialY, posXContentRight
        //    );
        //    //applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.cellFormat().font().bold(true);
        //    mergedCellRegion.value('SCHEDA DI REGISTRAZIONE DELLE PRESENZE – PERSONALE DIPENDENTE');

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        1 + this.initialY, posXLabelLeft,
        //        1 + this.initialY, posXContentLeft - 1
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value('Ore lavorate');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        1 + this.initialY, posXContentLeft,
        //        1 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value('Dal:' + this.dataPnrr.start + ' al:' + this.dataPnrr.stop);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        2 + this.initialY, posXLabelLeft,
        //        2 + this.initialY, posXContentLeft - 1
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value('Per l\'esecuzione del progetto n.');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        2 + this.initialY, posXContentLeft,
        //        2 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.codice + ' CUP:' + this.dataPnrr.cup);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        3 + this.initialY, posXLabelLeft,
        //        3 + this.initialY, posXContentLeft - 1
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value('Decreto');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        3 + this.initialY, posXContentLeft,
        //        3 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.finanziamento ? this.dataPnrr.finanziamento : 'n.             del:');

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        5 + this.initialY, posXLabelLeft,
        //        5 + this.initialY, posXContentLeft
        //    );
        //    mergedCellRegion.value('Periodo dal ' + this.dataPnrr.start + ' al ' + this.dataPnrr.stop);

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        5 + this.initialY, posXContentLeft + 1,
        //        5 + this.initialY, posXContentLeft + 2
        //    );
        //    mergedCellRegion.value('SAL n. ');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        5 + this.initialY, posXContentLeft + 3,
        //        5 + this.initialY, posXContentLeft + 3
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.numerosal);

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        5 + this.initialY, posXContentLeft + 5,
        //        5 + this.initialY, posXContentLeft + (month ? 8 : 7)
        //    );
        //    mergedCellRegion.value('ANNO SOLARE:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        5 + this.initialY, posXContentLeft + (month ? 9 : 8),
        //        5 + this.initialY, posXContentLeft + (month ? 10 : 8)
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.opts.year);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        7 + this.initialY, posXLabelLeft,
        //        7 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Ricerca e Sviluppo:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        7 + this.initialY, posXContentLeft,
        //        7 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);

        //    const tipiOre = dtInput.rows.filter(r => r.idprogetto == opts.idprogetto).reduce((acc, { tipo, ore }) => {
        //        acc[tipo] = (acc[tipo] || 0) + ore;
        //        return acc;
        //    }, {});

        //    const tipoWithMostOre = Object.entries(tipiOre).reduce((max, [tipo, ore]) => {
        //        return ore > max.ore ? { tipo, ore } : max;
        //    }, { tipo: null, ore: -Infinity });

        //    mergedCellRegion.value(tipoWithMostOre.tipo);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        9 + this.initialY, posXLabelLeft,
        //        9 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Nominativo:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        9 + this.initialY, posXContentLeft,
        //        9 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        11 + this.initialY, posXLabelLeft,
        //        11 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Categoria dipendente:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        11 + this.initialY, posXContentLeft,
        //        11 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.categoria);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        13 + this.initialY, posXLabelLeft,
        //        13 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Livello dipendente:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        13 + this.initialY, posXContentLeft,
        //        13 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.livello);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        15 + this.initialY, posXLabelLeft,
        //        15 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Contratto applicato:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        15 + this.initialY, posXContentLeft,
        //        15 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.figuraContrattuale);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        17 + this.initialY, posXLabelLeft,
        //        17 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Monte ore lavorative annuo previsto:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        17 + this.initialY, posXContentLeft,
        //        17 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio);

        //    // -------------------------------------------------

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        19 + this.initialY, posXLabelLeft,
        //        19 + this.initialY, posXContentLeft - 1
        //    );
        //    mergedCellRegion.value('Sede di svolgimento delle attività:');

        //    mergedCellRegion = sheet.mergedCellsRegions().add(
        //        19 + this.initialY, posXContentLeft,
        //        19 + this.initialY, posXContentRight
        //    );
        //    applyRegionStyle(mergedCellRegion);
        //    mergedCellRegion.value(opts.sede);

        //    //setto la riga di partenza del riquadro delle ore
        //    this.offsetYFrontespizio = 21 + this.initialY;
        //    if (this.isFirstFrontespizio) {
        //        this.offsetY += this.offsetYFrontespizio;
        //        this.isFirstFrontespizio = false;
        //    }
        //},

        buildFrontespizioMISE: function (sheet, opts, dtInput, maximumX, month, initialY) {
            let applyRegionStyle = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posX = this.posX.bind(this);
            this.initialY = initialY;
            let posXLabelLeft = posX(0);
            let posXContentLeft = posX(0) + 3;
            let posXContentRight = (month ? 20 : 12);
            let row = this.initialY;

            let mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentRight);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('SCHEDA DI REGISTRAZIONE DELLE PRESENZE – PERSONALE DIPENDENTE');
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Ore lavorate');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Dal:' + this.dataPnrr.start + ' al:' + this.dataPnrr.stop);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Per l\'esecuzione del progetto n.');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.codice + ' CUP:' + this.dataPnrr.cup);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Decreto');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.finanziamento ? this.dataPnrr.finanziamento : 'n.             del:');
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft);
            mergedCellRegion.value('Periodo dal ' + this.dataPnrr.start + ' al ' + this.dataPnrr.stop);

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft + 1, row, posXContentLeft + 2);
            mergedCellRegion.value('SAL n. ');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft + 3, row, posXContentLeft + 3);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.numerosal);

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft + 5, row, posXContentLeft + (month ? 8 : 7));
            mergedCellRegion.value('ANNO SOLARE:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft + (month ? 9 : 8), row, posXContentLeft + (month ? 10 : 8));
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Ricerca e Sviluppo:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            const tipiOre = dtInput.rows.filter(r => r.idprogetto == opts.idprogetto).reduce((acc, { tipo, ore }) => {
                acc[tipo] = (acc[tipo] || 0) + ore;
                return acc;
            }, {});
            const tipoWithMostOre = Object.entries(tipiOre).reduce((max, [tipo, ore]) => ore > max.ore ? { tipo, ore } : max, { tipo: null, ore: -Infinity });
            mergedCellRegion.value(tipoWithMostOre.tipo);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Nominativo:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Categoria dipendente:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.categoria);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Livello dipendente:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.livello);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Contratto applicato:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.figuraContrattuale);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Monte ore lavorative annuo previsto:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio);
            row++;

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXLabelLeft, row, posXContentLeft - 1);
            mergedCellRegion.value('Sede di svolgimento delle attività:');

            mergedCellRegion = sheet.mergedCellsRegions().add(row, posXContentLeft, row, posXContentRight);
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value(opts.sede);
            row++;

            this.offsetYFrontespizio = row;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
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

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 19 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO FSC_MS_5-----------------------------------------------

        buildFrontespizioFSC_MS_5: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyle = function (region, isLeft) {
                const left = isLeft === true
                    ? "SI"
                    : isLeft === false
                        ? "NO"
                        : "INDEFINITO";

                region.cellFormat().font().bold(true);
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                if (left == "NO" || left == "INDEFINITO") region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                if (left == "SI" || left == "INDEFINITO") region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            };

            let posX = this.posX.bind(this);
            this.initialY = 9;
            let posXLabelLeft = posX(0);
            let posXContentLeft = posX(0) + 3;
            let posXContentRight = maximumX;

            // -------------------------------------------------

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXLabelLeft,
                2 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('PIANO SVILUPPO E COESIONE SALUTE');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXLabelLeft,
                3 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('Traiettoria 5 “Nutraceutica, nutrigenomica e alimenti funzionali”');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXLabelLeft,
                5 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().font().italic(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('Time sheet mensile delle attività svolte da Personale dipendente');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXLabelLeft,
                7 + this.initialY, posXContentRight
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.value('Progetto: ' + this.dataPnrr.titolo);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                10 + this.initialY, posXLabelLeft,
                10 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().font().italic(true);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('Personale dipendente');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, posXLabelLeft,
                12 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion, true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Partner: ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, posXContentLeft,
                12 + this.initialY, maximumX - 5
            );
            applyRegionStyle(mergedCellRegion, false);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.dataPnrr.istituto);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, maximumX - 3,
                12 + this.initialY, maximumX - 2
            );
            applyRegionStyle(mergedCellRegion, true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Anno: ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, maximumX - 1,
                12 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion, false);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.opts.year);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                14 + this.initialY, posXLabelLeft,
                14 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Nominativo Personale dipendente (Cognome e Nome): ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                14 + this.initialY, posXContentLeft,
                14 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                16 + this.initialY, posXLabelLeft,
                16 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Rapporto di Lavoro (Dipendente/Consulente e inquadramento CCNL): ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                16 + this.initialY, posXContentLeft,
                16 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.dataPnrr.categoria + ' / ' + this.dataPnrr.figuraContrattualeEsatta);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                18 + this.initialY, posXLabelLeft,
                18 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('Dettaglio giornate lavorative: ');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                19 + this.initialY, posXLabelLeft,
                19 + this.initialY, maximumX
            );
            mergedCellRegion.value('Ore lavorate (hl) ciascun giorno (gg) e ore dedicate al Progetto (hp) ore dedicate ad altri progetti finanziati (hpp). Se necessario ampliare le righe in funzione del WP rendicontato. ');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                20 + this.initialY, posXLabelLeft,
                20 + this.initialY, maximumX
            );
            mergedCellRegion.value('(da compilare per i soli mesi in cui almeno un’ora lavorativa è stata dedicata al Progetto)');

            // -------------------------------------------------

            //setto la riga di partenza del riquadro delle ore 
            this.offsetYFrontespizio = 20 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO PATTO_TERR-----------------------------------------------

        buildFrontespizioPATTO_TERR: function (sheet, opts, dtInput, maximumX, month) {

            this.columnIndexMonth = 2;
            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);

            //inizio a riga 9
            this.initialY = 9;

            // intestazione
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posX(0),
                this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('Progetto "Patto territoriale per il Sistema Universitario Pugliese"');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posX(0),
                1 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('PATTO TERRITORIALE DELL\'ALTA FORMAZIONE PER LE IMPRESE');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('AI SENSI DELL’ARTICOLO 14 – BIS DEL DECRETO-LEGGE 6 NOVEMBRE 2021, N. 152');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posX(0),
                3 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('CUP: ' + this.dataPnrr.cup);

            //4 riga vuota

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posX(0),
                5 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Beneficiario: " + this.dataPnrr.istituto );


            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Periodo di rendicontazione dal " + this.dataPnrr.start + " al " + this.dataPnrr.stop);

            //7 riga vuota

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posX(0),
                8 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Nominativo: " + this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            let livelloPatto = '';
            let costoPatto = '';

            if (this.dataPnrr.livello == 'ALTO (Professore Ordinario)') {
                livelloPatto = 'Professore Ordinario';
                costoPatto = '73';
            } else
                if (this.dataPnrr.livello == 'MEDIO (Professore Associato)') {
                    livelloPatto = 'Professore Associato';
                    costoPatto = '48';
                } else
                    if (this.dataPnrr.livello == 'BASSO (Ricercatore)') {
                        livelloPatto = 'Ricercatore';
                        costoPatto = '31';
                    } else
                        if (this.dataPnrr.categoria == 'Impiegato') {
                            livelloPatto = 'Personale Tecnico';
                            costoPatto = '31';
                        } 


            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posX(0),
                9 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Livello: " + livelloPatto);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                10 + this.initialY, posX(0),
                10 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Costo orario: " + costoPatto);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                11 + this.initialY, posX(0),
                11 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Monte ore lavorative annuo previsto: 1500"); //+ this.dataPnrr.oredivisionecostostipendio);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                12 + this.initialY, posX(0),
                12 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Dipartimento di afferenza: " + this.dataPnrr.unitaorganizzativa); 

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 14 + this.initialY;

            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }


        },

        //---------------------------------FRONTESPIZIO FSC_MS_3-----------------------------------------------

        buildFrontespizioFSC_MS_3: function (sheet, opts, dtInput, maximumX, month) {

            this.columnIndexMonth = 2;
            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);

            //inizio a riga 9

            // intestazione
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                9, posX(0),
                9, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('Avviso Pubblico bandito dal Ministero della Salute e contenuto nel Piano Operativo Salute (FSC 2014-2020) Traiettoria 3 “Medicina rigenerativa, predittiva e personalizzata” Linea di azione 3.1 ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                10, posX(0),
                10, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('“Creazione di un programma di medicina di precisione per la mappatura del genoma umano su scala nazionale”');

            //progetto a riga 11

            this.addProgetto(sheet, opts, maximumX, 12, "#d9e1f2");

            //riparto da riga 15


            this.initialY = 15;

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posX(0),
                1 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Nominativo: " + this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, Math.round(maximumX / 2) + 1,
                1 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("CF: " + this.dataPnrr.cf);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("QUALIFICA: " + this.dataPnrr.figuraContrattuale);

            //mergedCellRegion = sheet.mergedCellsRegions().add(
            //    3 + this.initialY, posX(0),
            //    3 + this.initialY, maximumX
            //);
            //mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            //mergedCellRegion.cellFormat().font().bold(true);
            //mergedCellRegion.value("Livello: " + this.dataPnrr.livello);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, Math.round(maximumX / 2)
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("Monte ore lavorative annuo previsto: " + this.dataPnrr.oredivisionecostostipendio);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, Math.round(maximumX / 2) + 1,
                4 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value("ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO: " + this.dataPnrr.tot);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("Periodo dal " + this.dataPnrr.start + " al " + this.dataPnrr.stop);

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 7 + this.initialY;

            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }


        },


        //---------------------------------FRONTESPIZIO FSC_MS-----------------------------------------------

        buildFrontespizioFSC_MS: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyle = function (region, isLeft) {
                //const left = isLeft === true
                //    ? "SI"
                //    : isLeft === false
                //        ? "NO"
                //        : "INDEFINITO";

                region.cellFormat().font().bold(true);
                //region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            //    if (left == "NO" || left == "INDEFINITO") region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            //    if (left == "SI" || left == "INDEFINITO") region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            //    region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            //    region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            };

            let posX = this.posX.bind(this);
            this.initialY = 9;
            let posXLabelLeft = posX(0);
            let posXContentLeft = posX(0) + 3;
            let posXContentRight = maximumX;

            // -------------------------------------------------

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posXLabelLeft,
                this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('PIANO DI SVILUPPO E COESIONE DEL MINISTERO DELLA SALUTE 2014-2020');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXLabelLeft,
                2 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('SCHEMA DI REGISTRAZIONE PRESENZE');

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXLabelLeft,
                4 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thick);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thick);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thick);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            mergedCellRegion.value('Nome Progetto: ' + this.dataPnrr.titolo);

            // -------------------------------------------------
            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXLabelLeft,
                5 + this.initialY, posXContentRight
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thick);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thick);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thick);
            mergedCellRegion.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_CELL_FRONTESPIZIO));
            mergedCellRegion.value('Denominazione sociale: ' + this.dataPnrr.istituto);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXLabelLeft,
                7 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Nominativo:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXContentLeft,
                7 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);

            // -------------------------------------------------

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posXLabelLeft,
                8 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Qualifica/Mansione: ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posXContentLeft,
                8 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.dataPnrr.categoria);

            // -------------------------------------------------
            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posXLabelLeft,
                9 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Contratto applicato: ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                9 + this.initialY, posXContentLeft,
                9 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(this.dataPnrr.figuraContrattualeEsatta);

            // -------------------------------------------------
            mergedCellRegion = sheet.mergedCellsRegions().add(
                10 + this.initialY, posXLabelLeft,
                10 + this.initialY, posXContentLeft - 1
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value('Monte ore lavorative annuo previsto: ');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                10 + this.initialY, posXContentLeft,
                10 + this.initialY, maximumX
            );
            applyRegionStyle(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio);

            // -------------------------------------------------

            //setto la riga di partenza del riquadro delle ore 
            this.offsetYFrontespizio = 10 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
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
            this.initialY = 10;

            let posXContentLeft = posX(0) + 2;
            let posXLabelRight = Math.round(maximumX / 2) - Math.round(maximumX / 4);
            let posXContentRight = Math.round(maximumX / 2) + 7;

            // TIMESHEET PER RENDICONTAZIONE PERSONALE
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, posXContentRight - 4
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value('TIMESHEET PER RENDICONTAZIONE PERSONALE');

            if (month) {
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight - 3,
                    0 + this.initialY, posXContentRight - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value('MESE');

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight,
                    0 + this.initialY, posXContentRight + 2
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(this.getMonthColumnName(month));
            }

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 3 : posXContentRight - 3),
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2)
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('ANNO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2) + 1,
                0 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);


            // TITOLO DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('TITOLO DEL PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXContentLeft,
                2 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.titolo);

            // CUP DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posX(0),
                3 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('CUP DEL PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXContentLeft,
                3 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cup);

            // CODICE DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('CODICE DEL PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXContentLeft,
                4 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.codice);

            // DENOMINAZIONE SOGGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posX(0),
                5 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('DENOMINAZIONE SOGGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft,
                5 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.istituto);

            //SEPARATORE FIGURA PROFESSIONALE

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, maximumX
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            mergedCellRegion.cellFormat().font().italic(true);
            mergedCellRegion.value("Figura Professionale" + (opts.idtimesheettemplate == ETemplateType.PNRR_AGE_IT ? ": " + this.dataPnrr.figuraContrattualeEsatta : ""));


            //NOME

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posX(0),
                7 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("NOME");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXContentLeft,
                7 + this.initialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.nome);

            //COGNOME

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXLabelRight,
                7 + this.initialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("COGNOME");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXContentRight,
                7 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cognome);

            //CODICE FISCALE

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posX(0),
                8 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("CODICE FISCALE");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posXContentLeft,
                8 + this.initialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cf);

            //ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO

            mergedCellRegion = sheet.mergedCellsRegions().add(
                8 + this.initialY, posXLabelRight,
                8 + this.initialY, posXContentRight - 1
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
                8 + this.initialY, posXContentRight,
                8 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.toTimeString(totOreMese));

            if (opts.idtimesheettemplate == ETemplateType.PNRR_AGE_IT) { 
                //CCNL

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    9 + this.initialY, posX(0),
                    9 + this.initialY, posXContentLeft - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value("CCNL");

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    9 + this.initialY, posXContentLeft,
                    9 + this.initialY, posXLabelRight - 1
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value("");

                //ORE LAVORATIVE ANNUE

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    9 + this.initialY, posXLabelRight,
                    9 + this.initialY, posXContentRight - 9
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value("ORE LAVORATIVE ANNUE");

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    9 + this.initialY, posXContentRight - 8,
                    9 + this.initialY, posXContentRight - 7
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(this.toTimeString(this.dataPnrr.oredivisionecostostipendio));

                //ORE PRODUTTIVE ANNUE

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    9 + this.initialY, posXContentRight - 6,
                    9 + this.initialY, posXContentRight - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value("ORE PRODUTTIVE ANNUE");

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    9 + this.initialY, posXContentRight,
                    9 + this.initialY, maximumX
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(this.toTimeString(this.dataPnrr.oredivisionecostostipendio - (this.dataPnrr.oremincompitidida ? this.dataPnrr.oremincompitidida : 0)));

            }

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 10 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO NBFC_CNR-----------------------------------------------

        buildFrontespizioNBFC_CNR: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyleContent = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.initialY = 10;

            let posXContentLeft = posX(0) + 2;
            let posXLabelRight = Math.round(maximumX / 2) - Math.round(maximumX / 4);
            let posXContentRight = Math.round(maximumX / 2) + 7;

            // TIMESHEET PER RENDICONTAZIONE PERSONALE
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, posXContentRight - 4
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('TIMESHEET PER RENDICONTAZIONE PERSONALE');

            if (month) {
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight - 3,
                    0 + this.initialY, posXContentRight - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value('MESE');

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight,
                    0 + this.initialY, posXContentRight + 2
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                mergedCellRegion.cellFormat().font().bold(true);
                mergedCellRegion.value(this.getMonthColumnName(month));
            }

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 3 : posXContentRight - 3),
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2)
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('ANNO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2) + 1,
                0 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.opts.year);


            // TITOLO DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posX(0),
                1 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value('Titolo del progetto:');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                1 + this.initialY, posXContentLeft,
                1 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
           mergedCellRegion.value(this.dataPnrr.titolo);

            // CUP DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value('CUP progetto:');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXContentLeft,
                2 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.cup);

            // CODICE DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posX(0),
                3 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value('Codice del progetto:');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXContentLeft,
                3 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.codice);


            //NOME

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value("Nome:");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXContentLeft,
                4 + this.initialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.nome);

            //COGNOME

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXLabelRight,
                4 + this.initialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value("Cognome:");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXContentRight,
                4 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.cognome);

            //CODICE FISCALE

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posX(0),
                5 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value("Codice fiscale:");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft,
                5 + this.initialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.cf);

            //INQUADRAMENTO-LIVELLO

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXLabelRight,
                5 + this.initialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value("Inquadramento livello:");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentRight,
                5 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.livello ? this.dataPnrr.livello : this.dataPnrr.scatto);


            //FIGURA PROFESSIONALE 1

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value("Figura professionale:");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posXContentLeft,
                6 + this.initialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.categoria);


            //ORE TOTALI RENDICONTANTE SUL PROGETTO PER IL PERIODO IN OGGETTO

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posXLabelRight,
                6 + this.initialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            mergedCellRegion.value(opts.mese || month ? "Ore totali rendicontate sul progetto nel mese:" : "Ore totali rendicontate sul progetto per il periodo in oggetto:");

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
                6 + this.initialY, posXContentRight,
                6 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.toTimeString(totOreMese));

            //FIGURA PROFESSIONALE 2

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posX(0),
                7 + this.initialY, posXLabelRight - 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(this.dataPnrr.figuraContrattualeEsatta);

            //ore anno

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXLabelRight,
                7 + this.initialY, posXContentRight - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(false);
            //mergedCellRegion.value("Ore lavorative annue " + this.dataPnrr.oredivisionecostostipendio + " - ore produttive annue:");
            mergedCellRegion.value("Ore lavorative annue");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                7 + this.initialY, posXContentRight,
                7 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            //mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio - (this.dataPnrr.oremincompitidida ? this.dataPnrr.oremincompitidida : 0));
            mergedCellRegion.value(this.dataPnrr.oredivisionecostostipendio);


            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 7 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //---------------------------------FRONTESPIZIO MASE-----------------------------------------------

        buildFrontespizioMASE: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyleContent = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.initialY = 10;

            let posXContentLeft = posX(0) + 3;
            let posXLabelRight = Math.round(maximumX / 2) - Math.round(maximumX / 4);
            let posXContentRight = Math.round(maximumX / 2) + 7;

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, posXContentRight - 4
            );
            //applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('TIMESHEET MENSILE DIPENDENTE');

            // TITOLO DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, posXContentLeft - 1
            );
            //this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('PNRR Misura / Componente / Investimento');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXContentLeft,
                2 + this.initialY, maximumX
            );
            //applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.finanziamento ? this.dataPnrr.finanziamento : this.dataPnrr.title_prog_fin + ' / ' + this.dataPnrr.title_prog_fin_bando + ' / ' + this.dataPnrr.titolo);

            // CUP DEL PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posX(0),
                3 + this.initialY, posXContentLeft - 1
            );
            //this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('CUP');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXContentLeft,
                3 + this.initialY, maximumX
            );
            //applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cup);

            // DENOMINAZIONE SOGGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, posXContentLeft - 1
            );
            //this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value('SOGGETTO ATTUATORE');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXContentLeft,
                4 + this.initialY, maximumX
            );
            //applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.istituto);

            //NOME
            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posX(0),
                5 + this.initialY, posXContentLeft - 1
            );
            //this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("MATRICOLA / CID DEL DIPENDENTE");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft,
                5 + this.initialY, maximumX
            );
            //applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.extmatricula + ' / ' + this.dataPnrr.nome + ' ' + this.dataPnrr.cognome);

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 5 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //-----------------------------FRONTESPIZIO MALATTIE_RARE----------------------------------------

        buildFrontespizioMALATTIE_RARE: function (sheet, opts, dtInput, maximumX, month) {

            let applyRegionStyleContent = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.initialY = 10;

            let posXContentLeft = posX(0) + 2;
            let posXLabelRight = Math.round(maximumX / 2) - Math.round(maximumX / 4);
            let posXContentRight = Math.round(maximumX / 2) + 7;

            // INTESTAZIONE
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posX(0),
                this.initialY + 1, posXContentRight + 1
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);

            mergedCellRegion.value('Avviso Pubblico \"Promozione di progetti di ricerca, sviluppo sperimentale e innovazione collaborativi nel campo delle malattie rare\"\r\n previsto al progr.n. 30 degli Allegati \"A5\" e \"B4\" dell\'Accordo per la Coesione della Regione Campania del 17/09/2024 a valere sulle risorse del Fondo di Rotazione ex L. 183/1987');

            this.initialY = mergedCellRegion.lastRow() + 2;

            // TIMESHEET PER RENDICONTAZIONE PERSONALE
            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, posXContentRight - 4
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value('TIMESHEET PER RENDICONTAZIONE PERSONALE');

            if (month) {
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight - 3,
                    0 + this.initialY, posXContentRight - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value('MESE');

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight,
                    0 + this.initialY, posXContentRight + 2
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(this.getMonthColumnName(month));
            }

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 3 : posXContentRight - 3),
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2)
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('ANNO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2) + 1,
                0 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);


            // ID PROGETTO
            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posX(0),
                2 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('ID PROGETTO');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                2 + this.initialY, posXContentLeft,
                2 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.titolo);

            // CUP
            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posX(0),
                3 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('CUP');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                3 + this.initialY, posXContentLeft,
                3 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.cup);

            // // CODICE DEL PROGETTO
            // mergedCellRegion = sheet.mergedCellsRegions().add(
            //     4 + this.initialY, posX(0),
            //     4 + this.initialY, posXContentLeft - 1
            // );
            // this.applyRegionOrCellStyleLabel(mergedCellRegion);
            // mergedCellRegion.value('CODICE DEL PROGETTO');


            // mergedCellRegion = sheet.mergedCellsRegions().add(
            //     4 + this.initialY, posXContentLeft,
            //     4 + this.initialY, maximumX
            // );
            // applyRegionStyleContent(mergedCellRegion);
            // mergedCellRegion.value(this.dataPnrr.codice);

            // SOGGETTO ATTUATORE
            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posX(0),
                4 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('SOGGETTO ATTUATORE');


            mergedCellRegion = sheet.mergedCellsRegions().add(
                4 + this.initialY, posXContentLeft,
                4 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.dataPnrr.istituto);

            // //SEPARATORE FIGURA PROFESSIONALE

            // mergedCellRegion = sheet.mergedCellsRegions().add(
            //     6 + this.initialY, posX(0),
            //     6 + this.initialY, maximumX
            // );
            // this.applyRegionOrCellStyleLabel(mergedCellRegion);
            // mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
            // mergedCellRegion.cellFormat().font().italic(true);
            // mergedCellRegion.value("Figura Professionale" + (opts.idtimesheettemplate == ETemplateType.PNRR_AGE_IT ? ": " + this.dataPnrr.figuraContrattualeEsatta : ""));


            //NOMINATIVO RISORSA
            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posX(0),
                5 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("NOMINATIVO RISORSA");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                5 + this.initialY, posXContentLeft,
                5 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(`${this.dataPnrr.cognome} ${this.dataPnrr.nome}`);

            //LIVELLO E TIPOLOGIA
            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posX(0),
                6 + this.initialY, posXContentLeft - 1
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value("Livello / Tipologia");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                6 + this.initialY, posXContentLeft,
                6 + this.initialY, maximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(`${this.dataPnrr.livello || 'N/A'} / ${this.dataPnrr.categoria || 'N/A'}`);

            //setto la riga di partenza del riquadro delle ore
            this.offsetYFrontespizio = 7 + this.initialY;
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
        },

        //-----------------------------FRONTESPIZIO PSRCAMPANIA----------------------------------------

        buildFrontespizioPSRCAMPANIA: function (sheet, opts, dtInput, maximumX, month) {
            let applyRegionStyleContent = function (region) {
                region.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                region.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            processedMaximumX = month ? maximumX : maximumX; // aggiungo spazio se c'è il mese

            let posY = this.posY.bind(this);
            let posX = this.posX.bind(this);
            this.initialY = 10;

            let posXContentLeft = posX(0) + 2;
            let posXLabelRight = Math.round(processedMaximumX / 2) - Math.round(processedMaximumX / 4);

            let posXContentRight = processedMaximumX - 6;

            // INTESTAZIONE
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                this.initialY, posX(0),
                this.initialY + 11, processedMaximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);


            let formulaAnagrafica = '';
            let formulaIndirizzoResidenza = '';

            if (this.requiredData.sets.registry.docenti.tables.registry.rows[0]) {

                const row = this.requiredData.sets.registry.docenti.tables.registry.rows[0];

                formulaAnagrafica = `nato a ${row.location} il ${new Date(row.birthdate).toLocaleDateString("en-GB") }`;
            }

            if (this.requiredData.sets.registry.docenti.tables.registryaddress.rows[0]) {

                const row = this.requiredData.sets.registry.docenti.tables.registryaddress.rows[0];

                formulaIndirizzoResidenza = `e residente in ${row.address}, ${row.cap} ${row.location}`;
            }

            const header = `
                PROGETTO "${this.dataPnrr.titolo}"
                PSR Campania 2014-2022 - TIPOLOGIA DI INTERVENTO  16.1.2  AZIONE 2
                D.R.D. N. 329 del  29.08.2022 -  CUP  ${this.dataPnrr.cup}

                TIME SHEET INTEGRATO - RIEPILOGO

                "Il sottoscritto ${this.dataPnrr.cognome} ${this.dataPnrr.nome} ${formulaAnagrafica} ${formulaIndirizzoResidenza}"
                DICHIARA
                sotto la propria responsabilità, consapevole di incorrere, in ipotesi di falsità in atti e dichiarazioni mendaci, nelle sanzioni penali di cui all’art. 76 del D.P.R. 445 del 28/12/2000,
                che ha collaborato allo svolgimento del progetto (${this.dataPnrr.progetto}) fornendo le ore di lavoro di seguito indicate
            `;

            mergedCellRegion.value(header);
            this.initialY = mergedCellRegion.lastRow() + 2;

            // TITOLO TIMESHEET
            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, posX(0),
                0 + this.initialY, posXContentRight - 4
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value('TIMESHEET PER RENDICONTAZIONE PERSONALE');

            if (month) {
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight - 3,
                    0 + this.initialY, posXContentRight - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value('MESE');

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    0 + this.initialY, posXContentRight,
                    0 + this.initialY, posXContentRight + 2
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(this.getMonthColumnName(month));
            }

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 3 : posXContentRight - 3),
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2)
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);
            mergedCellRegion.value('ANNO');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                0 + this.initialY, (month ? posXContentRight + 5 : posXContentRight - 2) + 1,
                0 + this.initialY, processedMaximumX
            );
            applyRegionStyleContent(mergedCellRegion);
            mergedCellRegion.value(this.opts.year);

            // CAMPI COLONNA 1
            const firstColumnFields = [
                { label: 'Partner', value: `${this.requiredData.sets.progettoregistry_aziende.seg.tables.registryaziendeview.rows.map(r => r.dropdown_title).join(' ')}` },
                { label: 'Voce di spesa', value: `${this.dataPnrr.figuraContrattuale}` },
                { label: 'Nome e cognome', value: `${this.dataPnrr.nome} ${this.dataPnrr.cognome}` },
                { label: 'Tipologia di contratto', value: `${this.dataPnrr.figuraContrattualeEsatta}` },
                { label: 'Costo standard', value: `${[...new Set(this.requiredData.tables.costoorariomembroattivitaprogettoperiodoview.rows.map(r => r.costostandard))].join(' ')}` },
            ];

            firstColumnFields.forEach((field, index) => {
                const row = 2 + this.initialY + index;

                // Label
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    row, posX(0),
                    row, posXContentLeft - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value(field.label);

                // Valore
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    row, posXContentLeft,
                    row, posXLabelRight + 1
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(field.value);
            });

            // CAMPI COLONNA 2
            const secondColumnStartX = posXLabelRight + 3;
            const secondColumnLabelWidth = month ? 6 : 3;
            const secondColumnValueStartX = secondColumnStartX + secondColumnLabelWidth;
            const secondColumnValueEndX = processedMaximumX;

            const secondColumnFields = [
                { label: 'Livello/Qualifica', value: `${this.dataPnrr.livello || 'N/A'} / ${this.dataPnrr.categoria || 'N/A'}` },
                {
                    label: 'Durata del contratto', value: `${[...new Set(this.requiredData.tables.costoorariomembroattivitaprogettoperiodoview.rows
                        .map(r => {
                            if (!r.startcontratto || !r.stopcontratto) {
                                return 'N/A';
                            }

                            let diffTime = Math.abs(new Date(r.stopcontratto) - new Date(r.startcontratto));
                            return `${ Math.ceil(diffTime / (1000 * 60 * 60 * 24)) } giorni`;

                        }))].join(' ')}`
                },
                { label: 'Nr. Ore progetto', value: this.dataPnrr.tot },
                {
                    label: 'Importo rendicontato', value: `€ ${ this.requiredData.tables.rendicontattivitaprogettomesetmview.rows
                        .reduce((sum, row) => sum + row.stipendiorendicontato, 0).toFixed(2) }`
                },
            ];

            secondColumnFields.forEach((field, index) => {
                const row = 2 + this.initialY + index;

                // Label
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    row, secondColumnStartX,
                    row, secondColumnValueStartX - 1
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.value(field.label);

                // Valore
                mergedCellRegion = sheet.mergedCellsRegions().add(
                    row, secondColumnValueStartX,
                    row, secondColumnValueEndX
                );
                applyRegionStyleContent(mergedCellRegion);
                mergedCellRegion.value(field.value);
            });

            // Offset per sezione successiva
            this.offsetYFrontespizio = 2 + this.initialY + Math.max(firstColumnFields.length, secondColumnFields.length);
            if (this.isFirstFrontespizio) {
                this.offsetY += this.offsetYFrontespizio;
                this.isFirstFrontespizio = false;
            }
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
        buildPiedipagina: function (sheet, opts, dtInput, maximumX, y, month) {
            let rowIndex = this.posY(y);
            switch (opts.idtimesheettemplate) {
                case ETemplateType.HORIZON:
                    this.buildPiedipaginaHorizon(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  4;
                    break;
                case ETemplateType.HORIZON_Y:
                    this.buildPiedipaginaHorizon(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  4;
                    break;
                case ETemplateType.PON:
                    this.buildPiedipaginaPON(sheet, opts, dtInput, maximumX, rowIndex);
                    return 15;
                    break;
                case ETemplateType.HORIZON_ERANET_COFUND:
                    this.buildPiedipaginaHORIZON_ERANET_COFUND(sheet, opts, dtInput, maximumX, rowIndex);
                    return 15;
                    break;
                case ETemplateType.MASE:
                    this.buildPiedipaginaMASE(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  13;
                    break;
                case ETemplateType.PNRR_PF:
                case ETemplateType.PNC:
                case ETemplateType.PNRR:
                    this.buildPiedipaginaPNRR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  13;
                    break;
                case ETemplateType.PNRR_AGE_IT:
                    this.buildPiedipaginaPNRR_AGE_IT(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return 13;
                    break;
                case ETemplateType.NBFC_CNR:
                    this.buildPiedipaginaNBFC_CNR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  7;
                    break;
                case ETemplateType.FSC_MS_5:
                    this.buildPiedipaginaFSC_MS_5(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return 20;
                    break;
                case ETemplateType.PATTO_TERR:
                    this.buildPiedipaginaPATTO_TERR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return 10;
                    break;
                case ETemplateType.FSC_MS_3:
                    this.buildPiedipaginaFSC_MS_3(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return 10;
                    break;
                case ETemplateType.FSC_MS:
                    this.buildPiedipaginaFSC_MS(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return 6;
                    break;
                case ETemplateType.MISE:
                    this.buildPiedipaginaMISE(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  8;
                    break;
                case ETemplateType.PORCAMPANIA_21_27:
                case ETemplateType.MIMIT_2:
                    this.buildPiedipaginaMISE(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  8;
                    break;
                case ETemplateType.PORCAMPANIA:
                    this.buildPiedipaginaPORCAMPANIA(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  8;
                    break;
                case ETemplateType.MIMIT:
                    this.buildPiedipaginaMIMIT(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  9;
                    break;
                case ETemplateType.EMPIR:
                    this.buildPiedipaginaEMPIR(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  8;
                    break;
                case ETemplateType.MALATTIE_RARE:
                    this.buildPiedipaginaMALATTIE_RARE(sheet, opts, dtInput, maximumX, rowIndex, month);
                    return  13; // return così, slegati, quando potevano essere valori di ritorno delle funzioni...
                                // servono ad aumentare la confusione e possibilità di errore?
                    break;
                default:
                    //this.buildPiedipaginaHorizon(sheet, opts, dtInput);
                    return  0;
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
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 10,
                rowIndex + 4, 22
            );
            mergedCellRegion.value(self.signatureLabels.right);

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

        buildPiedipaginaMIMIT: function (sheet, opts, dtInput, maximumX, rowIndex) {

            let applyRegionStyle = function (region) {
                region.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            };

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 2,
                rowIndex + 4, 4
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 10,
                rowIndex + 4, 22
            );
            mergedCellRegion.value(self.signatureLabels.right);

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

            //terza riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 7, 2,
                rowIndex + 7, 4
            );
            mergedCellRegion.value('Data');

            //quarta riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 8, 2,
                rowIndex + 8, 2
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
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 10,
                rowIndex + 4, 22
            );
            mergedCellRegion.value(self.signatureLabels.right);

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

        buildPiedipaginaHorizon: function (sheet, opts, dtInput, maximumX, rowIndex) {

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, 3
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 4,
                rowIndex + 2, 19
            );
            mergedCellRegion.value(self.signatureLabels.middle);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 22,
                rowIndex + 2, 30
            );
            mergedCellRegion.value(self.signatureLabels.right);

        },

        buildPiedipaginaMISE: function (sheet, opts, dtInput, maximumX, rowIndex) {

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, 3
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 4,
                rowIndex + 2, 19
            );
            mergedCellRegion.value(self.signatureLabels.middle);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 22,
                rowIndex + 2, 29
            );
            mergedCellRegion.value(self.signatureLabels.right);

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
            mergedCellRegion.value(opts.sede);
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
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 9, 24,
                rowIndex + 9, maximumX
            );
            //mergedCellRegion.value('Firma del Direttore amministrativo/Direttore del personale/Legale rappresentante *');
            mergedCellRegion.value(self.signatureLabels.middle);

            //quarta riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 13, 24,
                rowIndex + 13, maximumX
            );
            mergedCellRegion.value(self.signatureLabels.right);

            //qunta riga

            //mergedCellRegion = sheet.mergedCellsRegions().add(
            //    rowIndex + 15, 1,
            //    rowIndex + 15, 4
            //);
            //mergedCellRegion.value('* in alternativa');

        },

        buildPiedipaginaHORIZON_ERANET_COFUND: function (sheet, opts, dtInput, maximumX, rowIndex) {

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
            mergedCellRegion.value(opts.sede);
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
                rowIndex + 6, 1,
                rowIndex + 6, 9
            );
            mergedCellRegion.value('Personale non dipendente contrattualizzato  presso il laboratorio sito in (località)');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 6, 10,
                rowIndex + 6, 21
            );
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 6, 23,
                rowIndex + 6, 23
            );
            this.applyRegionOrCellStyleLabel(mergedCellRegion);

            //quarta riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 9, 1,
                rowIndex + 9, 4
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 9, 24,
                rowIndex + 9, maximumX
            );
            mergedCellRegion.value(self.signatureLabels.middle);

            //quinta riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 13, 24,
                rowIndex + 13, maximumX
            );
            mergedCellRegion.value(self.signatureLabels.right);

            //sesta riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 15, 1,
                rowIndex + 15, 4
            );
            mergedCellRegion.value('* in alternativa');

        },

        buildPiedipaginaMASE: function (sheet, opts, dtInput, maximumX, rowIndex, month) {


            //let mergedCellRegion = sheet.mergedCellsRegions().add(
            //    rowIndex + 2, 1,
            //    rowIndex + 2, maximumX
            //);
            //mergedCellRegion.cellFormat().font().italic(true);
            //mergedCellRegion.value("*Al fine di rendicontare le ore sul Progetto non saranno considerate le frazioni di ora ma sarà necessario arrotondate per difetto, riportando il totale delle ore all'unità, priva di decimali.");

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 13,
                rowIndex + 4, 19
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 21,
                rowIndex + 4, 29
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value(self.signatureLabels.right);

        },

        buildPiedipaginaPNRR_AGE_IT: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

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
                rowIndex + 5, 4
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("SEDE OPERATIVA IN CUI E' STATA SVOLTA L'ATTIVITA':");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 5,
                rowIndex + 5, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(opts.sede);

            //firma left
            this.writeRiquadroFirma(sheet, self.signatureLabels.left, 1, Math.round(maximumX / 2) - 6, rowIndex + 7);

            //firma right            
            this.writeRiquadroFirma(sheet, self.signatureLabels.right, Math.round(maximumX / 2) - 5, maximumX, rowIndex + 7);
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
                rowIndex + 5, 4
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("SEDE OPERATIVA IN CUI E' STATA SVOLTA L'ATTIVITA':");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 5,
                rowIndex + 5, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(opts.sede);

            //firma left
            this.writeRiquadroFirma(sheet, self.signatureLabels.left, 1, Math.round(maximumX / 2) - 6, rowIndex + 7);

            //firma right            
            this.writeRiquadroFirma(sheet, self.signatureLabels.right, Math.round(maximumX / 2) - 5, maximumX, rowIndex + 7);
        },

        buildPiedipaginaNBFC_CNR: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

            //firma left
            this.writeRiquadroFirma(sheet, self.signatureLabels.left, 1, Math.round(maximumX / 2) - 6, rowIndex + 2);

            //firma right            
            this.writeRiquadroFirma(sheet, self.signatureLabels.right, Math.round(maximumX / 2) - 5, maximumX, rowIndex + 2);
        },

        buildPiedipaginaFSC_MS_5: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

            //Descrizione delle attività svolte nel periodo:
            this.writeRiquadroFirma(sheet, "Descrizione delle attività svolte nel periodo:", 1, maximumX, rowIndex + 2, true);

            //Nel caso di Personale dipendente:
            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 8, 1,
                rowIndex + 8, maximumX
            );
            mergedCellRegion.cellFormat().font().italic(true);
            mergedCellRegion.value('Nel caso di Personale dipendente');

            //firma left
            this.writeRiquadroFirma(sheet, self.signatureLabels.left, 1, Math.round(maximumX / 2) - 6, rowIndex + 10);

            //firma right            
            this.writeRiquadroFirma(sheet, self.signatureLabels.middle, Math.round(maximumX / 2) - 5, maximumX, rowIndex + 10);

            //Firma del Coordinatore Tecnico Scientifico del Progetto :
            this.writeRiquadroFirma(sheet, self.signatureLabels.right, 1, maximumX, rowIndex + 16);

        },

        buildPiedipaginaFSC_MS_3: function (sheet, opts, dtInput, maximumX, rowIndex) {

            //prima riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, 4
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 24,
                rowIndex + 2, maximumX
            );
            //mergedCellRegion.value('Firma del Direttore amministrativo/Direttore del personale/Legale rappresentante *');
            mergedCellRegion.value(self.signatureLabels.right);

        },

        buildPiedipaginaPATTO_TERR: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

            //prima riga
            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 2,
                rowIndex + 2, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('Il/la sottoscritto/a dichiara che, nell\'anno e nei mesi e per le ore sopra indicati, ha svolto le proprie attività per lo svolgimento del Progetto');

            //seconda riga 
            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 3, 2,
                rowIndex + 3, maximumX
            );
            mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellRegion.value('"Patto territoriale per il Sistema Universitario Pugliese" (CUP  ' + this.dataPnrr.cup + ')');

            //terza riga vuota 

            //quarta riga
            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 2,
                rowIndex + 5, 4
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 6, 2,
                rowIndex + 6, 4
            );
            mergedCellRegion.value("" + this.dataPnrr.cognome + ' ' + this.dataPnrr.nome);


            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, (month ?24:12),
                rowIndex + 5, maximumX
            );
            mergedCellRegion.value('VISTO IL');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 6, (month ? 24 : 12),
                rowIndex + 6, maximumX
            );
            mergedCellRegion.value(self.signatureLabels.right);

        },

        buildPiedipaginaFSC_MS: function (sheet, opts, dtInput, maximumX, rowIndex) {

            //prima riga

            let mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 1,
                rowIndex + 2, 3
            );
            mergedCellRegion.value('Data');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 4,
                rowIndex + 2, 19
            );
            mergedCellRegion.value(self.signatureLabels.left);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 2, 22,
                rowIndex + 2, 29
            );
            mergedCellRegion.value(self.signatureLabels.right);

            //seconda riga

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 1,
                rowIndex + 4, 2
            );
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 4,
                rowIndex + 4, 15
            );
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 4, 22,
                rowIndex + 4, 29
            );
            mergedCellRegion.cellFormat().bottomBorderStyle($.ig.excel.CellBorderLineStyle.thin);

        },

        buildPiedipaginaMALATTIE_RARE: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 1,
                rowIndex + 5, 4
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("SEDE OPERATIVA IN CUI E' STATA SVOLTA L'ATTIVITA':");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 5,
                rowIndex + 5, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(opts.sede);

            // qua andrebbe fatto un metodo decente per calcolare le coordinate X non lineari (magari esponenziale?)
            // ma non abbiamo tempo

            const oneThird = Math.round(maximumX / 3);
            const firstColumnScalingFactor = 0.7;
            const offset = Math.floor(oneThird * firstColumnScalingFactor); // fattore di aggiustamento

            let boxes = {
                left: {
                    x1: 1,
                    x2: oneThird - offset,
                    y: rowIndex + 7
                },
                middle: {
                    x1: oneThird - offset + 1,
                    x2: 2 * oneThird - offset,
                    y: rowIndex + 7
                },
                right: {
                    x1: 2 * oneThird - offset + 1,
                    x2: maximumX,
                    y: rowIndex + 7
                }
            }

            //firma left
            this.writeRiquadroFirma(sheet, self.signatureLabels.left, boxes.left.x1, boxes.left.x2, boxes.left.y);

            //firma middle
            this.writeRiquadroFirma(sheet, self.signatureLabels.middle, boxes.middle.x1, boxes.middle.x2, boxes.middle.y);

            //firma right
            this.writeRiquadroFirma(sheet, self.signatureLabels.right, boxes.right.x1, boxes.right.x2, boxes.right.y);
        },

        buildPiedipaginaPSRCAMPANIA: function (sheet, opts, dtInput, maximumX, rowIndex, month) {

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 1,
                rowIndex + 5, 4
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value("SEDE OPERATIVA IN CUI E' STATA SVOLTA L'ATTIVITA':");

            mergedCellRegion = sheet.mergedCellsRegions().add(
                rowIndex + 5, 5,
                rowIndex + 5, maximumX
            );
            mergedCellRegion.cellFormat().font().bold(true);
            mergedCellRegion.value(opts.sede);

            // qua andrebbe fatto un metodo decente per calcolare le coordinate X non lineari (magari esponenziale?)
            // ma non abbiamo tempo

            const oneThird = Math.round(maximumX / 3);
            const firstColumnScalingFactor = 0.7;
            const offset = Math.floor(oneThird * firstColumnScalingFactor); // fattore di aggiustamento

            let boxes = {
                left: {
                    x1: 1,
                    x2: oneThird - offset,
                    y: rowIndex + 7
                },
                middle: {
                    x1: oneThird - offset + 1,
                    x2: 2 * oneThird - offset,
                    y: rowIndex + 7
                },
                right: {
                    x1: 2 * oneThird - offset + 1,
                    x2: maximumX,
                    y: rowIndex + 7
                }
            }

            //firma left
            this.writeRiquadroFirma(sheet, self.signatureLabels.left, boxes.left.x1, boxes.left.x2, boxes.left.y);

            //firma middle
            this.writeRiquadroFirma(sheet, self.signatureLabels.middle, boxes.middle.x1, boxes.middle.x2, boxes.middle.y);

            //firma right
            this.writeRiquadroFirma(sheet, self.signatureLabels.right, boxes.right.x1, boxes.right.x2, boxes.right.y);
        },


        writeRiquadroFirma: function (sheet, label, posXleft, posiXRigt, posY, skipDataFirma) {

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
            if (!skipDataFirma)
                mergedCellRegion.value('data:');

            mergedCellRegion = sheet.mergedCellsRegions().add(
                posY + 3, posXleft,
                posY + 3, posiXRigt
            );
            mergedCellRegion.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.thin);
            mergedCellRegion.cellFormat().font().bold(true);
            if (!skipDataFirma)
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
                    Ypos, Xpos + (month ? 4 : 1)
                );
                mergedCellRegion.cellFormat().font().bold(true);
                mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.left);
                mergedCellRegion.value(label);

                mergedCellRegion = sheet.mergedCellsRegions().add(
                    Ypos, Xpos + (month ? 5 : 2),
                    Ypos, Xpos + (month ? 6 : 2)
                );
                this.applyRegionOrCellStyleLabel(mergedCellRegion);
                mergedCellRegion.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                mergedCellRegion.value(this.toTimeString(totOreMese));
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

            var mergedCellMonth = sheet.mergedCellsRegions().add(
                posY(0) , posX(0) + this.offsetXYear,
                posY(1) , posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellMonth.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellMonth.value(year.toString());
            mergedCellMonth.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellMonth.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            mergedCellMonth.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellMonth.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellMonth.cellFormat().font().height(16 * 22);
            mergedCellMonth.cellFormat().font().bold(true);

            var xlRowDayString = sheet.rows(this.offsetY);
            xlRowDayString.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            xlRowDayString.cellFormat().font().bold(true);

            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var valueMonthString = this.getMonthColumnName(counterMonth);
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                sheet.columns(dataCellIndex).setWidth(80, $.ig.excel.WorksheetColumnWidthUnit.pixel);
                xlRowDayString.setCellValue(dataCellIndex, valueMonthString);
                sheet.rows(this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
                sheet.rows(this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
                xlRowDayString.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }

            var mergedCellTotal = sheet.mergedCellsRegions().add(
                posY(0) , posX(counterMonth + this.columnIndexMonth) + this.offsetXYear,
                posY(1) , posX(counterMonth + this.columnIndexMonth) + this.offsetXYear);
            mergedCellTotal.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellTotal.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_MONTH));
            mergedCellTotal.cellFormat().font().colorInfo(this.COLOR_MONTH_FONT);
            mergedCellTotal.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellTotal.value(this.lang == 'it' ? "totale" : "total");
        },

        addFiligrana: function (opts, sheet, isYear) {
            if (opts.watermark && (opts.output == 'P' || (this.signed && !this.signedAllowed))) {

                let watermarkBase64 = 'data:image/png;base64,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TTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjc3MGE1MzllLWFkZTAtNDU5ZC04ZWFkLTdkOGM4YjhiNDI3MiIKICAgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJ4bXAuZGlkOmYwZDNlOTIxLWExNDQtNGM2YS1hMmVmLTg1MjViMjhjZjc5NSIKICAgZGM6Rm9ybWF0PSJpbWFnZS9wbmciCiAgIEdJTVA6QVBJPSIyLjAiCiAgIEdJTVA6UGxhdGZvcm09IldpbmRvd3MiCiAgIEdJTVA6VGltZVN0YW1wPSIxNzIxMDU5MTI3NDE3NzcxIgogICBHSU1QOlZlcnNpb249IjIuMTAuMzIiCiAgIHRpZmY6T3JpZW50YXRpb249IjEiCiAgIHhtcDpDcmVhdG9yVG9vbD0iR0lNUCAyLjEwIgogICB4bXA6TWV0YWRhdGFEYXRlPSIyMDI0OjA3OjE1VDE3OjU4OjA2KzAyOjAwIgogICB4bXA6TW9kaWZ5RGF0ZT0iMjAyNDowNzoxNVQxNzo1ODowNiswMjowMCI+CiAgIDx4bXBNTTpIaXN0b3J5PgogICAgPHJkZjpTZXE+CiAgICAgPHJkZjpsaQogICAgICBzdEV2dDphY3Rpb249InNhdmVkIgogICAgICBzdEV2dDpjaGFuZ2VkPSIvIgogICAgICBzdEV2dDppbnN0YW5jZUlEPSJ4bXAuaWlkOmNlNGM4ZTBmLWI1YmUtNDVkMy04NmM0LWQyMDk5NmY4MWJkMSIKICAgICAgc3RFdnQ6c29mdHdhcmVBZ2VudD0iR2ltcCAyLjEwIChXaW5kb3dzKSIKICAgICAgc3RFdnQ6d2hlbj0iMjAyNC0wNy0xNVQxNzo1ODo0NyIvPgogICAgPC9yZGY6U2VxPgogICA8L3htcE1NOkhpc3Rvcnk+CiAgPC9yZGY6RGVzY3JpcHRpb24+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAg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';
                var imageShape = new $.ig.excel.WorksheetImage(watermarkBase64);

                if (!opts.intestazioneallsheet && !isYear) {
                    //caso del foglio del mese senza intestazione
                    imageShape.topLeftCornerCell(sheet.getCell('H1'));
                    imageShape.bottomRightCornerCell(sheet.getCell('L3'));
                } else {
                    if (opts.idtimesheettemplate === ETemplateType.HORIZON || opts.idtimesheettemplate === ETemplateType.HORIZON_Y || opts.idtimesheettemplate === ETemplateType.EMPIR || opts.idtimesheettemplate === ETemplateType.MIMIT) {
                        imageShape.topLeftCornerCell(sheet.getCell('A2'));
                        imageShape.bottomRightCornerCell(sheet.getCell('T8'));
                    } else {
                        imageShape.topLeftCornerCell(sheet.getCell('A2'));
                        imageShape.bottomRightCornerCell(sheet.getCell('T20'));
                    }
                }
                sheet.shapes().add(imageShape);
            }
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
        calcTimeSheetTable: function (workbook, obj, month, dtInput, opts, logoBase64, isFirst, isLast) {
            var self = this;
            if (this.verbose)
                console.log("4 - Disegna il foglio del mese");
            // aggiungo 1 singolo foglio per il mese
            var year = opts.year;
            var showactivitiesrow = opts.showactivitiesrow;

            var sheet = workbook.worksheets().add(this.getMonthColumnName(month));

            this.addBorder(sheet, 0, 36, true);

            //aggiungo l'intestazione nel foglio del mese se ...
            //c'è l'opzione intestazione in tutti fogli o se è il primo mese del template FSC_MS_5
            if (opts.intestazioneallsheet || (opts.idtimesheettemplate === ETemplateType.FSC_MS_5 && isFirst)) {
                this.addSheetLogo(sheet, opts, logoBase64, false);
                try { 
                    this.buildFrontespizio(sheet, opts, dtInput, this.getNumDaysInMonth(month, this.opts.year) +4, month);
                } catch (e) {
                    if (this.verbose)
                        console.log("Errore creando l'intestazione del mese. Metodo buildFrontespizio(), mese: " + month);
                }
            }

            this.createHeaders(sheet, month, year);
            var rowIndex = 2; // le prime 2 sono header  1 per giorni + 1 per stringa giorno

            //se ho scelto il collasso di altre attività e insegnamento e contemporaneamente di mostrare le timbrature (altre attività fittizie) devo TOGLIERE le teachig acivities (che sono già incluse nella timbratura)
            //quindi levo le teaching activitties che avendole collassate ora si chiamano attività istituzionali
            let projects = obj;
            if (opts.collapseteachingother == true && opts.showOtherActivitiesrow == true) {
                projects = _.filter(obj, function (o, pkey) {
                    return pkey != "Attività ordinaria" && pkey != "Institutional activities";
                });
            }

            //aggiungo anche l'idprogetto e l'ente finanziatore (se non l'ho già fatto per il riepilogo anno)
            if (!opts.riepilogoanno) {
                if (opts.multilineType) {
                    _.forEach(projects, function (o) {
                        o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].progetto;
                        o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].cup ? 
                            o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].cup : '';
                        o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idprogetto;
                        o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].idreg_aziende_fin;
                        o.ismur = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].ismur;
                        o.iseu = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].iseu;
                        o.tipoprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[Object.getOwnPropertyNames(o.group[Object.getOwnPropertyNames(o.group)[0]].group)[0]].group[0].tipoprogetto;
                    });
                } else {
                    _.forEach(projects, function (o) {
                        o.progetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].progetto;
                        o.cup = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].cup ?
                            o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].cup : '';
                        o.idprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idprogetto;
                        o.idreg_aziende_fin = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].idreg_aziende_fin;
                        o.ismur = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].ismur;
                        o.iseu = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].iseu;
                        o.tipoprogetto = o.group[Object.getOwnPropertyNames(o.group)[0]].group[0].tipoprogetto;
                    });
                }
            }

            if (opts.idtimesheettemplate === ETemplateType.EMPIR) {
                self.getRowText(sheet, rowIndex, "In case of absence, indicate one of the reason codes below", month);
                rowIndex += 1; // righe aggiunte per wp + 1 del prog
            }

            // 2. scorro i progetti

            //2.1 aggiungo prima la riga del progetto principale
            let objPrg = _.filter(projects, function (o) { return o.idprogetto == opts.idprogetto });
            _.forEach(objPrg, function (el) {
                var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
            });

            if (
                //2A) tempalte con una sola riga per tutti gli altri (li ho collassati prima)
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS_3 ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS_5 ||
                opts.idtimesheettemplate === ETemplateType.FSC_MS ||
                opts.idtimesheettemplate === ETemplateType.PON ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND ||
                opts.idtimesheettemplate === ETemplateType.MIMIT ||
                opts.idtimesheettemplate === ETemplateType.POR ||

                //2C) template con tutti i progetti
                opts.idtimesheettemplate === ETemplateType.HORIZON ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_Y ||
                opts.idtimesheettemplate === ETemplateType.EMPIR ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                opts.idtimesheettemplate === ETemplateType.MISE ||
                opts.idtimesheettemplate === ETemplateType.PATTO_TERR 
            ) {
                //poi quella degli altri progetti
                let objFinEq = _.filter(projects, function (o) { return o.idprogetto != opts.idprogetto && (o.tipoprogetto == 'ricerca' || o.tipoprogetto == 'didattica' || o.tipoprogetto == 'altro'); });
                if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5)
                    objFinEq = _.filter(projects, function (o) { return o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca'; });

                if (opts.idtimesheettemplate === ETemplateType.MIMIT ||
                    opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                    opts.idtimesheettemplate === ETemplateType.MIMIT_2
                ) {
                    self.getRowText(sheet, rowIndex, "Altre attività non di pertinenza del progetto", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                }

                if (
                    opts.idtimesheettemplate === ETemplateType.PON ||
                    opts.idtimesheettemplate === ETemplateType.MISE
                ) {
                    self.getRowText(sheet, rowIndex, "Altri progetti finanziati", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                }

                _.forEach(objFinEq, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });


            }
            else {
                //2.2 B) template con gruppo stesso ente finanziatore e poi gruppo tutti gli altri -------------------------------------------------------------------
                //MASE, PNRR, PNRR_PF PNC NBFC_CNR
                let objFinEq = [];

                if (opts.idtimesheettemplate === ETemplateType.MASE) {
                    self.getRowText(sheet, rowIndex, "Attività svolte su altri progetti finanziati con risorse UE (B)", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    objFinEq = _.filter(projects, function (o) {
                        return o.iseu == 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                    });
                } else {
                    //2.2 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI MUR:", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    objFinEq = _.filter(projects, function (o) {
                        return o.ismur == 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                    });

                }

                _.forEach(objFinEq, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                let objFinNeq = [];

                if (opts.idtimesheettemplate === ETemplateType.MASE) {
                    self.getRowText(sheet, rowIndex, "Attività svolte su progetti finanziati con altre risorse (C)", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog
                    objFinNeq = _.filter(projects, function (o) {
                        return o.iseu != 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                    });
                } else {
                    //2.3 aggiungo la riga "ATTIVITA' SVOLTE SU ALTRI PROGETTI:"
                    self.getRowText(sheet, rowIndex, "ATTIVITA' SVOLTE SU ALTRI PROGETTI:", month);
                    rowIndex += 1; // righe aggiunte per wp + 1 del prog

                    //2.4 poi quella dei progetti con ente finanziatore diverso
                    objFinNeq = _.filter(projects, function (o) {
                        return o.ismur != 'S' && o.idprogetto != opts.idprogetto && o.tipoprogetto == 'ricerca';
                    });

                }

                _.forEach(objFinNeq, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });


                if (opts.idtimesheettemplate === ETemplateType.PNRR_PF) {

                        //progetto fittizio progetti idprogetto_otherresearchactivities  "Altri progetti di ricerca"
                        let objFittRes = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'fittizio ricerca'
                        });
                        _.forEach(objFittRes, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });

                        self.getRowText(sheet, rowIndex, "", month);
                        rowIndex += 1;

                        //"Altre attività"
                        let objOther = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'altro'
                        });
                        _.forEach(objOther, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });

                        //"Attività di didattica"
                        let objDida = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'didattica'
                        });
                        _.forEach(objDida, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });

                        self.getRowText(sheet, rowIndex, "", month);
                        rowIndex += 1;

                        //porgetto fittizio altre attività idprogetto_otheractivities "Ulteriori attività"
                        let objFittOther = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'fittizio altro'
                        });
                        _.forEach(objFittOther, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });
                    }
                else { 
                    if (opts.idtimesheettemplate === ETemplateType.MASE) {
                            //MASE  - Attività ordinaria (D)
                            let objOther = _.filter(projects, function (o) {
                                return o.tipoprogetto == 'altro' || o.tipoprogetto == 'didattica';
                            });
                            _.forEach(objOther, function (el) {
                                var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                                rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                            });
                        } else {
                        //PNRR e PNC

                        //"Altre attività"
                        let objOther = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'altro'
                        });
                        _.forEach(objOther, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });

                        //"Attività di didattica"
                        let objDida = _.filter(projects, function (o) {
                            return o.tipoprogetto == 'didattica'
                        });
                        _.forEach(objDida, function (el) {
                            var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                            rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                        });
                    }

                }


            }

            //MALATTIE FERIE PERMESSI -----------------------------------------------------------------------------------------------------------

            if (
                opts.idtimesheettemplate === ETemplateType.PNRR ||
                opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT ||
                opts.idtimesheettemplate === ETemplateType.MALATTIE_RARE
            ) {
                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia' || o.tipoprogetto == 'ferie' || o.tipoprogetto == 'permessi'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.MASE) {
                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia' || o.tipoprogetto == 'ferie' || o.tipoprogetto == 'permessi'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                //faccio in modo che in questo primo totale ci sia il totale reale calcolato su ricerca insegnamento e attività ordinaria
                opts.showOtherActivitiesrow = false;

                //visualizza il totale giornaliero
                this.addLastRowWithTotalActivities(sheet, rowIndex, dtInput, month, year, opts);
                rowIndex += 1;

                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                let objFerie = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'ferie'
                });
                _.forEach(objFerie, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
                let objPermessi = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'permessi'
                });
                _.forEach(objPermessi, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                self.getRowText(sheet, rowIndex, "Altre assenze", month);
                rowIndex += 1;
            }

            if (
                opts.idtimesheettemplate === ETemplateType.MISE ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.HORIZON_ERANET_COFUND
            ) {
                let objMalattia = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'malattia'
                });
                _.forEach(objMalattia, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });

                let objFerie = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'ferie'
                });
                _.forEach(objFerie, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
                let objPermessi = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'permessi'
                });
                _.forEach(objPermessi, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
            }

            if (opts.idtimesheettemplate === ETemplateType.FSC_MS) {
                let objFerie = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'ferie'
                });
                _.forEach(objFerie, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });
                let objPermessi = _.filter(projects, function (o) {
                    return o.tipoprogetto == 'permessi'
                });
                _.forEach(objPermessi, function (el) {
                    var currentRowIndex = self.getProgettoTimeSheet(sheet, rowIndex, el.progetto, el, dtInput, month, year, opts);
                    rowIndex += currentRowIndex + 1; // righe aggiunte per wp + 1 del prog
                });            }

            //RIGHE ATTIVABILI CON OPZIONI + TOTALE + PIEDIPAGINA-----------------------------------------------------------------------------------------------------

            //riga delle altre attività calcolate fittizie
            if (opts.showOtherActivitiesrow) {
                //visualizzo la riga con la differenza delle ore dei progetti con il massimale del giorno per idposition su una riga intitolata ad "altre attività"
                this.addRowOtherActivities(sheet, rowIndex, dtInput, month, opts);
                rowIndex++;
            }

            //riga con il totale delle SOLE attività di ricerca
            if (showactivitiesrow) {
                this.addLastRowWithTotalActivities(sheet, rowIndex, dtInput, month, year, opts);
                rowIndex++;
            }

            ////se il template è  NBFC_CNR nell'ultimo totale ci va il totale fittizio del massimo delle ore lavorabili
            //if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) 
            //    opts.showOtherActivitiesrow = true;

            //visualizza il totale giornaliero
            this.addLastRowWithTotal(sheet, rowIndex, dtInput, month, year, opts);

            //il piè di pagina
            if (opts.idtimesheettemplate != ETemplateType.FSC_MS_5 || isLast) 
                rowIndex += this.buildPiedipagina(sheet, opts, dtInput, this.getNumDaysInMonth(month, this.opts.year) + 4, rowIndex, month);

            this.addBorder(sheet, rowIndex + 1, 36, false);

            //aggiungo la filigrana 
            this.addFiligrana(opts, sheet, false);

            //questo template ha l'intestazione solo al primo foglio, fatto il primo lo resetto
            if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5 && isFirst)
                this.offsetY -= 30;

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
            mergedCellMonth.value(this.getMonthColumnName(month) + ' ' + year.toString());
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

            //le  colonne successive le stringo al massimo per gestire le intestazioni più larghe di 1 (mesi di 30) o 3 gg (febbraio)
            let colRight = 31 - this.getNumDaysInMonth(month, this.opts.year);
            for (var dd = 1; dd <= colRight; dd++) {
                sheet.columns(posX(counterDay + this.columnIndexMonth) + dd).setWidth(30, $.ig.excel.WorksheetColumnWidthUnit.pixel);
            }
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

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                mergedCellProgName.value("Totale ore lavorative");
            }

            if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5) {
                mergedCellProgName.value("hl");
            }

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

                let isFestivo = this.isZeroOtherActivitiesDay(d);
                //considero il ruolo solo se non è sabato, domenica o festività e non sono consolidamenti obbligatori (l'obbligatorietà dei consolidamenti la calcola la vista stessa
                let role = isFestivo && maxHoursPerDayRole.role != 'Consolidamento assente' && maxHoursPerDayRole.role != 'Consolidamenti' ? '' : maxHoursPerDayRole.role; 

                //SE ho calcolato la riga delle altre attività per differenza con le massime, allora ...
                //...tranne che sabato, domenica e i gorni di sospensione se ha rendicontato meno delle ore lavorate/lavorabili ...
                if (!isFestivo && tot < maxHours && opts.showOtherActivitiesrow) {
                    //...il mio totale sono le ore lavorate/lavorabili ...
                    tot = maxHours
                }

                if (role == 'Timbrature') {
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

                if (role == 'Consolidamenti') {
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
                if (role == 'Consolidamento assente' || role == 'Timbratura assente') {
                    //...la coloro di rosso
                    isRed = true;
                    //... lascio il totale di quanto rendicontato 
                    //...blocco la firma
                    this.signedAllowed = false;
                }

                globalTot += tot;
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(tot));
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
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, this.toTimeString(globalTot));
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
        addLastRowWithTotalActivities: function (sheet, rowIndex, dtInput, month, year, opts) {
            // 1. aggiungo riga del totale
            var posY = this.posY.bind(this);
            var posX = this.posX.bind(this);
            var mergedCellProgName = sheet.mergedCellsRegions().add(
                posY(rowIndex), posX(0),
                posY(rowIndex), posX(this.columnIndexMonth));
            mergedCellProgName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);

            mergedCellProgName.value(this.lang == 'it' ? "Ore totali in attività di ricerca" : "Total research activities hours");
            mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                mergedCellProgName.value("Totale ore produttive");
                mergedCellProgName.cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            }

            mergedCellProgName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellProgName.cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            mergedCellProgName.cellFormat().font().bold(true);
            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            var daysInMonth = this.getNumDaysInMonth(month, year);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(
                    _.sumBy(
                        _.filter(
                            dtInput.rows,
                            function (o) {
                                return o.giorno == counterDay && o.mese == month && (o.tipoprogetto == 'ricerca' || o.tipoprogetto == 'fittizio ricerca');
                            }
                            //{ giorno: counterDay, mese: month }
                        )
                        , 'ore')));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));

                if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                    sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
                }

            }

            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(
                dtInput.rows, function (o) {
                    return o.mese == month && (o.tipoprogetto == 'ricerca' || o.tipoprogetto == 'fittizio ricerca');
                }
                //{ mese: month }
            ), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, this.toTimeString(total));
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));

            if (opts.idtimesheettemplate === ETemplateType.NBFC_CNR) {
                sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_TOTAL));
            }
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
        addRowOtherActivities: function (sheet, rowIndex, dtInput, month, opts, year) {
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
            if (this.lang == 'it') {
                if (opts.collapseteachingother)
                    mergedCellProgName.value('Attività ordinaria');
                else
                    mergedCellProgName.value('Altre attività');
            }
            else {
                if (opts.collapseteachingother)
                    mergedCellProgName.value("Institutional activities");
                else
                    mergedCellProgName.value("Other activities");
            }

            //se ho scelto il collasso di altre attività e insegnamento e contemporaneamente di mostrare le timbrature (altre attività fittizie) devo TOGLIERE le teachig acivities (che sono già incluse nella timbratura)
            //quindi levo le teaching activitties che avendole collassate ora si chiamano attività istituzionali
            let projectsRows = dtInput.rows;
            if (opts.collapseteachingother == true && opts.showOtherActivitiesrow == true) {
                projectsRows = _.filter(dtInput.rows, function (o) { return o.progetto != "Attività ordinaria" && o.progetto != "Institutional activities" });
            }


            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var maxDayHour = 8;
            var total = 0;
            var daysInMonth = this.getNumDaysInMonth(month, opts.year);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var isRed = false;
                var d = new Date(opts.year, month - 1, counterDay);
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                //ore massime lavorabili
                var maxHoursPerDayRole = this.getMaxHourPerDay(d);
                let isFestivo = this.isZeroOtherActivitiesDay(d);
                var maxDayHour = isFestivo ? 0 : maxHoursPerDayRole.maxHoursPerDay;
                let role = isFestivo ? '' : maxHoursPerDayRole.role; //considero il ruolo solo se non è sabato, domenica o festività
                let researchHours = _.sumBy(_.filter(projectsRows, { giorno: counterDay, mese: month }), 'ore');
                let diff = maxDayHour - researchHours

                //se è una timbratura e ho sforato (diff negativo) ...
                if (
                    (diff && diff < 0 && role == 'Timbrature')
                    //|| role == " <span style='color:red;'>non definita per questo giorno<span>" //TOLTO perche' non deve essere segnalato nella riga "altre ore"" la timbratura assente. Lo farà il totale se serve
                ) {
                    //...la segnalo in rosso e lascio il numero negativo
                    isRed = true;
                }

                //se è una Consolidamento e ho sforato (diff negativo) o non saturato (diff positivo)...
                if (diff && diff != 0 && role == 'Consolidamenti') {
                    //...la segnalo in rosso e lascio il numero negativo
                    isRed = true;
                }

                //se è un massimale che viene dalla configurazione si può superare ...
                if (diff && diff < 0 && role != 'Timbrature' && role != 'Consolidamenti') {
                    //... ma devo impostare le altre ore a zero (non possono essere negative)
                    diff = 0;
                }

                xlRow.setCellValue(dataCellIndex, this.toTimeString(diff));
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(isRed ? this.COLOR_CELL_ERRORE : this.COLOR_ROW_PROG));
                total += diff;
            }

            // aggiungo cella per il totale
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, this.toTimeString(total));
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
                // Non è fuori da tutte le sospensioni
                isSospensione = !_.every(_.orderBy(appMeta.appMain.dtSospensioni.rows, 'start'), function (rowSosp) {
                    if (rowSosp.start && rowSosp.stop) {
                        //non è dentro => è fuori
                        return !(moment(d).isSameOrAfter(moment(rowSosp.start)) && moment(d).isBefore(moment(rowSosp.stop)));
                    }
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

            //di base esce il nome del progetto ...
            mergedCellProgName.value(progettokey);

            //modifiche a tutte le righe dei progetti
            if ((
                opts.idtimesheettemplate === ETemplateType.PNRR ||
                opts.idtimesheettemplate === ETemplateType.PNRR_PF ||
                opts.idtimesheettemplate === ETemplateType.PNRR_AGE_IT ||
                opts.idtimesheettemplate === ETemplateType.PNC ||
                opts.idtimesheettemplate === ETemplateType.NBFC_CNR ||
                opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                opts.idtimesheettemplate === ETemplateType.MIMIT_2 ||
                opts.idtimesheettemplate === ETemplateType.MALATTIE_RARE
            )
                && progettoObj.tipoprogetto == 'ricerca'
            ) {
                if (progettoObj.cup)
                    mergedCellProgName.value(progettokey + '; CUP:' + progettoObj.cup + ';');
                else
                    mergedCellProgName.value(progettokey);
            }

            if (
                opts.idtimesheettemplate === ETemplateType.EMPIR
                && progettokey !== 'Institutional activities')
                mergedCellProgName.value("Hours worked on project " + progettokey);


            //modifica del rigo del progetto principale
            if (progettoObj.idprogetto == opts.idprogetto) {
                if (opts.idtimesheettemplate === ETemplateType.FSC_MS_5)
                    mergedCellProgName.value("hp");

                if (opts.idtimesheettemplate === ETemplateType.FSC_MS)
                    mergedCellProgName.value("Attività sul progetto");

                if (
                    opts.idtimesheettemplate === ETemplateType.MISE ||
                    opts.idtimesheettemplate === ETemplateType.PORCAMPANIA_21_27 ||
                    opts.idtimesheettemplate === ETemplateType.MIMIT_2
                    )
                    mergedCellProgName.value("Attività progetto");

                if (opts.idtimesheettemplate === ETemplateType.MASE) 
                    mergedCellProgName.value("Attività svolta sul Progetto (A)");
                
            }

            //modifica della altre ore + ore di didattica 
            if (opts.idtimesheettemplate === ETemplateType.MASE) {
                if (progettoObj.tipoprogetto == 'altro' || progettoObj.tipoprogetto == 'didattica') {
                    mergedCellProgName.value("Attività ordinaria (D)");
                }
            }

            //traduzioni in italiano
            if (this.lang == 'it'
                && progettokey == 'Teaching activities') {
                mergedCellProgName.value('Attività di didattica');
            }
            if (this.lang == 'it'
                && progettokey == 'Other activities') {
                mergedCellProgName.value('Altre attività');
            }
            if (this.lang == 'it' &&
                progettokey == 'Other Research Activities') {
                mergedCellProgName.value('Altre attività di ricerca');
            }

            var xlRow = sheet.rows(rowIndex + this.offsetY);
            xlRow.cellFormat().font().bold(true);
            xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            var daysInMonth = this.getNumDaysInMonth(month, year);
            for (var counterDay = 1; counterDay <= daysInMonth; counterDay++) {
                var dataCellIndex = this.columnIndexMonth + counterDay + this.offsetX;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(this.getDaySumProject(dtInput, progettokey, month, counterDay)));
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
                sheet.rows(rowIndex + this.offsetY).cells(dataCellIndex).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            }
            // aggiungo cella per il totale
            var total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, mese: month }), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, this.toTimeString(total));
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().topBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().fill($.ig.excel.CellFill.createSolidFill(this.COLOR_ROW_PROG));
            sheet.rows(rowIndex + this.offsetY).cells(counterDay + this.columnIndexMonth + this.offsetX).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);

            //se è stata indicata l'opzione di visualizzare i workpackage e non ho applicato il collasso su una riga sola del progetto corrente e sono righe di progetti reali (non fittizi)
            if (opts.withWorkpackage == true && progettokey != "Altri progetti finanziati" && progettoObj.tipoprogetto == 'ricerca' && progettoObj.idprogetto == opts.idprogetto) {
                // 2. scorro i workpackege del progetto e creo riga

                progettoObj.group = Object.keys(progettoObj.group)
                    .sort() // Ordina le chiavi in ordine alfabetico
                    .reduce((acc, key) => {
                        acc[key] = progettoObj.group[key];
                        return acc;
                    }, {});
                _.forOwn(progettoObj.group, function (el, wpkey) {
                    if (wpkey !== 'Teaching activities' && wpkey !== 'Other activities' && wpkey !== 'Other Research Activities') {
                        if (opts.multilineType == true /*&& progettoObj.idprogetto == opts.idprogetto*/) {
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
                posY(rowIndex), posX(0) + this.offsetXYear,
                posY(rowIndex), posX(this.columnIndexMonth) + this.offsetXYear);
            mergedCellWPName.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            mergedCellWPName.cellFormat().leftBorderStyle($.ig.excel.CellBorderLineStyle.double1);
            mergedCellWPName.cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.dotted);
            let title = workpackagekey;
            if (opts.idtimesheettemplate === ETemplateType.EMPIR)
                title = "Hours worked on project " + progettokey + ' grids ' + workpackagekey;
            mergedCellWPName.value(title + (type ? ' - ' + type : ''));

            var xlRow = sheet.rows(rowIndex + this.offsetY);
            for (var counterMonth = 1; counterMonth <= 12; counterMonth++) {
                var dataCellIndex = this.columnIndexMonth + counterMonth + this.offsetX + this.offsetXYear;
                xlRow.setCellValue(dataCellIndex, this.toTimeString(this.getDaySumWorkpackageMonth(dtInput, progettokey, workpackagekey, counterMonth, type)));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }
            // aggiungo cella per il totale
            var total = 0;
            if (type)
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey, tipo: type }), 'ore');
            else
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey }), 'ore');
            xlRow.setCellValue(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear, this.toTimeString(total));
            sheet.rows(rowIndex + this.offsetY).cells(counterMonth + this.columnIndexMonth + this.offsetX + this.offsetXYear).cellFormat().rightBorderStyle($.ig.excel.CellBorderLineStyle.double1);
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
                xlRow.setCellValue(dataCellIndex, this.toTimeString(this.getDaySumWorkpackage(dtInput, progettokey, workpackagekey, month, counterDay, type)));
                xlRow.cellFormat().alignment($.ig.excel.HorizontalCellAlignment.center);
            }
            // aggiungo cella per il totale
            var total = 0;
            if(type)
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey, mese: month, tipo: type }), 'ore');
             else
                total = _.sumBy(_.filter(dtInput.rows, { progetto: progettokey, workpackage: workpackagekey, mese: month }), 'ore');
            xlRow.setCellValue(counterDay + this.columnIndexMonth + this.offsetX, this.toTimeString(total));
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
