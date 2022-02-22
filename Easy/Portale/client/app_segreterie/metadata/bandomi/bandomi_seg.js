
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

    function metaPage_bandomi() {
		MetaPage.apply(this, ['bandomi', 'seg', false]);
        this.name = 'Bandi di mobilit�';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_bandomi.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomi,
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
				
				if (self.isNullOrMinDate(parentRow.startcandidature))
					parentRow.startcandidature = new Date();
				if (self.isNullOrMinDate(parentRow.startgraduatoria))
					parentRow.startgraduatoria = new Date();
				if (self.isNullOrMinDate(parentRow.startpresentazione))
					parentRow.startpresentazione = new Date();
				if (self.isNullOrMinDate(parentRow.stopcadidature))
					parentRow.stopcadidature = new Date();
				if (self.isNullOrMinDate(parentRow.stopgraduatoria))
					parentRow.stopgraduatoria = new Date();
				if (self.isNullOrMinDate(parentRow.stoppresentazione))
					parentRow.stoppresentazione = new Date();
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#bandomi_seg_idresidence'), null);
				} else {
					this.helpForm.filter($('#bandomi_seg_idresidence'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-bandomi_seg");
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
				this.helpForm.filter($('#bandomi_seg_idresidence'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('convalida_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('cefrlanglevel_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizionebmi'), this.getDataTable('cefrlanglevel_alias2'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('convalida'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrstud'), this.getDataTable('cefrlanglevel'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('convalida_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('learningagrtrainer'), this.getDataTable('cefrlanglevel_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizionebmi'), this.getDataTable('cefrlanglevel_alias2'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btn_add_bandomididprogto_iddidprog").on("click", _.partial(this.searchAndAssigndidprog, self));
				$("#btn_add_bandomididprogto_iddidprog").prop("disabled", true);
				$("#btn_add_bandomididprogfrom_iddidprog").on("click", _.partial(this.searchAndAssigndidprog_alias1, self));
				$("#btn_add_bandomididprogfrom_iddidprog").prop("disabled", true);
				$("#btn_add_bandomipropedeut_idinsegn").on("click", _.partial(this.searchAndAssigninsegn, self));
				$("#btn_add_bandomipropedeut_idinsegn").prop("disabled", true);
				$("#btn_add_bandomiinsegn_idinsegn").on("click", _.partial(this.searchAndAssigninsegn_alias1, self));
				$("#btn_add_bandomiinsegn_idinsegn").prop("disabled", true);
				$("#btn_add_bandomistrutturefrom_idstruttura").on("click", _.partial(this.searchAndAssignstruttura, self));
				$("#btn_add_bandomistrutturefrom_idstruttura").prop("disabled", true);
				$("#btn_add_bandomistruttureto_idstruttura").on("click", _.partial(this.searchAndAssignstruttura_alias1, self));
				$("#btn_add_bandomistruttureto_idstruttura").prop("disabled", true);
				$("#btn_add_bandomiistitutiesteri_idreg_istitutiesteri").on("click", _.partial(this.searchAndAssignregistry_istitutiesteri, self));
				$("#btn_add_bandomiistitutiesteri_idreg_istitutiesteri").prop("disabled", true);
				$("#btn_add_bandomiallegati_idbandomiallegati").on("click", _.partial(this.searchAndAssignbandomiallegati_alias1, self));
				$("#btn_add_bandomiallegati_idbandomiallegati").prop("disabled", true);
				$("#btn_add_bandomirequisito_idrequisito").on("click", _.partial(this.searchAndAssignrequisito, self));
				$("#btn_add_bandomirequisito_idrequisito").prop("disabled", true);
				this.setDenyNull("bandomi","aa");
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
				$("#btn_add_bandomididprogto_iddidprog").prop("disabled", false);
				$("#btn_add_bandomididprogfrom_iddidprog").prop("disabled", false);
				$("#btn_add_bandomipropedeut_idinsegn").prop("disabled", false);
				$("#btn_add_bandomiinsegn_idinsegn").prop("disabled", false);
				$("#btn_add_bandomistrutturefrom_idstruttura").prop("disabled", false);
				$("#btn_add_bandomistruttureto_idstruttura").prop("disabled", false);
				$("#btn_add_bandomiistitutiesteri_idreg_istitutiesteri").prop("disabled", false);
				$("#btn_add_bandomiallegati_idbandomiallegati").prop("disabled", false);
				$("#btn_add_bandomirequisito_idrequisito").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_bandomididprogto_iddidprog").prop("disabled", true);
					$("#btn_add_bandomididprogfrom_iddidprog").prop("disabled", true);
					$("#btn_add_bandomipropedeut_idinsegn").prop("disabled", true);
					$("#btn_add_bandomiinsegn_idinsegn").prop("disabled", true);
					$("#btn_add_bandomistrutturefrom_idstruttura").prop("disabled", true);
					$("#btn_add_bandomistruttureto_idstruttura").prop("disabled", true);
					$("#btn_add_bandomiistitutiesteri_idreg_istitutiesteri").prop("disabled", true);
					$("#btn_add_bandomiallegati_idbandomiallegati").prop("disabled", true);
					$("#btn_add_bandomirequisito_idrequisito").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			searchAndAssigndidprog: function (that) {
				return that.searchAndAssign({
					tableName: "didprog",
					listType: "default",
					idControl: "txt_bandomididprogto_iddidprog",
					tagSearch: "didprogdefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "iddidprog",
					columnToFill: "iddidprog",
					tableToFill: "bandomididprogto"
				});
			},

			searchAndAssigndidprog_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "didprog_alias1",
					listType: "default",
					idControl: "txt_bandomididprogfrom_iddidprog",
					tagSearch: "didprogdefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "iddidprog",
					columnToFill: "iddidprog",
					tableToFill: "bandomididprogfrom"
				});
			},

			searchAndAssigninsegn: function (that) {
				return that.searchAndAssign({
					tableName: "insegn",
					listType: "default",
					idControl: "txt_bandomipropedeut_idinsegn",
					tagSearch: "insegndefaultview.dropdown_title",
					columnNameText: "denominazione",
					columnSource: "idinsegn",
					columnToFill: "idinsegn",
					tableToFill: "bandomipropedeut"
				});
			},

			searchAndAssigninsegn_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "insegn_alias1",
					listType: "default",
					idControl: "txt_bandomiinsegn_idinsegn",
					tagSearch: "insegndefaultview.dropdown_title",
					columnNameText: "denominazione",
					columnSource: "idinsegn",
					columnToFill: "idinsegn",
					tableToFill: "bandomiinsegn"
				});
			},

			searchAndAssignstruttura: function (that) {
				return that.searchAndAssign({
					tableName: "struttura",
					listType: "default",
					idControl: "txt_bandomistrutturefrom_idstruttura",
					tagSearch: "strutturadefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idstruttura",
					columnToFill: "idstruttura",
					tableToFill: "bandomistrutturefrom"
				});
			},

			searchAndAssignstruttura_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "struttura_alias1",
					listType: "default",
					idControl: "txt_bandomistruttureto_idstruttura",
					tagSearch: "strutturadefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idstruttura",
					columnToFill: "idstruttura",
					tableToFill: "bandomistruttureto"
				});
			},

			searchAndAssignregistry_istitutiesteri: function (that) {
				return that.searchAndAssign({
					tableName: "registry",
					listType: "istitutiesteri",
					idControl: "txt_bandomiistitutiesteri_idreg_istitutiesteri",
					tagSearch: "registryistitutiesteriview.dropdown_title",
					columnNameText: "title",
					columnSource: "idreg",
					columnToFill: "idreg_istitutiesteri",
					tableToFill: "bandomiistitutiesteri"
				});
			},

			searchAndAssignbandomiallegati_alias1: function (that) {
				return that.searchAndAssign({
					tableName: "bandomiallegati_alias1",
					listType: "default",
					idControl: "txt_bandomiallegati_idbandomiallegati",
					tagSearch: "bandomiallegati_alias1.title",
					columnNameText: "title",
					columnSource: "idbandomiallegati",
					columnToFill: "idbandomiallegati",
					tableToFill: "bandomiallegati"
				});
			},

			searchAndAssignrequisito: function (that) {
				return that.searchAndAssign({
					tableName: "requisito",
					listType: "default",
					idControl: "txt_bandomirequisito_idrequisito",
					tagSearch: "requisito.title",
					columnNameText: "title",
					columnSource: "idrequisito",
					columnToFill: "idrequisito",
					tableToFill: "bandomirequisito"
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('bandomi', 'seg', metaPage_bandomi);

}());
