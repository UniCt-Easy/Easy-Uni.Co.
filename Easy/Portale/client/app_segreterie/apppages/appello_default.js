
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

    function metaPage_appello() {
		MetaPage.apply(this, ['appello', 'default', false]);
        this.name = 'Appelli';
		this.defaultListType = 'default';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_appello.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_appello,
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
				
				if (!parentRow.idappelloazionekind)
					parentRow.idappelloazionekind = 1;
				if (!parentRow.idappellokind)
					parentRow.idappellokind = 1;
				if (!parentRow.idstudprenotkind)
					parentRow.idstudprenotkind = 1;
				if (!parentRow.lavoratori)
					parentRow.lavoratori = "N";
				if (!parentRow.passaggio)
					parentRow.passaggio = "N";
				if (!parentRow.prointermedia)
					parentRow.prointermedia = "N";
				if (!parentRow.publicato)
					parentRow.publicato = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-appello_default");
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

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				$("#btn_add_appelloattivform_idattivform").on("click", _.partial(this.searchAndAssignattivform, self));
				$("#btn_add_appelloattivform_idattivform").prop("disabled", true);
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
				$("#btn_add_appelloattivform_idattivform").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_appelloattivform_idattivform").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssignattivform: function (that) {
				return that.searchAndAssign({
					tableName: "attivform",
					listType: "appello",
					idControl: "txt_appelloattivform_idattivform",
					tagSearch: "attivformappelloview.dropdown_title",
					columnNameText: "title",
					columnSource: "idattivform",
					columnToFill: "idattivform",
					tableToFill: "appelloattivform"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('appello', 'default', metaPage_appello);

}());
