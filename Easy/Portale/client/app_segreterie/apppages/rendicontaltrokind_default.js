(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontaltrokind() {
		MetaPage.apply(this, ['rendicontaltrokind', 'default', false]);
        this.name = 'Tipologia delle attività da rendicontare oltre le lezioni ';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontaltrokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontaltrokind,
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

	window.appMeta.addMetaPage('rendicontaltrokind', 'default', metaPage_rendicontaltrokind);

}());
