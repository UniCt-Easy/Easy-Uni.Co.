(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_orakind() {
		MetaPage.apply(this, ['orakind', 'seg', false]);
        this.name = 'Tipologia di ore';
		this.defaultListType = 'seg';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_orakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_orakind,
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

	window.appMeta.addMetaPage('orakind', 'seg', metaPage_orakind);

}());
