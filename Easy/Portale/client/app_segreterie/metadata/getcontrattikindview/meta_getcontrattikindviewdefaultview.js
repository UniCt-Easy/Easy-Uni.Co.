
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

    function meta_getcontrattikindviewdefaultview() {
        MetaData.apply(this, ["getcontrattikindviewdefaultview"]);
        this.name = 'meta_getcontrattikindviewdefaultview';
    }

    meta_getcontrattikindviewdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcontrattikindviewdefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'title', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo', 'Costolordoannuo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo_ck', 'Costolordoannuo_ck', 'fixed.2', 30, null);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo_inq', 'Costolordoannuo_inq', 'fixed.2', 40, null);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo_stip', 'Costolordoannuo_stip', 'fixed.2', 50, null);
						this.describeAColumn(table, 'getcontrattikindview_costomese', 'Costomese', 'fixed.2', 60, null);
						this.describeAColumn(table, 'getcontrattikindview_costoora', 'Costoora', 'fixed.2', 70, null);
						this.describeAColumn(table, 'contrattokind_title', 'Identificativo', null, 80, 50);
						this.describeAColumn(table, 'getcontrattikindview_oremaxdidatempoparziale', 'Oremaxdidatempoparziale', null, 90, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxdidatempopieno', 'Oremaxdidatempopieno', null, 100, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxgg', 'Oremaxgg', null, 110, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxtempoparziale', 'Oremaxtempoparziale', null, 120, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxtempopieno', 'Oremaxtempopieno', null, 130, null);
						this.describeAColumn(table, 'getcontrattikindview_oremindidatempoparziale', 'Oremindidatempoparziale', null, 140, null);
						this.describeAColumn(table, 'getcontrattikindview_oremindidatempopieno', 'Oremindidatempopieno', null, 150, null);
						this.describeAColumn(table, 'getcontrattikindview_parttime', 'Parttime', null, 160, null);
						this.describeAColumn(table, 'getcontrattikindview_tempdef', 'Tempdef', null, 170, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontrattokind"];
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

    window.appMeta.addMeta('getcontrattikindviewdefaultview', new meta_getcontrattikindviewdefaultview('getcontrattikindviewdefaultview'));

	}());
