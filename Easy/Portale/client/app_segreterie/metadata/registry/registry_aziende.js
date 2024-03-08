(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'aziende', false]);
        this.name = 'Enti e Aziende';
		this.defaultListType = 'aziende';
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
					this.helpForm.filter($('#registry_aziende_idnaturagiur'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_idnaturagiur'), this.q.eq('naturagiur_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_idcategory'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_idcategory'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_idaccmotivedebit'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_idaccmotivedebit'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_idaccmotivecredit'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_idaccmotivecredit'), this.q.eq('accmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_aziende");
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
				this.helpForm.filter($('#registry_aziende_idnaturagiur'), null);
				this.helpForm.filter($('#registry_aziende_idcategory'), null);
				this.helpForm.filter($('#registry_aziende_idaccmotivedebit'), null);
				this.helpForm.filter($('#registry_aziende_idaccmotivecredit'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.registry.defaults({ 'extension': 'aziende' });
				this.state.DS.tables.registry.defaults({ 'idcentralizedcategory': '03' });
				this.state.DS.tables.registry.defaults({ 'idregistryclass': '21' });
				this.state.DS.tables.registry.defaults({ 'idregistrykind': 4 });
				this.state.DS.tables.registry.defaults({ 'residence': 1 });
				$("#btn_add_ccnlregistry_aziende_idccnl").on("click", _.partial(this.searchAndAssignccnl, self));
				$("#btn_add_ccnlregistry_aziende_idccnl").prop("disabled", true);
				appMeta.metaModel.insertFilter(this.getDataTable("registryclassaziendeview"), this.q.eq('registryclass_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("residence"), this.q.eq('active', 'S'));
				appMeta.metaModel.insertFilter(this.getDataTable("numerodip"), this.q.eq('active', 'S'));
				$('#grid_ccnlregistry_aziende_default').data('mdlconditionallookup', '!idccnl_ccnl_active,S,Si;!idccnl_ccnl_active,N,No;!idccnl_registry_active,S,Si;!idccnl_registry_active,N,No;');
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

			rowSelected: function (dataRow) {
				$("#btn_add_ccnlregistry_aziende_idccnl").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_ccnlregistry_aziende_idccnl").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignccnl: function (that) {
				return that.searchAndAssign({
					tableName: "ccnl",
					listType: "default",
					idControl: "txt_ccnlregistry_aziende_idccnl",
					tagSearch: "ccnldefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idccnl",
					columnToFill: "idccnl",
					tableToFill: "ccnlregistry_aziende"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'aziende', metaPage_registry);

}());
