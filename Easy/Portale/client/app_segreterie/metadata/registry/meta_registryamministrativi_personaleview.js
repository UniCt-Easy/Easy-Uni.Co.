
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

    function meta_registryamministrativi_personaleview() {
        MetaData.apply(this, ["registryamministrativi_personaleview"]);
        this.name = 'meta_registryamministrativi_personaleview';
    }

    meta_registryamministrativi_personaleview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryamministrativi_personaleview,
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
					case 'amministrativi_personale':
						this.describeAColumn(table, 'title_description', 'Titolo', null, 10, 50);
						this.describeAColumn(table, 'registry_surname', 'Cognome', null, 20, 50);
						this.describeAColumn(table, 'registry_forename', 'Nome', null, 30, 50);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_badgecode', 'Codice bedge', null, 50, 20);
						this.describeAColumn(table, 'registry_active', 'Attivo', null, 100, null);
						this.describeAColumn(table, 'contrattokind_title', 'Tipo', null, 520, 50);
//$objCalcFieldConfig_amministrativi_personale$
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

			//$getSorting$

        });

    window.appMeta.addMeta('registryamministrativi_personaleview', new meta_registryamministrativi_personaleview('registryamministrativi_personaleview'));

	}());
