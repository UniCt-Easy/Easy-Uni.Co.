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

			//isValidFunction

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
				this.helpForm.filter($('#registry_amministrativi_idaccmotivedebit'), null);
				this.helpForm.filter($('#registry_amministrativi_idaccmotivecredit'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
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
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar63').fullCalendar('rerenderEvents');
				});
				appMeta.metaModel.insertFilter(this.getDataTable("title"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("maritalstatus"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("registryclassdefaultview"), this.q.eq('registryclass_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("category"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("residence"), this.q.eq('active', 'S'));
				$('#grid_progettotimesheet_default').data('mdlconditionallookup', 'multilinetype,S,Si;multilinetype,N,No;output,P,PDF;output,F,PDF firmato;output,X,Excel;');
				$('#grid_registryreference_persone').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;');
				$('#grid_registrylegalstatus_amm').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;tempindet,S,Si;tempindet,N,No;');
				$('#grid_timbratura_default').data('mdlconditionallookup', 'convalida,S,Si;convalida,N,No;');
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

			beforePost: function () {
				var self = this;
				this.getDataTable('contrattostipendioannuoview').acceptChanges();
				this.getDataTable('contrattostipendioview').acceptChanges();
				//innerBeforePost
			},

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

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'amministrativi', metaPage_registry);

}());
