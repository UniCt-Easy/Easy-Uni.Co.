
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

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'aziende', false]);
        this.name = 'Enti e Aziende';
		this.defaultListType = 'aziende';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registry,
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
				
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "aziende";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_residence'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_residence'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_default_idnaturagiur'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_default_idnaturagiur'), this.q.eq('naturagiur_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_default_idnumerodip'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_default_idnumerodip'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_aziende_idcategory'), null);
				} else {
					this.helpForm.filter($('#registry_aziende_idcategory'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_aziende_aziende");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_aziende"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_aziende");
					meta.setDefaults(dt);
					var defregistry_aziende = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowaziende) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_aziende);
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
				this.helpForm.filter($('#registry_aziende_idregistryclass'), null);
				this.helpForm.filter($('#registry_aziende_residence'), null);
				this.helpForm.filter($('#registry_aziende_default_idnaturagiur'), null);
				this.helpForm.filter($('#registry_aziende_default_idnumerodip'), null);
				this.helpForm.filter($('#registry_aziende_idcategory'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('sede'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_ccnlregistry_aziende_idccnl").on("click", _.partial(this.searchAndAssignccnl, self));
				$("#btn_add_ccnlregistry_aziende_idccnl").prop("disabled", true);
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
				$("#btn_add_ccnlregistry_aziende_idccnl").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_ccnlregistry_aziende_idccnl").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignccnl: function (that) {
				return that.searchAndAssign({
					tableName: "ccnl",
					listType: "default",
					idControl: "txt_ccnlregistry_aziende_idccnl",
					tagSearch: "ccnldefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idccnl",
					columnToFill: "idccnl",
					tableToFill: "ccnlregistry_aziende"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'aziende', metaPage_registry);

}());
