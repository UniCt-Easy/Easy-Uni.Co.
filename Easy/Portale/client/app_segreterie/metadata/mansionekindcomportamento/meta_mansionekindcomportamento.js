(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_mansionekindcomportamento() {
        MetaData.apply(this, ["mansionekindcomportamento"]);
        this.name = 'meta_mansionekindcomportamento';
    }

    meta_mansionekindcomportamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mansionekindcomportamento,
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
						this.describeAColumn(table, 'idperfcomportamento', 'Comportamento', null, 20, null);
						this.describeAColumn(table, 'year_start', 'Anno inizio validità', null, 80, null);
						this.describeAColumn(table, 'year_stop', 'Anno fine validità', null, 90, null);
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_title', 'Titolo', null, 23, null);
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_description', 'Descrizione', null, 23, null);
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_peso', 'Peso', 'fixed.2', 29, null);
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_title'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'title', columnNamekey:'idperfcomportamento' };
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_description'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'description', columnNamekey:'idperfcomportamento' };
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_peso'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'peso', columnNamekey:'idperfcomportamento' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idperfcomportamento"].caption = "Comportamento";
						table.columns["year_start"].caption = "Anno inizio validità";
						table.columns["year_stop"].caption = "Anno fine validità";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_mansionekindcomportamento");

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

			//$describeTree$
        });

    window.appMeta.addMeta('mansionekindcomportamento', new meta_mansionekindcomportamento('mansionekindcomportamento'));

	}());
