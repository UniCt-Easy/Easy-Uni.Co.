
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
		MetaPage.apply(this, ['registry', 'docenti', false]);
        this.name = 'Docenti';
		this.defaultListType = 'docenti';
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

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-registry_docenti_docenti");
				var arraydef = [];
				
				arraydef.push(this.manageregistry_docenti_default_idcontrattokind());
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
				
				if (self.isNullOrMinDate(parentRow.birthdate))
					parentRow.birthdate = new Date();
				if (!parentRow.idregistrykind)
					parentRow.idregistrykind = 8;
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "docenti";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_default_idclassconsorsuale'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_default_idclassconsorsuale'), this.q.eq('classconsorsuale_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_default_idreg_istituti'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_default_idreg_istituti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_docenti_docenti");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_docenti"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_docenti");
					meta.setDefaults(dt);
					var defregistry_docenti = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowdocenti) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_docenti);
				}

				arraydef.push(this.manageregistry_docenti_default_idcontrattokind());
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
				this.helpForm.filter($('#registry_docenti_idtitle'), null);
				this.helpForm.filter($('#registry_docenti_idregistryclass'), null);
				this.helpForm.filter($('#registry_docenti_default_idclassconsorsuale'), null);
				this.helpForm.filter($('#registry_docenti_default_idreg_istituti'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('rendicontattivitaprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				$("#btn_add_publicazregistry_docenti_idpublicaz").on("click", _.partial(this.searchAndAssignpublicaz, self));
				$("#btn_add_publicazregistry_docenti_idpublicaz").prop("disabled", true);
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar64').fullCalendar('rerenderEvents');
				});
				this.setDenyNull("registry","surname");
				this.setDenyNull("registry","forename");
				this.setDenyNull("registry","gender");
				this.setDenyNull("registry","birthdate");
				this.setDenyNull("registry","idcity");
				var grid_affidamento_segChildsTables = [
					{ tablename: 'affidamentocaratteristica', edittype: 'seg', columnlookup: 'json', columncalc: '!affidamentocaratteristica'},
				];
				$('#grid_affidamento_seg').data('childtables', grid_affidamento_segChildsTables);
				$('#grid_affidamento_seg').data('childtablesadd', false);
				$('#grid_affidamento_seg').data('childtablesedit', false);
				$('#grid_affidamento_seg').data('childtablesdelete', false);
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
				$("#btn_add_publicazregistry_docenti_idpublicaz").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btn_add_publicazregistry_docenti_idpublicaz").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registrydocentiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registrydocentiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title']");
                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename.substring(0,49);
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            },

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('rendicontattivitaprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", self.state.currentRow.idreg),
						self.q.eq("idsospensione",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='sospensione.default.default']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			searchAndAssignpublicaz: function (that) {
				return that.searchAndAssign({
					tableName: "publicaz",
					listType: "default",
					idControl: "txt_publicazregistry_docenti_idpublicaz",
					tagSearch: "publicazdefaultview.dropdown_title",
					columnNameText: "title",
					columnSource: "idpublicaz",
					columnToFill: "idpublicaz",
					tableToFill: "publicazregistry_docenti"
				});
			},

			manageregistry_docenti_default_idcontrattokind: function () {
				var def = appMeta.Deferred("beforeFill-manageregistry_docenti_idcontrattokind");
				var self = this;
				var currcontratto;
				_.forEach(this.state.DS.tables.contratto.rows, function (row) {
					if (!currcontratto)
						currcontratto = row;
					else
						if (currcontratto.start < row.start)
							currcontratto = row;
				});
				if (currcontratto)
					this.state.DS.tables.registry_docenti.rows[0].idcontrattokind = currcontratto.idcontrattokind;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'docenti', metaPage_registry);

}());
