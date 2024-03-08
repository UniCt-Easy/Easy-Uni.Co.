(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_publicazkind() {
		MetaPage.apply(this, ['publicazkind', 'default', false]);
        this.name = 'Tipologie di pubblicazione ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_publicazkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_publicazkind,
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

	window.appMeta.addMetaPage('publicazkind', 'default', metaPage_publicazkind);

}());
