(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_nation() {
		MetaPage.apply(this, ['geo_nation', 'seg', false]);
        this.name = 'Nazioni';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_geo_nation.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_geo_nation,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_nation'), this.getDataTable('geo_region'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_nation'), this.getDataTable('geo_region'));
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

	window.appMeta.addMetaPage('geo_nation', 'seg', metaPage_geo_nation);

}());
