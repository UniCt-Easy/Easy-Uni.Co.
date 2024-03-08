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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('pianostudio'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('decadenza'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('pianostudio'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('decadenza'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizione_seganagstu");
				$('#iscrizione_seganagstu_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizione_seganagstu_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
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

			children: ['decadenza', 'iscrizioneanno', 'pianostudio', 'sostenimento'],
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
