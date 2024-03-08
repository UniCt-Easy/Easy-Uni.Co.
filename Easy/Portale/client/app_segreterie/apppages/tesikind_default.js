(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tesikind() {
		MetaPage.apply(this, ['tesikind', 'default', false]);
        this.name = 'Tipologia di Tesi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tesikind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tesikind,
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

	window.appMeta.addMetaPage('tesikind', 'default', metaPage_tesikind);

}());
