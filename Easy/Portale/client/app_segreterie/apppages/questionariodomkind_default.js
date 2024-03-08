(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_questionariodomkind() {
		MetaPage.apply(this, ['questionariodomkind', 'default', false]);
        this.name = 'Tipologie di  domande del questionario';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_questionariodomkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_questionariodomkind,
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

	window.appMeta.addMetaPage('questionariodomkind', 'default', metaPage_questionariodomkind);

}());
