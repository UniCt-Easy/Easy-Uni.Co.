(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfschedacambiostato() {
		MetaPage.apply(this, ['perfschedacambiostato', 'default', false]);
        this.name = 'Cambi di stato delle schede';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfschedacambiostato.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfschedacambiostato,
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

	window.appMeta.addMetaPage('perfschedacambiostato', 'default', metaPage_perfschedacambiostato);

}());
