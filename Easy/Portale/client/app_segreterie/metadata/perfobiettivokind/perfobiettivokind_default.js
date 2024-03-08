(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfobiettivokind() {
		MetaPage.apply(this, ['perfobiettivokind', 'default', false]);
        this.name = 'Tipologia obiettivo';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfobiettivokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfobiettivokind,
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

	window.appMeta.addMetaPage('perfobiettivokind', 'default', metaPage_perfobiettivokind);

}());
