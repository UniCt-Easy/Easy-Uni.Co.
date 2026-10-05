(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sessione() {
		MetaPage.apply(this, ['sessione', 'default', false]);
        this.name = 'Sessioni di esami';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_sessione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sessione,
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
				appMeta.metaModel.insertFilter(this.getDataTable("appellokinddefaultview"), this.q.eq('appellokind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("sessionekinddefaultview"), this.q.eq('sessionekind_active', 'Si'));
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

	window.appMeta.addMetaPage('sessione', 'default', metaPage_sessione);

}());
