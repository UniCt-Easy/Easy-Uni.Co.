
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

    function meta_areadidatticadefaultview() {
        MetaData.apply(this, ["areadidatticadefaultview"]);
        this.name = 'meta_areadidatticadefaultview';
    }

    meta_areadidatticadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_areadidatticadefaultview,
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
						this.describeAColumn(table, 'idareadidattica', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 100);
						this.describeAColumn(table, 'areadidattica_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'corsostudiokind_title', 'Tipo di corso', null, 40, 50);
						this.describeAColumn(table, 'areadidattica_sortcode', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, 'areadidattica_subtitle', 'Sotto-titolo', null, 60, 100);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idareadidattica"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , areadidattica_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('areadidatticadefaultview', new meta_areadidatticadefaultview('areadidatticadefaultview'));

	}());
