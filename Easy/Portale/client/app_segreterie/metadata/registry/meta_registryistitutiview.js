
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

    function meta_registryistitutiview() {
        MetaData.apply(this, ["registryistitutiview"]);
        this.name = 'meta_registryistitutiview';
    }

    meta_registryistitutiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryistitutiview,
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
					case 'istituti':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 20, 65);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'registry_istituti_idreg', 'Codice', null, 10, null);
						this.describeAColumn(table, 'registry_istituti_codicemiur', 'Codice MIUR', null, 40, 50);
						this.describeAColumn(table, 'istitutokind_tipoistituto', 'Tipologia', null, 50, 256);
//$objCalcFieldConfig_istituti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "istituti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryistitutiview', new meta_registryistitutiview('registryistitutiview'));

	}());
