(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettocostobudgetview() {
		MetaPage.apply(this, ['perfprogettocostobudgetview', 'default', true]);
        this.name = 'Variazioni del budget';
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

    metaPage_perfprogettocostobudgetview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettocostobudgetview,
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
				this.setDenyNull("perfprogettocostobudgetview","nvar");
				this.setDenyNull("perfprogettocostobudgetview","rownum");
				this.setDenyNull("perfprogettocostobudgetview","yvar");
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

	window.appMeta.addMetaPage('perfprogettocostobudgetview', 'default', metaPage_perfprogettocostobudgetview);

}());
