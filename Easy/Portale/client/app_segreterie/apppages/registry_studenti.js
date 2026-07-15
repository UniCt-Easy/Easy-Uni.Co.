(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'studenti', false]);
        this.name = 'Studenti';
		this.defaultListType = 'studenti';
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
				var def = appMeta.Deferred("isValid-registry_studenti");
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
				
			if (self.isNullOrMinDate(parentRow.birthdate))
				parentRow.birthdate = new Date();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_studenti_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_studenti_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_studenti_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_studenti_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_studenti_residence'), null);
				} else {
					this.helpForm.filter($('#registry_studenti_residence'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_studenti");
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
				this.helpForm.filter($('#registry_studenti_idregistryclass'), null);
				this.helpForm.filter($('#registry_studenti_idtitle'), null);
				this.helpForm.filter($('#registry_studenti_residence'), null);
				this.enableControl($('#registry_studenti_idreg'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.configureDependencies();
				this.state.DS.tables.registry.defaults({ 'extension': 'studenti' });
				this.state.DS.tables.registry.defaults({ 'idcentralizedcategory': '01' });
				this.state.DS.tables.registry.defaults({ 'idnation': 1 });
				this.state.DS.tables.registry.defaults({ 'idregistryclass': '22' });
				this.state.DS.tables.registry.defaults({ 'idregistrykind': '21' });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				this.state.DS.tables.registry.defaults({ 'active': 'S' });
				this.state.DS.tables.registry.defaults({ 'authorization_free': 'N' });
				this.state.DS.tables.registry.defaults({ 'multi_cf': 'N' });
				this.state.DS.tables.registry.defaults({ 'flagbankitaliaproceeds': 'N' });
				this.state.DS.tables.registry.defaults({ 'flag_pa': 'N' });
				this.state.DS.tables.registry.defaults({ 'sdi_norifamm': 'N' });
				this.setDenyNull("registry","surname");
				this.setDenyNull("registry","forename");
				this.setDenyNull("registry","gender");
				this.setDenyNull("registry","birthdate");
				appMeta.metaModel.insertFilter(this.getDataTable("maritalstatusdefaultview"), this.q.eq('maritalstatus_active', 'Si'));
				$('#grid_registryaddress_seg').data('mdlconditionallookup', 'active,S,Si;active,N,No;flagforeign,S,Si;flagforeign,N,No;');
				$('#grid_registryreference_persone').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;');
				$('#grid_titolostudio_docenti').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
				//indico al framework che la tabella corsostudio è cached
				var corsostudioTable = this.getDataTable("corsostudio");
				appMeta.metaModel.cachedTable(corsostudioTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(corsostudioTable, null, null));
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

			//afterPost

			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registrystudentiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registrystudentiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title?registrystudentiview.title']");
                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename;
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            },

			deleteNotDescendants: function (descendant, descendantalias, element, elementalias) {
				var self = this;
				var descendantTable = descendant + (descendantalias !== 0 ? '_alias' + descendantalias : '');
				var elementTable = element + (elementalias !== 0 ? '_alias' + elementalias : '');
				var elementKey = 'id' + element;
				this.state.DS.tables[descendantTable].select(window.jsDataQuery.isNotIn(elementKey, 
					_.map(self.getDataTable(elementTable).rows,
					function (row) {
						return row[elementKey]; //sbagliato
					}))).forEach(function (row) {
							var state = row.getRow().state;
							row.getRow().del();
							if (state !== "added")
								row.getRow().acceptChanges();
					});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'studenti', metaPage_registry);

}());
