(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'amministrativi_personale', false]);
        this.name = 'Dati personali';
		this.defaultListType = 'amministrativi_personale';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.firstSearchFilter = window.jsDataQuery.constant(true);
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
					this.helpForm.filter($('#registry_amministrativi_personale_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_personale_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_personale_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_personale_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_personale_idcategory'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_personale_idcategory'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_amministrativi_personale");
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
				this.enableControl($('#registry_amministrativi_personale_extmatricula'), true);
				this.enableControl($('#registry_amministrativi_personale_idtitle'), true);
				this.helpForm.filter($('#registry_amministrativi_personale_idtitle'), null);
				this.enableControl($('#registry_amministrativi_personale_surname'), true);
				this.enableControl($('#registry_amministrativi_personale_forename'), true);
				this.enableControl($('#registry_amministrativi_personale_birthdate'), true);
				this.enableControl($('#registry_amministrativi_personale_idcity'), true);
				this.enableControl($('#registry_amministrativi_personale_idnation'), true);
				this.enableControl($('#registry_amministrativi_personale_genderM'), true);
				this.enableControl($('#registry_amministrativi_personale_genderF'), true);
				this.enableControl($('#registry_amministrativi_personale_cf'), true);
				this.enableControl($('#registry_amministrativi_personale_foreigncf'), true);
				this.enableControl($('#registry_amministrativi_personale_badgecode'), true);
				this.enableControl($('#registry_amministrativi_personale_idmaritalstatus'), true);
				this.enableControl($('#registry_amministrativi_personale_activeSi'), true);
				this.enableControl($('#registry_amministrativi_personale_activeNo'), true);
				this.enableControl($('#registry_amministrativi_personale_idregistryclass'), true);
				this.helpForm.filter($('#registry_amministrativi_personale_idregistryclass'), null);
				this.enableControl($('#registry_amministrativi_personale_annotation'), true);
				this.enableControl($('#registry_amministrativi_personale_idcategory'), true);
				this.helpForm.filter($('#registry_amministrativi_personale_idcategory'), null);
				this.enableControl($('#registry_amministrativi_personale_idregistrykind'), true);
				this.enableControl($('#registry_amministrativi_personale_p_iva'), true);
				this.enableControl($('#registry_amministrativi_personale_residence'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				this.state.DS.tables.registry.defaults({ 'active': 'S' });
				this.state.DS.tables.registry.defaults({ 'extension': 'amministrativi' });
				this.state.DS.tables.registry.defaults({ 'idcentralizedcategory': "01" });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar60').fullCalendar('rerenderEvents');
				});
				appMeta.metaModel.insertFilter(this.getDataTable("maritalstatus"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("residence"), this.q.eq('active', 'S'));
				$('#grid_registrylegalstatus_amm').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;tempindet,S,Si;tempindet,N,No;');
				$('#grid_progettotimesheet_datipersonali').data('mdlconditionallookup', 'multilinetype,S,Si;multilinetype,N,No;output,P,PDF;output,F,PDF firmato;output,X,Excel;');
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

			//beforePost

			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registryamministrativiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registryamministrativiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title']");

				// funz di trasformazione
				var modifiesDenominazione = function (row) {
					if (!row) return;
					var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
					var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
					return vSurname + " " + vForename.substring(1,49);
				};
				this.registerFormula(f1, modifiesDenominazione);

				this.addDependencies(p1, f1);
				this.addDependencies(p2, f1);
			},

			afterFill: function () {
				this.enableControl($('#registry_amministrativi_personale_extmatricula'), false);
				this.enableControl($('#registry_amministrativi_personale_idtitle'), false);
				this.enableControl($('#registry_amministrativi_personale_surname'), false);
				this.enableControl($('#registry_amministrativi_personale_forename'), false);
				this.enableControl($('#registry_amministrativi_personale_birthdate'), false);
				this.enableControl($('#registry_amministrativi_personale_idcity'), false);
				this.enableControl($('#registry_amministrativi_personale_idnation'), false);
				this.enableControl($('#registry_amministrativi_personale_genderM'), false);
				this.enableControl($('#registry_amministrativi_personale_genderF'), false);
				this.enableControl($('#registry_amministrativi_personale_cf'), false);
				this.enableControl($('#registry_amministrativi_personale_foreigncf'), false);
				this.enableControl($('#registry_amministrativi_personale_badgecode'), false);
				this.enableControl($('#registry_amministrativi_personale_idmaritalstatus'), false);
				this.enableControl($('#registry_amministrativi_personale_activeSi'), false);
				this.enableControl($('#registry_amministrativi_personale_activeNo'), false);
				this.enableControl($('#registry_amministrativi_personale_idregistryclass'), false);
				this.enableControl($('#registry_amministrativi_personale_annotation'), false);
				this.enableControl($('#registry_amministrativi_personale_idcategory'), false);
				this.enableControl($('#registry_amministrativi_personale_idregistrykind'), false);
				this.enableControl($('#registry_amministrativi_personale_p_iva'), false);
				this.enableControl($('#registry_amministrativi_personale_residence'), false);
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

	window.appMeta.addMetaPage('registry', 'amministrativi_personale', metaPage_registry);

}());
