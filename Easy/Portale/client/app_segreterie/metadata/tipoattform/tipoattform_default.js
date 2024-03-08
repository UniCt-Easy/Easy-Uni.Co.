(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tipoattform() {
		MetaPage.apply(this, ['tipoattform', 'default', false]);
        this.name = 'Tipologia delle attività formative';
		this.defaultListType = 'default';
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

	window.appMeta.addMetaPage('tipoattform', 'default', metaPage_tipoattform);

}());
