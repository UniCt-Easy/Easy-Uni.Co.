(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istitutokind() {
		MetaPage.apply(this, ['istitutokind', 'default', false]);
        this.name = 'Tipologia di istituto';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_istitutokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istitutokind,
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

	window.appMeta.addMetaPage('istitutokind', 'default', metaPage_istitutokind);

}());
