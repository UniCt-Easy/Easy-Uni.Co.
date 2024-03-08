(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sostenimentoesito() {
		MetaPage.apply(this, ['sostenimentoesito', 'default', false]);
        this.name = 'Esito';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_sostenimentoesito.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sostenimentoesito,
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

	window.appMeta.addMetaPage('sostenimentoesito', 'default', metaPage_sostenimentoesito);

}());
