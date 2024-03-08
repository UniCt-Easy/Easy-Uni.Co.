(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_mutuazionecaratteristicaora() {
		MetaPage.apply(this, ['mutuazionecaratteristicaora', 'default', true]);
        this.name = 'Ore';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_mutuazionecaratteristicaora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_mutuazionecaratteristicaora,
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

	window.appMeta.addMetaPage('mutuazionecaratteristicaora', 'default', metaPage_mutuazionecaratteristicaora);

}());
