(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfpositioncomportamento() {
        MetaData.apply(this, ["perfpositioncomportamento"]);
        this.name = 'meta_perfpositioncomportamento';
    }

    meta_perfpositioncomportamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfpositioncomportamento,
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
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_title', 'Titolo', null, 23, null);
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_description', 'Descrizione', null, 23, null);
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_title'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'title', columnNamekey:'idperfcomportamento' };
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_description'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'description', columnNamekey:'idperfcomportamento' };
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
               var def = appMeta.Deferred("getNewRow-meta_perfpositioncomportamento");

				//$getNewRowInside$

				dt.autoIncrement('idperfpositioncomportamento', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfpositioncomportamento', new meta_perfpositioncomportamento('perfpositioncomportamento'));

	}());
