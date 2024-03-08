(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pcscessazioniview() {
		MetaPage.apply(this, ['pcscessazioniview', 'default', true]);
        this.name = 'Cessazioni';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_pcscessazioniview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pcscessazioniview,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("pcscessazioniview","idpcscessazioniview");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('pcscessazioniview', 'default', metaPage_pcscessazioniview);

}());
