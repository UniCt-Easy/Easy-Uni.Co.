
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

    function metaPage_nullaosta() {
		MetaPage.apply(this, ['nullaosta', 'imm_seganagstupre', true]);
        this.name = 'Nullaosta';
		this.defaultListType = 'imm_seganagstupre';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_nullaosta.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_nullaosta,
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
				parentRow.extension = "imm";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-nullaosta_imm_imm_seganagstupre");
				var arraydef = [];
				
				var dt = this.state.DS.tables["nullaosta_imm"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("nullaosta_imm");
					meta.setDefaults(dt);
					var defnullaosta_imm = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowimm) {
							currentRowimm.current.parttime = "N";
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defnullaosta_imm);
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
				this.enableControl($('#nullaosta_imm_seganagstupre_protanno'), false);
				this.enableControl($('#nullaosta_imm_seganagstupre_protnumero'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.setDenyNull("nullaosta_imm","iddidprogcurr");
				this.setDenyNull("nullaosta_imm","iddidprogori");
				this.state.DS.tables.didprogcurr.staticFilter(window.jsDataQuery.eq("iddidprog", this.state.callerState.DS.tables.istanza.rows[0].iddidprog));
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


			//insertClick

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.idreg_istituto;
				var idreg_destinazione = that.state.currentRow.idreg; 
				
				var nullaosta_imm = that.getDataTable('nullaosta_imm');
				var rowsNullaosta_imm = nullaosta_imm.select(that.q.eq('idnullaosta', that.state.currentRow.idnullaosta));
				var oggetto = 'Nullaosta del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsNullaosta_imm.length ? ' all\'immatricolazione all\'anno di corso: ' + rowsNullaosta_imm[0].annoimm : '');
				var idprotocollodockind = 6;
				var arrayTablesToProtocol = ['nullaosta', 'nullaosta_imm'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idnullaosta;
				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			//buttons
        });

	window.appMeta.addMetaPage('nullaosta', 'imm_seganagstupre', metaPage_nullaosta);

}());
