(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryreference() {
		MetaPage.apply(this, ['registryreference', 'persone', true]);
        this.name = 'Recapiti';
		this.defaultListType = 'persone';
		//pageHeaderDeclaration
    }

    metaPage_registryreference.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registryreference,
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

	window.appMeta.addMetaPage('registryreference', 'persone', metaPage_registryreference);

}());
