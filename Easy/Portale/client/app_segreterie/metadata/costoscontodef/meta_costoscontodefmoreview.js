
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

    function meta_costoscontodefmoreview() {
        MetaData.apply(this, ["costoscontodefmoreview"]);
        this.name = 'meta_costoscontodefmoreview';
    }

    meta_costoscontodefmoreview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefmoreview,
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
					case 'more':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2024);
						this.describeAColumn(table, 'costoscontodefkind_title', 'Tipologia', null, 30, 50);
						this.describeAColumn(table, 'costoscontodefparent_title', 'Relativo al costo', null, 40, 2024);
//$objCalcFieldConfig_more$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcostoscontodef"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "more": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodefmoreview', new meta_costoscontodefmoreview('costoscontodefmoreview'));

	}());
