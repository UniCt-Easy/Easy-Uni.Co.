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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('classescuola'), this.getDataTable('classescuolacaratteristica'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('classescuola'), this.getDataTable('classescuolacaratteristica'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

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
