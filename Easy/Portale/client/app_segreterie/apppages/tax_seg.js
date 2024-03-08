(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tax() {
		MetaPage.apply(this, ['tax', 'seg', false]);
        this.name = 'Tipi di ritenuta';
		this.defaultListType = 'seg';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_tax.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tax,
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

	window.appMeta.addMetaPage('tax', 'seg', metaPage_tax);

}());
