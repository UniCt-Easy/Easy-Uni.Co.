(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_partnerkind() {
		MetaPage.apply(this, ['partnerkind', 'default', false]);
        this.name = 'Tipi di partnership';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_partnerkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_partnerkind,
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

	window.appMeta.addMetaPage('partnerkind', 'default', metaPage_partnerkind);

}());
