(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfindicatorekind() {
		MetaPage.apply(this, ['perfindicatorekind', 'default', false]);
        this.name = 'Tipi di indicatore';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_perfindicatorekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfindicatorekind,
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

	window.appMeta.addMetaPage('perfindicatorekind', 'default', metaPage_perfindicatorekind);

}());
