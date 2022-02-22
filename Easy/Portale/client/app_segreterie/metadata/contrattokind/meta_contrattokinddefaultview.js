
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

    function meta_contrattokinddefaultview() {
        MetaData.apply(this, ["contrattokinddefaultview"]);
        this.name = 'meta_contrattokinddefaultview';
    }

    meta_contrattokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattokinddefaultview,
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
						this.describeAColumn(table, 'contrattokind_active', 'Attivo', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'contrattokind_oremaxgg', 'Ore di lavoro al giorno massime', null, 30, null);
						this.describeAColumn(table, 'contrattokind_costolordoannuo', 'Costo lordo annuo', 'fixed.2', 200, null);
						this.describeAColumn(table, 'contrattokind_costolordoannuooneri', 'Costo lordo annuo e oneri', 'fixed.2', 210, null);
						this.describeAColumn(table, 'contrattokind_puntiorganico', 'Punti organico', 'fixed.2', 230, null);
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
						return "contrattokind_active desc, title asc ";
					}
					case "default": {
						return "contrattokind_active desc, title asc , contrattokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('contrattokinddefaultview', new meta_contrattokinddefaultview('contrattokinddefaultview'));

	}());
