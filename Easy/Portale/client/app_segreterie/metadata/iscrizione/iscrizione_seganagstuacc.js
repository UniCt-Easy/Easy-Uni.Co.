(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_iscrizione() {
		MetaPage.apply(this, ['iscrizione', 'seganagstuacc', true]);
        this.name = 'Iscrizioni alle prova d\'accesso';
		this.defaultListType = 'seganagstuacc';
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
				var def = appMeta.Deferred("afterGetFormData-iscrizione_seganagstuacc");
				var arraydef = [];
				
				arraydef.push(this.manageiscrizione__seganagstuacc_idcorsostudio());
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
				var def = appMeta.Deferred("afterRowSelect-iscrizione_seganagstuacc");
				$('#iscrizione_seganagstuacc_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizione_seganagstuacc_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#iscrizione_seganagstuacc_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Prova di accesso');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			children: ['sostenimento_alias2'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageiscrizione__seganagstuacc_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageiscrizione__seganagstuacc_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogingressoview.rows, function (row) {
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

	window.appMeta.addMetaPage('iscrizione', 'seganagstuacc', metaPage_iscrizione);

}());
