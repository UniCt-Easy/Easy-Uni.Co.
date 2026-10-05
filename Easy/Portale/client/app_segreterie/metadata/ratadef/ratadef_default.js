(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_ratadef() {
		MetaPage.apply(this, ['ratadef', 'default', true]);
        this.name = 'Rate';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_ratadef.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_ratadef,
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
				appMeta.metaModel.insertFilter(this.getDataTable("ratakinddefaultview"), this.q.eq('ratakind_active', 'Si'));
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

	window.appMeta.addMetaPage('ratadef', 'default', metaPage_ratadef);

}());
