(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomiistitutiesteri() {
        MetaData.apply(this, ["bandomiistitutiesteri"]);
        this.name = 'meta_bandomiistitutiesteri';
    }

    meta_bandomiistitutiesteri.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomiistitutiesteri,
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
					case 'seg':
						this.describeAColumn(table, 'idreg_istitutiesteri', 'Istituto', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registryclass_description', 'Tipologia', null, 23, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_cf', 'Codice fiscale', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_p_iva', 'Partita iva', null, 25, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_active', 'attivo', null, 26, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_acronim', 'Acronim', null, 28, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_code', 'Code', null, 29, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_codicemiur', 'Codicemiur', null, 30, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_codiceustat', 'Codiceustat', null, 31, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_idanpr', 'Idanpr', null, 32, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_ateco_codice', 'Codice Idateco', null, 34, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_ateco_title', 'Titolo Idateco', null, 35, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_fonteindicebibliometrico_title', 'Idfonteindicebibliometrico', null, 35, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_istitutokind_tipoistituto', 'Idistitutokind', null, 36, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_nace_idnace', 'Identificativo Idnace', null, 37, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_nace_activity', 'Activity Idnace', null, 38, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_naturagiur_title', 'Idnaturagiur', null, 38, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_numerodip_title', 'Idnumerodip', null, 39, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_alias1_title', 'Idreg_istituti', null, 40, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_sasd_codice', 'Codice Idsasd', null, 41, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_sasd_title', 'Denominazione Idsasd', null, 42, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_struttura_title', 'Denominazione Idstruttura', null, 42, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 42, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_indicebibliometrico', 'Indicebibliometrico', null, 42, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_institutionalcode', 'Institutionalcode', null, 43, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_pic', 'Pic', null, 44, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_referencenumber', 'Referencenumber', null, 45, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_ricevimento', 'Ricevimento', null, 46, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_soggiorno', 'Soggiorno', null, 47, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title_en', 'Title_en', null, 48, null);
						objCalcFieldConfig['!idreg_istitutiesteri_registryclass_description'] = { tableNameLookup:'registryclass', columnNameLookup:'description', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_acronim'] = { tableNameLookup:'registry', columnNameLookup:'acronim', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_code'] = { tableNameLookup:'registry', columnNameLookup:'code', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_codicemiur'] = { tableNameLookup:'registry', columnNameLookup:'codicemiur', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_codiceustat'] = { tableNameLookup:'registry', columnNameLookup:'codiceustat', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_idanpr'] = { tableNameLookup:'registry', columnNameLookup:'idanpr', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_ateco_codice'] = { tableNameLookup:'ateco', columnNameLookup:'codice', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_ateco_title'] = { tableNameLookup:'ateco', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_fonteindicebibliometrico_title'] = { tableNameLookup:'fonteindicebibliometrico', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_istitutokind_tipoistituto'] = { tableNameLookup:'istitutokind', columnNameLookup:'tipoistituto', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_nace_idnace'] = { tableNameLookup:'nace', columnNameLookup:'idnace', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_nace_activity'] = { tableNameLookup:'nace', columnNameLookup:'activity', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_naturagiur_title'] = { tableNameLookup:'naturagiur', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_numerodip_title'] = { tableNameLookup:'numerodip', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_indicebibliometrico'] = { tableNameLookup:'registry', columnNameLookup:'indicebibliometrico', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_institutionalcode'] = { tableNameLookup:'registry', columnNameLookup:'institutionalcode', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_pic'] = { tableNameLookup:'registry', columnNameLookup:'pic', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_referencenumber'] = { tableNameLookup:'registry', columnNameLookup:'referencenumber', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_ricevimento'] = { tableNameLookup:'registry', columnNameLookup:'ricevimento', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_soggiorno'] = { tableNameLookup:'registry', columnNameLookup:'soggiorno', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_title_en'] = { tableNameLookup:'registry', columnNameLookup:'title_en', columnNamekey:'idreg_istitutiesteri' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idreg_istitutiesteri"].caption = "Istituto";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandomiistitutiesteri");

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

    window.appMeta.addMeta('bandomiistitutiesteri', new meta_bandomiistitutiesteri('bandomiistitutiesteri'));

	}());
