(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_currency() {
		MetaPage.apply(this, ['currency', 'default', false]);
        this.name = 'Valute';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_currency.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_currency,
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

	window.appMeta.addMetaPage('currency', 'default', metaPage_currency);

}());
