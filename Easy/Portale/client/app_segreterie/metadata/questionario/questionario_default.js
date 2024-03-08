(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_questionario() {
		MetaPage.apply(this, ['questionario', 'default', false]);
        this.name = 'Questionari';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_questionario.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_questionario,
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

	window.appMeta.addMetaPage('questionario', 'default', metaPage_questionario);

}());
