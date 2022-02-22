
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

    function meta_assetdiarydocenteview() {
        MetaData.apply(this, ["assetdiarydocenteview"]);
        this.name = 'meta_assetdiarydocenteview';
    }

    meta_assetdiarydocenteview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiarydocenteview,
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
					case 'docente':
						this.describeAColumn(table, 'inventory_description', 'Descrizione Inventario Bene strumentale', null, 1120, 50);
						this.describeAColumn(table, 'asset_ninventory', 'Numero inventario Bene strumentale', null, 1200, null);
						this.describeAColumn(table, 'asset_idasset', 'Identificativo Bene strumentale', null, 1300, null);
						this.describeAColumn(table, 'asset_idpiece', 'Numero parte Bene strumentale', null, 1400, null);
						this.describeAColumn(table, 'assetacquire_description', 'Descrizione Descrizione Bene strumentale', null, 1510, 150);
						this.describeAColumn(table, 'asset_rfid', 'Codice RFID Bene strumentale', null, 1600, 30);
						this.describeAColumn(table, 'progetto_titolobreve', 'Progetto', null, 3500, 2048);
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 5100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 5200, 2048);
						this.describeAColumn(table, 'assetdiary_orepreventivate', 'Ore di utilizzo complessive preventivate', null, 6000, null);
//$objCalcFieldConfig_docente$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idassetdiary", "idworkpackage"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docente": {
						return "progetto_titolobreve asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('assetdiarydocenteview', new meta_assetdiarydocenteview('assetdiarydocenteview'));

	}());
