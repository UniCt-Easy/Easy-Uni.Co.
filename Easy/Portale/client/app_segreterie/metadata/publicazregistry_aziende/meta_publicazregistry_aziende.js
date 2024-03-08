﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_publicazregistry_aziende() {
        MetaData.apply(this, ["publicazregistry_aziende"]);
        this.name = 'meta_publicazregistry_aziende';
    }

    meta_publicazregistry_aziende.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazregistry_aziende,
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
						this.describeAColumn(table, '!idreg_aziende_registry_title', 'Denominazione', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_registryclass_description', 'Tipologia', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_registry_cf', 'Codice fiscale', null, 10, null);
						this.describeAColumn(table, '!idreg_aziende_registry_p_iva', 'Partita iva', null, 10, null);
						this.describeAColumn(table, '!idreg_aziende_registry_active', 'attivo', null, 10, null);
						this.describeAColumn(table, '!idreg_aziende_geo_nation_alias2_title', 'Nazionalità', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_ateco_codice', 'Codice Classificazione Ateco', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_ateco_title', 'Titolo Classificazione Ateco', null, 12, null);
						this.describeAColumn(table, '!idreg_aziende_naturagiur_title', 'Natura Giuridica', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_numerodip_title', 'Numero di dipendenti', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_nace_idnace', 'Codice NACE', null, 11, null);
						this.describeAColumn(table, '!idreg_aziende_nace_activity', 'Activity NACE', null, 12, null);
						this.describeAColumn(table, '!idreg_aziende_registry_aziende_pic', 'Participant Identification Code (PIC)', null, 10, null);
						objCalcFieldConfig['!idreg_aziende_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registryclass_description'] = { tableNameLookup:'registryclass', columnNameLookup:'description', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_geo_nation_alias2_title'] = { tableNameLookup:'geo_nation_alias2', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_ateco_codice'] = { tableNameLookup:'ateco', columnNameLookup:'codice', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_ateco_title'] = { tableNameLookup:'ateco', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_naturagiur_title'] = { tableNameLookup:'naturagiur', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_numerodip_title'] = { tableNameLookup:'numerodip', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_nace_idnace'] = { tableNameLookup:'nace', columnNameLookup:'idnace', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_nace_activity'] = { tableNameLookup:'nace', columnNameLookup:'activity', columnNamekey:'idreg_aziende' };
						objCalcFieldConfig['!idreg_aziende_registry_aziende_pic'] = { tableNameLookup:'registry_aziende', columnNameLookup:'pic', columnNamekey:'idreg_aziende' };
						this.describeAColumn(table, '!idreg_aziende_registry_title', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idreg_aziende_registryclass_description', 'Tipologia', null, 13, null);
						this.describeAColumn(table, '!idreg_aziende_registry_cf', 'Codice fiscale', null, 14, null);
						this.describeAColumn(table, '!idreg_aziende_registry_p_iva', 'Partita iva', null, 15, null);
						this.describeAColumn(table, '!idreg_aziende_registry_active', 'attivo', null, 16, null);
						this.describeAColumn(table, '!idreg_aziende_geo_nation_alias2_title', 'Nazionalità', null, 22, null);
						this.describeAColumn(table, '!idreg_aziende_registry_flag_pa', 'Ente pubblico', null, 110, null);
						this.describeAColumn(table, '!idreg_aziende_ateco_codice', 'Codice Classificazione Ateco', null, 18, null);
						this.describeAColumn(table, '!idreg_aziende_ateco_title', 'Titolo Classificazione Ateco', null, 19, null);
						this.describeAColumn(table, '!idreg_aziende_naturagiur_title', 'Natura Giuridica', null, 19, null);
						this.describeAColumn(table, '!idreg_aziende_numerodip_title', 'Numero di dipendenti', null, 20, null);
						this.describeAColumn(table, '!idreg_aziende_nace_idnace', 'Codice NACE', null, 21, null);
						this.describeAColumn(table, '!idreg_aziende_nace_activity', 'Activity NACE', null, 22, null);
						this.describeAColumn(table, '!idreg_aziende_registry_aziende_pic', 'Participant Identification Code (PIC)', null, 22, null);
						objCalcFieldConfig['!idreg_aziende_registry_flag_pa'] = { tableNameLookup:'registry', columnNameLookup:'flag_pa', columnNamekey:'idreg_aziende' };
						this.describeAColumn(table, '!idreg_aziende_nace_idnace', 'Identificativo NACE', null, 21, null);
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
						table.columns["idpublicaz"].caption = "Publicazione";
						table.columns["idreg_aziende"].caption = "Ente promotore";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_publicazregistry_aziende");

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

    window.appMeta.addMeta('publicazregistry_aziende', new meta_publicazregistry_aziende('publicazregistry_aziende'));

	}());
