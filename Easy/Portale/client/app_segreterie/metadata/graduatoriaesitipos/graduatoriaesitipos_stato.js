(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriaesitipos() {
		MetaPage.apply(this, ['graduatoriaesitipos', 'stato', true]);
        this.name = 'Esiti';
		this.defaultListType = 'stato';
		//pageHeaderDeclaration
    }

    metaPage_graduatoriaesitipos.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriaesitipos,
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

	window.appMeta.addMetaPage('graduatoriaesitipos', 'stato', metaPage_graduatoriaesitipos);

}());
