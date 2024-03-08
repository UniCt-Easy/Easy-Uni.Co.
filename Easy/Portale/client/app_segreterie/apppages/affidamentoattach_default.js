(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentoattach() {
		MetaPage.apply(this, ['affidamentoattach', 'default', true]);
        this.name = 'Allegati';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_affidamentoattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamentoattach,
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

	window.appMeta.addMetaPage('affidamentoattach', 'default', metaPage_affidamentoattach);

}());
