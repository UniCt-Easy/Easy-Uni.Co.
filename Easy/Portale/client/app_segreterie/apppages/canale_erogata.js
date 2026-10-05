(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_canale() {
		MetaPage.apply(this, ['canale', 'erogata', true]);
        this.name = 'Canali';
		this.defaultListType = 'erogata';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_canale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_canale,
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
				var def = appMeta.Deferred("afterGetFormData-canale_erogata");
				var arraydef = [];
				
				arraydef.push(this.managecanale_erogata_idsede());
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
				
				if (this.isNull(parentRow['!filtrostud']) || parentRow['!filtrostud'] == '')
					parentRow['!filtrostud'] = 'T';
				this.managecanale_erogata_idsede();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-canale_erogata");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('canaleregistry'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('iscrizione'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('canaleregistry'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('canale'), this.getDataTable('iscrizione'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_canaleregistry_idreg").on("click", _.partial(this.searchAndAssignregistry, self));
				$("#btn_add_canaleregistry_idreg").prop("disabled", true);
				$('#grid_mutuazione_default').data('mdlconditionallookup', 'riferimento,S,Si;riferimento,N,No;');
				$('#grid_canaleregistry_default').data('mdlconditionallookup', '!idreg_registry_active,S,Si;!idreg_registry_active,N,No;');
				$('#grid_affidamento_default').data('mdlconditionallookup', 'freqobbl,S,Si;freqobbl,N,No;gratuito,S,Si;gratuito,N,No;riferimento,S,Si;riferimento,N,No;');
				var grid_affidamento_defaultChildsTables = [
					{ tablename: 'affidamentocaratteristica', edittype: 'default', columnlookup: 'cf', columncalc: '!affidamentocaratteristica'},
				];
				$('#grid_affidamento_default').data('childtables', grid_affidamento_defaultChildsTables);
				$('#grid_affidamento_default').data('childtablesadd', false);
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
				$("#btn_add_canaleregistry_idreg").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_canaleregistry_idreg").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			//afterPost

			searchAndAssignregistry: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "studenti",
					idControl: "txt_canaleregistry_idreg",
					tagSearch: "registrystudentiview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg",
					tableToFill: "canaleregistry",
					filter: document.querySelector('input[name="canale_erogata_filtrostud"]:checked')?.id === 'canale_erogata_filtrostudT'
						? null
						: that.q.isIn(
							'idreg',
							_.map(that.state.DS.tables.iscrizione.rows, r => r.idreg)
						)

				});
			},

			managecanale_erogata_idsede: function () {
this.state.currentRow.idsede= this.state.callerState.currentRow.idsede;
			},

			//buttons
        });

	window.appMeta.addMetaPage('canale', 'erogata', metaPage_canale);

}());
