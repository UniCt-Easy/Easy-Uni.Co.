(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoudrmembrokind() {
		MetaPage.apply(this, ['progettoudrmembrokind', 'default', false]);
        this.name = 'Tipologia di membro delle unità di personale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_progettoudrmembrokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoudrmembrokind,
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

	window.appMeta.addMetaPage('progettoudrmembrokind', 'default', metaPage_progettoudrmembrokind);

}());
