(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassacsingconf() {
		MetaPage.apply(this, ['tassacsingconf', 'default', false]);
        this.name = 'Definizione dei costi dei corsi singoli';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassacsingconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassacsingconf,
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

	window.appMeta.addMetaPage('tassacsingconf', 'default', metaPage_tassacsingconf);

}());
