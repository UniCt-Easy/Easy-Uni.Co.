(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_edificio() {
		MetaPage.apply(this, ['edificio', 'seg_child', true]);
        this.name = 'Edifici';
		this.defaultListType = 'seg_child';
		//pageHeaderDeclaration
    }

    metaPage_edificio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_edificio,
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

	window.appMeta.addMetaPage('edificio', 'seg_child', metaPage_edificio);

}());
