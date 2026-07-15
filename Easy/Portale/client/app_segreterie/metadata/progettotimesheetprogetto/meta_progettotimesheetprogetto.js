(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotimesheetprogetto() {
        MetaData.apply(this, ["progettotimesheetprogetto"]);
        this.name = 'meta_progettotimesheetprogetto';
    }

    meta_progettotimesheetprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotimesheetprogetto,
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
						this.describeAColumn(table, 'idprogetto', 'Identificativo', null, 10, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettotimesheetprogetto");

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

    window.appMeta.addMeta('progettotimesheetprogetto', new meta_progettotimesheetprogetto('progettotimesheetprogetto'));

	}());
