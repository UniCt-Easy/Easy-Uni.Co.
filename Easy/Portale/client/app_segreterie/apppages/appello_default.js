(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_appello() {
		MetaPage.apply(this, ['appello', 'default', false]);
        this.name = 'Appelli';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_appello.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_appello,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData

			//beforeFill

			
			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.appello.defaults({ 'aa': this.getAAByDate(new Date()) });
				this.state.DS.tables.appello.defaults({ 'idappelloazionekind': 1 });
				this.state.DS.tables.appello.defaults({ 'idappellokind': 1 });
				this.state.DS.tables.appello.defaults({ 'idstudprenotkind': 1 });
				this.state.DS.tables.appello.defaults({ 'lavoratori': "N" });
				this.state.DS.tables.appello.defaults({ 'passaggio': "N" });
				this.state.DS.tables.appello.defaults({ 'prointermedia': "N" });
				this.state.DS.tables.appello.defaults({ 'publicato': "N" });
				appMeta.metaModel.insertFilter(this.getDataTable("appellokinddefaultview"), this.q.eq('appellokind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("appelloazionekinddefaultview"), this.q.eq('appelloazionekind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("studprenotkinddefaultview"), this.q.eq('studprenotkind_active', 'Si'));
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

			//afterPost

			afterClear: function () {
				//parte sincrona
				const annoCorrente = this.getAAByDate(new Date());
				$('#appello_default_aa').val(annoCorrente).trigger('change');

				//afterClearin
				
				//afterClearInAsyncBase
			},

			//buttons
        });

	window.appMeta.addMetaPage('appello', 'default', metaPage_appello);

}());
