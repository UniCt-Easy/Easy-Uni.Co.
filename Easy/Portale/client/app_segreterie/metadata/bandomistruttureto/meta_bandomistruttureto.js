(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomistruttureto() {
        MetaData.apply(this, ["bandomistruttureto"]);
        this.name = 'meta_bandomistruttureto';
    }

    meta_bandomistruttureto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomistruttureto,
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
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!idstruttura_strutturakind_title', 'Tipologia', null, 21, null);
						this.describeAColumn(table, '!idstruttura_struttura_codice', 'Codice', null, 20, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_codice'] = { tableNameLookup:'struttura', columnNameLookup:'codice', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!idstruttura_strutturakind_title', 'Tipo', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_codice', 'Codice', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura madre', null, 33, null);
						this.describeAColumn(table, '!idstruttura_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 33, null);
						objCalcFieldConfig['!idstruttura_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idstruttura_registry_title', 'Responsabile', null, 29, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura madre', null, 30, null);
						this.describeAColumn(table, '!idstruttura_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 30, null);
						objCalcFieldConfig['!idstruttura_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idstruttura_struttura_alias1_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!idstruttura_struttura_alias1_codice', 'Codice', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_alias1_title', 'Denominazione Struttura madre', null, 30, null);
						this.describeAColumn(table, '!idstruttura_struttura_alias1_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 30, null);
						objCalcFieldConfig['!idstruttura_struttura_alias1_title'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_alias1_codice'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'codice', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_alias1_title'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_alias1_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
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
						table.columns["idbandomi"].caption = "Bando per la mobilità internazionale";
						table.columns["idstruttura"].caption = "Struttura didattica di accoglienza";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandomistruttureto");

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

    window.appMeta.addMeta('bandomistruttureto', new meta_bandomistruttureto('bandomistruttureto'));

	}());
