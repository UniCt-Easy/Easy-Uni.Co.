(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pcsbilancio() {
		MetaPage.apply(this, ['pcsbilancio', 'default', true]);
        this.name = 'Bilancio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_pcsbilancio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pcsbilancio,
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

	window.appMeta.addMetaPage('pcsbilancio', 'default', metaPage_pcsbilancio);

}());
