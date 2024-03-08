(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidante() {
		MetaPage.apply(this, ['convalidante', 'segistrein', true]);
        this.name = 'Convalidanti';
		this.defaultListType = 'segistrein';
		//pageHeaderDeclaration
    }

    metaPage_convalidante.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidante,
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

	window.appMeta.addMetaPage('convalidante', 'segistrein', metaPage_convalidante);

}());
