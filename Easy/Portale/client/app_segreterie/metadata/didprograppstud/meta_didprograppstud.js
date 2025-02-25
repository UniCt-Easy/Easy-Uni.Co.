(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprograppstud() {
        MetaData.apply(this, ["didprograppstud"]);
        this.name = 'meta_didprograppstud';
    }

    meta_didprograppstud.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprograppstud,
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
						this.describeAColumn(table, '!idreg_studenti_registry_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_p_iva', 'Partita iva', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 20, null);
						this.describeAColumn(table, '!idreg_studenti_studdirittokind_title', 'Tipologia per il diritto allo studio', null, 21, null);
						this.describeAColumn(table, '!idreg_studenti_studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 21, null);
						objCalcFieldConfig['!idreg_studenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_studenti_authinps'] = { tableNameLookup:'registry_studenti', columnNameLookup:'authinps', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_studdirittokind_title'] = { tableNameLookup:'studdirittokind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_studprenotkind_title'] = { tableNameLookup:'studprenotkind', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						this.describeAColumn(table, '!idreg_studenti_registry_title', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idreg_studenti_registry_cf', 'Codice fiscale', null, 24, null);
						this.describeAColumn(table, '!idreg_studenti_registry_p_iva', 'Partita iva', null, 25, null);
						this.describeAColumn(table, '!idreg_studenti_registry_active', 'attivo', null, 26, null);
						this.describeAColumn(table, '!idreg_studenti_registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 50, null);
						this.describeAColumn(table, '!idreg_studenti_studdirittokind_title', 'Tipologia per il diritto allo studio', null, 52, null);
						this.describeAColumn(table, '!idreg_studenti_studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 53, null);
						this.describeAColumn(table, '!idreg_studenti_registry_surname', 'Cognome', null, 21, null);
						this.describeAColumn(table, '!idreg_studenti_registry_forename', 'Nome', null, 22, null);
						this.describeAColumn(table, '!idreg_studenti_registry_extmatricula', 'Matricola', null, 25, null);
						objCalcFieldConfig['!idreg_studenti_registry_surname'] = { tableNameLookup:'registry', columnNameLookup:'surname', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_forename'] = { tableNameLookup:'registry', columnNameLookup:'forename', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_extmatricula'] = { tableNameLookup:'registry', columnNameLookup:'extmatricula', columnNamekey:'idreg_studenti' };
						this.describeAColumn(table, '!idreg_studenti_registryclass_description', 'Tipologia', null, 23, null);
						this.describeAColumn(table, '!idreg_studenti_ateco_codice', 'Codice Idateco', null, 40, null);
						this.describeAColumn(table, '!idreg_studenti_ateco_title', 'Titolo Idateco', null, 41, null);
						this.describeAColumn(table, '!idreg_studenti_fonteindicebibliometrico_title', 'Idfonteindicebibliometrico', null, 45, null);
						this.describeAColumn(table, '!idreg_studenti_nace_idnace', 'Identificativo Idnace', null, 47, null);
						this.describeAColumn(table, '!idreg_studenti_nace_activity', 'Activity Idnace', null, 48, null);
						this.describeAColumn(table, '!idreg_studenti_naturagiur_title', 'Idnaturagiur', null, 49, null);
						this.describeAColumn(table, '!idreg_studenti_numerodip_title', 'Idnumerodip', null, 50, null);
						this.describeAColumn(table, '!idreg_studenti_registry_alias1_title', 'Idreg_istituti', null, 52, null);
						this.describeAColumn(table, '!idreg_studenti_sasd_alias1_codice', 'Codice Idsasd', null, 55, null);
						this.describeAColumn(table, '!idreg_studenti_sasd_alias1_title', 'Denominazione Idsasd', null, 56, null);
						this.describeAColumn(table, '!idreg_studenti_struttura_title', 'Denominazione Idstruttura', null, 56, null);
						this.describeAColumn(table, '!idreg_studenti_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 56, null);
						this.describeAColumn(table, '!idreg_studenti_registry_indicebibliometrico', 'Indicebibliometrico', null, 57, null);
						this.describeAColumn(table, '!idreg_studenti_registry_pic', 'Pic', null, 65, null);
						this.describeAColumn(table, '!idreg_studenti_registry_ricevimento', 'Ricevimento', null, 67, null);
						this.describeAColumn(table, '!idreg_studenti_registry_soggiorno', 'Soggiorno', null, 71, null);
						this.describeAColumn(table, '!idreg_studenti_registry_title_en', 'Title_en', null, 73, null);
						objCalcFieldConfig['!idreg_studenti_registryclass_description'] = { tableNameLookup:'registryclass', columnNameLookup:'description', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_ateco_codice'] = { tableNameLookup:'ateco', columnNameLookup:'codice', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_ateco_title'] = { tableNameLookup:'ateco', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_fonteindicebibliometrico_title'] = { tableNameLookup:'fonteindicebibliometrico', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_nace_idnace'] = { tableNameLookup:'nace', columnNameLookup:'idnace', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_nace_activity'] = { tableNameLookup:'nace', columnNameLookup:'activity', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_naturagiur_title'] = { tableNameLookup:'naturagiur', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_numerodip_title'] = { tableNameLookup:'numerodip', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_sasd_alias1_codice'] = { tableNameLookup:'sasd_alias1', columnNameLookup:'codice', columnNamekey:'idreg_studenti' };
						objCalcFieldConfig['!idreg_studenti_sasd_alias1_title'] = { tableNameLookup:'sasd_alias1', columnNameLookup:'title', columnNamekey:'idreg_studenti' };
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
               var def = appMeta.Deferred("getNewRow-meta_didprograppstud");

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

    window.appMeta.addMeta('didprograppstud', new meta_didprograppstud('didprograppstud'));

	}());
