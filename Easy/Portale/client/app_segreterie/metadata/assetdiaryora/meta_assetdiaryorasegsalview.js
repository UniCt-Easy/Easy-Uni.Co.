
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

    function meta_assetdiaryorasegsalview() {
        MetaData.apply(this, ["assetdiaryorasegsalview"]);
        this.name = 'meta_assetdiaryorasegsalview';
    }

    meta_assetdiaryorasegsalview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiaryorasegsalview,
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
					case 'segsal':
						this.describeAColumn(table, 'assetdiaryora_amount', 'Amount', 'fixed.2', 10, null);
						this.describeAColumn(table, 'assetdiaryora_start', 'Data e ora di inizio', 'g', 80, null);
						this.describeAColumn(table, 'assetdiaryora_stop', 'Data e ora di fine', 'g', 90, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato avanzamento lavori', null, 150, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato avanzamento lavori', null, 150, null);
//$objCalcFieldConfig_segsal$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idassetdiary", "idworkpackage", "idassetdiaryora"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segsal": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiaryorasegsalview', new meta_assetdiaryorasegsalview('assetdiaryorasegsalview'));

	}());
