
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

    function meta_perfrequestobbindividualedefaultview() {
        MetaData.apply(this, ["perfrequestobbindividualedefaultview"]);
        this.name = 'meta_perfrequestobbindividualedefaultview';
    }

    meta_perfrequestobbindividualedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfrequestobbindividualedefaultview,
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
						this.describeAColumn(table, 'registry_title', 'Valutato', null, 10, 101);
						this.describeAColumn(table, 'title', 'Titolo obiettivo', null, 20, 1024);
						this.describeAColumn(table, 'year_year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'perfrequestobbindividuale_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'perfrequestobbindividuale_peso', 'Peso', 'fixed.2', 50, null);
						this.describeAColumn(table, 'perfrequestobbindividuale_inserito', 'Inserito', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idperfrequestobbindividuale"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfrequestobbindividualedefaultview', new meta_perfrequestobbindividualedefaultview('perfrequestobbindividualedefaultview'));

	}());
