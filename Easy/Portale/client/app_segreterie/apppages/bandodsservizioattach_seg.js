(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsservizioattach() {
		MetaPage.apply(this, ['bandodsservizioattach', 'seg', true]);
        this.name = 'Allegati richiesti';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsservizioattach.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsservizioattach,
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

	window.appMeta.addMetaPage('bandodsservizioattach', 'seg', metaPage_bandodsservizioattach);

}());
