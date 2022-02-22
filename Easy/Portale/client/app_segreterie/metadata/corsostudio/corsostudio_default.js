
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
		MetaPage.apply(this, ['corsostudio', 'default', false]);
        this.name = 'Corsi di studio';
		this.defaultListType = 'default';
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

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('corsostudio'), this.getDataTable('corsostudiocaratteristica'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('corsostudio'), this.getDataTable('corsostudiocaratteristica'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_corsostudioclassescuola_idclassescuola").on("click", _.partial(this.searchAndAssignclassescuola, self));
				$("#btn_add_corsostudioclassescuola_idclassescuola").prop("disabled", true);
				$("#btn_add_corsostudiostruttura_idstruttura").on("click", _.partial(this.searchAndAssignstruttura, self));
				$("#btn_add_corsostudiostruttura_idstruttura").prop("disabled", true);
				this.state.DS.tables.corsostudiokinddefaultview.staticFilter(window.jsDataQuery.isNotIn("idcorsostudiokind", [2,12,13]));
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
				$("#btn_add_corsostudioclassescuola_idclassescuola").prop("disabled", false);
				$("#btn_add_corsostudiostruttura_idstruttura").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_corsostudioclassescuola_idclassescuola").prop("disabled", true);
					$("#btn_add_corsostudiostruttura_idstruttura").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignclassescuola: function (that) {
				return that.searchAndAssign({
					tableName: "classescuola",
					listType: "default",
					idControl: "txt_corsostudioclassescuola_idclassescuola",
					tagSearch: "classescuoladefaultview.dropdown_title",
					columnNameText: "sigla",
					columnSource: "idclassescuola",
					columnToFill: "idclassescuola",
					tableToFill: "corsostudioclassescuola"
				});
			},

			searchAndAssignstruttura: function (that) {
				return that.searchAndAssign({
					tableName: "struttura",
					listType: "default",
					idControl: "txt_corsostudiostruttura_idstruttura",
					tagSearch: "strutturadefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idstruttura",
					columnToFill: "idstruttura",
					tableToFill: "corsostudiostruttura"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('corsostudio', 'default', metaPage_corsostudio);

}());
