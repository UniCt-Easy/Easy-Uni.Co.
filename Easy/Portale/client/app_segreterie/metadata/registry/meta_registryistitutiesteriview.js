
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

    function meta_registryistitutiesteriview() {
        MetaData.apply(this, ["registryistitutiesteriview"]);
        this.name = 'meta_registryistitutiesteriview';
    }

    meta_registryistitutiesteriview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryistitutiesteriview,
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
					case 'istitutiesteri':
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'geo_city_title', 'Città', null, 70, 65);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 80, 65);
						this.describeAColumn(table, 'registry_istitutiesteri_idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'registry_istitutiesteri_name', 'Name', null, 20, 1024);
						this.describeAColumn(table, 'registry_istitutiesteri_city', 'City', null, 30, 255);
						this.describeAColumn(table, 'registry_istitutiesteri_code', 'Code', null, 40, 50);
						this.describeAColumn(table, 'registry_istitutiesteri_institutionalcode', 'Institutional code', null, 50, 50);
						this.describeAColumn(table, 'registry_istitutiesteri_referencenumber', 'Reference number', null, 60, 50);
//$objCalcFieldConfig_istitutiesteri$
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
					case "istitutiesteri": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryistitutiesteriview', new meta_registryistitutiesteriview('registryistitutiesteriview'));

	}());
