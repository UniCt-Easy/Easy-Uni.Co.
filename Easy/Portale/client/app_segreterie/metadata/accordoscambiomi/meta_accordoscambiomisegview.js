
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

    function meta_accordoscambiomisegview() {
        MetaData.apply(this, ["accordoscambiomisegview"]);
        this.name = 'meta_accordoscambiomisegview';
    }

    meta_accordoscambiomisegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomisegview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, -1);
						this.describeAColumn(table, 'programmami_acronimo', 'Programma di mobilità internazionale', null, 20, 50);
						this.describeAColumn(table, 'aa_start', 'Anno accademico di inizio', null, 30, 9);
						this.describeAColumn(table, 'aa_stop', 'Anno accademico di fine', null, 40, 9);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaccordoscambiomi"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('accordoscambiomisegview', new meta_accordoscambiomisegview('accordoscambiomisegview'));

	}());
