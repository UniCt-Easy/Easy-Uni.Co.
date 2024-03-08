(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accordoscambiomidettlangkind() {
        MetaData.apply(this, ["accordoscambiomidettlangkind"]);
        this.name = 'meta_accordoscambiomidettlangkind';
    }

    meta_accordoscambiomidettlangkind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomidettlangkind,
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
						this.describeAColumn(table, 'title', 'Soggetto', null, 20, 50);
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
				var def = appMeta.Deferred("getNewRow-meta_accordoscambiomidettlangkind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idaccordoscambiomidettlangkind', { minimum: 99990001 });

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
					case "default": {
						return "sortcode";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('accordoscambiomidettlangkind', new meta_accordoscambiomidettlangkind('accordoscambiomidettlangkind'));

	}());
