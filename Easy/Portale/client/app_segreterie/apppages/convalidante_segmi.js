(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidante() {
		MetaPage.apply(this, ['convalidante', 'segmi', true]);
        this.name = 'Convalidante';
		this.defaultListType = 'segmi';
		//pageHeaderDeclaration
    }

    metaPage_convalidante.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidante,
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

	window.appMeta.addMetaPage('convalidante', 'segmi', metaPage_convalidante);

}());
