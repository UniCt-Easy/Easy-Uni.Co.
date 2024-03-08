(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_lezione() {
		MetaPage.apply(this, ['lezione', 'rendicont', true]);
        this.name = 'Registro elettronico';
		this.defaultListType = 'rendicont';
		//pageHeaderDeclaration
    }

    metaPage_lezione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_lezione,
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
				
				if (self.isNullOrMinDate(parentRow.start))
					parentRow.start = new Date();
				if (self.isNullOrMinDate(parentRow.stop))
					parentRow.stop = new Date();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-lezione_rendicont");
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

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-lezione_rendicont");
				$('#lezione_rendicont_idcorsostudio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_idcorsostudio').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "corsostudiodefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("idcorsostudio", r.idcorsostudio));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].idcorsostudio !== r.idcorsostudio) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#lezione_rendicont_iddidprog').val('');
						}
				}
				$('#lezione_rendicont_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "didprogdefaultview" && r !== null) {
					this.state.DS.tables.didprogcurr.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.didprogcurr.rows.length)
						if (this.state.DS.tables.didprogcurr.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.didprogcurr.clear();
							$('#lezione_rendicont_iddidprogcurr').val('');
						}
				}
				$('#lezione_rendicont_iddidprogcurr').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_iddidprogcurr').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "didprogcurr" && r !== null) {
					this.state.DS.tables.didprogoridefaultview.staticFilter(window.jsDataQuery.eq("iddidprogcurr", r.iddidprogcurr));
					if (this.state.DS.tables.didprogoridefaultview.rows.length)
						if (this.state.DS.tables.didprogoridefaultview.rows[0].iddidprogcurr !== r.iddidprogcurr) {
							this.state.DS.tables.didprogoridefaultview.clear();
							$('#lezione_rendicont_iddidprogori').val('');
						}
				}
				$('#lezione_rendicont_iddidprogori').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_iddidprogori').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "didprogoridefaultview" && r !== null) {
					this.state.DS.tables.didprogannodefaultview.staticFilter(window.jsDataQuery.eq("iddidprogori", r.iddidprogori));
					if (this.state.DS.tables.didprogannodefaultview.rows.length)
						if (this.state.DS.tables.didprogannodefaultview.rows[0].iddidprogori !== r.iddidprogori) {
							this.state.DS.tables.didprogannodefaultview.clear();
							$('#lezione_rendicont_iddidproganno').val('');
						}
				}
				$('#lezione_rendicont_iddidproganno').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_iddidproganno').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "didprogannodefaultview" && r !== null) {
					this.state.DS.tables.didprogporzannodefaultview.staticFilter(window.jsDataQuery.eq("iddidproganno", r.iddidproganno));
					if (this.state.DS.tables.didprogporzannodefaultview.rows.length)
						if (this.state.DS.tables.didprogporzannodefaultview.rows[0].iddidproganno !== r.iddidproganno) {
							this.state.DS.tables.didprogporzannodefaultview.clear();
							$('#lezione_rendicont_iddidprogporzanno').val('');
						}
				}
				$('#lezione_rendicont_iddidprogporzanno').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_iddidprogporzanno').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "didprogporzannodefaultview" && r !== null) {
					this.state.DS.tables.attivformdefaultview.staticFilter(window.jsDataQuery.eq("iddidprogporzanno", r.iddidprogporzanno));
					if (this.state.DS.tables.attivformdefaultview.rows.length)
						if (this.state.DS.tables.attivformdefaultview.rows[0].iddidprogporzanno !== r.iddidprogporzanno) {
							this.state.DS.tables.attivformdefaultview.clear();
							$('#lezione_rendicont_idattivform').val('');
						}
				}
				$('#lezione_rendicont_idattivform').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_idattivform').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "attivformdefaultview" && r !== null) {
					this.state.DS.tables.canale.staticFilter(window.jsDataQuery.eq("idattivform", r.idattivform));
					if (this.state.DS.tables.canale.rows.length)
						if (this.state.DS.tables.canale.rows[0].idattivform !== r.idattivform) {
							this.state.DS.tables.canale.clear();
							$('#lezione_rendicont_idcanale').val('');
						}
				}
				$('#lezione_rendicont_idcanale').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_idcanale').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "canale" && r !== null) {
					this.state.DS.tables.affidamentosegview.staticFilter(window.jsDataQuery.eq("idcanale", r.idcanale));
					if (this.state.DS.tables.affidamentosegview.rows.length)
						if (this.state.DS.tables.affidamentosegview.rows[0].idcanale !== r.idcanale) {
							this.state.DS.tables.affidamentosegview.clear();
							$('#lezione_rendicont_idaffidamento').val('');
						}
				}
				$('#lezione_rendicont_idaffidamento').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#lezione_rendicont_idaffidamento').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#lezione_rendicont_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studi');
				}
				if (!$('#lezione_rendicont_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				if (!$('#lezione_rendicont_iddidprogcurr').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Curriculum');
				}
				if (!$('#lezione_rendicont_iddidprogori').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Orientamento');
				}
				if (!$('#lezione_rendicont_iddidproganno').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno di corso');
				}
				if (!$('#lezione_rendicont_iddidprogporzanno').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Porzione d\'anno');
				}
				if (!$('#lezione_rendicont_idattivform').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo attività formativa');
				}
				if (!$('#lezione_rendicont_idcanale').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Canale');
				}
				if (!$('#lezione_rendicont_idaffidamento').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Affidamento');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: ['rendicontlezionestud'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('lezione', 'rendicont', metaPage_lezione);

}());
