
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
		MetaPage.apply(this, ['registry', 'amministrativi', false]);
        this.name = 'Personale Amministrativo';
		this.defaultListType = 'amministrativi';
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
				var def = appMeta.Deferred("afterGetFormData-registry_amministrativi_amministrativi");
				var arraydef = [];
				
				arraydef.push(this.manageregistry_amministrativi_default_idcontrattokind());
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
					this.helpForm.filter($('#registry_amministrativi_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_amministrativi_idtitle'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_amministrativi_amministrativi");
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

				arraydef.push(this.manageregistry_amministrativi_default_idcontrattokind());
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
				this.helpForm.filter($('#registry_amministrativi_idtitle'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('rendicontattivitaprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar56').fullCalendar('rerenderEvents');
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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('assetdiary'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('registry'), this.getDataTable('rendicontattivitaprogetto'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('rendicontattivitaprogetto'), this.getDataTable('rendicontattivitaprogettoora'));
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

			manageregistry_amministrativi_default_idcontrattokind: function () {
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

	window.appMeta.addMetaPage('registry', 'amministrativi', metaPage_registry);

}());
