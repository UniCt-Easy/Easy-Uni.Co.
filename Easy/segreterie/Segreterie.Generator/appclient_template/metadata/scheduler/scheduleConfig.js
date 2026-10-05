/**
 * @module scheduleConfig
 * @description
 * Implements the methods to open and manage a scheduleConfig modal form, for user input
 */
(function () {

    var Deferred = appMeta.Deferred;
    var utils = appMeta.utils;
    var getData = appMeta.getData;
    var localResource = appMeta.localization;
    var q = window.jsDataQuery;

    function scheduleConfig(metaPage, objConf) {
        self = this;
        this.metaPage = metaPage;
        this.rootElement = metaPage.rootElement || document.body;

        this.maxHoursDay = 8; //ore massime per giorno da proporre dallo scheduler all'utente nella tendina
        this.minHours = 1;

        this.endDate = objConf.endDate;
        this.minDateValue = objConf.minDateValue;
        this.tableNameSchedule = objConf.tableNameSchedule;
        this.columnDate = objConf.columnDate;
        this.columnOre = objConf.columnOre;
        this.columnTitle = objConf.columnTitle;
        this.columnTitleValue = objConf.columnTitleValue;
        this.columnStop = objConf.columnStop;
        this.maxHours = objConf.maxHours; //ore da schedulare della attività
        this.chooseAula = objConf.chooseAula;
        this.chooseProject = objConf.chooseProject;
        this.dtActivity = objConf.dtActivity;
        this.writeColumnTitleValue = objConf.writeColumnTitleValue;
        // ====================================================================
        this.chooseKind = objConf.chooseKind;
        // ====================================================================

        // orm per check sul massimo di ore per eventi per un idreg
        this.maxHoursPerDay = 24;
        this.calendarTag = objConf.calendarTag;
        this.maxHoursPerDayTable = objConf.maxHoursPerDayTable;

        if (this.maxHoursPerDayTable) {
            _.forEach(this.maxHoursPerDayTable.rows, function (r) {
                //se r.oremaxgg è decimale lo riporto a intero
                r.oremaxgg = parseInt(r.oremaxgg);
                //adeguo le ore da proporre dallo scheduler all'utente nel caso ne potesse lavorare di più di 8 per giorno
                if (r.oremaxgg > self.maxHoursDay)
                    self.maxHoursDay = r.oremaxgg;
            });
        }

        //costruisco la tabella del residuo annuo
        this.maxHoursPerYearTable = objConf.maxHoursPerYearTable;
        this.maxHoursPerYearTableMaxHourCol = objConf.maxHoursPerYearTableMaxHourCol;
        this.maxHoursPerYearTableWorkedHourCol = objConf.maxHoursPerYearTableWorkedHourCol;
        this.maxHoursPerYear = [];
        if (!!this.maxHoursPerYearTable && !!this.maxHoursPerYearTableMaxHourCol && !!this.maxHoursPerYearTableWorkedHourCol) {

            this.maxHoursPerYearTable.rows.forEach(record => {

                // Trova l'indice del record con l'anno corrispondente nella lista maxHoursPerYear
                let existingRecord = self.maxHoursPerYear.find(r => r.anno === record.year);

                // Se il record con l'anno corrispondente esiste, se necessario:
                //1 - abbassa il numero massimo di ore lavorabili
                //2 - somma le ore lavorate
                //3 - calcola il residuo
                if (existingRecord) {
                    if (record[self.maxHoursPerYearTableMaxHourCol] < existingRecord.maxYearHours) {
                        existingRecord.maxYearHours = record[self.maxHoursPerYearTableMaxHourCol];
                    }
                    existingRecord.workedHours += record[self.maxHoursPerYearTableWorkedHourCol];
                    existingRecord.residuo = existingRecord.maxYearHours - existingRecord.workedHours
                } else {
                    // Altrimenti, aggiungi un nuovo record
                    self.maxHoursPerYear.push({
                        anno: record.year,
                        maxYearHours: record[self.maxHoursPerYearTableMaxHourCol],
                        workedHours: record[self.maxHoursPerYearTableWorkedHourCol],
                        residuo: record[self.maxHoursPerYearTableMaxHourCol] - record[self.maxHoursPerYearTableWorkedHourCol]
                    });
                }
            });

        }

        // leggo tutti glie eventi attachati al calendario. utile pereffettuare alcuni calcoli logici
        this.allEventsRows = [];
        if (this.calendarTag) {
            // recupero eventi e tutte le righe attachate al calendario
            this.allEventsRows = _.map(
                metaPage.getCustomControl(this.calendarTag).getAllEvents(),
                function (event) {
                    return event.row;
                });
        }
    }

    scheduleConfig.prototype = {
        constructor: scheduleConfig,

        /**
         * @method getModalHtml
         * @private
         * @description SYNC
         * Builds the html for a modal scheduleConfig dialog
         * @returns {string} html string for a modal Bootstrap dialog
         */
        getModalHtml: function () {
            var templateFileHtmlPath = appMeta.getMetaPagePath('scheduler') + "/scheduleConfig.html";
            return appMeta.getData.cachedSyncGetHtml(templateFileHtmlPath);
        },


        /**
         * @method show
         * @public
         * @description ASYNC
         * Shows the bootstrap modal
         * @param {MetaPage} page
         * @param {html element} parent. the html node where the modal will be added
         * @retunrs {Deferred} a promise, that will be resolved in the close() event
         */
        show: function () {
            var self = this;
            this.def = Deferred("scheduleConfig.show");
            this.logMaxHourPerDay = "";
            this.dialogid = "dialogid" + utils.getUniqueId();
            this.dialogrootelement = $('<div id="' + this.dialogid + '">');
            var htmlInfo = this.getModalHtml();
            $(this.rootElement).append(this.dialogrootelement);

            if (this.chooseAula) {
                appMeta.modalLoaderControl.show(localResource.scheduler_waitConfigLoading, false);
                getData.runSelect("auladefaultview", "idsede,idaula,idedificio,dropdown_title", null)
                    .then(function (dt) {
                        _.forEach(dt.rows, function (row) {
                            $("#selectAula").append($("<option>").text(row.dropdown_title).val(JSON.stringify(row)));
                        });
                        appMeta.modalLoaderControl.hide();
                    });
            }

            // ====================================================================

            if (this.chooseKind) {
                appMeta.modalLoaderControl.show(localResource.scheduler_waitConfigLoading, false);
                getData.runSelect("rendicontaltrokind", ["idrendicontaltrokind", "title"].join(","), null)
                    .then(function (dt) {
                        _.forEach(dt.rows, function (row) {
                            $("#selectKind").append($("<option>").text(row.title).val(row.idrendicontaltrokind));
                        });
                        appMeta.modalLoaderControl.hide();
                    });
            }

            // ====================================================================

            // calcolo le ore rimaneti da schedulare
            var calcHoursRemain = this.getRemainingHours(this);
            var calcHoursRemainFunction = this.getRemainingHours;

            $("#" + this.dialogid).dialog({
                modal: true,
                autoResize: true,
                width: screen.width * 0.25,
                title: localResource.scheduler_title,
                open: function () {
                    // attacco html
                    $(this).html(htmlInfo);
                    self.setControls(calcHoursRemain);
                },
                close: function (event, ui) {
                    $(this).dialog("close");
                    self.dialogrootelement.remove();
                    self.def.resolve();
                },
                position: { my: "center bottom", at: "center center", of: window }
            });

            // ====================================================================

            if (this.chooseProject) {

                let distinctProject = [];
                _.forEach(this.dtActivity.rows, function (row) {
                    if (!distinctProject.includes(row.idprogetto)) {
                        $("#selectProject").append($("<option>").text(row.progettotitle).val(row.idprogetto));
                        distinctProject.push(row.idprogetto)
                    }
                });

                //sets events
                $("#selectProject").on('change', function () { self.populateWorkpackageSelect(calcHoursRemainFunction, self) });
                $("#selectWorkpackage").on('change', function () { self.populateActivitiesSelect(calcHoursRemainFunction, self) });
                $("#selectActivity").on('change', function () { self.setDateAndMaxOurs(calcHoursRemainFunction, self) });

                //populate for the first choice
                this.populateWorkpackageSelect(calcHoursRemainFunction, this);
                this.populateActivitiesSelect(calcHoursRemainFunction, this);

            }
            // ====================================================================
            else {

                if (!calcHoursRemain || calcHoursRemain <= 0) {
                    this.metaPage.showMessageOk(localResource.scheduler_maxHoursScheduled);
                    return this.def.resolve(true);
                }

            }
            return this.def.promise();
        },

        /**
         * selezione a cascata del Workpackage se viene modificato il progetto
         */
        populateWorkpackageSelect: function (calcHoursRemain, page) {

            // Clear existing options
            $("#selectWorkpackage").empty();

            let distinctWp = [];
            _.forEach(page.dtActivity.rows, function (row) {
                if (!distinctWp.includes(row.idworkpackage) && row.idprogetto == $("#selectProject").val()) {
                    $("#selectWorkpackage").append($("<option>").text(row.workpackagetitle).val(row.idworkpackage));
                    distinctWp.push(row.idworkpackage)
                }
            });


            //Clear and populate dependent select
            $("#selectActivity").empty();
            page.populateActivitiesSelect(calcHoursRemain, page);

        },

        /**
         * selezione a cascata della attività se viene modificato il progetto
         */
        populateActivitiesSelect: function (calcHoursRemain, page) {

            // Clear existing options
            $("#selectActivity").empty();

            let distinctActivies = [];
            _.forEach(page.dtActivity.rows, function (row) {
                if (!distinctActivies.includes(row.idrendicontattivitaprogetto) && row.idworkpackage == $("#selectWorkpackage").val()) {
                    $("#selectActivity").append($("<option>").text(row.activitytitle).val(row.idrendicontattivitaprogetto));
                    distinctActivies.push(row.idrendicontattivitaprogetto)
                }
            });

            this.setDateAndMaxOurs(calcHoursRemain, page);

        },

        setDateAndMaxOurs: function (calcHoursRemain, page) {
            if ($("#selectActivity").val()) {
                let selectedActivity = page.dtActivity.select(q.eq('idrendicontattivitaprogetto', parseInt($("#selectActivity").val())));
                if (selectedActivity.length) {
                    //resetto il numero massimo di ore
                    page.maxHours = selectedActivity[0].orepreventivate;
                    //se sono qui sono nella pagina del timesheet e quindi le ore rimaste
                    let oreRimaste = calcHoursRemain(page, selectedActivity[0].idrendicontattivitaprogetto, 'idrendicontattivitaprogetto', selectedActivity[0].year, selectedActivity[0].oretotali);
                    $('#txtTotalHours').val(oreRimaste);
                    $("#txtTotalHours").prop('min', page.minHours);
                    $("#txtTotalHours").prop('max', oreRimaste);
                    //se sono qui sono nella pagina del timesheet e quindi comunque NON devo schedulare al di fuori dell'anno del timesheet quindi:
                    //1 - memorizzo una volta sola l'anno (al primo passaggio qui)
                    if (!page.yearStart) page.yearStart = page.minDateValue;
                    if (!page.yearStop) page.yearStop = page.endDate;
                    //2 - ricao l'inizio e fine dell'attività ma all'interno dell'anno e setto le variabili
                    page.minDateValue = selectedActivity[0].activitystart > page.yearStart ? selectedActivity[0].activitystart : page.yearStart;
                    page.endDate = selectedActivity[0].activitystop < page.yearStop ? selectedActivity[0].activitystop : page.yearStop;
                    if (page.columnStop) {
                        $('#txtStartDate').datetimepicker('setDate', page.minDateValue);
                        $('#txtStopDate').datetimepicker('setDate', page.endDate);
                        // setto min date, cioè oltre quella data indietro non posso andare
                        $('#txtStartDate').datetimepicker("option", "minDate", page.minDateValue)
                        $('#txtStartDate').datetimepicker("option", "maxDate", page.endDate)
                        $('#txtStopDate').datetimepicker("option", "minDate", page.minDateValue)
                        $('#txtStopDate').datetimepicker("option", "maxDate", page.endDate)
                    } else {
                        $('#txtStartDate').datepicker('setDate', page.minDateValue);
                        $('#txtStopDate').datepicker('setDate', page.endDate);
                        // setto min date, cioè oltre quella data indietro non posso andare
                        $('#txtStartDate').datepicker("option", "minDate", page.minDateValue)
                        $('#txtStartDate').datepicker("option", "maxDate", page.endDate)
                        $('#txtStopDate').datepicker("option", "minDate", page.minDateValue)
                        $('#txtStopDate').datepicker("option", "maxDate", page.endDate)
                    }
                    //3 - resetto la data di inizo e fine del controllo
                    var startDate = moment(page.minDateValue).format('DD/MM/YYYY');
                    var stopDate = moment(page.endDate).format('DD/MM/YYYY');
                    $("#txtStartDate").val(startDate);
                    $("#txtStopDate").val(stopDate);

                }
            }
        },

        /**
         *
         * @returns {number}
         */
        getRemainingHours: function (page, parentKey, parentKeyName, year, oretotali) {

            //se ho passato delle oretotali > page.maxHours vuol dire che page.maxHours è il numero di ore specifico per l'annoe quindi lo devo confrontare con le sole ore di quell'anno
            let isHoursForYear = false;
            if (!!oretotali && !!year && oretotali > page.maxHours)
                isHoursForYear = true;

            //se non è stato passato un tetto massimo  consideriamo sempre minseribili 1500 ore
            if (page.maxHours) {
                // calcolo le ore rimaneti da schedulare
                var totHours = page.maxHours; //se ho passato la configurazione "ore per anno" sono solo le ore per quello specifico anno! 

                var self = page;
                var dtSchedule = page.metaPage.getDataTable(page.tableNameSchedule);
                var rowsToConsider = _.filter(dtSchedule.rows, function (r) {
                    return (r.getRow().state !== 'deleted' && (parentKey ? r[parentKeyName] == parentKey : true))
                        && (!isHoursForYear || r[self.columnDate].getFullYear() == year);
                });

                var calcHoursRemain;
                if (page.columnStop) {
                    // calcolo la somma delle ore allocate. eseguo diff tra start e stop
                    calcHoursRemain = totHours - _.sumBy(rowsToConsider, function (row) {
                        return Math.abs(row[self.columnStop].getTime() - row[self.columnDate].getTime()) / 3600000;
                    });
                } else {
                    // orario fisso per giorno. quindi sommo il parametro ore
                    calcHoursRemain = totHours - _.sumBy(rowsToConsider, function (row) {
                        return row.ore;
                    });
                    //se ho passato la chiave ...
                    if (parentKey) {
                        var calendar = page.metaPage.getCustomControl(page.calendarTag);
                        //...devo togliere anche le ore degli eventi esterni
                        let externalRowsToConsider = _.filter(calendar.externalEventsDt.rows, function (r) {
                            return (r.getRow().state !== 'deleted' && (parentKey ? r[parentKeyName] == parentKey : true))
                                && (!isHoursForYear || r.start.getFullYear() == year);
                        });
                        calcHoursRemain = calcHoursRemain - _.sumBy(externalRowsToConsider, function (row) {
                            return row.ore;
                        });

                    }
                }

                //verifico se il residuo annuo della persona sia sufficiente, a prescindere dalla configurazione per anno della attività, solo se stiamo schedulando nell'anno
                if (page.maxHoursPerYear.length && year) {
                    let existingRecord = page.maxHoursPerYear.find(r => r.anno === year);
                    if (existingRecord && existingRecord.residuo < calcHoursRemain)
                        calcHoursRemain = existingRecord.residuo;
                }
            } else {
                calcHoursRemain = 1500;
            }

            return calcHoursRemain;
        },

        /**
         * Configures the controls at startup form
         * @param calcHoursRemain
         */
        setControls: function (calcHoursRemain) {
            this.calcHoursRemain = calcHoursRemain;
            $('#txtTotalHours').val(calcHoursRemain);
            $("#txtTotalHours").prop('min', this.minHours);
            $("#txtTotalHours").prop('max', calcHoursRemain);

            var startDate = moment(this.minDateValue).format('DD/MM/YYYY');
            $("#txtStartDate").val(startDate);

            if (this.columnStop) {
                // setto min date, cioè oltre quella data indietro non posso andare
                $("#txtStartDate").datetimepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: this.minDateValue,
                    maxDate: this.endDate
                });
            } else {
                // setto min date, cioè oltre quella data indietro non posso andare
                $("#txtStartDate").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: this.minDateValue,
                    maxDate: this.endDate
                });
            }

            var stopDate = moment(this.endDate).format('DD/MM/YYYY');
            $("#txtStopDate").val(stopDate);

            if (this.columnStop) {
                // setto min date, cioè oltre quella data indietro non posso andare
                $("#txtStopDate").datetimepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: this.minDateValue,
                    maxDate: this.endDate
                });
            } else {
                // setto min date, cioè oltre quella data indietro non posso andare
                $("#txtStopDate").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: this.minDateValue,
                    maxDate: this.endDate
                });
            }

            // decoro con plugin select2
            $('#selectDays').select2();
            $("#" + this.dialogid).find(".select2-search").css("display", "none");
            $('#selectHours').select2();

            // a seconda delle ore massimo da schedulare popolo la select con le opzioni di ore. max 8
            var maxSelHours = calcHoursRemain >= this.maxHoursDay ? this.maxHoursDay : calcHoursRemain;
            $('#selectHours').each(function (index, row) {
                for (var i = 1; i <= maxSelHours; i++) {
                    $(this).append($("<option>").text(i).val(i));
                }
            });

            // devo selzionare l'aula
            if (this.chooseAula) {
                $('#selectAula').select2();
                $('#selectAulaGroupId').show();
            }

            // ====================================================================
            if (this.chooseKind) {
                $('#selectKind').select2();
                $('#selectKindGroupId').show();
            }
            // ====================================================================
            if (this.chooseProject) {
                $('#selectProject').select2();
                $('#selectWorkpackage').select2();
                $('#selectActivity').select2();
                $('#selectProjectGroupId').show();
            }
            // ====================================================================
            if (this.writeColumnTitleValue) {
                $('#columnTitleValueGroupId').show();
            }


            $("#btnScheduleOk").on("click", _.partial(this.createSchedule, this));
        },

        forceClose: function () {
            $("#" + this.dialogid).dialog("close");
            this.dialogrootelement.remove();
        },

        /**
         * Returns the input to the caller. Resolve the deferred
         * @param that
         */
        createSchedule: function (that) {
            var hourTot = $('#txtTotalHours').val();
            var hourPerDay = $('#selectHours').val();
            var days = $('#selectDays').val(); // 1 lunedì...
            var aulaVal = $('#selectAula').val();
            var kindVal = $('#selectKind').val();
            var startDate = $('#txtStartDate').val();
            var stopDate = $('#txtStopDate').val();
            var progettoVal = $('#selectProject').val();
            var workpackageVal = $('#selectWorkpackage').val();
            var attivitaVal = $('#selectActivity').val();
            let homogenization = $('#ckHomogenization').is(":checked");
            if (that.writeColumnTitleValue) {
                that.columnTitleValue = $('#columnTitleValue').val();
            }

            // dati incompleti
            if (!hourTot || !hourPerDay || !days || !startDate || !days.length) {
                that.metaPage.showMessageOk(localResource.scheduler_missing_fields);
                return;
            }

            if (hourTot > that.calcHoursRemain) {
                that.metaPage.showMessageOk(localResource.scheduler_max_hour_to_insert + ": " + that.calcHoursRemain);
                return;
            }

            if (moment(startDate, "DD/MM/YYYY hh:mm") < new Date(that.minDateValue) || moment(stopDate, "DD/MM/YYYY hh:mm") > new Date(that.endDate)) {
                that.metaPage.showMessageOk(localResource.scheduler_out_of_range + ': ' + moment(that.minDateValue).format("DD/MM/YYYY") + ' - ' + moment(that.endDate).format("DD/MM/YYYY"));
                return;
            }

            that.forceClose();

            // creo le righe sulla tabella da schedulare, metto indicatore di attesa
            appMeta.modalLoaderControl.show(localResource.scheduler_running, false);

            let arrayGetNewRow = [];

            //verifico che il periodo da schedulare sia completamente all'interno della configurazione per anno se presente,
            //se non lo è o lo è solo in modo parziale la configurazione per anno viene ignorata perchè non si può fare un algoritmo decente in un caso misto
            let periodIsInConfYear = false;
            if (that.metaPage.state.DS.tables.rendicontattivitaprogettoyear && that.metaPage.state.DS.tables.rendicontattivitaprogettoyear.rows.length) {

                //calcolo il periodo configurato dal 1 gennaio del primo anno al 31 dicembre dell'ultimo
                let orderedYear = _.orderBy(that.metaPage.state.DS.tables.rendicontattivitaprogettoyear.rows, 'year', 'asc');
                let firstYear = orderedYear[0];
                let lastYear = orderedYear[orderedYear.length - 1];


                if (moment(startDate, "DD/MM/YYYY hh:mm") >= new Date(firstYear.year, 0, 1) && moment(stopDate, "DD/MM/YYYY hh:mm") <= new Date(lastYear.year, 11, 31)) {
                    //sta dentro
                    periodIsInConfYear = true;
                }
                else {
                    //sta fuori
                    that.logMaxHourPerDay += "E\' stata trovata una configurazione di ore per anno per l'attività ma il periodo indicato non è totalmente compreso negli anni configurati e quindi la configurazione per anno è stata ignorata.<br />";
                }
            }

            if (periodIsInConfYear) {

                that.logMaxHourPerDay += "E\' stata trovata una configurazione di ore per anno per l'attività<br />";


                _.forEach(that.metaPage.state.DS.tables.rendicontattivitaprogettoyear.rows, function (row) {
                    //controllo se l'anno fa parte del periodo che devo schedulare
                    if (moment(stopDate, "DD/MM/YYYY hh:mm") > new Date(row.year, 0, 1) && moment(startDate, "DD/MM/YYYY hh:mm") < new Date(row.year, 11, 31)) {

                        let start = moment(startDate, "DD/MM/YYYY hh:mm") > new Date(row.year, 0, 1) ? startDate : moment(new Date(row.year, 0, 1)).format('DD/MM/YYYY');
                        let stop = moment(stopDate, "DD/MM/YYYY hh:mm") < new Date(row.year, 11, 31) ? stopDate : moment(new Date(row.year, 11, 31)).format('DD/MM/YYYY');

                        //calcolo le ore da schedulare
                        //1 - parto con le ore previste per l'anno
                        let hoursRemain = row.ore;
                        let hourtToScheduleInferiorHoursYear = false;
                        //2 - sotraggo le ore già schedulate per questa attività nell'anno
                        let existingRecordHours = _.filter(that.metaPage.state.DS.tables.rendicontattivitaprogettoora.rows, function (r) {
                            return r.data >= moment(start, "DD/MM/YYYY hh:mm") && r.data <= moment(stop, "DD/MM/YYYY hh:mm");
                        });

                        if (existingRecordHours) {
                            let alreadyScheduled = 0;
                            _.forEach(existingRecordHours, function (recordHours) {
                                alreadyScheduled += recordHours.ore;
                            });
                            hoursRemain -= alreadyScheduled;
                            if (hoursRemain < 0) hoursRemain = 0;
                        }
                        //3 - controllo quante ore volevo schedulare (hourTot) che se è a sua volta inferiore a quelle configurate per l'anno (hoursRemain) lo sostiuisce
                        if (hourTot < hoursRemain) {
                            that.logMaxHourPerDay += "Per l'anno " + row.year + " erano state configurate " + row.ore + " ma restano da schedulare solo " + hourTot + " ore.<br />";
                            hoursRemain = hourTot;
                            hourtToScheduleInferiorHoursYear = true;
                        }
                        //4 - controllo il residuo della persona che se è inferiore lo sostituisce
                        let existingRecord = self.maxHoursPerYear.find(r => r.anno === row.year);
                        if (existingRecord && existingRecord.residuo < hoursRemain) {
                            if (hourtToScheduleInferiorHoursYear)
                                that.logMaxHourPerDay += "Per l'anno " + row.year + " restavano da schedulare " + hoursRemain + " ma la persona ha un residuo di " + existingRecord.residuo + " ore.<br />";
                            else
                                that.logMaxHourPerDay += "Per l'anno " + row.year + " erano state configurate " + row.ore + " ma la persona ha un residuo di " + existingRecord.residuo + " ore.<br />";
                            hoursRemain = existingRecord.residuo < 0 ? 0 : existingRecord.residuo;
                        }
                        //5 - aggiorno le ore rimaste da schedulare
                        hourTot = hourTot - hoursRemain;

                        let arrayGetNewRowYear = that.schedule({
                            hourTot: hoursRemain,
                            hourPerDay: hourPerDay,
                            days: days,
                            startDate: start,
                            stopDate: stop,
                            homogenization: homogenization,
                            aulaVal: aulaVal,
                            // ====================================================================
                            kindVal: kindVal,
                            // ====================================================================
                            progettoVal: progettoVal,
                            workpackageVal: workpackageVal,
                            attivitaVal: attivitaVal
                        });
                        _.forEach(arrayGetNewRowYear, function (y) {
                            arrayGetNewRow.push(y);
                        });
                    }
                });


            } else {

                arrayGetNewRow = that.schedule({
                    hourTot: hourTot,
                    hourPerDay: hourPerDay,
                    days: days,
                    startDate: startDate,
                    stopDate: stopDate,
                    homogenization: homogenization,
                    aulaVal: aulaVal,
                    // ====================================================================
                    kindVal: kindVal,
                    // ====================================================================
                    progettoVal: progettoVal,
                    workpackageVal: workpackageVal,
                    attivitaVal: attivitaVal
                });
            }
            // risolvo le getNewRow e rinfreso la pagina
            $.when.apply($, arrayGetNewRow)
                .then(function () {
                    return that.metaPage.freshForm();
                })
                .then(function () {
                    appMeta.modalLoaderControl.hide();
                    appMeta.Toast.showNotification(localResource.scheduler_done);
                    // mostro log su ore non schedulate
                    if (that.logMaxHourPerDay) that.metaPage.showMessageOk(that.logMaxHourPerDay);
                    that.def.resolve(true);
                });
        },

        createElements: function (startDate, endDate, numElements, daysOfWeek, hourPerDay) {
            let start = new Date(startDate);
            let end = new Date(endDate);
            let numDayToSchedule = numElements / hourPerDay;

            // Calcola il numero totale di giorni tra startDate e endDate
            let totalDays = (end - start) / (1000 * 60 * 60 * 24);

            //PRIMO TENTATIVO: considerando tutti i giorni con tutte e ore richieste (hourPerDay) libere
            let result = this.createInternalElements(startDate, endDate, numElements, daysOfWeek, hourPerDay);

            if (result.length < numDayToSchedule) {

                //SECONDO TENTATIVO: abbasso di volta in volta il numero di ore giornaliero sperando che sia possibile
                appMeta.Toast.showNotification("non ci sono giorni sufficienti " + result.length + " per schedulare tutte le ore. Sarebbero necessari " + numDayToSchedule + " giorni.");
                let isEnd = false;
                while (hourPerDay > 1 && isEnd == false) {
                    hourPerDay--;
                    numDayToSchedule = numElements / hourPerDay;
                    result = this.createInternalElements(startDate, endDate, numElements, daysOfWeek, hourPerDay);
                    if (result.length >= numDayToSchedule)
                        isEnd = true;
                }

                if (result.length < numDayToSchedule) {
                    //TERZO TENTATIVO: la schedualzione omogenea non è applicabile, si passa alla modalità a riempimento (standard) restituento tutti i giorni con almeno 1 ora libera
                    result = [];
                    for (let i = 0; i <= totalDays; i++) {
                        let current = new Date(start);
                        current.setDate(start.getDate() + i);
                        let currentMoment = moment(current, "DD/MM/YYYY hh:mm")
                        //se è nei giorni giusti della settimana
                        if (_.includes(daysOfWeek, currentMoment.day().toString())) {
                            //se quel giorno ha abbastanza ore
                            if (this.getHoursToSchedule(currentMoment, hourPerDay, false) >= 1)
                                result.push(new Date(current));
                        }
                    }
                }
            }

            return result;
        },

        createInternalElements: function (startDate, endDate, numElements, daysOfWeek, hourPerDay) {
            let start = new Date(startDate);
            let end = new Date(endDate);
            let numDayToSchedule = numElements / hourPerDay;

            // Calcola il numero totale di giorni tra startDate e endDate
            let totalDays = (end - start) / (1000 * 60 * 60 * 24);

            // Trova tutti i giorni della settimana desiderati nel periodo
            let allDaysOfWeek = [];
            for (let i = 0; i <= totalDays; i++) {
                let current = new Date(start);
                current.setDate(start.getDate() + i);
                let currentMoment = moment(current, "DD/MM/YYYY hh:mm")
                //se è nei giorni giusti della settimana
                if (_.includes(daysOfWeek, currentMoment.day().toString())) {
                    //se quel giorno ha abbastanza ore
                    if (this.getHoursToSchedule(currentMoment, hourPerDay, false) >= hourPerDay)
                        allDaysOfWeek.push(new Date(current));
                }
            }

            // Calcola l'intervallo per distribuire gli elementi omogeneamente
            let interval = (allDaysOfWeek.length - 1) / (numDayToSchedule - 1);

            // Seleziona gli elementi distribuiti omogeneamente
            let result = [];
            for (let i = 0; i < numDayToSchedule; i++) {
                if (!_.includes(result, allDaysOfWeek[Math.round(i * interval)]))
                    result.push(allDaysOfWeek[Math.round(i * interval)]);
            }

            return result;
        },


        includes: function (array, value) {
            return !!array.find(item => { return (new Date(item)).getTime() == (new Date(value)).getTime() });
        },

        /**
         * Prende in input i parametri per crear lo scheduling. data inizio, ora totali, ore per giorno e giorni della settimana
         * @param {object} configScheduling {startDate:DateTime, hourTot:number, hourPerDay:number, days:[number]}
         * @returns {[Deferred]} [Deferred](DataRow)
         */
        schedule: function (configScheduling) {
            var startDate = moment(configScheduling.startDate, "DD/MM/YYYY hh:mm");
            var stopDate = moment(configScheduling.stopDate, "DD/MM/YYYY hh:mm");
            var self = this;
            // prm per inserimento dati sulla tabella
            var dtSchedule = this.metaPage.getDataTable(this.tableNameSchedule);
            var meta = appMeta.getMeta(dtSchedule.tableForReading());
            // array di deffered con le nuove righe
            var arrayGetNewRow = [];
            var oreTotali = parseInt(configScheduling.hourTot);
            var currDate = startDate.clone();

            try {

                //se la distribuzione è omogenea devo calcolare pima le date
                let homogeneousDates = [];
                if (configScheduling.homogenization)
                    homogeneousDates = this.createElements(startDate, stopDate, oreTotali, configScheduling.days, configScheduling.hourPerDay);

                // creo giorni nello scheduler finchè ci sono ore disponibili
                var end = false;

                while (oreTotali > 0 && (!end)) {

                    // se esiste una data fine e il giorno è dopo esco dal while e mostro messaggio
                    if (this.endDate && (currDate.isAfter(moment(this.endDate)))) {
                        end = true;
                        this.logMaxHourPerDay += localResource.getLogSchedulerTooManyHours(
                            oreTotali,
                            moment(this.endDate).format("DD/MM/YYYY")) + "</br></br>";
                        break;
                    }

                    // se esiste una data fine impostata a mano e il giorno è dopo esco dal while e mostro messaggio
                    if (stopDate && (currDate.isAfter(moment(stopDate)))) {
                        end = true;
                        this.logMaxHourPerDay += localResource.getLogSchedulerTooManyHours(
                            oreTotali,
                            moment(stopDate).format("DD/MM/YYYY")) + "</br></br>";
                        break;
                    }

                    // quante ore rimangono? L'ultima giornata potrebbe avere meno ore, metto le rimanenti
                    var hourDurataLezione = parseInt(oreTotali >= configScheduling.hourPerDay ? configScheduling.hourPerDay : oreTotali);


                    if (
                        (!configScheduling.homogenization && _.includes(configScheduling.days, currDate.day().toString())) // se la distribuzione non è omogenea e se sto nel giorno della settimana corretto: 1=lunedi', 2=martedì, 0=domenica
                        ||
                        (configScheduling.homogenization && this.includes(homogeneousDates, currDate)) // se la distribuzione è omogenea e se sto nel giorno distribuito in modo omogeneo
                    ) {

                        // e se  ci sono abbastanza ore disponibili per schedulare
                        var hoursToScheduleForCurrDate = self.getHoursToSchedule(currDate, hourDurataLezione);
                        if (hoursToScheduleForCurrDate) {

                            // log nel caso l'ultimo giorno metto meno ore di quelle dell'attività, poichè avanzano.
                            if (hoursToScheduleForCurrDate < configScheduling.hourPerDay &&
                                (oreTotali - hoursToScheduleForCurrDate) <= 0) {
                                this.logMaxHourPerDay += localResource.getLogSchedulerLastDay(
                                    currDate.format("DD/MM/YYYY"),
                                    hoursToScheduleForCurrDate) + "</br></br>";
                            }

                            // creo la riga async, aggiungo nell'array che poi verrà risolto. nella closure passo i parametri correnti, risolti nella then async
                            arrayGetNewRow.push(
                                (function (d, h) {
                                    meta.setDefaults(dtSchedule);
                                    return meta.getNewRow(self.metaPage.state.currentRow.getRow(), dtSchedule)
                                        .then(function (newRow) {
                                            newRow.current[self.columnTitle] = self.columnTitleValue + " " + h + " ore";
                                            newRow.current[self.columnDate] = d.toDate();
                                            if (dtSchedule.columns[self.columnOre]) newRow.current[self.columnOre] = h;
                                            // è mutabile, quindi ne faccio il clone e aggiungo 1 ora
                                            var calcStartDate = d.clone();
                                            if (self.columnStop) newRow.current[self.columnStop] = calcStartDate.add(h, 'hours').toDate();

                                            if (configScheduling.aulaVal && self.chooseAula) {
                                                var objRow = JSON.parse(configScheduling.aulaVal);
                                                newRow.current.idaula = objRow.idaula;
                                                newRow.current.idedificio = objRow.idedificio;
                                                newRow.current.idsede = objRow.idsede;
                                            }

                                            // ====================================================================
                                            if (configScheduling.kindVal && self.chooseKind) {
                                                newRow.current.idrendicontaltrokind = parseInt(configScheduling.kindVal);
                                                if (!newRow.current.aa) {
                                                    newRow.current.aa = appMeta.currApp.currentMetaPage.getAAByDate(newRow.current[self.columnDate]);
                                                }
                                            }
                                            // ====================================================================
                                            if (self.chooseProject && configScheduling.progettoVal && configScheduling.workpackageVal && configScheduling.attivitaVal) {
                                                newRow.current.idprogetto = parseInt(configScheduling.progettoVal);
                                                newRow.current.idworkpackage = parseInt(configScheduling.workpackageVal);
                                                newRow.current.idrendicontattivitaprogetto = parseInt(configScheduling.attivitaVal);
                                                newRow.current.idreg = parseInt(self.metaPage.state.currentRow.idreg);
                                            }

                                            return true;
                                        });
                                })(currDate.clone(), hoursToScheduleForCurrDate)
                            );
                            // sottraggo ore che ho spalmato
                            oreTotali -= hoursToScheduleForCurrDate;
                        }
                    }
                    // giorno successivo
                    currDate.add(1, 'days');
                }
            } catch (err) {
                this.metaPage.showMessageOk("error on scheduling: " + err);
            }

            return arrayGetNewRow;
        },

        /**
         * Verify that the day is valid. It not in sospensione.
         * @param {moment} date
         * @param {number} hourDurataLezione
         * @returns {number} the hours schedulable | 0 if it si not possible to schedule for this date.
         */
        getHoursToSchedule: function (date, hourDurataLezione, log) {
            var isSospensione = false;
            if (appMeta.appMain.dtSospensioni) {
                // torna true se ricade fuori dalla sospensione
                isSospensione = !_.every(appMeta.appMain.dtSospensioni.rows, function (rowSosp) {
                    if (rowSosp.start && rowSosp.stop) return !(date.isSameOrAfter(moment(rowSosp.start)) && date.isSameOrBefore(moment(rowSosp.stop)));
                    return true;
                });
            }

            if (isSospensione) {
                if (log != false) this.logMaxHourPerDay += localResource.getSospDay(date.format("DD/MM/YYYY")) + "</br></br>";
                return 0;
            }

            var self = this;

            // osservo le ore max per giorno
            // sommo per questo giorno tutte le ore degli eventi + quelle che avrei messo
            var allEvents = self.metaPage.getCustomControl(self.calendarTag).getAllEvents();
            var eventsSameDay = _.filter(allEvents, function (ev) {
                ev.calculatedStart = moment(ev.row.start ? ev.row.start : (ev.row.data ? ev.row.data : null));
                ev.calculatedStop = ev.row.stop ? moment(ev.row.stop) : ev.calculatedStart;
                return ((!ev.allDay && ev.calculatedStart.isSame(date, 'day')) //o è un evento non all day allora vedo se è lo stesso giorno che sto controllando
                    ||//oppure l'evento è allday e lo start e lo stop contengono il giorno
                    (ev.allDay && date.isBetween(ev.calculatedStart, ev.calculatedStop, 'day', '[]')))
                    //escludendo le ore timbrate, consolidate, gli errori e le missioni
                    && ev.row.color != "slategray" && ev.row.color != "red" && ev.row.color != "Pink";
            });

            var hoursSameDay =
                _.sumBy(
                    eventsSameDay
                    ,
                    function (ev) {
                        // se c'è stop eseguo somma della differenza con start, altrimenti sommo il prm ore che mi aspetto
                        if (ev.end) {
                            if (ev.calculatedStart && ev.calculatedStop) {
                                //se l'evento dura più di un giorno, metto 24h
                                let diffHours = ev.calculatedStop.diff(ev.calculatedStart, 'hours', true);
                                return diffHours > 24 ? 24 : diffHours;
                            }
                            else {
                                return ev.row.ore;
                            }
                        }
                        return ev.row.ore;
                    }) || 0;

            // hourDurataLezione sono le ore che avrei messo per questo evento

            // calcola il max numero di ore al giorno schedulabili. di default sarà 24h
            var maxHoursPerDayRole = this.getMaxHourPerDay(date);
            // calcolo le ore che posso spalmare su questo giorno. cioè quelle che ho disponibili.
            var diffHourToAdd = maxHoursPerDayRole.maxHoursPerDay - hoursSameDay;
            // se le ore totali che dovrei inserire, comprese quelle che già ci sono, è oltre il limite metto, nel log e  vado avanti

            // 2 casi:
            // 1 spalmo. ci sono ancora ore nel giorno
            if (diffHourToAdd > 0) {
                if (diffHourToAdd < hourDurataLezione) {
                    if (log != false) this.logMaxHourPerDay += localResource.getLogSchedulerMaxHourPerDayDiff(date.format("DD/MM/YYYY"),
                        maxHoursPerDayRole.maxHoursPerDay,
                        hoursSameDay,
                        diffHourToAdd,
                        hourDurataLezione,
                        maxHoursPerDayRole.role) + "</br></br>";
                    // torno le ore che effettivamente andrò a schedulare, in base al numero di ore della attività (hourDurataLezione) passata come prm
                    return diffHourToAdd;
                }

                // ok torno direttamente il numero di ore disp
                return hourDurataLezione;
            }

            // 2. salto il giorno
            if (log != false) this.logMaxHourPerDay += localResource.getLogSchedulerMaxHourPerDay(date.format("DD/MM/YYYY"),
                maxHoursPerDayRole.maxHoursPerDay,
                maxHoursPerDayRole.role) + "</br></br>";
            return 0;
        },

        /**
         *
         * @param {moment} date
         * @returns {role:string, maxHoursPerDay:number}
         */
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
        }
    };

    appMeta.scheduleConfig = scheduleConfig;

}());
