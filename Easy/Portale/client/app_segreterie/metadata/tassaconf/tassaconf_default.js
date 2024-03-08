(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaconf() {
		MetaPage.apply(this, ['tassaconf', 'default', false]);
        this.name = 'Definizione dei costi generici';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassaconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaconf,
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

	window.appMeta.addMetaPage('tassaconf', 'default', metaPage_tassaconf);

}());
