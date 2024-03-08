(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_appellokind() {
		MetaPage.apply(this, ['appellokind', 'default', false]);
        this.name = 'Tipologie di appello';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_appellokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_appellokind,
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

	window.appMeta.addMetaPage('appellokind', 'default', metaPage_appellokind);

}());
