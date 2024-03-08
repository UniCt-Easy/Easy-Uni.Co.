(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_changeskind() {
		MetaPage.apply(this, ['changeskind', 'default', false]);
        this.name = 'Tipo di cambiamenti';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_changeskind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_changeskind,
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

	window.appMeta.addMetaPage('changeskind', 'default', metaPage_changeskind);

}());
