(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoattach() {
		MetaPage.apply(this, ['progettoattach', 'seg', true]);
        this.name = 'Allegati';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_progettoattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoattach,
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
				$("#GetTemplate").on("click", _.partial(this.fireGetTemplate, this));
				$("#GetTemplate").prop("disabled", true);
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
				$("#GetTemplate").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#GetTemplate").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			fireGetTemplate: function (that) {
},

			//buttons
        });

	window.appMeta.addMetaPage('progettoattach', 'seg', metaPage_progettoattach);

}());
