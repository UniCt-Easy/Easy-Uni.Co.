
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

    function meta_registryuncategorizedview() {
        MetaData.apply(this, ["registryuncategorizedview"]);
        this.name = 'meta_registryuncategorizedview';
    }

    meta_registryuncategorizedview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryuncategorizedview,
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
					case 'uncategorized':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 101);
						this.describeAColumn(table, 'registryclass_description', 'Tipologia', null, 30, 150);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'registry_extmatricula', 'Matricola', null, 70, 40);
//$objCalcFieldConfig_uncategorized$
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
					case "uncategorized": {
						return "title asc ";
					}
					case "uncategorized": {
						return "title asc , registryclass_description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('registryuncategorizedview', new meta_registryuncategorizedview('registryuncategorizedview'));

	}());
