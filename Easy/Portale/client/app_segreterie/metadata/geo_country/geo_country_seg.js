(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_country() {
		MetaPage.apply(this, ['geo_country', 'seg', false]);
        this.name = 'Province';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_geo_country.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_geo_country,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_country'), this.getDataTable('geo_city'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_country'), this.getDataTable('geo_city'));
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

	window.appMeta.addMetaPage('geo_country', 'seg', metaPage_geo_country);

}());
