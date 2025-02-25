(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_classescuola() {
		MetaPage.apply(this, ['classescuola', 'default', false]);
        this.name = 'Scuole / Classi di laurea';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_classescuola.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_classescuola,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('classescuola'), this.getDataTable('classescuolacaratteristica'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('classescuola'), this.getDataTable('classescuolacaratteristica'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_classescuolacaratteristica_classe').data('mdlconditionallookup', 'obblig,S,Si;obblig,N,No;profess,S,Si;profess,N,No;');
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

	window.appMeta.addMetaPage('classescuola', 'default', metaPage_classescuola);

}());
