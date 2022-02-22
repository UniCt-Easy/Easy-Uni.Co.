
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

    function meta_learningagrtrainersegview() {
        MetaData.apply(this, ["learningagrtrainersegview"]);
        this.name = 'meta_learningagrtrainersegview';
    }

    meta_learningagrtrainersegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrtrainersegview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo del tirocinio ', null, 20, -1);
						this.describeAColumn(table, 'learningagrtrainer_address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'learningagrtrainer_assicurazienda', 'Assicurazione dell\'azienda', null, 40, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuraziendacivile', 'Copertura responsabilità civile', null, 50, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuraziendaspost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 60, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuraziendaviagg', 'Copertura viaggi di lavoro', null, 70, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristituto', 'Assicurazione dell\'istituto', null, 80, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristitutocivile', 'Copertura responsabilità civile', null, 90, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristitutospost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 100, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristitutoviagg', 'Copertura viaggi di lavoro', null, 110, null);
						this.describeAColumn(table, 'learningagrtrainer_cap', 'CAP', null, 120, 20);
						this.describeAColumn(table, 'learningagrtrainer_capacitaacquis', 'Capacità e competenze che verranno acquisite', null, 130, -1);
						this.describeAColumn(table, 'learningagrtrainer_ectscf', 'Numero di crediti ECTS', null, 140, null);
						this.describeAColumn(table, 'learningagrtrainer_ectstitle', 'Titolo ECTS', null, 150, -1);
						this.describeAColumn(table, 'geo_city_title', 'Città', null, 180, 65);
						this.describeAColumn(table, 'learningagrkind_title', 'Tipologia Fase del tirocinio', null, 200, 50);
						this.describeAColumn(table, 'learningagrkind_description', 'Descrizione Fase del tirocinio', null, 200, 256);
						this.describeAColumn(table, 'learningagrtrainerkind_title', 'Tipologia', null, 210, 50);
						this.describeAColumn(table, 'learningagrtrainervalut_title', 'Title Tipo di valutazione finale', null, 220, 50);
						this.describeAColumn(table, 'learningagrtrainervalut_description', 'Description Tipo di valutazione finale', null, 220, 256);
						this.describeAColumn(table, 'registryaziende_title', 'Azienda o ente', null, 250, 101);
						this.describeAColumn(table, 'learningagrtrainer_location', 'Località', null, 260, 20);
						this.describeAColumn(table, 'learningagrtrainer_oresettimana', 'Ore di lavoro alla settimana ', null, 270, null);
						this.describeAColumn(table, 'learningagrtrainer_pianomonit', 'Piano di monitoraggio', null, 280, -1);
						this.describeAColumn(table, 'learningagrtrainer_pianovalut', 'Piano di valutazione', null, 290, -1);
						this.describeAColumn(table, 'learningagrtrainer_programma', 'Programma', null, 300, -1);
						this.describeAColumn(table, 'learningagrtrainer_registrainemd', 'Registra l’attività nell’Europass Mobility Document', null, 310, null);
						this.describeAColumn(table, 'learningagrtrainer_registraintor', 'Registra l’attività nel Transcript of records', null, 320, null);
						this.describeAColumn(table, 'learningagrtrainer_sostaltro', 'Sostegni di qualunque altro tipo dell’azienda', 'fixed.2', 330, null);
						this.describeAColumn(table, 'learningagrtrainer_sostazienda', 'Sostegno economico dell’azienda', 'fixed.2', 340, null);
						this.describeAColumn(table, 'learningagrtrainer_start', 'Data inizio periodo ', null, 350, null);
						this.describeAColumn(table, 'learningagrtrainer_stop', 'Data fine periodo ', null, 360, null);
						this.describeAColumn(table, 'learningagrtrainer_voto', 'Voto', null, 370, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idbandomi", "idiscrizionebmi", "idlearningagrtrainer"];
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

    window.appMeta.addMeta('learningagrtrainersegview', new meta_learningagrtrainersegview('learningagrtrainersegview'));

	}());
