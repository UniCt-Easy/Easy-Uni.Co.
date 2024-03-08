(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ratadef() {
		MetaPage.apply(this, ['ratadef', 'sconti', true]);
        this.name = 'Rate';
		this.defaultListType = 'sconti';
		//pageHeaderDeclaration
    }

    metaPage_ratadef.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ratadef,
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

	window.appMeta.addMetaPage('ratadef', 'sconti', metaPage_ratadef);

}());
