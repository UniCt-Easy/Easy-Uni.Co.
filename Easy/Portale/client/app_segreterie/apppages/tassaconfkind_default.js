(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaconfkind() {
		MetaPage.apply(this, ['tassaconfkind', 'default', false]);
        this.name = 'Definizione delle tasse generiche';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_tassaconfkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaconfkind,
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

	window.appMeta.addMetaPage('tassaconfkind', 'default', metaPage_tassaconfkind);

}());
