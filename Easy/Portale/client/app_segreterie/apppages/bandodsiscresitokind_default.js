(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsiscresitokind() {
		MetaPage.apply(this, ['bandodsiscresitokind', 'default', false]);
        this.name = 'Esito della partecipazione al bando per il diritto allo studio';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_bandodsiscresitokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsiscresitokind,
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

	window.appMeta.addMetaPage('bandodsiscresitokind', 'default', metaPage_bandodsiscresitokind);

}());
