(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_valutazionekind() {
		MetaPage.apply(this, ['valutazionekind', 'default', false]);
        this.name = 'Tipologia di valutazione di una attività didattica';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_valutazionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_valutazionekind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#valutazionekind_default_idvalutazionekind'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

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

	window.appMeta.addMetaPage('valutazionekind', 'default', metaPage_valutazionekind);

}());
