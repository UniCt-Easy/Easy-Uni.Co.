(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_numerodip() {
		MetaPage.apply(this, ['numerodip', 'default', false]);
        this.name = 'Numero dipendenti';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_numerodip.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_numerodip,
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

	window.appMeta.addMetaPage('numerodip', 'default', metaPage_numerodip);

}());
