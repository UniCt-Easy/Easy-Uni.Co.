(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'seganagstu', true]);
        this.name = 'Iscrizioni a corsi di studio';
		this.defaultListType = 'seganagstu';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-iscrizione_seganagstu");
				var arraydef = [];
				
				arraydef.push(this.manageiscrizione__seganagstu_idcorsostudio());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#iscrizione_seganagstu_iddidprog'), true);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('decadenza'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('pianostudio'));
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('decadenza'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('pianostudio'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$('#grid_convalidatoview_default').data('mdlconditionallookup', 'votolode,S,Si;votolode,N,No;');
				$('#grid_sostenimento_seganagstu').data('mdlconditionallookup', 'livello,A,A ;livello,B,B ;livello,C,C ;livello,D,D ;votolode,S,Si;votolode,N,No;');
				var grid_pianostudio_seganagstuChildsTables = [
					{ tablename: 'pianostudioattivform', edittype: 'seganagstu', columnlookup: 'anno', columncalc: '!pianostudioattivform'},
				];
				$('#grid_pianostudio_seganagstu').data('childtables', grid_pianostudio_seganagstuChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizione_seganagstu");
				$('#iscrizione_seganagstu_iddidprog').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#iscrizione_seganagstu_iddidprog').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_seganagstu_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('convalidatoview').acceptChanges();
				//innerBeforePost
			},

			children: ['convalidatoview', 'decadenza', 'iscrizioneanno', 'pianostudio', 'sostenimento'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageiscrizione__seganagstu_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageiscrizione__seganagstu_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdefaultview.rows, function (row) {
					if (self.state.currentRow.iddidprog)
						return row.iddidprog === self.state.currentRow.iddidprog;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('iscrizione', 'seganagstu', metaPage_iscrizione);

}());
