
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

    function meta_sasdintegrandiview() {
        MetaData.apply(this, ["sasdintegrandiview"]);
        this.name = 'meta_sasdintegrandiview';
    }

    meta_sasdintegrandiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sasdintegrandiview,
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
					case 'integrandi':
						this.describeAColumn(table, 'idsasd', 'Codice Istituto', null, 10, null);
						this.describeAColumn(table, 'codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'sasd_title', 'Denominazione', null, 30, 255);
						this.describeAColumn(table, 'areadidattica_title', 'Area o ambito disciplinare', null, 40, 100);
						this.describeAColumn(table, 'sasd_codice_old', 'Codice legge precedente', null, 50, 4);
//$objCalcFieldConfig_integrandi$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsasd"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "integrandi": {
						return "codice asc , sasd_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('sasdintegrandiview', new meta_sasdintegrandiview('sasdintegrandiview'));

	}());
