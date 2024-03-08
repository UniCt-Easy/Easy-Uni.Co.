(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfobiettiviuosoglia() {
		MetaPage.apply(this, ['perfobiettiviuosoglia', 'default', true]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfobiettiviuosoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfobiettiviuosoglia,
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

	window.appMeta.addMetaPage('perfobiettiviuosoglia', 'default', metaPage_perfobiettiviuosoglia);

}());
