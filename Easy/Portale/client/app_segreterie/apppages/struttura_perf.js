
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

    function metaPage_struttura() {
		MetaPage.apply(this, ['struttura', 'perf', false]);
        this.name = 'Unità organizzative';
		this.defaultListType = 'perf';
		this.isList = true;
		this.isTree = true;
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_struttura.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_struttura,
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
				
				appMeta.metaModel.getTemporaryValues(this.getDataTable('perfstrutturaperfindicatore'));
				appMeta.metaModel.getTemporaryValues(this.getDataTable('strutturaresponsabile'));
				appMeta.metaModel.getTemporaryValues(this.getDataTable('afferenza'));
				if (this.state.isEditState()) {
					this.helpForm.filter($('#struttura_perf_paridstruttura'), this.q.ne('idstruttura', this.state.currentRow.idstruttura));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#struttura_perf_idupb'), null);
				} else {
					this.helpForm.filter($('#struttura_perf_idupb'), this.q.eq('upb_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-struttura_perf");
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
				this.helpForm.filter($('#struttura_perf_idupb'), null);
				//afterClearin
			},

			//afterFill

			afterLink: function () {
				var self = this;
				$("#btn_add_perfstrutturaperfindicatore_idperfindicatore").on("click", _.partial(this.searchAndAssignperfindicatore, self));
				$("#btn_add_perfstrutturaperfindicatore_idperfindicatore").prop("disabled", true);
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
				$("#btn_add_perfstrutturaperfindicatore_idperfindicatore").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_perfstrutturaperfindicatore_idperfindicatore").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			beforeSelectTreeManager: function () {
				var def = appMeta.Deferred('beforeSelectTreeManager');
				return def.resolve(true);
			},

			searchAndAssignperfindicatore: function (that) {
				return that.searchAndAssign({
					tableName: "perfindicatore",
					listType: "default",
					idControl: "txt_perfstrutturaperfindicatore_idperfindicatore",
					tagSearch: "perfindicatoredefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idperfindicatore",
					columnToFill: "idperfindicatore",
					tableToFill: "perfstrutturaperfindicatore"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('struttura', 'perf', metaPage_struttura);

}());
