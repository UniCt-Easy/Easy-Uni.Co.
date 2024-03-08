(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_didprogdatepiano() {
		MetaPage.apply(this, ['didprogdatepiano', 'default', true]);
        this.name = 'Date di presentazione dei piani di studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_didprogdatepiano.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprogdatepiano,
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

	window.appMeta.addMetaPage('didprogdatepiano', 'default', metaPage_didprogdatepiano);

}());
