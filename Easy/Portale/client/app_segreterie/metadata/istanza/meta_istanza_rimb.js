(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_rimb() {
        MetaData.apply(this, ["istanza_rimb"]);
        this.name = 'meta_istanza_rimb';
    }

    meta_istanza_rimb.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_rimb,
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
					case 'rimb_seg':
						return this.superClass.describeColumns(table, listType);
//$objCalcFieldConfig_rimb_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_rimb");

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

    window.appMeta.addMeta('istanza_rimb', new meta_istanza_rimb('istanza_rimb'));

	}());
