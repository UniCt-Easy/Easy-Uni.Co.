(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomiallegati() {
		MetaPage.apply(this, ['bandomiallegati', 'seg', true]);
        this.name = 'Allegati richiesti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomiallegati.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomiallegati,
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

	window.appMeta.addMetaPage('bandomiallegati', 'seg', metaPage_bandomiallegati);

}());
