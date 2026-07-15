(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaistanzaconf() {
		MetaPage.apply(this, ['tassaistanzaconf', 'default', false]);
        this.name = 'Definizione dei costi delle istanze';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassaistanzaconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaistanzaconf,
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
				appMeta.metaModel.insertFilter(this.getDataTable("istanzakinddefaultview"), this.q.eq('istanzakind_active', 'Si'));
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

	window.appMeta.addMetaPage('tassaistanzaconf', 'default', metaPage_tassaistanzaconf);

}());
