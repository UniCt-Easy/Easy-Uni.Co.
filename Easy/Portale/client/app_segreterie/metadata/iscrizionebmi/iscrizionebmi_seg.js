
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

    function metaPage_iscrizionebmi() {
		MetaPage.apply(this, ['iscrizionebmi', 'seg', true]);
        this.name = 'Iscrizioni ai bandi';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_iscrizionebmi.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_iscrizionebmi,
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
				
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-iscrizionebmi_seg");
				var arraydef = [];
				
				var dtcefrlanglevel = this.state.DS.tables["cefrlanglevel"];
				if (dtcefrlanglevel.rows.length === 0) {
					var metacefrlanglevel = appMeta.getMeta("cefrlanglevel");
					metacefrlanglevel.setDefaults(dtcefrlanglevel);
					var defcefrlanglevel = metacefrlanglevel.getNewRow(parentRow.getRow(), dtcefrlanglevel, self.editType).then(
						function (currentRowcefrlanglevel) {
							//defaultcefrlanglevelObject
							return true;
						}
					);
					arraydef.push(defcefrlanglevel);
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('convalida_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('cefrlanglevel_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizionebmi'), this.getDataTable('cefrlanglevel'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('convalida_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('cefrlanglevel_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizionebmi'), this.getDataTable('cefrlanglevel'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.cefrlanglevel, "default", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("cefrlanglevel");
				$("#btn_add_iscrizionebmiattach_idattach").on("click", _.partial(this.searchAndAssignattach, self));
				$("#btn_add_iscrizionebmiattach_idattach").prop("disabled", true);
				$("#btn_add_iscrizionebmirequisito_idiscrizionebmi").on("click", _.partial(this.searchAndAssigniscrizionebmi_alias1, self));
				$("#btn_add_iscrizionebmirequisito_idiscrizionebmi").prop("disabled", true);
				this.setDenyNull("iscrizionebmi","idiscrizione");
				this.state.DS.tables.iscrizionedefaultview.staticFilter(window.jsDataQuery.registrystudentiview);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-iscrizionebmi_seg");
				$('#iscrizionebmi_seg_idreg').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#iscrizionebmi_seg_idreg').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btn_add_iscrizionebmiattach_idattach").prop("disabled", false);
				$("#btn_add_iscrizionebmirequisito_idiscrizionebmi").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_iscrizionebmiattach_idattach").prop("disabled", true);
					$("#btn_add_iscrizionebmirequisito_idiscrizionebmi").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#iscrizionebmi_seg_idreg').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			searchAndAssignattach: function (that) {
				return that.searchAndAssign({
					tableName: "attach",
					listType: "default",
					idControl: "txt_iscrizionebmiattach_idattach",
					tagSearch: "attach.filename",
					columnNameText: "filename",
					columnSource: "idattach",
					columnToFill: "idattach",
					tableToFill: "iscrizionebmiattach"
				});
			},

			searchAndAssigniscrizionebmi_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "iscrizionebmi_alias1",
					listType: "default",
					idControl: "txt_iscrizionebmirequisito_idiscrizionebmi",
					tagSearch: "iscrizionebmi_alias1.idreg",
					columnNameText: "idreg",
					columnSource: "idiscrizionebmi",
					columnToFill: "idiscrizionebmi",
					tableToFill: "iscrizionebmirequisito"
				});
			},

			children: ['cefrlanglevel', 'iscrizionebmiattach', 'iscrizionebmirequisito', 'learningagrstud', 'learningagrtrainer', 'staffagrteaching'],
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

	window.appMeta.addMetaPage('iscrizionebmi', 'seg', metaPage_iscrizionebmi);

}());
