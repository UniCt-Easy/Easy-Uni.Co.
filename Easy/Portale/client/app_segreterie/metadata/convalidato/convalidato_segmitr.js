(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidato() {
		MetaPage.apply(this, ['convalidato', 'segmitr', true]);
        this.name = 'Convalidato';
		this.defaultListType = 'segmitr';
		//pageHeaderDeclaration
    }

    metaPage_convalidato.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidato,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('convalidato', 'segmitr', metaPage_convalidato);

}());
