(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ofakind() {
		MetaPage.apply(this, ['ofakind', 'default', false]);
        this.name = 'Titologie di obblighi formativi aggiuntivi';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_ofakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ofakind,
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

			//buttons
        });

	window.appMeta.addMetaPage('ofakind', 'default', metaPage_ofakind);

}());
