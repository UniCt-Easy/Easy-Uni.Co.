
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

    function metaPage_corsostudio() {
		MetaPage.apply(this, ['corsostudio', 'ingresso', false]);
        this.name = 'Prove di ammissione';
		this.defaultListType = 'ingresso';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_corsostudio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_corsostudio,
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
				var def = appMeta.Deferred("afterGetFormData-corsostudio_ingresso");
				var arraydef = [];
				
				arraydef.push(this.managedidprog_ingresso_title());
				arraydef.push(this.managedidprog_ingresso_title_en());
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
				
				if (!parentRow.idcorsostudiokind)
					parentRow.idcorsostudiokind = 12;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-corsostudio_ingresso");
				var arraydef = [];
				
				var dtdidprog = this.state.DS.tables["didprog"];
				if (dtdidprog.rows.length === 0) {
					var metadidprog = appMeta.getMeta("didprog");
					metadidprog.setDefaults(dtdidprog);
					var defdidprog = metadidprog.getNewRow(parentRow.getRow(), dtdidprog, self.editType).then(
						function (currentRowdidprog) {
							currentRowdidprog.current.iddidprognumchiusokind = 1;
							currentRowdidprog.current.iddidprogsuddannokind = 5;
							currentRowdidprog.current.idnation_lang = 1;
							currentRowdidprog.current.idnation_langvis = 1;
							currentRowdidprog.current.idtitolokind = 1;
							currentRowdidprog.current.immatoltreauth = "S";
							currentRowdidprog.current.preimmatoltreauth = "S";
							//defaultdidprogObject
							return true;
						}
					);
					arraydef.push(defdidprog);
				}

				arraydef.push(this.managedidprog_ingresso_title());
				arraydef.push(this.managedidprog_ingresso_title_en());
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

			//afterFill

			afterLink: function () {
				var self = this;
				appMeta.metaModel.computeRowsAs(this.state.DS.tables.didprog, "ingresso", this.superClass.calculateFields);
				this.helpForm.addExtraEntity("didprog");
				$("#btn_add_didprogaccesso_iddidprog_acc").on("click", _.partial(this.searchAndAssigndidprog_alias2, self));
				$("#btn_add_didprogaccesso_iddidprog_acc").prop("disabled", true);
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar49').fullCalendar('rerenderEvents');
				});
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
				$("#btn_add_didprogaccesso_iddidprog_acc").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_didprogaccesso_iddidprog_acc").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssigndidprog_alias2: function (that) {
				return that.searchAndAssign({
					tableName: "didprog_alias2",
					listType: "default",
					idControl: "txt_didprogaccesso_iddidprog_acc",
					tagSearch: "didprogdefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "iddidprog",
					columnToFill: "iddidprog_acc",
					tableToFill: "didprogaccesso",
					parentRow: that.state.DS.tables.didprog.rows[0]
				});
			},

			managedidprog_ingresso_title: function () {
				var def = appMeta.Deferred("beforeFill-managedidprog_title");
				var self = this;
				if (this.state.DS.tables.didprog)
					if (this.state.DS.tables.didprog.rows[0])
						this.state.DS.tables.didprog.rows[0].title = self.state.currentRow.title;
				return def.resolve();
			},

			managedidprog_ingresso_title_en: function () {
				var def = appMeta.Deferred("beforeFill-managedidprog_title_en");
				var self = this;
				if (this.state.DS.tables.didprog)
					if (this.state.DS.tables.didprog.rows[0])
						this.state.DS.tables.didprog.rows[0].title_en = self.state.currentRow.title_en;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('corsostudio', 'ingresso', metaPage_corsostudio);

}());
