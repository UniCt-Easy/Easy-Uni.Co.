(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_accordoscambiomi() {
		MetaPage.apply(this, ['accordoscambiomi', 'seg', false]);
        this.name = 'Accordi bilaterali';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_accordoscambiomi.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_accordoscambiomi,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidettaz'), this.getDataTable('cefrlanglevel'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('accordoscambiomiporzanno'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('cefrlanglevel_alias1'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidettaz'), this.getDataTable('cefrlanglevel'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('accordoscambiomiporzanno'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('accordoscambiomidett'), this.getDataTable('cefrlanglevel_alias1'));
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

	window.appMeta.addMetaPage('accordoscambiomi', 'seg', metaPage_accordoscambiomi);

}());
