(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pagamento() {
        MetaData.apply(this, ["pagamento"]);
        this.name = 'meta_pagamento';
    }

    meta_pagamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pagamento,
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
						this.describeAColumn(table, 'dataora', 'Data e ora', 'g', 20, null);
//$objCalcFieldConfig_seg$
						break;
					case 'default':
						this.describeAColumn(table, 'dataora', 'Data e ora', 'g', 20, null);
						this.describeAColumn(table, '!idpagamentokind_pagamentokind_title', 'Tipologia', null, 41, null);
						objCalcFieldConfig['!idpagamentokind_pagamentokind_title'] = { tableNameLookup:'pagamentokind', columnNameLookup:'title', columnNamekey:'idpagamentokind' };
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
						table.columns["dataora"].caption = "Data e ora";
						table.columns["idpagamentokind"].caption = "Tipologia";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pagamento");

				//$getNewRowInside$

				dt.autoIncrement('idpagamento', { minimum: 99990001 });

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

    window.appMeta.addMeta('pagamento', new meta_pagamento('pagamento'));

	}());
