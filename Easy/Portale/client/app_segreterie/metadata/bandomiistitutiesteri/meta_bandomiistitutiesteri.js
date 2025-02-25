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
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_cf', 'Codice fiscale', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_p_iva', 'Partita iva', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_active', 'attivo', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_city_title', 'Città', null, 21, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_nation_title', 'Nazione', null, 21, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_name', 'Name', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_city', 'City', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_code', 'Code', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode', 'Institutional code', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_referencenumber', 'Reference number', null, 20, null);
						objCalcFieldConfig['!idreg_istitutiesteri_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_geo_city_title'] = { tableNameLookup:'geo_city', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_geo_nation_title'] = { tableNameLookup:'geo_nation', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_name'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'name', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_city'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'city', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_code'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'code', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'institutionalcode', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_referencenumber'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'referencenumber', columnNamekey:'idreg_istitutiesteri' };
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_cf', 'Codice fiscale', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_p_iva', 'Partita iva', null, 25, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_active', 'attivo', null, 26, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_city_title', 'Città', null, 28, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_nation_title', 'Nazione', null, 29, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_name', 'Name', null, 22, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_city', 'City', null, 23, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_code', 'Code', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode', 'Institutional code', null, 25, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_referencenumber', 'Reference number', null, 26, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_ateco_codice', 'Codice Idateco', null, 40, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_ateco_title', 'Titolo Idateco', null, 41, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_fonteindicebibliometrico_title', 'Idfonteindicebibliometrico', null, 45, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_nace_idnace', 'Identificativo Idnace', null, 47, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_nace_activity', 'Activity Idnace', null, 48, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_naturagiur_title', 'Idnaturagiur', null, 49, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_numerodip_title', 'Idnumerodip', null, 50, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_alias1_title', 'Idreg_istituti', null, 52, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_sasd_codice', 'Codice Idsasd', null, 55, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_sasd_title', 'Denominazione Idsasd', null, 56, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_struttura_title', 'Denominazione Idstruttura', null, 56, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 56, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_indicebibliometrico', 'Indicebibliometrico', null, 57, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_pic', 'Pic', null, 65, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_ricevimento', 'Ricevimento', null, 67, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_soggiorno', 'Soggiorno', null, 71, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title_en', 'Title_en', null, 73, null);
						objCalcFieldConfig['!idreg_istitutiesteri_ateco_codice'] = { tableNameLookup:'ateco', columnNameLookup:'codice', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_ateco_title'] = { tableNameLookup:'ateco', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_fonteindicebibliometrico_title'] = { tableNameLookup:'fonteindicebibliometrico', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
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
						objCalcFieldConfig['!idreg_istitutiesteri_registry_pic'] = { tableNameLookup:'registry', columnNameLookup:'pic', columnNamekey:'idreg_istitutiesteri' };
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


			//$setCaptions$

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
