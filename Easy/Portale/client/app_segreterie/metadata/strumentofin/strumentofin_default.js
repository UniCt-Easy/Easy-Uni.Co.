(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_strumentofin() {
		MetaPage.apply(this, ['strumentofin', 'default', false]);
        this.name = 'Strumenti di finanziamento';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_strumentofin.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_strumentofin,
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

	window.appMeta.addMetaPage('strumentofin', 'default', metaPage_strumentofin);

}());
