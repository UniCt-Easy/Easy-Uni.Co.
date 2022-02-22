
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

    function meta_sedeseg_child_aziendaview() {
        MetaData.apply(this, ["sedeseg_child_aziendaview"]);
        this.name = 'meta_sedeseg_child_aziendaview';
    }

    meta_sedeseg_child_aziendaview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sedeseg_child_aziendaview,
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
					case 'seg_child_azienda':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'sede_address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'sede_cap', 'CAP', null, 50, 20);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 60, 65);
//$objCalcFieldConfig_seg_child_azienda$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsede"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg_child_azienda": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sedeseg_child_aziendaview', new meta_sedeseg_child_aziendaview('sedeseg_child_aziendaview'));

	}());
