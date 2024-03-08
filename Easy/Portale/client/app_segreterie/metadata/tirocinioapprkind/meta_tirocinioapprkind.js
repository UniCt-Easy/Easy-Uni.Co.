(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirocinioapprkind() {
        MetaData.apply(this, ["tirocinioapprkind"]);
        this.name = 'meta_tirocinioapprkind';
    }

    meta_tirocinioapprkind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioapprkind,
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
					case 'elenchi':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 256);
//$objCalcFieldConfig_elenchi$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_tirocinioapprkind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idtirocinioapprkind', { minimum: 99990001 });

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
					case "elenchi": {
						return "sortcode";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirocinioapprkind', new meta_tirocinioapprkind('tirocinioapprkind'));

	}());
