(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_appelloazionekind() {
		MetaPage.apply(this, ['appelloazionekind', 'default', false]);
        this.name = 'Titologie di azione in appello';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_appelloazionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_appelloazionekind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('appelloazionekind', 'default', metaPage_appelloazionekind);

}());
