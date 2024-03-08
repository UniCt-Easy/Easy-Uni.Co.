(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_costoscontodefdettagliokind() {
		MetaPage.apply(this, ['costoscontodefdettagliokind', 'default', false]);
        this.name = 'Voci dei dettaglio debito';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_costoscontodefdettagliokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_costoscontodefdettagliokind,
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

	window.appMeta.addMetaPage('costoscontodefdettagliokind', 'default', metaPage_costoscontodefdettagliokind);

}());
