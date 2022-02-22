
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

    function metaPage_workpackage() {
		MetaPage.apply(this, ['workpackage', 'seg', true]);
        this.name = 'Workpackage';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_workpackage.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_workpackage,
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
				
				this.manageworkpackage_seg_amount();				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-workpackage_seg");
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('workpackage'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('workpackage'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_workpackageupb_idupb").on("click", _.partial(this.searchAndAssignupb, self));
				$("#btn_add_workpackageupb_idupb").prop("disabled", true);
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
				$("#btn_add_workpackageupb_idupb").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_workpackageupb_idupb").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

						manageworkpackage_seg_amount: function () {
				var assetdiary= this.getDataTable('assetdiary');
				var assetdiaryora = this.getDataTable('assetdiaryora');
				_.forEach(assetdiary.rows, function(rb) {
					rb["!amount"] = _.ceil( _.sumBy(
						_.filter(assetdiaryora.rows, function (r) {
							return r.idassetdiary === rb.idassetdiary  && !!r.amount;
						}),
						'amount'), 2);
				});
			}
,

			searchAndAssignupb: function (that) {
				return that.searchAndAssign({
					tableName: "upb",
					listType: "seg",
					idControl: "txt_workpackageupb_idupb",
					tagSearch: "upbsegview.dropdown_title",
					columnNameText: "title",
					columnSource: "idupb",
					columnToFill: "idupb",
					tableToFill: "workpackageupb"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('workpackage', 'seg', metaPage_workpackage);

}());
