(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandodsiscr() {
        MetaData.apply(this, ["bandodsiscr"]);
        this.name = 'meta_bandodsiscr';
    }

    meta_bandodsiscr.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodsiscr,
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
						this.describeAColumn(table, 'cfbonus', 'Crediti bonus', 'fixed.2', 20, null);
						this.describeAColumn(table, '!idaccreditokind_accreditokind_title', 'Modalità di accredito', null, 31, null);
						objCalcFieldConfig['!idaccreditokind_accreditokind_title'] = { tableNameLookup:'accreditokind', columnNameLookup:'title', columnNamekey:'idaccreditokind' };
//$objCalcFieldConfig_seg$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'cfbonus', 'Crediti bonus', 'fixed.2', 20, null);
						this.describeAColumn(table, '!idaccreditokind_accreditokind_title', 'Modalità di accredito', null, 31, null);
						objCalcFieldConfig['!idaccreditokind_accreditokind_title'] = { tableNameLookup:'accreditokind', columnNameLookup:'title', columnNamekey:'idaccreditokind' };
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandodsiscr");

				//$getNewRowInside$

				dt.autoIncrement('idbandodsiscr', { minimum: 99990001 });

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

    window.appMeta.addMeta('bandodsiscr', new meta_bandodsiscr('bandodsiscr'));

	}());
