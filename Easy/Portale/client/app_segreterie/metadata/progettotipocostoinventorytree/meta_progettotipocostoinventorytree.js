(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocostoinventorytree() {
        MetaData.apply(this, ["progettotipocostoinventorytree"]);
        this.name = 'meta_progettotipocostoinventorytree';
    }

    meta_progettotipocostoinventorytree.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostoinventorytree,
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
						this.describeAColumn(table, '!idinv_inventorytree_codeinv', 'Codice', null, 11, null);
						this.describeAColumn(table, '!idinv_inventorytree_description', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idinv_accmotive_codemotive', 'Codice causale di carico', null, 11, null);
						this.describeAColumn(table, '!idinv_accmotive_title', 'Denominazione causale di carico', null, 12, null);
						objCalcFieldConfig['!idinv_inventorytree_codeinv'] = { tableNameLookup:'inventorytree', columnNameLookup:'codeinv', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_inventorytree_description'] = { tableNameLookup:'inventorytree', columnNameLookup:'description', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idinv' };
						this.describeAColumn(table, '!idinv_inventorytree_codeinv', 'Codice', null, 12, null);
						this.describeAColumn(table, '!idinv_inventorytree_description', 'Denominazione', null, 14, null);
						this.describeAColumn(table, '!idinv_accmotive_codemotive', 'Codice causale di carico', null, 15, null);
						this.describeAColumn(table, '!idinv_accmotive_title', 'Denominazione causale di carico', null, 16, null);
						this.describeAColumn(table, '!idinv_accmotive_alias2_codemotive', 'Codice causale di carico', null, 15, null);
						this.describeAColumn(table, '!idinv_accmotive_alias2_title', 'Denominazione causale di carico', null, 16, null);
						objCalcFieldConfig['!idinv_accmotive_alias2_codemotive'] = { tableNameLookup:'accmotive_alias2', columnNameLookup:'codemotive', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_accmotive_alias2_title'] = { tableNameLookup:'accmotive_alias2', columnNameLookup:'title', columnNamekey:'idinv' };
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
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostoinventorytree");

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

    window.appMeta.addMeta('progettotipocostoinventorytree', new meta_progettotipocostoinventorytree('progettotipocostoinventorytree'));

	}());
