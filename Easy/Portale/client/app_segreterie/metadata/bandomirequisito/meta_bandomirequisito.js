(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomirequisito() {
        MetaData.apply(this, ["bandomirequisito"]);
        this.name = 'meta_bandomirequisito';
    }

    meta_bandomirequisito.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomirequisito,
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
						this.describeAColumn(table, '!idrequisito_requisito_title', 'Title', null, 21, null);
						this.describeAColumn(table, '!idrequisito_requisito_active', 'Active', null, 20, null);
						this.describeAColumn(table, '!idrequisito_requisito_sortcode', 'Sortcode', null, 20, null);
						objCalcFieldConfig['!idrequisito_requisito_title'] = { tableNameLookup:'requisito', columnNameLookup:'title', columnNamekey:'idrequisito' };
						objCalcFieldConfig['!idrequisito_requisito_active'] = { tableNameLookup:'requisito', columnNameLookup:'active', columnNamekey:'idrequisito' };
						objCalcFieldConfig['!idrequisito_requisito_sortcode'] = { tableNameLookup:'requisito', columnNameLookup:'sortcode', columnNamekey:'idrequisito' };
						this.describeAColumn(table, '!idrequisito_requisito_title', 'Title', null, 23, null);
						this.describeAColumn(table, '!idrequisito_requisito_active', 'Active', null, 23, null);
						this.describeAColumn(table, '!idrequisito_requisito_sortcode', 'Sortcode', null, 24, null);
						this.describeAColumn(table, '!idrequisito_requisito_title', 'Titolo', null, 23, null);
						this.describeAColumn(table, '!idrequisito_requisito_active', 'Attivo', null, 23, null);
						this.describeAColumn(table, '!idrequisito_requisito_sortcode', 'Codice identificativo', null, 24, null);
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
               var def = appMeta.Deferred("getNewRow-meta_bandomirequisito");

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

    window.appMeta.addMeta('bandomirequisito', new meta_bandomirequisito('bandomirequisito'));

	}());
