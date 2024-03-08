(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriavar() {
		MetaPage.apply(this, ['graduatoriavar', 'default', false]);
        this.name = 'Variabili delle graduatorie';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_graduatoriavar.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriavar,
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

	window.appMeta.addMetaPage('graduatoriavar', 'default', metaPage_graduatoriavar);

}());
