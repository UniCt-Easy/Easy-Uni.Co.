
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

    function meta_perfprogettoobiettivoattivitadocentiview() {
        MetaData.apply(this, ["perfprogettoobiettivoattivitadocentiview"]);
        this.name = 'meta_perfprogettoobiettivoattivitadocentiview';
    }

    meta_perfprogettoobiettivoattivitadocentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivoattivitadocentiview,
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
					case 'docenti':
						this.describeAColumn(table, 'perfprogetto_title', 'Progetto Strategico', null, 1200, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivo_title', 'Obiettivo strategico', null, 2200, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivoattivitaparent_title', 'Attività madre', null, 3400, 1024);
						this.describeAColumn(table, 'title', 'Titolo', null, 4000, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datainizioprevista', 'Data inizio prevista', 'g', 5000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datafineprevista', 'Data fine prevista', 'g', 6000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datainizioeffettiva', 'Data inizio effettiva', 'g', 7000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datafineeffettiva', 'Data fine effettiva', 'g', 8000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_completamento', 'Percentuale di completamento', 'fixed.2', 9000, null);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docenti": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivoattivitadocentiview', new meta_perfprogettoobiettivoattivitadocentiview('perfprogettoobiettivoattivitadocentiview'));

	}());
