(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandodsiscresito() {
        MetaData.apply(this, ["bandodsiscresito"]);
        this.name = 'meta_bandodsiscresito';
    }

    meta_bandodsiscresito.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodsiscresito,
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
					case 'seganagstu':
						return this.superClass.describeColumns(table, listType);
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
				var def = appMeta.Deferred("getNewRow-meta_bandodsiscresito");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idbandodsiscresito', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seganagstu": {
						return "idbandodsiscresitokind desc";
					}
					case "seg": {
						return "idbandodsiscresitokind desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('bandodsiscresito', new meta_bandodsiscresito('bandodsiscresito'));

	}());
