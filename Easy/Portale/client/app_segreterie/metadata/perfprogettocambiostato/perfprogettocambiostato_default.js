(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettocambiostato() {
		MetaPage.apply(this, ['perfprogettocambiostato', 'default', false]);
        this.name = 'Cambi di stato dei progetti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettocambiostato.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettocambiostato,
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

	window.appMeta.addMetaPage('perfprogettocambiostato', 'default', metaPage_perfprogettocambiostato);

}());
