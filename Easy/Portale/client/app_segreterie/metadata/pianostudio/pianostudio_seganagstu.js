(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudio() {
		MetaPage.apply(this, ['pianostudio', 'seganagstu', true]);
        this.name = 'Piani di studio';
		this.defaultListType = 'seganagstu';
		//pageHeaderDeclaration
    }

    metaPage_pianostudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudio,
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
				this.setDenyNull("pianostudio","idpianostudio");
				this.setDenyNull("pianostudio","idiscrizione");
				appMeta.metaModel.insertFilter(this.getDataTable("pianostudiostatusdefaultview"), this.q.eq('pianostudiostatus_active', 'Si'));
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

	window.appMeta.addMetaPage('pianostudio', 'seganagstu', metaPage_pianostudio);

}());
