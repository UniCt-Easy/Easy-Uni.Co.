(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ateco() {
		MetaPage.apply(this, ['ateco', 'default', false]);
        this.name = 'Classificazione ATECO';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_ateco.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ateco,
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

	window.appMeta.addMetaPage('ateco', 'default', metaPage_ateco);

}());
