
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

    function meta_assetdiary() {
        MetaData.apply(this, ["assetdiary"]);
        this.name = 'meta_assetdiary';
    }

    meta_assetdiary.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiary,
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
					case 'seganag':
						this.describeAColumn(table, 'orepreventivate', 'Ore di utilizzo complessive preventivate', null, 60, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_ninventory', 'Numero inventario Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idasset', 'Identificativo Bene strumentale', null, 13, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idpiece', 'Numero parte Bene strumentale', null, 14, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_rfid', 'Codice RFID Bene strumentale', null, 16, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_description', 'Descrizione Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_nassetacquire_description', 'Descrizione Bene strumentale', null, 11, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_nassetacquire_idinv', 'Class. Inv. Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_nassetacquire_idupb', 'UPB Bene strumentale', null, 13, null);
						objCalcFieldConfig['!idasset-idpiece_asset_ninventory'] = { tableNameLookup:'asset', columnNameLookup:'ninventory', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_idasset'] = { tableNameLookup:'asset', columnNameLookup:'idasset', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_idpiece'] = { tableNameLookup:'asset', columnNameLookup:'idpiece', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_rfid'] = { tableNameLookup:'asset', columnNameLookup:'rfid', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_idinventory_description'] = { tableNameLookup:'inventory', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_nassetacquire_description'] = { tableNameLookup:'assetacquire', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_nassetacquire_idinv'] = { tableNameLookup:'assetacquire', columnNameLookup:'idinv', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_nassetacquire_idupb'] = { tableNameLookup:'assetacquire', columnNameLookup:'idupb', columnNamekey:'idasset-idpiece' };
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Progetto', null, 31, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 51, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 52, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage', columnNameLookup:'title', columnNamekey:'idworkpackage' };
//$objCalcFieldConfig_seganag$
						break;
					case 'seg':
						this.describeAColumn(table, 'orepreventivate', 'Ore di utilizzo complessive preventivate', null, 50, null);
						this.describeAColumn(table, '!amount', 'Costo di ammortamento calcolato', null, 60, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_ninventory', 'Numero inventario Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idasset', 'Identificativo Bene strumentale', null, 13, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idpiece', 'Numero parte Bene strumentale', null, 14, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_rfid', 'Codice RFID Bene strumentale', null, 16, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_description', 'Descrizione Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_nassetacquire_description', 'Descrizione Bene strumentale', null, 11, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_nassetacquire_idinv', 'Class. Inv. Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_nassetacquire_idupb', 'UPB Bene strumentale', null, 13, null);
						objCalcFieldConfig['!idasset-idpiece_asset_ninventory'] = { tableNameLookup:'asset', columnNameLookup:'ninventory', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_idasset'] = { tableNameLookup:'asset', columnNameLookup:'idasset', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_idpiece'] = { tableNameLookup:'asset', columnNameLookup:'idpiece', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_rfid'] = { tableNameLookup:'asset', columnNameLookup:'rfid', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_idinventory_description'] = { tableNameLookup:'inventory', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_nassetacquire_description'] = { tableNameLookup:'assetacquire', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_nassetacquire_idinv'] = { tableNameLookup:'assetacquire', columnNameLookup:'idinv', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_nassetacquire_idupb'] = { tableNameLookup:'assetacquire', columnNameLookup:'idupb', columnNamekey:'idasset-idpiece' };
						this.describeAColumn(table, '!idreg_registry_title', 'Operatore', null, 41, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_seg$
						break;
					case 'docente':
						this.describeAColumn(table, 'orepreventivate', 'Ore di utilizzo complessive preventivate', null, 60, null);
//$objCalcFieldConfig_docente$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seganag':
						table.columns["idpiece"].caption = "Bene strumentale";
						table.columns["idasset"].caption = "Bene strumentale";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Operatore";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Ore di utilizzo complessive preventivate";
//$innerSetCaptionConfig_seganag$
						break;
					case 'seg':
						table.columns["idpiece"].caption = "Bene strumentale";
						table.columns["idasset"].caption = "Bene strumentale";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Operatore";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Ore di utilizzo complessive preventivate";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
//$innerSetCaptionConfig_seg$
						break;
					case 'docente':
						table.columns["idpiece"].caption = "Bene strumentale";
//$innerSetCaptionConfig_docente$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_assetdiary");

				//$getNewRowInside$

				dt.autoIncrement('idassetdiary', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docente": {
						return "idprogetto asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiary', new meta_assetdiary('assetdiary'));

	}());
