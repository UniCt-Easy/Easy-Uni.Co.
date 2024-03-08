(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidakind() {
		MetaPage.apply(this, ['convalidakind', 'default', false]);
        this.name = 'Tipologie di convalida';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_convalidakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidakind,
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

	window.appMeta.addMetaPage('convalidakind', 'default', metaPage_convalidakind);

}());
