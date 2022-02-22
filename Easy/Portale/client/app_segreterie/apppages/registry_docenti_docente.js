
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
		MetaPage.apply(this, ['registry', 'docenti_docente', false]);
        this.name = 'Dati personali';
		this.defaultListType = 'docenti_docente';
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
				var def = appMeta.Deferred("afterGetFormData-registry_docenti_docenti_docente");
				var arraydef = [];
				
				arraydef.push(this.manageregistry_docenti_docente_idcontrattokind());
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
								_.forEach(this.getDataTable("rendicontaltro").rows, function (r) {
					var title = r.ore + ' ore';
					if(r.idrendicontaltrokind) {
						var tipoRows = self.getDataTable("rendicontaltrokind").select(self.q.eq('idrendicontaltrokind', r.idrendicontaltrokind));
						title += ' per ' + tipoRows[0].title;
					}
					r['!title'] = title;
				});				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idclassconsorsuale'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idclassconsorsuale'), this.q.eq('classconsorsuale_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_docenti_docente_idreg_istituti'), null);
				} else {
					this.helpForm.filter($('#registry_docenti_docente_idreg_istituti'), this.q.eq('registry_active', 'Si'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_docenti_docenti_docente");
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

				arraydef.push(this.manageregistry_docenti_docente_idcontrattokind());
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
				this.helpForm.filter($('#registry_docenti_docente_idtitle'), null);
				this.helpForm.filter($('#registry_docenti_docente_idregistryclass'), null);
				this.helpForm.filter($('#registry_docenti_docente_idclassconsorsuale'), null);
				this.helpForm.filter($('#registry_docenti_docente_idreg_istituti'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('progettotimesheet'), this.getDataTable('progettotimesheetprogetto'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				this.configureDependencies();
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar64').fullCalendar('rerenderEvents');
				});
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar65').fullCalendar('rerenderEvents');
				});
				this.setDenyNull("registry","surname");
				this.setDenyNull("registry","forename");
				this.setDenyNull("registry","gender");
				this.setDenyNull("registry","birthdate");
				this.setDenyNull("registry","idcity");
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

			//QUESTO COMMENTO SERVE AD EVITARE CHE L'ANTIVIRUS SCAMBI IL FILE PER UN VIRUS
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
				this.enableControl($('#registry_docenti_docente_idreg'), false);
				this.enableControl($('#registry_docenti_docente_idtitle'), false);
				this.enableControl($('#registry_docenti_docente_surname'), false);
				this.enableControl($('#registry_docenti_docente_forename'), false);
				this.enableControl($('#registry_docenti_docente_genderM'), false);
				this.enableControl($('#registry_docenti_docente_genderF'), false);
				this.enableControl($('#registry_docenti_docente_birthdate'), false);
				this.enableControl($('#registry_docenti_docente_idcity'), false);
				this.enableControl($('#registry_docenti_docente_idnation'), false);
				this.enableControl($('#registry_docenti_docente_cf'), false);
				this.enableControl($('#registry_docenti_docente_idmaritalstatus'), false);
				this.enableControl($('#registry_docenti_docente_p_iva'), false);
				this.enableControl($('#registry_docenti_docente_idregistryclass'), false);
				this.enableControl($('#registry_docenti_docente_residence'), false);
				this.enableControl($('#registry_docenti_docente_location'), false);
				this.enableControl($('#registry_docenti_docente_foreigncf'), false);
				this.enableControl($('#registry_docenti_docente_maritalsurname'), false);
				this.enableControl($('#registry_docenti_docente_soggiorno'), false);
				this.enableControl($('#registry_docenti_docente_idstruttura'), false);
				this.enableControl($('#registry_docenti_docente_idsasd'), false);
				this.enableControl($('#registry_docenti_docente_idclassconsorsuale'), false);
				this.enableControl($('#registry_docenti_docente_idreg_istituti'), false);
				this.enableControl($('#registry_docenti_docente_idfonteindicebibliometrico'), false);
				this.enableControl($('#registry_docenti_docente_indicebibliometrico'), false);
				this.enableControl($('#registry_docenti_docente_activeSi'), false);
				this.enableControl($('#registry_docenti_docente_activeNo'), false);
				this.enableControl($('#registry_docenti_docente_badgecode'), false);
				this.enableControl($('#registry_docenti_docente_annotation'), false);
				this.enableControl($('#registry_docenti_docente_multi_cfSi'), false);
				this.enableControl($('#registry_docenti_docente_multi_cfNo'), false);
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
						// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
						filter = self.q.and(
							self.q.eq("idreg", self.state.currentRow.idreg),
							self.q.eq("idrendicontaltro", 0)
						);
						return self.getExternalEventForCalendar(filter, $("[data-tag='rendicontaltro.docente.docente']")).then( function(){
							return MetaPage.prototype.afterFill.call(self);
						});
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			manageregistry_docenti_docente_idcontrattokind: function () {
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

	window.appMeta.addMetaPage('registry', 'docenti_docente', metaPage_registry);

}());
