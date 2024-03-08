(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettofinanziamento() {
		MetaPage.apply(this, ['progettofinanziamento', 'default', true]);
        this.name = 'Rimodulazioni del finanziamento';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettofinanziamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettofinanziamento,
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

	window.appMeta.addMetaPage('progettofinanziamento', 'default', metaPage_progettofinanziamento);

}());
