(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_region() {
		MetaPage.apply(this, ['geo_region', 'segchild', true]);
        this.name = 'Regioni';
		this.defaultListType = 'segchild';
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

	window.appMeta.addMetaPage('geo_region', 'segchild', metaPage_geo_region);

}());
