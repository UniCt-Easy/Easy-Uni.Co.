(function () {

    var MetaSegreteriePage = window.appMeta.MetaSegreteriePage;
    var getData = window.appMeta.getData;
    var Deferred = appMeta.Deferred;

    function metaPage_registryAdmin() {
        MetaSegreteriePage.apply(this, ['registry', 'admin', false]);
        this.name = 'Funzioni di admin';
        this.defaultListType = 'admin';
        this.searchEnabled = false;
        this.canInsert = false;
        this.canInsertCopy = false;
        this.canSave = false;
        this.canCancel = false;
        this.canCmdClose = true;
        this.canShowLast = false;

        // inizializzo righe notevoli, utilizzate per calcolo json e title nel caricamento del carico didattico
        this.currtipoattform = null;
        this.currambitoareadisc = null;
        this.currsasd = null;
        this.currsasdList = {}; // dictionary calcolata ad ogni ciclo

        this.didProgCache = {};

        // TODO fissato per ora a 1.
        this.idSede = 1;
    }

    metaPage_registryAdmin.prototype = _.extend(
        new MetaSegreteriePage(),
        {
            constructor: metaPage_registryAdmin,
            superClass: MetaSegreteriePage.prototype,

            getName: function () {
                return this.name;
            },

            afterLink: function () {
                $("#registerBtn").on("click", _.partial(this.registerUser, this));
                $("#clearSessionBtn").on("click", _.partial(this.clearSessions, this));
                $("#clearCacheBtn").on("click", _.partial(this.clearServerCache, this));
                $("#pwdDbBtn").on("click", _.partial(this.codificaPwdDb, this));
                $("#btnshowPasswordDb").on("click", _.partial(this.showHidePassword, this));
                $("#btngetCaricoDidattico").on("click", _.partial(this.getCaricoDidattico, this));
                $("#btngetCaricoDidatticoJson").on("click", _.partial(this.getCaricoDidatticoJson, this));
                $("#btngetAllocationsDebug").on("click", _.partial(this.getAllocationsDebug, this));
                $("#btngetAllocations").on("click", _.partial(this.getAllocations, this));

                // carico didattico
                $("#idUploadFileJson").on("change", _.partial(this.selectJsonFileCaricoDidattico, this));
                $("#btngetCaricoDidatticoJsonFile").on("click", _.partial(this.getCaricoDidatticoJsonFile, this));

                //lezioni
                $("#idUploadFileAllocationJson").on("change", _.partial(this.selectJsonFileAllocation, this));
                $("#btngetAllocationJsonFile").on("click", _.partial(this.getAllocationJsonFile, this));
                $("#btngetAllocationsMassivo").on("click", _.partial(this.getAllocationMassivo, this));

                $("#btnSaveDataset").on("click", _.partial(this.simulatedoPostSilent, this));

                $("#dataInizioGetAllId").datepicker({ dateFormat: 'dd/mm/yy' });
                $("#dataFineGetAllId").datepicker({ dateFormat: 'dd/mm/yy' });

                //Nuovi WS 16-11-'22
                //Zucchetti timbrature
                $("#btngetTimbrature").on("click", _.partial(this.getTimbrature, this));
                $("#dataInizioTimbrature").datepicker({ altFormat: "mm-dd-yy", altField: "#alt_dataInizioTimbrature" });
                $("#dataFineTimbrature").datepicker({ altFormat: "mm-dd-yy", altField: "#alt_dataFineTimbrature" });

                //18-11-'22 - Visper costo orario del personale
                $("#btngetCostoOrario").on("click", _.partial(this.getCostoOrario, this));
                $("#dataInizioCostoOrario").datepicker({ altFormat: "mm-dd-yy", altField: "#alt_dataInizioCostoOrario" });
                $("#dataFineCostoOrario").datepicker({ altFormat: "mm-dd-yy", altField: "#alt_dataFineCostoOrario" });
            },

            selectJsonFileCaricoDidattico: function (that, event) {
                if (event.target.files.length > 0) {
                    that.jsonFileCaricoDidattico = event.target.files[0];
                }
            },

            selectJsonFileAllocation: function (that, event) {
                if (event.target.files.length > 0) {
                    that.jsonFileAllocations = event.target.files[0];
                }
            },


            lezioneDidProg: function (item) {
                var def = Deferred('lezioneDidProg');
                var codice = item.contextCode;
                var q = this.q.eq('codicemiur', codice);
                return getData.runSelect('didprog', "iddidprog,codicemiur", q)
                    .then(function (dt) {
                        // didattiche programmate con quel codice
                        var ids = _.map(dt.rows, function (r) {
                            return r.iddidprog;
                        });
                        return def.resolve(ids);
                    });
            },

            lezioneDidProgAnno: function (idsdidProg, item) {
                var def = Deferred('lezioneDidProgAnno');
                var q1 = this.q.isIn('iddidprog', idsdidProg);
                var q2 = this.q.eq('anno', item.yearsJS);
                var q = this.q.and(q1, q2);
                return getData.runSelect('didproganno ', "iddidproganno ", q)
                    .then(function (dt) {
                        var ids = _.map(dt.rows, function (r) {
                            return r.iddidproganno;
                        });
                        return def.resolve([idsdidProg, ids]);
                    });
            },

            lezioneInsegn: function (ids, item) {
                var def = Deferred('lezioneDidProgAnno');
                var q = this.q.eq('codice', item.courseCode);
                return getData.runSelect('insegn ', "idinsegn,codice", q)
                    .then(function (dt) {
                        var idinsegn = dt.rows.length ? dt.rows[0].idinsegn : null;
                        ids.push(idinsegn);
                        return def.resolve(ids);
                    });
            },

            manageCorsoStudio: function (ds, item, annoistituzione) {
                var self = this;
                var tname = 'corsostudio';
                var dtMain = ds.tables[tname];

                var def = Deferred('manageCorsoStudio');
                var codicione = item.Codicione;
                var title = item.ProgrammazioneDenominazione;
                var title_en = item.ProgrammazioneDenominazione_EN;
                var codiceCorso = item.CodiceCorso;
                var programmazionefacolta = item.ProgrammazioneFacolta;
                var filter = this.q.eq("codicemiur", codiceCorso);
                var idStruttura = null;
                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currCorsoStudioRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currCorsoStudioRow = table.rows[0];
                                return def.resolve();
                            })
                            ._else(function () {
                                var meta = appMeta.getMeta(tname);
                                self.getIdStruttura(programmazionefacolta)
                                    .then(function (id) {
                                        meta.setDefaults(dtMain);
                                        idStruttura = id;
                                        return meta.getNewRow(null, dtMain);
                                    }).then(function (row) {
                                        if (!row) {
                                            return def.resolve();
                                        }
                                        row.current.codicemiur = codiceCorso;
                                        row.current.codicemiurlungo = codicione;
                                        row.current.title = title;
                                        row.current.title_en = title_en;
                                        row.current.idstruttura = idStruttura;
                                        row.current.annoistituz = annoistituzione;
                                        self.currCorsoStudioRow = row.current;
                                        return def.resolve();
                                    });
                            });
                    });

                return def.promise();
            },

            manageCorsoStudioClasseScuola: function (ds, item) {
                var def = Deferred('manageCorsoStudioClasseScuola');
                var self = this;
                var tname = 'corsostudioclassescuola';
                var dtMain = ds.tables[tname];
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;

                var classeDiLaurea = item.ClasseDiLaurea;

                getData.runSelect("classescuola", "*", this.q.eq('sigla', classeDiLaurea))
                    .then(function (dt) {

                        if (!dt.rows.length) {
                            console.log('classeDiLaurea ' + classeDiLaurea + ' vuota', item);
                            return def.resolve();
                        }

                        var idclassescuola = dt.rows[0].idclassescuola;
                        var filter = self.q.and(
                            self.q.eq("idcorsostudio", idcorsostudio),
                            self.q.eq("idclassescuola", idclassescuola)
                        );
                        // se già c'è
                        if (dtMain.select(filter).length) {
                            return def.resolve();
                        }
                        getData.runSelect(tname, "*", filter).then(function (table) {
                            // se non esiste creo riga
                            appMeta.utils._if(table && table.rows.length)
                                ._then(function () {
                                    dtMain.load(table.rows[0]);
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
                                            row.current.idcorsostudio = idcorsostudio;
                                            row.current.idclassescuola = idclassescuola;
                                            return def.resolve();
                                        })
                                });
                        });
                    });

                return def.promise();
            },

            getIdStruttura: function (programmazionefacolta) {
                var def = Deferred('manageDidProg');
                getData.runSelect("strutturadefaultview", "idstruttura,title")
                    .then(function (dt) {
                        var idstrutturaObj = _.find(dt.rows, function (row) {
                            return row.title.toUpperCase().trim() === programmazionefacolta.toUpperCase().trim();
                        });
                        if (idstrutturaObj) {
                            return def.resolve(idstrutturaObj.idstruttura)
                        }
                        return def.resolve(null)
                    });

                return def.promise();
            },

            manageDidErog: function (ds, item) {
                var def = Deferred('manageDidErog');
                var self = this;
                var tname = 'diderog';
                var dtMain = ds.tables[tname];
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var annoAccademico = item.AnnoAccademico;

                var filter = self.q.and(
                    self.q.eq("idcorsostudio", idcorsostudio),
                    self.q.eq("aa", annoAccademico)
                );
                var rows = dtMain.select(filter);
                if (rows.length) {
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter).then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function () {
                            dtMain.load(table.rows[0]);
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
                                    row.current.idcorsostudio = idcorsostudio;
                                    row.current.aa = annoAccademico;
                                    row.current.idsede = 1;
                                    row.current.inesaurimento = 'N';
                                    return def.resolve();
                                })
                        });
                });

                return def.promise();
            },

            manageDidProg: function (ds, item) {
                var def = Deferred('manageDidProg');
                var self = this;
                var tname = 'didprog';
                var dtMain = ds.tables[tname];
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var programmazionefacolta = item.ProgrammazioneFacolta;

                var title = item.ProgrammazioneDenominazione;
                var title_en = item.ProgrammazioneDenominazione_EN;
                var annoAccademico = item.AnnoAccademico;
                var codiceCorso = item.CodiceCorso;
                var annosolare = annoAccademico.split("/")[0];
                var unitaTemporale = item.UnitaTemporale;

                var annoCorso = item.AnnoCorsoNumber;
                var annoDidProgPartenza = annosolare - annoCorso + 1;
                var annoDidProg = annoDidProgPartenza + "/" + (annoDidProgPartenza + 1);

                this.getIdStruttura(programmazionefacolta)
                    .then(function (idstruttura) {
                        var filter = self.q.and(
                            self.q.eq("codicemiur", codiceCorso),
                            self.q.eq("aa", annoDidProg)
                        );
                        var rows = dtMain.select(filter);
                        if (rows.length) {
                            self.currDidprogRow = rows[0];
                            return def.resolve();
                        }

                        getData.runSelect(tname, "*", filter).then(function (table) {
                            // se non esiste creo riga
                            appMeta.utils._if(table && table.rows.length)
                                ._then(function () {
                                    dtMain.load(table.rows[0]);
                                    self.currDidprogRow = table.rows[0];
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
                                            row.current.idcorsostudio = idcorsostudio;
                                            row.current.codicemiur = codiceCorso;
                                            row.current.title = title;
                                            row.current.title_en = title_en;
                                            row.current.aa = annoDidProg;
                                            row.current.idsede = 1;
                                            row.current.annosolare = annosolare;
                                            switch (unitaTemporale.toUpperCase()) {
                                                case "PRIMO SEMESTRE":
                                                    row.current.iddidprogsuddannokind = 5; //semestrale
                                                    break;
                                                case "SECONDO SEMESTRE":
                                                    row.current.iddidprogsuddannokind = 5; //semestrale
                                                    break;
                                                default:
                                                    var a = 0;
                                            }
                                            self.currDidprogRow = row.current;
                                            return def.resolve();
                                        })
                                });
                        });
                    });

                return def.promise();
            },

            manageDidProgCurr: function (ds, item) {
                var def = Deferred('manageDidProgCurr');
                var self = this;
                var tname = 'didprogcurr';
                var dtMain = ds.tables[tname];

                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;

                var title = item.Curriculum;
                var codice = item.CodiceCurriculum ? item.CodiceCurriculum : '';

                var filter;
                if (codice) {
                    filter = self.q.and([
                        self.q.eq("title", title),
                        self.q.eq("iddidprog", iddidprog),
                        self.q.eq("codice", codice)]
                    );
                } else {
                    filter = self.q.and([
                        self.q.eq("title", title),
                        self.q.eq("iddidprog", iddidprog)]
                    );
                }

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currDidprogcurrRow = rows[0];
                    return def.resolve();
                }
                getData.runSelect(tname, "", filter).then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function () {
                            dtMain.load(table.rows[0]);
                            self.currDidprogcurrRow = table.rows[0];
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
                                    row.current.title = title;
                                    row.current.codice = codice;
                                    row.current.iddidprog = iddidprog;
                                    row.current.idcorsostudio = idcorsostudio;
                                    self.currDidprogcurrRow = row.current;
                                    return def.resolve();
                                })
                        });
                });
                return def.promise();
            },

            manageDidProgOri: function (ds, item) {
                var def = Deferred('manageDidProgCurr');
                var self = this;
                var tname = 'didprogori';
                var dtMain = ds.tables[tname];
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;

                var title = item.Orientamento;
                var filter = self.q.and([
                    self.q.eq("iddidprogcurr", iddidprogcurr),
                    self.q.eq("title", title)]
                );
                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currDidprogoriRow = rows[0];
                    return def.resolve();
                }
                getData.runSelect(tname, "*", filter).then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function () {
                            dtMain.load(table.rows[0]);
                            self.currDidprogoriRow = table.rows[0];
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
                                    row.current.title = title;
                                    row.current.iddidprog = iddidprog;
                                    row.current.iddidprogcurr = iddidprogcurr;
                                    row.current.idcorsostudio = idcorsostudio;
                                    self.currDidprogoriRow = row.current;
                                    return def.resolve();
                                })
                        });
                });
                return def.promise();
            },

            manageDidProgAnno: function (ds, item) {
                var def = Deferred('manageDidProgAnno');
                var self = this;
                var tname = 'didproganno';
                var dtMain = ds.tables[tname];

                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;

                var annoAccademico = item.AnnoAccademico;
                var anno = item.AnnoCorsoNumber;

                var filter = self.q.and([
                    self.q.eq("iddidprogori", iddidprogori),
                    self.q.eq("aa", annoAccademico)]
                );
                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currDidprogannoRow = rows[0];
                    return def.resolve();
                }
                getData.runSelect(tname, "*", filter).then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function () {
                            dtMain.load(table.rows[0]);
                            self.currDidprogannoRow = table.rows[0];
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
                                    row.current.iddidprog = iddidprog;
                                    row.current.iddidprogcurr = iddidprogcurr;
                                    row.current.idcorsostudio = idcorsostudio;
                                    row.current.iddidprogori = iddidprogori;
                                    row.current.anno = anno;
                                    row.current.title = anno + " anno";
                                    row.current.aa = annoAccademico;
                                    self.currDidprogannoRow = row.current;
                                    return def.resolve();
                                })
                        });
                });
                return def.promise();
            },

            manageDidProgPorzanno: function (ds, item) {
                var def = Deferred('manageDidProgCurr');
                var self = this;
                var tname = 'didprogporzanno';
                var dtMain = ds.tables[tname];

                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;

                var annoAccademico = item.AnnoAccademico;
                var title = item.UnitaTemporale;

                var filter = self.q.and([
                    self.q.eq("iddidproganno", iddidproganno),
                    self.q.eq("title", title)]
                );
                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currDidprogporzannoRow = rows[0];
                    return def.resolve();
                }
                getData.runSelect(tname, "*", filter).then(function (table) {
                    // se non esiste creo riga
                    appMeta.utils._if(table && table.rows.length)
                        ._then(function () {
                            dtMain.load(table.rows[0]);
                            self.currDidprogporzannoRow = table.rows[0];
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
                                    row.current.iddidprog = iddidprog;
                                    row.current.iddidprogcurr = iddidprogcurr;
                                    row.current.idcorsostudio = idcorsostudio;
                                    row.current.iddidprogori = iddidprogori;
                                    row.current.iddidproganno = iddidproganno;
                                    row.current.aa = annoAccademico;
                                    row.current.title = title;
                                    switch (title.toUpperCase()) {
                                        case "PRIMO SEMESTRE":
                                            row.current.indice = 1;
                                            row.current.iddidprogporzannokind = 5; //semestrale
                                            break;
                                        case "SECONDO SEMESTRE":
                                            row.current.indice = 2;
                                            row.current.iddidprogporzannokind = 5; //semestrale
                                            break;
                                        default:
                                            var a = 0;
                                    }
                                    self.currDidprogporzannoRow = row.current;
                                    return def.resolve();
                                })
                        });
                });
                return def.promise();
            },

            manageInsegn: function (ds, item) {
                var self = this;
                var tname = 'insegn';
                var dtMain = ds.tables[tname];
                var def = Deferred('manageInsegn');
                var denominazione = item.Insegnamento;
                var codiceInsegnamento = item.CodiceInsegnamento;

                if (!codiceInsegnamento) {
                    return this.showMessageOk('manageInsegn - codice insegnamento nullo ' + denominazione);
                }
                codiceInsegnamento = codiceInsegnamento.toString();
                var filter = this.q.eq("codice", codiceInsegnamento);

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currInsegnRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currInsegnRow = table.rows[0];
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
                                        row.current.denominazione = denominazione;
                                        row.current.codice = codiceInsegnamento;
                                        self.currInsegnRow = row.current;
                                        return def.resolve();
                                    });
                            });
                    });

                return def.promise();
            },

            getIdSasd: function (sigla) {
                var self = this;
                var def = Deferred('getIdSasd');

                if (!sigla) {
                    return this.showMessageOk('sigla vuota');
                }
                // se già calcolato lo ritorno
                if (self.currsasdList[sigla]) {
                    return def.resolve(self.currsasdList[sigla]);
                }

                getData.runSelect("sasd", "idsasd,codice", this.q.eq('codice', sigla))
                    .then(function (dt) {
                        if (dt.rows.length) {
                            // memorizzo in dictionary gli idsasd per questo codice (Sigla)
                            self.currsasdList[sigla] = dt.rows[0].idsasd;
                            return def.resolve(dt.rows[0].idsasd);
                        }
                        return def.resolve(null);
                    });
                return def.promise();
            },

            manageInsegncaratteristica: function (ds, item) {
                var def = Deferred('manageInsegncaratteristica');
                var self = this;
                var cf = item.Crediti;

                if (!item.SSDInsegnamento) {
                    console.log('item.SSDInsegnamento vuoto', item);
                    return def.resolve();
                }
                if (!self.currInsegnRow) {
                    return def.resolve();
                }

                var ssd = item.SSDInsegnamento.SSD;
                var modulo = item.Modulo;
                // distiunguo array da elemento singolo. nel caso array inserisco molteplici Insegncaratteristica

                if (Array.isArray(ssd) && !modulo) {
                    var arrayDef = [];
                    var chain = $.when();
                    var realCf = 0;
                    if (ssd.length) {
                        realCf = cf / ssd.length;
                    }
                    _.forEach(ssd, function (ssdItem, index) {
                        chain = chain.then(function () {
                            return self.manageInsegncaratteristicaSSD(ds, item, ssdItem, realCf);
                        });
                        arrayDef.push(chain);
                    });
                    return def.from($.when.apply($, arrayDef))
                }

                return def.from(self.manageInsegncaratteristicaSSD(ds, item, ssd, cf));

            },

            manageInsegncaratteristicaSSD: function (ds, item, ssd, cf) {

                var def = Deferred('manageInsegncaratteristica');
                var self = this;
                var tname = 'insegncaratteristica';
                var dtMain = ds.tables[tname];
                var modulo = item.Modulo;

                // se c'è modulo non va creato
                if (modulo) {
                    return def.resolve();
                }
                // se non c'è la lavoro
                var idinsegn = self.currInsegnRow.idinsegn;

                var sigla = ssd.Sigla;
                var idsasd;
                this.getIdSasd(sigla)
                    .then(function (idsasdPrm) {
                        idsasd = idsasdPrm;
                        var filter = self.q.and([
                            self.q.eq("idinsegn", idinsegn),
                            self.q.eq("cf", cf),
                            self.q.eq("idsasd", idsasd),
                        ]);

                        // se già c'è
                        var rows = dtMain.select(filter);
                        if (rows.length) {
                            self.currInsegnCaratteristicaRow = rows[0];
                            return def.resolve();
                        }

                        getData.runSelect(tname, "*", filter)
                            .then(function (table) {
                                // se non esiste creo riga
                                appMeta.utils._if(table && table.rows.length)
                                    ._then(function () {
                                        dtMain.load(table.rows[0]);
                                        self.currInsegnCaratteristicaRow = table.rows[0];
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
                                                row.current.idinsegn = idinsegn;
                                                row.current.cf = cf;
                                                row.current.idsasd = idsasd;
                                                row.current.profess = 'N';
                                                self.currInsegnCaratteristicaRow = row.current;
                                                return def.resolve();
                                            });
                                    })
                            });
                    });

                return def.promise();
            },

            manageInsegnteg: function (ds, item) {
                var self = this;
                var tname = 'insegninteg';
                var dtMain = ds.tables[tname];
                var def = Deferred('manageInsegnteg');

                if (!self.currInsegnRow) {
                    return def.resolve();
                }

                var idinsegn = self.currInsegnRow.idinsegn;
                var modulo = item.Modulo;
                var codice = item.CodiceModulo;

                if (!modulo) {
                    return def.resolve();
                }
                var filter;
                if (codice) {
                    filter = this.q.and(
                        this.q.eq("codice", codice),
                        this.q.eq("idinsegn", idinsegn));
                } else {
                    filter = this.q.and(
                        this.q.eq("denominazione", modulo),
                        this.q.eq("idinsegn", idinsegn));
                }

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currInsegnintegRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currInsegnintegRow = table.rows[0];
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
                                        row.current.denominazione = modulo;
                                        row.current.codice = codice;
                                        row.current.idinsegn = idinsegn;
                                        self.currInsegnintegRow = row.current;
                                        return def.resolve();
                                    })
                            });
                    });

                return def.promise();
            },

            manageInsegntegcaratteristica: function (ds, item) {
                var def = Deferred('manageInsegntegcaratteristica');
                var self = this;
                var cf = item.Crediti;
                var ssd = item.SSD;
                return def.from(self.manageInsegntegcaratteristicaSSD(ds, item, ssd, cf));
            },

            manageInsegntegcaratteristicaSSD: function (ds, item, ssd, cf) {
                var def = Deferred('manageInsegntegcaratteristica');
                var self = this;
                var tname = 'insegnintegcaratteristica';
                var dtMain = ds.tables[tname];
                var modulo = item.Modulo;

                if (!modulo) {
                    return def.resolve();
                }

                if (!self.currInsegnRow) {
                    return def.resolve();
                }

                if (!self.currInsegnintegRow) {
                    return def.resolve();
                }

                // se non c'è lavoro
                var idinsegn = self.currInsegnRow.idinsegn;
                var idinsegninteg = self.currInsegnintegRow.idinsegninteg;

                var sigla = ssd.Sigla;
                var idsasd;
                this.getIdSasd(sigla)
                    .then(function (idsasdPrm) {
                        idsasd = idsasdPrm;
                        var filter = self.q.and([
                            self.q.eq("idinsegn", idinsegn),
                            self.q.eq("idinsegninteg", idinsegninteg),
                            self.q.eq("cf", cf),
                            self.q.eq("idsasd", idsasd),
                        ]);

                        // se già c'è
                        var rows = dtMain.select(filter);
                        if (rows.length) {
                            self.currInsegnintegcaratteristicaRow = rows[0];
                            return def.resolve();
                        }

                        getData.runSelect(tname, "*", filter)
                            .then(function (table) {
                                // se non esiste creo riga
                                appMeta.utils._if(table && table.rows.length)
                                    ._then(function () {
                                        dtMain.load(table.rows[0]);
                                        self.currInsegnintegcaratteristicaRow = table.rows[0];
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
                                                row.current.idinsegn = idinsegn;
                                                row.current.idinsegninteg = idinsegninteg;
                                                row.current.cf = cf;
                                                row.current.idsasd = idsasd;
                                                row.current.profess = 'N';
                                                self.currInsegnintegcaratteristicaRow = row.current;
                                                return def.resolve();
                                            })
                                    });
                            });
                    });

                return def.promise();
            },

            manageAttivform: function (ds, item) {
                var self = this;
                var def = Deferred('manageAttivform');
                var tname = 'attivform';
                var dtMain = ds.tables[tname];

                var idinsegn = self.currInsegnRow.idinsegn;
                var idinsegninteg = self.currInsegnintegRow ? self.currInsegnintegRow.idinsegninteg : null;

                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;

                var annoAccademico = item.AnnoAccademico;
                var insegnamento = item.Insegnamento;
                var codiceInsegnamento = item.CodiceInsegnamento;
                var modulo = item.Modulo;
                var codiceModulo = item.CodiceModulo;

                var filter = self.q.and([
                    self.q.eq("iddidprogporzanno", iddidprogporzanno),
                    self.q.eq("idinsegn", idinsegn)
                ]
                );

                if (idinsegninteg) {
                    filter = self.q.and(filter, self.q.eq("idinsegninteg", idinsegninteg));
                }

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currAttivformRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currAttivformRow = table.rows[0];
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
                                        row.current.idinsegn = idinsegn;
                                        row.current.idinsegninteg = idinsegninteg;
                                        row.current.iddidprogporzanno = iddidprogporzanno;
                                        row.current.iddidprog = iddidprog;
                                        row.current.iddidprogcurr = iddidprogcurr;
                                        row.current.idcorsostudio = idcorsostudio;
                                        row.current.iddidprogori = iddidprogori;
                                        row.current.iddidproganno = iddidproganno;
                                        row.current.aa = annoAccademico;
                                        row.current.idsede = 1;
                                        row.current.title = 'Insegnamento: ' + insegnamento + '; Codice: ' + codiceInsegnamento + '; Modulo: ' + modulo + '; Codice Modulo: ' + codiceModulo + ';';
                                        self.currAttivformRow = row.current;
                                        return def.resolve();
                                    })
                            });
                    });

                return def.promise();
            },

            manageAttivformcaratteristica: function (ds, item) {
                var self = this;
                var def = Deferred('manageAttivformcaratteristica');
                var crediti = item.Crediti;

                if (!item.SSDInsegnamento) {
                    console.log('manageAttivformcaratteristica item.SSDInsegnamento vuoto', item);
                    return def.resolve();
                }

                var ssd = item.SSDInsegnamento.SSD;
                var sigla = item.SSD.Sigla;
                var modulo = item.Modulo;

                // distiunguo array da elemento singolo. nel caso array inserisco molteplici Insegncaratteristica
                if (Array.isArray(ssd) && !modulo) {
                    var arrayDef = [];
                    var chain = $.when();
                    var realCf = 0;
                    if (ssd.length) {
                        realCf = crediti / ssd.length;
                    }
                    _.forEach(ssd, function (ssdItem, index) {
                        chain = chain.then(function () {
                            // recupero dalla dict già calcolata per insegn.
                            var idsasd = self.currsasdList[ssdItem.Sigla];
                            return self.manageAttivformcaratteristicaSSD(ds, item, idsasd, realCf);
                        });
                        arrayDef.push(chain);
                    });
                    return def.from($.when.apply($, arrayDef))
                }

                // se (non array o c'è modulo) prendo ssd
                // recupero dalla dict già calcolata per insegn.
                var idsasd = self.currsasdList[sigla];
                return def.from(self.manageAttivformcaratteristicaSSD(ds, item, idsasd, crediti));
            },

            manageAttivformcaratteristicaSSD: function (ds, item, idsasd, crediti) {
                var self = this;
                var def = Deferred('manageAttivformcaratteristicaSSD');
                var tname = 'attivformcaratteristica';
                var dtMain = ds.tables[tname];

                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;
                var idattivform = self.currAttivformRow.idattivform;

                var annoAccademico = item.AnnoAccademico;

                var sigla = item.Attivita.Sigla;
                var indicecineca = item.Ambito.CodiceEsportazione;

                // calcolati tramite query
                var idtipoattform;
                var idambitoareadisc;

                var filterTipoattform = this.q.eq('title', sigla);
                getData.runSelect('tipoattform', "idtipoattform", filterTipoattform)
                    .then(function (dt) {

                        if (dt.rows.length) {
                            // var globale di classe usata per popolare campo json e title
                            self.currtipoattform = dt.rows[0];
                            idtipoattform = dt.rows[0].idtipoattform;
                        }

                        var filterAmbitoareadisc = self.q.eq('indicecineca', indicecineca);
                        return getData.runSelect('ambitoareadisc', "idambitoareadisc", filterAmbitoareadisc)
                    })
                    .then(function (dt) {
                        if (dt.rows.length) {
                            // var globale di classe usata per popolare campo json e title
                            self.currambitoareadisc = dt.rows[0];
                            idambitoareadisc = dt.rows[0].idambitoareadisc;
                        }

                        var filter = self.q.and([
                            self.q.eq("idattivform", idattivform),
                            self.q.eq("idtipoattform", idtipoattform),
                            self.q.eq("idambitoareadisc", idambitoareadisc),
                            self.q.eq("idsasd", idsasd)
                        ]
                        );
                        // se già c'è
                        var rows = dtMain.select(filter);
                        if (rows.length) {
                            self.currAttivformcaratteristicaRow = rows[0];
                            return def.resolve();
                        }

                        // esistenza riga su db
                        return getData.runSelect(tname, "*", filter);
                    }).then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currAttivformcaratteristicaRow = table.rows[0];
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
                                        row.current.idattivform = idattivform;
                                        row.current.iddidprogporzanno = iddidprogporzanno;
                                        row.current.iddidprog = iddidprog;
                                        row.current.iddidprogcurr = iddidprogcurr;
                                        row.current.idcorsostudio = idcorsostudio;
                                        row.current.iddidprogori = iddidprogori;
                                        row.current.iddidproganno = iddidproganno;
                                        row.current.aa = annoAccademico;

                                        row.current.idtipoattform = idtipoattform;
                                        row.current.idambitoareadisc = idambitoareadisc;
                                        row.current.idsasd = idsasd;
                                        row.current.cf = crediti;
                                        row.current.profess = 'N';

                                        // algoritmo per popolare campo json e title
                                        var p = [];
                                        p.push([{ cf: crediti }, 'cf', 'Crediti']);
                                        p.push([self.currtipoattform, 'title', 'Attività']);
                                        p.push([self.currambitoareadisc, 'title', 'Ambito']);
                                        p.push([self.currsasd, 'sasd_codice', 'SSD']);
                                        var output = self.buildOreAttivformcaratteristicaForTitle(item);
                                        p.push([output, null, 'Ore']);
                                        row.current.json = self.stringify(p, 'json');
                                        row.current.title = self.stringify(p, 'string');
                                        self.currAttivformcaratteristicaRow = row.current;
                                        return def.resolve();
                                    })
                            });
                    });

                return def.promise();
            },

            buildOreAttivformcaratteristicaForTitle: function (item) {
                var oraAula = item.OreAula;
                var oreSeminari = item.OreSeminari;
                var oreLaboratorio = item.OreLaboratorio;
                var oreEsercitazioni = item.OreEsercitazioni;
                var oreAltro = item.OreAltro;
                var res = '';
                if (oraAula && oraAula !== '0.00') {
                    res = oraAula + ' ore di aula';
                }
                if (oreSeminari && oreSeminari !== '0.00') {
                    res += ', ' + oreSeminari + ' ore di seminari';
                }
                if (oreLaboratorio && oreLaboratorio !== '0.00') {
                    res += ', ' + oreLaboratorio + ' ore di laboratorio';
                }
                if (oreEsercitazioni && oreEsercitazioni !== '0.00') {
                    res += ', ' + oreEsercitazioni + ' ore di esercitazione';
                }
                if (oreAltro && oreAltro !== '0.00') {
                    res += ', ' + oreAltro + ' ore di altro';
                }

                return res;
            },

            manageAttivformcaratteristicaora: function (ds, item) {
                var def = Deferred('manageAttivformcaratteristicaora');

                // ore
                var oraAula = item.OreAula;
                var oreSeminari = item.OreSeminari;
                var oreLaboratorio = item.OreLaboratorio;
                var oreEsercitazioni = item.OreEsercitazioni;
                var oreAltro = item.OreAltro;

                var arraydef = [];
                if (oraAula && oraAula !== '0.00') {
                    arraydef.push(this.creaAttivformCaratteristicaOraRecord(ds, item, oraAula, 2))
                }
                if (oreSeminari && oreSeminari !== '0.00') {
                    arraydef.push(this.creaAttivformCaratteristicaOraRecord(ds, item, oreSeminari, 6))
                }
                if (oreLaboratorio && oreLaboratorio !== '0.00') {
                    arraydef.push(this.creaAttivformCaratteristicaOraRecord(ds, item, oreLaboratorio, 4))
                }
                if (oreEsercitazioni && oreEsercitazioni !== '0.00') {
                    arraydef.push(this.creaAttivformCaratteristicaOraRecord(ds, item, oreEsercitazioni, 3))
                }
                if (oreAltro && oreAltro !== '0.00') {
                    arraydef.push(this.creaAttivformCaratteristicaOraRecord(ds, item, oreAltro, 8))
                }

                // 5 righe
                return def.from($.when.apply($, arraydef))

            },

            /**
             * Crea singolo record su affidamentocaratteristicaora in base a  ora, idorakind
             * @param ds
             * @param item
             * @param ora
             * @param idorakind
             * @returns {Deferred}
             */
            creaAttivformCaratteristicaOraRecord(ds, item, ora, idorakind) {
                var self = this;
                var def = Deferred('creaAttivformCaratteristicaOraRecord');
                var tname = 'attivformcaratteristicaora';
                var dtMain = ds.tables[tname];
                var meta = appMeta.getMeta(tname);

                if (!self.currAttivformcaratteristicaRow) {
                    console.log('creaAttivformCaratteristicaOraRecord currAttivformcaratteristicaRow vuoto', item);
                    return def.resolve();
                }

                var idattivformcaratteristica = self.currAttivformcaratteristicaRow.idattivformcaratteristica;
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;
                var idattivform = self.currAttivformRow.idattivform;
                var aa = item.AnnoAccademico;

                var filter = self.q.and([
                    self.q.eq("idattivformcaratteristica", idattivformcaratteristica),
                    self.q.eq("idorakind", idorakind)
                ]
                );

                // se già c'è
                if (dtMain.select(filter).length) {
                    return def.resolve();
                }

                meta.setDefaults(dtMain);
                meta.getNewRow(null, dtMain)
                    .then(function (row) {
                        row.current.idattivform = idattivform;
                        row.current.idattivformcaratteristica = idattivformcaratteristica;
                        row.current.iddidprogporzanno = iddidprogporzanno;
                        row.current.iddidprog = iddidprog;
                        row.current.iddidprogcurr = iddidprogcurr;
                        row.current.idcorsostudio = idcorsostudio;
                        row.current.iddidprogori = iddidprogori;
                        row.current.iddidproganno = iddidproganno;
                        row.current.aa = aa;

                        row.current.idorakind = idorakind;
                        row.current.ora = parseInt(ora);

                        def.resolve();
                    });

                return def.promise();
            },

            manageCanale: function (ds, item) {
                var self = this;
                var def = Deferred('manageCanale');
                var tname = 'canale';
                var dtMain = ds.tables[tname];

                var idsede = self.currAttivformRow.idsede;
                var cuin = item.CUIN;

                if (!cuin) {
                    console.log('manageCanale item.CUIN vuoto', item);
                    return def.resolve();
                }

                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;
                var idattivform = self.currAttivformRow.idattivform;
                var title = item.Canale;
                // a volte vale {"-self-closing": "true"} edè quindi un oggetto
                if (typeof title === 'object') {
                    title = '';
                }
                var sortcode = item.CanaleIndex;
                var numerostud = item.NumeroStudentiCanale;
                var aa = item.AnnoAccademico;

                var filter = self.q.and([
                    self.q.eq("idattivform", idattivform),
                    self.q.eq("cuin", cuin)
                ]
                );
                if (title) {
                    filter = self.q.and(filter, self.q.eq("title", title));
                }

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currCanaleRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currCanaleRow = table.rows[0];
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
                                        row.current.idattivform = idattivform;
                                        row.current.iddidprogporzanno = iddidprogporzanno;
                                        row.current.iddidprog = iddidprog;
                                        row.current.iddidprogcurr = iddidprogcurr;
                                        row.current.idcorsostudio = idcorsostudio;
                                        row.current.iddidprogori = iddidprogori;
                                        row.current.iddidproganno = iddidproganno;
                                        row.current.idsede = idsede;
                                        row.current.aa = aa;
                                        row.current.cuin = cuin;
                                        row.current.sortcode = sortcode;
                                        row.current.numerostud = numerostud;
                                        row.current.title = title;
                                        self.currCanaleRow = row.current;
                                        return def.resolve();
                                    })
                            });
                    });

                return def.promise();
            },

            /**
             *
             * @param ds
             * @param item
             * @param {string} docenteCF necessario per calcolare idreg_docenti
             * @returns {*}
             */
            manageAffidamento: function (ds, item, idreg_docenti) {
                var self = this;
                var def = Deferred('manageAffidamento');
                var tname = 'affidamento';
                var dtMain = ds.tables[tname];

                if (!self.currCanaleRow) {
                    console.log('manageAffidamento riga canale vuota', item);
                    return def.resolve();
                }

                var idcanale = self.currCanaleRow.idcanale;
                var idSede = self.currCanaleRow.idsede;
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;
                var idattivform = self.currAttivformRow.idattivform;
                var aa = item.AnnoAccademico;
                var gratuito = item.Gratuito === 'false' ? 'N' : 'S';
                var ruolo = item.Ruolo;


                var ruoloStringToCompare = '';
                if (ruolo) {
                    ruoloStringToCompare = ruolo.toString().toUpperCase();
                }
                var idAffidamentoKindToCompare = 1;
                // --> Vedere idaffidamentokind a seconda del ruolo
                if (ruoloStringToCompare === 'Bando'.toUpperCase()) {
                    idAffidamentoKindToCompare = 3;
                }
                if (ruoloStringToCompare === 'Richiesta SSD'.toUpperCase()) {
                    idAffidamentoKindToCompare = 8;
                }
                if (ruoloStringToCompare === 'Tutor'.toUpperCase()) {
                    idAffidamentoKindToCompare = 9;
                }
                var filter;
                if (idreg_docenti) {
                    filter = self.q.and([
                        self.q.eq("idcanale", idcanale),
                        self.q.eq("idreg_docenti", idreg_docenti)
                    ]
                    );
                } else {
                    console.log('manageAffidamento idreg_docenti vuoto, ma trovato idAffidamento' + idAffidamentoKindToCompare, item);
                    filter = self.q.and([
                        self.q.eq("idcanale", idcanale),
                        self.q.eq("idaffidamentokind", idAffidamentoKindToCompare)
                    ]
                    );
                }

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currAffidamentoRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currAffidamentoRow = table.rows[0];
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
                                        row.current.idcanale = idcanale;
                                        row.current.idattivform = idattivform;
                                        row.current.iddidprogporzanno = iddidprogporzanno;
                                        row.current.iddidprog = iddidprog;
                                        row.current.iddidprogcurr = iddidprogcurr;
                                        row.current.idcorsostudio = idcorsostudio;
                                        row.current.iddidprogori = iddidprogori;
                                        row.current.iddidproganno = iddidproganno;
                                        row.current.idsede = idSede;
                                        row.current.gratuito = gratuito;
                                        row.current.aa = aa;

                                        // convenzioni
                                        row.current.idaffidamentokind = idAffidamentoKindToCompare;

                                        /*if (ruoloStringToCompare === 'Carico didattico'.toUpperCase()) {
                                            // default
                                            row.current.idaffidamentokind = 1;
                                        }*/

                                        row.current.iderogazkind = 1;
                                        row.current.riferimento = 'S';

                                        row.current.idreg_docenti = idreg_docenti;
                                        self.currAffidamentoRow = row.current;
                                        return def.resolve();
                                    })
                            });
                    });

                return def.promise();
            },

            manageEdificio: function (ds, item) {
                var self = this;
                var tname = 'edificio';
                var dtMain = ds.tables[tname];
                var def = Deferred('manageEdificio');
                var spacePath = item.spacePath; // "CITTADELLA UNIVERSITARIA  > EDIFICIO 1 - SCIENZE CHIMICHE",
                var edificioInfoArr = spacePath.split(">");
                var edificioTitle = edificioInfoArr[1].trim();

                var filter = this.q.eq("title", edificioTitle);

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
                            ._then(function () {
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
                                        return def.resolve();
                                    });
                            });
                    });

                return def.promise();
            },

            manageLezioneAula: function (ds, item) {
                var self = this;
                var tname = 'aula';
                var dtMain = ds.tables[tname];
                var def = Deferred('manageLezioneAula');
                var code = item.spaceCode;
                var title = item.spaceName;
                var edificioInfoArr = item.spacePath.split(">");
                var edificioTitle = edificioInfoArr[1].trim();

                var filter = this.q.eq("code", code);

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
                            ._then(function () {
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

                                        var filterEdificio = self.q.eq("title", edificioTitle);
                                        var rows = ds.tables.edificio.select(filterEdificio);
                                        row.current.idedificio = rows[0].idedificio;
                                        row.current.title = title;
                                        row.current.code = code;
                                        row.current.idsede = self.idSede;
                                        self.currAulaRow = row.current;
                                        return def.resolve();
                                    });
                            });
                    });

                return def.promise();
            },

            manageAffidamentoCustomFields: function (ds, item) {
                var def = appMeta.Deferred("beforeFill-manageattivform_title");
                var dtaffidamento = ds.tables.affidamento;
                var rowAffidamento = dtaffidamento.rows[0];
                this.manageaffidamento_default_jsonancestor(rowAffidamento, ds);
                this.manageaffidamento_default_title_and_json(rowAffidamento, ds, item)
                    .then(function () {
                        def.resolve();
                    });
                return def.promise();
            },

            manageaffidamento_default_title_and_json: function (rowAffidamento, ds, item) {
                var def = appMeta.Deferred("beforeFill-manageattivform_title");
                var self = this;
                var curraffidamentokind;
                var currdocente;
                var idreg = rowAffidamento.idreg_docenti;
                var idaffidamentokind = rowAffidamento.idaffidamentokind;
                getData.runSelect('affidamentokinddefaultview', '*', this.q.eq('idaffidamentokind', idaffidamentokind), null)
                    .then(function (dt) {
                        curraffidamentokind = dt.rows[0];
                        return getData.runSelect('registrydocentiview', '*', self.q.eq('idreg', idreg), null);
                    })
                    .then(function (dt) {
                        currdocente = dt.rows[0];
                    }).then(function () {

                        var p = [];
                        var output = self.buildOreAndCfFormAffidamento(item);
                        p.push([curraffidamentokind, 'dropdown_title', 'Tipo di affidamento']);
                        p.push([currdocente, 'dropdown_title', 'Docente']);
                        p.push([currdocente, 'struttura_title', 'Dipartimento']);
                        p.push([currdocente, 'registryistituti_title', 'Istituto']);
                        p.push([output, null, 'CF e ore assegnate']);

                        // faccio side-effect sulla riga di affidamento
                        rowAffidamento.json = self.stringify(p, 'json');
                        rowAffidamento.title = self.stringify(p, 'string');
                        def.resolve();
                    });

                return def.promise();

            },

            buildOreAndCfFormAffidamento: function (item) {
                var creditidocente = item.CreditiDocente;
                var ore = item.OreDocente;
                var res = '';
                if (creditidocente) {
                    res = creditidocente + ' crediti';
                }
                if (ore) {
                    res += ', ' + ore + ' ore';
                }
                return res;
            },

            /**
             * SYNC
             * @param {} rowAffidamento
             * @param {} ds
             */
            manageaffidamento_default_jsonancestor: function (rowAffidamento, ds) {
                var self = this;
                var p = [];

                var titleDidProg = self.currDidprogRow.title;
                var aaDidProg = self.currDidprogRow.aa;

                var titleDidProgCurr = self.currDidprogcurrRow.title;
                var titleDidProgOri = self.currDidprogoriRow.title;
                var titleDidProganno = self.currDidprogannoRow.title;
                var titleDidProgPorzanno = self.currDidprogporzannoRow.title;

                p.push([titleDidProg + ' ' + aaDidProg, null, 'Corso']);
                p.push([titleDidProgCurr, null, 'Curriculum']);
                p.push([titleDidProgOri, null, 'Orientamento']);
                p.push([titleDidProganno, null, 'Anno di corso']);
                p.push([titleDidProgPorzanno, null, "Porzione d'anno"]);

                rowAffidamento.jsonancestor = self.stringify(p, 'json');
            },

            manageAffidamentoCaratteristica: function (ds, item) {
                var self = this;
                var def = Deferred('manageAffidamentoCaratteristica');
                var tname = 'affidamentocaratteristica';
                var dtMain = ds.tables[tname];

                if (!self.currAffidamentoRow) {
                    return def.resolve();
                }

                var idaffidamento = self.currAffidamentoRow.idaffidamento;
                var idcanale = self.currCanaleRow.idcanale;
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;
                var idattivform = self.currAttivformRow.idattivform;
                var aa = item.AnnoAccademico;

                // calcolati tramite query in emtodi precedenti. righe salvate in var di classe
                var idtipoattform = this.currtipoattform.idtipoattform;
                var idambitoareadisc = this.currambitoareadisc.idambitoareadisc;

                if (!item.SSD) {
                    console.log('manageAffidamentoCaratteristica item.SSD vuota', item);
                    return def.resolve();
                }

                // prendo isasd. sicuramente è già calcolato sulla dict currsasdList
                var sigla = item.SSD.Sigla;
                var idsasd = this.currsasdList[sigla];

                // TODO capire profess cosa ci va
                var profess = 'N';

                var filter = self.q.and([
                    self.q.eq("idaffidamento", idaffidamento),
                    self.q.eq("idtipoattform", idtipoattform),
                    self.q.eq("idambitoareadisc", idambitoareadisc),
                    self.q.eq("idsasd", idsasd)
                ]
                );

                // se già c'è
                var rows = dtMain.select(filter);
                if (rows.length) {
                    self.currAffidamentoCaratteristicaRow = rows[0];
                    return def.resolve();
                }

                getData.runSelect(tname, "*", filter)
                    .then(function (table) {
                        // se non esiste creo riga
                        appMeta.utils._if(table && table.rows.length)
                            ._then(function () {
                                dtMain.load(table.rows[0]);
                                self.currAffidamentoCaratteristicaRow = table.rows[0];
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
                                        row.current.idaffidamento = idaffidamento;
                                        row.current.idcanale = idcanale;
                                        row.current.idattivform = idattivform;
                                        row.current.iddidprogporzanno = iddidprogporzanno;
                                        row.current.iddidprog = iddidprog;
                                        row.current.iddidprogcurr = iddidprogcurr;
                                        row.current.idcorsostudio = idcorsostudio;
                                        row.current.iddidprogori = iddidprogori;
                                        row.current.iddidproganno = iddidproganno;
                                        row.current.aa = aa;

                                        row.current.idtipoattform = idtipoattform;
                                        row.current.idambitoareadisc = idambitoareadisc;
                                        row.current.idsasd = idsasd;

                                        row.current.profess = profess;
                                        self.currAffidamentoCaratteristicaRow = row.current;
                                        return def.resolve();
                                    })
                            });
                    });

                return def.promise();
            },

            manageAffidamentoCaratteristicaora(ds, item) {
                var def = Deferred('manageAffidamentoCaratteristicaora');

                // ore
                var oreDocente = item.OreDocente;

                if (!this.currAffidamentoCaratteristicaRow) {
                    return def.resolve();
                }

                var arraydef = [];
                if (oreDocente && oreDocente !== '0.00') {
                    arraydef.push(this.creaAffidamentoCaratteristicaOraRecord(ds, item, oreDocente, null))
                }
                // 1 riga
                $.when.apply($, arraydef)
                    .then(function () {
                        def.resolve();
                    });

                return def.promise();
            },

            /**
             * Crea singolo record su affidamentocaratteristicaora in base a  ora, idorakind
             * @param ds
             * @param item
             * @param ora
             * @param idorakind
             * @returns {Deferred}
             */
            creaAffidamentoCaratteristicaOraRecord(ds, item, ora, idorakind) {
                var self = this;
                var def = Deferred('creaAffidamentoCaratteristicaOraRecord');
                var tname = 'affidamentocaratteristicaora';
                var dtMain = ds.tables[tname];
                var meta = appMeta.getMeta(tname);

                if (!self.currAffidamentoCaratteristicaRow) {
                    return def.resolve();
                }

                var idaffidamentocaratteristica = self.currAffidamentoCaratteristicaRow.idaffidamentocaratteristica;
                var idaffidamento = self.currAffidamentoRow.idaffidamento;
                var idcanale = self.currCanaleRow.idcanale;
                var idcorsostudio = self.currCorsoStudioRow.idcorsostudio;
                var iddidprog = self.currDidprogRow.iddidprog;
                var iddidprogcurr = self.currDidprogcurrRow.iddidprogcurr;
                var iddidprogori = self.currDidprogoriRow.iddidprogori;
                var iddidproganno = self.currDidprogannoRow.iddidproganno;
                var iddidprogporzanno = self.currDidprogporzannoRow.iddidprogporzanno;
                var idattivform = self.currAttivformRow.idattivform;
                var aa = item.AnnoAccademico;

                var filter = self.q.eq("idaffidamentocaratteristica", idaffidamentocaratteristica);


                // se già c'è
                if (dtMain.select(filter).length) {
                    return def.resolve();
                }

                meta.setDefaults(dtMain);
                meta.getNewRow(null, dtMain)
                    .then(function (row) {
                        row.current.idaffidamento = idaffidamento;
                        row.current.idaffidamentocaratteristica = idaffidamentocaratteristica;
                        row.current.idcanale = idcanale;
                        row.current.idattivform = idattivform;
                        row.current.iddidprogporzanno = iddidprogporzanno;
                        row.current.iddidprog = iddidprog;
                        row.current.iddidprogcurr = iddidprogcurr;
                        row.current.idcorsostudio = idcorsostudio;
                        row.current.iddidprogori = iddidprogori;
                        row.current.iddidproganno = iddidproganno;
                        row.current.aa = aa;

                        row.current.idorakind = idorakind;
                        row.current.ripetizioni = null;
                        row.current.ora = parseInt(ora);

                        def.resolve();
                    });

                return def.promise();
            },

            getIdRegDocenti(cf) {
                var def = Deferred('getIdRegDocenti');
                var filter = this.q.eq("cf", cf);
                getData.runSelect('registry', "idreg", filter)
                    .then(function (table) {
                        if (table.rows.length) {
                            return def.resolve(table.rows[0].idreg);
                        }
                        def.resolve(null);
                    });

                return def.promise();
            },

            getCaricoDidattico: function (that) {
                var docenteCF = $("#docenteCFId").val();
                var docenteCognome = $("#docenteCognomeId").val();
                var aa = $("#annoaccademicoId").val();

                var waitingHandler = that.showWaitingIndicator('attendi chiamata servizio');

                appMeta.callWebService("getCaricoDidattico", {
                    docenteCognome: docenteCognome,
                    aa: aa
                }).then(function (res) {
                    that.hideWaitingIndicator(waitingHandler);
                    return that._getCaricodidattico(res, aa, null, null, null);
                });
            },

            getCaricoDidatticoJsonFile: function (that) {
                if (that.jsonFileCaricoDidattico) {
                    var reader = new FileReader();
                    reader.readAsText(that.jsonFileCaricoDidattico, "UTF-8");
                    reader.onload = function (evt) {
                        var aa = $("#annoaccademicoIdJsonFile").val();
                        var idreg = $("#docenteIdRegFile").val();
                        return that._getCaricodidattico(evt.target.result, aa, idreg, "Envelope", "Body", true);
                    };
                    reader.onerror = function (evt) {
                        document.getElementById("infoImportFileJson").innerHTML = "error reading file";
                    }
                }
            },

            getAllocationJsonFile: function (that) {
                if (that.jsonFileAllocations) {
                    var reader = new FileReader();
                    reader.readAsText(that.jsonFileAllocations, "UTF-8");
                    reader.onload = function (evt) {
                        return appMeta.Lezioni.manageGetAllocationsResponse(evt.target.result, that);
                    };
                    reader.onerror = function (evt) {
                        document.getElementById("infoImportFileAllocationJson").innerHTML = "error reading file allocations";
                    }
                }
            },

            getCaricoDidatticoJson: function (that) {
                var res = $("#jsonresponseidJson").val();
                var aa = $("#annoaccademicoIdJson").val();
                var idreg = $("#docenteIdReg").val();
                return that._getCaricodidattico(res, aa, idreg, null, null);
            },

            _getCaricodidattico(json, aa, idregPrm, envelopeTagPrm, bodyTagPrm, popupOk) {
                var corsostudioTableName = 'corsostudio';
                var corsostudioEditType = 'load';
                var that = this;
                try {
                    // calcolato all'inizio della catena di "then"
                    var idreg_docenti;
                    var waitingHandler = that.showWaitingIndicator('Attendi richiesta dataset');
                    // DocenteModuloNVA
                    var envelopeTag = envelopeTagPrm || "soap:Envelope";
                    var bodyTag = bodyTagPrm || "soap:Body";
                    var items = JSON.parse(json)[envelopeTag][bodyTag].GetCaricoDidatticoResponse.GetCaricoDidatticoResult.CaricoDidattico.DocenteModuloNVA;
                    var arrayDef = [];
                    var arrayDefInsegn = [];

                    var sliceIndex = parseInt($("#itemIndexId").val());
                    items = items.slice(sliceIndex);

                    var onlyCorsoStudio = $("#onlyCorsoStudioId").prop('checked')

                    getData.getDataSet(corsostudioTableName, corsostudioEditType).then(function (ds) {
                        var chain = $.when();
                        var chainInsegn = $.when();
                        // TODO calcolare bene passando array di anni accademici
                        var annoistituzione = aa.split("/")[0];

                        // INIZIO LOOP su insegn insegnteg

                        if (!onlyCorsoStudio) {
                            _.forEach(items, function (item, index) {

                                chainInsegn = chainInsegn.then(function () {
                                    that.hideWaitingIndicator(waitingHandler);
                                    waitingHandler = that.showWaitingIndicator('Attendi costruzione righe vocabolari insegn insegnteg  ' + (index + sliceIndex + 1));
                                    that.currInsegnRow = null;
                                    that.currInsegnCaratteristicaRow = null;
                                    that.currInsegnintegRow = null;
                                    that.currInsegnintegcaratteristicaRow = null;
                                    return that.manageInsegn(ds, item);
                                }).then(function () {
                                    return that.manageInsegncaratteristica(ds, item);
                                })
                                    .then(function () {
                                        return that.manageInsegnteg(ds, item);
                                    })
                                    .then(function () {
                                        return that.manageInsegntegcaratteristica(ds, item);
                                    }).then(function () {
                                        that.hideWaitingIndicator(waitingHandler);
                                        waitingHandler = that.showWaitingIndicator('salvo vocabolario ' + (index + sliceIndex + 1));
                                        return appMeta.postData.doPostSilent(ds, corsostudioTableName, corsostudioEditType, [])
                                    })
                                    .then(function (res, msg) {
                                        that.hideWaitingIndicator(waitingHandler);
                                        if (!res && msg && msg.length) {
                                            var s = msg.reduce(function (acc, m) {
                                                acc += m.description + '\n';
                                                return acc;
                                            }, '');
                                            that.printItemIndex('Vocabolario err', index + sliceIndex);
                                            return that.showMessageOk(s)
                                        }
                                        if (res && !popupOk) {
                                            return that.showMessageOk('Vocabolario ' + (index + sliceIndex + 1) + ' salvato con successo')
                                        }
                                        that.printItemIndex('Vocabolario', index + sliceIndex);
                                        return true;
                                    }, function (err) {
                                        that.printItemIndex('Vocabolario err', index + sliceIndex);
                                        that.hideWaitingIndicator(waitingHandler);
                                        return false;
                                    });

                                arrayDefInsegn.push(chainInsegn);
                            });
                        }
                        // FINE LOOP vocabolari

                        // RISOLVO IL PRIMO PACCHETTO DI DEFERRED così il ds avrà gli id calcolati veri su insegn insegnteg
                        return $.when.apply($, arrayDefInsegn)
                            .then(function (res) {
                                that.hideWaitingIndicator(waitingHandler);

                                //INIZIO for su didattica
                                _.forEach(items, function (item, index) {
                                    chain = chain.then(function () {
                                        // reset var globali
                                        that.currCorsoStudioRow = null;
                                        that.currDidprogRow = null;
                                        that.currDidprogcurrRow = null;
                                        that.currDidprogoriRow = null;
                                        that.currDidprogannoRow = null;
                                        that.currDidprogporzannoRow = null;
                                        that.currAttivformRow = null;
                                        that.currAttivformcaratteristicaRow = null;
                                        that.currInsegnRow = null;
                                        that.currInsegnCaratteristicaRow = null;
                                        that.currInsegnintegRow = null;
                                        that.currInsegnintegcaratteristicaRow = null;
                                        that.currCanaleRow = null;
                                        that.currAffidamentoRow = null;
                                        that.currAffidamentoCaratteristicaRow = null;
                                        that.hideWaitingIndicator(waitingHandler);
                                        waitingHandler = that.showWaitingIndicator('attendi caricamento banca dati ' + (index + sliceIndex + 1));

                                        if (!item.CodiceCorso) {
                                            console.log('item.CodiceCorso vuoto', item);
                                            that.printItemIndex('item', index + sliceIndex);
                                            return true;
                                        }

                                        return that.manageCorsoStudio(ds, item, annoistituzione)
                                            .then(function () {

                                                if (item.Docente && item.Docente.CodiceFiscale) {
                                                    return that.getIdRegDocenti(item.Docente.CodiceFiscale);
                                                } else {
                                                    console.log('item.Docente.CodiceFiscale null', item);
                                                    return null;
                                                }
                                            })
                                            .then(function (idreg) {
                                                idreg_docenti = idregPrm || idreg; // in debug usa idregPrm
                                                return that.manageCorsoStudioClasseScuola(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageDidErog(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageDidProg(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageDidProgCurr(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageDidProgOri(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageDidProgAnno(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageDidProgPorzanno(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageInsegn(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageInsegncaratteristica(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageInsegnteg(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageInsegntegcaratteristica(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageAttivform(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageAttivformcaratteristica(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageAttivformcaratteristicaora(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageCanale(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageAffidamento(ds, item, idreg_docenti);
                                            })
                                            .then(function () {
                                                return that.manageAffidamentoCaratteristica(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageAffidamentoCaratteristicaora(ds, item);
                                            })
                                            .then(function () {
                                                return that.manageAffidamentoCustomFields(ds, item);
                                            })
                                            .then(function () {
                                                that.hideWaitingIndicator(waitingHandler);
                                                if (idreg_docenti == null) {
                                                    // return Deferred('no_id_found').resolve(false, 'non è stato trovato idreg per cf ' + item.Docente.CodiceFiscale);
                                                }
                                                waitingHandler = that.showWaitingIndicator('salvo item carico didattico ' + (index + sliceIndex + 1));
                                                return appMeta.postData.doPostSilent(ds, corsostudioTableName, corsostudioEditType, [])
                                            })
                                            .then(function (res, msg) {
                                                that.hideWaitingIndicator(waitingHandler);
                                                if (!res && msg && msg.length) {
                                                    var s = msg.reduce(function (acc, m) {
                                                        acc += m.description + '\n';
                                                        return acc;
                                                    }, '');
                                                    that.printItemIndex('item err', index + sliceIndex);
                                                    return that.showMessageOk(s)
                                                }
                                                that.printItemIndex('item', index + sliceIndex);
                                                if (res && !popupOk) {
                                                    return that.showMessageOk('Carico didattico item ' + (index + sliceIndex + 1) + ' salvato con successo')
                                                }
                                                return true;
                                            }, function (err) {
                                                that.printItemIndex('item err', index + sliceIndex);
                                                that.hideWaitingIndicator(waitingHandler);
                                            });
                                    });
                                    arrayDef.push(chain);
                                });

                                return $.when.apply($, arrayDef)
                                    .then(function (res) {
                                        that.hideWaitingIndicator(waitingHandler);
                                        console.log(res);
                                    })
                            });

                        // FINE when arrayinsegnteg. all'internoe segue loop per didprog ...

                    });
                } catch (error) {
                    that.hideWaitingIndicator(waitingHandler);
                    console.error(error);
                }
            },

            printItemIndex: function (msg, i) {
                document.getElementById("infoImportFileJson").innerHTML = msg + " item: " + i;
            },

            getAllocationMassivo: function (that) {
                // esegue la richiesta al servizio di unict. la url è cablata lato server. --> renderla configurabile
                var docenteNome = null;
                var docenteCognome = null;
                var dataInizio = $("#dataInizioGetAllId").val();
                var dataFine = $("#dataFineGetAllId").val();

                if (!dataInizio || !dataFine) {
                    return that.showMessageOk('Scegli un periodo');
                }

                that.showMessageOkCancel('Vuoi caricare le lezioni per tutti i docenti, per il periodo selezionato?').then(function (res) {
                    if (!res) {
                        return;
                    }
                    appMeta.Lezioni.getAllocations({
                        docenteCognome: docenteCognome,
                        docenteNome: docenteNome,
                        dataInizio: dataInizio,
                        dataFine: dataFine,
                        metaPage: that
                    });
                });
            },

            getAllocations: function (that) {
                // esegue la richiesta al servizio di unict. la url è cablata lato server. --> renderla configurabile
                var docenteNome = $("#docenteNomeGetAllId").val();
                var docenteCognome = $("#docenteCognomeGetAllId").val();
                var dataInizio = $("#dataInizioGetAllId").val();
                var dataFine = $("#dataFineGetAllId").val();

                if (!dataInizio || !dataFine) {
                    return that.showMessageOk('Scegli un periodo');
                }

                that.showMessageOkCancel('Vuoi caricare le lezioni, per il periodo selezionato?').then(function (res) {
                    if (!res) {
                        return;
                    }
                    appMeta.Lezioni.getAllocations({
                        docenteCognome: docenteCognome,
                        docenteNome: docenteNome,
                        dataInizio: dataInizio,
                        dataFine: dataFine,
                        metaPage: that
                    });
                });
            },

            getAllocationsDebug: function (that) {
                var res = $("#jsonGetAllocations").val();
                return appMeta.Lezioni.manageGetAllocationsResponse(res, that);
            },


            /**
             * show hide the password
             */
            showHidePassword: function (that) {
                that.isPwdToShow = !that.isPwdToShow;
                var type = that.isPwdToShow ? 'text' : 'password';
                var iconRemove = that.isPwdToShow ? 'fa-eye' : 'fa-eye-slash';
                var iconAdd = that.isPwdToShow ? 'fa-eye-slash' : 'fa-eye';
                $('#iconPwd').removeClass(iconRemove);
                $('#iconPwd').addClass(iconAdd);
                $('#pwddb').attr('type', type);
            },

            setPageTitle: function () {
                this.showAllTbas();
                this.setTitle(this.getName());
            },

            /**
             * ritorna true se il check sulla ripetizione password è corretto
             * @returns {boolean}
             */
            isValidPassword: function () {
                if (($("#pwdeasy").val() !== $("#rpassword").val()) ||
                    ($("#passwordweb").val() !== $("#rpasswordweb").val())) {
                    return false;
                }
                return true;
            },


            createExec: function (that) {

            },

            /**
             * Esegue la registrazione utente, inserendo i dati su tutte le tabelle che servono per la gestione dei privilegi
             * oltre che dei contatti
             * @param that
             * @returns {*}
             */
            registerUser: function (that) {
                var def = appMeta.Deferred("admin-registerUser");

                var isValidPassword = that.isValidPassword();
                if (!isValidPassword) {
                    return that.showMessageOk("Le password inserite non corrispondono")
                        .then(function () {
                            return def.resolve();
                        });
                }

                var waitingHandler = that.showWaitingIndicator("Attendi registrazione utente");
                appMeta.callWebService("adminregisteruser",
                    {
                        login: $("#uname").val(),
                        password: $("#pwdeasy").val(),
                        passwordweb: $("#passwordweb").val(),
                        surname: $("#surname").val(),
                        forename: $("#forename").val(),
                        cf: $("#cf").val(),
                        email: $("#email").val(),
                        codeflowchart: $("#codeflowchart").val(),
                        esercizio: $("#esercizio").val(),
                        usertype: $("#usertype").val(),
                        matricola: $("#matricola").val(),
                        userkind: $("#userKindsel").val()
                    })
                    .then(function (res) {
                        var err = res.err;
                        var msg = res.msg;
                        that.hideWaitingIndicator(waitingHandler);
                        that.showMessageOk(msg)
                            .then(function () {
                                def.resolve();
                            });
                    });

                return def.promise();
            },

            codificaPwdDb: function (that) {
                var def = appMeta.Deferred("admin-codificaPwdDb");
                var waitingHandler = that.showWaitingIndicator("Attendi mentre codifico i parametri di sistema");
                appMeta.callWebService("cryptSystemConfig",
                    {
                        password: $("#pwddb").val(),
                    })
                    .then(function (res) {
                        that.hideWaitingIndicator(waitingHandler);
                        $("#pwdcod").val(res)
                    });

                return def.promise();
            },

            /**
             * svuota le sessioni, quindi gli utenti sono costretti a far elogin di nuovo
             * @param that
             * @returns {*}
             */
            clearSessions: function (that) {
                var def = appMeta.Deferred("admin-registerUser");
                var waitingHandler = that.showWaitingIndicator("Attendi lapulizia delle sessioni utente");
                appMeta.callWebService("clearSessions", {})
                    .then(function () {
                        that.hideWaitingIndicator(waitingHandler);
                        def.resolve();
                    });
                return def.promise();
            },

            /**
             * ripulsice la cahce quindi anche le groupOperation, cioè i privilegi utente
             * @param that
             * @returns {*}
             */
            clearServerCache: function (that) {
                var def = appMeta.Deferred("admin-registerUser");
                var waitingHandler = that.showWaitingIndicator("Attendi registrazione utente");
                appMeta.callWebService("clearCache", {})
                    .then(function () {
                        that.hideWaitingIndicator(waitingHandler);
                        def.resolve();
                    });
                return def.promise();
            },

            /**
             * call doPostSilent
             * @param that
             */
            simulatedoPostSilent: function (that) {
                var dsjson = $("#jsondsid").val();
                var tableName = $("#tableNameId").val();
                var editType = $("#edittypeid").val();

                var ds = appMeta.getDataUtils.getJsDataSetFromJson(dsjson);

                var waitingHandler = that.showWaitingIndicator("salvataggio dataset in corso");

                appMeta.postData.doPostSilent(ds, tableName, editType, [])
                    .then(function (res, messages) {
                        if (messages && messages.length) {
                            return appMeta.postData.showErrorList(messages, false, that);
                        }
                        alert('Dataset salvato senza errori');
                        that.hideWaitingIndicator(waitingHandler);
                    }, function (err) {
                        that.hideWaitingIndicator(waitingHandler);
                    })
            },

            getTimbrature: function (that) {
                let formatDate = function (date) { // Torna la data nel formato AAAAmmdd
                    var d = new Date(date),
                        month = '' + (d.getMonth() + 1),
                        day = '' + d.getDate(),
                        year = d.getFullYear();

                    if (month.length < 2) month = '0' + month;
                    if (day.length < 2) day = '0' + day;

                    return [year, month, day].join('');
                }

                let matricole = $("#matricolaTimbrature").val(),
                    dataInizio = formatDate($("#alt_dataInizioTimbrature").val()),
                    dataFine = formatDate($("#alt_dataFineTimbrature").val());

                let waitingHandler = that.showWaitingIndicator('attendi chiamata servizio');

                console.log({
                    matricole: matricole,
                    dataInizio: dataInizio,
                    dataFine: dataFine
                });

                appMeta.callWebService("getTimbrature", {
                    matricola: matricole,
                    dateFrom: dataInizio,
                    dateTo: dataFine
                }).then(function (res) {
                    that.hideWaitingIndicator(waitingHandler);

                    if (res == "OK")
                        return alert("Dati salvati correttamente");
                    else {
                        console.error(res);
                        return alert("Attenzione! Si è verificato un errore");
                    }
                });
            },

            getCostoOrario: function (that) {
                let formatDate = function (date) { // Torna la data nel formato dd/mm/yyyy
                    if (!date)
                        return '';

                    var d = new Date(date),
                        month = '' + (d.getMonth() + 1),
                        day = '' + d.getDate(),
                        year = d.getFullYear();
                    if (isNaN(day) || isNaN(month) || isNaN(year))
                        return '';

                    if (month.length < 2) month = '0' + month;
                    if (day.length < 2) day = '0' + day;

                    return [day, month, year].join('/');
                }

                let matricole = $("#matricolaWsCostoOrario").val(),
                    dataElaborazione = formatDate($("#alt_dataInizioCostoOrario").val()),
                    dataStopCostoOrario = formatDate($("#alt_dataFineCostoOrario").val());

                let waitingHandler = that.showWaitingIndicator('attendi chiamata servizio');

                appMeta.callWebService("getCostoOrario", {
                    matricola: matricole,
                    dataElab: dataElaborazione,
                    dataStop: dataStopCostoOrario
                }).then(function (res) {
                    that.hideWaitingIndicator(waitingHandler);

                    console.warn("response:\n\n" + res);
                    if (res == "OK")
                        return alert("Dati salvati correttamente");
                    else {
                        console.error(res);
                        return alert("Attenzione! Si è verificato un errore\n\n" + res);
                    }
                });
            }
            //buttons
        });

    window.appMeta.addMetaPage('registry', 'admin', metaPage_registryAdmin);

}());

/*
select * from didprog
select * from diderog
select * from didprogcurr order by iddidprogcurr desc
select * from didprogporzanno order by iddidprogporzanno desc
select * from attivform order by idattivform desc
select * from attivformcaratteristica order by idattivformcaratteristica desc
select * from attivformcaratteristicaora order by idattivformcaratteristicaora desc
select * from canale order by idcanale desc
select * from affidamento order by idaffidamento desc
select * from affidamentocaratteristica order by idaffidamentocaratteristica desc
select * from affidamentocaratteristicaora order by idaffidamentocaratteristicaora desc
select * from insegn order by idinsegn desc
select * from insegninteg order by idinsegn desc
select * from insegncaratteristica order by idinsegn desc
select * from insegnintegcaratteristica order by idinsegn desc

declare @id int = 6;
delete from insegn where idinsegn = @id
delete from insegninteg where idinsegn = @id
delete from insegncaratteristica where idinsegn = @id
delete from insegnintegcaratteristica where idinsegn = @id


declare @id int = 15;
delete from didprog where iddidprog = @id
delete from didprogcurr where iddidprog = @id
delete from didprogcurrcaratteristica where iddidprog = @id
delete from didprogori where iddidprog = @id
delete from didproganno where iddidprog = @id
delete from didprogporzanno where iddidprog = @id
delete from attivform where iddidprog = @id
delete from attivformcaratteristica where iddidprog = @id
delete from attivformcaratteristicaora where iddidprog = @id
delete from canale where iddidprog = @id
delete from didprograppstud where iddidprog = @id
delete from didprogclassconsorsuale where iddidprog = @id
delete from affidamento where iddidprog = @id
delete from affidamentoattach where iddidprog = @id
delete from affidamentocaratteristica where iddidprog = @id
delete from affidamentocaratteristicaora where iddidprog = @id
delete from attivformproped where iddidprog = @id*/
