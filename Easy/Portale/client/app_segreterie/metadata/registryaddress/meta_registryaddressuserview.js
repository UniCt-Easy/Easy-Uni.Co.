
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

    function meta_registryaddressuserview() {
        MetaData.apply(this, ["registryaddressuserview"]);
        this.name = 'meta_registryaddressuserview';
    }

    meta_registryaddressuserview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryaddressuserview,
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
					case 'user':
						this.describeAColumn(table, 'address', 'Indirizzo', null, 70, 100);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 90, 65);
						this.describeAColumn(table, 'registryaddress_location', 'Località', null, 100, 50);
						this.describeAColumn(table, 'registryaddress_cap', 'CAP', null, 110, 20);
//$objCalcFieldConfig_user$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "start", "idaddresskind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "user": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryaddressuserview', new meta_registryaddressuserview('registryaddressuserview'));

	}());
