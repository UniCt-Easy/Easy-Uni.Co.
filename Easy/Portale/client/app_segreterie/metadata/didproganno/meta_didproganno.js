(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didproganno() {
        MetaData.apply(this, ["didproganno"]);
        this.name = 'meta_didproganno';
    }

    meta_didproganno.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didproganno,
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
						this.describeAColumn(table, 'anno', 'Anno', null, 10, null);
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 20, 9);
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
				var def = appMeta.Deferred("getNewRow-meta_didproganno");

				//$getNewRowInside$

				dt.autoIncrement('iddidproganno', { minimum: 99990001 });

				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "anno desc, aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didproganno', new meta_didproganno('didproganno'));

	}());
