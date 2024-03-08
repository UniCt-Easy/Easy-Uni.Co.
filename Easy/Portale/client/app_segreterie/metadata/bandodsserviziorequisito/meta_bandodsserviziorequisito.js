(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandodsserviziorequisito() {
        MetaData.apply(this, ["bandodsserviziorequisito"]);
        this.name = 'meta_bandodsserviziorequisito';
    }

    meta_bandodsserviziorequisito.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodsserviziorequisito,
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
						this.describeAColumn(table, 'cfbonus', 'Crediti formativi massimi di bonus che si possono richiedere ', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfbonushp', 'Crediti formativi massimi di bonus che si possono richiedere per portatori di handicap ', 'fixed.2', 30, null);
						this.describeAColumn(table, 'cfconseguiti', 'Crediti formativi minimi conseguiti negli anni accademici precedenti ', 'fixed.2', 40, null);
						this.describeAColumn(table, 'cfconseguitihp', 'Crediti formativi minimi conseguiti negli anni accademici precedenti per portatori di handicap ', 'fixed.2', 50, null);
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
				var def = appMeta.Deferred("getNewRow-meta_bandodsserviziorequisito");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idbandodsserviziorequisito', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('bandodsserviziorequisito', new meta_bandodsserviziorequisito('bandodsserviziorequisito'));

	}());
