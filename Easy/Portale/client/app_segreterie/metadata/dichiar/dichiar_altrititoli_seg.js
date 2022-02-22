
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
		MetaPage.apply(this, ['dichiar', 'altrititoli_seg', false]);
        this.name = 'Altri titoli';
		this.defaultListType = 'altrititoli_seg';
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
					parentRow.extension = "altrititoli";
				if (!parentRow.iddichiarkind)
					parentRow.iddichiarkind = 2;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-dichiar_altrititoli_altrititoli_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["dichiar_altrititoli"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("dichiar_altrititoli");
					meta.setDefaults(dt);
					var defdichiar_altrititoli = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowaltrititoli) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defdichiar_altrititoli);
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

			//afterClear

			afterFill: function () {
				this.enableControl($('#dichiar_altrititoli_seg_protnumero'), false);
				this.enableControl($('#dichiar_altrititoli_seg_protanno'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
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
				var def = appMeta.Deferred("afterRowSelect-dichiar_altrititoli_altrititoli_seg");
				$('#dichiar_altrititoli_seg_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#dichiar_altrititoli_seg_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['dichiar_altrititoli'].rows.length)
						this.state.DS.tables['dichiar_altrititoli'].rows[0].idreg = r.idreg;
				//afterRowSelectin
				return def.resolve();
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
				if (!$('#dichiar_altrititoli_seg_idreg').val() && this.children.includes(grid.dataSourceName)) {
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
				var arrayTablesToProtocol = ['dichiar', 'dichiar_altrititoli'];
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

	window.appMeta.addMetaPage('dichiar', 'altrititoli_seg', metaPage_dichiar);

}());
