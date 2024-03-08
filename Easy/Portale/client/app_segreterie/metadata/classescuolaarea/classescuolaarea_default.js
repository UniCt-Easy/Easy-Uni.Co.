(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_classescuolaarea() {
		MetaPage.apply(this, ['classescuolaarea', 'default', false]);
        this.name = 'Area della scuola / classe di laurea';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_classescuolaarea.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_classescuolaarea,
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

	window.appMeta.addMetaPage('classescuolaarea', 'default', metaPage_classescuolaarea);

}());
