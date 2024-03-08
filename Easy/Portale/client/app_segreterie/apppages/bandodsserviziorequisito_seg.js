(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsserviziorequisito() {
		MetaPage.apply(this, ['bandodsserviziorequisito', 'seg', true]);
        this.name = 'Requisiti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsserviziorequisito.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsserviziorequisito,
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

	window.appMeta.addMetaPage('bandodsserviziorequisito', 'seg', metaPage_bandodsserviziorequisito);

}());
