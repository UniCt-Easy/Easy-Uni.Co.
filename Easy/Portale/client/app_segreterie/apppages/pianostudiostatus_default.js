(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudiostatus() {
		MetaPage.apply(this, ['pianostudiostatus', 'default', false]);
        this.name = 'Stati dei piani di studio';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_pianostudiostatus.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudiostatus,
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

	window.appMeta.addMetaPage('pianostudiostatus', 'default', metaPage_pianostudiostatus);

}());
