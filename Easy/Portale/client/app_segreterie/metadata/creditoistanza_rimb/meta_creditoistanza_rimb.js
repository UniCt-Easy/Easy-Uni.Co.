(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_creditoistanza_rimb() {
        MetaData.apply(this, ["creditoistanza_rimb"]);
        this.name = 'meta_creditoistanza_rimb';
    }

    meta_creditoistanza_rimb.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_creditoistanza_rimb,
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
					case 'segistrimb':
						this.describeAColumn(table, '!iddebito_debito_title', 'Denominazione', null, 523, null);
						this.describeAColumn(table, '!iddebito_debito_scadenza', 'Scadenza', null, 531, null);
						objCalcFieldConfig['!iddebito_debito_title'] = { tableNameLookup:'debito', columnNameLookup:'title', columnNamekey:'iddebito' };
						objCalcFieldConfig['!iddebito_debito_scadenza'] = { tableNameLookup:'debito', columnNameLookup:'scadenza', columnNamekey:'iddebito' };
//$objCalcFieldConfig_segistrimb$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segistrimb':
						table.columns["idcredito"].caption = "Credito";
//$innerSetCaptionConfig_segistrimb$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_creditoistanza_rimb");

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

    window.appMeta.addMeta('creditoistanza_rimb', new meta_creditoistanza_rimb('creditoistanza_rimb'));

	}());
