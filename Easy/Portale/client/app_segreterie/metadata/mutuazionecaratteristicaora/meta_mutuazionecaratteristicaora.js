(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_mutuazionecaratteristicaora() {
        MetaData.apply(this, ["mutuazionecaratteristicaora"]);
        this.name = 'meta_mutuazionecaratteristicaora';
    }

    meta_mutuazionecaratteristicaora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mutuazionecaratteristicaora,
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
						this.describeAColumn(table, 'ora', 'Ore', null, 120, null);
						this.describeAColumn(table, '!idorakind_orakind_title', 'Tipo', null, 111, null);
						objCalcFieldConfig['!idorakind_orakind_title'] = { tableNameLookup:'orakind', columnNameLookup:'title', columnNamekey:'idorakind' };
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
               var def = appMeta.Deferred("getNewRow-meta_mutuazionecaratteristicaora");

				//$getNewRowInside$

				dt.autoIncrement('idmutuazionecaratteristicaora', { minimum: 99990001 });

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

    window.appMeta.addMeta('mutuazionecaratteristicaora', new meta_mutuazionecaratteristicaora('mutuazionecaratteristicaora'));

	}());
