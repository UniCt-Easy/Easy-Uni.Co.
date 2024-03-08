(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollodestinatario() {
		MetaPage.apply(this, ['protocollodestinatario', 'seg', true]);
        this.name = 'Destinatari';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_protocollodestinatario.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollodestinatario,
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

	window.appMeta.addMetaPage('protocollodestinatario', 'seg', metaPage_protocollodestinatario);

}());
