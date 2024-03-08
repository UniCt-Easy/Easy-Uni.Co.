(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprognumchiusokind() {
		MetaPage.apply(this, ['didprognumchiusokind', 'default', false]);
        this.name = 'Numero chiuso locale o nazionale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprognumchiusokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprognumchiusokind,
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

	window.appMeta.addMetaPage('didprognumchiusokind', 'default', metaPage_didprognumchiusokind);

}());
