(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accountvardetail() {
        MetaData.apply(this, ["accountvardetail"]);
        this.name = 'meta_accountvardetail';
    }

    meta_accountvardetail.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accountvardetail,
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
					case 'perf':
						this.describeAColumn(table, '!idacc_account_title', 'Denominazione id voce piano conti (tabella account)', null, 81, null);
						this.describeAColumn(table, '!idacc_account_codeacc', 'Codice conto (tabella account) id voce piano conti (tabella account)', null, 82, null);
						this.describeAColumn(table, '!idacc_account_ayear', 'esercizio id voce piano conti (tabella account)', null, 83, null);
						objCalcFieldConfig['!idacc_account_title'] = { tableNameLookup:'account', columnNameLookup:'title', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_account_codeacc'] = { tableNameLookup:'account', columnNameLookup:'codeacc', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_account_ayear'] = { tableNameLookup:'account', columnNameLookup:'ayear', columnNamekey:'idacc' };
						this.describeAColumn(table, '!idcostpartition_costpartition_title', 'Denominazione id ripartizione dei costi (tabella costpartition)', null, 91, null);
						this.describeAColumn(table, '!idcostpartition_costpartition_description', 'Descrizione id ripartizione dei costi (tabella costpartition)', null, 92, null);
						objCalcFieldConfig['!idcostpartition_costpartition_title'] = { tableNameLookup:'costpartition', columnNameLookup:'title', columnNamekey:'idcostpartition' };
						objCalcFieldConfig['!idcostpartition_costpartition_description'] = { tableNameLookup:'costpartition', columnNameLookup:'description', columnNamekey:'idcostpartition' };
						this.describeAColumn(table, '!idinv_inventorytree_codeinv', 'Codice Idinv', null, 101, null);
						this.describeAColumn(table, '!idinv_inventorytree_description', 'Denominazione Idinv', null, 102, null);
						objCalcFieldConfig['!idinv_inventorytree_codeinv'] = { tableNameLookup:'inventorytree', columnNameLookup:'codeinv', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_inventorytree_description'] = { tableNameLookup:'inventorytree', columnNameLookup:'description', columnNamekey:'idinv' };
//$objCalcFieldConfig_perf$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_accountvardetail");

				//$getNewRowInside$

				dt.autoIncrement('yvar', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('accountvardetail', new meta_accountvardetail('accountvardetail'));

	}());
