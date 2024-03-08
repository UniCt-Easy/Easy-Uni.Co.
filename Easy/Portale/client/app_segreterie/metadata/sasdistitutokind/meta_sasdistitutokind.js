(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sasdistitutokind() {
        MetaData.apply(this, ["sasdistitutokind"]);
        this.name = 'meta_sasdistitutokind';
    }

    meta_sasdistitutokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sasdistitutokind,
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
						this.describeAColumn(table, '!idistitutokind_istitutokind_tipoistituto', 'Tipologia', null, 11, null);
						this.describeAColumn(table, '!idistitutokind_istitutokind_tipoistitutoen', 'Tipologia (EN)', null, 10, null);
						this.describeAColumn(table, '!idistitutokind_istitutokind_tipoistitutosigla', 'Sigla', null, 10, null);
						objCalcFieldConfig['!idistitutokind_istitutokind_tipoistituto'] = { tableNameLookup:'istitutokind', columnNameLookup:'tipoistituto', columnNamekey:'idistitutokind' };
						objCalcFieldConfig['!idistitutokind_istitutokind_tipoistitutoen'] = { tableNameLookup:'istitutokind', columnNameLookup:'tipoistitutoen', columnNamekey:'idistitutokind' };
						objCalcFieldConfig['!idistitutokind_istitutokind_tipoistitutosigla'] = { tableNameLookup:'istitutokind', columnNameLookup:'tipoistitutosigla', columnNamekey:'idistitutokind' };
						this.describeAColumn(table, '!idistitutokind_istitutokind_tipoistituto', 'Tipologia', null, 13, null);
						this.describeAColumn(table, '!idistitutokind_istitutokind_tipoistitutoen', 'Tipologia (EN)', null, 13, null);
						this.describeAColumn(table, '!idistitutokind_istitutokind_tipoistitutosigla', 'Sigla', null, 14, null);
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
               var def = appMeta.Deferred("getNewRow-meta_sasdistitutokind");

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

    window.appMeta.addMeta('sasdistitutokind', new meta_sasdistitutokind('sasdistitutokind'));

	}());
