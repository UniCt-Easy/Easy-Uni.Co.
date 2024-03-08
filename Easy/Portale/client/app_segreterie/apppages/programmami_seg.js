(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_programmami() {
		MetaPage.apply(this, ['programmami', 'seg', false]);
        this.name = 'Programmi di cooperazione';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_programmami.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_programmami,
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

	window.appMeta.addMetaPage('programmami', 'seg', metaPage_programmami);

}());
