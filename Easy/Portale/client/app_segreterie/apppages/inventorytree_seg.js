(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_inventorytree() {
		MetaPage.apply(this, ['inventorytree', 'seg', false]);
        this.name = 'Classificazione inventariale';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_inventorytree.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_inventorytree,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.setCodeinvExtendedPropertiesLength();
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-inventorytree_seg");
				var arraydef = [];
				
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			setCodeinvExtendedPropertiesLength: function () {
				this.getDataTable("inventorytree").columns.codeinv.length = this.state.currentRow.codeinv.length;
			} ,

			//buttons
        });

	window.appMeta.addMetaPage('inventorytree', 'seg', metaPage_inventorytree);

}());
