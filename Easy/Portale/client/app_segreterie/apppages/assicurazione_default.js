(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_assicurazione() {
		MetaPage.apply(this, ['assicurazione', 'default', false]);
        this.name = 'Assicurazione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_assicurazione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_assicurazione,
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

	window.appMeta.addMetaPage('assicurazione', 'default', metaPage_assicurazione);

}());
