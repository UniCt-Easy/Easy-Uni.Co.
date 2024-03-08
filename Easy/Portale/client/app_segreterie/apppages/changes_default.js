(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_changes() {
		MetaPage.apply(this, ['changes', 'default', false]);
        this.name = 'Cambiamento per learning agreement';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_changes.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_changes,
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

	window.appMeta.addMetaPage('changes', 'default', metaPage_changes);

}());
