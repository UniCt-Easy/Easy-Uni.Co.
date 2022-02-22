
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
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonale() {
		MetaPage.apply(this, ['perfvalutazionepersonale', 'default', false]);
        this.name = 'Schede di valutazione del personale';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazionepersonale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazionepersonale,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-perfvalutazionepersonale_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazionepersonale_default_idreg());
				arraydef.push(this.manageperfvalutazionepersonale_default_percperfuo());
				arraydef.push(this.manageperfvalutazionepersonale_default_perccomportamenti());
				arraydef.push(this.manageperfvalutazionepersonale_default_percobiettivi());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.year)
					parentRow.year = new Date().getFullYear();
				this.manageperfvalutazionepersonale_default_idreg();
				this.manageperfvalutazionepersonale_default_percperfuo();
				this.manageperfvalutazionepersonale_default_perccomportamenti();
				this.manageperfvalutazionepersonale_default_percobiettivi();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazionepersonale_default");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleateneo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonalecomportamento'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleobiettivo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfinterazioni'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleattach'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfvalutazionepersonale_default_risultato'), false);
				this.enableControl($('#perfvalutazionepersonale_default_percperfuo'), false);
				this.enableControl($('#perfvalutazionepersonale_default_perccomportamenti'), false);
				this.enableControl($('#perfvalutazionepersonale_default_percobiettivi'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleateneo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonalecomportamento'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleobiettivo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfinterazioni'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleattach'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#perfvalutazionepersonale_default_pesocomportamenti').on("change", _.partial(this.managepesocomportamenti, self));
				$('#perfvalutazionepersonale_default_pesoobiettivi').on("change", _.partial(this.managepesoobiettivi, self));
				$('#perfvalutazionepersonale_default_pesoperfuo').on("change", _.partial(this.managepesoperfuo, self));
				appMeta.metaModel.cachedTable(this.getDataTable("getregistrydocentiamministratividefaultview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getregistrydocentiamministratividefaultview"));
				appMeta.metaModel.cachedTable(this.getDataTable("getregistrydocentiamministratividefaultview_alias1"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getregistrydocentiamministratividefaultview_alias1"));
				var grid_perfvalutazionepersonalecomportamento_defaultChildsTables = [
					{ tablename: 'perfvalutazionepersonalecomportamentosoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfvalutazionepersonalecomportamentosoglia'},
				];
				$('#grid_perfvalutazionepersonalecomportamento_default').data('childtables', grid_perfvalutazionepersonalecomportamento_defaultChildsTables);
				$('#grid_perfvalutazionepersonalecomportamento_default').data('childtablesadd', false);
				$('#grid_perfvalutazionepersonalecomportamento_default').data('childtablesedit', false);
				$('#grid_perfvalutazionepersonalecomportamento_default').data('childtablesdelete', false);
				var grid_perfvalutazionepersonaleobiettivo_defaultChildsTables = [
					{ tablename: 'perfvalutazionepersonalesoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfvalutazionepersonalesoglia'},
				];
				$('#grid_perfvalutazionepersonaleobiettivo_default').data('childtables', grid_perfvalutazionepersonaleobiettivo_defaultChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#perfvalutazionepersonale_default_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazionepersonale_default_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazionepersonale_default_year').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazionepersonale_default_year').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "year" && r !== null) {
 var filterResponsabile = self.q.eq('idreg', this.sec.usr('idreg'));
                    var filterRuolo = self.q.eq('idperfruolo', 'Responsabile');

                    var startgt = new Date();
                 
                    startgt.setMonth(0);
                    startgt.setDate(1);
                    startgt.setFullYear(r.year);
                    startgt.setHours(0, 0, 0, 0);
                    var filterDa = self.q.gt('convert(varchar,strutturaresponsabile_start,101)', startgt);
                    var filterDaEqual = self.q.eq('convert(varchar,strutturaresponsabile_start,101)', startgt);
                    var filterDaNull = self.q.isNull('strutturaresponsabile_start');
                    var filterOrDa = self.q.or(filterDa, filterDaEqual, filterDaNull);

                    var startlt = new Date();
                    startlt.setMonth(11);
                    startlt.setDate(31);
                    startlt.setFullYear(r.year);
                    startlt.setHours(23, 59, 59, 59);

                    var filterA = self.q.lt('convert(varchar,strutturaresponsabile_stop,101)', startlt);
                    var filterANull = self.q.isNull('strutturaresponsabile_stop');
                    var filterAEqual = self.q.eq('convert(varchar,strutturaresponsabile_stop,101)', startlt);
                    var filterOrA = self.q.or(filterA, filterAEqual, filterANull);

                    var filterAfferenteNotNull = self.q.isNotNull('afferente_idreg');


                    var filterValutatoNotLoggato = self.q.ne('afferente_idreg', this.sec.usr('idreg'));
                    var filterAll = self.q.and(filterResponsabile, filterRuolo, filterOrDa, filterOrA, filterAfferenteNotNull, filterValutatoNotLoggato);



                    if (self.state.currentRow && self.state.currentRow.idreg) {
                        var filterSelected = self.q.eq('afferente_idreg', self.state.currentRow.idreg);
                        filterAll = self.q.or(filterAll, filterSelected);
                    }

                    return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "*", filterAll).then(function (dt) {

                        filter = self.q.isIn("idreg", _.map(dt.rows,
                            function (row) {
                                if (row.afferente_idreg) {
                                    return row.afferente_idreg;
                                }
                                return true;
                            })
                        );

                        appMeta.metaModel.cachedTable(self.getDataTable("getregistrydocentiamministratividefaultview"), false);
                        var perfvalutazionepersonale_default_idregCtrl = $('#perfvalutazionepersonale_default_idreg').data("customController");

                        arraydef.push(perfvalutazionepersonale_default_idregCtrl.filteredPreFillCombo(filter, null, true)
                            .then(function (dt) {
                                if (self.state.currentRow && self.state.currentRow.idreg) {
                                    return perfvalutazionepersonale_default_idregCtrl.fillControl(null, self.state.currentRow.idreg);
                                }
                                return true;
                            })
                        );



                        return $.when.apply($, arraydef);
                    });
				}
				if (t.name === "getregistrydocentiamministratividefaultview" && r !== null) {
 if ((this.state.isInsertState() &&
                        (self.state.currentRow && self.state.currentRow.idreg > 0 &&
                            self.state.currentRow.idreg == $('#perfvalutazionepersonale_default_idreg').val()
                        )) || this.state.isSearchState())
                        return $.when.apply($, arraydef);


                    var filterListApprovatori;
                    var filterListValutatori;
                    self.state.currentRow.idreg = self.state.currentRow.idreg == 0 ? $('#perfvalutazionepersonale_default_idreg').val() : self.state.currentRow.idreg;
                    //Dalla struttura dell'afferente, recupero il valutatore da preselezionare
                    var filterValutato = self.q.eq('afferente_idreg', self.state.currentRow.idreg);

                    var filterRuolo = self.q.eq('idperfruolo', 'Valutatore');

                    var d = new Date();
                    var date = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate();

                    var filterDa = self.q.lt('convert(varchar,strutturaresponsabile_start,101)', date);

                    var filterDaEqual = self.q.eq('convert(varchar,strutturaresponsabile_start,101)', date);
                    var filterDaNull = self.q.isNull('strutturaresponsabile_start');
                    var filterOrDa = self.q.or(filterDa, filterDaEqual, filterDaNull);

                    var filterA = self.q.gt('convert(varchar,strutturaresponsabile_stop,101)', date);
                    var filterANull = self.q.isNull('strutturaresponsabile_stop');
                    var filterAEqual = self.q.eq('convert(varchar,strutturaresponsabile_stop,101)', date);
                    var filterOrA = self.q.or(filterA, filterAEqual, filterANull);

                    var filterIdRegNotNull = self.q.isNotNull('idreg');

                    var filterAll = self.q.and(filterValutato, filterRuolo, filterOrDa, filterOrA, filterIdRegNotNull);

                    if (self.state.currentRow.idreg_val)
                        filterAll = self.q.or(filterAll, self.q.eq('idreg', self.state.currentRow.idreg_val));


                    return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "*", filterAll).
                        then(function (dtVal) {
                            //se sono già stati selezionati o esistenti, non devo riselezionarli
                            if (!self.state.currentRow.idreg_val) {
                                if (dtVal.rows.length > 0) {
                                    self.state.currentRow.idreg_val = dtVal.rows[0].idreg;
                                }
                                else self.state.currentRow.idreg_val = null;
                            }

                            filterListValutatori = self.q.isIn("idreg", _.map(dtVal.rows,
                                function (row) {
                                    if (row.idreg) {
                                        return row.idreg;
                                    }
                                    return true;
                                })
                            );


                            var filterValutato = self.q.eq('afferente_idreg', self.state.currentRow.idreg);
                            var filterRuolo = self.q.eq('idperfruolo', 'Approvatore');


                            var filterDa = self.q.lt('convert(varchar,strutturaresponsabile_start,101)', date);
                            var filterDaEqual = self.q.eq('convert(varchar,strutturaresponsabile_start,101)', date);
                            var filterDaNull = self.q.isNull('strutturaresponsabile_start');
                            var filterOrDa = self.q.or(filterDa, filterDaEqual, filterDaNull);

                            var filterA = self.q.gt('convert(varchar,strutturaresponsabile_stop,101)', date);
                            var filterANull = self.q.isNull('strutturaresponsabile_stop');
                            var filterAEqual = self.q.eq('convert(varchar,strutturaresponsabile_stop,101)', date);
                            var filterOrA = self.q.or(filterA, filterAEqual, filterANull);

                            var filterIdRegNotNull = self.q.isNotNull('idreg');

                            var filterAll = self.q.and(filterValutato, filterRuolo, filterOrDa, filterOrA, filterIdRegNotNull);


                            if (self.state.currentRow.idreg_appr)
                                filterAll = self.q.or(filterAll, self.q.eq('idreg', self.state.currentRow.idreg_appr));

                            //Dalla struttura dell'afferente, recupero l'approvatore da preselzionare
                            return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "*", filterAll).
                                then(function (dtaff) {
                                    //se sono già stati selezionati o esistenti, non devo riselezionarli
                                    if (!self.state.currentRow.idreg_appr) {
                                        if (dtaff.rows.length > 0) {

                                            self.state.currentRow.idreg_appr = dtaff.rows[0].idreg;

                                        }
                                        else self.state.currentRow.idreg_appr = null;
                                    }

                                    filterListApprovatori = self.q.isIn("idreg", _.map(dtaff.rows,
                                        function (row) {
                                            if (row.idreg) {
                                                return row.idreg;
                                            }
                                            return true;
                                        })
                                    );


                                    appMeta.metaModel.cachedTable(self.getDataTable("getregistrydocentiamministratividefaultview_alias1"), false);
                                    var perfvalutazionepersonale_default_idreg_valCtrl = $('#perfvalutazionepersonale_default_idreg_val').data("customController");
                                    arraydef.push(perfvalutazionepersonale_default_idreg_valCtrl.filteredPreFillCombo(filterListValutatori, null, true)
                                        .then(function (dt) {
                                            if (self.state.currentRow && self.state.currentRow.idreg_val) {
                                                return perfvalutazionepersonale_default_idreg_valCtrl.fillControl(null, self.state.currentRow.idreg_val);
                                            }
                                            return true;
                                        })
                                    );


                                    appMeta.metaModel.cachedTable(self.getDataTable("getregistrydocentiamministratividefaultview_alias2"), false);
                                    var perfvalutazionepersonale_default_idreg_apprCtrl = $('#perfvalutazionepersonale_default_idreg_appr').data("customController");
                                    arraydef.push(perfvalutazionepersonale_default_idreg_apprCtrl.filteredPreFillCombo(filterListApprovatori, null, true)
                                        .then(function (dt) {
                                            if (self.state.currentRow && self.state.currentRow.idreg_appr) {
                                                return perfvalutazionepersonale_default_idreg_apprCtrl.fillControl(null, self.state.currentRow.idreg_appr);
                                            }
                                            return true;
                                        })
                                    );


                                })
                                .then(function () {

                                    if (self.state.isInsertState()) {

                                        self.getComportamenti(null);
                                    }

                                    return true;
                                });


                            return $.when.apply($, arraydef);


                        });

				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			
			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#perfvalutazionepersonale_default_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Valutato');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			calculateRisultatoPerc: function () {
				if (this.state.currentRow) {
					var arrayRisultato = [//{ valore: this.state.currentRow.percateneo, peso: this.state.currentRow.pesoateneo },
						{ valore: this.state.currentRow.percperfuo, peso: this.state.currentRow.pesoperfuo },
						{ valore: this.state.currentRow.perccomportamenti, peso: this.state.currentRow.pesocomportamenti },
						{ valore: this.state.currentRow.percobiettivi, peso: this.state.currentRow.pesoobiettivi },
					];
					var pa = this.getDataTable("perfvalutazionepersonaleateneo");
					if (pa.rows.length > 0)
						arrayRisultato.push({ valore: pa.punteggio, peso: pa.peso });
					var average = this.calculateWeightedAverage(arrayRisultato);
					if(this.state.currentRow.risultato != average)
						this.state.currentRow.risultato = average;
				}
			},

            assignPercentuali: function (tableName, columnName) {
            if (this.getDataTable(tableName).rows.length > 0) {
               var arrayIndicatori = _.map(this.getDataTable(tableName).rows, function (r) { return { valore: r.completamento, peso: r.peso } });
               var average = this.calculateWeightedAverage(arrayIndicatori);
               if (average === this.state.currentRow[columnName]) {
                  return;
               }
               this.state.currentRow[columnName] = average;
               this.calculateRisultatoPerc();
            }
         },
   getComportamenti: function (prm) {
                if (!this.state.currentRow || !(this.state.isInsertState() && (this.getDataTable('perfvalutazionepersonalecomportamento').rows == 0))) {
                    return;
                }
                var grid = $('#grid_perfvalutazionepersonalecomportamento_default').data("customController");

                if (grid.gridRows.length > 0)
                    return;


                var self = this;
                var IsIn = false;
                var def = appMeta.Deferred("getCompotamenti");
                var chain = $.when(); //inizializzo la chain


                var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

                appMeta.callWebService("calcolaComportamenti",
                    {
                        idRegValutato: self.state.currentRow.idreg == 0 ? $('#perfvalutazionepersonale_default_idreg').val() : self.state.currentRow.idreg,
                        year: this.state.currentRow.year,
                        idRegResp: this.sec.usr('idreg'),
                        idRuolo: 'Responsabile'
                    }).then(function (resDt) {
                        var comportamentoDt = appMeta.getDataUtils.getJsDataTableFromJson(resDt);
                        var comportamentoTable = self.getDataTable("perfcomportamento");

                        appMeta.getDataUtils.mergeRowsIntoTable(comportamentoTable, comportamentoDt.rows, true);

                        _.forEach(comportamentoTable.rows, function (comportamentoRows) {

                            //il merge è fatto su perfcomportamento, righe sdoppiate su perfvalutazionepersonalecomportamento se inserisco i comportamenti presenti già sul dataset.
                            _.forEach(self.getDataTable("perfvalutazionepersonalecomportamento").rows, function (perfcompRows) {

                                IsIn = IsIn || (perfcompRows.idperfcomportamento == comportamentoRows.idperfcomportamento);

                                return true;
                            });

                            if (IsIn)
                                return;

                            chain = chain.then(function () {

                                var meta = appMeta.getMeta("perfvalutazionepersonalecomportamento");

                                meta.setDefaults(self.getDataTable("perfvalutazionepersonalecomportamento"));

                                return meta.getNewRow(self.state.currentRow, self.getDataTable("perfvalutazionepersonalecomportamento")).then(function (row) {
                                    row.current.idperfcomportamento = comportamentoRows.idperfcomportamento;
                                    row.current.idperfvalutazionepersonale = self.state.currentRow.idperfvalutazionepersonale;

                                    return true;

                                });
                            });
                        });//chiudo primo foreach
                        return chain; //chiudo la chain
                    }).then(function () {

                        chain = $.when();
                        var i = 0;
                        _.forEach(self.getDataTable("perfvalutazionepersonalecomportamento").rows, function (comportamentoRows) {
                            chain = chain.then(function () {
                                var filterYear = window.jsDataQuery.eq('year', self.state.currentRow.year);
                                var filterComportamento = window.jsDataQuery.eq('idperfcomportamento', comportamentoRows.idperfcomportamento);
                                var filter = window.jsDataQuery.and(filterYear, filterComportamento);
                                //visualizzo il messaggio solo per l'ultimo inserimento
                                if (i != self.getDataTable("perfvalutazionepersonalecomportamento").rows.length - 1) {
                                    message = false;
                                }
                                else message = null;
                                i++;

                                return self.superClass.insertSoglie({
                                    table: "perfvalutazionepersonalecomportamentosoglia", tableSoglie: "perfcomportamentosoglia", tableParent: "", keyColumns: "idperfvalutazionepersonale=" + comportamentoRows.idperfvalutazionepersonale + ",idperfvalutazionepersonalecomportamento=" + comportamentoRows.idperfvalutazionepersonalecomportamento, filter: filter, desMessage: message
                                });

                            });

                        });

                        return chain;

                    }).then(function () {

                        if (grid.gridRows.length == 0) {
                            appMeta.metaModel.getTemporaryValues(self.getDataTable("perfvalutazionepersonalecomportamento"));
                        }
                        return grid.fillControl();
                    }).then(function () {


                        self.hideWaitingIndicator(waitingHandler);
                        return def.resolve();

                    });


                return def.promise();
            },
