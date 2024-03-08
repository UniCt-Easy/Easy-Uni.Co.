(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_valutazionekind() {
		MetaPage.apply(this, ['valutazionekind', 'seg_child', false]);
        this.name = 'Tipologia di valutazione di una attività didattica';
		this.defaultListType = 'seg_child';
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

	window.appMeta.addMetaPage('valutazionekind', 'seg_child', metaPage_valutazionekind);

}());
