
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
		MetaPage.apply(this, ['istanza', 'pas_seganagstu', true]);
        this.name = 'Istanze di passaggio corso o cambio ordinamento';
		this.defaultListType = 'pas_seganagstu';
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
				var def = appMeta.Deferred("afterGetFormData-istanza_pas_pas_seganagstu");
				var arraydef = [];
				
				arraydef.push(this.manageistanza__pas_seganagstu_iddidprog());
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
				if (!parentRow.extension)
					parentRow.extension = "pas";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 3;
				if (!parentRow.idstatuskind)
					parentRow.idstatuskind = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_pas_pas_seganagstu");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_pas"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_pas");
					meta.setDefaults(dt);
					var defistanza_pas = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowpas) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_pas);
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_pas'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_pas_seganagstu_protnumero'), false);
				this.enableControl($('#istanza_pas_seganagstu_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_pas'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('pratica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('nullaosta_alias4'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("istanza","iddidprog");
				this.setDenyNull("istanza_pas","idiscrizione_from");
				this.setDenyNull("istanza","idiscrizione");
				this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.and(window.jsDataQuery.eq("idreg", this.state.callerState.DS.tables.registry.rows[0].idreg),	window.jsDataQuery.isNotNull("iddidprog")));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

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
				if (!$('#istanza_pas_seganagstu_idiscrizione_from').val() && grid.dataSourceName === 'pratica') {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Iscrizione di partenza');
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
				var arrayTablesToProtocol = ['istanza', 'istanza_pas'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			manageistanza__pas_seganagstu_iddidprog: function () {
				var def = appMeta.Deferred("beforeFill-manageistanza__pas_seganagstu_iddidprog");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.annoaccademico.rows, function (row) {
					if (self.state.currentRow.aa)
						return row.aa === self.state.currentRow.aa;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.iddidprog = masterRow.iddidprog;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'pas_seganagstu', metaPage_istanza);

}());
