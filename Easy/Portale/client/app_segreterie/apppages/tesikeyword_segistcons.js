(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tesikeyword() {
		MetaPage.apply(this, ['tesikeyword', 'segistcons', true]);
        this.name = 'Keywords';
		this.defaultListType = 'segistcons';
		//pageHeaderDeclaration
    }

    metaPage_tesikeyword.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tesikeyword,
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

	window.appMeta.addMetaPage('tesikeyword', 'segistcons', metaPage_tesikeyword);

}());
