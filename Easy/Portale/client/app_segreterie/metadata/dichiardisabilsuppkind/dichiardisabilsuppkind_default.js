(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_dichiardisabilsuppkind() {
		MetaPage.apply(this, ['dichiardisabilsuppkind', 'default', false]);
        this.name = 'Tipologie dichiarazioni disabilita';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_dichiardisabilsuppkind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_dichiardisabilsuppkind,
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

	window.appMeta.addMetaPage('dichiardisabilsuppkind', 'default', metaPage_dichiardisabilsuppkind);

}());
