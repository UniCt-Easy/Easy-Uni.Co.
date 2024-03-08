(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodockind() {
		MetaPage.apply(this, ['protocollodockind', 'seg', false]);
        this.name = 'Tipo di documento protocollato';
		this.defaultListType = 'seg';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_protocollodockind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodockind,
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

	window.appMeta.addMetaPage('protocollodockind', 'seg', metaPage_protocollodockind);

}());
