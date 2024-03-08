(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotiporicavokindcontrattokind() {
        MetaData.apply(this, ["progettotiporicavokindcontrattokind"]);
        this.name = 'meta_progettotiporicavokindcontrattokind';
    }

    meta_progettotiporicavokindcontrattokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotiporicavokindcontrattokind,
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
						this.describeAColumn(table, 'idposition', 'Identificativo', null, 10, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettotiporicavokindcontrattokind");

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

			//$describeTree$
        });

    window.appMeta.addMeta('progettotiporicavokindcontrattokind', new meta_progettotiporicavokindcontrattokind('progettotiporicavokindcontrattokind'));

	}());
