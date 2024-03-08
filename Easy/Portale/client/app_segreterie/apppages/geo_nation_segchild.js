(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_geo_nation() {
		MetaPage.apply(this, ['geo_nation', 'segchild', true]);
        this.name = 'Nazioni';
		this.defaultListType = 'segchild';
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

	window.appMeta.addMetaPage('geo_nation', 'segchild', metaPage_geo_nation);

}());
