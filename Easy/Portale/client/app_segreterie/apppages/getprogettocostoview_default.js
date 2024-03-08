(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_getprogettocostoview() {
		MetaPage.apply(this, ['getprogettocostoview', 'default', true]);
        this.name = 'Costi';
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

    metaPage_getprogettocostoview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_getprogettocostoview,
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
				this.setDenyNull("getprogettocostoview","idprogetto");
				this.setDenyNull("getprogettocostoview","idgetprogettocostoview");
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

	window.appMeta.addMetaPage('getprogettocostoview', 'default', metaPage_getprogettocostoview);

}());
