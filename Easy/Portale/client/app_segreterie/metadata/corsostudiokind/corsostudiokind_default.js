(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_corsostudiokind() {
		MetaPage.apply(this, ['corsostudiokind', 'default', false]);
        this.name = 'Tipologie dei corsi di studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_corsostudiokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudiokind,
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

	window.appMeta.addMetaPage('corsostudiokind', 'default', metaPage_corsostudiokind);

}());
