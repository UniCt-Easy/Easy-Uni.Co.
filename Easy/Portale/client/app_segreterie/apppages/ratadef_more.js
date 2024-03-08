(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ratadef() {
		MetaPage.apply(this, ['ratadef', 'more', true]);
        this.name = 'Rate';
		this.defaultListType = 'more';
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

	window.appMeta.addMetaPage('ratadef', 'more', metaPage_ratadef);

}());
