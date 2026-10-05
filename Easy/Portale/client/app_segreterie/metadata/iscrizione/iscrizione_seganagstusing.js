(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'seganagstusing', true]);
        this.name = 'Iscrizioni a corsi singoli';
		this.defaultListType = 'seganagstusing';
		//pageHeaderDeclaration
    }

    metaPage_iscrizione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizione,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
								for (var i = 0; i < this.state.DS.tables.pianostudioattivform_alias1.rows.length; i++) {
				  var rowPianoStudio = this.state.DS.tables.pianostudioattivform_alias1.rows[i];
				  var rowSostenimento = this.state.DS.tables.sostenimento_alias1.rows.find(row => row.idattivform === rowPianoStudio.idattivform);
				  if (rowSostenimento) {
					rowPianoStudio.idsostenimento = rowSostenimento.idsostenimento;
				  }
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-iscrizione_seganagstusing");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$('#grid_sostenimento_alias1_seganagstusing').data('mdlconditionallookup', 'livello,A,A ;livello,B,B ;livello,C,C ;livello,D,D ;votolode,S,Si;votolode,N,No;');
				var grid_pianostudio_alias1_seganagstusingChildsTables = [
					{ tablename: 'pianostudioattivform_alias1', edittype: 'seganagstusing', columnlookup: 'idattivform', columncalc: '!pianostudioattivform_alias1'},
				];
				$('#grid_pianostudio_alias1_seganagstusing').data('childtables', grid_pianostudio_alias1_seganagstusingChildsTables);
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

	window.appMeta.addMetaPage('iscrizione', 'seganagstusing', metaPage_iscrizione);

}());
