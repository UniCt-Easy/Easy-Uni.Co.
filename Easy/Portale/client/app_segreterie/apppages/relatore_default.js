(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_relatore() {
		MetaPage.apply(this, ['relatore', 'default', true]);
        this.name = 'Relatori';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_relatore.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_relatore,
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

	window.appMeta.addMetaPage('relatore', 'default', metaPage_relatore);

}());
