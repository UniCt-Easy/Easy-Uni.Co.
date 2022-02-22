
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
    var utils = appMeta.utils;
    var getData = appMeta.getData;
    var Deferred = appMeta.Deferred;
    var q = window.jsDataQuery;

    /**
     * @constructor Lezioni
     * @description
     * Esegue caricamento delle elzioni. chiama servizio di terze parti dal backend
     */
    function Lezioni() {
        // TODO fissato per ora a 1.
        this.idSede = 1;
    }

    Lezioni.prototype = {
        constructor: Lezioni,

        getAllocations:function(opts) {
            var self = this;
            // esegue la richiesta al servizio di unict. la url è cablata lato server. --> renderla configurabile
            var docenteNome = opts.docenteNome;
            var docenteCognome = opts.docenteCognome;
            var dataInizio = opts.dataInizio;
            var dataFine = opts.dataFine;
            this.metaPage = opts.metaPage;

            // trasformo formato date da "dd/MM/yyyy" in "yyyy-MM-ddT00:00:00"
            var stringTime = 'T00:00:00';
            dataInizio = dataInizio.split('/').reverse().join('-') + stringTime;
            dataFine = dataFine.split('/').reverse().join('-') + stringTime;

            var waitingHandler = this.metaPage.showWaitingIndicator('attendi chiamata servizio per caricamento lezioni , del sistema esterno');

            return appMeta.callWebService("getAllocations", {
                docenteCognome: docenteCognome,
                docenteNome: docenteNome,
                dataInizio: dataInizio,
                dataFine: dataFine
            }).then(function (res) {
                self.metaPage.hideWaitingIndicator(waitingHandler);
                return self.manageGetAllocationsResponse(res, self.metaPage);
            });
        },

        printItemIndex: function(msg, i) {
            document.getElementById("infoImportFileAllocationJson").innerHTML = msg + " item: " + i;
        },

        manageGetAllocationsResponse:function(json, metaPage) {
            var self = this;
            var corsostudioTableName = 'corsostudio';
            var corsostudioEditType = 'load';
            var obj = JSON.parse(json);
            var waitingHandler = metaPage.showWaitingIndicator('Attendi richiesta dataset e creazione righe su tabella Lezione');

            var onlyLezioniId = $("#onlyLezioniId").prop('checked');

            getData.getDataSet(corsostudioTableName, corsostudioEditType).then(function (ds) {
                if (obj.results && obj.results.length) {


                    var sliceIndex = parseInt($("#itemIndexLezioniId").val());
                    obj.results = obj.results.slice(sliceIndex);

                    var tname = 'lezione';
                    var dtMain = ds.tables[tname];
                    var meta = appMeta.getMeta(tname);

                    // INIZIO LOOP Aule -edificio
                    var chainAulaEdificio = $.when();
                    var chain = $.when();
                    var arrayAulaEdificio = [];


                    if (!onlyLezioniId) {
                        _.forEach(obj.results, function (item, index) {
                            chainAulaEdificio = chainAulaEdificio.then(function () {
                                metaPage.hideWaitingIndicator(waitingHandler);
                                waitingHandler = metaPage.showWaitingIndicator('Attendi costruzione righe aule edifici  ' + (sliceIndex + index + 1) + ' su righe json ' + obj.results.length);
                                // reset var globali
                                self.currEdificioRow = null;
                                self.currAulaRow = null;
                                return self.manageEdificio(ds, item)
                            }).then(function () {
                                return self.manageLezioneAula(ds, item);
                            }).then(function () {
                                metaPage.hideWaitingIndicator(waitingHandler);
                                waitingHandler = metaPage.showWaitingIndicator('salvo aule.edifici ' + (sliceIndex + index + 1) + ' su righe json ' + obj.results.length);
                                if (!self.isPostToDo ) {
                                    return true;
                                }
                                self.isPostToDo = false;
                                return appMeta.postData.doPostSilent(ds, corsostudioTableName, corsostudioEditType, []);
                            }).then(function (res, msg) {
                                metaPage.hideWaitingIndicator(waitingHandler);
                                if (!res && msg && msg.length) {
                                    var s = msg.reduce(function (acc, m) {
                                        acc += m.description + '\n';
                                        return acc;
                                    }, '');
                                    return metaPage.showMessageOk(s)
                                }
                                if (res) {
                                    self.printItemIndex('item salvato aula-edifici', (index + 1) + sliceIndex + ' su righe json ' + obj.results.length);
                                    return true;
                                    // return metaPage.showMessageOk('Aule-Edifici ' + (index + 1) + ' salvati con successo')
                                }
                            }, function (err) {
                                metaPage.hideWaitingIndicator(waitingHandler);
                                return false;
                            });
                            arrayAulaEdificio.push(chainAulaEdificio);
                        });
                        // FINE LOOP AULE-EDIFICIO
                    }

                    return $.when.apply($, arrayAulaEdificio)
                        .then(function(res) {
                            metaPage.hideWaitingIndicator();

                            _.forEach(obj.results, function (item, index) {

                                chain = chain.then(function () {
                                    waitingHandler = metaPage.showWaitingIndicator('Attendi creazione lezione ' + (sliceIndex + index + 1) + ' su righe json ' + obj.results.length);
                                    // calcolo chiavi. devo recuperare l'idAffidamento
                                    var rowAffidamento; // riga affidamento padre di elzione da trovare!
                                    var idreg_docenti;
                                    var start;
                                    var stop;

                                    return self.manageEdificio(ds, item)
                                        .then(function(){
                                            return self.manageLezioneAula(ds, item)
                                        })
                                        .then(function() {
                                            return self.lezioneDidProg(item)
                                                .then(function (idsdidProg) {
                                                        // se non trovo didattica prog. esco
                                                        if (!idsdidProg) {
                                                            metaPage.hideWaitingIndicator(waitingHandler);
                                                            return true;
                                                        }
                                                        return self.lezioneDidProgAnno(idsdidProg, item)
                                                            .then(function (idsdidProg, idsdidProgAnno) {
                                                                // se non trovo didattica prog. esco
                                                                if (!idsdidProgAnno) {
                                                                    metaPage.hideWaitingIndicator(waitingHandler);
                                                                    return true;
                                                                }
                                                                return self.lezioneInsegn(idsdidProg, idsdidProgAnno, item)
                                                                    .then(function (idsdidProg, idsdidProgAnno, idInsegn) {

                                                                        return self.lezioneInsegInteg(idsdidProg, idsdidProgAnno, idInsegn, item)

                                                                            .then(function (idsdidProg, idsdidProgAnno, idInsegn, insegninteg) {

                                                                                var q1 = q.eq('iddidprog', idsdidProg);
                                                                                var q2 = q.eq('iddidproganno', idsdidProgAnno);
                                                                                var filter= q.and([q1, q2]);
                                                                                var q3;
                                                                                var q4;
                                                                                // a seconda esistenza
                                                                                if (idInsegn && insegninteg) {
                                                                                    q3 = q.eq('idinsegn', idInsegn);
                                                                                    q4 = q.eq('idinsegninteg', insegninteg);
                                                                                    var qor = q.or(q3, q4);
                                                                                    filter = q.and([q1, q2, qor]);
                                                                                }
                                                                                if (idInsegn && !insegninteg) {
                                                                                    q3 = q.eq('idinsegn', idInsegn);
                                                                                    filter = q.and([q1, q2, q3]);
                                                                                }
                                                                                if (!idInsegn && insegninteg) {
                                                                                    q4 = q.eq('idinsegninteg', insegninteg);
                                                                                    filter = q.and([q1, q2, q4]);
                                                                                }
                                                                                return self.lezioneAttivform(idsdidProg, idsdidProgAnno, idInsegn, insegninteg, filter)

                                                                                    .then(function (idsdidProg, idsdidProgAnno, idInsegn, insegninteg, idsAttivForm) {

                                                                                            if (!idsAttivForm) {
                                                                                                console.log('attivform non trovata', item);
                                                                                                metaPage.hideWaitingIndicator(waitingHandler);
                                                                                                return true;
                                                                                            }

                                                                                            var q1 = q.eq('iddidprog', idsdidProg);
                                                                                            var q2 = q.eq('iddidproganno', idsdidProgAnno);
                                                                                            var q3 = q.eq('idattivform ', idsAttivForm);
                                                                                            var q4 = q.eq('title', item.partition);
                                                                                            var filter = q.and([q1, q2, q3, q4]);

                                                                                        return self.lezioneCanale(idsdidProg, idsdidProgAnno, idInsegn, insegninteg, idsAttivForm, filter)

                                                                                                .then(function (idsdidProg, idsdidProgAnno, idInsegn, insegninteg, idsAttivForm, idcanale) {

                                                                                                    if (!idcanale) {
                                                                                                        console.log('canal non trovato', item);
                                                                                                        metaPage.hideWaitingIndicator(waitingHandler);
                                                                                                        return true;
                                                                                                    }

                                                                                                    var filter = q.like('titleforenamesurname', item.courseOwner);

                                                                                                    if(!item.courseOwner) {
                                                                                                        console.log('item.courseOwner vuoto', item);
                                                                                                        metaPage.hideWaitingIndicator(waitingHandler);
                                                                                                        return true;
                                                                                                    }


                                                                                                    // -----------------------------------> select idreg
                                                                                                    return getData.runSelect('registrytitleview ', "idreg", filter)
                                                                                                        .then(function (dtReg) {

                                                                                                            if (dtReg.rows.length === 0) {
                                                                                                                metaPage.hideWaitingIndicator(waitingHandler);
                                                                                                                return null;
                                                                                                            }
                                                                                                            var idregs = _.map(dtReg.rows , function(r) {
                                                                                                                return r.idreg;
                                                                                                            });

                                                                                                            var q1 = q.eq('iddidprog', idsdidProg);
                                                                                                            var q2 = q.eq('iddidproganno', idsdidProgAnno);
                                                                                                            var q3 = q.eq('idattivform ',idsAttivForm);
                                                                                                            var q4 = q.eq('idcanale', idcanale);
                                                                                                            var q5 = q.isIn('idreg_docenti', idregs); // ----------------------------------------> In
                                                                                                            var filterAffidamento = q.and([q1, q2, q3, q4, q5]);
                                                                                                            var dta = ds.tables.affidamento;
                                                                                                            // recupero ed inserisco sul DS. così poi la posso aggiornare per il calcolo della stop e start.
                                                                                                            return getData.runSelectIntoTable(dta,  filterAffidamento, 1)
                                                                                                        })
                                                                                                        .then(function () {
                                                                                                                var dtAffidamento = ds.tables.affidamento;
                                                                                                                if (!dtAffidamento) {
                                                                                                                    return null;
                                                                                                                }

                                                                                                                if (dtAffidamento.rows.length === 0) {
                                                                                                                    return null;
                                                                                                                }

                                                                                                                var rowsAffidamento = _.filter(dtAffidamento.rows, {iddidprog: idsdidProg, iddidproganno:idsdidProgAnno, idcanale: idcanale, idattivform:idsAttivForm });
                                                                                                                if (rowsAffidamento.length === 0) {
                                                                                                                    return null;
                                                                                                                }

                                                                                                                rowAffidamento = rowsAffidamento[0];

                                                                                                                start = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(item.allocationStartTime), true);
                                                                                                                stop = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(item.allocationEndTime), true);
                                                                                                                var qf = q.and(
                                                                                                                    [
                                                                                                                        q.eq('idaffidamento',rowAffidamento.idaffidamento ),
                                                                                                                        q.eq('idcanale',rowAffidamento.idcanale ),
                                                                                                                        q.eq('idattivform',rowAffidamento.idattivform ),
                                                                                                                        q.eq('iddidprogporzanno',rowAffidamento.iddidprogporzanno ),
                                                                                                                        q.eq('iddidprog',rowAffidamento.iddidprog ),
                                                                                                                        q.eq('iddidprogcurr',rowAffidamento.iddidprogcurr ),
                                                                                                                        q.eq('iddidprogori',rowAffidamento.iddidprogori ),
                                                                                                                        q.eq('iddidproganno',rowAffidamento.iddidproganno ),
                                                                                                                        q.eq('idsede',rowAffidamento.idsede ),
                                                                                                                        q.eq('aa',rowAffidamento.aa ),
                                                                                                                        q.eq('idreg_docenti',rowAffidamento.idreg_docenti ),
                                                                                                                        q.eq('idaffidamento',rowAffidamento.idaffidamento ),
                                                                                                                        q.eq('start', start),
                                                                                                                        q.eq('stop', stop),
                                                                                                                        q.eq('idaula', self.currAulaRow.idaula ),
                                                                                                                        q.eq('idedificio', self.currEdificioRow.idedificio )
                                                                                                                    ]
                                                                                                                );

                                                                                                                var rowsLezione = dtMain.select(qf);
                                                                                                                if (rowsLezione.length) {
                                                                                                                    return null;
                                                                                                                }

                                                                                                                return getData.runSelect(tname, "*", qf)
                                                                                                                    .then(function (table) {
                                                                                                                        // se non esiste creo riga
                                                                                                                        return appMeta.utils._if(table && table.rows.length)
                                                                                                                            ._then(function () {
                                                                                                                                return null;
                                                                                                                            })
                                                                                                                            ._else(function () {
                                                                                                                                meta.setDefaults(dtMain);
                                                                                                                                return meta.getNewRow(null, dtMain);
                                                                                                                            });
                                                                                                                    });
                                                                                                            }).then(function (row) {
                                                                                                                    if (!row) {
                                                                                                                        metaPage.hideWaitingIndicator(waitingHandler);
                                                                                                                        return true;
                                                                                                                    }

                                                                                                                    // calcolo start e  stop di affidamento, se la nuova stop della lezione "è dopo", allora metto come nuova stop
                                                                                                                    // sull'affidamento. e la riga verrà aggiornata. stessa cosa se è null per qualche motivo.
                                                                                                                    if (stop) {
                                                                                                                        if (rowAffidamento.stop) {
                                                                                                                            if (moment(stop).isAfter(moment(rowAffidamento.stop))) {
                                                                                                                                rowAffidamento.stop = stop;
                                                                                                                            }
                                                                                                                        } else {
                                                                                                                            rowAffidamento.stop = stop;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    // per la start vale la stessa cosa, solo che verifica se sta prima
                                                                                                                    if (start) {
                                                                                                                        if (rowAffidamento.start) {
                                                                                                                            if (moment(start).isBefore(moment(rowAffidamento.start))) {
                                                                                                                                rowAffidamento.start = start;
                                                                                                                            }
                                                                                                                        } else {
                                                                                                                            rowAffidamento.start = start;
                                                                                                                        }
                                                                                                                    }

                                                                                                                    row.current.idaffidamento = rowAffidamento.idaffidamento;
                                                                                                                    row.current.idcanale = rowAffidamento.idcanale;
                                                                                                                    row.current.idattivform = rowAffidamento.idattivform;
                                                                                                                    row.current.iddidprogporzanno = rowAffidamento.iddidprogporzanno;
                                                                                                                    row.current.iddidprog = rowAffidamento.iddidprog;
                                                                                                                    row.current.iddidprogcurr = rowAffidamento.iddidprogcurr;
                                                                                                                    row.current.idcorsostudio = rowAffidamento.idcorsostudio;
                                                                                                                    row.current.iddidprogori = rowAffidamento.iddidprogori;
                                                                                                                    row.current.iddidproganno = rowAffidamento.iddidproganno;
                                                                                                                    row.current.idsede = rowAffidamento.idsede;
                                                                                                                    row.current.aa = rowAffidamento.aa;
                                                                                                                    row.current.idreg_docenti = rowAffidamento.idreg_docenti;
                                                                                                                    row.current.visita = 'N';
                                                                                                                    row.current.nonsvolta = 'N';
                                                                                                                    row.current.stage = 'N';
                                                                                                                    row.current.start = start;
                                                                                                                    row.current.stop = stop;
                                                                                                                    row.current.idaula = self.currAulaRow.idaula; // self.findIdaula(ds, item);
                                                                                                                    row.current.idedificio = self.currEdificioRow.idedificio; //self.findidEdificio(ds, item);
                                                                                                                    self.affidamentiBuiltCounter = !self.affidamentiBuiltCounter ? 1 : (self.affidamentiBuiltCounter + 1);

                                                                                                                    self.LezioniRowCounter =   self.LezioniRowCounter ? self.LezioniRowCounter + 1 : 1;
                                                                                                                    document.getElementById("infoAffidamenti").innerHTML = " lezioni create da salvare: " + self.LezioniRowCounter;

                                                                                                                    metaPage.hideWaitingIndicator(waitingHandler);
                                                                                                                    return true;
                                                                                                                });
                                                                                                            });
                                                                                });
                                                                        });
                                                                });
                                                        });
                                                });
                                        });
                                })
                            }); // fine foreach

                            return chain.then(
                                function () {
                                    metaPage.hideWaitingIndicator();
                                    console.log('AFFIDAMENTI DA CREARE ' +  self.affidamentiBuiltCounter);
                                    waitingHandler = metaPage.showWaitingIndicator('salvo lezioni ' + ds.tables.lezione.rows.length);
                                    return appMeta.postData.doPostSilent(ds, corsostudioTableName, corsostudioEditType, [])
                                }).then(function (res, msg) {
                                    metaPage.hideWaitingIndicator(waitingHandler);
                                    if (!res && msg && msg.length) {
                                        var s = msg.reduce(function (acc, m) {
                                            acc += m.description + '\n';
                                            return acc;
                                        }, '');
                                        return metaPage.showMessageOk(s)
                                    }
                                    if (res) {
                                        return metaPage.showMessageOk( ds.tables.lezione.rows.length + ' Lezioni salvate con successo');
                                    }
                            }, function (err) {
                                console.log(err);
                                metaPage.hideWaitingIndicator(waitingHandler);
                            });

                        });
                } // fine if obj.result
            });
        },

        manageEdificio:function(ds, item) {
            var self = this;
            var tname = 'edificio';
            var dtMain = ds.tables[tname];
            var def = appMeta.Deferred('manageEdificio');
            var spacePath = item.spacePath; // "CITTADELLA UNIVERSITARIA  > EDIFICIO 1 - SCIENZE CHIMICHE",
            var edificioInfoArr = spacePath.split(">");
            var edificioTitle = edificioInfoArr[1].trim();

            var filter  = q.eq("title", edificioTitle);

            // se già c'è
            var rows = dtMain.select(filter);
            if (rows.length) {
                self.currEdificioRow = rows[0];
                return def.resolve();
            }

            getData.runSelect(tname, "*", filter)
                .then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function (){
                            dtMain.load(table.rows[0]);
                            self.currEdificioRow = table.rows[0];
                            return def.resolve();
                        })
                        ._else(function () {
                            var meta = appMeta.getMeta(tname);
                            meta.setDefaults(dtMain);
                            return meta.getNewRow(null, dtMain)
                                .then(function (row) {
                                    if (!row) {
                                        return def.resolve();
                                    }
                                    row.current.idsede = self.idSede;
                                    row.current.title = edificioTitle;

                                    self.currEdificioRow = row.current;

                                    self.isPostToDo = true;

                                    return def.resolve();
                                });
                        });
                });

            return def.promise();
        },

        manageLezioneAula:function(ds, item) {
            var self = this;
            var tname = 'aula';
            var dtMain = ds.tables[tname];
            var def = Deferred('manageLezioneAula');
            var code = item.spaceCode;
            var title = item.spaceName;
            var edificioInfoArr = item.spacePath.split(">");
            var edificioTitle = edificioInfoArr[1].trim();

            var filter  = q.eq("code", code);

            if (!code) {
                console.log('item.spaceCode vuto', item);
                return def.resolve();
            }

            // se già c'è
            var rows = dtMain.select(filter);
            if (rows.length) {
                self.currAulaRow = rows[0];
                return def.resolve();
            }

            getData.runSelect(tname, "*", filter)
                .then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function (){
                            dtMain.load(table.rows[0]);
                            self.currAulaRow = table.rows[0];
                            return def.resolve();
                        })
                        ._else(function () {
                            var meta = appMeta.getMeta(tname);
                            meta.setDefaults(dtMain);
                            return meta.getNewRow(null, dtMain)
                                .then(function (row) {
                                    if (!row) {
                                        return def.resolve();
                                    }

                                    var filterEdificio  = q.eq("title", edificioTitle);
                                    var rows = ds.tables.edificio.select(filterEdificio);
                                    row.current.idedificio = rows[0].idedificio;
                                    row.current.title = title;
                                    row.current.code = code;
                                    row.current.idsede = self.idSede;
                                    self.currAulaRow = row.current;
                                    self.isPostToDo = true;
                                    return def.resolve();
                                });
                        });
                });

            return def.promise();
        },

        lezioneDidProg:function(item) {
            var def = Deferred('lezioneDidProg');
            var codice = item.contextCode;
            if (!codice) {
                return def.resolve();
            }
            var filter = q.eq('codicemiur', codice);
            return getData.runSelect('didprog',"iddidprog,codicemiur", filter)
                .then(function (dt) {
                    var id = dt.rows.length ? dt.rows[0].iddidprog : null;
                    return def.resolve(id);
                });
        },

        lezioneDidProgAnno:function(idsdidProg, item) {
            var def = Deferred('lezioneDidProgAnno');
            var q1 = q.eq('iddidprog', idsdidProg);

            if (!item.yearsJS) {
                return def.resolve(idsdidProg, null);
            }
            var years = item.yearsJS.split(",");

            var q2 = q.isIn('anno', years);
            var filter = q.and(q1, q2);
            return getData.runSelect('didproganno',"iddidproganno ", filter)
                .then(function (dt) {
                    var iddidproganno = dt.rows.length ? dt.rows[0].iddidproganno : null;
                    return def.resolve(idsdidProg, iddidproganno);
                });
        },

        lezioneInsegn:function(idsdidProg, idsdidProgAnno, item) {
            var def = Deferred('lezioneInsegn');


            if(!item.courseCode) {
                return def.resolve(idsdidProg, idsdidProgAnno, null);
            }
            var filter = q.eq('codice', item.courseCode.toString());
            return getData.runSelect('insegn',"idinsegn,codice", filter)
                .then(function (dt) {
                    var idinsegn = dt.rows.length ? dt.rows[0].idinsegn : null;
                    return def.resolve(idsdidProg, idsdidProgAnno, idinsegn);
                });
        },

        lezioneInsegInteg:function(idsdidProg, idsdidProgAnno, idInsegn, item) {
            var def = Deferred('lezioneInsegInteg');
            if(!item.courseCode) {
                return def.resolve(idsdidProg, idsdidProgAnno, idInsegn, null);
            }
            var filter = q.eq('codice', item.courseCode.toString());
            return getData.runSelect('insegninteg', "idinsegninteg,codice", filter)
                .then(function (dt) {
                    var insegninteg = dt.rows.length ? dt.rows[0].idinsegninteg : null;
                    return def.resolve(idsdidProg, idsdidProgAnno, idInsegn, insegninteg)
                });
        },

        lezioneAttivform:function(idsdidProg, idsdidProgAnno, idInsegn, insegninteg, filter) {
            var def = Deferred('lezioneAttivform');
            return getData.runSelect('attivform', "idattivform", filter)
                .then(function (dt) {
                    var idsAttivForm = dt.rows.length ? dt.rows[0].idattivform : null;
                    return def.resolve(idsdidProg, idsdidProgAnno, idInsegn, insegninteg, idsAttivForm)
                });
        },

        lezioneCanale:function (idsdidProg, idsdidProgAnno, idInsegn, insegninteg, idsAttivForm, filter) {
            var def = Deferred('lezioneCanale');
            return getData.runSelect('canale', "idcanale", filter)
                .then(function (dt) {
                    var idcanale = dt.rows.length ? dt.rows[0].idcanale : null;
                    return def.resolve(idsdidProg, idsdidProgAnno, idInsegn, insegninteg, idsAttivForm, idcanale)
                });
        }

    };

    appMeta.Lezioni = new Lezioni();
}());
