(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_city() {
		MetaPage.apply(this, ['geo_city', 'seg', false]);
        this.name = 'Comuni';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_geo_city.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_geo_city,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('geo_city', 'seg', metaPage_geo_city);

}());
