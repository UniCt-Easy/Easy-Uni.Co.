﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudiostruttura() {
        MetaData.apply(this, ["corsostudiostruttura"]);
        this.name = 'meta_corsostudiostruttura';
    }

    meta_corsostudiostruttura.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudiostruttura,
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
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!idstruttura_strutturakind_title', 'Tipo', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_codice', 'Codice', null, 23, null);
						this.describeAColumn(table, '!idstruttura_struttura_alias1_title', 'Denominazione Struttura madre', null, 30, null);
						this.describeAColumn(table, '!idstruttura_struttura_alias1_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 30, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_codice'] = { tableNameLookup:'struttura', columnNameLookup:'codice', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_alias1_title'] = { tableNameLookup:'struttura_alias1', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_alias1_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
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
						table.columns["idstruttura"].caption = "Struttura";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_corsostudiostruttura");

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

    window.appMeta.addMeta('corsostudiostruttura', new meta_corsostudiostruttura('corsostudiostruttura'));

	}());
