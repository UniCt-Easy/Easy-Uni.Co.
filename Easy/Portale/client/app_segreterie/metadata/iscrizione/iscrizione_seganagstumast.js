(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'seganagstumast', true]);
        this.name = 'Iscrizioni a master';
		this.defaultListType = 'seganagstumast';
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
				var def = appMeta.Deferred("afterGetFormData-iscrizione_seganagstumast");
				var arraydef = [];
				
				arraydef.push(this.manageiscrizione__seganagstumast_idcorsostudio());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizione_seganagstumast");
				$('#iscrizione_seganagstumast_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizione_seganagstumast_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_seganagstumast_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Master');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			children: ['sostenimento_alias3'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageiscrizione__seganagstumast_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageiscrizione__seganagstumast_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdotmasview.rows, function (row) {
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

	window.appMeta.addMetaPage('iscrizione', 'seganagstumast', metaPage_iscrizione);

}());
