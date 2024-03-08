(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_afferenza() {
        MetaData.apply(this, ["afferenza"]);
        this.name = 'meta_afferenza';
    }

    meta_afferenza.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_afferenza,
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
					case 'doc':
						this.describeAColumn(table, 'start', 'Dal', null, 40, null);
						this.describeAColumn(table, 'stop', 'Al', null, 50, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Struttura', null, 11, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_doc$
						break;
					case 'amm':
						this.describeAColumn(table, 'start', 'Dal', 'g', 40, null);
						this.describeAColumn(table, 'stop', 'Al', 'g', 50, null);
						this.describeAColumn(table, '!idmansionekind_mansionekind_title', 'Mansione', null, 101, null);
						objCalcFieldConfig['!idmansionekind_mansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idmansionekind' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione U.O.', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_paridstruttura', 'U.O. madre U.O.', null, 12, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_paridstruttura'] = { tableNameLookup:'struttura', columnNameLookup:'paridstruttura', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_amm$
						break;
					case 'docente':
						this.describeAColumn(table, 'start', 'Dal', 'g', 40, null);
						this.describeAColumn(table, 'stop', 'Al', 'g', 50, null);
						this.describeAColumn(table, '!idmansionekind_mansionekind_title', 'Mansione', null, 101, null);
						objCalcFieldConfig['!idmansionekind_mansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idmansionekind' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipo Struttura', null, 10, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_docente$
						break;
					case 'stru':
						this.describeAColumn(table, 'start', 'Dal ', 'g', 50, null);
						this.describeAColumn(table, 'stop', 'Al ', 'g', 60, null);
						this.describeAColumn(table, '!idmansionekind_mansionekind_title', 'Mansione', null, 21, null);
						objCalcFieldConfig['!idmansionekind_mansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idmansionekind' };
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Membro del personale', null, 11, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Membro del personale', null, 12, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Membro del personale', null, 13, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Membro del personale', null, 14, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
//$objCalcFieldConfig_stru$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'docente':
						table.columns["idmansionekind"].caption = "Mansione";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["start"].caption = "Dal";
						table.columns["stop"].caption = "Al";
//$innerSetCaptionConfig_docente$
						break;
					case 'amm':
						table.columns["idmansionekind"].caption = "Mansione";
						table.columns["idstruttura"].caption = "U.O.";
//$innerSetCaptionConfig_amm$
						break;
					case 'stru':
						table.columns["idmansionekind"].caption = "Mansione";
						table.columns["idreg"].caption = "Membro del personale";
						table.columns["start"].caption = "Dal ";
						table.columns["stop"].caption = "Al ";
//$innerSetCaptionConfig_stru$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_afferenza");

				//$getNewRowInside$

				dt.autoIncrement('idafferenza', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('afferenza', new meta_afferenza('afferenza'));

	}());
