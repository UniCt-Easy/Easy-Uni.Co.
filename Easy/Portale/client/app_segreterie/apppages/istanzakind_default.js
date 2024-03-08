(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanzakind() {
		MetaPage.apply(this, ['istanzakind', 'default', false]);
        this.name = 'Tipologie di istanza';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_istanzakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanzakind,
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

	window.appMeta.addMetaPage('istanzakind', 'default', metaPage_istanzakind);

}());
