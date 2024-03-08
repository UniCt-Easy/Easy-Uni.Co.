(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_country() {
		MetaPage.apply(this, ['geo_country', 'segchild', true]);
        this.name = 'Province';
		this.defaultListType = 'segchild';
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

	window.appMeta.addMetaPage('geo_country', 'segchild', metaPage_geo_country);

}());
