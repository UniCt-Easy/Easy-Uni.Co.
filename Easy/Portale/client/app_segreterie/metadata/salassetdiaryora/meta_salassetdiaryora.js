(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_salassetdiaryora() {
        MetaData.apply(this, ["salassetdiaryora"]);
        this.name = 'meta_salassetdiaryora';
    }

    meta_salassetdiaryora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_salassetdiaryora,
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
						this.describeAColumn(table, '!idassetdiaryora_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 12, null);
						this.describeAColumn(table, '!idassetdiaryora_workpackage_title', 'Titolo Workpackage', null, 13, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiary_asset_idinventory', 'Inventario Beni strumentali', null, 13, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiary_asset_ninventory', 'Numero inventario Beni strumentali', null, 14, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiary_asset_idpiece', 'Numero parte Beni strumentali', null, 16, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiary_asset_nassetacquire', 'Descrizione Beni strumentali', null, 17, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiary_asset_rfid', 'Codice RFID Beni strumentali', null, 18, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiary_registry_title', 'Denominazione Anagrafica generale', null, 13, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_start', 'Data e ora di inizio', 'g', 16, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_stop', 'Data e ora di fine', 'g', 18, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_amount', 'Importo', 'fixed.2', 15, null);
						this.describeAColumn(table, '!idassetdiaryora_sal_alias1_start', 'Data di inizio Stato avanzamento lavori', null, 17, null);
						this.describeAColumn(table, '!idassetdiaryora_sal_alias1_stop', 'Data di fine Stato avanzamento lavori', null, 18, null);
						objCalcFieldConfig['!idassetdiaryora_workpackage_raggruppamento'] = { tableNameLookup:'workpackage', columnNameLookup:'raggruppamento', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_workpackage_title'] = { tableNameLookup:'workpackage', columnNameLookup:'title', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiary_asset_idinventory'] = { tableNameLookup:'asset', columnNameLookup:'idinventory', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiary_asset_ninventory'] = { tableNameLookup:'asset', columnNameLookup:'ninventory', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiary_asset_idpiece'] = { tableNameLookup:'asset', columnNameLookup:'idpiece', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiary_asset_nassetacquire'] = { tableNameLookup:'asset', columnNameLookup:'nassetacquire', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiary_asset_rfid'] = { tableNameLookup:'asset', columnNameLookup:'rfid', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiary_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_start'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'start', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_stop'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'stop', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_amount'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'amount', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_sal_alias1_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_sal_alias1_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idassetdiaryora' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idassetdiaryora"].caption = "Ore dei diari d'uso";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_salassetdiaryora");

				//$getNewRowInside$


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

    window.appMeta.addMeta('salassetdiaryora', new meta_salassetdiaryora('salassetdiaryora'));

	}());
