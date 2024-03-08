(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_questionariokind() {
		MetaPage.apply(this, ['questionariokind', 'default', false]);
        this.name = 'Tipologie di questionario';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_questionariokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_questionariokind,
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

	window.appMeta.addMetaPage('questionariokind', 'default', metaPage_questionariokind);

}());
