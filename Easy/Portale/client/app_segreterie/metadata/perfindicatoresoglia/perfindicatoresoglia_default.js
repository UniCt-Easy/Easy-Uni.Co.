(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfindicatoresoglia() {
		MetaPage.apply(this, ['perfindicatoresoglia', 'default', true]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfindicatoresoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfindicatoresoglia,
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

	window.appMeta.addMetaPage('perfindicatoresoglia', 'default', metaPage_perfindicatoresoglia);

}());
