
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

    function meta_geo_citydefaultview() {
        MetaData.apply(this, ["geo_citydefaultview"]);
        this.name = 'meta_geo_citydefaultview';
    }

    meta_geo_citydefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_citydefaultview,
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
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'idcity', 'Codice', null, 20, null);
						this.describeAColumn(table, 'geo_country_title', 'id paese (tabella geo_country)', null, 30, 50);
						this.describeAColumn(table, 'geo_city_1_title', 'id nuovo comune in cui questo è eventualmente confluito, se valorizzato questo comune non è più valido', null, 40, 65);
						this.describeAColumn(table, 'geo_city_2_title', 'id comune da cui questo è confluito', null, 50, 65);
						this.describeAColumn(table, 'geo_city_start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'geo_city_stop', 'data fine', null, 70, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcity"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('geo_citydefaultview', new meta_geo_citydefaultview('geo_citydefaultview'));

	}());
