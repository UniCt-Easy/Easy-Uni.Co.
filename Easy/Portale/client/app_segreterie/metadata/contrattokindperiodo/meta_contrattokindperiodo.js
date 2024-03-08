(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattokindperiodo() {
        MetaData.apply(this, ["contrattokindperiodo"]);
        this.name = 'meta_contrattokindperiodo';
    }

    meta_contrattokindperiodo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattokindperiodo,
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
						this.describeAColumn(table, 'datafrom', 'Dal', null, 20, null);
						this.describeAColumn(table, 'datato', 'Al', null, 30, null);
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
               var def = appMeta.Deferred("getNewRow-meta_contrattokindperiodo");

				//$getNewRowInside$

				dt.autoIncrement('idcontrattokindperiodo', { minimum: 99990001 });

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

    window.appMeta.addMeta('contrattokindperiodo', new meta_contrattokindperiodo('contrattokindperiodo'));

	}());
