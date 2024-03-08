(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoproroga() {
		MetaPage.apply(this, ['progettoproroga', 'seg', true]);
        this.name = 'Proroghe';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettoproroga.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoproroga,
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

	window.appMeta.addMetaPage('progettoproroga', 'seg', metaPage_progettoproroga);

}());
