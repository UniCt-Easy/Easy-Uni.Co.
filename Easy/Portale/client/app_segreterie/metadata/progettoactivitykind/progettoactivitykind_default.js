(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoactivitykind() {
		MetaPage.apply(this, ['progettoactivitykind', 'default', false]);
        this.name = 'Tipo di attività o progetto';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_progettoactivitykind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoactivitykind,
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

	window.appMeta.addMetaPage('progettoactivitykind', 'default', metaPage_progettoactivitykind);

}());
