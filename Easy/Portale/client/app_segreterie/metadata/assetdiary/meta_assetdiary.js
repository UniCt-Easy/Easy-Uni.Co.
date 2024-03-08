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
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_description', 'Inventario Bene strumentale', null, 10, null);
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
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_codeinventory', 'Codice Bene strumentale', null, 11, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_description', 'Descrizione Bene strumentale', null, 12, null);
						objCalcFieldConfig['!idasset-idpiece_asset_idinventory_codeinventory'] = { tableNameLookup:'inventory', columnNameLookup:'codeinventory', columnNamekey:'idasset-idpiece' };
//$objCalcFieldConfig_seganag$
						break;
					case 'seg':
						this.describeAColumn(table, 'orepreventivate', 'Ore di utilizzo complessive preventivate', null, 50, null);
						this.describeAColumn(table, '!amount', 'Costo di ammortamento calcolato', null, 60, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_ninventory', 'Numero inventario Bene strumentale', null, 12, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idasset', 'Identificativo Bene strumentale', null, 13, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idpiece', 'Numero parte Bene strumentale', null, 14, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_rfid', 'Codice RFID Bene strumentale', null, 16, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_description', 'Inventario Bene strumentale', null, 10, null);
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
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Operatore', null, 41, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Operatore', null, 42, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Operatore', null, 43, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Operatore', null, 44, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_codeinventory', 'Codice Bene strumentale', null, 11, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_idinventory_description', 'Descrizione Bene strumentale', null, 12, null);
						objCalcFieldConfig['!idasset-idpiece_asset_idinventory_codeinventory'] = { tableNameLookup:'inventory', columnNameLookup:'codeinventory', columnNamekey:'idasset-idpiece' };
//$objCalcFieldConfig_seg$
						break;
					case 'docente':
						this.describeAColumn(table, 'orepreventivate', 'Ore di utilizzo complessive preventivate', null, 60, null);
//$objCalcFieldConfig_docente$
						break;
					case 'segsal':
						this.describeAColumn(table, 'orepreventivate', 'Ore di utilizzo complessive preventivate', null, 60, null);
//$objCalcFieldConfig_segsal$
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
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
						table.columns["!amount"].caption = "Costo di ammortamento calcolato";
//$innerSetCaptionConfig_seg$
						break;
					case 'docente':
//$innerSetCaptionConfig_docente$
						break;
					case 'segsal':
						table.columns["idasset"].caption = "Bene strumentale";
						table.columns["idpiece"].caption = "Parte";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Operatore";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Ore di utilizzo complessive preventivate";
//$innerSetCaptionConfig_segsal$
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
					case "segsal": {
						return "idreg asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiary', new meta_assetdiary('assetdiary'));

	}());
