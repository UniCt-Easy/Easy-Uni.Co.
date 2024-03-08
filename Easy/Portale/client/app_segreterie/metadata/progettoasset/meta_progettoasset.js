(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoasset() {
        MetaData.apply(this, ["progettoasset"]);
        this.name = 'meta_progettoasset';
    }

    meta_progettoasset.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoasset,
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
						this.describeAColumn(table, 'idpiece', 'Bene strumentale', null, 20, null);
						this.describeAColumn(table, 'costoorario', 'Costo orario', 'fixed.2', 70, null);
						this.describeAColumn(table, 'aggiunta', 'Costo orario aggiuntivo o sostitutivo al costo di ammortamento', null, 80, null);
						this.describeAColumn(table, 'start', 'Data di inizio utilizzo preventivata', null, 100, null);
						this.describeAColumn(table, 'stop', 'Data di fine utilizzo preventivata', null, 110, null);
						this.describeAColumn(table, 'ammortamentopreventivato', 'Ammortamento preventivato', 'fixed.2', 120, null);
						this.describeAColumn(table, '!ammortamento', 'Ammortamento rendicontato', null, 130, null);
						this.describeAColumn(table, '!idasset-idpiece_inventory_codeinventory', 'Codice Inventario', null, 22, null);
						this.describeAColumn(table, '!idasset-idpiece_inventory_description', 'Descrizione Inventario', null, 23, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_ninventory', 'Numero inventario', null, 24, null);
						this.describeAColumn(table, '!idasset-idpiece_assetacquire_description', 'Descrizione', null, 26, null);
						this.describeAColumn(table, '!idasset-idpiece_assetacquire_inventorytree_codeinv', 'Codice Classificazione inventariale', null, 26, null);
						this.describeAColumn(table, '!idasset-idpiece_assetacquire_inventorytree_description', 'Denominazione Classificazione inventariale', null, 27, null);
						this.describeAColumn(table, '!idasset-idpiece_assetacquire_upb_codeupb', 'Codice Unità previsionali di base', null, 26, null);
						this.describeAColumn(table, '!idasset-idpiece_assetacquire_upb_title', 'Denominazione Unità previsionali di base', null, 27, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_rfid', 'Codice RFID', null, 32, null);
						this.describeAColumn(table, '!idasset-idpiece_asset_lifestart', 'Data inizio esistenza', null, 27, null);
						objCalcFieldConfig['!idasset-idpiece_inventory_codeinventory'] = { tableNameLookup:'inventory', columnNameLookup:'codeinventory', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_inventory_description'] = { tableNameLookup:'inventory', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_ninventory'] = { tableNameLookup:'asset', columnNameLookup:'ninventory', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_assetacquire_description'] = { tableNameLookup:'assetacquire', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_assetacquire_inventorytree_codeinv'] = { tableNameLookup:'inventorytree', columnNameLookup:'codeinv', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_assetacquire_inventorytree_description'] = { tableNameLookup:'inventorytree', columnNameLookup:'description', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_assetacquire_upb_codeupb'] = { tableNameLookup:'upb', columnNameLookup:'codeupb', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_assetacquire_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_rfid'] = { tableNameLookup:'asset', columnNameLookup:'rfid', columnNamekey:'idasset-idpiece' };
						objCalcFieldConfig['!idasset-idpiece_asset_lifestart'] = { tableNameLookup:'asset', columnNameLookup:'lifestart', columnNamekey:'idasset-idpiece' };
						this.describeAColumn(table, '!idasset-idpiece_asset_lifestart', 'Data inizio esistenza', 'g', 27, null);
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
						table.columns["idpiece"].caption = "Bene strumentale";
						table.columns["!altreupb"].caption = "Cerca anche cespiti di altre UPB ";
						table.columns["!ammortamento"].caption = "Ammortamento rendicontato";
						table.columns["aggiunta"].caption = "Costo orario aggiuntivo o sostitutivo al costo di ammortamento";
						table.columns["ammortamentopreventivato"].caption = "Ammortamento preventivato";
						table.columns["costoorario"].caption = "Costo orario";
						table.columns["descammortamentopreventivato"].caption = "Dati ammortamento preventivato";
						table.columns["idasset"].caption = "Bene";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["start"].caption = "Data di inizio utilizzo preventivata";
						table.columns["stop"].caption = "Data di fine utilizzo preventivata";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoasset");

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

    window.appMeta.addMeta('progettoasset', new meta_progettoasset('progettoasset'));

	}());
