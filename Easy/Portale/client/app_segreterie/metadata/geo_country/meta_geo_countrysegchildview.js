
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

    function meta_geo_countrysegchildview() {
        MetaData.apply(this, ["geo_countrysegchildview"]);
        this.name = 'meta_geo_countrysegchildview';
    }

    meta_geo_countrysegchildview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_countrysegchildview,
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
					case 'segchild':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'geo_country_1_title', 'id nuova provincia in cui questa è confluita', null, 40, 50);
						this.describeAColumn(table, 'geo_country_2_title', 'id provincia da cui questa è confluita', null, 50, 50);
						this.describeAColumn(table, 'geo_country_province', 'sigla provincia', null, 60, null);
						this.describeAColumn(table, 'geo_country_start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'geo_country_stop', 'data fine', null, 80, null);
//$objCalcFieldConfig_segchild$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcountry"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segchild": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_countrysegchildview', new meta_geo_countrysegchildview('geo_countrysegchildview'));

	}());
