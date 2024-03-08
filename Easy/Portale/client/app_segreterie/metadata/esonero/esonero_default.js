(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_esonero() {
		MetaPage.apply(this, ['esonero', 'default', false]);
        this.name = 'Definizione degli esoneri generici';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_esonero.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_esonero,
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

	window.appMeta.addMetaPage('esonero', 'default', metaPage_esonero);

}());
