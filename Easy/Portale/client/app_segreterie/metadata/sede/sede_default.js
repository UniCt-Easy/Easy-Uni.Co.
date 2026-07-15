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
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('sede'), this.getDataTable('edificio'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('sede'), this.getDataTable('edificio'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.sede.defaults({ 'idreg': self.idreg_istituto });
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('sede', 'default', metaPage_sede);

}());
