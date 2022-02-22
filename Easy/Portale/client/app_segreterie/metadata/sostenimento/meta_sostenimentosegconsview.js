
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


(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentosegconsview() {
        MetaData.apply(this, ["sostenimentosegconsview"]);
        this.name = 'meta_sostenimentosegconsview';
    }

    meta_sostenimentosegconsview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentosegconsview,
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
					case 'segcons':
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'annoaccademico_didprog_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'annoaccademico_iscrizione_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 20, null);
						this.describeAColumn(table, 'sostenimento_domande', 'Domande', null, 30, null);
						this.describeAColumn(table, 'sostenimento_ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'appello_description', 'Descrizione Appello', null, 60, 1024);
						this.describeAColumn(table, 'attivform_title', 'Attivit� formativa', null, 70, -1);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Prova di ammissione', null, 80, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Prova di ammissione', null, 80, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Prova di ammissione', null, 90, 1024);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 100, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 100, null);
						this.describeAColumn(table, 'prova_title', 'Denominazione Prova', null, 110, 50);
						this.describeAColumn(table, 'prova_start', 'Data e ora inizio Prova', 'g', 110, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 130, 50);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di studio', null, 140, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di studio', null, 140, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di studio', null, 140, null);
						this.describeAColumn(table, 'sostenimento_insecod', 'Codice insegnamento', null, 150, 50);
						this.describeAColumn(table, 'sostenimento_insedesc', 'Insegnamento', null, 160, 1024);
						this.describeAColumn(table, 'sostenimento_livello', 'Livello', null, 170, null);
						this.describeAColumn(table, 'sostenimentoparent_idreg', 'Studente Sostenimento parziale di', null, 180, null);
						this.describeAColumn(table, 'sostenimentoparent_voto', 'Voto Sostenimento parziale di', 'fixed.2', 180, null);
						this.describeAColumn(table, 'sostenimentoparent_votosu', 'Su Sostenimento parziale di', null, 180, null);
						this.describeAColumn(table, 'sostenimentoparent_votolode', 'Lode Sostenimento parziale di', null, 180, null);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 210, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 220, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 230, null);
//$objCalcFieldConfig_segcons$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentosegconsview', new meta_sostenimentosegconsview('sostenimentosegconsview'));

	}());
