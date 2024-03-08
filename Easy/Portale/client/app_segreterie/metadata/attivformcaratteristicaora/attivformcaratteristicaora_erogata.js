(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_attivformcaratteristicaora() {
		MetaPage.apply(this, ['attivformcaratteristicaora', 'erogata', true]);
        this.name = 'Ore';
		this.defaultListType = 'erogata';
		//pageHeaderDeclaration
    }

    metaPage_attivformcaratteristicaora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivformcaratteristicaora,
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

	window.appMeta.addMetaPage('attivformcaratteristicaora', 'erogata', metaPage_attivformcaratteristicaora);

}());
