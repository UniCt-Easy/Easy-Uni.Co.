(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriaesiti() {
		MetaPage.apply(this, ['graduatoriaesiti', 'seg', true]);
        this.name = 'Graduatoria';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_graduatoriaesiti.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriaesiti,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('graduatoriaesiti', 'seg', metaPage_graduatoriaesiti);

}());
