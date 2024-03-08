(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_graduatoriaesitipos() {
		MetaPage.apply(this, ['graduatoriaesitipos', 'seg', true]);
        this.name = 'Esito';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_graduatoriaesitipos.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_graduatoriaesitipos,
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
				this.setDenyNull("graduatoriaesitipos","idreg_studenti");
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

			//buttons
        });

	window.appMeta.addMetaPage('graduatoriaesitipos', 'seg', metaPage_graduatoriaesitipos);

}());
