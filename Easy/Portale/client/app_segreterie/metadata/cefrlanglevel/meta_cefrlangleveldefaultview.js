
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

    function meta_cefrlangleveldefaultview() {
        MetaData.apply(this, ["cefrlangleveldefaultview"]);
        this.name = 'meta_cefrlangleveldefaultview';
    }

    meta_cefrlangleveldefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_cefrlangleveldefaultview,
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
						this.describeAColumn(table, 'geo_nation_title', 'Lingua', null, 10, 65);
						this.describeAColumn(table, 'cefrcompasc_title', 'Comprensione ascolto', null, 20, 50);
						this.describeAColumn(table, 'cefrcomplett_title', 'Comprensione lettura', null, 30, 50);
						this.describeAColumn(table, 'cefrparlinter_title', 'Parlato interazione', null, 40, 50);
						this.describeAColumn(table, 'cefrparlprod_title', 'Parlato produzione', null, 50, 50);
						this.describeAColumn(table, 'cefrscritto_title', 'Scritto', null, 60, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcefrlanglevel"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('cefrlangleveldefaultview', new meta_cefrlangleveldefaultview('cefrlangleveldefaultview'));

	}());
