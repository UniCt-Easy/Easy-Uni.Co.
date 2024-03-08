(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_studprenotkind() {
		MetaPage.apply(this, ['studprenotkind', 'default', false]);
        this.name = 'Tipologia di studente durante la prenotazione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_studprenotkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_studprenotkind,
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

	window.appMeta.addMetaPage('studprenotkind', 'default', metaPage_studprenotkind);

}());
