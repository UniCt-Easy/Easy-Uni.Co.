(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazionepersonale() {
		MetaPage.apply(this, ['perfvalutazionepersonale', 'default', false]);
        this.name = 'Schede di valutazione del personale';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
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

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-perfvalutazionepersonale_default");
				var firstErrorObj;

				if (rowToCheck.table.postingTable() == 'perfvalutazionepersonale') {
					var self = this;
					var datasetRow = this.state.DS.tables.perfvalutazionepersonale.rows[0].getRow();
					if (datasetRow.old.idperfschedastatus)
						if (!self.allowedStateChanges || !_.some(self.allowedStateChanges, function (change) {
							//o c'è un cambio stato che corrisponde al cambiamento ...
							return (change.idperfschedastatus == datasetRow.old.idperfschedastatus && change.idperfschedastatus_to == self.state.currentRow.idperfschedastatus)
								//... oppure un cambio stato il cui stato di partenza è quello attuale e non c'è stato cambiamento di stato
								|| (change.idperfschedastatus == datasetRow.old.idperfschedastatus && datasetRow.old.idperfschedastatus == self.state.currentRow.idperfschedastatus);
						})) {
							firstErrorObj = { warningMsg: "", errMsg: "Non sei abilitato ad effettuare questo cambio di stato", errField: "idperfschedastatus", row: rowToCheck };
						}
					return def.resolve(firstErrorObj);
				}
				def.resolve();
				//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.calculateRisultatoPerc();
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-perfvalutazionepersonale_default");
				var arraydef = [];
				
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
				
				appMeta.metaModel.getTemporaryValues(this.getDataTable('perfvalutazionepersonalestatuschanges'));
				this.calculateRisultatoPerc();
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
				//parte sincrona
				this.enableControl($('#perfvalutazionepersonale_default_risultato'), true);
				this.enableControl($('#perfvalutazionepersonale_default_pesoateneo'), true);
				this.enableControl($('#perfvalutazionepersonale_default_percateneo'), true);
				this.enableControl($('#perfvalutazionepersonale_default_percperfuo'), true);
				this.enableControl($('#perfvalutazionepersonale_default_perccomportamenti'), true);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_compcomp'), true);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_valcomp'), true);
				this.enableControl($('#perfvalutazionepersonale_default_percobiettivi'), true);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_create'), true);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_comp'), true);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_val'), true);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_appr'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleateneo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonalecomportamento'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleobiettivo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfinterazioni_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleattach'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			afterLink: function () {
				var self = this;
				this.state.DS.tables.perfvalutazionepersonale.defaults({ 'year': new Date().getFullYear() });
				$("#XXperfinterazioni").prop("disabled", true);
				this.state.DS.tables.year.staticFilter(window.jsDataQuery.and(this.q.gt('year',2020),this.q.lt('year', (new Date().getFullYear()) +1 )));
				appMeta.metaModel.insertFilter(this.getDataTable("perfschedastatusdefaultview"), this.q.eq('perfschedastatus_active', 'Si'));
				appMeta.metaModel.cachedTable(this.getDataTable("getregistrydocentiamministrativinomcognview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getregistrydocentiamministrativinomcognview"));
				appMeta.metaModel.cachedTable(this.getDataTable("getdocentiamministrativiresponsabilinomcognview_alias4"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getdocentiamministrativiresponsabilinomcognview_alias4"));
				appMeta.metaModel.cachedTable(this.getDataTable("getdocentiamministrativiresponsabilinomcognview_alias5"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getdocentiamministrativiresponsabilinomcognview_alias5"));
				$('#perfvalutazionepersonale_default_pesocomportamenti').on("change", _.partial(this.managepesocomportamenti, self));
				$('#perfvalutazionepersonale_default_pesoobiettivi').on("change", _.partial(this.managepesoobiettivi, self));
				$('#perfvalutazionepersonale_default_pesoperfuo').on("change", _.partial(this.managepesoperfuo, self));
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
				$('#perfvalutazionepersonale_default_idreg').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#perfvalutazionepersonale_default_idreg').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#perfvalutazionepersonale_default_year').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#perfvalutazionepersonale_default_year').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idreg);
				$('#perfvalutazionepersonale_default_idafferenza').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idafferenza);
				$('#perfvalutazionepersonale_default_idafferenza').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idafferenza);
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "year" && r !== null) {
 					//se scelgo l'anno devo riempire la tendina con sole le persone che ha diritto l'utente di gestire
					var filterResponsabile = self.q.eq('idreg', parseInt(this.sec.usr('idreg')));
					var filterYear = self.q.eq('year', r.year);
					var filterAll = self.q.and(filterResponsabile, filterYear);

					return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "*", filterAll).then(function (dt) {

						filter = self.q.isIn("idreg", _.map(dt.rows,
							function (row) {
								if (row.afferenza_idreg) {
									return row.afferenza_idreg;
								}
								return true;
							})
						);

						appMeta.metaModel.cachedTable(self.getDataTable("getregistrydocentiamministrativinomcognview"), false);
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
				if (t.name === "getregistrydocentiamministrativinomcognview" && r !== null) {
					//se è già selezionata sul controllo la persona che sta sul dataset esco e non faccio niente
					if ((this.state.isInsertState() && (self.state.currentRow && self.state.currentRow.idreg > 0 && self.state.currentRow.idreg == $('#perfvalutazionepersonale_default_idreg').val())))
						return $.when.apply($, arraydef);

					//recupero tutti i responsabili/valutatori della persona selezionata, compreso l'utente loggato
					var filterValutato = self.q.eq('afferenza_idreg', r.idreg);
					var filterYear = self.q.eq('year', (self.state.currentRow ? self.state.currentRow.year : $('#perfvalutazionepersonale_default_year').val()));
					//var filterObiettivi = self.q.or(self.q.eq('obiettivi_individuali', 'S'), self.q.eq('obiettivi_comportamentali', 'S'))
					var filterAll = self.q.and(filterYear, filterValutato/*, filterObiettivi*/);

					    var dtVal;
						return self.calcDiritti(filterAll)
							.then(function (res){
								dtVal = res;
								return self.EnableControls();
							})
							.then(function () {

							//solo le afferenze relative all'anno (e quindi ai valutatori) di riferimento
							var filterListAfferenza = self.q.isIn("idafferenza", _.map(dtVal.rows,
								function (row) {
									if (row.idafferenza) {
										return row.idafferenza;
									}
									return true;
								})
							);

							appMeta.metaModel.cachedTable(self.getDataTable("afferenzaammview"), false);
							var perfvalutazionepersonale_default_idafferenzaCtrl = $('#perfvalutazionepersonale_default_idafferenza').data("customController");
							arraydef.push(perfvalutazionepersonale_default_idafferenzaCtrl.filteredPreFillCombo(filterListAfferenza, null, true)
								.then(function (dt) {
									if (self.state.currentRow && self.state.currentRow.idafferenza) {
										return perfvalutazionepersonale_default_idafferenzaCtrl.fillControl(null, self.state.currentRow.idafferenza);
									}
									return true;
								})
							);

							if (self.state.currentRow) {
								//Compilatore comportamenti
								self.loadRulesPerson(arraydef, dtVal, "aggiorna", "obiettivi_comportamentali", "idreg_compcomp", "getdocentiamministrativiresponsabilinomcognview", 'perfvalutazionepersonale_default_idreg_compcomp');
								//Valutatore comportamenti
								self.loadRulesPerson(arraydef, dtVal, "valuta", "obiettivi_comportamentali", "idreg_valcomp", "getdocentiamministrativiresponsabilinomcognview_alias1", 'perfvalutazionepersonale_default_idreg_valcomp');
								if (self.state.DS.tables.perfvalutazionepersonaleobiettivo.rows.length > 0) {
									//Inserisce obiettivi individuali
									self.loadRulesPerson(arraydef, dtVal, "crea", "obiettivi_individuali", "idreg_create", "getdocentiamministrativiresponsabilinomcognview_alias2", 'perfvalutazionepersonale_default_idreg_create');
									//Compilatore obiettivi individuali
									self.loadRulesPerson(arraydef, dtVal, "aggiorna", "obiettivi_individuali", "idreg_comp", "getdocentiamministrativiresponsabilinomcognview_alias3", 'perfvalutazionepersonale_default_idreg_comp');
									//Valutatore obiettivi individuali
									self.loadRulesPerson(arraydef, dtVal, "valuta", "obiettivi_individuali", "idreg_val", "getdocentiamministrativiresponsabilinomcognview_alias4", 'perfvalutazionepersonale_default_idreg_val');
								}
								//Approvatore
								self.loadRulesPerson(arraydef, dtVal, "approva", "obiettivi_individuali", "idreg_appr", "getdocentiamministrativiresponsabilinomcognview_alias5", 'perfvalutazionepersonale_default_idreg_appr');
							}

							return $.when.apply($, arraydef);

						});
				}
				if (t.name === "afferenzaammview" && r !== null) {
					var dtVal;
					return this.manageidafferenza(this)
						.then(function () {
							//recupero tutti i responsabili/valutatori della persona selezionata, compreso l'utente loggato
							var filterValutato = self.q.eq('idafferenza', r.idafferenza);
							var filterYear = self.q.eq('year', (self.state.currentRow ? self.state.currentRow.year : $('#perfvalutazionepersonale_default_year').val()));
							//var filterObiettivi = self.q.or(self.q.eq('obiettivi_individuali', 'S'), self.q.eq('obiettivi_comportamentali', 'S'))
							var filterAll = self.q.and(filterYear, filterValutato/*, filterObiettivi*/);
							return self.calcDiritti(filterAll)
						}).then(function (res) {
							dtVal = res;
							return self.EnableControls();
						})
						.then(function () {
							if (self.state.currentRow) {
								//Compilatore comportamenti
								self.loadRulesPerson(arraydef, dtVal, "aggiorna", "obiettivi_comportamentali", "idreg_compcomp", "getdocentiamministrativiresponsabilinomcognview", 'perfvalutazionepersonale_default_idreg_compcomp');
								//Valutatore comportamenti
								self.loadRulesPerson(arraydef, dtVal, "valuta", "obiettivi_comportamentali", "idreg_valcomp", "getdocentiamministrativiresponsabilinomcognview_alias1", 'perfvalutazionepersonale_default_idreg_valcomp');
								if (self.state.DS.tables.perfvalutazionepersonaleobiettivo.rows.length > 0) {
									//Inserisce obiettivi individuali
									self.loadRulesPerson(arraydef, dtVal, "crea", "obiettivi_individuali", "idreg_create", "getdocentiamministrativiresponsabilinomcognview_alias2", 'perfvalutazionepersonale_default_idreg_create');
									//Compilatore obiettivi individuali
									self.loadRulesPerson(arraydef, dtVal, "aggiorna", "obiettivi_individuali", "idreg_comp", "getdocentiamministrativiresponsabilinomcognview_alias3", 'perfvalutazionepersonale_default_idreg_comp');
									//Valutatore obiettivi individuali
									self.loadRulesPerson(arraydef, dtVal, "valuta", "obiettivi_individuali", "idreg_val", "getdocentiamministrativiresponsabilinomcognview_alias4", 'perfvalutazionepersonale_default_idreg_val');
								}
								//Approvatore
								self.loadRulesPerson(arraydef, dtVal, "approva", "obiettivi_individuali", "idreg_appr", "getdocentiamministrativiresponsabilinomcognview_alias5", 'perfvalutazionepersonale_default_idreg_appr');
							}
							return $.when.apply($, arraydef);
						})

				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			
			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXperfinterazioni").length) {
					$("#XXperfinterazioni").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			
			//beforePost

			afterFill: function () {
				this.comportamentiGiaCalcolati = false;
				this.enableControl($("#XXperfinterazioni"), this.state.isEditState());
				this.enableControl($('#perfvalutazionepersonale_default_risultato'), false);
				this.enableControl($('#perfvalutazionepersonale_default_pesoateneo'), false);
				this.enableControl($('#perfvalutazionepersonale_default_percateneo'), false);
				this.enableControl($('#perfvalutazionepersonale_default_percperfuo'), false);
				this.enableControl($('#perfvalutazionepersonale_default_perccomportamenti'), false);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_compcomp'), false);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_valcomp'), false);
				this.enableControl($('#perfvalutazionepersonale_default_percobiettivi'), false);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_create'), false);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_comp'), false);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_val'), false);
				this.enableControl($('#perfvalutazionepersonale_default_idreg_appr'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleateneo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleuo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonalecomportamento'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonalecomportamento'), this.getDataTable('perfvalutazionepersonalecomportamentosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleobiettivo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfinterazioni_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazionepersonale'), this.getDataTable('perfvalutazionepersonaleattach'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			insertClick: function (that, grid) {
				var msg = this.CheckRights(that, grid, 'i');
				if (msg) return this.showMessageOk(msg);
				if (!$('#perfvalutazionepersonale_default_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Valutato');
				}
				if (!$('#perfvalutazionepersonale_default_idafferenza').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Afferenza');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			editClick: function (that, grid) {
				var msg = this.CheckRights(that, grid, 'u');
				if (msg) return this.showMessageOk(msg);
				return this.superClass.editClick(that, grid);
			},

			deleteClick: function (that, grid) {
				var msg = this.CheckRights(that, grid, 'd');
				if (msg) return this.showMessageOk(msg);
				return this.superClass.deleteClick(that, grid);
			},

			editInPlace: function (that, grid, colname, row) {
				if (grid.dataSourceName === "perfvalutazionepersonaleobiettivo") {
					if (colname == 'valorenumerico' && row.valorenumerico !== undefined && row.valorenumerico !== null) {
						var rowsSoglie = that.state.DS.tables["perfvalutazionepersonalesoglia"].select(that.q.eq('idperfvalutazionepersonaleobiettivo', row.idperfvalutazionepersonaleobiettivo));
						var arrSoglieObiettivi = _.map(rowsSoglie, function (r) { return { indicatore: r.valorenumerico, soglia: r.percentuale } })
						row.completamento = that.calculateCompletamentoByValoreNumerico(arrSoglieObiettivi, row.valorenumerico);
						return grid.fillControl();
					}
					if (colname == 'completamento' && row.completamento !== undefined && row.completamento !== null) {
						row.valorenumerico = null;
						return grid.fillControl();
					}
				}
				if (grid.dataSourceName === "perfvalutazionepersonalecomportamento") {
					if (colname == 'valorenumerico' && row.valorenumerico !== undefined && row.valorenumerico !== null) {
						var rowsSoglie = that.state.DS.tables["perfvalutazionepersonalesoglia"].select(that.q.eq('idperfvalutazionepersonalecomportamento', row.idperfvalutazionepersonalecomportamento));
						var arrSoglieObiettivi = _.map(rowsSoglie, function (r) { return { indicatore: r.valorenumerico, soglia: r.percentuale } })
						row.completamento = that.calculateCompletamentoByValoreNumerico(arrSoglieObiettivi, row.valorenumerico);
						return grid.fillControl();
					}
					if (colname == 'completamento' && row.completamento !== undefined && row.completamento !== null) {
						row.valorenumerico = null;
						return grid.fillControl();
					}
				}
			},

			CheckRights: function (that, grid, op) {
				//obiettivi comportamentali
				if (grid.dataSourceName == "perfvalutazionepersonalecomportamento") {
					if (this.crea !== true && (op === 'd' || op == 'i')) {
						return 'Non sei abilitato a creare o cancellare comportamenti'; //comportamenti
					}
				}
				//obiettivi individuali
				if (grid.dataSourceName == "perfvalutazionepersonaleobiettivo") {
					if (this.crea !== true && (op === 'd' || op == 'i')) {
						return 'Non sei abilitato a creare o cancellare obiettivi individuali'; //individuali
					}
				}
			},

			EnableControls: function (param) {
				if (this.crea !== true) {
					this.enableControl('#perfvalutazionepersonale_default_pesoperfuo', false)
					this.enableControl('#perfvalutazionepersonale_default_pesocomportamenti', false)
					this.enableControl('#perfvalutazionepersonale_default_pesoobiettivi', false)
				} else {
					this.enableControl('#perfvalutazionepersonale_default_pesoperfuo', true)

					if (this.valuta_co !== true)
						this.enableControl('#perfvalutazionepersonale_default_pesocomportamenti', false)
					else
						this.enableControl('#perfvalutazionepersonale_default_pesocomportamenti', true)

					if (this.valuta_ind !== true)
						this.enableControl('#perfvalutazionepersonale_default_pesoobiettivi', false)
					else
						this.enableControl('#perfvalutazionepersonale_default_pesoobiettivi', true)

				}

				//motivazioni
				if (this.valuta_ind !== true && this.valuta_co !== true)
					this.enableControl('#perfvalutazionepersonale_default_motivazione', false)
				else
					this.enableControl('#perfvalutazionepersonale_default_motivazione', true)

				if (this.canSaveOriginal === undefined) {
					this.canSaveOriginal = this.canSave;
					this.canInsertOriginal = this.canInsert;
					this.canInsertCopyOriginal = this.canInsertCopy;
					this.canCancelOriginal = this.canCancel;
				}

				if (this.crea !== true && this.valuta_co !== true && this.valuta_ind !== true && this.aggiorna_co !== true && this.aggiorna_ind !== true) {
					this.canSave = false;
					this.canInsert = false;
					this.canInsertCopy = false;
					this.canCancel = false;
				} else {
					this.canSave = this.canSaveOriginal;
					if (this.crea !== true) {
						this.canInsert = false;
						this.canInsertCopy = false;
						this.canCancel = false;
					} else {
						this.canInsert = this.canInsertOriginal;
						this.canInsertCopy = this.canInsertCopyOriginal;
						this.canCancel = this.canCancelOriginal;
					}
				}

				//se non ci può lavorare disabilito i comportamenti TODO DEVE POTER VEDERE GLI ALLEGATI
				var goi = $('#grid_perfvalutazionepersonaleobiettivo_default').data("customController")
				if (goi) {
					if (this.valuta_ind !== true && this.aggiorna_ind !== true) {
						$(goi.el).css("pointer-events", "none")
					} else {
						$(goi.el).css("pointer-events", "unset")
					}
				}

				//se non ci può lavorare disabilito i comportamenti
				var gc = $('#grid_perfvalutazionepersonalecomportamento_default').data("customController")
				if (gc) {
					if (this.valuta_co !== true && this.aggiorna_co !== true) {
						$(gc.el).css("pointer-events", "none")
					} else {
						$(gc.el).css("pointer-events", "unset")
					}
				}

				//se ha un cambio stato impostato lo faccio salvare
				if (this.roles && this.roles.length > 0 && this.state.currentRow && this.state.currentRow.idperfschedastatus) {
					var self = this;
					var filter = this.q.isIn('idperfruolo', this.roles);
					return appMeta.getData.runSelect("perfschedacambiostatoruolimailview", "*", filter)
						.then(function (dtRes) {
							if (dtRes.rows.length) {
								self.allowedStateChanges = dtRes.rows;
								self.canSave = self.canSaveOriginal;
								self.canInsert = self.canInsertOriginal;
								self.canInsertCopy = self.canInsertCopylseOriginal;
								self.canCancel = self.canCancelOriginal;
							}
							return true;
						})
						.then(function () {
							return self.freshToolBar();
						});
				}
				else
					return this.freshToolBar();
			},

			calculateRisultatoPerc: function () {
				if (this.state.currentRow) {
					var pa = this.getDataTable("perfvalutazionepersonaleateneo");
					if (pa.rows.length > 0)
						if (this.state.DS.tables.perfvalutazionepersonaleateneo.rows[0].peso > 0) {
							this.state.currentRow.pesoateneo = this.state.DS.tables.perfvalutazionepersonaleateneo.rows[0].peso;
							this.state.currentRow.percateneo = this.state.DS.tables.perfvalutazionepersonaleateneo.rows[0].punteggio;
						}

					var arrayRisultato = [
						{ valore: this.state.currentRow.percateneo, peso: this.state.currentRow.pesoateneo },
						{ valore: this.state.currentRow.percperfuo, peso: this.state.currentRow.pesoperfuo },
						{ valore: this.state.currentRow.perccomportamenti, peso: this.state.currentRow.pesocomportamenti },
						{ valore: this.state.currentRow.percobiettivi, peso: this.state.currentRow.pesoobiettivi },
					];

					var average = this.calculateWeightedAverage(arrayRisultato);
					if (this.state.currentRow.risultato != average)
						this.state.currentRow.risultato = average;
				}
			},

			getComportamenti: function (prm) {
				return this.getComportamentiAndAteneo('default', 'default');
			},

			rowSelected: function () {
				this.stateValue = this.state.currentRow.idperfschedastatus;
			},

			afterPost: function () {
				return this.sendMailChangeStatusValutazionePersonale(true, "della scheda di valutazione del personale", 'default');
			},

			stateValue: null,

			manageidafferenza: function(that) { 
				var def = appMeta.Deferred("manageidafferenza");
				var waitingHandler = that.showWaitingIndicator('attendi select');
				if ($('#perfvalutazionepersonale_default_idafferenza').val()) {
					if (that.state.isInsertState() || that.state.isEditState()) {
						var tName = "perfvalutazionepersonaleateneo";
						var t = that.getDataTable(tName)

						//se non c'è ...
						appMeta.utils._if(that.state.DS.tables[tName].rows.length == 0)
							._then(function () {
								//...recupero i dati della scheda di ateneo...
								var filterYear = that.q.eq('year', $('#perfvalutazionepersonale_default_year').val());
								return appMeta.getData.runSelect("perfvalutazioneateneo", "*", filterYear).then(function (dt) {
									if (dt.rows.length > 0) {
										//...creo la riga
										var meta = appMeta.getMeta(tName);
										meta.setDefaults(t);
										return meta.getNewRow(that.state.currentRow.getRow(), t).then(function (row) {
											row.current.peso = 0;
											row.current.punteggio = dt.rows[0].performance;
											row.current.punteggiopesato = 0;
											return true;
										});
									}
									return true;
								});
							})
							.then(function () {
								that.getComportamenti(null)
									.then(function () {
										tName = 'perfvalutazionepersonaleuo';
										t = that.getDataTable(tName)
										if (that.state.DS.tables[tName].rows.length == 0) {
											//...recupero i dati della scheda della uo...
											var filterYear = that.q.eq('year', $('#perfvalutazionepersonale_default_year').val());

											var idafferenza = parseInt($('#perfvalutazionepersonale_default_idafferenza').val());
											var selectedAfferenza = that.state.DS.tables.afferenzaammview.select(that.q.eq('idafferenza', idafferenza));
											if (selectedAfferenza.length) {
												var filterStrutt = that.q.eq('idstruttura', selectedAfferenza[0].idstruttura);
												var filterAll = that.q.and([filterYear, filterStrutt])
												return appMeta.getData.runSelect("perfvalutazioneuo", "*", filterAll).then(function (dt) {
													if (dt.rows.length > 0) {
														if (that.state.DS.tables[tName].rows.length == 0) {
															//...creo la riga
															var meta = appMeta.getMeta(tName);
															meta.setDefaults(t);
															return meta.getNewRow(that.state.currentRow.getRow(), t)
															.then(function (row) {
																row.current.afferenza = 100;
																row.current.punteggio = dt.rows[0].performance;
																row.current.peso = 0;
																row.current.punteggiopesato = 0;
																row.current.idstruttura = selectedAfferenza[0].idstruttura;
																return true;
															})
															.then(function () {
																//invoco il refill del dataset a partire però dalla riga principale per popolare 
																//le tabelle vocabolario struttura e strutturakind collegate in cascata
																return appMeta.getData.doGet(that.state.DS, that.state.currentRow.getRow(), 'perfvalutazionepersonale', true)
																.then(function () {
																	var grid = $('#grid_perfvalutazionepersonaleuo_default').data("customController");
																	appMeta.metaModel.getTemporaryValues(that.getDataTable(tName));
																	return grid.fillControl()
																	.then(function () {
																		that.hideWaitingIndicator(waitingHandler);
																		return def.resolve();
																				
																	})
																});
															});
														}
														else {
															//aggiorno la riga
															that.state.DS.tables[tName].rows[0].punteggio = dt.rows[0].performance;
														}
													}
													that.hideWaitingIndicator(waitingHandler);
													return def.resolve();
													});
												}
											}
											that.hideWaitingIndicator(waitingHandler);
											return def.resolve();
										});
							});

						return def.promise();
					}
				}

				that.hideWaitingIndicator(waitingHandler);
				return  def.resolve();
			},

			manageperfvalutazionepersonale_default_percperfuo: function () {
				//Percentuale di completamento dell’unità organizzativa
				this.assignPercentuali("perfvalutazionepersonaleuo", "percperfuo", "punteggio", "afferenza");
			},

			manageperfvalutazionepersonale_default_perccomportamenti: function () {
				//Percentuale di completamento dei comportamenti attesi
				 this.assignPercentuali("perfvalutazionepersonalecomportamento", "perccomportamenti");


			},

			manageperfvalutazionepersonale_default_percobiettivi: function () {
				//Percentuale di completamento degli obiettivi individuali
				this.assignPercentuali("perfvalutazionepersonaleobiettivo", "percobiettivi");
			},

			children: ['perfinterazioni_alias1', 'perfvalutazionepersonaleateneo', 'perfvalutazionepersonaleattach', 'perfvalutazionepersonalecomportamento', 'perfvalutazionepersonaleobiettivo', 'perfvalutazionepersonalestatuschanges', 'perfvalutazionepersonaleuo'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			managepesocomportamenti: function(that) { 
				var def = appMeta.Deferred('managepesocomportamenti');

            	if (that.state.isSearchState()) {
					return def.resolve();
				}

				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazionepersonale.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazionepersonale_default_risultato').val(value);
					def.resolve();
				});

				return def.promise();
			},

			managepesoobiettivi: function(that) { 
				var def = appMeta.Deferred('managepesoobiettivi');

				if (that.state.isSearchState()) {
					return def.resolve();
				}

				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazionepersonale.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazionepersonale_default_risultato').val(value);
					def.resolve();
				});
				return def.promise();
			},

			managepesoperfuo: function(that) { 
				var def = appMeta.Deferred('managepesoperfuo');
				if (that.state.isSearchState()) {
					return def.resolve();
				}
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazionepersonale.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazionepersonale_default_risultato').val(value);
					def.resolve();
				});
				return def.promise();
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazionepersonale', 'default', metaPage_perfvalutazionepersonale);

}());
