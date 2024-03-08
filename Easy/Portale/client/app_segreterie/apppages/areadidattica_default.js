(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_areadidattica() {
		MetaPage.apply(this, ['areadidattica', 'default', false]);
        this.name = 'Aeree didattiche';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_areadidattica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_areadidattica,
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

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('areadidattica', 'default', metaPage_areadidattica);

}());
