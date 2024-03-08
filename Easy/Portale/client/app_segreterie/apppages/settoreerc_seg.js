(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_settoreerc() {
		MetaPage.apply(this, ['settoreerc', 'seg', false]);
        this.name = 'Settori dell\'European Research Council';
		this.defaultListType = 'seg';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_settoreerc.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_settoreerc,
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

	window.appMeta.addMetaPage('settoreerc', 'seg', metaPage_settoreerc);

}());
