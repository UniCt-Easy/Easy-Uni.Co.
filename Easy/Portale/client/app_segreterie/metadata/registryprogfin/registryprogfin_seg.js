(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_registryprogfin() {
		MetaPage.apply(this, ['registryprogfin', 'seg', true]);
        this.name = 'Programmi di finanziamento';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_registryprogfin.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registryprogfin,
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

	window.appMeta.addMetaPage('registryprogfin', 'seg', metaPage_registryprogfin);

}());
