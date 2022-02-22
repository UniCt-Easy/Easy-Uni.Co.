
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

    function metaPage_perfvalutazioneuo() {
		MetaPage.apply(this, ['perfvalutazioneuo', 'default', false]);
        this.name = 'Schede di valutazione delle Unità organizzative';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneuo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneuo,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazioneuo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazioneuo_default_idstruttura());
				arraydef.push(this.manageperfvalutazioneuo_default_completamentopsuo());
				arraydef.push(this.manageperfvalutazioneuo_default_completamentopsauo());
				arraydef.push(this.manageperfvalutazioneuo_default_indicatori());
				arraydef.push(this.manageperfvalutazioneuo_default_obiettiviindividuali());
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
				this.manageperfvalutazioneuo_default_idstruttura();
				this.manageperfvalutazioneuo_default_completamentopsuo();
				this.manageperfvalutazioneuo_default_completamentopsauo();
				this.manageperfvalutazioneuo_default_indicatori();
				this.manageperfvalutazioneuo_default_obiettiviindividuali();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneuo_default");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoindicatori'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuoindicatori'), this.getDataTable('perfvalutazioneuoindicatorisoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfobiettiviuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoattach'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfvalutazioneuo_default_risultato'), false);
				this.enableControl($('#perfvalutazioneuo_default_completamentopsuo'), false);
				this.enableControl($('#perfvalutazioneuo_default_completamentopsauo'), false);
				this.enableControl($('#perfvalutazioneuo_default_indicatori'), false);
				this.enableControl($('#perfvalutazioneuo_default_obiettiviindividuali'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoindicatori'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuoindicatori'), this.getDataTable('perfvalutazioneuoindicatorisoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfobiettiviuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoattach'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.calculateRisultatoPerc();
				$('#perfvalutazioneuo_default_pesoindicatori').on("change", _.partial(this.managepesoindicatori, self));
				$('#perfvalutazioneuo_default_pesoobiettivi').on("change", _.partial(this.managepesoobiettivi, self));
				$('#perfvalutazioneuo_default_pesoprogaltreuo').on("change", _.partial(this.managepesoprogaltreuo, self));
				$('#perfvalutazioneuo_default_pesoproguo').on("change", _.partial(this.managepesoproguo, self));
				appMeta.metaModel.cachedTable(this.getDataTable("strutturaperfelenchiview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("strutturaperfelenchiview"));
				appMeta.metaModel.cachedTable(this.getDataTable("getregistrydocentiamministratividefaultview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getregistrydocentiamministratividefaultview"));
				var grid_perfprogettoobiettivouoview_defaultChildsTables = [
					{ tablename: 'perfprogettoobiettivosoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfprogettoobiettivosoglia'},
				];
				$('#grid_perfprogettoobiettivouoview_default').data('childtables', grid_perfprogettoobiettivouoview_defaultChildsTables);
				$('#grid_perfprogettoobiettivouoview_default').data('childtablesadd', false);
				$('#grid_perfprogettoobiettivouoview_default').data('childtablesedit', false);
				$('#grid_perfprogettoobiettivouoview_default').data('childtablesdelete', false);
				var grid_perfprogettoobiettivopersonaleview_defaultChildsTables = [
					{ tablename: 'perfprogettoobiettivosoglia_alias1', edittype: 'default', columnlookup: 'description', columncalc: '!perfprogettoobiettivosoglia_alias1'},
				];
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtables', grid_perfprogettoobiettivopersonaleview_defaultChildsTables);
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtablesadd', false);
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtablesedit', false);
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtablesdelete', false);
				var grid_perfvalutazioneuoindicatori_defaultChildsTables = [
					{ tablename: 'perfvalutazioneuoindicatorisoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfvalutazioneuoindicatorisoglia'},
				];
				$('#grid_perfvalutazioneuoindicatori_default').data('childtables', grid_perfvalutazioneuoindicatori_defaultChildsTables);
				$('#grid_perfvalutazioneuoindicatori_default').data('childtablesadd', false);
				$('#grid_perfvalutazioneuoindicatori_default').data('childtablesedit', false);
				$('#grid_perfvalutazioneuoindicatori_default').data('childtablesdelete', false);
				var grid_perfobiettiviuo_defaultChildsTables = [
					{ tablename: 'perfobiettiviuosoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfobiettiviuosoglia'},
				];
				$('#grid_perfobiettiviuo_default').data('childtables', grid_perfobiettiviuo_defaultChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#perfvalutazioneuo_default_idstruttura').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazioneuo_default_idstruttura').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazioneuo_default_year').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#perfvalutazioneuo_default_year').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "year" && r !== null) {
 var filterResponsabile = self.q.eq('idreg', this.sec.usr('idreg'));
                    var filterRuolo = self.q.eq('idperfruolo', 'Responsabile');
             
                    var startdA =  appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(r.year,0,1), true);
               
                    var filterDa = self.q.lt('start', startdA);
                    var filterDaEq = self.q.eq('start', startdA);
                    var filterDaNull = self.q.isNull('start');
                    var filterOrDa = self.q.or(filterDa, filterDaNull, filterDaEq);

                    var startA = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(r.year,11,31), true);
                
                    var filterA = self.q.gt('stop', startA);
                    var filterANull = self.q.isNull('stop');
                    var filterAEq = self.q.eq('stop', startA);
                    var filterOrA = self.q.or(filterA, filterANull, filterAEq);

                    var filterStrutturaNotNull = self.q.isNotNull('idstruttura');


                    var filterAll = self.q.and(filterResponsabile, filterRuolo, filterOrDa, filterOrA, filterStrutturaNotNull);


                    if (self.state.currentRow && self.state.currentRow.idreg) {
                        var filterSelected = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
                        filterAll = self.q.or(filterAll, filterSelected);
                    }

                    return appMeta.getData.runSelect("strutturaparentresponsabiliview", "idstruttura", filterAll).then(function (dt) {


                        filter = self.q.isIn("idstruttura", _.map(dt.rows,
                            function (row) {
                                if (row.idstruttura) {
                                    return row.idstruttura;
                                }
                                return true;

                            })
                        );


                        appMeta.metaModel.cachedTable(self.getDataTable("strutturaperfelenchiview"), false);
                        var perfvalutazioneuo_default_idstruttura = $('#perfvalutazioneuo_default_idstruttura').data("customController");

                        arraydef.push(perfvalutazioneuo_default_idstruttura.filteredPreFillCombo(filter, null, true)
                            .then(function (dt) {
                                if (self.state.currentRow && self.state.currentRow.idstruttura)
                                    perfvalutazioneuo_default_idstruttura.fillControl(null, self.state.currentRow.idstruttura);
                                return true;
                            })
                        );
                        return $.when.apply($, arraydef);

                    });
				}
				if (t.name === "strutturaperfelenchiview" && r !== null) {
if ((this.state.isInsertState() && (self.state.currentRow && self.state.currentRow.idstruttura > 0 && self.state.currentRow.idstruttura == $('perfvalutazioneuo_default_idstruttura').val())) ||
                        this.state.isSearchState())
                        return $.when.apply($, arraydef);

                    var filterListApprovatori;
                    var filterListValutatori;
                    self.state.currentRow.idstruttura = self.state.currentRow.idstruttura == 0 ? $('#perfvalutazioneuo_default_idstruttura').val() : self.state.currentRow.idstruttura;

                    //Recupero il valutatore da preselezionare
                    var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
                    var filterRuolo = self.q.eq('idperfruolo', 'Valutatore');

                     var startdA = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date($('#perfvalutazioneuo_default_year').val(), 0, 1), true)

                    var filterDa = self.q.lt('start', startdA);
                    var filterEqDa = self.q.eq('start', startdA);
                    var filterDaNull = self.q.isNull('start');
                    var filterOrDa = self.q.or(filterDa, filterDaNull, filterEqDa);
                                     
                    var startA = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date($('#perfvalutazioneuo_default_year').val(),11,1), true);


                    var filterA = self.q.gt('stop', startA);
                    var filterEqA = self.q.eq('stop', startA);
                    var filterANull = self.q.isNull('stop');

                    var filterOrA = self.q.or(filterA, filterANull, filterEqA);

                    var filterIdRegNotNull = self.q.isNotNull('idreg');

                    var filterAll = self.q.and(filterStruttura, filterRuolo, filterOrDa, filterOrA, filterIdRegNotNull);

                    if (self.state.currentRow.idreg_val)
                        filterAll = self.q.or(filterAll, self.q.eq('idreg', self.state.currentRow.idreg_val));

                    return appMeta.getData.runSelect("strutturaparentresponsabiliview", "*", filterAll).
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
                            var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);
                            var filterRuolo = self.q.eq('idperfruolo', 'Approvatore');

                            var startdA = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date($('#perfvalutazioneuo_default_year').val(), 0, 1), true)

                           

                            var filterDa = self.q.lt('start', startdA);
                            var filterEqDa = self.q.eq('start', startdA);
                            var filterDaNull = self.q.isNull('start');
                            var filterOrDa = self.q.or(filterDa, filterDaNull, filterEqDa);

                            var startA = appMeta.getDataUtils.normalizeDataWithoutOffsetTimezone(new Date($('#perfvalutazioneuo_default_year').val(), 11, 31), true)

                            var filterA = self.q.gt('stop', startA);
                            var filterEqA = self.q.eq('stop', startA);
                            var filterANull = self.q.isNull('stop');

                            var filterOrA = self.q.or(filterA, filterANull, filterEqA);

                            var filterIdRegNotNull = self.q.isNotNull('idreg');

                            var filterAll = self.q.and(filterStruttura, filterRuolo, filterOrDa, filterOrA, filterIdRegNotNull);

                            if (self.state.currentRow.idreg_appr)
                                filterAll = self.q.or(filterAll, self.q.eq('idreg', self.state.currentRow.idreg_appr));

                            //Recupero l'approvatore da preselzionare
                            return appMeta.getData.runSelect("strutturaparentresponsabiliview", "*", filterAll).
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


                                    appMeta.metaModel.cachedTable(self.getDataTable("getregistrydocentiamministratividefaultview"), false);
                                    var perfvalutazioneuo_default_idreg_valCtrl = $('#perfvalutazioneuo_default_idreg_val').data("customController");
                                    arraydef.push(perfvalutazioneuo_default_idreg_valCtrl.filteredPreFillCombo(filterListValutatori, null, true)
                                        .then(function (dt) {
                                            if (self.state.currentRow && self.state.currentRow.idreg_val)
                                                return perfvalutazioneuo_default_idreg_valCtrl.fillControl(null, self.state.currentRow.idreg_val);
                                            return true;
                                        })
                                    );


                                    appMeta.metaModel.cachedTable(self.getDataTable("getregistrydocentiamministratividefaultview_alias1"), false);
                                    var perfvalutazioneuo_default_idreg_apprCtrl = $('#perfvalutazioneuo_default_idreg_appr').data("customController");
                                    arraydef.push(perfvalutazioneuo_default_idreg_apprCtrl.filteredPreFillCombo(filterListApprovatori, null, true)
                                        .then(function (dt) {
                                            if (self.state.currentRow && self.state.currentRow.idreg_appr)
                                                return perfvalutazioneuo_default_idreg_apprCtrl.fillControl(null, self.state.currentRow.idreg_appr);
                                            return true;
                                        })
                                    );


                                }).then(function () {
                                    if (self.state.isInsertState()) {
                                        self.calculateIndicatori(null).then(function () {
                                            if (self.state.currentRow && self.getDataTable("perfvalutazioneuoindicatori").rows) {

                                                $('#perfvalutazioneuo_default_idstruttura').prop("disabled", true);
                                                $('#perfvalutazioneuo_default_idstruttura').prop("readonly", true);
                                                $('#perfvalutazioneuo_default_year').prop("disabled", true);
                                                $('#perfvalutazioneuo_default_year').prop("readonly", true);
                                            }
                                            return true;
                                        });
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
				if (!$('#perfvalutazioneuo_default_idstruttura').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Unità organizzativa');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('perfprogettoobiettivouoview').acceptChanges();
				this.getDataTable('perfprogettoobiettivopersonaleview').acceptChanges();
				//innerBeforePost
			},

			alreadySelected: false,
stateValue: null,
 calculateIndicatori: function (prm) {
                if (!this.state.currentRow || !(this.state.isInsertState() && (this.getDataTable("perfvalutazioneuoindicatori").rows == 0)))
                {
                    return;
                }
                var grid = this.getCustomControl('perfvalutazioneuoindicatori.default.default');


                if (grid.gridRows.length > 0)
                    return;

                var waitingHandler = this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
                var def = appMeta.Deferred("calculateIndicatori");

                var self = this;
                var filterPerfIndicatore;
                var idstruttura = self.state.currentRow.idstruttura == 0 ? $('#perfvalutazioneuo_default_idstruttura').val() : self.state.currentRow.idstruttura;
                var filter = this.q.eq("idstruttura", idstruttura);

                var chain = $.when();
                var arrayDef = [];
                var rows;
                var sogliaTable;



                appMeta.getData.runSelect("perfstrutturaperfindicatore", "idstruttura,idperfindicatore", filter)
                    .then(function (dtPerfstrutturaPerfindicatore) {
                        filterPerfIndicatore = self.q.isIn("idperfindicatore", _.map(dtPerfstrutturaPerfindicatore.rows, function (r) { return r.idperfindicatore; }));

                        return appMeta.getData.runSelectIntoTable(self.getDataTable("perfindicatore"), filterPerfIndicatore)
                    }).then(function () {

                        var filterAnnoScheda = self.q.eq("year", self.state.currentRow.year);

                        var filterAnd = self.q.and(filterPerfIndicatore, filterAnnoScheda);

                        return appMeta.getData.runSelect("perfindicatoresoglia", "*", filterAnd)
                    }).then(function (dtIndicatoreSoglia) {
                        sogliaTable = dtIndicatoreSoglia.rows;

                        rows = _.uniqBy(sogliaTable, "idperfindicatore");

                        var meta = appMeta.getMeta("perfvalutazioneuoindicatori");

                        var dt = self.getDataTable("perfvalutazioneuoindicatori");

                        meta.setDefaults(dt);

                        _.forEach(rows, function (indicatoreRow) {
                            if (indicatoreRow.getRow().state != jsDataSet.dataRowState.added && !self.state.isInsertState())
                                return;

                            chain = chain.then(function () {

                                return self.costruisciPerfvalutazioneuoindicatori(indicatoreRow);
                            });

                            arrayDef.push(chain);

                        });

                        return $.when.apply($, arrayDef);
                    }).then(function () {

                        //riaggiorno la tabella manualmente con i dati calcolati dopo che la carichiamo
                        appMeta.metaModel.getTemporaryValues(self.getDataTable("perfvalutazioneuoindicatori"));

                        chain = $.when();
                        arrayDef = [];
                        var meta = appMeta.getMeta("perfvalutazioneuoindicatorisoglia");


                        var dt = self.getDataTable("perfvalutazioneuoindicatorisoglia");
                        meta.setDefaults(dt);

                        _.forEach(sogliaTable, function (sogliaRow) {
                            if (sogliaRow.getRow().state != jsDataSet.dataRowState.added && !self.state.isInsertState())
                                return;

                            chain = chain.then(function () {
                                return self.costruisciPerfvalutazioneuoindicatorisoglia(sogliaRow, self.getDataTable("perfvalutazioneuoindicatori"));
                            });

                            arrayDef.push(chain);

                        });
                        return $.when.apply($, arrayDef);
                    }).then(function () {

                        appMeta.metaModel.getTemporaryValues(self.getDataTable("perfvalutazioneuoindicatorisoglia"));

                        var gridControl = $('#grid_perfvalutazioneuoindicatori_default').data("customController");
                        if (gridControl&& gridControl.rows > 0) {
                            return gridControl.fillControl();
                        }

                    }).then(function () {

                        self.hideWaitingIndicator(waitingHandler);
                        def.resolve();

                    });
                return def.promise();
            },

			costruisciPerfvalutazioneuoindicatorisoglia: function (sogliaRow, perfvalutazioneuoindicatori) {
				var def = appMeta.Deferred("costruisciriga");

				var meta = appMeta.getMeta("perfvalutazioneuoindicatorisoglia");
				var self = this;


				var idperfvalutazioneuoindicatori = 0;
				var filter = self.q.eq("idperfindicatore", sogliaRow.idperfindicatore);
				var rows = perfvalutazioneuoindicatori.select(filter);
				if (rows.length > 0) {
					idperfvalutazioneuoindicatori = rows[0].idperfvalutazioneuoindicatori;
					meta.getNewRow(this.state.currentRow.getRow(), this.getDataTable("perfvalutazioneuoindicatorisoglia")).then(function (row) {
						row.current.idperfvalutazioneuoindicatorisoglia = sogliaRow.idperfindicatoresoglia;
						row.current.idperfvalutazioneuoindicatori = idperfvalutazioneuoindicatori;
						row.current.valore = sogliaRow.valore;
						row.current.description = sogliaRow.description;
						row.current.valorenumerico = sogliaRow.valorenumerico;
						row.current.idperfsogliakind = sogliaRow.idperfsogliakind;
						row.current.year = sogliaRow.year;

						def.resolve();
					});
					return def.promise();
				}

				return def.resolve();
			},
			calculateRisultatoPerc: function () {
				if (!this.state.currentRow) {
					return;
				}
				var arrayRisultato = [{ valore: this.state.currentRow.completamentopsuo, peso: this.state.currentRow.pesoproguo },
				{ valore: this.state.currentRow.completamentopsauo, peso: this.state.currentRow.pesoprogaltreuo },
				{ valore: this.state.currentRow.indicatori, peso: this.state.currentRow.pesoindicatori },
				{ valore: this.state.currentRow.obiettiviindividuali, peso: this.state.currentRow.pesoobiettivi }];
				var average = this.calculateWeightedAverage(arrayRisultato);
				this.state.currentRow.risultato = average;
			},
afterPost: function () {

                if (!this.state.currentRow.getRow) {
                    return;
                }
                if (this.stateValue == this.state.currentRow.idperfschedastatus || !this.state.currentRow.idperfschedastatus)
                    return;

                var self = this;
                var destinatari = [];
                var destinatariDbRow = [];
                var invio = false;
                var exit = false;
                var ruoloLoggato;
                var titleLoggato;
                var titleStruttura;
                var strutturaRows;
                var def = appMeta.Deferred("afterPost");
                var parentRow = self.state.currentRow;
                var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

                var filter = this.q.and([this.q.eq("idperfvalutazioneuo", parentRow.idperfvalutazioneuo), this.q.eq("idstruttura", parentRow.idstruttura)]);
                var selBuilderArray = [];
                var tableToRefresh = ['perfprogettoobiettivouoview', 'perfprogettoobiettivopersonaleview'];
                _.forEach(tableToRefresh, function (tname) {
                    selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: self.state.DS.tables[tname] });
                });

                appMeta.getData.multiRunSelect(selBuilderArray)
                    .then(function () {
                        return self.freshForm(false, false)
                    })
                    .then(function () {

                        // è stato cliccato annulla o elimina non invio mail
                        if (!self.state.currentRow.getRow) {
                            exit = true;
                            return def.resolve();
                        }

                        //lo stato è rimasto lo stesso, o non viene inizialmente inserito non invio mail
                        if (self.stateValue == self.state.currentRow.idperfschedastatus || !self.state.currentRow.idperfschedastatus) {
                            exit = true;
                            return def.resolve();
                        }

                        //verifico se deve essere inviata una mail

                        var startdA = new Date();
                        startdA.setMonth(11);
                        startdA.setDate(31);

                        startdA.setFullYear(self.state.currentRow.year - 1);

                        var filterDa = self.q.lt('convert(varchar,start,101)', startdA);
                        var filterDaNull = self.q.isNull('start');
                        var filterOrDa = self.q.or(filterDa, filterDaNull);

                        var startA = new Date();
                        startA.setMonth(0);
                        startA.setDate(1);
                        startA.setFullYear(self.state.currentRow.year + 1);


                        var filterA = self.q.gt('convert(varchar,stop,101)', startA);
                        var filterANull = self.q.isNull('stop');

                        var filterOrA = self.q.or(filterA, filterANull);

                        var filterStruttura = self.q.eq('idstruttura', self.state.currentRow.idstruttura);


                        //var filterValutatore = self.q.eq('idreg', self.state.currentRow.idreg_val);
                        //var filterApprovatore = self.q.eq('idreg', self.state.currentRow.idreg_appr);

                        //var filterOr = self.q.or(filterValutatore, filterApprovatore);

                        var filterAll = self.q.and(filterOrDa, filterOrA, filterStruttura);

                        return appMeta.getData.runSelect("strutturaparentresponsabiliview", "*", filterAll)
                    })
                    .then(function (dtStruttura) {
                        if (exit) {
                            return;
                        }
                        strutturaRows = dtStruttura.rows;

                        _.forEach(strutturaRows, function (row) {
                            if (row.idreg == self.sec.usrEnv.idreg) {
                                ruoloLoggato = row.idperfruolo;
                                titleLoggato = row.registry_title;
                                titleStruttura = row.title;
                                return false;
                            }
                        });

                        //vecchio stato scheda
                        var filterStato = self.q.eq('idperfschedastatus', self.stateValue);
                        //se è il primo stato che viene salvato alla scheda setto lo stato attuale come quello di partenza
                        if (!self.stateValue) {
                            filterStato = self.q.isNull(self.state.currentRow.idperfschedastatus);
                        }

                        //nuovo stato scheda
                        var filterStatoTo = self.q.eq('idperfschedastatus_to', self.state.currentRow.idperfschedastatus);

                        var filterRuolo = self.q.eq('idperfruolo', ruoloLoggato);
                        var filterAll = self.q.and(filterStato, filterStatoTo, filterRuolo);

                        //recupero i cambi stato /ruoli a cui devo inviare la mail
                        return appMeta.getData.runSelect("perfschedacambiostato", "*", filterAll)
                    })
                    .then(function (dtCambiostato) {
                        if (exit) {
                            return;
                        }
                        self.stateValue = self.state.currentRow.idperfschedastatus;

                        //Non ci sono ruoli a cui devo inviare mail esco
                        if (dtCambiostato.rows.length == 0 || !dtCambiostato.rows[0].idperfruolo_mail) {
                            self.hideWaitingIndicator(waitingHandler);
                            exit = true;
                            return def.resolve();
                        }
                        self.hideWaitingIndicator(waitingHandler);
                        waitingHandler = self.showWaitingIndicator('Invio mail');
                        invio = true;

                        _.forEach(dtCambiostato.rows, function (cambioStatoRow) {
                            if (cambioStatoRow.idperfruolo_mail == 'Valutatore') {
                                //destinatari.push([self.state.currentRow.idreg_val, 'Valutatore']);
                                _.forEach(strutturaRows, function (row) {
                                    if (row.idreg == self.state.currentRow.idreg_val) {
                                        destinatari.push(row);
                                        return false;
                                    }
                                });
                            } else {
                                if (cambioStatoRow.idperfruolo_mail == 'Approvatore') {
                                    _.forEach(strutturaRows, function (row) {
                                        if (row.idreg == self.state.currentRow.idreg_appr) {
                                            destinatari.push(row);
                                            return false;
                                        }
                                    });
                                } else {
                                    _.forEach(strutturaRows, function (row) {
                                        if (cambioStatoRow.idperfruolo_mail == row.idperfruolo) {
                                            destinatari.push(row);
                                            return false;
                                        }
                                    });
                                }
                            }
                        });

                        var arrayDest = [];
                        _.map(destinatari, function (row) { return arrayDest.push(row.idreg); });
                        //Recupero i dati della persona a cui inviare la mail
                        return self.superClass.getRegistryreference(arrayDest)
                    })

                    .then(function (dtRows) {
                        if (exit) {
                            return;
                        }
                        if (dtRows.length == 0) {
                            self.hideWaitingIndicator(waitingHandler);
                            return def.from(self.showMessageOk("Non ci sono destinatari a cui inviare la notifica"));
                        }

                        destinatariDbRow = dtRows;

                        var filterStato = self.q.eq("idperfschedastatus", self.state.currentRow.idperfschedastatus);

                        //recupero i cambi stato /ruoli a cui devo inviare la mail
                        return appMeta.getData.runSelect("perfschedastatus", "*", filterStato)
                    }).then(function (dtStato) {


                        var arrayDef = [];
                        var body;
                        if (!dtStato || dtStato.rows.length == 0) {
                            self.hideWaitingIndicator(waitingHandler);
                            return def.from(self.showMessageOk("Lo stato selezionato non è riconosciuto"));
                        }

                        _.forEach(destinatariDbRow, function (row) {
                            body = "Gentile " + row.email + ",</br>";
                            var subject = "Modifica stato scheda valutazione unità organizzativa " + titleStruttura;
                            body += "l'utente \"" + titleLoggato + "\" ha modificato lo stato della scheda in  \"" + dtStato.rows[0].title + "\".";
                            arrayDef.push(self.superClass.sendMail({ emailDest: row.email, body: body, subject: subject, viewMessage: false }));
                        });

                        return $.when.apply($, arrayDef);
                    })
                    .then(function () {
                        self.hideWaitingIndicator(waitingHandler);
                        if (exit == true) {
                            return def.resolve();
                        }
                        if (typeof (exit) === 'string' && exit.trim()) {
                            return def.from(self.showMessageOk(exit));
                        }
                        if (invio) {

                            return def.from(self.showMessageOk('Invio mail avvenuto con successo'));
                        }
                        return def.resolve();
                    });

                def.promise();
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
            getProfiliValutazione: function (varToNoAafterLinkPush) {
                var def = appMeta.Deferred("getProfValutazione");
                var self = this;
                var startdA = new Date();
                startdA.setMonth(11);
                startdA.setDate(31);

                startdA.setFullYear(new Date().getFullYear() - 1);

                var filterDa = self.q.lt('convert(varchar,start,101)', startdA);
                var filterDaNull = self.q.isNull('start');
                var filterOrDa = self.q.or(filterDa, filterDaNull);

                var startA = new Date();
                startA.setMonth(0);
                startA.setDate(1);
                startA.setFullYear(new Date().getFullYear() + 1);


                var filterA = self.q.gt('convert(varchar,stop,101)', startA);
                var filterANull = self.q.isNull('stop)');

				var filterOrA = self.q.or(filterA, filterANull);

                var filterSelected = self.q.eq('idstruttura', self.state.currentRow.idstruttura);

                var filterStrutturaParent = self.q.eq('idstruttura_parent', self.state.currentRow.idstruttura);
                var filterAndStruttura = self.q.and(filterSelected, filterStrutturaParent);


                var filterAll = self.q.and(filterOrDa, filterOrA, filterSelected, filterAndStruttura);



                return appMeta.getData.runSelect("strutturaparentresponsabiliview", "*", filterAll).then(function (dt) {

                    def.resolve();
                    return dt.rows;

                });

                return def.promise();
            },
rowSelected: function () {
				this.stateValue = this.state.currentRow.idperfschedastatus;
			},

			managepesoindicatori: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
				});
			},

			managepesoobiettivi: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
				});

			},

			managepesoprogaltreuo: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
				});
			},

			managepesoproguo: function(that) { 
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
				});
			},

			manageperfvalutazioneuo_default_idstruttura: function () {
var grid = this.getCustomControl('perfvalutazioneuoindicatori.default.default');
				if (this.state.currentRow.idstruttura > 0 && grid.gridRows.length == 0 && !this.state.isInsertState()) {
					this.calculateIndicatori(null);
				}
			},

			manageperfvalutazioneuo_default_completamentopsuo: function () {
               //Percentuale di completamento per i progetti Strategici della UO
              this.assignPercentuali("perfprogettoobiettivouoview", "completamentopsuo");            
			},

			manageperfvalutazioneuo_default_completamentopsauo: function () {
      //Percentuale di completamento dei progetti Strategici di altre UO 
       this.assignPercentuali("perfprogettoobiettivopersonaleview", "completamentopsauo");
			},

			manageperfvalutazioneuo_default_indicatori: function () {
         //Percentuale di completamento indicatori
          this.assignPercentuali("perfvalutazioneuoindicatori", "indicatori");
			},

			manageperfvalutazioneuo_default_obiettiviindividuali: function () {
        //Percentuale di completamento obiettivi una tantum
        this.assignPercentuali("perfobiettiviuo", "obiettiviindividuali");
			},

			children: ['perfobiettiviuo', 'perfprogettoobiettivopersonaleview', 'perfprogettoobiettivouoview', 'perfvalutazioneuoattach', 'perfvalutazioneuoindicatori'],
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

	window.appMeta.addMetaPage('perfvalutazioneuo', 'default', metaPage_perfvalutazioneuo);

}());
