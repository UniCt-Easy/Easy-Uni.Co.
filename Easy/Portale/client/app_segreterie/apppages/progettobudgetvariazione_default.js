(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettobudgetvariazione() {
		MetaPage.apply(this, ['progettobudgetvariazione', 'default', true]);
        this.name = 'Variazioni del budget';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettobudgetvariazione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettobudgetvariazione,
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

	window.appMeta.addMetaPage('progettobudgetvariazione', 'default', metaPage_progettobudgetvariazione);

}());
