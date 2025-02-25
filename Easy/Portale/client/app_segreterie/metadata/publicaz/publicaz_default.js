(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_publicaz() {
		MetaPage.apply(this, ['publicaz', 'default', false]);
        this.name = 'Pubblicazioni';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_publicaz.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_publicaz,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('publicaz'), this.getDataTable('publicazkeyword'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('publicaz'), this.getDataTable('publicazkeyword'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_publicazkindpublicaz_idpublicazkind").on("click", _.partial(this.searchAndAssignpublicazkind, self));
				$("#btn_add_publicazkindpublicaz_idpublicazkind").prop("disabled", true);
				$("#btn_add_publicazregistry_aziende_idreg_aziende").on("click", _.partial(this.searchAndAssignregistry, self));
				$("#btn_add_publicazregistry_aziende_idreg_aziende").prop("disabled", true);
				$("#btn_add_publicazregistry_docenti_idreg_docenti").on("click", _.partial(this.searchAndAssignregistry_alias1, self));
				$("#btn_add_publicazregistry_docenti_idreg_docenti").prop("disabled", true);
				$('#grid_publicazkindpublicaz_default').data('mdlconditionallookup', '!idpublicazkind_publicazkind_active,S,Si;!idpublicazkind_publicazkind_active,N,No;');
				$('#grid_publicazregistry_aziende_default').data('mdlconditionallookup', '!idreg_registry_active,S,Si;!idreg_registry_active,N,No;!idreg_registry_flag_pa,S,Si;!idreg_registry_flag_pa,N,No;');
				$('#grid_publicazregistry_docenti_default').data('mdlconditionallookup', '!idreg_registry_active,S,Si;!idreg_registry_active,N,No;');
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
				$("#btn_add_publicazkindpublicaz_idpublicazkind").prop("disabled", false);
				$("#btn_add_publicazregistry_aziende_idreg_aziende").prop("disabled", false);
				$("#btn_add_publicazregistry_docenti_idreg_docenti").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_publicazkindpublicaz_idpublicazkind").prop("disabled", true);
					$("#btn_add_publicazregistry_aziende_idreg_aziende").prop("disabled", true);
					$("#btn_add_publicazregistry_docenti_idreg_docenti").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignpublicazkind: function (that) {
				return that.searchAndAssign({
					tableName: "publicazkind",
					listType: "default",
					idControl: "txt_publicazkindpublicaz_idpublicazkind",
					tagSearch: "publicazkinddefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idpublicazkind",
					columnToFill: "idpublicazkind",
					tableToFill: "publicazkindpublicaz"
				});
			},

			searchAndAssignregistry: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "aziende",
					idControl: "txt_publicazregistry_aziende_idreg_aziende",
					tagSearch: "registryaziendeview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_aziende",
					tableToFill: "publicazregistry_aziende"
				});
			},

			searchAndAssignregistry_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "registry_alias1",
					listType: "docenti",
					idControl: "txt_publicazregistry_docenti_idreg_docenti",
					tagSearch: "registrydocentiview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_docenti",
					tableToFill: "publicazregistry_docenti"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('publicaz', 'default', metaPage_publicaz);

}());
