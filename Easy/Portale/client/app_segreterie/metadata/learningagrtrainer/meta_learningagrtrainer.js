
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


(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_learningagrtrainer() {
        MetaData.apply(this, ["learningagrtrainer"]);
        this.name = 'meta_learningagrtrainer';
    }

    meta_learningagrtrainer.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrtrainer,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo del tirocinio ', null, 20, -1);
						this.describeAColumn(table, 'address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'assicurazienda', 'Assicurazione dell\'azienda', null, 40, null);
						this.describeAColumn(table, 'assicuraziendacivile', 'Copertura responsabilità civile', null, 50, null);
						this.describeAColumn(table, 'assicuraziendaspost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 60, null);
						this.describeAColumn(table, 'assicuraziendaviagg', 'Copertura viaggi di lavoro', null, 70, null);
						this.describeAColumn(table, 'assicuristituto', 'Assicurazione dell\'istituto', null, 80, null);
						this.describeAColumn(table, 'assicuristitutocivile', 'Copertura responsabilità civile', null, 90, null);
						this.describeAColumn(table, 'assicuristitutospost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 100, null);
						this.describeAColumn(table, 'assicuristitutoviagg', 'Copertura viaggi di lavoro', null, 110, null);
						this.describeAColumn(table, 'cap', 'CAP', null, 120, 20);
						this.describeAColumn(table, 'capacitaacquis', 'Capacità e competenze che verranno acquisite', null, 130, -1);
						this.describeAColumn(table, 'ectscf', 'Numero di crediti ECTS', null, 140, null);
						this.describeAColumn(table, 'ectstitle', 'Titolo ECTS', null, 150, -1);
						this.describeAColumn(table, 'location', 'Località', null, 260, 20);
						this.describeAColumn(table, 'oresettimana', 'Ore di lavoro alla settimana ', null, 270, null);
						this.describeAColumn(table, 'pianomonit', 'Piano di monitoraggio', null, 280, -1);
						this.describeAColumn(table, 'pianovalut', 'Piano di valutazione', null, 290, -1);
						this.describeAColumn(table, 'programma', 'Programma', null, 300, -1);
						this.describeAColumn(table, 'registrainemd', 'Registra l’attività nell’Europass Mobility Document', null, 310, null);
						this.describeAColumn(table, 'registraintor', 'Registra l’attività nel Transcript of records', null, 320, null);
						this.describeAColumn(table, 'sostaltro', 'Sostegni di qualunque altro tipo dell’azienda', 'fixed.2', 330, null);
						this.describeAColumn(table, 'sostazienda', 'Sostegno economico dell’azienda', 'fixed.2', 340, null);
						this.describeAColumn(table, 'start', 'Data inizio periodo ', null, 350, null);
						this.describeAColumn(table, 'stop', 'Data fine periodo ', null, 360, null);
						this.describeAColumn(table, 'voto', 'Voto', null, 370, null);
						this.describeAColumn(table, '!idcity_geo_city_title', 'Città', null, 181, null);
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup:'geo_city', columnNameLookup:'title', columnNamekey:'idcity' };
						this.describeAColumn(table, '!idlearningagrkind_learningagrkind_title', 'Tipologia Fase del tirocinio', null, 201, null);
						this.describeAColumn(table, '!idlearningagrkind_learningagrkind_description', 'Descrizione Fase del tirocinio', null, 202, null);
						objCalcFieldConfig['!idlearningagrkind_learningagrkind_title'] = { tableNameLookup:'learningagrkind', columnNameLookup:'title', columnNamekey:'idlearningagrkind' };
						objCalcFieldConfig['!idlearningagrkind_learningagrkind_description'] = { tableNameLookup:'learningagrkind', columnNameLookup:'description', columnNamekey:'idlearningagrkind' };
						this.describeAColumn(table, '!idlearningagrtrainerkind_learningagrtrainerkind_title', 'Tipologia', null, 211, null);
						objCalcFieldConfig['!idlearningagrtrainerkind_learningagrtrainerkind_title'] = { tableNameLookup:'learningagrtrainerkind', columnNameLookup:'title', columnNamekey:'idlearningagrtrainerkind' };
						this.describeAColumn(table, '!idlearningagrtrainervalut_learningagrtrainervalut_title', 'Title Tipo di valutazione finale', null, 221, null);
						this.describeAColumn(table, '!idlearningagrtrainervalut_learningagrtrainervalut_description', 'Description Tipo di valutazione finale', null, 222, null);
						objCalcFieldConfig['!idlearningagrtrainervalut_learningagrtrainervalut_title'] = { tableNameLookup:'learningagrtrainervalut', columnNameLookup:'title', columnNamekey:'idlearningagrtrainervalut' };
						objCalcFieldConfig['!idlearningagrtrainervalut_learningagrtrainervalut_description'] = { tableNameLookup:'learningagrtrainervalut', columnNameLookup:'description', columnNamekey:'idlearningagrtrainervalut' };
						this.describeAColumn(table, '!idreg_aziende_registry_aziende_title', 'Azienda o ente', null, 251, null);
						objCalcFieldConfig['!idreg_aziende_registry_aziende_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_learningagrtrainer");

				//$getNewRowInside$

				dt.autoIncrement('idlearningagrtrainer', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('learningagrtrainer', new meta_learningagrtrainer('learningagrtrainer'));

	}());
