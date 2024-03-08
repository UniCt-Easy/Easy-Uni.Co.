(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneateneovalidatore() {
        MetaData.apply(this, ["perfvalutazioneateneovalidatore"]);
        this.name = 'meta_perfvalutazioneateneovalidatore';
    }

    meta_perfvalutazioneateneovalidatore.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneateneovalidatore,
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
						this.describeAColumn(table, '!idvalidatori_validatori_title', 'Identificativo', null, 93, null);
						objCalcFieldConfig['!idvalidatori_validatori_title'] = { tableNameLookup:'validatori', columnNameLookup:'title', columnNamekey:'idvalidatori' };
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
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneateneovalidatore");

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

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "idvalidatori asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfvalutazioneateneovalidatore', new meta_perfvalutazioneateneovalidatore('perfvalutazioneateneovalidatore'));

	}());
