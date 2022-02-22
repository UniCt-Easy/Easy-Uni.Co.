
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

    function meta_menuwebtreeview() {
        MetaData.apply(this, ["menuwebtreeview"]);
        this.name = 'meta_menuwebtreeview';
    }

    meta_menuwebtreeview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_menuwebtreeview,
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
					case 'tree':
						this.describeAColumn(table, 'idmenuweb', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'menuweb_editType', 'EditType', null, 20, 60);
						this.describeAColumn(table, 'menuwebparent_label', 'Idmenuwebparent', null, 30, 250);
						this.describeAColumn(table, 'label', 'Label', null, 40, 250);
						this.describeAColumn(table, 'menuweb_link', 'Link', null, 50, 250);
						this.describeAColumn(table, 'menuweb_sort', 'Sort', null, 60, null);
						this.describeAColumn(table, 'menuweb_tableName', 'TableName', null, 70, 60);
//$objCalcFieldConfig_tree$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idmenuweb"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "tree": {
						return "menuwebparent_label asc , menuweb_sort asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('menuwebtreeview', new meta_menuwebtreeview('menuwebtreeview'));

	}());