rowSelected: function () {
				this.stateValue = this.state.currentRow.idperfschedastatus;
			},
			afterPost: function () {

				// è stato cliccato annulla o elimina non invio mail
				if (!this.state.currentRow.getRow) {
					return;
				}
				if (this.stateValue == this.state.currentRow.idperfschedastatus || !this.state.currentRow.idperfschedastatus)
					return;
				var self = this;

				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				var destinatari = [];
				var filterRuolo;
				var filterDestinatario;
				var body;
				var ruoloDestinatario;
				var ruoloLoggato;
				var destinatario;
				var loggato;
				var valutato;
				var invio = false;
				var def = appMeta.Deferred("fireSendMail");
				var sendMail = '';
				//rivedere recupero ruolo loggato
				ruoloLoggato = 'Responsabile';


				destinatari.push([self.state.currentRow.idreg_val, 'Valutatore']);
				destinatari.push([self.state.currentRow.idreg_appr, 'Approvatore']);
				destinatari.push([self.state.currentRow.idreg, 'Valutato']);


				if (self.state.currentRow.idreg_val == self.sec.usrEnv.idreg) {
					filterReg = self.q.eq('idreg', self.state.currentRow.idreg_val);
					ruoloLoggato = 'Valutatore';

				}

				if (self.state.currentRow.idreg_appr == self.sec.usrEnv.idreg) {
					filterReg = self.q.eq('idreg', self.state.currentRow.idreg_appr);
					ruoloLoggato = 'Approvatore';

				}

				if (self.state.currentRow.idreg == self.sec.usrEnv.idreg) {
					filterReg = self.q.eq('idreg', self.state.currentRow.idreg);
					ruoloLoggato = 'Valutato';
				}

				filterRuolo = self.q.eq('idperfruolo', ruoloLoggato);

				var filterStato = self.q.eq('idperfschedastatus', this.stateValue)
				if (!this.stateValue)
					filterStato = self.q.isNull(self.state.currentRow.idperfschedastatus);
				var filterStatoTo = self.q.eq('idperfschedastatus_to', self.state.currentRow.idperfschedastatus)
				var filterAll = self.q.and(filterStato, filterStatoTo, filterRuolo);

				return appMeta.getData.runSelect("perfschedacambiostato", "*", filterAll)
					.then(function (dtCambiostato) {
						self.stateValue = self.state.currentRow.idperfschedastatus;
						if (dtCambiostato.rows.length == 0 || !dtCambiostato.rows[0].idperfruolo_mail) {
                                                        self.hideWaitingIndicator(waitingHandler);
							return def.resolve();
						}
						if (dtCambiostato.rows.length > 0) {

							self.hideWaitingIndicator(waitingHandler);
							waitingHandler = self.showWaitingIndicator('Invio mail');
							invio = true;
						}
						else return;
						return self.superClass.getRegistryreference(self.state.currentRow.idreg)
							.then(function (dsValutato) {
								valutato = dsValutato[0];
								return self.superClass.getRegistryreference(self.sec.usrEnv.idreg)
									.then(function (dsLoggato) {
										loggato = dsLoggato[0];


										var filterStato = self.q.eq('idperfschedastatus', self.state.currentRow.idperfschedastatus);

										return appMeta.getData.runSelect("perfschedastatus", "*", filterStato)
											.then(function (dsStato) {


												var chain = $.when();
												var arrayDef = [];

												_.forEach(dtCambiostato.rows, function (cambiostato) {
													chain = chain.then(function () {


														//recupero il ruolo
														var dest = _.find(destinatari, function (item) {
															if (item[1] == cambiostato.idperfruolo_mail)
																return item[0];
															return;
														});

														if (!dest)
															return;

														return self.superClass.getRegistryreference(dest[0])
															.then(function (dsRows) {

																destinatario = dsRows[0];
																if (sendMail.includes(destinatario.email) > 0)
																	return;

																body = "Gentile " + destinatario.email;
																subject = "Modifica stato scheda valutazione personale";
																if (dest[1] != 'Valutato') {

																	body += ", <br>" + dest[1].toLowerCase() + " della valutazione personale di " + valutato.email;
																	subject += " di " + valutato.email;
																}

																body += ", l'utente " + loggato.email + " ha modificato lo stato della scheda in  \"" + dsStato.rows[0].title + "\".";

																sendMail += destinatario.email + ";";
																return self.superClass.sendMail({ emailDest: destinatario.email, body: body, subject: subject, viewMessage: false })

															});
													});
													arrayDef.push(chain);
												});
												return $.when.apply($, arrayDef).then(function (msg) {



													self.hideWaitingIndicator(waitingHandler);

													if (!msg && invio) {

														msg = 'Invio mail avvenuto con successo';
													}

													if (msg)
														return self.showMessageOk(msg);

												});

											});



									});
							});
					});
				def.promise();

			},
