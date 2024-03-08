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

				this.manageperfvalutazioneuo_default_idstruttura();
				this.manageperfvalutazioneuo_default_completamentopsuo();
				this.manageperfvalutazioneuo_default_completamentopsauo();
				this.manageperfvalutazioneuo_default_indicatori();
				this.manageperfvalutazioneuo_default_obiettiviindividuali();
				//beforeFillFilter

				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneuo_default");
				var arraydef = [];

				if (!this.state.isSearchState()) {
					var filteractive = this.q.eq('struttura_active', 'Si');
					var filter = self.state.currentRow.idstruttura ? this.q.or(filteractive, this.q.eq('idstruttura', self.state.currentRow.idstruttura)) : filteractive;
					appMeta.metaModel.cachedTable(this.getDataTable("strutturaperfelenchiview"), false);
					var perfvalutazioneuo_default_idstrutturaCtrl = $('#perfvalutazioneuo_default_idstruttura').data("customController");
					arraydef.push(perfvalutazioneuo_default_idstrutturaCtrl.filteredPreFillCombo(filter, null, true));
				}
				if (!this.state.isSearchState()) {
					var filteractive = this.q.eq('perfschedastatus_active', 'Si');
					var filter = self.state.currentRow.idperfschedastatus ? this.q.or(filteractive, this.q.eq('idperfschedastatus', self.state.currentRow.idperfschedastatus)) : filteractive;
					appMeta.metaModel.cachedTable(this.getDataTable("perfschedastatusdefaultview"), false);
					var perfvalutazioneuo_default_idperfschedastatusCtrl = $('#perfvalutazioneuo_default_idperfschedastatus').data("customController");
					arraydef.push(perfvalutazioneuo_default_idperfschedastatusCtrl.filteredPreFillCombo(filter, null, true));
				}
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
				this.enableControl($('#perfvalutazioneuo_default_risultato'), true);
				this.enableControl($('#perfvalutazioneuo_default_completamentopsuo'), true);
				this.enableControl($('#perfvalutazioneuo_default_completamentopsauo'), true);
				this.enableControl($('#perfvalutazioneuo_default_indicatori'), true);
				this.enableControl($('#perfvalutazioneuo_default_idreg_compobborg'), true);
				this.enableControl($('#perfvalutazioneuo_default_idreg_valobborg'), true);
				this.enableControl($('#perfvalutazioneuo_default_obiettiviindividuali'), true);
				this.enableControl($('#perfvalutazioneuo_default_idreg_create'), true);
				this.enableControl($('#perfvalutazioneuo_default_idreg_comp'), true);
				this.enableControl($('#perfvalutazioneuo_default_idreg_val'), true);
				this.enableControl($('#perfvalutazioneuo_default_idreg_appr'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfprogettoobiettivouoview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettosoglia_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoindicatori'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuoindicatori'), this.getDataTable('perfvalutazioneuoindicatorisoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoattach'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfobiettiviuo'));
				//afterClearin

				//parte asincrona
				var def = appMeta.Deferred("afterClear-perfvalutazioneuo_default");
				var arraydef = [];

				if (this.state.isSearchState()) {
					appMeta.metaModel.cachedTable(this.getDataTable("strutturaperfelenchiview"), false);
					var perfvalutazioneuo_default_idstrutturaCtrl = $('#perfvalutazioneuo_default_idstruttura').data("customController");
					arraydef.push(perfvalutazioneuo_default_idstrutturaCtrl.filteredPreFillCombo(null, null, true));
				}
				if (this.state.isSearchState()) {
					appMeta.metaModel.cachedTable(this.getDataTable("perfschedastatusdefaultview"), false);
					var perfvalutazioneuo_default_idperfschedastatusCtrl = $('#perfvalutazioneuo_default_idperfschedastatus').data("customController");
					arraydef.push(perfvalutazioneuo_default_idperfschedastatusCtrl.filteredPreFillCombo(null, null, true));
				}
				//afterClearInAsync
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},

			afterFill: function () {
				this.enableControl($('#perfvalutazioneuo_default_risultato'), false);
				this.enableControl($('#perfvalutazioneuo_default_completamentopsuo'), false);
				this.enableControl($('#perfvalutazioneuo_default_completamentopsauo'), false);
				this.enableControl($('#perfvalutazioneuo_default_indicatori'), false);
				this.enableControl($('#perfvalutazioneuo_default_idreg_compobborg'), false);
				this.enableControl($('#perfvalutazioneuo_default_idreg_valobborg'), false);
				this.enableControl($('#perfvalutazioneuo_default_obiettiviindividuali'), false);
				this.enableControl($('#perfvalutazioneuo_default_idreg_create'), false);
				this.enableControl($('#perfvalutazioneuo_default_idreg_comp'), false);
				this.enableControl($('#perfvalutazioneuo_default_idreg_val'), false);
				this.enableControl($('#perfvalutazioneuo_default_idreg_appr'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfprogettoobiettivouoview'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettoobiettivosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivouoview'), this.getDataTable('perfprogettosoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettosoglia_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoindicatori'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuoindicatori'), this.getDataTable('perfvalutazioneuoindicatorisoglia'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfvalutazioneuoattach'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfvalutazioneuo'), this.getDataTable('perfobiettiviuo'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.EnableControl();
				this.state.DS.tables.perfvalutazioneuo.defaults({ 'year': new Date().getFullYear() });
				this.state.DS.tables.year.staticFilter(window.jsDataQuery.and(this.q.gt('year', 2020), this.q.lt('year', (new Date().getFullYear()) + 1)));
				appMeta.metaModel.cachedTable(this.getDataTable("strutturaperfelenchiview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("strutturaperfelenchiview"));
				appMeta.metaModel.cachedTable(this.getDataTable("getdocentiamministrativiresponsabilinomcognview_alias4"), true);
				appMeta.metaModel.lockRead(this.getDataTable("getdocentiamministrativiresponsabilinomcognview_alias4"));
				$('#perfvalutazioneuo_default_pesoindicatori').on("change", _.partial(this.managepesoindicatori, self));
				$('#perfvalutazioneuo_default_pesoobiettivi').on("change", _.partial(this.managepesoobiettivi, self));
				$('#perfvalutazioneuo_default_pesoprogaltreuo').on("change", _.partial(this.managepesoprogaltreuo, self));
				$('#perfvalutazioneuo_default_pesoproguo').on("change", _.partial(this.managepesoproguo, self));
				var grid_perfprogettoobiettivouoview_defaultChildsTables = [
					{ tablename: 'perfprogettoobiettivosoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfprogettoobiettivosoglia' },
					{ tablename: 'perfprogettosoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfprogettosoglia' },
				];
				$('#grid_perfprogettoobiettivouoview_default').data('childtables', grid_perfprogettoobiettivouoview_defaultChildsTables);
				$('#grid_perfprogettoobiettivouoview_default').data('childtablesadd', false);
				$('#grid_perfprogettoobiettivouoview_default').data('childtablesedit', false);
				$('#grid_perfprogettoobiettivouoview_default').data('childtablesdelete', false);
				var grid_perfprogettoobiettivopersonaleview_defaultChildsTables = [
					{ tablename: 'perfprogettoobiettivosoglia_alias1', edittype: 'default', columnlookup: 'description', columncalc: '!perfprogettoobiettivosoglia_alias1' },
					{ tablename: 'perfprogettosoglia_alias1', edittype: 'default', columnlookup: 'description', columncalc: '!perfprogettosoglia_alias1' },
				];
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtables', grid_perfprogettoobiettivopersonaleview_defaultChildsTables);
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtablesadd', false);
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtablesedit', false);
				$('#grid_perfprogettoobiettivopersonaleview_default').data('childtablesdelete', false);
				var grid_perfvalutazioneuoindicatori_defaultChildsTables = [
					{ tablename: 'perfvalutazioneuoindicatorisoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfvalutazioneuoindicatorisoglia' },
				];
				$('#grid_perfvalutazioneuoindicatori_default').data('childtables', grid_perfvalutazioneuoindicatori_defaultChildsTables);
				$('#grid_perfvalutazioneuoindicatori_default').data('childtablesadd', false);
				$('#grid_perfvalutazioneuoindicatori_default').data('childtablesedit', false);
				$('#grid_perfvalutazioneuoindicatori_default').data('childtablesdelete', false);
				var grid_perfobiettiviuo_defaultChildsTables = [
					{ tablename: 'perfobiettiviuosoglia', edittype: 'default', columnlookup: 'description', columncalc: '!perfobiettiviuosoglia' },
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
				$('#perfvalutazioneuo_default_year').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.year);
				$('#perfvalutazioneuo_default_year').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.year);
				$('#perfvalutazioneuo_default_idstruttura').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idstruttura);
				$('#perfvalutazioneuo_default_idstruttura').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idstruttura);
				$('#perfvalutazioneuo_default_year').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idstruttura);
				$('#perfvalutazioneuo_default_year').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idstruttura);
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "year" && r !== null) {
					//in base all'anno selezionato e ai diritti dell'utente popolo la tendina delle strutture 
					var filterResponsabile = self.q.eq('idreg', parseInt(this.sec.usr('idreg')));
					var filterYear = self.q.eq('year', r.year);
					var filterAll = self.q.and(filterResponsabile, filterYear);

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
									return perfvalutazioneuo_default_idstruttura.fillControl(null, self.state.currentRow.idstruttura);
								return true;
							})
						);
						return $.when.apply($, arraydef);

					});

				}
				if (t.name === "strutturaperfelenchiview" && r !== null) {
					//se sono in ricerca oppure è già selezionata sul controllo la struttura che sta sul dataset esco e non faccio niente
					if ((this.state.isInsertState() && (self.state.currentRow && self.state.currentRow.idstruttura && self.state.currentRow.idstruttura == $('#perfvalutazioneuo_default_idstruttura').val()))
						|| this.state.isSearchState()
					)
						return $.when.apply($, arraydef);

					var filterStruttura = self.q.eq('idstruttura', r.idstruttura);
					var filterYear = self.q.eq('year', (self.state.currentRow ? self.state.currentRow.year : $('#perfvalutazioneuo_default_year').val()));
					var filterObiettivi = self.q.or(self.q.eq('obiettivi_organizzativi', 'S'), self.q.eq('obiettivi_unatantum', 'S'))
					var filterAll = self.q.and(filterYear, filterStruttura, filterObiettivi);

					var dtVal;
					return self.calcDirittiUO(filterAll)
						.then(function (res) {
							dtVal = res;
							return self.EnableControl();
						})
						.then(function () {

							//Compilatore indicatori
							self.loadRulesPerson(arraydef, dtVal, "aggiorna", "obiettivi_organizzativi", "idreg_compobborg", "getdocentiamministrativiresponsabilinomcognview", 'perfvalutazioneuo_default_idreg_compobborg');
							//Valutatore indicatori
							self.loadRulesPerson(arraydef, dtVal, "valuta", "obiettivi_organizzativi", "idreg_valobborg", "getdocentiamministrativiresponsabilinomcognview_alias1", 'perfvalutazioneuo_default_idreg_valobborg');
							//Inserisce obiettivi una tantum
							self.loadRulesPerson(arraydef, dtVal, "crea", "obiettivi_unatantum", "idreg_create", "getdocentiamministrativiresponsabilinomcognview_alias2", 'perfvalutazioneuo_default_idreg_create');
							//Compilatore obiettivi una tantum
							self.loadRulesPerson(arraydef, dtVal, "aggiorna", "obiettivi_unatantum", "idreg_comp", "getdocentiamministrativiresponsabilinomcognview_alias3", 'perfvalutazioneuo_default_idreg_comp');
							//Valutatore obiettivi una tantum
							self.loadRulesPerson(arraydef, dtVal, "valuta", "obiettivi_unatantum", "idreg_val", "getdocentiamministrativiresponsabilinomcognview_alias4", 'perfvalutazioneuo_default_idreg_val');
							//Approvatore
							self.loadRulesPerson(arraydef, dtVal, "approva", "obiettivi_unatantum", "idreg_appr", "getdocentiamministrativiresponsabilinomcognview_alias5", 'perfvalutazioneuo_default_idreg_appr');

							return true;
						}).then(function () {
							if (self.state.isInsertState()) {
								return self.calculateIndicatori(null).then(function () {
									if (self.state.currentRow && self.getDataTable("perfvalutazioneuoindicatori").rows) {

										$('#perfvalutazioneuo_default_idstruttura').prop("disabled", true);
										$('#perfvalutazioneuo_default_idstruttura').prop("readonly", true);
										$('#perfvalutazioneuo_default_year').prop("disabled", true);
										$('#perfvalutazioneuo_default_year').prop("readonly", true);
									}
									return $.when.apply($, arraydef);
								});
							}
							return $.when.apply($, arraydef);
						});

				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation


			//buttonClickEnd


			beforePost: function () {
				var self = this;
				this.getDataTable('perfprogettoobiettivouoview').acceptChanges();
				this.getDataTable('perfprogettoobiettivopersonaleview').acceptChanges();
				//innerBeforePost
			},

			insertClick: function (that, grid) {
				var msg = this.CheckRights(that, grid, 'i');
				if (msg) return this.showMessageOk(msg);
				if (!$('#perfvalutazioneuo_default_year').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno solare');
				}
				if (!$('#perfvalutazioneuo_default_idstruttura').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Unità organizzativa');
				}
				if (!$('#perfvalutazioneuo_default_year').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno solare');
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

			CheckRights: function (that, grid, op) {
				var usr = parseInt(this.sec.usr('idreg'));
				//obiettivi organizzativi
				if (grid.dataSourceName == "perfvalutazioneuoindicatori") {
					if (this.state.currentRow.idreg_create !== usr && this.state.currentRow.idreg_compobborg !== usr && this.state.currentRow.idreg_valobborg !== usr
						&& this.crea !== true && this.aggiorna_org !== true && this.valuta_org !== true) {
						return 'Non sei abilitato a operare su gli indicatori'; //indicatori
					}
					else {
						if (this.state.currentRow.idreg_create !== usr && this.crea !== true && (op === 'd' || op == 'i')) {
							return 'Non sei abilitato a creare o cancellare indicatori'; //indicatori
						}
					}
				}
				if (grid.dataSourceName == "perfobiettiviuo") {
					if (this.state.currentRow.idreg_create !== usr && this.state.currentRow.idreg_comp !== usr && this.state.currentRow.idreg_val !== usr
						&& this.crea !== true && this.aggiorna_ut !== true && this.valuta_ut !== true) {
						return 'Non sei abilitato a operare su gli obiettivi una tantum'; //una tantum
					}
					else {
						if (this.state.currentRow.idreg_create !== usr && this.crea !== true && (op === 'd' || op == 'i')) {
							return 'Non sei abilitato a creare o cancellare obiettivi una tantum'; //una tantum
						}
					}
				}
			},

			EnableControl: function () {
				//pesi
				//se non crea e non valuta ...
				if (this.crea !== true && this.valuta_org !== true && this.valuta_ut !== true) {
					this.enableControl('#perfvalutazioneuo_default_pesoproguo', false)
					this.enableControl('#perfvalutazioneuo_default_pesoprogaltreuo', false)
					this.enableControl('#perfvalutazioneuo_default_pesoindicatori', false)
					this.enableControl('#perfvalutazioneuo_default_pesoobiettivi', false)
				} else {
					//..altrimenti ...
					if (this.crea == true) {
						this.enableControl('#perfvalutazioneuo_default_pesoproguo', true)
						this.enableControl('#perfvalutazioneuo_default_pesoprogaltreuo', true)
					}

					if (this.crea == true || this.valuta_org === true)
						this.enableControl('#perfvalutazioneuo_default_pesoindicatori', true)
					else
						this.enableControl('#perfvalutazioneuo_default_pesoindicatori', false)
					if (this.crea == true || this.valuta_ut === true)
						this.enableControl('#perfvalutazioneuo_default_pesoobiettivi', true)
					else
						this.enableControl('#perfvalutazioneuo_default_pesoobiettivi', false)

				}

				//pulsanti
				if (this.canSaveOriginal === undefined) {
					this.canSaveOriginal = this.canSave;
					this.canInsertOriginal = this.canInsert;
					this.canInsertCopyOriginal = this.canInsertCopy;
					this.canCancelOriginal = this.canCancel;
				}

				if (this.crea !== true && this.valuta_org !== true && this.valuta_ut !== true && this.aggiorna_org !== true && this.aggiorna_ut !== true) {
					this.canSave = false;
					this.canInsert = false;
					this.canInsertCopy = false;
					this.canCancel = false;
				} else {
					this.canSave = this.canSaveOriginal;
					this.canInsert = this.canInsertOriginal;
					this.canInsertCopy = this.canInsertCopyOriginal;
					this.canCancel = this.canCancelOriginal;
				}

				//griglie
				var goi = $('#grid_perfvalutazioneuoindicatori_default').data("customController")
				if (goi) {
					//indicatori
					if (this.aggiorna_org !== true && this.valuta_org !== true) {
						$(goi.el).css("pointer-events", "none")
					} else {
						$(goi.el).css("pointer-events", "unset")
					}
					//una tantum
					var gc = $('#grid_perfobiettiviuo_default').data("customController")
					if (this.crea !== true && this.aggiorna_ut !== true && this.valuta_ut !== true) {
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

			alreadySelected: false,

			stateValue: null,

			calculateIndicatori: function (prm) {
				var def = appMeta.Deferred("calculateIndicatori");
				if (!this.state.currentRow || !(this.state.isInsertState() && (this.getDataTable("perfvalutazioneuoindicatori").rows == 0))) {
					return def.resolve();
				}
				var grid = this.getCustomControl('perfvalutazioneuoindicatori.default.default');


				if (grid.gridRows.length > 0)
					return def.resolve();

				var waitingHandler = this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

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
						if (gridControl && gridControl.dataTable.rows != null && gridControl.dataTable.rows.length > 0) {
							return gridControl.fillControl();
						}

					}).then(function () {

						self.hideWaitingIndicator(waitingHandler);
						def.resolve();

					});
				return def.promise();
			},

			costruisciPerfvalutazioneuoindicatori: function (indicatoreRow) {
				var def = appMeta.Deferred("costruisciIndicatore");
				var meta = appMeta.getMeta("perfvalutazioneuoindicatori");
				var self = this;

				meta.getNewRow(this.state.currentRow.getRow(), this.getDataTable("perfvalutazioneuoindicatori")).then(function (row) {
					row.current.idperfindicatore = indicatoreRow.idperfindicatore;
					row.current.idperfvalutazioneuo = self.state.currentRow.idperfvalutazioneuo;
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
				return this.sendMailChangeStatusValutazioneUO(false, ['perfprogettoobiettivouoview', 'perfprogettoobiettivopersonaleview'], "della scheda di valutazione dell'unità organizzativa ");
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

			managepesoindicatori: function (that) {
				var def = appMeta.Deferred('managepesoindicatori');

				if (that.state.isSearchState()) {
					return def.resolve();
				}
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
					def.resolve();
				});
				return def.promise();
			},

			managepesoobiettivi: function (that) {
				var def = appMeta.Deferred('managepesoobiettivi');

				if (that.state.isSearchState()) {
					return def.resolve();
				}
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
					def.resolve();
				});
				return def.promise();

			},

			managepesoprogaltreuo: function (that) {
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
				});
			},

			managepesoproguo: function (that) {
				var def = appMeta.Deferred('managepesoproguo');

				if (that.state.isSearchState()) {
					return def.resolve();
				}
				that.getFormData(true).then(function () {
					that.calculateRisultatoPerc();
					var result = that.state.currentRow.risultato;
					var tag = "perfvalutazioneuo.risultato.fixed.2";
					var typedObject = new appMeta.TypedObject("Decimal", result, tag);
					var value = typedObject.stringValue(tag);
					$('#perfvalutazioneuo_default_risultato').val(value);
					def.resolve();
				});
				return def.promise();
			},

			//buttons
		});

	window.appMeta.addMetaPage('perfvalutazioneuo', 'default', metaPage_perfvalutazioneuo);

}());
