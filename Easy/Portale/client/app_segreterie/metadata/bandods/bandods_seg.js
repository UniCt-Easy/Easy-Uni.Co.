(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandods() {
		MetaPage.apply(this, ['bandods', 'seg', false]);
        this.name = 'Bandi di diritto allo studio';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandods.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandods,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
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

	window.appMeta.addMetaPage('bandods', 'seg', metaPage_bandods);

}());
