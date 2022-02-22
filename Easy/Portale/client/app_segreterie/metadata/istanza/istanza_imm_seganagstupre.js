
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'imm_seganagstupre', true]);
        this.name = 'Istanze di preimmatricolazione';
		this.defaultListType = 'imm_seganagstupre';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_istanza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanza,
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
				var def = appMeta.Deferred("afterGetFormData-istanza_imm_imm_seganagstupre");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__imm_seganagstupre_idcorsostudio());
				arraydef.push(this.manageistanza_imm__seganagstupre_idcorsostudio());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 13;
				if (!parentRow.idstatuskind)
					parentRow.idstatuskind = 1;
				parentRow.extension = "imm";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_imm_imm_seganagstupre");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_imm"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_imm");
					meta.setDefaults(dt);
					var defistanza_imm = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowimm) {
							currentRowimm.current.parttime = "N";
							currentRowimm.current.pre = "S";
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_imm);
				}

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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_imm'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_imm'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanzadichiar'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_imm_seganagstupre_protnumero'), false);
				this.enableControl($('#istanza_imm_seganagstupre_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_imm'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_imm'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanzadichiar'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_istanzadichiar_iddichiar").on("click", _.partial(this.searchAndAssigndichiar, self));
				$("#btn_add_istanzadichiar_iddichiar").prop("disabled", true);
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("didprogcurr"), true);
				appMeta.metaModel.lockRead(this.getDataTable("didprogcurr"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_imm_seganagstupre_iddidprog').val('');
						}
				}
				$('#istanza_imm_seganagstupre_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_imm_seganagstupre_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#istanza_imm_seganagstupre_aa').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_imm_seganagstupre_aa').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'didprogdefaultview' && r !== null)
					if (this.state.DS.tables['istanza_imm'].rows.length)
						this.state.DS.tables['istanza_imm'].rows[0].iddidprog = r.iddidprog;
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "didprogdefaultview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("didprogcurr"), false);
					var istanza_imm_seganagstupre_iddidprogcurrCtrl = $('#istanza_imm_seganagstupre_iddidprogcurr').data("customController");
					arraydef.push(istanza_imm_seganagstupre_iddidprogcurrCtrl.filteredPreFillCombo(window.jsDataQuery.eq("iddidprog", r ? r.iddidprog : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.iddidprogcurr)
								istanza_imm_seganagstupre_iddidprogcurrCtrl.fillControl(null, self.state.currentRow.iddidprogcurr);
							return true;
						})
);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			afterActivation: function () {
				var parentRow = this.state.currentRow;
				var self = this;
				//afterActivationin
				var arraydef = [];
				if (parentRow.iddidprog) {
					appMeta.metaModel.cachedTable(this.getDataTable("didprogcurr"), false);
					var istanza_imm_seganagstupre_iddidprogcurrCtrl = $('#istanza_imm_seganagstupre_iddidprogcurr').data("customController");
					arraydef.push(istanza_imm_seganagstupre_iddidprogcurrCtrl.filteredPreFillCombo(window.jsDataQuery.eq("iddidprog", parentRow.iddidprog), null, true));
				}
				//afterActivationAsincIn
				return $.when.apply($, arraydef);
			},

			rowSelected: function (dataRow) {
				$("#btn_add_istanzadichiar_iddichiar").prop("disabled", false);
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_istanzadichiar_iddichiar").prop("disabled", true);
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#istanza_imm_seganagstupre_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				if (!$('#istanza_imm_seganagstupre_iddidprog').val() && grid.dataSourceName === 'nullaosta') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			searchAndAssigndichiar: function (that) {
				return that.searchAndAssign({
					tableName: "dichiar",
					listType: "seg",
					idControl: "txt_istanzadichiar_iddichiar",
					tagSearch: "dichiarsegview.dropdown_title",
					columnNameText: "iddichiarkind",
					columnSource: "iddichiar",
					columnToFill: "iddichiar",
					tableToFill: "istanzadichiar"
				});
			},

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_imm'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['istanza_alias14', 'istanzadichiar', 'nullaosta'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			manageistanza__imm_seganagstupre_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__imm_seganagstupre_idcorsostudio");
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

			manageistanza_imm__seganagstupre_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza_imm__seganagstupre_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdefaultview.rows, function (row) {
					if (self.state.currentRow.iddidprog)
						return row.iddidprog === self.state.currentRow.iddidprog;
					else
						return null;
				});
				if (masterRow)
					this.state.DS.tables.istanza_imm.rows[0].idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'imm_seganagstupre', metaPage_istanza);

}());
