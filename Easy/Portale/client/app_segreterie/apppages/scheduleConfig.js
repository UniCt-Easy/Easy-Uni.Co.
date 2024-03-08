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
        this.metaPage = metaPage;
        this.rootElement = metaPage.rootElement || document.body;

        this.maxHoursDay = 8;
        this.minHours = 1;

        this.endDate = objConf.endDate;
        this.minDateValue = objConf.minDateValue;
        this.tableNameSchedule = objConf.tableNameSchedule;
        this.columnDate = objConf.columnDate;
        this.columnOre = objConf.columnOre;
        this.columnTitle = objConf.columnTitle;
        this.columnTitleValue = objConf.columnTitleValue;
        this.columnStop = objConf.columnStop;
        this.maxHours = objConf.maxHours;
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
                    let oreRimaste = calcHoursRemain(page, selectedActivity[0].idrendicontattivitaprogetto, 'idrendicontattivitaprogetto'); //page.maxHours; //
                    $('#txtTotalHours').val(oreRimaste);
                    $("#txtTotalHours").prop('min', page.minHours);
                    $("#txtTotalHours").prop('max', oreRimaste);
                    //resetto la data di inizo
                    page.minDateValue = selectedActivity[0].activitystart;
                    var startDate = moment(page.minDateValue).format('DD/MM/YYYY');
                    $("#txtStartDate").val(startDate);
                }
            }
        },

        /**
         *
         * @returns {number}
         */
        getRemainingHours: function (page, parentKey, parentKeyName) {
            // calcolo le ore rimaneti da schedulare
            var totHours = page.maxHours;
            var self = page;
            var dtSchedule = page.metaPage.getDataTable(page.tableNameSchedule);
            var rowsToConsider = _.filter(dtSchedule.rows, function (r) {
                return r.getRow().state !== 'deleted' && (parentKey ? r[parentKeyName] == parentKey : true);
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
                        return r.getRow().state !== 'deleted' && (parentKey ? r[parentKeyName] == parentKey : true);
                    });
                    calcHoursRemain = calcHoursRemain - _.sumBy(externalRowsToConsider, function (row) {
                        return row.ore;
                    });

                }
            }
            return calcHoursRemain;
        },

        /**
         * Configures the controls at startup form
         * @param calcHoursRemain
         */
        setControls: function (calcHoursRemain) {
            this.calcHoursRemain = calcHoursRemain;
            var startDate = moment(this.minDateValue).format('DD/MM/YYYY');
            $("#txtStartDate").val(startDate);
            $('#txtTotalHours').val(calcHoursRemain);
            $("#txtTotalHours").prop('min', this.minHours);
            $("#txtTotalHours").prop('max', calcHoursRemain);

            if (this.columnStop) {
                // setto min date, cioè oltre quella data indietro non posso andare
                $("#txtStartDate").datetimepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: this.minDateValue
                });
            } else {
                // setto min date, cioè oltre quella data indietro non posso andare
                $("#txtStartDate").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: this.minDateValue
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
            var progettoVal = $('#selectProject').val();
            var workpackageVal = $('#selectWorkpackage').val();
            var attivitaVal = $('#selectActivity').val();
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

            that.forceClose();

            // creo le righe sulla tabella da schedulare, metto indicatore di attesa
            appMeta.modalLoaderControl.show(localResource.scheduler_running, false);
            var arrayGetNewRow = that.schedule({
                hourTot: hourTot,
                hourPerDay: hourPerDay,
                days: days,
                startDate: startDate,
                aulaVal: aulaVal,
                // ====================================================================
                kindVal: kindVal,
                // ====================================================================
                progettoVal: progettoVal,
                workpackageVal: workpackageVal,
                attivitaVal: attivitaVal
            });

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

        /**
         * Prende in input i parametri per crear lo scheduling. data inizio, ora totali, ore per giorno e giorni della settimana
         * @param {object} configScheduling {startDate:DateTime, hourTot:number, hourPerDay:number, days:[number]}
         * @returns {[Deferred]} [Deferred](DataRow)
         */
        schedule: function (configScheduling) {
            var startDate = moment(configScheduling.startDate, "DD/MM/YYYY hh:mm");
            var self = this;
            // prm per inserimento dati sulla tabella
            var dtSchedule = this.metaPage.getDataTable(this.tableNameSchedule);
            var meta = appMeta.getMeta(dtSchedule.tableForReading());
            // array di deffered con le nuove righe
            var arrayGetNewRow = [];
            var oreTotali = parseInt(configScheduling.hourTot);
            var currDate = startDate.clone();

            try {
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

                    // quante ore rimangono? L'ultima giornata potrebbe avere meno ore, metto le rimanenti
                    var hourDurataLezione = parseInt(oreTotali >= configScheduling.hourPerDay ? configScheduling.hourPerDay : oreTotali);


                    // se sto nel giorno della settimana corretto: 1=lunedi', 2=martedì, 0=domenica
                    if (_.includes(configScheduling.days, currDate.day().toString())) {

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
        getHoursToSchedule: function (date, hourDurataLezione) {
            var isSospensione = false;
            if (appMeta.appMain.dtSospensioni) {
                // torna true se ricade fuori dalla sospensione
                isSospensione = !_.every(appMeta.appMain.dtSospensioni.rows, function (rowSosp) {
                    if (rowSosp.start && rowSosp.stop) return !(date.isAfter(moment(rowSosp.start)) && date.isBefore(moment(rowSosp.stop)));
                    return true;
                });
            }

            if (isSospensione) {
                this.logMaxHourPerDay += localResource.getSospDay(date.format("DD/MM/YYYY")) + "</br></br>";
                return 0;
            }

            var self = this;

            // osservo le ore max per giorno
            // sommo per questo giorno tutte le ore degli eventi + quelle che avrei messo
            var allEvents = self.metaPage.getCustomControl(self.calendarTag).getAllEvents();
            var hoursSameDay =
                _.sumBy(
                    // filtro stesso giorno
                    _.filter(allEvents, function (ev) {
                        var start = ev.row.start ? ev.row.start : (ev.row.data ? ev.row.data : null);
                        //ritorno tutti gli eventi dello stesso giorno esclusi quelli
                        //grigi che rappresentano il monte ore lavorato
                        //rossi che rappresentano gli avvisi di errore
                        //rosa che sono le missioni e quindi è possibile schedulare ore durante le missioni
                        return moment(start).isSame(date, 'day') && ev.row.color != "slategray" && ev.row.color != "red" && ev.row.color != "Pink";
                    }),
                    function (ev) {
                        // se c'è stop eseguo somma della differenza con start, altrimenti sommo il prm ore che mi aspetto
                        if (ev.end) {
                            var start = ev.row.start ? ev.row.start : (ev.row.data ? ev.row.data : null);
                            var stop = ev.row.stop ? ev.row.stop : null;
                            if (start && stop) {
                                return Math.abs(stop.getTime() - start.getTime()) / 3600000;
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
                    this.logMaxHourPerDay += localResource.getLogSchedulerMaxHourPerDayDiff(date.format("DD/MM/YYYY"),
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
            this.logMaxHourPerDay += localResource.getLogSchedulerMaxHourPerDay(date.format("DD/MM/YYYY"),
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
