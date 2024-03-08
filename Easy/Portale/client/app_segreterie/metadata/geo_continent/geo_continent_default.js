(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_continent() {
		MetaPage.apply(this, ['geo_continent', 'default', false]);
        this.name = 'Continenti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_geo_continent.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_geo_continent,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_continent'), this.getDataTable('geo_nation'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('geo_continent'), this.getDataTable('geo_nation'));
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

	window.appMeta.addMetaPage('geo_continent', 'default', metaPage_geo_continent);

}());
