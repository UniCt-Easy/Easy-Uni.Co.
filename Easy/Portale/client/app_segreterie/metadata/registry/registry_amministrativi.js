(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'amministrativi', false]);
        this.name = 'Personale Amministrativo';
		this.defaultListType = 'amministrativi';
		//pageHeaderDeclaration
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registry,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-registry_amministrativi");
				var firstErrorObj;

				if (rowToCheck.table.dataset.tables["registrymultikindregistry"] && this.getNotDeletedRows(rowToCheck.table.dataset.tables["registrymultikindregistry"]).length < 1) {
					firstErrorObj = { warningMsg: "", errMsg: loc.getMinNumRowRequired("", 1), errField: "XXregistrymultikindregistry", row: rowToCheck, outCaption: "Tipo anagrafica" };
					return def.resolve(firstErrorObj);
				}
				//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			//afterGetFormData

			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_idaccmotivedebit'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_idaccmotivedebit'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_idaccmotivecredit'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_idaccmotivecredit'), this.q.eq('accmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_amministrativi");
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
				this.enableControl($('#registry_amministrativi_idreg'), true);
				this.helpForm.filter($('#registry_amministrativi_idaccmotivedebit'), null);
				this.helpForm.filter($('#registry_amministrativi_idaccmotivecredit'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				this.state.DS.tables.registry.defaults({ 'active': 'S' });
				this.state.DS.tables.registry.defaults({ 'extension': 'amministrativi' });
				this.state.DS.tables.registry.defaults({ 'idcentralizedcategory': '01' });
				this.state.DS.tables.registry.defaults({ 'idregistryclass': '22' });
				this.state.DS.tables.registry.defaults({ 'idregistrykind': 5 });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				this.state.DS.tables.registry.defaults({ 'authorization_free': 'N' });
				this.state.DS.tables.registry.defaults({ 'multi_cf': 'N' });
				this.state.DS.tables.registry.defaults({ 'flagbankitaliaproceeds': 'N' });
				this.state.DS.tables.registry.defaults({ 'flag_pa': 'N' });
				this.state.DS.tables.registry.defaults({ 'sdi_norifamm': 'N' });
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar71').fullCalendar('rerenderEvents');
				});
				appMeta.metaModel.insertFilter(this.getDataTable("title"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("maritalstatusdefaultview"), this.q.eq('maritalstatus_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("registryclassdefaultview"), this.q.eq('registryclass_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("categorydefaultview"), this.q.eq('category_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("residence"), this.q.eq('active', 'S'));
				$('#grid_rendicontattivitaprogetto_anagamm').data('mdlconditionallookup', 'rendicontatutto,S,Si;rendicontatutto,N,No;');
				$('#grid_progettotimesheet_default').data('mdlconditionallookup', 'multilinetype,S,Si;multilinetype,N,No;output,P,PDF;output,F,PDF firmato;output,X,Excel;');
				$('#grid_registryreference_persone').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;');
				$('#grid_registrylegalstatus_amm').data('mdlconditionallookup', 'tempindet,S,Si;tempindet,N,No;');
				$('#grid_registrycongiunto_default').data('mdlconditionallookup', 'have104,S,Si;have104,N,No;');
				$('#grid_timbratura_default').data('mdlconditionallookup', 'convalida,S,Si;convalida,N,No;');
				$('#registry_amministrativi_importtimbratura').on("change", _.partial(this.manageimporttimbratura, self));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			
			
			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registryamministrativiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registryamministrativiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title?registryamministrativiview.registry_title']");

				// funz di trasformazione
				var modifiesDenominazione = function (row) {
					if (!row) return;
					var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
					var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
					return vSurname + " " + vForename.substring(0,49);
				};
				this.registerFormula(f1, modifiesDenominazione);

				this.addDependencies(p1, f1);
				this.addDependencies(p2, f1);
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg),
						self.q.eq("idsospensione",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='sospensione.default.default']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			beforePost: function () {
				var self = this;
				const rowsChanged = this.state.DS.tables.costoorario.getChanges();
				if (rowsChanged.length > 0) this.haveToRefreshCosts = true;
				this.getDataTable('contrattostipendioannuoview').acceptChanges();
				this.getDataTable('contrattostipendioview').acceptChanges();
				//innerBeforePost
			},

			afterPost: function () {
				if (this.haveToRefreshCosts == true) {
					var self = this;
					var waitingHandler = this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
					appMeta.getData.launchCustomServerMethod("callSP", {
						spname: "sp_calcola_costi_periodi_persona_progetto",
						prm1: this.state.currentRow.idreg,
						prm2: '',
						prm3: ''
					}).then(function (res) {
						self.haveToRefreshCosts = false
						self.hideWaitingIndicator(waitingHandler);
					});
				}
			},

			manageimporttimbratura: function(that) { 
				var files = event.target.files;
				var file = files[0];
				var colname = 'idreg'; //chiave del padre
				var id = [that.state.currentRow[colname]]; //chiavi padre, nonno, ecc.
				//nome della procedura, array chiavi, riga dell'header del file di import, nome tabella in griglia da ricaricare, chiave del padre
				appMeta.ImportExcel.importFileIntoTable(that, file, 'sp_import_timbrature', id, 0, 'timbratura', colname, null)
					.then(function () {
						$('#registry_amministrativi_importtimbratura').val('');
					});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'amministrativi', metaPage_registry);

}());
