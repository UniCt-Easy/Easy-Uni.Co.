(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'aziende_ro', false]);
        this.name = 'Enti e Aziende';
		this.defaultListType = 'aziende_ro';
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
					this.helpForm.filter($('#registry_aziende_ro_idcategory'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idcategory'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_residence'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_residence'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idnaturagiur'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idnaturagiur'), this.q.eq('naturagiur_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_ro_idnumerodip'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_ro_idnumerodip'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_aziende_ro");
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
				this.enableControl($('#registry_aziende_ro_title'), true);
				this.enableControl($('#registry_aziende_ro_idregistrykind'), true);
				this.enableControl($('#registry_aziende_ro_title_en'), true);
				this.enableControl($('#registry_aziende_ro_idcategory'), true);
				this.helpForm.filter($('#registry_aziende_ro_idcategory'), null);
				this.enableControl($('#registry_aziende_ro_idregistryclass'), true);
				this.helpForm.filter($('#registry_aziende_ro_idregistryclass'), null);
				this.enableControl($('#registry_aziende_ro_residence'), true);
				this.helpForm.filter($('#registry_aziende_ro_residence'), null);
				this.enableControl($('#registry_aziende_ro_ccp'), true);
				this.enableControl($('#registry_aziende_ro_idnation'), true);
				this.enableControl($('#registry_aziende_ro_flag_paS'), true);
				this.enableControl($('#registry_aziende_ro_flag_paN'), true);
				this.enableControl($('#registry_aziende_ro_idcity'), true);
				this.enableControl($('#registry_aziende_ro_location'), true);
				this.enableControl($('#registry_aziende_ro_ipa_fe'), true);
				this.enableControl($('#registry_aziende_ro_cf'), true);
				this.enableControl($('#registry_aziende_ro_p_iva'), true);
				this.enableControl($('#registry_aziende_ro_foreigncf'), true);
				this.enableControl($('#registry_aziende_ro_pic'), true);
				this.enableControl($('#registry_aziende_ro_multi_cfSi'), true);
				this.enableControl($('#registry_aziende_ro_multi_cfNo'), true);
				this.enableControl($('#registry_aziende_ro_annotation'), true);
				this.enableControl($('#registry_aziende_ro_idateco'), true);
				this.enableControl($('#registry_aziende_ro_idnace'), true);
				this.enableControl($('#registry_aziende_ro_idnaturagiur'), true);
				this.helpForm.filter($('#registry_aziende_ro_idnaturagiur'), null);
				this.enableControl($('#registry_aziende_ro_idnumerodip'), true);
				this.helpForm.filter($('#registry_aziende_ro_idnumerodip'), null);
				this.enableControl($('#registry_aziende_ro_activeSi'), true);
				this.enableControl($('#registry_aziende_ro_activeNo'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#registry_aziende_ro_title'), false);
				this.enableControl($('#registry_aziende_ro_idregistrykind'), false);
				this.enableControl($('#registry_aziende_ro_title_en'), false);
				this.enableControl($('#registry_aziende_ro_idcategory'), false);
				this.enableControl($('#registry_aziende_ro_idregistryclass'), false);
				this.enableControl($('#registry_aziende_ro_residence'), false);
				this.enableControl($('#registry_aziende_ro_ccp'), false);
				this.enableControl($('#registry_aziende_ro_idnation'), false);
				this.enableControl($('#registry_aziende_ro_flag_paS'), false);
				this.enableControl($('#registry_aziende_ro_flag_paN'), false);
				this.enableControl($('#registry_aziende_ro_idcity'), false);
				this.enableControl($('#registry_aziende_ro_location'), false);
				this.enableControl($('#registry_aziende_ro_ipa_fe'), false);
				this.enableControl($('#registry_aziende_ro_cf'), false);
				this.enableControl($('#registry_aziende_ro_p_iva'), false);
				this.enableControl($('#registry_aziende_ro_foreigncf'), false);
				this.enableControl($('#registry_aziende_ro_pic'), false);
				this.enableControl($('#registry_aziende_ro_multi_cfSi'), false);
				this.enableControl($('#registry_aziende_ro_multi_cfNo'), false);
				this.enableControl($('#registry_aziende_ro_annotation'), false);
				this.enableControl($('#registry_aziende_ro_idateco'), false);
				this.enableControl($('#registry_aziende_ro_idnace'), false);
				this.enableControl($('#registry_aziende_ro_idnaturagiur'), false);
				this.enableControl($('#registry_aziende_ro_idnumerodip'), false);
				this.enableControl($('#registry_aziende_ro_activeSi'), false);
				this.enableControl($('#registry_aziende_ro_activeNo'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.registry.defaults({ 'extension': 'aziende' });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				$('#grid_registryaddress_seg').data('mdlconditionallookup', 'active,S,Si;active,N,No;flagforeign,S,Si;flagforeign,N,No;');
				$('#grid_registryreference_seg').data('mdlconditionallookup', 'flagdefault,S,Si;flagdefault,N,No;');
				$('#grid_ccnlregistry_aziende_default').data('mdlconditionallookup', '!idccnl_ccnl_active,S,Si;!idccnl_ccnl_active,N,No;!idccnl_registry_active,S,Si;!idccnl_registry_active,N,No;');
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

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'aziende_ro', metaPage_registry);

}());
