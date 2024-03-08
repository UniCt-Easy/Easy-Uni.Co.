(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_costoscontodefkind() {
		MetaPage.apply(this, ['costoscontodefkind', 'default', false]);
        this.name = 'Tipologia tra Costo, Sconto, Mora, indennizzo';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_costoscontodefkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodefkind,
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

	window.appMeta.addMetaPage('costoscontodefkind', 'default', metaPage_costoscontodefkind);

}());
