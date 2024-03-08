(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfcomportamentosoglia() {
		MetaPage.apply(this, ['perfcomportamentosoglia', 'default', true]);
        this.name = 'Descrizione delle soglie per anno solare';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfcomportamentosoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfcomportamentosoglia,
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

	window.appMeta.addMetaPage('perfcomportamentosoglia', 'default', metaPage_perfcomportamentosoglia);

}());
