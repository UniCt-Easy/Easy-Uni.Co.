
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

    function meta_esonerotitolostudioview() {
        MetaData.apply(this, ["esonerotitolostudioview"]);
        this.name = 'meta_esonerotitolostudioview';
    }

    meta_esonerotitolostudioview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonerotitolostudioview,
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
					case 'titolostudio':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'esonero_description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'esonero_applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Sconto', null, 60, 2024);
						this.describeAColumn(table, 'esoneroanskind_title', 'Tipologia Codice ANS', null, 70, 50);
						this.describeAColumn(table, 'esoneroanskind_description', 'Descrizione Codice ANS', null, 70, 256);
						this.describeAColumn(table, 'esonero_retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'esonero_soloconisee', 'Applicabile solo con ISEE', null, 90, null);
						this.describeAColumn(table, 'esonero_titolostudio_conseguitoincorso', 'Conseguito in corso', null, 10, null);
						this.describeAColumn(table, 'esonero_titolostudio_dataconstutticf', 'Data limite per aver conseguito tutti i crediti formativi', null, 20, null);
						this.describeAColumn(table, 'esonero_titolostudio_datalaurea', 'Data limite di conseguimento del titolo', null, 30, null);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura didattica', null, 50, 1024);
						this.describeAColumn(table, 'esonero_titolostudio_nellistituto', 'Solo per corsi dell\'istituto', null, 60, null);
						this.describeAColumn(table, 'esonero_titolostudio_noabbr', 'Senza abbreviazioni di carriera', null, 70, null);
						this.describeAColumn(table, 'esonero_titolostudio_noparttime', 'Senza aver effettuato iscrizioni part-time', null, 80, null);
						this.describeAColumn(table, 'esonero_titolostudio_votomin', 'Voto minimo', null, 90, null);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
//$objCalcFieldConfig_titolostudio$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idesonero"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "titolostudio": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonerotitolostudioview', new meta_esonerotitolostudioview('esonerotitolostudioview'));

	}());
