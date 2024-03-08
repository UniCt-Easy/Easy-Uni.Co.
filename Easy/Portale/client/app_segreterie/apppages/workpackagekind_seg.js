(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_workpackagekind() {
		MetaPage.apply(this, ['workpackagekind', 'seg', true]);
        this.name = 'Workpackage';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_workpackagekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_workpackagekind,
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

	window.appMeta.addMetaPage('workpackagekind', 'seg', metaPage_workpackagekind);

}());
