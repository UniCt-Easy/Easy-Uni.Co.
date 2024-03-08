(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfruolo() {
		MetaPage.apply(this, ['perfruolo', 'default', false]);
        this.name = 'Tipologie ruoli';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfruolo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfruolo,
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
				this.state.DS.tables.perfruolo.defaults({ 'aggiorna': 'N' });
				this.state.DS.tables.perfruolo.defaults({ 'approva': 'N' });
				this.state.DS.tables.perfruolo.defaults({ 'crea': 'N' });
				this.state.DS.tables.perfruolo.defaults({ 'escluso': 'N' });
				this.state.DS.tables.perfruolo.defaults({ 'generascheda': 'S' });
				this.state.DS.tables.perfruolo.defaults({ 'leggi': 'S' });
				this.state.DS.tables.perfruolo.defaults({ 'oper': 'A' });
				this.state.DS.tables.perfruolo.defaults({ 'valuta': 'N' });
				$('#grid_perfruoloperfobiettivokind_default').data('mdlconditionallookup', '!idperfobiettivokind_perfobiettivokind_active,S,Si;!idperfobiettivokind_perfobiettivokind_active,N,No;');
				$('#grid_perfruolocontrattokind_default').data('mdlconditionallookup', '!idposition_position_active,S,Si;!idposition_position_active,N,No;!idposition_position_tipopersonale,D,Docente;!idposition_position_tipopersonale,P,Personale tecnico-amministrativo;!idposition_position_tipopersonale,R,Ricercatore;');
				$('#grid_perfruolomansionekind_default').data('mdlconditionallookup', '!idmansionekind_mansionekind_generascheda,S,Si;!idmansionekind_mansionekind_generascheda,N,No;');
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

	window.appMeta.addMetaPage('perfruolo', 'default', metaPage_perfruolo);

}());
