(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodoc() {
		MetaPage.apply(this, ['protocollodoc', 'seg', true]);
        this.name = 'Descrittore del documento';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_protocollodoc.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodoc,
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

	window.appMeta.addMetaPage('protocollodoc', 'seg', metaPage_protocollodoc);

}());
