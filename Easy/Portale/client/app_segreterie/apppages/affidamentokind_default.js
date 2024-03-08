(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentokind() {
		MetaPage.apply(this, ['affidamentokind', 'default', false]);
        this.name = 'Tipologie di affidamento';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_affidamentokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamentokind,
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

	window.appMeta.addMetaPage('affidamentokind', 'default', metaPage_affidamentokind);

}());
