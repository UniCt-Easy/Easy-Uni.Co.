(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocostotax() {
        MetaData.apply(this, ["progettotipocostotax"]);
        this.name = 'meta_progettotipocostotax';
    }

    meta_progettotipocostotax.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostotax,
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
						this.describeAColumn(table, '!taxcode_tax_description', 'Descrizione', null, 31, null);
						this.describeAColumn(table, '!taxcode_tax_taxref', 'Codice ritenuta', null, 32, null);
						this.describeAColumn(table, '!taxcode_tax_active', 'Attivo', null, 30, null);
						objCalcFieldConfig['!taxcode_tax_description'] = { tableNameLookup:'tax', columnNameLookup:'description', columnNamekey:'taxcode' };
						objCalcFieldConfig['!taxcode_tax_taxref'] = { tableNameLookup:'tax', columnNameLookup:'taxref', columnNamekey:'taxcode' };
						objCalcFieldConfig['!taxcode_tax_active'] = { tableNameLookup:'tax', columnNameLookup:'active', columnNamekey:'taxcode' };
						this.describeAColumn(table, '!taxcode_tax_description', 'Descrizione', null, 32, null);
						this.describeAColumn(table, '!taxcode_tax_taxref', 'Codice ritenuta', null, 34, null);
						this.describeAColumn(table, '!taxcode_tax_active', 'Attivo', null, 33, null);
						this.describeAColumn(table, '!taxcode_tax_fiscaltaxcodecreditf24ord', 'Fiscaltaxcodecreditf24ord', null, 36, null);
						this.describeAColumn(table, '!taxcode_tax_fiscaltaxcodef24ord', 'Fiscaltaxcodef24ord', null, 37, null);
						objCalcFieldConfig['!taxcode_tax_fiscaltaxcodecreditf24ord'] = { tableNameLookup:'tax', columnNameLookup:'fiscaltaxcodecreditf24ord', columnNamekey:'taxcode' };
						objCalcFieldConfig['!taxcode_tax_fiscaltaxcodef24ord'] = { tableNameLookup:'tax', columnNameLookup:'fiscaltaxcodef24ord', columnNamekey:'taxcode' };
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
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostotax");

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

    window.appMeta.addMeta('progettotipocostotax', new meta_progettotipocostotax('progettotipocostotax'));

	}());
