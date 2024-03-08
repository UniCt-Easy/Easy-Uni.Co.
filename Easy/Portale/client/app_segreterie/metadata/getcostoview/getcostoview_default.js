(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_getcostoview() {
		MetaPage.apply(this, ['getcostoview', 'default', true]);
        this.name = 'Consuntivo';
		this.defaultListType = 'default';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canSave = false;
		this.canCancel = false;
		this.canCmdClose = false;
		this.canShowLast = false;
		//pageHeaderDeclaration
    }

    metaPage_getcostoview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_getcostoview,
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
				this.setDenyNull("getcostoview","idaccmotive");
				this.setDenyNull("getcostoview","idexp");
				this.setDenyNull("getcostoview","idupb");
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

	window.appMeta.addMetaPage('getcostoview', 'default', metaPage_getcostoview);

}());
