(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_settoreerc() {
		MetaPage.apply(this, ['settoreerc', 'segprog', false]);
        this.name = 'Settori dell\'European Research Council';
		this.defaultListType = 'segprog';
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

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('settoreerc', 'segprog', metaPage_settoreerc);

}());
