(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_eq() {
        MetaData.apply(this, ["istanza_eq"]);
        this.name = 'meta_istanza_eq';
    }

    meta_istanza_eq.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_eq,
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
					case 'eq_seg':
						this.describeAColumn(table, 'iddichiar_titolo_seg', 'Dichiarazione del titolo di studio', null, 1090, null);
//$objCalcFieldConfig_eq_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_eq");

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

    window.appMeta.addMeta('istanza_eq', new meta_istanza_eq('istanza_eq'));

	}());
