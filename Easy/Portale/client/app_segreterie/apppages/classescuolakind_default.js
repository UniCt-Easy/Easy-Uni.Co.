(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_classescuolakind() {
		MetaPage.apply(this, ['classescuolakind', 'default', false]);
        this.name = 'Tipologia della scuola / classe di laurea';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_classescuolakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_classescuolakind,
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

	window.appMeta.addMetaPage('classescuolakind', 'default', metaPage_classescuolakind);

}());
