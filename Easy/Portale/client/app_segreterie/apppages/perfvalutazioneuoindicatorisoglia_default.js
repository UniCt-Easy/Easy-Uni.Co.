(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfvalutazioneuoindicatorisoglia() {
		MetaPage.apply(this, ['perfvalutazioneuoindicatorisoglia', 'default', true]);
        this.name = 'Soglie';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneuoindicatorisoglia.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneuoindicatorisoglia,
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
				this.setDenyNull("perfvalutazioneuoindicatorisoglia","idperfvalutazioneuoindicatori");
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

	window.appMeta.addMetaPage('perfvalutazioneuoindicatorisoglia', 'default', metaPage_perfvalutazioneuoindicatorisoglia);

}());
