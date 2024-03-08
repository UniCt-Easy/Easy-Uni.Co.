(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_cefr() {
		MetaPage.apply(this, ['cefr', 'default', false]);
        this.name = 'Quadro europeo comune di riferimento per le lingue';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_cefr.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_cefr,
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

	window.appMeta.addMetaPage('cefr', 'default', metaPage_cefr);

}());
