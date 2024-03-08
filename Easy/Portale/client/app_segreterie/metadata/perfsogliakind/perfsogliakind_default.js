(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfsogliakind() {
		MetaPage.apply(this, ['perfsogliakind', 'default', false]);
        this.name = 'Tipi di soglie';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_perfsogliakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfsogliakind,
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

	window.appMeta.addMetaPage('perfsogliakind', 'default', metaPage_perfsogliakind);

}());
