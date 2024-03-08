(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryprogfinbando() {
		MetaPage.apply(this, ['registryprogfinbando', 'seg', true]);
        this.name = 'Bandi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_registryprogfinbando.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registryprogfinbando,
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

	window.appMeta.addMetaPage('registryprogfinbando', 'seg', metaPage_registryprogfinbando);

}());
