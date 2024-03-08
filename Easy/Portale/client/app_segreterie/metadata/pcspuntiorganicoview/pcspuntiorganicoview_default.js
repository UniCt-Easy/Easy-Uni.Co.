(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pcspuntiorganicoview() {
		MetaPage.apply(this, ['pcspuntiorganicoview', 'default', true]);
        this.name = 'Analisi punti organico e importi';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_pcspuntiorganicoview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pcspuntiorganicoview,
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
				this.setDenyNull("pcspuntiorganicoview","year");
				this.setDenyNull("pcspuntiorganicoview","position_title");
				this.setDenyNull("pcspuntiorganicoview","idanalisiannuale");
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

	window.appMeta.addMetaPage('pcspuntiorganicoview', 'default', metaPage_pcspuntiorganicoview);

}());
