(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_cert() {
        MetaData.apply(this, ["istanza_cert"]);
        this.name = 'meta_istanza_cert';
    }

    meta_istanza_cert.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_cert,
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
					case 'cert_seg':
						this.describeAColumn(table, 'idcertkind', 'Tipologia di certificato', null, 510, null);
//$objCalcFieldConfig_cert_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_cert");

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

    window.appMeta.addMeta('istanza_cert', new meta_istanza_cert('istanza_cert'));

	}());
