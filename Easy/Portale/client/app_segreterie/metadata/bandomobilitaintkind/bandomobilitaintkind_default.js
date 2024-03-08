(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomobilitaintkind() {
		MetaPage.apply(this, ['bandomobilitaintkind', 'default', false]);
        this.name = 'Tipologa del bando di mobilità internanzionale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_bandomobilitaintkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomobilitaintkind,
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

	window.appMeta.addMetaPage('bandomobilitaintkind', 'default', metaPage_bandomobilitaintkind);

}());
