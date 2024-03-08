(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_dichiardisabilkind() {
		MetaPage.apply(this, ['dichiardisabilkind', 'default', false]);
        this.name = 'Tipologie di disabilità';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_dichiardisabilkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_dichiardisabilkind,
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

	window.appMeta.addMetaPage('dichiardisabilkind', 'default', metaPage_dichiardisabilkind);

}());
