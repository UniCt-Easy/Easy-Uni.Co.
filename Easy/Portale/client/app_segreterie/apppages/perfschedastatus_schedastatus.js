(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfschedastatus() {
		MetaPage.apply(this, ['perfschedastatus', 'schedastatus', false]);
        this.name = 'Stati delle schede';
		this.defaultListType = 'schedastatus';
		//pageHeaderDeclaration
    }

    metaPage_perfschedastatus.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfschedastatus,
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

	window.appMeta.addMetaPage('perfschedastatus', 'schedastatus', metaPage_perfschedastatus);

}());
