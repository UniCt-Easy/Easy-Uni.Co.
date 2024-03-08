(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_strutturakind() {
		MetaPage.apply(this, ['strutturakind', 'default', false]);
        this.name = 'Tipologia delle strutture';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_strutturakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_strutturakind,
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

	window.appMeta.addMetaPage('strutturakind', 'default', metaPage_strutturakind);

}());
