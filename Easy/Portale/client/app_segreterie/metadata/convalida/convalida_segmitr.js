(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalida() {
		MetaPage.apply(this, ['convalida', 'segmitr', true]);
        this.name = 'Convalida';
		this.defaultListType = 'segmitr';
		//pageHeaderDeclaration
    }

    metaPage_convalida.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalida,
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

	window.appMeta.addMetaPage('convalida', 'segmitr', metaPage_convalida);

}());
