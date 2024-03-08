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

        this.minDateValue = objConf.minDateValue;
        this.tableNameSchedule = objConf.tableNameSchedule;
        this.columnDate = objConf.columnDate;
        this.columnOre = objConf.columnOre;
        this.columnTitle = objConf.columnTitle;
        this.columnTitleValue = objConf.columnTitleValue;
        this.columnStop = objConf.columnStop;
        this.maxHours = objConf.maxHours;
        this.chooseAula = objConf.chooseAula;
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
        getModalHtml:function () {
            var templateFileHtmlPath = appMeta.getMetaDataPath('scheduler') + "/scheduleConfig.html";
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
            this.dialogid = "dialogid" + utils.getUnivoqueId();
            this.dialogrootelement = $('<div id="' +  this.dialogid + '">');
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


            // calcolo le ore rimaneti da schedulare
            var calcHoursRemain = this.getRemainingHours();

            if (!calcHoursRemain) {
                this.metaPage.showMessageOk(localResource.scheduler_maxHoursScheduled);
                return this.def.resolve(true);
            }

            $("#" + this.dialogid).dialog({
                modal: true,
                autoResize:true,
                width: screen.width * 0.5,
                title: localResource.scheduler_title,
                open: function () {
                    // attacco html
                    $(this).html(htmlInfo);
                    self.setControls(calcHoursRemain);
                },
                close: function(event, ui) {
                    $(this).dialog("close");
                    self.dialogrootelement.remove();
                    self.def.resolve();
                },
                position: { my: "center bottom", at: "center center", of: window }
            });
            return this.def.promise();
        },

        /**
         *
         * @returns {number}
         */
        getRemainingHours:function() {
            // calcolo le ore rimaneti da schedulare
            var totHours = this.maxHours;
            var self = this;
            var dtSchedule = this.metaPage.getDataTable(this.tableNameSchedule);
            var rowsToConsider = _.filter( dtSchedule.rows, function (r) {
                return r.getRow().state !== 'deleted';
            });

            var calcHoursRemain;
            if (this.columnStop ) {
                // calcolo la somma delle ore allocate. eseguo diff tra start e stop
                calcHoursRemain = totHours - _.sumBy(rowsToConsider, function (row) {
                    return Math.abs(row[self.columnStop].getTime() - row[self.columnDate].getTime()) / 3600000;
                });
            } else {
                // orario fisso per giorno. quindi sommo il parametro ore
                calcHoursRemain = totHours - _.sumBy(rowsToConsider, function (row) {
                    return row.ore;
                });
            }
            return calcHoursRemain;
        },

        /**
         * Configures the controls at startup form
         * @param calcHoursRemain
         */
        setControls:function(calcHoursRemain) {
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
            $('#selectHours').each(function(index,row) {
                for(var i = 1; i <= maxSelHours; i++){
                    $(this).append($("<option>").text(i).val(i));
                }
            });
            
            // devo selzionare l'aula
            if (this.chooseAula) {
                $('#selectAula').select2();
                $('#selectAulaGroupId').show();
            }

            $("#btnScheduleOk").on("click", _.partial(this.createSchedule, this ));
        },

        forceClose:function() {
            $("#" + this.dialogid).dialog("close");
            this.dialogrootelement.remove();
        },

        /**
         * Returns the input to the caller. Resolve the deferred
         * @param that
         */
        createSchedule:function (that) {
            var hourTot = $('#txtTotalHours').val();
            var hourPerDay = $('#selectHours').val();
            var days = $('#selectDays').val(); // 1 lunedì...
            var aulaVal = $('#selectAula').val(); // 1 lunedì...
            var startDate =  $('#txtStartDate').val();

            // dati incompleti
            if (!hourTot || !hourPerDay || !days || ! startDate || !days.length) {
                that.metaPage.showMessageOk(localResource.scheduler_missing_fields);
                return;
            }

            if (hourTot > that.calcHoursRemain) {
                that.metaPage.showMessageOk(localResource.scheduler_max_hour_to_insert  + ": " + that.calcHoursRemain);
                return;
            }

            that.forceClose();

            // creo le righe sulla tabella da schedulare, metto indicatore di attesa
            appMeta.modalLoaderControl.show(localResource.scheduler_running, false);
            var arrayGetNewRow =  that.schedule({
                hourTot:hourTot,
                hourPerDay:hourPerDay,
                days:days,
                startDate:startDate,
                aulaVal: aulaVal
            });

            // risolvo le getNewRow e rinfreso la pagina
            $.when.apply($, arrayGetNewRow)
                .then(function () {
                    return that.metaPage.freshForm();
                }).then(function () {
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
        schedule:function(configScheduling) {
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
                while (oreTotali > 0) {

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
                                    meta.getNewRow(self.metaPage.state.currentRow.getRow(), dtSchedule)
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
        getHoursToSchedule:function (date, hourDurataLezione) {
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
            var hoursSameDay =
                    _.sumBy(
                        // filtro stesso giorno
                        _.filter(this.allEventsRows, function (row) {
                            return moment(row[self.columnDate]).isSame(date, 'day');
                        }),
                            function (row) {
                            // se c'è stop eseguo somma della differenza con start, altrimenti sommo il prm ore che mi aspetto
                            if (self.columnStop) return Math.abs(row[self.columnStop].getTime() - row[self.columnDate].getTime()) / 3600000;
                            return row.ore;
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
        getMaxHourPerDay:function (date) {
            var role = localResource.schedulerNoRoleDefined;
            var maxHoursPerDay =  this.maxHoursPerDay;
            var self = this;
            if (this.maxHoursPerDayTable) {
                _.forEach(this.maxHoursPerDayTable.rows, function (rowMaxDay) {
                    // se la data è compresa nell'intervallo allora torno il max numero di ore configurato su quell'intervallo
                    if (date.isAfter(moment(rowMaxDay.start)) &&
                        (date.isBefore(moment(rowMaxDay.stop)) || !rowMaxDay.stop)
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
