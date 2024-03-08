(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryreference() {
		MetaPage.apply(this, ['registryreference', 'seg', true]);
        this.name = 'Recapiti';
		this.defaultListType = 'seg';
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

	window.appMeta.addMetaPage('registryreference', 'seg', metaPage_registryreference);

}());
