(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_contrattokindperiodo() {
		MetaPage.apply(this, ['contrattokindperiodo', 'default', true]);
        this.name = 'Periodi di validità';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_contrattokindperiodo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_contrattokindperiodo,
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

	window.appMeta.addMetaPage('contrattokindperiodo', 'default', metaPage_contrattokindperiodo);

}());
