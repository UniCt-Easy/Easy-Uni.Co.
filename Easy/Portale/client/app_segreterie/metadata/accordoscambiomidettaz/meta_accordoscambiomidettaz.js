(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accordoscambiomidettaz() {
        MetaData.apply(this, ["accordoscambiomidettaz"]);
        this.name = 'meta_accordoscambiomidettaz';
    }

    meta_accordoscambiomidettaz.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomidettaz,
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
					case 'seg':
						this.describeAColumn(table, 'numstud', 'Numero di studenti', null, 40, null);
						this.describeAColumn(table, 'stipula', 'Data di stipula', null, 50, null);
						this.describeAColumn(table, 'stop', 'Data di termine', null, 60, null);
						this.describeAColumn(table, '!idreg_aziende_registry_aziende_title', 'Azienda', null, 31, null);
						objCalcFieldConfig['!idreg_aziende_registry_aziende_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_accordoscambiomidettaz");

				//$getNewRowInside$

				dt.autoIncrement('idaccordoscambiomidettaz', { minimum: 99990001 });

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

    window.appMeta.addMeta('accordoscambiomidettaz', new meta_accordoscambiomidettaz('accordoscambiomidettaz'));

	}());
