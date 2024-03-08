(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_classconsorsuale() {
		MetaPage.apply(this, ['classconsorsuale', 'default', false]);
        this.name = 'Classi di concorso MIUR';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_classconsorsuale.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_classconsorsuale,
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
				$("#btn_add_didprogclassconsorsuale_iddidprog").on("click", _.partial(this.searchAndAssigndidprog, self));
				$("#btn_add_didprogclassconsorsuale_iddidprog").prop("disabled", true);
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
				$("#btn_add_didprogclassconsorsuale_iddidprog").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_didprogclassconsorsuale_iddidprog").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssigndidprog: function (that) {
				return that.searchAndAssign({
					tableName: "didprog",
					listType: "default",
					idControl: "txt_didprogclassconsorsuale_iddidprog",
					tagSearch: "didprogdefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "iddidprog",
					columnToFill: "iddidprog",
					tableToFill: "didprogclassconsorsuale"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('classconsorsuale', 'default', metaPage_classconsorsuale);

}());
