(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_appello() {
		MetaPage.apply(this, ['appello', 'default', false]);
        this.name = 'Appelli';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_appello.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_appello,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.appello.defaults({ 'idappelloazionekind': 1 });
				this.state.DS.tables.appello.defaults({ 'idappellokind': 1 });
				this.state.DS.tables.appello.defaults({ 'idstudprenotkind': 1 });
				this.state.DS.tables.appello.defaults({ 'lavoratori': "N" });
				this.state.DS.tables.appello.defaults({ 'passaggio': "N" });
				this.state.DS.tables.appello.defaults({ 'prointermedia': "N" });
				this.state.DS.tables.appello.defaults({ 'publicato': "N" });
				$("#btn_add_appelloattivform_idattivform").on("click", _.partial(this.searchAndAssignattivform, self));
				$("#btn_add_appelloattivform_idattivform").prop("disabled", true);
				$('#grid_appelloattivform_appello').data('mdlconditionallookup', '!aa_attivform_tipovalutaz,S,Si;!aa_attivform_tipovalutaz,N,No;');
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
				$("#btn_add_appelloattivform_idattivform").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_appelloattivform_idattivform").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignattivform: function (that) {
				return that.searchAndAssign({
					tableName: "attivform",
					listType: "appello",
					idControl: "txt_appelloattivform_idattivform",
					tagSearch: "attivformappelloview.dropdown_title",
					columnNameText: "title",
					columnSource: "idattivform",
					columnToFill: "idattivform",
					tableToFill: "appelloattivform"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('appello', 'default', metaPage_appello);

}());
