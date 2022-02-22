
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

    function meta_workpackagesegview() {
        MetaData.apply(this, ["workpackagesegview"]);
        this.name = 'meta_workpackagesegview';
    }

    meta_workpackagesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_workpackagesegview,
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
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
						this.describeAColumn(table, 'raggruppamento', 'Raggruppamento', null, 10, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'workpackage_acronimo', 'Acronimo', null, 30, 2048);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Dipartimento', null, 50, 1024);
						this.describeAColumn(table, 'workpackage_start', 'Data di inizio', null, 100, null);
						this.describeAColumn(table, 'workpackage_stop', 'Data di fine', null, 110, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto", "idworkpackage"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "raggruppamento asc , workpackage_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('workpackagesegview', new meta_workpackagesegview('workpackagesegview'));

	}());
