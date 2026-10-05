(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'istituti_princ', false]);
        this.name = 'Istituto in gestione';
		this.defaultListType = 'istituti_princ';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-registry_istituti_princ");
				var arraydef = [];
				
				arraydef.push(this.manageregistry_istituti_princ_idistitutokind());
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
				
				this.manageregistry_istituti_princ_idistitutokind();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istitutoprinc_default_idreg_dir'), null);
				} else {
					this.helpForm.filter($('#istitutoprinc_default_idreg_dir'), this.q.eq('getregistrydocentiamministrativi_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istitutoprinc_default_idreg_diramm'), null);
				} else {
					this.helpForm.filter($('#istitutoprinc_default_idreg_diramm'), this.q.eq('getregistrydocentiamministrativi_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_istituti_princ");
				var arraydef = [];
				
				var dtistitutoprinc = this.state.DS.tables["istitutoprinc"];
				if (dtistitutoprinc.rows.length === 0) {
					var metaistitutoprinc = appMeta.getMeta("istitutoprinc");
					metaistitutoprinc.setDefaults(dtistitutoprinc);
					var defistitutoprinc = metaistitutoprinc.getNewRow(parentRow.getRow(), dtistitutoprinc, self.editType).then(
						function (currentRowistitutoprinc) {
							//defaultistitutoprincObject
							return true;
						}
					);
					arraydef.push(defistitutoprinc);
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
				this.helpForm.filter($('#istitutoprinc_default_idreg_dir'), null);
				this.helpForm.filter($('#istitutoprinc_default_idreg_diramm'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('aoo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('struttura'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('aoo'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('struttura'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.istitutoprinc, "default", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("istitutoprinc");
				$('#grid_struttura_princ').data('mdlconditionallookup', 'active,S,Si;active,N,No;');
				$('#grid_registryreference_seg').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;');
				$('#grid_registryaddress_seg').data('mdlconditionallookup', 'active,S,Si;active,N,No;flagforeign,S,Si;flagforeign,N,No;');
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

			manageregistry_istituti_princ_idistitutokind: function () {
this.state.currentRow.idistitutokind = this.state.DS.tables.istitutoprinc.rows[0].idistitutokind ;
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'istituti_princ', metaPage_registry);

}());
