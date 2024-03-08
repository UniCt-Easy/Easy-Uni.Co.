(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontattivitaprogettoyear() {
		MetaPage.apply(this, ['rendicontattivitaprogettoyear', 'default', true]);
        this.name = 'Suddivisione delle ore dell\'attività per anno solare';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogettoyear.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogettoyear,
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

	window.appMeta.addMetaPage('rendicontattivitaprogettoyear', 'default', metaPage_rendicontattivitaprogettoyear);

}());
