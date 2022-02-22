
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
		MetaPage.apply(this, ['registry', 'amministrativi_personale', false]);
        this.name = 'Dati personali';
		this.defaultListType = 'amministrativi_personale';
		this.searchEnabled = false;
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.canShowLast = false;
		this.firstSearchFilter = window.jsDataQuery.constant(true);
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
				var def = appMeta.Deferred("afterGetFormData-registry_amministrativi_amministrativi_personale");
				var arraydef = [];
				
				arraydef.push(this.manageregistry_amministrativi_personale_idcontrattokind());
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
				
				if (!parentRow.active)
					parentRow.active = 'S';
				if (!parentRow.idcentralizedcategory)
					parentRow.idcentralizedcategory = "01";
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "amministrativi";
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_personale_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_personale_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_personale_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_personale_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_amministrativi_personale_idcategory'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_personale_idcategory'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_amministrativi_amministrativi_personale");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_amministrativi"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_amministrativi");
					meta.setDefaults(dt);
					var defregistry_amministrativi = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowamministrativi) {
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_amministrativi);
				}

				arraydef.push(this.manageregistry_amministrativi_personale_idcontrattokind());
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
				this.helpForm.filter($('#registry_amministrativi_personale_idtitle'), null);
				this.helpForm.filter($('#registry_amministrativi_personale_idregistryclass'), null);
				this.helpForm.filter($('#registry_amministrativi_personale_idcategory'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar54').fullCalendar('rerenderEvents');
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

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			configureDependencies:function () {
				var p1 = $("input[data-tag='registry.surname?registryamministrativiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registryamministrativiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title']");

				// funz di trasformazione
				var modifiesDenominazione = function (row) {
					if (!row) return;
					var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
					var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
					return vSurname + " " + vForename.substring(1,49);
				};
				this.registerFormula(f1, modifiesDenominazione);

				this.addDependencies(p1, f1);
				this.addDependencies(p2, f1);
			},

			afterFill: function () {
				this.enableControl($('#registry_amministrativi_personale_idtitle'), false);
				this.enableControl($('#registry_amministrativi_personale_forename'), false);
				this.enableControl($('#registry_amministrativi_personale_surname'), false);
				this.enableControl($('#registry_amministrativi_personale_birthdate'), false);
				this.enableControl($('#registry_amministrativi_personale_idcity'), false);
				this.enableControl($('#registry_amministrativi_personale_idnation'), false);
				this.enableControl($('#registry_amministrativi_personale_genderM'), false);
				this.enableControl($('#registry_amministrativi_personale_genderF'), false);
				this.enableControl($('#registry_amministrativi_personale_cf'), false);
				this.enableControl($('#registry_amministrativi_personale_foreigncf'), false);
				this.enableControl($('#registry_amministrativi_personale_badgecode'), false);
				this.enableControl($('#registry_amministrativi_personale_idmaritalstatus'), false);
				this.enableControl($('#registry_amministrativi_personale_activeSi'), false);
				this.enableControl($('#registry_amministrativi_personale_activeNo'), false);
				this.enableControl($('#registry_amministrativi_personale_idregistryclass'), false);
				this.enableControl($('#registry_amministrativi_personale_annotation'), false);
				this.enableControl($('#registry_amministrativi_personale_idcategory'), false);
				this.enableControl($('#registry_amministrativi_personale_idregistrykind'), false);
				this.enableControl($('#registry_amministrativi_personale_p_iva'), false);
				this.enableControl($('#registry_amministrativi_personale_residence'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg),
						self.q.eq("idsospensione",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='sospensione.default.default']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			manageregistry_amministrativi_personale_idcontrattokind: function () {
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
					this.state.DS.tables.registry_amministrativi.rows[0].idcontrattokind = currcontratto.idcontrattokind;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'amministrativi_personale', metaPage_registry);

}());
