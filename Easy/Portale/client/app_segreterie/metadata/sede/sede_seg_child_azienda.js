(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sede() {
		MetaPage.apply(this, ['sede', 'seg_child_azienda', true]);
        this.name = 'Sedi';
		this.defaultListType = 'seg_child_azienda';
		//pageHeaderDeclaration
    }

    metaPage_sede.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sede,
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

	window.appMeta.addMetaPage('sede', 'seg_child_azienda', metaPage_sede);

}());
