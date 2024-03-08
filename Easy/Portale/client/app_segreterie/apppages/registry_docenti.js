(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'docenti', false]);
        this.name = 'Docenti';
		this.defaultListType = 'docenti';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
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

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idstruttura'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idstruttura'), this.q.eq('struttura_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idclassconsorsuale'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idclassconsorsuale'), this.q.eq('classconsorsuale_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idreg_istituti'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idreg_istituti'), this.q.eq('registry_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idaccmotivedebit'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idaccmotivedebit'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idaccmotivecredit'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idaccmotivecredit'), this.q.eq('accmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_docenti");
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
				this.helpForm.filter($('#registry_docenti_idstruttura'), null);
				this.helpForm.filter($('#registry_docenti_idclassconsorsuale'), null);
				this.helpForm.filter($('#registry_docenti_idreg_istituti'), null);
				this.helpForm.filter($('#registry_docenti_idaccmotivedebit'), null);
				this.helpForm.filter($('#registry_docenti_idaccmotivecredit'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				this.state.DS.tables.registry.defaults({ 'extension': 'docenti' });
				this.state.DS.tables.registry.defaults({ 'idcentralizedcategory': '01' });
				this.state.DS.tables.registry.defaults({ 'idregistryclass': '22' });
				this.state.DS.tables.registry.defaults({ 'idregistrykind': 8 });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				$("#btn_add_publicazregistry_docenti_idpublicaz").on("click", _.partial(this.searchAndAssignpublicaz, self));
				$("#btn_add_publicazregistry_docenti_idpublicaz").prop("disabled", true);
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar62').fullCalendar('rerenderEvents');
				});
				this.setDenyNull("registry","surname");
				this.setDenyNull("registry","forename");
				this.setDenyNull("registry","gender");
				appMeta.metaModel.insertFilter(this.getDataTable("title"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("maritalstatus"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("registryclasspersoneview"), this.q.eq('registryclass_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("residence"), this.q.eq('active', 'S'));
				$('#grid_registrylegalstatus_default').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;tempdef,S,Si;tempdef,N,No;tempindet,S,Si;tempindet,N,No;');
				$('#grid_titolostudio_docenti').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
				$('#grid_registryaddress_seg').data('mdlconditionallookup', 'active,S,Si;active,N,No;flagforeign,S,Si;flagforeign,N,No;');
				$('#grid_registryreference_persone').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;');
				$('#grid_affidamento_seg').data('mdlconditionallookup', 'freqobbl,S,Si;freqobbl,N,No;gratuito,S,Si;gratuito,N,No;riferimento,S,Si;riferimento,N,No;');
				$('#grid_progettotimesheet_default').data('mdlconditionallookup', 'multilinetype,S,Si;multilinetype,N,No;output,P,PDF;output,F,PDF firmato;output,X,Excel;');
				var grid_affidamento_segChildsTables = [
					{ tablename: 'affidamentocaratteristica', edittype: 'seg', columnlookup: 'json', columncalc: '!affidamentocaratteristica'},
				];
				$('#grid_affidamento_seg').data('childtables', grid_affidamento_segChildsTables);
				$('#grid_affidamento_seg').data('childtablesadd', false);
				$('#grid_affidamento_seg').data('childtablesedit', false);
				$('#grid_affidamento_seg').data('childtablesdelete', false);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_publicazregistry_docenti_idpublicaz").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_publicazregistry_docenti_idpublicaz").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			beforePost: function () {
				var self = this;
				this.getDataTable('contrattostipendioannuoview').acceptChanges();
				this.getDataTable('contrattostipendioview').acceptChanges();
				//innerBeforePost
			},

			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registrydocentiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registrydocentiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title?registrydocentiview.title']");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoitineration'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", self.state.currentRow.idreg),
						self.q.eq("idsospensione",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='sospensione.default.default']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			searchAndAssignpublicaz: function (that) {
				return that.searchAndAssign({
					tableName: "publicaz",
					listType: "default",
					idControl: "txt_publicazregistry_docenti_idpublicaz",
					tagSearch: "publicazdefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idpublicaz",
					columnToFill: "idpublicaz",
					tableToFill: "publicazregistry_docenti"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'docenti', metaPage_registry);

}());
