(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaistanzaconf() {
		MetaPage.apply(this, ['tassaistanzaconf', 'default', false]);
        this.name = 'Definizione dei costi delle istanze';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassaistanzaconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaistanzaconf,
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

	window.appMeta.addMetaPage('tassaistanzaconf', 'default', metaPage_tassaistanzaconf);

}());
