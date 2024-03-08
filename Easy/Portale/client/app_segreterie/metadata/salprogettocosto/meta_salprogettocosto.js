(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_salprogettocosto() {
        MetaData.apply(this, ["salprogettocosto"]);
        this.name = 'meta_salprogettocosto';
    }

    meta_salprogettocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_salprogettocosto,
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
						this.describeAColumn(table, '!idprogettocosto_workpackage_alias2_raggruppamento', 'Raggruppamento Workpackage', null, 22, null);
						this.describeAColumn(table, '!idprogettocosto_workpackage_alias2_title', 'Titolo Workpackage', null, 23, null);
						this.describeAColumn(table, '!idprogettocosto_progettotipocosto_title', 'Voce di costo', null, 23, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_amount', 'Importo', 'fixed.2', 23, null);
						this.describeAColumn(table, '!idprogettocosto_contrattokind_title', 'Tipo di contratto', null, 24, null);
						this.describeAColumn(table, '!idprogettocosto_rendicontattivitaprogetto_description', 'Descrizione Attività svolta', null, 26, null);
						this.describeAColumn(table, '!idprogettocosto_rendicontattivitaprogetto_registry_title', 'Denominazione Anagrafica generale', null, 26, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_doc', 'Documento collegato', null, 26, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_docdate', 'Data del documento collegato', null, 27, null);
						this.describeAColumn(table, '!idprogettocosto_expense_description', 'Descrizione Spesa', null, 29, null);
						this.describeAColumn(table, '!idprogettocosto_expense_ymov', 'Anno movimento Spesa', null, 30, null);
						this.describeAColumn(table, '!idprogettocosto_expense_nmov', 'N.movimento Spesa', null, 31, null);
						this.describeAColumn(table, '!idprogettocosto_pettycash_description', 'Descrizione Fondo economale', null, 30, null);
						this.describeAColumn(table, '!idprogettocosto_pettycash_pettycode', 'Codice Fondo economale', null, 31, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_yoperation', 'Esercizio operazione', null, 30, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_noperation', 'Numero operazione', null, 31, null);
						this.describeAColumn(table, '!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_idpiece', 'Bene strumentale Diari di utilizzo di beni strumentali', null, 33, null);
						this.describeAColumn(table, '!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_idreg', 'Operatore Diari di utilizzo di beni strumentali', null, 34, null);
						this.describeAColumn(table, '!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_orepreventivate', 'Ore di utilizzo complessive preventivate Diari di utilizzo di beni strumentali', null, 35, null);
						this.describeAColumn(table, '!idprogettocosto_assetdiaryora_alias2_start', 'Data e ora di inizio Diario d\'uso del bene strumentale', 'g', 34, null);
						this.describeAColumn(table, '!idprogettocosto_assetdiaryora_alias2_stop', 'Data e ora di fine Diario d\'uso del bene strumentale', 'g', 35, null);
						this.describeAColumn(table, '!idprogettocosto_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_idpiece', 'Bene Strumentale Uso dei beni strumentali', null, 34, null);
						this.describeAColumn(table, '!idprogettocosto_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_percentuale', 'Percentuale Uso dei beni strumentali', 'fixed.2', 35, null);
						this.describeAColumn(table, '!idprogettocosto_salprogettoassetworkpackagemese_alias1_mese_title', 'Mese Mesi', null, 34, null);
						this.describeAColumn(table, '!idprogettocosto_salprogettoassetworkpackagemese_alias1_amount', 'Importo Uso del bene strumentale', 'fixed.2', 37, null);
						this.describeAColumn(table, '!idprogettocosto_sal_alias2_start', 'Data di inizio Stato avanzamento lavori', null, 35, null);
						this.describeAColumn(table, '!idprogettocosto_sal_alias2_stop', 'Data di fine Stato avanzamento lavori', null, 36, null);
						objCalcFieldConfig['!idprogettocosto_workpackage_alias2_raggruppamento'] = { tableNameLookup:'workpackage_alias2', columnNameLookup:'raggruppamento', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_workpackage_alias2_title'] = { tableNameLookup:'workpackage_alias2', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_amount'] = { tableNameLookup:'progettocosto', columnNameLookup:'amount', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto', columnNameLookup:'description', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_rendicontattivitaprogetto_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_doc'] = { tableNameLookup:'progettocosto', columnNameLookup:'doc', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_docdate'] = { tableNameLookup:'progettocosto', columnNameLookup:'docdate', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_expense_description'] = { tableNameLookup:'expense', columnNameLookup:'description', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_expense_ymov'] = { tableNameLookup:'expense', columnNameLookup:'ymov', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_expense_nmov'] = { tableNameLookup:'expense', columnNameLookup:'nmov', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_pettycash_description'] = { tableNameLookup:'pettycash', columnNameLookup:'description', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_pettycash_pettycode'] = { tableNameLookup:'pettycash', columnNameLookup:'pettycode', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_yoperation'] = { tableNameLookup:'progettocosto', columnNameLookup:'yoperation', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_noperation'] = { tableNameLookup:'progettocosto', columnNameLookup:'noperation', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_idpiece'] = { tableNameLookup:'assetdiary_alias1', columnNameLookup:'idpiece', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_idreg'] = { tableNameLookup:'assetdiary_alias1', columnNameLookup:'idreg', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_assetdiaryora_alias2_assetdiary_alias1_orepreventivate'] = { tableNameLookup:'assetdiary_alias1', columnNameLookup:'orepreventivate', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_assetdiaryora_alias2_start'] = { tableNameLookup:'assetdiaryora_alias2', columnNameLookup:'start', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_assetdiaryora_alias2_stop'] = { tableNameLookup:'assetdiaryora_alias2', columnNameLookup:'stop', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_idpiece'] = { tableNameLookup:'salprogettoassetworkpackage_alias2', columnNameLookup:'idpiece', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_salprogettoassetworkpackagemese_alias1_salprogettoassetworkpackage_alias2_percentuale'] = { tableNameLookup:'salprogettoassetworkpackage_alias2', columnNameLookup:'percentuale', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_salprogettoassetworkpackagemese_alias1_mese_title'] = { tableNameLookup:'mese', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_salprogettoassetworkpackagemese_alias1_amount'] = { tableNameLookup:'salprogettoassetworkpackagemese_alias1', columnNameLookup:'amount', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_sal_alias2_start'] = { tableNameLookup:'sal_alias2', columnNameLookup:'start', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_sal_alias2_stop'] = { tableNameLookup:'sal_alias2', columnNameLookup:'stop', columnNamekey:'idprogettocosto' };
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
						table.columns["idprogettocosto"].caption = "Dettaglio costo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_salprogettocosto");

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

    window.appMeta.addMeta('salprogettocosto', new meta_salprogettocosto('salprogettocosto'));

	}());
