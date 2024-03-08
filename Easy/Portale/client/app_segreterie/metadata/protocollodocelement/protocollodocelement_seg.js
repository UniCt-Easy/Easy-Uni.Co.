(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodocelement() {
		MetaPage.apply(this, ['protocollodocelement', 'seg', true]);
        this.name = 'Elemento del documento';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_protocollodocelement.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodocelement,
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

	window.appMeta.addMetaPage('protocollodocelement', 'seg', metaPage_protocollodocelement);

}());
