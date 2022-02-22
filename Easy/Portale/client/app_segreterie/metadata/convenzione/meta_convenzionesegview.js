
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

    function meta_convenzionesegview() {
        MetaData.apply(this, ["convenzionesegview"]);
        this.name = 'meta_convenzionesegview';
    }

    meta_convenzionesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_convenzionesegview,
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
						this.describeAColumn(table, 'registry_title', 'Istituto, ente o azienda', null, 10, 101);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 256);
						this.describeAColumn(table, 'convenzione_start', 'Data di inizio', null, 40, null);
						this.describeAColumn(table, 'convenzione_stop', 'Data di fine', null, 50, null);
						this.describeAColumn(table, 'convenzione_url', 'URL', null, 60, 512);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idconvenzione"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "registry_title desc, title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('convenzionesegview', new meta_convenzionesegview('convenzionesegview'));

	}());
