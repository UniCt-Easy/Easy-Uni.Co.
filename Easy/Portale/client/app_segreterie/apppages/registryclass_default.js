(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryclass() {
		MetaPage.apply(this, ['registryclass', 'default', false]);
        this.name = 'Tipologia fiscale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_registryclass.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registryclass,
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

	window.appMeta.addMetaPage('registryclass', 'default', metaPage_registryclass);

}());
