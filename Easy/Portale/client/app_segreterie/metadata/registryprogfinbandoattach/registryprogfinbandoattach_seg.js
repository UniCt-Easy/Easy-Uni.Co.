(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryprogfinbandoattach() {
		MetaPage.apply(this, ['registryprogfinbandoattach', 'seg', true]);
        this.name = 'Allegati';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_registryprogfinbandoattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registryprogfinbandoattach,
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

	window.appMeta.addMetaPage('registryprogfinbandoattach', 'seg', metaPage_registryprogfinbandoattach);

}());
