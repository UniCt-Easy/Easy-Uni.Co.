(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsserviziodatepres() {
		MetaPage.apply(this, ['bandodsserviziodatepres', 'seg', true]);
        this.name = 'Date di presentazione delle domande';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsserviziodatepres.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsserviziodatepres,
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

	window.appMeta.addMetaPage('bandodsserviziodatepres', 'seg', metaPage_bandodsserviziodatepres);

}());
