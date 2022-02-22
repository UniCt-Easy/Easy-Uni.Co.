
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

    function metaPage_registry() {
		MetaPage.apply(this, ['registry', 'uncategorized', false]);
        this.name = 'Anagrafiche da categorizzare';
		this.defaultListType = 'uncategorized';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_registry,
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
				
				if (!parentRow.residence)
					parentRow.residence = 1;
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_uncategorized_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_uncategorized_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_uncategorized_idaccmotivedebit'), null);
				} else {
					this.helpForm.filter($('#registry_uncategorized_idaccmotivedebit'), this.q.eq('accmotive_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_uncategorized_idaccmotivecredit'), null);
				} else {
					this.helpForm.filter($('#registry_uncategorized_idaccmotivecredit'), this.q.eq('accmotive_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_uncategorized");
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
				this.helpForm.filter($('#registry_uncategorized_idregistryclass'), null);
				this.helpForm.filter($('#registry_uncategorized_idaccmotivedebit'), null);
				this.helpForm.filter($('#registry_uncategorized_idaccmotivecredit'), null);
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#registry_uncategorized_idreg'), false);
				this.enableControl($('#registry_uncategorized_idregistryclass'), false);
				this.enableControl($('#registry_uncategorized_extmatricula'), false);
				this.enableControl($('#registry_uncategorized_idaccmotivedebit'), false);
				this.enableControl($('#registry_uncategorized_title'), false);
				this.enableControl($('#registry_uncategorized_idaccmotivecredit'), false);
				this.enableControl($('#registry_uncategorized_cf'), false);
				this.enableControl($('#registry_uncategorized_p_iva'), false);
				this.enableControl($('#registry_uncategorized_activeSi'), false);
				this.enableControl($('#registry_uncategorized_activeNo'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#SetAsDocente").on("click", _.partial(this.fireSetAsDocente, this));
				$("#SetAsDocente").prop("disabled", true);
				$("#SetAsAmministrativo").on("click", _.partial(this.fireSetAsAmministrativo, this));
				$("#SetAsAmministrativo").prop("disabled", true);
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
				$("#SetAsDocente").prop("disabled", false);
				$("#SetAsAmministrativo").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#SetAsDocente").prop("disabled", true);
					$("#SetAsAmministrativo").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			fireSetAsDocente: function (that) {
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				var dt = that.state.DS.tables["registry_docenti"];
				var meta = appMeta.getMeta("registry_docenti");
				meta.setDefaults(dt);
				return meta.getNewRow(that.state.currentRow.getRow(), dt, that.editType).then(
					function (currentRowdocenti) {
						that.state.currentRow.extension = 'docenti'
						//defaultExtendingObject
						return true;
					}).then(function () {
						dt.rows[0].idreg = that.state.currentRow.idreg;
						that.hideWaitingIndicator(waitingHandler);
						alert('impostazione effettuata');
					});
			},

			fireSetAsAmministrativo: function (that) {
				var waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				var dt = that.state.DS.tables["registry_amministrativi"];
				var meta = appMeta.getMeta("registry_amministrativi");
				meta.setDefaults(dt);
				return meta.getNewRow(that.state.currentRow.getRow(), dt, that.editType).then(
					function (currentRowamministrativi) {
						currentRowamministrativi.idreg = that.state.currentRow.idreg;
						that.state.currentRow.extension = 'amministrativi'
						//defaultExtendingObject
						return true;
					}
				).then(function () {
					dt.rows[0].idreg = that.state.currentRow.idreg;
					that.hideWaitingIndicator(waitingHandler);
					alert('impostazione effettuata');
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'uncategorized', metaPage_registry);

}());
