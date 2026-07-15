(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tassaiscrizioneconf() {
		MetaPage.apply(this, ['tassaiscrizioneconf', 'default', false]);
        this.name = 'Definizione delle tasse di iscrizione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_tassaiscrizioneconf.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tassaiscrizioneconf,
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
				this.state.DS.tables.tassaiscrizioneconf.defaults({ 'aamax': this.getAAByDate() });
				this.state.DS.tables.tassaiscrizioneconf.defaults({ 'aamin': this.getAAByDate() });
				this.state.DS.tables.tassaiscrizioneconf.defaults({ 'corsisingoli': 'N' });
				this.state.DS.tables.tassaiscrizioneconf.defaults({ 'idcorsostudiokind': 11 });
				this.state.DS.tables.tassaiscrizioneconf.defaults({ 'title': 'Tassa di iscrizione per ' });
				this.setDenyNull("tassaiscrizioneconf","idcostoscontodef");
				appMeta.metaModel.insertFilter(this.getDataTable("corsostudiokinddefaultview"), this.q.eq('corsostudiokind_active', 'Si'));
				appMeta.metaModel.insertFilter(this.getDataTable("strutturadefaultview"), this.q.eq('struttura_active', 'Si'));
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

	window.appMeta.addMetaPage('tassaiscrizioneconf', 'default', metaPage_tassaiscrizioneconf);

}());
