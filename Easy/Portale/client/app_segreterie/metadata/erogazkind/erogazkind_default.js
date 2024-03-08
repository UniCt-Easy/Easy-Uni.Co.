(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_erogazkind() {
		MetaPage.apply(this, ['erogazkind', 'default', false]);
        this.name = 'Tipologie di erogazione della didattica';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_erogazkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_erogazkind,
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

	window.appMeta.addMetaPage('erogazkind', 'default', metaPage_erogazkind);

}());
