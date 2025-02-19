﻿(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_getcostididattica() {
		MetaPage.apply(this, ['getcostididattica', 'default', false]);
        this.name = 'Riepilogo dei costi degli affidamenti';
		this.defaultListType = 'default';
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canSave = false;
		this.canCancel = false;
		this.canShowLast = false;
		//pageHeaderDeclaration
    }

    metaPage_getcostididattica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_getcostididattica,
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
				
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#getcostididattica_default_idposition'), null);
				} else {
					this.helpForm.filter($('#getcostididattica_default_idposition'), this.q.eq('position_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#getcostididattica_default_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#getcostididattica_default_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-getcostididattica_default");
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

			afterClear: function () {
				//parte sincrona
				this.helpForm.filter($('#getcostididattica_default_idposition'), null);
				this.helpForm.filter($('#getcostididattica_default_idreg_docenti'), null);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			//afterFill

			afterLink: function () {
				var self = this;
				this.setDenyNull("getcostididattica","idcorsostudio");
				this.setDenyNull("getcostididattica","idsede");
				this.setDenyNull("getcostididattica","aa");
				this.setDenyNull("getcostididattica","iddidprog");
				this.setDenyNull("getcostididattica","iddidprogcurr");
				this.setDenyNull("getcostididattica","idaffidamento");
				this.setDenyNull("getcostididattica","idposition");
				appMeta.metaModel.insertFilter(this.getDataTable("affidamentokinddefaultview"), this.q.eq('affidamentokind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-getcostididattica_default");
				$('#getcostididattica_default_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#getcostididattica_default_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idcorsostudio);
				$('#getcostididattica_default_idsede').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#getcostididattica_default_idsede').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idsede);
				$('#getcostididattica_default_aa').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				$('#getcostididattica_default_aa').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.aa);
				if (t.name === "corsostudiodefaultview" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("idcorsostudio", r.idcorsostudio));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].idcorsostudio !== r.idcorsostudio) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#getcostididattica_default_iddidprog').val('');
						}
				}
				$('#getcostididattica_default_iddidprog').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#getcostididattica_default_iddidprog').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#getcostididattica_default_idcorsostudio').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				$('#getcostididattica_default_idcorsostudio').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprog);
				if (t.name === "didprogdefaultview" && r !== null) {
					this.state.DS.tables.didprogcurr.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.didprogcurr.rows.length)
						if (this.state.DS.tables.didprogcurr.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.didprogcurr.clear();
							$('#getcostididattica_default_iddidprogcurr').val('');
						}
				}
				$('#getcostididattica_default_iddidprogcurr').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprogcurr);
				$('#getcostididattica_default_iddidprogcurr').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprogcurr);
				$('#getcostididattica_default_iddidprog').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprogcurr);
				$('#getcostididattica_default_iddidprog').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.iddidprogcurr);
				$('#getcostididattica_default_idposition').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idposition);
				$('#getcostididattica_default_idposition').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idposition);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#getcostididattica_default_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studio');
				}
				if (!$('#getcostididattica_default_idsede').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Sede');
				}
				if (!$('#getcostididattica_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo AA erogata');
				}
				if (!$('#getcostididattica_default_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				if (!$('#getcostididattica_default_iddidprogcurr').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Curriculum');
				}
				if (!$('#getcostididattica_default_idposition').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ruolo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var self = this;
				this.getDataTable('corsostudiodefaultview').acceptChanges();
				this.getDataTable('sededefaultview').acceptChanges();
				this.getDataTable('annoaccademico').acceptChanges();
				this.getDataTable('didprogdefaultview').acceptChanges();
				this.getDataTable('didprogcurr').acceptChanges();
				this.getDataTable('insegndefaultview').acceptChanges();
				this.getDataTable('insegnintegdefaultview').acceptChanges();
				this.getDataTable('affidamentokinddefaultview').acceptChanges();
				this.getDataTable('positiondefaultview').acceptChanges();
				this.getDataTable('registrydocentiview').acceptChanges();
				//innerBeforePost
			},

			children: [''],
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

	window.appMeta.addMetaPage('getcostididattica', 'default', metaPage_getcostididattica);

}());
