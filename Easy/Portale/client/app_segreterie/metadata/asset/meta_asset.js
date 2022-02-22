
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_asset() {
        MetaData.apply(this, ["asset"]);
        this.name = 'meta_asset';
    }

    meta_asset.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_asset,
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
					case 'seg':
						this.describeAColumn(table, 'ninventory', 'Numero inventario', null, 20, null);
						this.describeAColumn(table, 'idasset', 'Identificativo', null, 30, null);
						this.describeAColumn(table, 'idpiece', 'Numero parte', null, 40, null);
						this.describeAColumn(table, 'rfid', 'Codice RFID', null, 60, 30);
						this.describeAColumn(table, 'lifestart', 'Data inizio esistenza', null, 70, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idasset"].caption = "Identificativo";
						table.columns["idinventory"].caption = "Inventario";
						table.columns["idpiece"].caption = "Numero parte";
						table.columns["lifestart"].caption = "Data inizio esistenza";
						table.columns["nassetacquire"].caption = "Descrizione";
						table.columns["ninventory"].caption = "Numero inventario";
						table.columns["rfid"].caption = "Codice RFID";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_asset");

				//$getNewRowInside$

				dt.autoIncrement('idasset', { minimum: 99990001 });
				dt.autoIncrement('idpiece', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('asset', new meta_asset('asset'));

	}());
