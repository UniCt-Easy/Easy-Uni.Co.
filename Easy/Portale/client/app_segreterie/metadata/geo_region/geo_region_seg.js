(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_region() {
		MetaPage.apply(this, ['geo_region', 'seg', false]);
        this.name = 'Regioni';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_geo_region.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_geo_region,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_region'), this.getDataTable('geo_country'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_region'), this.getDataTable('geo_country'));
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

	window.appMeta.addMetaPage('geo_region', 'seg', metaPage_geo_region);

}());
