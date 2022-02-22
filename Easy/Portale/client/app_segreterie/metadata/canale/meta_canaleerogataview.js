
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

    function meta_canaleerogataview() {
        MetaData.apply(this, ["canaleerogataview"]);
        this.name = 'meta_canaleerogataview';
    }

    meta_canaleerogataview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_canaleerogataview,
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
					case 'erogata':
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 10, 256);
						this.describeAColumn(table, 'didprogori_title', 'Orientamento', null, 20, 256);
						this.describeAColumn(table, 'didproganno_title', 'Anno', null, 30, 2048);
						this.describeAColumn(table, 'didprogporzanno_title', 'Porzione d\'anno', null, 40, 2048);
						this.describeAColumn(table, 'attivform_title', 'Attività formativa', null, 50, -1);
						this.describeAColumn(table, 'title', 'Denominazione', null, 60, 256);
						this.describeAColumn(table, 'canale_CUIN', 'CUIN', null, 70, 9);
						this.describeAColumn(table, 'XXaffidamento', 'Affidamento', null, 150, null);
						this.describeAColumn(table, 'XXmutuazione', 'Mutuazione o fruizione', null, 160, null);
//$objCalcFieldConfig_erogata$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idcanale", "iddidprog", "idattivform", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "erogata": {
						return "didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , attivform_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('canaleerogataview', new meta_canaleerogataview('canaleerogataview'));

	}());
