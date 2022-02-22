
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

    function meta_perfsogliadefaultview() {
        MetaData.apply(this, ["perfsogliadefaultview"]);
        this.name = 'meta_perfsogliadefaultview';
    }

    meta_perfsogliadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfsogliadefaultview,
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
						this.describeAColumn(table, 'perfsogliakind_idperfsogliakind', 'Tipo', null, 30, 50);
						this.describeAColumn(table, 'perfsoglia_valore', 'Percentuale di default', 'fixed.2', 40, null);
						this.describeAColumn(table, 'year_year', 'Anno solare', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfsoglia"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfsogliadefaultview', new meta_perfsogliadefaultview('perfsogliadefaultview'));

	}());
