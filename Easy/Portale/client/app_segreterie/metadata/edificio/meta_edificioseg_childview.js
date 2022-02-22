
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

    function meta_edificioseg_childview() {
        MetaData.apply(this, ["edificioseg_childview"]);
        this.name = 'meta_edificioseg_childview';
    }

    meta_edificioseg_childview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_edificioseg_childview,
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
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'edificio_address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'edificio_cap', 'CAP', null, 40, 20);
						this.describeAColumn(table, 'edificio_code', 'Codice', null, 50, 128);
						this.describeAColumn(table, 'geo_city_title', 'Città', null, 60, 65);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 70, 65);
						this.describeAColumn(table, 'edificio_latitude', 'Latitudine', 'fixed.7', 90, null);
						this.describeAColumn(table, 'edificio_location', 'Località', null, 100, 20);
						this.describeAColumn(table, 'edificio_longitude', 'Longitudine', 'fixed.7', 110, null);
//$objCalcFieldConfig_seg_child$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsede", "idedificio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg_child": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('edificioseg_childview', new meta_edificioseg_childview('edificioseg_childview'));

	}());
