
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

    function meta_geo_nationsegview() {
        MetaData.apply(this, ["geo_nationsegview"]);
        this.name = 'meta_geo_nationsegview';
    }

    meta_geo_nationsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_nationsegview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'geo_continent_title', 'Continente', null, 20, 50);
						this.describeAColumn(table, 'geo_nation_lang', 'Lingua', null, 40, 64);
						this.describeAColumn(table, 'geo_nation_1_title', 'Nazione in cui questa è confluita', null, 50, 65);
						this.describeAColumn(table, 'geo_nation_2_title', 'Nazione da cui questa è confluita', null, 60, 65);
						this.describeAColumn(table, 'geo_nation_start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'geo_nation_stop', 'data fine', null, 80, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idnation"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_nationsegview', new meta_geo_nationsegview('geo_nationsegview'));

	}());
