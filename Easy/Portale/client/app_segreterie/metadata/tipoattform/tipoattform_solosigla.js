(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tipoattform() {
		MetaPage.apply(this, ['tipoattform', 'solosigla', false]);
        this.name = 'Tipologia delle attività formative';
		this.defaultListType = 'solosigla';
		//pageHeaderDeclaration
    }

    metaPage_tipoattform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tipoattform,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('tipoattform', 'solosigla', metaPage_tipoattform);

}());
