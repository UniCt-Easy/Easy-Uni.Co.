(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_salrendicontattivitaprogettoora() {
        MetaData.apply(this, ["salrendicontattivitaprogettoora"]);
        this.name = 'meta_salrendicontattivitaprogettoora';
    }

    meta_salrendicontattivitaprogettoora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_salrendicontattivitaprogettoora,
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
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_workpackage_alias3_raggruppamento', 'Raggruppamento Workpackage', null, 22, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_workpackage_alias3_title', 'Titolo Workpackage', null, 23, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_data', 'Data', null, 25, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_description', 'Descrizione Attività', null, 27, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_registry_title', 'Denominazione Anagrafica generale', null, 27, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_ore', 'Numero di ore', null, 27, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_sal_alias3_start', 'Data di inizio Stato di avanzamento lavori', null, 34, null);
						this.describeAColumn(table, '!idrendicontattivitaprogettoora_sal_alias3_stop', 'Data di fine Stato di avanzamento lavori', null, 35, null);
						objCalcFieldConfig['!idrendicontattivitaprogettoora_workpackage_alias3_raggruppamento'] = { tableNameLookup:'workpackage_alias3', columnNameLookup:'raggruppamento', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_workpackage_alias3_title'] = { tableNameLookup:'workpackage_alias3', columnNameLookup:'title', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_data'] = { tableNameLookup:'rendicontattivitaprogettoora', columnNameLookup:'data', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_description'] = { tableNameLookup:'rendicontattivitaprogetto_alias1', columnNameLookup:'description', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_rendicontattivitaprogetto_alias1_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_ore'] = { tableNameLookup:'rendicontattivitaprogettoora', columnNameLookup:'ore', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_sal_alias3_start'] = { tableNameLookup:'sal_alias3', columnNameLookup:'start', columnNamekey:'idrendicontattivitaprogettoora' };
						objCalcFieldConfig['!idrendicontattivitaprogettoora_sal_alias3_stop'] = { tableNameLookup:'sal_alias3', columnNameLookup:'stop', columnNamekey:'idrendicontattivitaprogettoora' };
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
						table.columns["idrendicontattivitaprogettoora"].caption = "Ore di attività";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_salrendicontattivitaprogettoora");

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

    window.appMeta.addMeta('salrendicontattivitaprogettoora', new meta_salrendicontattivitaprogettoora('salrendicontattivitaprogettoora'));

	}());
