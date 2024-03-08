(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tirocinioinvioazienda() {
		MetaPage.apply(this, ['tirocinioinvioazienda', 'seg', true]);
        this.name = 'Invii all’azienda o ente';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tirocinioinvioazienda.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tirocinioinvioazienda,
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

	window.appMeta.addMetaPage('tirocinioinvioazienda', 'seg', metaPage_tirocinioinvioazienda);

}());
