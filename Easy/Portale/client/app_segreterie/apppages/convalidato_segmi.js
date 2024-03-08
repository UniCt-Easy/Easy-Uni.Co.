(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidato() {
		MetaPage.apply(this, ['convalidato', 'segmi', true]);
        this.name = 'Convalidato';
		this.defaultListType = 'segmi';
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

	window.appMeta.addMetaPage('convalidato', 'segmi', metaPage_convalidato);

}());
