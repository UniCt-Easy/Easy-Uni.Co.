(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_nace() {
		MetaPage.apply(this, ['nace', 'default', false]);
        this.name = 'Classificazione delle attività economiche nella Comunità Europea';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_nace.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_nace,
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

	window.appMeta.addMetaPage('nace', 'default', metaPage_nace);

}());
