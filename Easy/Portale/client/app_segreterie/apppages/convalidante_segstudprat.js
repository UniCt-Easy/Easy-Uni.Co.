(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidante() {
		MetaPage.apply(this, ['convalidante', 'segstudprat', true]);
        this.name = 'Convalidanti';
		this.defaultListType = 'segstudprat';
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

			//buttons
        });

	window.appMeta.addMetaPage('convalidante', 'segstudprat', metaPage_convalidante);

}());
