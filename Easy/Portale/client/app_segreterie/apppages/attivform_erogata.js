
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

    function metaPage_attivform() {
		MetaPage.apply(this, ['attivform', 'erogata', true]);
        this.name = 'Attività formative';
		this.defaultListType = 'erogata';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_attivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivform,
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
				var def = appMeta.Deferred("afterGetFormData-attivform_erogata");
				var arraydef = [];
				
				arraydef.push(this.manageattivform_erogata_idsede());
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
				
				this.manageattivform_erogata_idsede();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-attivform_erogata");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('appelloattivform'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformvalutazionekind'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#attivform_erogata_idinsegn'), false);
				this.enableControl($('#attivform_erogata_idinsegninteg'), false);
				this.enableControl($('#attivform_erogata_obbform'), false);
				this.enableControl($('#attivform_erogata_obbform_en'), false);
				this.enableControl($('#attivform_erogata_tipovalutazP'), false);
				this.enableControl($('#attivform_erogata_tipovalutazI'), false);
				this.enableControl($('#attivform_erogata_sortcode'), false);
				this.enableControl($('#attivform_erogata_iddidproggrupp'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('appelloattivform'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformcaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('attivform'), this.getDataTable('attivformvalutazionekind'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_appelloattivform_idappello").on("click", _.partial(this.searchAndAssignappello, self));
				$("#btn_add_appelloattivform_idappello").prop("disabled", true);
				var grid_attivformcaratteristica_erogataChildsTables = [
					{ tablename: 'attivformcaratteristicaora', edittype: 'erogata', columnlookup: 'idorakind', columncalc: '!attivformcaratteristicaora'},
				];
				$('#grid_attivformcaratteristica_erogata').data('childtables', grid_attivformcaratteristica_erogataChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-attivform_erogata");
				if (t.name === "insegndefaultview" && r !== null) {
					this.state.DS.tables.insegnintegdefaultview.staticFilter(window.jsDataQuery.eq("idinsegn", r.idinsegn));
					if (this.state.DS.tables.insegnintegdefaultview.rows.length)
						if (this.state.DS.tables.insegnintegdefaultview.rows[0].idinsegn !== r.idinsegn) {
							this.state.DS.tables.insegnintegdefaultview.clear();
							$('#attivform_erogata_idinsegninteg').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_appelloattivform_idappello").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_appelloattivform_idappello").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignappello: function (that) {
				return that.searchAndAssign({
					tableName: "appello",
					listType: "erogata",
					idControl: "txt_appelloattivform_idappello",
					tagSearch: "appelloerogataview.dropdown_title",
					columnNameText: "description",
					columnSource: "idappello",
					columnToFill: "idappello",
					tableToFill: "appelloattivform"
				});
			},

			manageattivform_erogata_idsede: function () {
this.state.currentRow.idsede= this.state.callerState.currentRow.idsede
			},

			//buttons
        });

	window.appMeta.addMetaPage('attivform', 'erogata', metaPage_attivform);

}());
