
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

    function meta_attivformpropedview() {
        MetaData.apply(this, ["attivformpropedview"]);
        this.name = 'meta_attivformpropedview';
    }

    meta_attivformpropedview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformpropedview,
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
					case 'proped':
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 10, 256);
						this.describeAColumn(table, 'didprogori_title', 'Orientamento', null, 20, 256);
						this.describeAColumn(table, 'didproganno_title', 'Anno di corso', null, 30, 2048);
						this.describeAColumn(table, 'didprogporzanno_title', 'Porzione d\'anno', null, 40, 2048);
						this.describeAColumn(table, 'didproggrupp_title', 'Gruppo opzionale', null, 50, 256);
						this.describeAColumn(table, 'insegn_denominazione', 'Denominazione Insegnamento', null, 60, 256);
						this.describeAColumn(table, 'insegn_codice', 'Codice Insegnamento', null, 60, 50);
						this.describeAColumn(table, 'insegninteg_denominazione', 'Denominazione Integrando', null, 70, 256);
						this.describeAColumn(table, 'insegninteg_codice', 'Codice Integrando', null, 70, 50);
						this.describeAColumn(table, 'attivform_start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'attivform_stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'attivform_tipovalutaz', 'Profitto o Idoneità', null, 100, null);
//$objCalcFieldConfig_proped$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idsede", "iddidprog", "idattivform", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "proped": {
						return "didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('attivformpropedview', new meta_attivformpropedview('attivformpropedview'));

	}());
