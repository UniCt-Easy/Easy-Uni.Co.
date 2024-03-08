(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_duratakind() {
		MetaPage.apply(this, ['duratakind', 'default', false]);
        this.name = 'Tipo di durata';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_duratakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_duratakind,
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

	window.appMeta.addMetaPage('duratakind', 'default', metaPage_duratakind);

}());
