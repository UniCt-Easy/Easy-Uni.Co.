(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_isced2013() {
		MetaPage.apply(this, ['isced2013', 'default', false]);
        this.name = 'International Standard Classification of Education (ISCED)';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_isced2013.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_isced2013,
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

	window.appMeta.addMetaPage('isced2013', 'default', metaPage_isced2013);

}());
