(function () {
	
    var MetaPage = window.appMeta.Meta_APP_Page;

    function metaPage_tabella() {
		MetaPage.apply(this, ['tabella', 'tipoedit', Principale]);
        this.name = 'titolopagina';
		this.defaultListType = 'tipoedit';
		//pageHeaderDeclaration
    }

    metaPage_tabella.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tabella,
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

	window.appMeta.addMetaPage('tabella', 'tipoedit', metaPage_tabella);

}());
