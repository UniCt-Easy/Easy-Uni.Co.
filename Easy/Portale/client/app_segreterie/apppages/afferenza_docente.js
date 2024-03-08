(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_afferenza() {
		MetaPage.apply(this, ['afferenza', 'docente', true]);
        this.name = 'Afferenza alle strutture';
		this.defaultListType = 'docente';
		//pageHeaderDeclaration
    }

    metaPage_afferenza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_afferenza,
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

	window.appMeta.addMetaPage('afferenza', 'docente', metaPage_afferenza);

}());
