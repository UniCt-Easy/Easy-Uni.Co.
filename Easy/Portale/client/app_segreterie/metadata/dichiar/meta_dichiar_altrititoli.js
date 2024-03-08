(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar_altrititoli() {
        MetaData.apply(this, ["dichiar_altrititoli"]);
        this.name = 'meta_dichiar_altrititoli';
    }

    meta_dichiar_altrititoli.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar_altrititoli,
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
					case 'altrititoli_seg':
						this.describeAColumn(table, 'title', 'Titolo', null, 510, 1024);
						this.describeAColumn(table, 'dataottenimento', 'Data ottenimento', null, 520, null);
						this.describeAColumn(table, 'rilasciatoda', 'Rilasciato da', null, 550, 1024);
//$objCalcFieldConfig_altrititoli_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_dichiar_altrititoli");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					idreg : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "altrititoli_seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('dichiar_altrititoli', new meta_dichiar_altrititoli('dichiar_altrititoli'));

	}());
