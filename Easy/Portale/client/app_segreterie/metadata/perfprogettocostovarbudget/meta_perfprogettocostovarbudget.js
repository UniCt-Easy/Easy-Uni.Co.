(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettocostovarbudget() {
        MetaData.apply(this, ["perfprogettocostovarbudget"]);
        this.name = 'meta_perfprogettocostovarbudget';
    }

    meta_perfprogettocostovarbudget.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocostovarbudget,
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
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'budget', 'Variazione del budget', 'fixed.2', 40, null);
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
               var def = appMeta.Deferred("getNewRow-meta_perfprogettocostovarbudget");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettocostovarbudget', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfprogettocostovarbudget', new meta_perfprogettocostovarbudget('perfprogettocostovarbudget'));

	}());
