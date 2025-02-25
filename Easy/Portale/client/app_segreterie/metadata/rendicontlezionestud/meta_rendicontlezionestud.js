(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontlezionestud() {
        MetaData.apply(this, ["rendicontlezionestud"]);
        this.name = 'meta_rendicontlezionestud';
    }

    meta_rendicontlezionestud.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontlezionestud,
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
						this.describeAColumn(table, 'assente', 'Assente', null, 20, null);
						this.describeAColumn(table, 'ritardo', 'Ritardo', 'g', 30, null);
						this.describeAColumn(table, 'ritardogiustifica', 'Giustificazione del ritardo', null, 40, 1024);
						this.describeAColumn(table, 'notadisciplinare', 'Nota disciplinare', null, 50, 1024);
						this.describeAColumn(table, '!idreg_studenti_registry_title', 'Denominazione', null, 11, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 10, null);
						this.describeAColumn(table, '!idreg_studenti_registry_p_iva', 'Partita iva', null, 10, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 10, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 10, null);
						this.describeAColumn(table, '!idreg_studenti_studdirittokind_title', 'Tipologia per il diritto allo studio', null, 11, null);
						this.describeAColumn(table, '!idreg_studenti_studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 11, null);
						objCalcFieldConfig['!idreg_studenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_studenti_authinps'] = { tableNameLookup:'registry_studenti', columnNameLookup:'authinps', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_studdirittokind_title'] = { tableNameLookup:'studdirittokind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_studprenotkind_title'] = { tableNameLookup:'studprenotkind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						this.describeAColumn(table, '!idreg_studenti_registry_title', 'Denominazione', null, 14, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 14, null);
						this.describeAColumn(table, '!idreg_studenti_registry_p_iva', 'Partita iva', null, 15, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 16, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 40, null);
						this.describeAColumn(table, '!idreg_studenti_studdirittokind_title', 'Tipologia per il diritto allo studio', null, 42, null);
						this.describeAColumn(table, '!idreg_studenti_studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 43, null);
						this.describeAColumn(table, '!idreg_studenti_registryclass_description', 'Tipologia', null, 13, null);
						this.describeAColumn(table, '!idreg_studenti_registry_idanpr', 'Idanpr', null, 29, null);
						this.describeAColumn(table, '!idreg_studenti_ateco_codice', 'Codice Idateco', null, 31, null);
						this.describeAColumn(table, '!idreg_studenti_ateco_title', 'Titolo Idateco', null, 32, null);
						this.describeAColumn(table, '!idreg_studenti_fonteindicebibliometrico_title', 'Idfonteindicebibliometrico', null, 36, null);
						this.describeAColumn(table, '!idreg_studenti_nace_idnace', 'Identificativo Idnace', null, 38, null);
						this.describeAColumn(table, '!idreg_studenti_nace_activity', 'Activity Idnace', null, 39, null);
						this.describeAColumn(table, '!idreg_studenti_naturagiur_title', 'Idnaturagiur', null, 40, null);
						this.describeAColumn(table, '!idreg_studenti_numerodip_title', 'Idnumerodip', null, 41, null);
						this.describeAColumn(table, '!idreg_studenti_registry_alias1_title', 'Idreg_istituti', null, 43, null);
						this.describeAColumn(table, '!idreg_studenti_sasd_codice', 'Codice Idsasd', null, 46, null);
						this.describeAColumn(table, '!idreg_studenti_sasd_title', 'Denominazione Idsasd', null, 47, null);
						this.describeAColumn(table, '!idreg_studenti_struttura_title', 'Denominazione Idstruttura', null, 47, null);
						this.describeAColumn(table, '!idreg_studenti_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 47, null);
						this.describeAColumn(table, '!idreg_studenti_registry_indicebibliometrico', 'Indicebibliometrico', null, 48, null);
						this.describeAColumn(table, '!idreg_studenti_registry_pic', 'Pic', null, 56, null);
						this.describeAColumn(table, '!idreg_studenti_registry_ricevimento', 'Ricevimento', null, 58, null);
						this.describeAColumn(table, '!idreg_studenti_registry_soggiorno', 'Soggiorno', null, 62, null);
						this.describeAColumn(table, '!idreg_studenti_registry_title_en', 'Title_en', null, 64, null);
						objCalcFieldConfig['!idreg_studenti_registryclass_description'] = { tableNameLookup:'registryclass', columnNameLookup:'description', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_idanpr'] = { tableNameLookup:'registry', columnNameLookup:'idanpr', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_ateco_codice'] = { tableNameLookup:'ateco', columnNameLookup:'codice', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_ateco_title'] = { tableNameLookup:'ateco', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_fonteindicebibliometrico_title'] = { tableNameLookup:'fonteindicebibliometrico', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_nace_idnace'] = { tableNameLookup:'nace', columnNameLookup:'idnace', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_nace_activity'] = { tableNameLookup:'nace', columnNameLookup:'activity', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_naturagiur_title'] = { tableNameLookup:'naturagiur', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_numerodip_title'] = { tableNameLookup:'numerodip', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_indicebibliometrico'] = { tableNameLookup:'registry', columnNameLookup:'indicebibliometrico', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_pic'] = { tableNameLookup:'registry', columnNameLookup:'pic', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_ricevimento'] = { tableNameLookup:'registry', columnNameLookup:'ricevimento', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_soggiorno'] = { tableNameLookup:'registry', columnNameLookup:'soggiorno', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_title_en'] = { tableNameLookup:'registry', columnNameLookup:'title_en', columnNamekey:'idreg_studenti' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontlezionestud");

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

    window.appMeta.addMeta('rendicontlezionestud', new meta_rendicontlezionestud('rendicontlezionestud'));

	}());
