(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettostatus() {
		MetaPage.apply(this, ['perfprogettostatus', 'default', false]);
        this.name = 'Stati dei progetti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettostatus.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettostatus,
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

	window.appMeta.addMetaPage('perfprogettostatus', 'default', metaPage_perfprogettostatus);

}());
