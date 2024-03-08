(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriadesc() {
		MetaPage.apply(this, ['graduatoriadesc', 'default', true]);
        this.name = 'Parametri del calcolo';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_graduatoriadesc.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriadesc,
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

	window.appMeta.addMetaPage('graduatoriadesc', 'default', metaPage_graduatoriadesc);

}());
