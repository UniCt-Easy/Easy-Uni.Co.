
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function metaPage_mansionekind() {
		MetaPage.apply(this, ['mansionekind', 'default', false]);
        this.name = 'Mansioni';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_mansionekind.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_mansionekind,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$("#btn_add_mansionekindcomportamento_idperfcomportamento").on("click", _.partial(this.searchAndAssignperfcomportamento, self));
				$("#btn_add_mansionekindcomportamento_idperfcomportamento").prop("disabled", true);
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
				$("#btn_add_mansionekindcomportamento_idperfcomportamento").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_mansionekindcomportamento_idperfcomportamento").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignperfcomportamento: function (that) {
				return that.searchAndAssign({
					tableName: "perfcomportamento",
					listType: "default",
					idControl: "txt_mansionekindcomportamento_idperfcomportamento",
					tagSearch: "perfcomportamento.title",
					columnNameText: "title",
					columnSource: "idperfcomportamento",
					columnToFill: "idperfcomportamento",
					tableToFill: "mansionekindcomportamento"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('mansionekind', 'default', metaPage_mansionekind);

}());