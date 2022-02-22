
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
		MetaPage.apply(this, ['istanza', 'rein_seg', false]);
        this.name = 'Istanza di reintegro';
		this.defaultListType = 'rein_seg';
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
				if (!parentRow.extension)
					parentRow.extension = "rein";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 2;
				if (!parentRow.idstatuskind)
					parentRow.idstatuskind = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_rein_rein_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_rein"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_rein");
					meta.setDefaults(dt);
					var defistanza_rein = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowrein) {
							currentRowrein.current.idistanzakind = 2;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_rein);
				}

				//beforeFillInside

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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_rein'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_rein_seg_protnumero'), false);
				this.enableControl($('#istanza_rein_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_rein'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("istanza","idcorsostudio");
				this.setDenyNull("istanza","idiscrizione");
				this.setDenyNull("istanza","iddidprog");
				appMeta.metaModel.cachedTable(this.getDataTable("iscrizionedefaultview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("iscrizionedefaultview"));
				this.state.DS.tables.statuskind.staticFilter(window.jsDataQuery.eq('istanze', 'S'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#istanza_rein_seg_idcorsostudio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_rein_seg_idcorsostudio').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'corsostudiodefaultview' && r !== null)
					if (this.state.DS.tables['istanza_rein'].rows.length)
						this.state.DS.tables['istanza_rein'].rows[0].idcorsostudio = r.idcorsostudio;
				$('#istanza_rein_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_rein_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_rein'].rows.length)
						this.state.DS.tables['istanza_rein'].rows[0].idreg = r.idreg;
				$('#istanza_rein_seg_idiscrizione').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_rein_seg_idiscrizione').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'iscrizionedefaultview' && r !== null)
					if (this.state.DS.tables['istanza_rein'].rows.length)
						this.state.DS.tables['istanza_rein'].rows[0].idiscrizione = r.idiscrizione;
				if (t.name === "annoaccademico" && r !== null) {
					this.state.DS.tables.didprogdefaultview.staticFilter(window.jsDataQuery.eq("aa", r.aa));
					if (this.state.DS.tables.didprogdefaultview.rows.length)
						if (this.state.DS.tables.didprogdefaultview.rows[0].aa !== r.aa) {
							this.state.DS.tables.didprogdefaultview.clear();
							$('#istanza_rein_seg_iddidprog').val('');
						}
				}
				$('#istanza_rein_seg_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_rein_seg_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#istanza_rein_seg_aa').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_rein_seg_aa').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'didprogdefaultview' && r !== null)
					if (this.state.DS.tables['istanza_rein'].rows.length)
						this.state.DS.tables['istanza_rein'].rows[0].iddidprog = r.iddidprog;
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.iscrizionedefaultview_alias1.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.iscrizionedefaultview_alias1.rows.length)
						if (this.state.DS.tables.iscrizionedefaultview_alias1.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.iscrizionedefaultview_alias1.clear();
							$('#istanza_rein_seg_idiscrizione_from').val('');
						}
				}
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("iscrizionedefaultview"), false);
					var istanza_rein_seg_idiscrizioneCtrl = $('#istanza_rein_seg_idiscrizione').data("customController");
					arraydef.push(istanza_rein_seg_idiscrizioneCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idiscrizione)
								istanza_rein_seg_idiscrizioneCtrl.fillControl(null, self.state.currentRow.idiscrizione);
							return true;
						})
);
				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#istanza_rein_seg_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studi');
				}
				if (!$('#istanza_rein_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#istanza_rein_seg_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				if (!$('#istanza_rein_seg_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_rein'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['diniego_alias3', 'nullaosta_alias4', 'pratica'],
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

	window.appMeta.addMetaPage('istanza', 'rein_seg', metaPage_istanza);

}());
