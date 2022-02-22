
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

    function metaPage_didprog() {
		MetaPage.apply(this, ['didprog', 'default', false]);
        this.name = 'Didattiche programmate';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_didprog.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_didprog,
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
				
				if (!parentRow.freqobbl)
					parentRow.freqobbl = "S";
				if (!parentRow.iddidprognumchiusokind)
					parentRow.iddidprognumchiusokind = 1;
				if (!parentRow.iddidprogsuddannokind)
					parentRow.iddidprogsuddannokind = 5;
				if (!parentRow.iderogazkind)
					parentRow.iderogazkind = 1;
				if (!parentRow.idnation_lang)
					parentRow.idnation_lang = 1;
				if (!parentRow.idnation_langvis)
					parentRow.idnation_langvis = 1;
				if (!parentRow.idtitolokind)
					parentRow.idtitolokind = 1;
				if (!parentRow.immatoltreauth)
					parentRow.immatoltreauth = "S";
				if (!parentRow.preimmatoltreauth)
					parentRow.preimmatoltreauth = "S";
				$("#XXdidproggrupp").prop("disabled", !this.state.isEditState());
				$("#XXdidprogcurr").prop("disabled", !this.state.isEditState());
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#didprog_default_idareadidattica'), null);
				} else {
					this.helpForm.filter($('#didprog_default_idareadidattica'), this.q.eq('areadidattica_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#didprog_default_idreg_docenti'), null);
				} else {
					this.helpForm.filter($('#didprog_default_idreg_docenti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-didprog_default");
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
				this.helpForm.filter($('#didprog_default_idareadidattica'), null);
				this.helpForm.filter($('#didprog_default_idreg_docenti'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('canale'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformproped'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('canale'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformproped'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").on("click", _.partial(this.searchAndAssignclassconsorsuale, self));
				$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").prop("disabled", true);
				$("#btn_add_didprograppstud_idreg_studenti").on("click", _.partial(this.searchAndAssignregistry_studenti, self));
				$("#btn_add_didprograppstud_idreg_studenti").prop("disabled", true);
				$("#XXdidproggrupp").prop("disabled", true);
				$("#XXdidprogcurr").prop("disabled", true);
				$("#GenerateDidProgCurricula").on("click", _.partial(this.fireGenerateDidProgCurricula, this));
				$("#GenerateDidProgCurricula").prop("disabled", true);
				this.setDenyNull("didprog","aa");
				this.setDenyNull("didprog","iddidprogsuddannokind");
				var grid_attivform_defaultChildsTables = [
					{ tablename: 'canale', edittype: 'default', columnlookup: 'title', columncalc: '!canale'},
					{ tablename: 'attivformcaratteristica', edittype: 'default', columnlookup: 'cf', columncalc: '!attivformcaratteristica'},
				];
				$('#grid_attivform_default').data('childtables', grid_attivform_defaultChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-didprog_default");
				$('#didprog_default_idcorsostudio').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#didprog_default_idcorsostudio').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").prop("disabled", false);
				$("#btn_add_didprograppstud_idreg_studenti").prop("disabled", false);
				$("#GenerateDidProgCurricula").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				if ($("#XXdidproggrupp").length) {
					$("#XXdidproggrupp").prop("disabled", !currMetaPage.state.isEditState());
				}
				if ($("#XXdidprogcurr").length) {
					$("#XXdidprogcurr").prop("disabled", !currMetaPage.state.isEditState());
				}
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_didprogclassconsorsuale_idclassconsorsuale").prop("disabled", true);
					$("#btn_add_didprograppstud_idreg_studenti").prop("disabled", true);
					$("#GenerateDidProgCurricula").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			
			
			insertClick: function (that, grid) {
				if (this.state.isInsertState() && grid.dataSourceName === "attivform") {
					return this.showMessageOk("Devi prima salvare la didattica, e creare gli oggetti: curriculum etc...");
				} 
				if (!$('#didprog_default_idcorsostudio').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Corso di studi');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			beforePost: function () {
				var def = appMeta.Deferred("afterRowSelect-didprog_default");

				var r = this.state.currentRow;
				if (!r) return def.resolve();
				if (!r.getRow) return def.resolve();
				if (r.getRow().state !== jsDataSet.dataRowState.deleted) return def.resolve();

				// siamo nello stato deleted della riga principiale, forzo la cancellazione delle entità non subentità,che diepndono da questa didprog
				var self = this;
				var selBuilderArray = [];
				var tableArray = ["didprogcurr", "didprogori", "didproganno", "didprogporzanno", "didproggrupp", "didprograppstud", "didprogclassconsorsuale",
					"didprogcurrcaratteristica", "affidamento", "affidamentocaratteristica", "affidamentocaratteristicaora","affidamentoattach"];

				var idDidProgKey = "iddidprog";

				var iddidprog = this.state.currentRow[idDidProgKey];
				var filter = window.jsDataQuery.eq(idDidProgKey, iddidprog);

				// costruisco query
				_.forEach(tableArray, function (tname) {
					selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: self.state.DS.tables[tname] });
				});

				appMeta.getData.multiRunSelect(selBuilderArray)
					.then(function () {
						_.forEach(tableArray, function (tname) {
							var currTab = self.state.DS.tables[tname];
							_.forEach(currTab.rows, function (r) {
								// cancello solo le righe referenziate da questa didprog
								if (r[idDidProgKey] === iddidprog) r.getRow().del();
							});
						});

						def.resolve();
					});

				return def.promise();
			},

			searchAndAssignclassconsorsuale: function (that) {
				return that.searchAndAssign({
					tableName: "classconsorsuale",
					listType: "default",
					idControl: "txt_didprogclassconsorsuale_idclassconsorsuale",
					tagSearch: "classconsorsualedefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idclassconsorsuale",
					columnToFill: "idclassconsorsuale",
					tableToFill: "didprogclassconsorsuale"
				});
			},

			searchAndAssignregistry_studenti: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "studenti",
					idControl: "txt_didprograppstud_idreg_studenti",
					tagSearch: "registrystudentiview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_studenti",
					tableToFill: "didprograppstud"
				});
			},

						fireGenerateDidProgCurricula: function (that) {
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				appMeta.getData.launchCustomServerMethod("callSP", {
					spname: "GenerateDidProgCurricula",
					prm1: that.state.currentRow.iddidprog,
					prm2: appMeta.security.usr('userweb')
				}).then(function (res) {
					var msg = "OK. Sono stati generati i curriculum e le suddivisioni temporali.";
					if (res.err) {
						msg = "KO " + res.err;
					}
					var parentRow = that.state.currentRow;
					var filter = window.jsDataQuery.eq("iddidprog", parentRow.iddidprog);
					var selBuilderArray = [];
					var tableToRefresh = ['attivform'];
					_.forEach(tableToRefresh, function (tname) {
						selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: that.state.DS.tables[tname] });
					});
					appMeta.getData.multiRunSelect(selBuilderArray)
						.then(function () {
							that.freshForm(false, false)
								.then(function () {
									that.hideWaitingIndicator(waitingHandler);
									alert(msg);
								});
						});
				});
			},

			children: ['attivform', 'didprogclassconsorsuale', 'didprogcurr', 'didprogdatepiano', 'didproggrupp', 'didprograppstud', 'iscrizione'],
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

	window.appMeta.addMetaPage('didprog', 'default', metaPage_didprog);

}());
