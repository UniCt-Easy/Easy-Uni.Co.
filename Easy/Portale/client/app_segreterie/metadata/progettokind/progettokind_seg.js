(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettokind() {
		MetaPage.apply(this, ['progettokind', 'seg', false]);
        this.name = 'Modello/Template di progetto o attività';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettokind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettokind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettoattachkind'), this.getDataTable('progettoattachkindprogettostatuskind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotestokind'), this.getDataTable('progettotestokindprogettostatuskind'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettoattachkind'), this.getDataTable('progettoattachkindprogettostatuskind'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotestokind'), this.getDataTable('progettotestokindprogettostatuskind'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.state.DS.tables.progettokind.defaults({ 'active': 'S' });
				this.state.DS.tables.progettokind.defaults({ 'idcorsostudio': "N" });
				this.state.DS.tables.progettokind.defaults({ 'irap': 'S' });
				this.state.DS.tables.progettokind.defaults({ 'oredivisionecostostipendio': 1500 });
				this.state.DS.tables.progettokind.defaults({ 'stipendioannoprec': "N" });
				this.state.DS.tables.progettokind.defaults({ 'stipendiocomericavo': "N" });
				this.setDenyNull("progettokind","oredivisionecostostipendio");
				appMeta.metaModel.insertFilter(this.getDataTable("progettoactivitykinddefaultview"), this.q.eq('progettoactivitykind_active', 'Si'));
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

	window.appMeta.addMetaPage('progettokind', 'seg', metaPage_progettokind);

}());
