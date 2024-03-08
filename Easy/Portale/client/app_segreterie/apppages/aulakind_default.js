(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_aulakind() {
		MetaPage.apply(this, ['aulakind', 'default', false]);
        this.name = 'Tipologie delle aule';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_aulakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_aulakind,
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

	window.appMeta.addMetaPage('aulakind', 'default', metaPage_aulakind);

}());
