(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomipropedeut() {
        MetaData.apply(this, ["bandomipropedeut"]);
        this.name = 'meta_bandomipropedeut';
    }

    meta_bandomipropedeut.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomipropedeut,
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
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice', null, 22, null);
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione', null, 21, null);
						objCalcFieldConfig['!idinsegn_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idinsegn' };
						objCalcFieldConfig['!idinsegn_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idinsegn' };
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice', null, 24, null);
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice', null, 23, null);
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione', null, 23, null);
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
               var def = appMeta.Deferred("getNewRow-meta_bandomipropedeut");

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

    window.appMeta.addMeta('bandomipropedeut', new meta_bandomipropedeut('bandomipropedeut'));

	}());
