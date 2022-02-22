
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

    function meta_registryclassaziendeview() {
        MetaData.apply(this, ["registryclassaziendeview"]);
        this.name = 'meta_registryclassaziendeview';
    }

    meta_registryclassaziendeview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryclassaziendeview,
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
					case 'aziende':
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'registryclass_active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_aziende$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idregistryclass"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registryclassaziendeview', new meta_registryclassaziendeview('registryclassaziendeview'));

	}());
