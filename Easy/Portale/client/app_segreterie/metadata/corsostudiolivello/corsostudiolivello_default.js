(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_corsostudiolivello() {
		MetaPage.apply(this, ['corsostudiolivello', 'default', false]);
        this.name = 'Livelli dei corsi di studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_corsostudiolivello.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudiolivello,
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

	window.appMeta.addMetaPage('corsostudiolivello', 'default', metaPage_corsostudiolivello);

}());
