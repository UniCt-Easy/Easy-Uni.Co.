(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sede() {
		MetaPage.apply(this, ['sede', 'default', false]);
        this.name = 'Sedi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sede.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sede,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.idreg)
					parentRow.idreg = self.idreg_istituto;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-sede_default");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('sede'), this.getDataTable('sospensione'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('sede'), this.getDataTable('sospensione'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('sede', 'default', metaPage_sede);

}());
