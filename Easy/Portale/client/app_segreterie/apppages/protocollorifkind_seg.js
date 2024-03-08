(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollorifkind() {
		MetaPage.apply(this, ['protocollorifkind', 'seg', false]);
        this.name = 'Tipo di documento di riferimento';
		this.defaultListType = 'seg';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_protocollorifkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollorifkind,
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

	window.appMeta.addMetaPage('protocollorifkind', 'seg', metaPage_protocollorifkind);

}());
