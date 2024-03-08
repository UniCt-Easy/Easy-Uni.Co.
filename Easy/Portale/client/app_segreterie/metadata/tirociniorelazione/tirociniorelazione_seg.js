(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirociniorelazione() {
		MetaPage.apply(this, ['tirociniorelazione', 'seg', true]);
        this.name = 'Relazione conclusiva ';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tirociniorelazione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirociniorelazione,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//buttons
        });

	window.appMeta.addMetaPage('tirociniorelazione', 'seg', metaPage_tirociniorelazione);

}());
