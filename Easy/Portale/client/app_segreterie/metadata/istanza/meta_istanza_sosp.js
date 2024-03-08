(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_sosp() {
        MetaData.apply(this, ["istanza_sosp"]);
        this.name = 'meta_istanza_sosp';
    }

    meta_istanza_sosp.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_sosp,
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
					case 'sosp_seg':
						this.describeAColumn(table, 'motivo', 'Motivo', null, 540, -1);
						this.describeAColumn(table, 'start', 'Data di Inizio', null, 550, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 560, null);
//$objCalcFieldConfig_sosp_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_sosp");

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

    window.appMeta.addMeta('istanza_sosp', new meta_istanza_sosp('istanza_sosp'));

	}());
