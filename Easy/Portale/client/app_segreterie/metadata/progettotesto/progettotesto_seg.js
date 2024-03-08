(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettotesto() {
		MetaPage.apply(this, ['progettotesto', 'seg', true]);
        this.name = 'Testi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettotesto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotesto,
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

	window.appMeta.addMetaPage('progettotesto', 'seg', metaPage_progettotesto);

}());
