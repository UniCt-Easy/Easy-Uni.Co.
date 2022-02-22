
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

    function metaPage_pratica() {
		MetaPage.apply(this, ['pratica', 'segstud', false]);
        this.name = 'Pratica di convalida/riconoscimento/dispensa';
		this.defaultListType = 'segstud';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_pratica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pratica,
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
				
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 3;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-pratica_segstud");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#pratica_segstud_protnumero'), false);
				this.enableControl($('#pratica_segstud_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('pratica'), this.getDataTable('convalida'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("iscrizioneseganagstuview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("iscrizioneseganagstuview"));
				appMeta.metaModel.cachedTable(this.getDataTable("iscrizioneseganagstuview_alias1"), true);
				appMeta.metaModel.lockRead(this.getDataTable("iscrizioneseganagstuview_alias1"));
				appMeta.metaModel.cachedTable(this.getDataTable("titolostudio"), true);
				appMeta.metaModel.lockRead(this.getDataTable("titolostudio"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#pratica_segstud_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idiscrizione').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idiscrizione').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idcorsostudio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idcorsostudio').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idistanza').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idistanza').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === "registrystudentiview" && r !== null) {
					this.state.DS.tables.dichiarsegview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.dichiarsegview.rows.length)
						if (this.state.DS.tables.dichiarsegview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.dichiarsegview.clear();
							$('#pratica_segstud_iddichiar').val('');
						}
				}
				$('#pratica_segstud_idistanzakind').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#pratica_segstud_idistanzakind').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("iscrizioneseganagstuview"), false);
					var pratica_segstud_idiscrizioneCtrl = $('#pratica_segstud_idiscrizione').data("customController");
					arraydef.push(pratica_segstud_idiscrizioneCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idiscrizione)
								pratica_segstud_idiscrizioneCtrl.fillControl(null, self.state.currentRow.idiscrizione);
							return true;
						})
);
				}
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("iscrizioneseganagstuview_alias1"), false);
					var pratica_segstud_idiscrizione_fromCtrl = $('#pratica_segstud_idiscrizione_from').data("customController");
					arraydef.push(pratica_segstud_idiscrizione_fromCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idiscrizione_from)
								pratica_segstud_idiscrizione_fromCtrl.fillControl(null, self.state.currentRow.idiscrizione_from);
							return true;
						})
);
				}
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("titolostudio"), false);
					var pratica_segstud_idtitolostudioCtrl = $('#pratica_segstud_idtitolostudio').data("customController");
					arraydef.push(pratica_segstud_idtitolostudioCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idtitolostudio)
								pratica_segstud_idtitolostudioCtrl.fillControl(null, self.state.currentRow.idtitolostudio);
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
				if (!$('#pratica_segstud_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				if (!$('#pratica_segstud_idiscrizione').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione');
				}
				if (!$('#pratica_segstud_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studio');
				}
				if (!$('#pratica_segstud_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Didattica programmata');
				}
				if (!$('#pratica_segstud_idistanza').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Istanza');
				}
				if (!$('#pratica_segstud_idistanzakind').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Tipologia di istanza');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			firebtnProtocol: function (that) {
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['convalida'],
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

	window.appMeta.addMetaPage('pratica', 'segstud', metaPage_pratica);

}());
