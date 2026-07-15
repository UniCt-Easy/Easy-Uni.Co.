(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandodsservizio() {
		MetaPage.apply(this, ['bandodsservizio', 'seg', true]);
        this.name = 'Servizi';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandodsservizio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandodsservizio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('tipologiastudente'), this.getDataTable('graduatoriaesiti'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('graduatoriaesiti'), this.getDataTable('graduatoriaesitipos'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.insertFilter(this.getDataTable("bandodsserviziokind"), this.q.eq('active', 'S'));
				$('#grid_tipologiastudente_seg').data('mdlconditionallookup', 'abbreviazione,S,Si;abbreviazione,N,No;immatricolato,S,Si;immatricolato,N,No;iscrittobmi,S,Si;iscrittobmi,N,No;passaggio,S,Si;passaggio,N,No;tri,S,Si;tri,N,No;');
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

	window.appMeta.addMetaPage('bandodsservizio', 'seg', metaPage_bandodsservizio);

}());
