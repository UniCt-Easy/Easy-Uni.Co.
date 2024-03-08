(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_validatori() {
		MetaPage.apply(this, ['validatori', 'default', false]);
        this.name = 'Validatori';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_validatori.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_validatori,
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

	window.appMeta.addMetaPage('validatori', 'default', metaPage_validatori);

}());
