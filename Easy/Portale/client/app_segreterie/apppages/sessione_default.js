(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sessione() {
		MetaPage.apply(this, ['sessione', 'default', false]);
        this.name = 'Sessioni di esami';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sessione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sessione,
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

	window.appMeta.addMetaPage('sessione', 'default', metaPage_sessione);

}());
