(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_insegninteg() {
		MetaPage.apply(this, ['insegninteg', 'default', true]);
        this.name = 'Insegnamenti integrandi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_insegninteg.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_insegninteg,
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

	window.appMeta.addMetaPage('insegninteg', 'default', metaPage_insegninteg);

}());
