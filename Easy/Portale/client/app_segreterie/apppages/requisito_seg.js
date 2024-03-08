(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_requisito() {
		MetaPage.apply(this, ['requisito', 'seg', false]);
        this.name = 'Definizione dei requisiti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_requisito.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_requisito,
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

	window.appMeta.addMetaPage('requisito', 'seg', metaPage_requisito);

}());
