(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirociniostato() {
		MetaPage.apply(this, ['tirociniostato', 'default', false]);
        this.name = 'Stato dei tirocini';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_tirociniostato.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirociniostato,
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

	window.appMeta.addMetaPage('tirociniostato', 'default', metaPage_tirociniostato);

}());
