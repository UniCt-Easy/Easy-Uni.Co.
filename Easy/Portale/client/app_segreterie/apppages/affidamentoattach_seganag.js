(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentoattach() {
		MetaPage.apply(this, ['affidamentoattach', 'seganag', true]);
        this.name = 'Allegati';
		this.defaultListType = 'seganag';
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

			//buttons
        });

	window.appMeta.addMetaPage('affidamentoattach', 'seganag', metaPage_affidamentoattach);

}());