stateValue: null,

			managepesocomportamenti: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazionepersonale.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazionepersonale_default_risultato').val(value);
				});
			},

			managepesoobiettivi: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazionepersonale.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazionepersonale_default_risultato').val(value);
				});
			},

			managepesoperfuo: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazionepersonale.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazionepersonale_default_risultato').val(value);
				});
			},

			manageperfvalutazionepersonale_default_idreg: function () {
	var grid = this.getCustomControl('perfvalutazionepersonalecomportamento.default.default');
				if (this.state.currentRow.idreg > 0 && grid.gridRows.length == 0 && !this.state.isInsertState()) {
					this.getComportamenti(null);
				}
			},

			manageperfvalutazionepersonale_default_percperfuo: function () {
				//Percentuale di completamento dell’unità organizzativa
				this.assignPercentuali("perfvalutazionepersonaleuo", "percperfuo");
			},

			manageperfvalutazionepersonale_default_perccomportamenti: function () {
				//Percentuale di completamento dei comportamenti attesi
				 this.assignPercentuali("perfvalutazionepersonalecomportamento", "perccomportamenti");


			},

			manageperfvalutazionepersonale_default_percobiettivi: function () {
				//Percentuale di completamento degli obiettivi individuali
				this.assignPercentuali("perfvalutazionepersonaleobiettivo", "percobiettivi");
			},

			children: ['perfinterazioni', 'perfvalutazionepersonaleateneo', 'perfvalutazionepersonaleattach', 'perfvalutazionepersonalecomportamento', 'perfvalutazionepersonaleobiettivo', 'perfvalutazionepersonaleuo'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazionepersonale', 'default', metaPage_perfvalutazionepersonale);

}());
