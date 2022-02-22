
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
		MetaPage.apply(this, ['registry', 'studenti', false]);
        this.name = 'Studenti';
		this.defaultListType = 'studenti';
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
				
				var gridParentRelsiscrizione57 = self.state.DS.getParentChildRelation("registry", "iscrizione");
				var fatherfilteriscrizione57 = gridParentRelsiscrizione57[0].getChildFilter(parentRow);
				var filterGrididcorsostudio57 = window.jsDataQuery.isIn("idcorsostudio", _.map(this.getDataTable("corsostudio").rows,  					function (row) {  						if (row.idcorsostudiokind !== 12 && row.idcorsostudiokind !== 13 && row.idcorsostudiokind !== 2  /*Corsi di studio*/) {  							return row.idcorsostudio;  						}  					}));
				var iscrizione = this.getDataTable("iscrizione");
				var finalfilteriscrizione57 = window.jsDataQuery.and([fatherfilteriscrizione57, filterGrididcorsostudio57]);
				iscrizione.rows =  _.filter(iscrizione.rows, function(r) {return finalfilteriscrizione57(r)});
				$("#grid_iscrizione_seganagstu").data("customParentRelation", finalfilteriscrizione57);
				var gridParentRelsiscrizione_alias158 = self.state.DS.getParentChildRelation("registry", "iscrizione_alias1");
				var fatherfilteriscrizione_alias158 = gridParentRelsiscrizione_alias158[0].getChildFilter(parentRow);
				var filterGrididcorsostudio58 = window.jsDataQuery.isIn("idcorsostudio", _.map(this.getDataTable("corsostudio").rows, 					function (row) { 						if (row.idcorsostudiokind === 12 /*test di ingresso*/) { 							return row.idcorsostudio; 						} 					}));
				var iscrizione_alias1 = this.getDataTable("iscrizione_alias1");
				var finalfilteriscrizione_alias158 = window.jsDataQuery.and([fatherfilteriscrizione_alias158, filterGrididcorsostudio58]);
				iscrizione_alias1.rows =  _.filter(iscrizione_alias1.rows, function(r) {return finalfilteriscrizione_alias158(r)});
				$("#grid_iscrizione_alias1_seganagstuacc").data("customParentRelation", finalfilteriscrizione_alias158);
				var gridParentRelsiscrizione_alias259 = self.state.DS.getParentChildRelation("registry", "iscrizione_alias2");
				var fatherfilteriscrizione_alias259 = gridParentRelsiscrizione_alias259[0].getChildFilter(parentRow);
				var filterGrididcorsostudio59 = window.jsDataQuery.isIn("idcorsostudio", _.map(this.getDataTable("corsostudio").rows, 					function (row) { 						if (row.idcorsostudiokind === 2 /*master*/) { 							return row.idcorsostudio; 						} 					}));
				var iscrizione_alias2 = this.getDataTable("iscrizione_alias2");
				var finalfilteriscrizione_alias259 = window.jsDataQuery.and([fatherfilteriscrizione_alias259, filterGrididcorsostudio59]);
				iscrizione_alias2.rows =  _.filter(iscrizione_alias2.rows, function(r) {return finalfilteriscrizione_alias259(r)});
				$("#grid_iscrizione_alias2_seganagstumast").data("customParentRelation", finalfilteriscrizione_alias259);
				var gridParentRelsiscrizione_alias360 = self.state.DS.getParentChildRelation("registry", "iscrizione_alias3");
				var fatherfilteriscrizione_alias360 = gridParentRelsiscrizione_alias360[0].getChildFilter(parentRow);
				var filterGrididcorsostudio60 = window.jsDataQuery.isIn("idcorsostudio", _.map(this.getDataTable("corsostudio").rows, 					function (row) { 						if (row.idcorsostudiokind === 13 /*esami di stato*/) { 							return row.idcorsostudio; 						} 					}));
				var iscrizione_alias3 = this.getDataTable("iscrizione_alias3");
				var finalfilteriscrizione_alias360 = window.jsDataQuery.and([fatherfilteriscrizione_alias360, filterGrididcorsostudio60]);
				iscrizione_alias3.rows =  _.filter(iscrizione_alias3.rows, function(r) {return finalfilteriscrizione_alias360(r)});
				$("#grid_iscrizione_alias3_seganagstustato").data("customParentRelation", finalfilteriscrizione_alias360);
				var gridParentRelsiscrizione_alias461 = self.state.DS.getParentChildRelation("registry", "iscrizione_alias4");
				var fatherfilteriscrizione_alias461 = gridParentRelsiscrizione_alias461[0].getChildFilter(parentRow);
				var filterGrididcorsostudio61 = window.jsDataQuery.isNull("idcorsostudio");
				var iscrizione_alias4 = this.getDataTable("iscrizione_alias4");
				var finalfilteriscrizione_alias461 = window.jsDataQuery.and([fatherfilteriscrizione_alias461, filterGrididcorsostudio61]);
				iscrizione_alias4.rows =  _.filter(iscrizione_alias4.rows, function(r) {return finalfilteriscrizione_alias461(r)});
				$("#grid_iscrizione_alias4_seganagstusing").data("customParentRelation", finalfilteriscrizione_alias461);
				var gridParentRelsistanza62 = self.state.DS.getParentChildRelation("registry", "istanza");
				var fatherfilteristanza62 = gridParentRelsistanza62[0].getChildFilter(parentRow);
				var filterGrididistanzakind62 = window.jsDataQuery.eq("idistanzakind", 13);
				var filterGrididstatuskind62 = window.jsDataQuery.isIn("idstatuskind", _.map(this.getDataTable("statuskind").rows,  					function (row) {  						if (row.istanze === 'S') {  							return row.idstatuskind;  						}  					}));
				var istanza = this.getDataTable("istanza");
				var finalfilteristanza62 = window.jsDataQuery.and([fatherfilteristanza62, filterGrididistanzakind62,filterGrididstatuskind62]);
				istanza.rows =  _.filter(istanza.rows, function(r) {return finalfilteristanza62(r)});
				$("#grid_istanza_seganagstupre").data("customParentRelation", finalfilteristanza62);
				var gridParentRelsistanza_alias163 = self.state.DS.getParentChildRelation("registry", "istanza_alias1");
				var fatherfilteristanza_alias163 = gridParentRelsistanza_alias163[0].getChildFilter(parentRow);
				var filterGrididistanzakind63 = window.jsDataQuery.eq("idistanzakind", 14);
				var filterGrididstatuskind63 = window.jsDataQuery.isIn("idstatuskind", _.map(this.getDataTable("statuskind").rows,  					function (row) {  						if (row.istanze === 'S') {  							return row.idstatuskind;  						}  					}));
				var istanza_alias1 = this.getDataTable("istanza_alias1");
				var finalfilteristanza_alias163 = window.jsDataQuery.and([fatherfilteristanza_alias163, filterGrididistanzakind63,filterGrididstatuskind63]);
				istanza_alias1.rows =  _.filter(istanza_alias1.rows, function(r) {return finalfilteristanza_alias163(r)});
				$("#grid_istanza_alias1_seganagstu").data("customParentRelation", finalfilteristanza_alias163);
				var gridParentRelsistanza_alias264 = self.state.DS.getParentChildRelation("registry", "istanza_alias2");
				var fatherfilteristanza_alias264 = gridParentRelsistanza_alias264[0].getChildFilter(parentRow);
				var filterGrididistanzakind64 = window.jsDataQuery.eq("idistanzakind", 15);
				var filterGrididstatuskind64 = window.jsDataQuery.isIn("idstatuskind", _.map(this.getDataTable("statuskind").rows,  					function (row) {  						if (row.istanze === 'S') {  							return row.idstatuskind;  						}  					}));
				var istanza_alias2 = this.getDataTable("istanza_alias2");
				var finalfilteristanza_alias264 = window.jsDataQuery.and([fatherfilteristanza_alias264, filterGrididistanzakind64,filterGrididstatuskind64]);
				istanza_alias2.rows =  _.filter(istanza_alias2.rows, function(r) {return finalfilteristanza_alias264(r)});
				$("#grid_istanza_alias2_seganagsturin").data("customParentRelation", finalfilteristanza_alias264);
				var gridParentRelsistanza_alias365 = self.state.DS.getParentChildRelation("registry", "istanza_alias3");
				var fatherfilteristanza_alias365 = gridParentRelsistanza_alias365[0].getChildFilter(parentRow);
				var filterGrididistanzakind65 = window.jsDataQuery.eq("idistanzakind", 3);
				var filterGrididstatuskind65 = window.jsDataQuery.isIn("idstatuskind", _.map(this.getDataTable("statuskind").rows,  					function (row) {  						if (row.istanzedelibera === 'S') {  							return row.idstatuskind;  						}  					}));
				var istanza_alias3 = this.getDataTable("istanza_alias3");
				var finalfilteristanza_alias365 = window.jsDataQuery.and([fatherfilteristanza_alias365, filterGrididistanzakind65,filterGrididstatuskind65]);
				istanza_alias3.rows =  _.filter(istanza_alias3.rows, function(r) {return finalfilteristanza_alias365(r)});
				$("#grid_istanza_alias3_seganagstu").data("customParentRelation", finalfilteristanza_alias365);
				if (self.isNullOrMinDate(parentRow.birthdate))
					parentRow.birthdate = new Date();
				if (!parentRow.idregistrykind)
					parentRow.idregistrykind = "05";
				if (!parentRow.residence)
					parentRow.residence = 1;
				parentRow.extension = "studenti";
				
				//tolgo i sostenimenti che non sono figli di iscrizione a corsi normali
				this.deleteNotDescendants('sostenimento', 0, 'iscrizione', 0);
				//tolgo i piano studio alias 1 che non sono figli di iscrizione corsi singoli
				this.deleteNotDescendants('pianostudio', 1, 'iscrizione', 4);
				//tolgo le attività formative che non sono figlie dei piano studio figli di iscrizione corsi singoli
				this.deleteNotDescendants('pianostudioattivform', 1, 'iscrizione', 4);
				//tolgo i sostenimenti che non sono figli di iscrizione corsi singoli
				this.deleteNotDescendants('sostenimento', 1, 'iscrizione', 4);
				//tolgo i sostenimenti che non sono figli di iscrizione accesso
				this.deleteNotDescendants('sostenimento', 2, 'iscrizione', 1);
				//tolgo i sostenimenti che non sono figli di iscrizione a master
				this.deleteNotDescendants('sostenimento', 3, 'iscrizione', 2);
				//tolgo i sostenimenti che non sono figli di iscrizione a esami di stato
				this.deleteNotDescendants('sostenimento', 4, 'iscrizione', 3);

				//tolgo i nullaosta e diniego che non sono figli di istanze di preimmatricolazione
				this.deleteNotDescendants('istanza_imm', 0, 'istanza', 0);
				this.deleteNotDescendants('nullaosta', 0, 'istanza', 0);
				this.deleteNotDescendants('nullaosta_imm', 0, 'istanza', 0);
				this.deleteNotDescendants('diniego', 0, 'istanza', 0);
				//tolgo i nullaosta e diniego che non sono figli di istanze di immatricolazione
				this.deleteNotDescendants('istanza_imm', 1, 'istanza', 1);
				this.deleteNotDescendants('nullaosta', 1, 'istanza', 1);
				this.deleteNotDescendants('nullaosta_imm', 1, 'istanza', 1);
				this.deleteNotDescendants('diniego', 1, 'istanza', 1);
				//tolgo i nullaosta e diniego che non sono figli di istanze di rinnovo di iscrizione
				this.deleteNotDescendants('istanza_imm', 2, 'istanza', 2);
				this.deleteNotDescendants('nullaosta', 3, 'istanza', 2);
				this.deleteNotDescendants('nullaosta_imm', 3, 'istanza', 2);
				this.deleteNotDescendants('diniego', 2, 'istanza', 2);
				//tolgo i nipoti che non sono nipoti di istanze di passaggio
				this.deleteNotDescendants('nullaosta', 4, 'istanza', 3);
				this.deleteNotDescendants('diniego', 3, 'istanza', 3);
				this.deleteNotDescendants('pratica', 0, 'istanza', 3);

				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_studenti_idregistryclass'), null);
				} else {
					this.helpForm.filter($('#registry_studenti_idregistryclass'), this.q.eq('registryclass_active', 'Si'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_studenti_idtitle'), null);
				} else {
					this.helpForm.filter($('#registry_studenti_idtitle'), this.q.eq('active', 'S'));
				}
				if (this.state.isSearchState()) {
					this.helpForm.filter($('#registry_studenti_residence'), null);
				} else {
					this.helpForm.filter($('#registry_studenti_residence'), this.q.eq('active', 'S'));
				}
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-registry_studenti_studenti");
				var arraydef = [];
				
				var dt = this.state.DS.tables["registry_studenti"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("registry_studenti");
					meta.setDefaults(dt);
					var defregistry_studenti = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowstudenti) {
							currentRowstudenti.current.authinps = "N";
							currentRowstudenti.current.idstuddirittokind = 1;
							currentRowstudenti.current.idstudprenotkind = 1;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defregistry_studenti);
				}

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
				this.helpForm.filter($('#registry_studenti_idregistryclass'), null);
				this.helpForm.filter($('#registry_studenti_idtitle'), null);
				this.helpForm.filter($('#registry_studenti_residence'), null);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('pianostudio'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('decadenza'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_imm'), this.getDataTable('diniego_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_imm_alias1'), this.getDataTable('diniego_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_imm_alias2'), this.getDataTable('diniego_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_pas'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_pas'), this.getDataTable('nullaosta_alias3'));
				//afterClearin
			},

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('pianostudio'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('iscrizione'), this.getDataTable('decadenza'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_imm'), this.getDataTable('diniego_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_imm_alias1'), this.getDataTable('diniego_alias1'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_imm_alias2'), this.getDataTable('diniego_alias2'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_pas'), this.getDataTable('diniego_alias3'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza_pas'), this.getDataTable('nullaosta_alias3'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.configureDependencies();
				this.setDenyNull("registry","gender");
				this.setDenyNull("registry","surname");
				this.setDenyNull("registry","forename");
				this.setDenyNull("registry","idnation");
				this.setDenyNull("registry","idcity");
				this.setDenyNull("registry","birthdate");
				//indico al framework che la tabella corsostudio è cached
				var corsostudioTable = this.getDataTable("corsostudio");
				appMeta.metaModel.cachedTable(corsostudioTable, true);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(appMeta.getData.runSelectIntoTable(corsostudioTable, null, null));
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
				var p1 = $("input[data-tag='registry.surname?registrystudentiview.registry_surname']");
				var p2 = $("input[data-tag='registry.forename?registrystudentiview.registry_forename']");
				var f1 = $("input[data-tag='registry.title']");
                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename;
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            },

			deleteNotDescendants: function (descendant, descendantalias, element, elementalias) {
				var self = this;
				var descendantTable = descendant + (descendantalias !== 0 ? '_alias' + descendantalias : '');
				var elementTable = element + (elementalias !== 0 ? '_alias' + elementalias : '');
				var elementKey = 'id' + element;
				this.state.DS.tables[descendantTable].select(window.jsDataQuery.isNotIn(elementKey, 
					_.map(self.getDataTable(elementTable).rows,
					function (row) {
						return row[elementKey]; //sbagliato
					}))).forEach(function (row) {
							var state = row.getRow().state;
							row.getRow().del();
							if (state !== "added")
								row.getRow().acceptChanges();
					});
			},

			//buttons
        });

	window.appMeta.addMetaPage('registry', 'studenti', metaPage_registry);

}());
