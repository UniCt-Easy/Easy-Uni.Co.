
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

    function meta_inventorytreesegview() {
        MetaData.apply(this, ["inventorytreesegview"]);
        this.name = 'meta_inventorytreesegview';
    }

    meta_inventorytreesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_inventorytreesegview,
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
						this.describeAColumn(table, 'codeinv', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'inventorytree_description', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'accmotive_codemotive', 'Codice causale di carico', null, 40, 50);
						this.describeAColumn(table, 'accmotive_title', 'Denominazione causale di carico', null, 40, 150);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idinv"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "codeinv asc , inventorytree_description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('inventorytreesegview', new meta_inventorytreesegview('inventorytreesegview'));

	}());
