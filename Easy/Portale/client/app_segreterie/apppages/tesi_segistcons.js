(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tesi() {
		MetaPage.apply(this, ['tesi', 'segistcons', true]);
        this.name = 'Tesi';
		this.defaultListType = 'segistcons';
		//pageHeaderDeclaration
    }

    metaPage_tesi.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tesi,
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

	window.appMeta.addMetaPage('tesi', 'segistcons', metaPage_tesi);

}());
