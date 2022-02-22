
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

    function metaPage_dichiar() {
		MetaPage.apply(this, ['dichiar', 'titolo_seg', false]);
        this.name = 'Dichiarazione titoli di studio';
		this.defaultListType = 'titolo_seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_dichiar.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_dichiar,
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
				
				if (self.isNullOrMinDate(parentRow.date))
					parentRow.date = new Date();
				if (!parentRow.extension)
					parentRow.extension = "titolo";
				if (!parentRow.iddichiarkind)
					parentRow.iddichiarkind = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-dichiar_titolo_titolo_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["dichiar_titolo"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("dichiar_titolo");
					meta.setDefaults(dt);
					var defdichiar_titolo = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowtitolo) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defdichiar_titolo);
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

			//afterClear

			afterFill: function () {
				this.enableControl($('#dichiar_titolo_seg_protnumero'), false);
				this.enableControl($('#dichiar_titolo_seg_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				appMeta.metaModel.cachedTable(this.getDataTable("titolostudiodocentiview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("titolostudiodocentiview"));
				//indico al framework che la tabella dichiarkind è cached
				var dichiarkindTable = this.getDataTable("dichiarkind");
				appMeta.metaModel.cachedTable(dichiarkindTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(dichiarkindTable, null, null));
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				$('#dichiar_titolo_seg_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#dichiar_titolo_seg_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['dichiar_titolo'].rows.length)
						this.state.DS.tables['dichiar_titolo'].rows[0].idreg = r.idreg;
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "registrystudentiview" && r !== null) {
					appMeta.metaModel.cachedTable(this.getDataTable("titolostudiodocentiview"), false);
					var dichiar_titolo_seg_idtitolostudioCtrl = $('#dichiar_titolo_seg_idtitolostudio').data("customController");
					arraydef.push(dichiar_titolo_seg_idtitolostudioCtrl.filteredPreFillCombo(window.jsDataQuery.eq("idreg", r ? r.idreg : null), null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow.idtitolostudio)
								dichiar_titolo_seg_idtitolostudioCtrl.fillControl(null, self.state.currentRow.idtitolostudio);
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
				if (!$('#dichiar_titolo_seg_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg;
				var idreg_destinazione = that.idreg_istituto;
				var dichiarkind = that.getDataTable('dichiarkind');
				var rowsDichiarkind = dichiarkind.select(that.q.eq('iddichiarkind', that.state.currentRow.iddichiarkind));
				var oggetto = (rowsDichiarkind.length ? ' ' + rowsDichiarkind[0].title : '') + ' del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.date);
				var idprotocollodockind = 1;
				var arrayTablesToProtocol = ['dichiar', 'dichiar_titolo'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.iddichiar;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
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

	window.appMeta.addMetaPage('dichiar', 'titolo_seg', metaPage_dichiar);

}());
