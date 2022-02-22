
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
		MetaPage.apply(this, ['istanza', 'rimb_seg', false]);
        this.name = 'Istanze di rimborso';
		this.defaultListType = 'rimb_seg';
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

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (!parentRow.idistanzakind || parentRow.idistanzakind == 0)
					parentRow.idistanzakind = 16;
				parentRow.extension = "rimb";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#istanza_rimb_seg_idreg_studenti'), null);
				} else {
					this.helpForm.filter($('#istanza_rimb_seg_idreg_studenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_rimb_rimb_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_rimb"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_rimb");
					meta.setDefaults(dt);
					var defistanza_rimb = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowrimb) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_rimb);
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
				this.helpForm.filter($('#istanza_rimb_seg_idreg_studenti'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_rimb'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('creditoistanza_rimb'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_rimb_seg_protnumero'), false);
				this.enableControl($('#istanza_rimb_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_rimb'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('creditoistanza_rimb'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_creditoistanza_rimb_idcredito").on("click", _.partial(this.searchAndAssigncredito, self));
				$("#btn_add_creditoistanza_rimb_idcredito").prop("disabled", true);
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskind.staticFilter(window.jsDataQuery.eq('istanze', 'S'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_rimb_rimb_seg");
				$('#istanza_rimb_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_rimb_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_rimb'].rows.length)
						this.state.DS.tables['istanza_rimb'].rows[0].idreg = r.idreg;
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_rimb_seg_iddidprog').val('');
						}
				}
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.iscrizionedefaultview.rows.length)
						if (this.state.DS.tables.iscrizionedefaultview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.iscrizionedefaultview.clear();
							$('#istanza_rimb_seg_idiscrizione').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_creditoistanza_rimb_idcredito").prop("disabled", false);
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_creditoistanza_rimb_idcredito").prop("disabled", true);
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#istanza_rimb_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			searchAndAssigncredito: function (that) {
				return that.searchAndAssign({
					tableName: "credito",
					listType: "default",
					idControl: "txt_creditoistanza_rimb_idcredito",
					tagSearch: "credito.autorizzato",
					columnNameText: "autorizzato",
					columnSource: "idcredito",
					columnToFill: "idcredito",
					tableToFill: "creditoistanza_rimb"
				});
			},

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_rimb'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['creditoistanza_rimb'],
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

	window.appMeta.addMetaPage('istanza', 'rimb_seg', metaPage_istanza);

}());
