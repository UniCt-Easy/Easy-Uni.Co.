(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_publicazkeyword() {
		MetaPage.apply(this, ['publicazkeyword', 'default', true]);
        this.name = 'Keyword della pubblicazione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_publicazkeyword.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_publicazkeyword,
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

	window.appMeta.addMetaPage('publicazkeyword', 'default', metaPage_publicazkeyword);

}());
