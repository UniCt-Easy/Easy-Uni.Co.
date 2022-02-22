
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

    function metaPage_progettotipocosto() {
		MetaPage.apply(this, ['progettotipocosto', 'seg', true]);
        this.name = 'Voci di costo o ricavo';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_progettotipocosto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettotipocosto,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			afterFill: function () {
				this.enableControl($('#progettotipocosto_seg_idprogettotipocostokind'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_progettotipocostoaccmotive_idaccmotive").on("click", _.partial(this.searchAndAssignaccmotive, self));
				$("#btn_add_progettotipocostoaccmotive_idaccmotive").prop("disabled", true);
				$("#btn_add_progettotipocostoinventorytree_idinv").on("click", _.partial(this.searchAndAssigninventorytree, self));
				$("#btn_add_progettotipocostoinventorytree_idinv").prop("disabled", true);
				$("#btn_add_progettotipocostotax_taxcode").on("click", _.partial(this.searchAndAssigntax, self));
				$("#btn_add_progettotipocostotax_taxcode").prop("disabled", true);
				$("#btn_add_progettotiporicavoaccmotive_idaccmotive").on("click", _.partial(this.searchAndAssignaccmotive_alias1, self));
				$("#btn_add_progettotiporicavoaccmotive_idaccmotive").prop("disabled", true);
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
				$("#btn_add_progettotipocostoaccmotive_idaccmotive").prop("disabled", false);
				$("#btn_add_progettotipocostoinventorytree_idinv").prop("disabled", false);
				$("#btn_add_progettotipocostotax_taxcode").prop("disabled", false);
				$("#btn_add_progettotiporicavoaccmotive_idaccmotive").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_progettotipocostoaccmotive_idaccmotive").prop("disabled", true);
					$("#btn_add_progettotipocostoinventorytree_idinv").prop("disabled", true);
					$("#btn_add_progettotipocostotax_taxcode").prop("disabled", true);
					$("#btn_add_progettotiporicavoaccmotive_idaccmotive").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignaccmotive: function (that) {
				return that.searchAndAssign({
					tableName: "accmotive",
					listType: "seg",
					idControl: "txt_progettotipocostoaccmotive_idaccmotive",
					tagSearch: "accmotivesegview.dropdown_title",
					columnNameText: "codemotive",
					columnSource: "idaccmotive",
					columnToFill: "idaccmotive",
					tableToFill: "progettotipocostoaccmotive"
				});
			},

			searchAndAssigninventorytree: function (that) {
				return that.searchAndAssign({
					tableName: "inventorytree",
					listType: "seg",
					idControl: "txt_progettotipocostoinventorytree_idinv",
					tagSearch: "inventorytreesegview.dropdown_title",
					columnNameText: "codeinv",
					columnSource: "idinv",
					columnToFill: "idinv",
					tableToFill: "progettotipocostoinventorytree"
				});
			},

			searchAndAssigntax: function (that) {
				return that.searchAndAssign({
					tableName: "tax",
					listType: "seg",
					idControl: "txt_progettotipocostotax_taxcode",
					tagSearch: "taxsegview.dropdown_title",
					columnNameText: "description",
					columnSource: "taxcode",
					columnToFill: "taxcode",
					tableToFill: "progettotipocostotax"
				});
			},

			searchAndAssignaccmotive_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "accmotive_alias1",
					listType: "seg",
					idControl: "txt_progettotiporicavoaccmotive_idaccmotive",
					tagSearch: "accmotivesegview.dropdown_title",
					columnNameText: "codemotive",
					columnSource: "idaccmotive",
					columnToFill: "idaccmotive",
					tableToFill: "progettotiporicavoaccmotive"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettotipocosto', 'seg', metaPage_progettotipocosto);

}());
