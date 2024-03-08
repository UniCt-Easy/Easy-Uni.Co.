(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_commissregistry_docenti() {
        MetaData.apply(this, ["commissregistry_docenti"]);
        this.name = 'meta_commissregistry_docenti';
    }

    meta_commissregistry_docenti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_commissregistry_docenti,
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
						objCalcFieldConfig['!idreg_docenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_docenti_matricola'] = { tableNameLookup:'registry_docenti', columnNameLookup:'matricola', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_classconsorsuale_title'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idreg_docenti_registry_title', 'Denominazione', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_registry_cf', 'Codice fiscale', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_registry_p_iva', 'Partita iva', null, 35, null);
						this.describeAColumn(table, '!idreg_docenti_registry_active', 'attivo', null, 36, null);
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_matricola', 'Matricola', null, 31, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_codice', 'Codice SASD', null, 33, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_title', 'Settore Artistico Scientifico Disciplinare SASD', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_struttura_title', 'Denominazione Struttura di afferenza', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_registry_alias1_title', 'Istituto, Ente o Azienda', null, 35, null);
						this.describeAColumn(table, '!idreg_docenti_classconsorsuale_title', 'Classe consorsuale', null, 36, null);
						this.describeAColumn(table, '!idreg_docenti_contrattokind_title', 'Tipo', null, 82, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_title', 'Denominazione SASD', null, 34, null);
//$objCalcFieldConfig_default$
						break;
					case 'ingresso':
						this.describeAColumn(table, '!idreg_docenti_registry_title', 'Denominazione', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_registry_cf', 'Codice fiscale', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_registry_p_iva', 'Partita iva', null, 35, null);
						this.describeAColumn(table, '!idreg_docenti_registry_active', 'attivo', null, 36, null);
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_matricola', 'Matricola', null, 31, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_codice', 'Codice SASD', null, 33, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_title', 'Denominazione SASD', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_struttura_title', 'Denominazione Struttura di afferenza', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 34, null);
						this.describeAColumn(table, '!idreg_docenti_registry_alias1_title', 'Istituto, Ente o Azienda', null, 35, null);
						this.describeAColumn(table, '!idreg_docenti_classconsorsuale_title', 'Classe consorsuale', null, 36, null);
						this.describeAColumn(table, '!idreg_docenti_contrattokind_title', 'Tipo', null, 82, null);
						objCalcFieldConfig['!idreg_docenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_docenti_matricola'] = { tableNameLookup:'registry_docenti', columnNameLookup:'matricola', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_classconsorsuale_title'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
//$objCalcFieldConfig_ingresso$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'ingresso':
						table.columns["idreg_docenti"].caption = "Docente membro";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'default':
						table.columns["idreg_docenti"].caption = "Docente membro";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_commissregistry_docenti");

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

    window.appMeta.addMeta('commissregistry_docenti', new meta_commissregistry_docenti('commissregistry_docenti'));

	}());
