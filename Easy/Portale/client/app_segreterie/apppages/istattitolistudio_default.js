(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istattitolistudio() {
		MetaPage.apply(this, ['istattitolistudio', 'default', false]);
        this.name = 'Titoli di studio ISTAT';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_istattitolistudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istattitolistudio,
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

	window.appMeta.addMetaPage('istattitolistudio', 'default', metaPage_istattitolistudio);

}());
