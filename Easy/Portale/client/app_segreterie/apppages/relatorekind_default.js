(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_relatorekind() {
		MetaPage.apply(this, ['relatorekind', 'default', false]);
        this.name = 'Tipologia di Relatori';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_relatorekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_relatorekind,
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

	window.appMeta.addMetaPage('relatorekind', 'default', metaPage_relatorekind);

}());
