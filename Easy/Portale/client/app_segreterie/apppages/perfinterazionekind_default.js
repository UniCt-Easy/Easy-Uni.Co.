(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfinterazionekind() {
		MetaPage.apply(this, ['perfinterazionekind', 'default', false]);
        this.name = 'Tipo di interazione';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_perfinterazionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfinterazionekind,
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

	window.appMeta.addMetaPage('perfinterazionekind', 'default', metaPage_perfinterazionekind);

}());
