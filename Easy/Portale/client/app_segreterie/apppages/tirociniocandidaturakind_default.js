(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirociniocandidaturakind() {
		MetaPage.apply(this, ['tirociniocandidaturakind', 'default', false]);
        this.name = 'Tipologia di candidatura ad un tirocinio';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_tirociniocandidaturakind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirociniocandidaturakind,
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

	window.appMeta.addMetaPage('tirociniocandidaturakind', 'default', metaPage_tirociniocandidaturakind);

}());
