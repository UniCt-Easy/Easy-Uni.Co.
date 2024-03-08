(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_prenotappello() {
        MetaData.apply(this, ["prenotappello"]);
        this.name = 'meta_prenotappello';
    }

    meta_prenotappello.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_prenotappello,
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
					case 'appello':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 81, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_appello$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_prenotappello");

				//$getNewRowInside$

				dt.autoIncrement('idprenotappello', { minimum: 99990001 });

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

    window.appMeta.addMeta('prenotappello', new meta_prenotappello('prenotappello'));

	}());
