
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

    function metaPage_progetto() {
		MetaPage.apply(this, ['progetto', 'seg', false]);
        this.name = 'Progetti e attività';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_progetto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progetto,
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
				var def = appMeta.Deferred("afterGetFormData-progetto_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogetto_seg_budgetcalcolato());
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
				
				if (!parentRow['!altreupb'])
					parentRow['!altreupb'] = 'N';
				if (!parentRow.idprogettostatuskind)
					parentRow.idprogettostatuskind = 1;
				$("#XXsal").prop("disabled", !this.state.isEditState());
				$("#XXprogettocosto").prop("disabled", !this.state.isEditState());
				this.manageprogetto_seg_budgetcalcolato();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progetto_seg_idreg_aziende_fin'), null);
				} else {
					this.helpForm.filter($('#progetto_seg_idreg_aziende_fin'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progetto_seg_idstrumentofin'), null);
				} else {
					this.helpForm.filter($('#progetto_seg_idstrumentofin'), this.q.eq('strumentofin_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progetto_seg_idreg_amm'), null);
				} else {
					this.helpForm.filter($('#progetto_seg_idreg_amm'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progetto_seg_idreg'), null);
				} else {
					this.helpForm.filter($('#progetto_seg_idreg'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#progetto_seg_idreg_aziende'), null);
				} else {
					this.helpForm.filter($('#progetto_seg_idreg_aziende'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progetto_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettobudget_seg_spese());
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
				this.helpForm.filter($('#progetto_seg_idreg_aziende_fin'), null);
				this.helpForm.filter($('#progetto_seg_idstrumentofin'), null);
				this.helpForm.filter($('#progetto_seg_idreg_amm'), null);
				this.helpForm.filter($('#progetto_seg_idreg'), null);
				this.helpForm.filter($('#progetto_seg_idreg_aziende'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('workpackage'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettocosto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettobudgetvariazione'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettoricavo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettorp'), this.getDataTable('getprogettocostoview'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#progetto_seg_budgetcalcolato'), false);
				this.enableControl($('#progetto_seg_budgetcalcolatodate'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('workpackage'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettocosto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettobudgetvariazione'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettobudget'), this.getDataTable('progettoricavo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettorp'), this.getDataTable('getprogettocostoview'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_progettosettoreerc_idsettoreerc").on("click", _.partial(this.searchAndAssignsettoreerc, self));
				$("#btn_add_progettosettoreerc_idsettoreerc").prop("disabled", true);
				$("#btn_add_progettoregistry_aziende_idreg_aziende").on("click", _.partial(this.searchAndAssignregistry_aziende, self));
				$("#btn_add_progettoregistry_aziende_idreg_aziende").prop("disabled", true);
				$("#XXsal").prop("disabled", true);
				$("#XXprogettocosto").prop("disabled", true);
				$("#GenerateDetail").on("click", _.partial(this.fireGenerateDetail, this));
				$("#GenerateDetail").prop("disabled", true);
				$("#CalculateAmmortamento").on("click", _.partial(this.fireCalculateAmmortamento, this));
				$("#CalculateAmmortamento").prop("disabled", true);
				$("#CalculateCostiProgetto").on("click", _.partial(this.fireCalculateCostiProgetto, this));
				$("#CalculateCostiProgetto").prop("disabled", true);
				$("#GenerateCategorieCosto").on("click", _.partial(this.fireGenerateCategorieCosto, this));
				$("#GenerateCategorieCosto").prop("disabled", true);
				$("#GetAsset").on("click", _.partial(this.fireGetAsset, this));
				$("#GetAsset").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("registryprogfinsegview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("registryprogfinsegview"));
				//indico al framework che la tabella sal è cached
				var salTable = this.getDataTable("sal");
				appMeta.metaModel.cachedTable(salTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(salTable, null, null));
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registryaziendeview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("registryprogfinsegview"), false);
					var progetto_seg_idregistryprogfinCtrl = $('#progetto_seg_idregistryprogfin').data("customController");
					arraydef.push(progetto_seg_idregistryprogfinCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function () {
							if (self.state.currentRow && self.state.currentRow.idregistryprogfin) {
								return progetto_seg_idregistryprogfinCtrl.fillControl(null, self.state.currentRow.idregistryprogfin);
							}
							return true;
						})
						.then(function () {
							if (self.state.currentRow && self.state.currentRow.idregistryprogfinbando) {
								var progetto_seg_idregistryprogfinbandoCtrl = $('#progetto_seg_idregistryprogfinbando').data("customController");
								return progetto_seg_idregistryprogfinbandoCtrl.fillControl(null, self.state.currentRow.idregistryprogfinbando);
							}
							return true;
						})
					);

				}
				if (t.name === "progettostatuskinddefaultview" && r !== null) {
					if (r.progettostatuskind_contributoenterichiesto === 'No') {
						self.enableControl($('#progetto_seg_contributoenterichiesto'), false);
					}
					else {
						self.enableControl($('#progetto_seg_contributoenterichiesto'), true);
					}
				}
				if (t.name === "progettostatuskinddefaultview" && r !== null) {
					if (r.progettostatuskind_contributorichiesto === 'No') {
						self.enableControl($('#progetto_seg_contributorichiesto'), false);
					}
					else {
						self.enableControl($('#progetto_seg_contributorichiesto'), true);
					}
				}
				if (t.name === "progettostatuskinddefaultview" && r !== null) {
					if (r.progettostatuskind_contributoente === 'No') {
						self.enableControl($('#progetto_seg_contributoente'), false);
					}
					else {
						self.enableControl($('#progetto_seg_contributoente'), true);
					}
				}
				if (t.name === "progettostatuskinddefaultview" && r !== null) {
					if (r.progettostatuskind_contributo === 'No') {
						self.enableControl($('#progetto_seg_contributo'), false);
					}
					else {
						self.enableControl($('#progetto_seg_contributo'), true);
					}
				}
				if (t.name === "progettokindsegview" && r !== null) {
					if (r.progettokind_idcorsostudio === 'No') {
						self.enableControl($('#progetto_seg_idcorsostudio'), false);
					}
					else {
						self.enableControl($('#progetto_seg_idcorsostudio'), true);
					}
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_progettosettoreerc_idsettoreerc").prop("disabled", false);
				$("#btn_add_progettoregistry_aziende_idreg_aziende").prop("disabled", false);
				$("#GenerateDetail").prop("disabled", false);
				$("#CalculateAmmortamento").prop("disabled", false);
				$("#CalculateCostiProgetto").prop("disabled", false);
				$("#GenerateCategorieCosto").prop("disabled", false);
				$("#GetAsset").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXsal").length) {
					$("#XXsal").prop("disabled", !currMetaPage.state.isEditState());
				}
				if ($("#XXprogettocosto").length) {
					$("#XXprogettocosto").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_progettosettoreerc_idsettoreerc").prop("disabled", true);
					$("#btn_add_progettoregistry_aziende_idreg_aziende").prop("disabled", true);
					$("#GenerateDetail").prop("disabled", true);
					$("#CalculateAmmortamento").prop("disabled", true);
					$("#CalculateCostiProgetto").prop("disabled", true);
					$("#GenerateCategorieCosto").prop("disabled", true);
					$("#GetAsset").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			beforePost: function () {
				var self = this;
				this.getDataTable('getprogettocostoview').acceptChanges();
				//innerBeforePost
			},

			manageprogettobudget_seg_spese: function () {
				var self = this;

				//calcolo dei costi delle categorie di costo

				var progettobudget = this.getDataTable('progettobudget');
				var progettocosto = this.getDataTable('progettocosto');
				_.forEach(progettobudget.rows, function (rb) {
					rb["!spese"] = _.ceil(_.sumBy(
						_.filter(progettocosto.rows, function (r) {
							return r.idprogettotipocosto === rb.idprogettotipocosto &&
								r.idworkpackage === rb.idworkpackage && !!r.amount;
						}),
						'amount'), 2);
				});

				var progettoricavo = this.getDataTable('progettoricavo');
				_.forEach(progettobudget.rows, function (rb) {
					rb["!ricaviincassati"] = _.ceil(_.sumBy(
						_.filter(progettoricavo.rows, function (r) {
							return r.idprogettotipocosto === rb.idprogettotipocosto &&
								r.idworkpackage === rb.idworkpackage && !!r.amount;
						}),
						'amount'), 2);
				});

				//Budget corrente
				var progettobudgetvariazione = this.getDataTable('progettobudgetvariazione');
				_.forEach(progettobudget.rows, function (rb) {
					var dateCurr = new Date(1900, 1, 1);

					var progettobudgetvariazioneCategoriaCosto = _.filter(progettobudgetvariazione.rows, function (r) {
						return r.idprogettobudget === rb.idprogettobudget && !!r.newamount && !!r.data;
					})

					_.forEach(progettobudgetvariazioneCategoriaCosto.rows, function (rbv) {
						if (rbv.data > dateCurr) {
							rb["!budgetvariazione"] = r.newamount
						}
					});
				});

				//calcolo i costi delle UDR
				var def = appMeta.Deferred("manage_progettoudr_budget");

				//filtro su tutti i membri di TUTTE le udr del progetto sulla query sul sql
				var getcontrattiFilter = self.q.isIn('idreg', _.map(self.getDataTable("progettoudrmembro").rows, function (r) { return r.idreg; }));
				var getcontrattiFilter2 = self.q.isNotIn('idreg', _.map(self.getDataTable("getcontratti").rows, function (r) { return r.idreg; }));
				appMeta.getData.runSelectIntoTable(this.getDataTable('getcontratti'), self.q.and([getcontrattiFilter, getcontrattiFilter2]), null).then(function (t) {

					var filterDate = self.q.not(
						self.q.or(
							self.q.and(
								self.q.isNotNull('stop'),
								self.q.lt('stop', self.state.currentRow.start)
							), self.q.gt('start', self.state.currentRow.stop)
						));

					_.forEach(self.getDataTable("progettoudr").rows, function (rudr) {

						//filtro su tutti i membri di QUESTA SPECIFICA udr sulla query sul dataset
						var filterMembers = self.q.isIn("idreg", _.map(
							self.getDataTable("progettoudrmembro").rows, function (row) {
								if (row.idprogettoudr === rudr.idprogettoudr) {
									return row.idreg;
								}
							}));

						rudr.budget = 0;
						rudr['!budgetore'] = 0;
						//per ogni membro di questa specifica udr
						var oreLavorabiliAnno = 1720;
						var progettokinds = self.getDataTable("progettokindsegview").select(self.q.eq("idprogettokind", self.state.currentRow.idprogettokind));
						if (progettokinds.length > 0 && progettokinds[0].progettokind_oredivisionecostostipendio)
							oreLavorabiliAnno = progettokinds[0].progettokind_oredivisionecostostipendio;

						_.forEach(self.getDataTable("progettoudrmembro").select(filterMembers), function (rudrmembro) {
							var costomese = 0;
							var costoora = 0;
							var oremaxgg = 8;
							var filterNull = self.q.isNotNull('costomese');
							var contratti = t.select(self.q.and(filterDate, self.q.eq('idreg', rudrmembro.idreg), filterNull));
							if (contratti.length > 0) {
								//di base metto costo mensile del contratto ...
								if(contratti[0].costomese)
									costomese = contratti[0].costomese;
								if (contratti[0].oremaxgg)
									oremaxgg = contratti[0].oremaxgg;
								if (contratti[0].costolordoannuo)
									costoora = (contratti[0].costolordoannuo / contratti[0].oremax);
							}
							//se è definito un costo orario specifico per questo membro in questo progetto ...
							if (rudrmembro.costoorario) {
								//...lo moltiplico per le ore che può lavorare al giorno per 30 giorni 
								costomese = rudrmembro.costoorario * (oreLavorabiliAnno / 12);
								costoora = rudrmembro.costoorario;
							}
							else {
								//...altrimenti prendo in considerazione il costo mensile da contratto

								// se sono definite sulla tipologia di progetto lo calcolo in base alle quelle ore...
								if (progettokinds.length > 0 && contratti.length > 0)
									if (progettokinds[0].progettokind_oredivisionecostostipendio && contratti[0].costolordoannuo) {
										costomese = (contratti[0].costolordoannuo / 12);
										costoora = (contratti[0].costolordoannuo / oreLavorabiliAnno);
									}
								//... altrimenti lascio quello calcolato dalle ore della tipologia di contratto che ho inserito all'inizio
							}
							// ... infine lo moltiplico per i mesi di impegno del menbro nel progetto e lo sommo al budget
							rudr.budget += costomese * (rudrmembro.impegno ?? 0);
							rudr['!budgetore'] += costoora * (rudrmembro.orepreventivate ?? 0);
						});
						rudr.budget = _.ceil(rudr.budget, 2);
						rudr['!budgetore'] = _.ceil(rudr['!budgetore'], 2);
					});
					def.resolve();
				});
				return def.promise();
			},

			searchAndAssignsettoreerc: function (that) {
				return that.searchAndAssign({
					tableName: "settoreerc",
					listType: "segprog",
					idControl: "txt_progettosettoreerc_idsettoreerc",
					tagSearch: "settoreerc.title",
					columnNameText: "title",
					columnSource: "idsettoreerc",
					columnToFill: "idsettoreerc",
					tableToFill: "progettosettoreerc"
				});
			},

			searchAndAssignregistry_aziende: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "aziende",
					idControl: "txt_progettoregistry_aziende_idreg_aziende",
					tagSearch: "registryaziendeview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_aziende",
					tableToFill: "progettoregistry_aziende"
				});
			},

			fireGenerateDetail: function (that) {
				that.hasUnsavedChanges()
					.then(function (result) {
						if (result) {
							return that.showMessageOk("Prima devi salvare l'attività o progetto");
						} else {
							var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
							appMeta.getData.launchCustomServerMethod("callSP", {
								spname: "GenerateProgettoDetail",
								prm1: that.state.currentRow.idprogettokind,
								prm2: that.state.currentRow.idprogetto,
								prm3: appMeta.security.usr('userweb')
							}).then(function (res) {
								var msg = "OK. I dettagli sono stati generati";
								if (res.err) {
									msg = "KO " + res.err;
								}
								var parentRow = that.state.currentRow;
								var filter = window.jsDataQuery.eq("idprogetto", parentRow.idprogetto);
								var selBuilderArray = [];
								var tableToRefresh = ['workpackage', 'progettotipocosto', 'progettobudget', 'progettotipocostoaccmotive', 'progettotipocostocontrattokind', 'progettotipocostoinventorytree', 'progettotipocostotax', 'progettotesto', 'progettoattach'];
								_.forEach(tableToRefresh, function (tname) {
									selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: that.state.DS.tables[tname] });
								});
								appMeta.getData.multiRunSelect(selBuilderArray)
									.then(function () {
										that.freshForm(true, false)
											.then(function () {
												that.hideWaitingIndicator(waitingHandler);
												that.showMessageOk(msg);
											});
									});
							});
						}
					});
			},

			fireCalculateAmmortamento: function (that) {
				var idProgetto = that.state.currentRow.idprogetto;
				var waitingHandler = that.showWaitingIndicator("Attendi calcolo ammortamenti mensili per il progetto: " + idProgetto );
				var def = appMeta.Deferred("fireCalculateAmmortamento");

				appMeta.callWebService("calculateAmmortamento",
					{ idProgetto: idProgetto,
						userweb: appMeta.security.usr('userweb')})
					.then(function (res) {
						return that.manageProgettiResult(res);
					})
					.then(function() {
						that.hideWaitingIndicator(waitingHandler);
						return that.showMessageOk("Terminato il calcolo per l'ammortamento. Ricordati di premere salva dopo aver verificato la correttezza dei dati generati");
					})
					.then(function () {
						def.resolve();
					});

				return def.promise();
			},

			fireCalculateCostiProgetto: function (that) {
				var idProgetto = that.state.currentRow.idprogetto;
				var waitingHandler = that.showWaitingIndicator("Attendi calcolo costi per il progetto: " + idProgetto );
				var def = appMeta.Deferred("fireCalculateCostiProgetto");

				var progettocosto = that.getDataTable("progettocosto");
				progettocosto.autoIncrement('idprogettocosto', { minimum: 99990001 });

				appMeta.callWebService("calculateCostiProgetto",
					{ idProgetto: idProgetto,
						userweb: appMeta.security.usr('userweb')})
					.then(function (res) {
						return that.manageProgettiResult(res);
					})
					.then(function() {
						that.hideWaitingIndicator(waitingHandler);
						return that.showMessageOk("Terminato il calcolo dei costi di progetto. Ricordati di premere salva dopo aver verificato la correttezza dei dati generati");
					})
					.then(function () {
						def.resolve();
					});

				return def.promise();
			},

			manageProgettiResult: function (res) {
				var def = appMeta.Deferred("manageProgettiResult");
				var ds = res.ds;
				var error = res.error;
				if (error && error.length > 0) {
					return this.showMessageOk("Errore nel calcolo: " + error);
				}
				else
				{
					this.state.currentRow.budgetcalcolatodate = new Date();
				}
				var dsOut = appMeta.getDataUtils.getJsDataSetFromJson(ds);
				appMeta.getDataUtils.mergeDataSet(this.state.DS, dsOut, true);

				return def.from(this.freshForm(true, false));
			}
,

			fireGenerateCategorieCosto:function(that) {
            	// 1, Aggiunge automaticamente sulla tabella progettobudget, le righe
				// che rappresentano l'associazione tra wp e progettotipocosto. Quindi viene fatto il prodotto (workpackage x progettotipocosto)
				// e vengono aggiunte le righe mancanti.
				// 2. Allo stesso modo viene fatto un ciclo sulle righe di progettobudget
				// e vengono elimnate le righe che non hanno più uno dei due riferimenti su workpackage o progettotipocosto
            	var workpackage = that.getDataTable('workpackage');
				var progettotipocosto = that.getDataTable('progettotipocosto');
				var progettobudget = that.getDataTable('progettobudget');
				var currentDataRow = that.state.currentRow.getRow();

				var msg = "";
				var foundAddedRow = false;
				var rowAdded = 0;
				var rowDeleted = 0;

				var def = appMeta.Deferred("fireUpdateCategoriaCosto");

				var waitingHandler = that.showWaitingIndicator("Sto aggiornando le categorie di costo");

				var meta_progettobudget = appMeta.getMeta('progettobudget');
				var arrayNewRow = [];
				// memorizza i defaultr iniziali
				var progettobudgetDefaults = _.clone(progettobudget.defaults());
				// 1. Aggiunge righe
				_.forEach(workpackage.rows, function (rWork) {
					_.forEach(progettotipocosto.rows, function (rPrTipo) {
						var idworkpackage = rWork.idworkpackage;
						var idprogettotipocosto = rPrTipo.idprogettotipocosto;

						// se ho aggiunto uno dei due padri allora non inserisco su progettobudget, perchè
						// ler gihe rimarrebbro scollegate con la chiave esterna, cioè rimarrebbe qella autoincremento
						// poichè mdl non avendo le relazioni non saprebbe mettere il corretto valore
						if (rWork.getRow().state === jsDataSet.dataRowState.added ||
							rPrTipo.getRow().state === jsDataSet.dataRowState.added) {
							if (!foundAddedRow) {
								msg += "Ci sono nuovi workpackage o voci di costo non salvati.</br> Premere prima il tasto salva per confermare i nuovi oggetti e poi"
								msg += " ripremi nuovamente il pulsante per creare le nuove categorie costo.</br></br>"
								foundAddedRow = true;
							}
						} else {
							// trova la riga
							var progettobudgetRow = _.find(progettobudget.rows, function (rProgBudg) {
								return (rProgBudg.idworkpackage === idworkpackage &&
									rProgBudg.idprogettotipocosto === idprogettotipocosto)
							});

							// se non esiste la crea
							if (!progettobudgetRow) {
								rowAdded++;
								// la riga deve essere creata con le chiavi esterne corrette
								progettobudget.defaults({idworkpackage: idworkpackage, idprogettotipocosto: idprogettotipocosto });
								arrayNewRow.push(meta_progettobudget.getNewRow(currentDataRow, progettobudget, null));
							}
						}

					})
				});

				// 2. elimina le righe che non esistono più in wrkp o in progettotipocosto
				progettobudget.rows
					.filter(function (r) {
						return r.getRow().state === jsDataSet.dataRowState.unchanged ||
							   r.getRow().state === jsDataSet.dataRowState.modified;
					}).forEach(function (rProgBudg) {
						var idworkpackage = rProgBudg.idworkpackage;
						var idprogettotipocosto = rProgBudg.idprogettotipocosto;

						var rWork = _.find(workpackage.rows, function (r) {
							// se la trovo e sta in deleted torno riga non trovata , così eliminerò
							return r.idworkpackage === idworkpackage &&
								   r.getRow().state !== jsDataSet.dataRowState.deleted;
						});
						var rkProg = _.find(progettotipocosto.rows, function (r) {
							return r.idprogettotipocosto === idprogettotipocosto &&
								   r.getRow().state !== jsDataSet.dataRowState.deleted;
						});

						// se non trovo le righe nelle tabelle collegate, la cancello
						if (!rWork || !rkProg) {
							appMeta.metaModel.cascadeDelete(rProgBudg);
							rowDeleted++;
						}
					});


				// risolve le getNew Row asincrone e preme salva automaticamente
				$.when.apply($, arrayNewRow)
					.then(function () {
						if (rowAdded > 0 || rowDeleted > 0) {
							msg += "Sono state effettuate le seguenti modifiche:</br></br>";
							// ho righe da committare, quindi premo salva
							return	that.cmdMainSave();
						}
						return false;

					}).then(function (res) {
					    that.hideWaitingIndicator(waitingHandler);
						// riassegno eventuali defaultoriginali
						progettobudget.defaults(progettobudgetDefaults);

						if (!res) {
							if (msg.length) {
								that.showMessageOk(msg);
							}
							appMeta.Toast.showNotification("Non ho inserito o eliminato nessuna nuova categoria costo");
							return def.resolve();
						}

						if (rowAdded > 0) {
							msg += "Sono state inserite " + rowAdded.toString() + " nuove categorie di costo</br></br>";
						}
						if (rowDeleted > 0) {
							msg += "Sono state eliminate " + rowDeleted.toString() + " categorie di costo, associate a workpackage o voci di costo non esistenti";
						}
						// mostro messaggio di riepilogo
						that.showMessageOk(msg);
						def.resolve();
					});

				return def.promise();

			},

			fireGetAsset: function (that) {

				that.calcFilterOnClassificazioneInventariale(that.state.DS)
					.then(function (filter) {
						that.searchAndAssign({
							tableName: 'asset',
							listType: 'seg',
							idControl: 'progetto_seg_filtraAsset',
							tagSearch: 'assetsegview.dropdown_title',
							columnNameText: 'multifield',
							columnSource: 'idasset,idpiece',
							columnToFill: 'idasset,idpiece',
							tableToFill: 'progettoasset',
							filter: filter
						});
					});
			},

			calcFilterOnClassificazioneInventariale: function (DSProgetto) {
				// filtro sui beni strumentali che afferiscono alla classificazione inventariale delle voci di costo
				/*
					assetsegview where inventorytree_codeinv is in (
					select codeinv from inventorytree where idinv in (
					select idinv  from datasetparent.progettotipocostoinventorytree.idinv))
				*/

				// 1. select idinv  from datasetparent.progettotipocostoinventorytree.idinv)
				var def = appMeta.Deferred("setFilterOnClassificazioneInventariale-progettoasset_default");
				var arrayIdInv = _.map(DSProgetto.tables.progettotipocostoinventorytree.rows,
					function (r) { return r.idinv; });
				var filterInventoryTree = window.jsDataQuery.isIn("idinv", arrayIdInv);

				// 2. select codeinv from inventorytree where idinv in
				return appMeta.getData.runSelect("inventorytree", "codeinv", filterInventoryTree, null)
					.then(function (dtInventorytree) {
						var arrayCodeinv = _.map(dtInventorytree.rows, function (r) { return r.codeinv; });

						// 3. assetsegview where inventorytree_codeinv is in
						var filter = window.jsDataQuery.isIn("inventorytree_codeinv", arrayCodeinv);

						//4 . se è spuntato altreupb allora basta così altrimenti filtro anche sulle upb dell progetto
						if (!$("#progetto_seg_altreupb").is(':checked')) {
							var upbs = _.map(DSProgetto.tables.workpackageupb.rows, function (r) { return r.idupb; });
							filter = window.jsDataQuery.and([filter, window.jsDataQuery.isIn("upb_idupb", upbs)]);
						}

						return def.resolve(filter);
					});
			},

			manageprogetto_seg_budgetcalcolato: function () {
				this.state.currentRow.budgetcalcolato = parseFloat(_.sumBy(this.state.DS.tables.progettocosto.rows, function (r) {
					if (r.amount) return r.amount;
					return 0;
				}).toFixed(2));

			},

			//buttons
        });

	window.appMeta.addMetaPage('progetto', 'seg', metaPage_progetto);

}());
