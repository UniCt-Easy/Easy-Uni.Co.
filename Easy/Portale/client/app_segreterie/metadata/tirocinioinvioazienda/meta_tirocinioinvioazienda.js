(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirocinioinvioazienda() {
        MetaData.apply(this, ["tirocinioinvioazienda"]);
        this.name = 'meta_tirocinioinvioazienda';
    }

    meta_tirocinioinvioazienda.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioinvioazienda,
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
						this.describeAColumn(table, 'dataora', 'Dataora', 'g', 10, null);
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
				var def = appMeta.Deferred("getNewRow-meta_tirocinioinvioazienda");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idtirocinioinvioazienda', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('tirocinioinvioazienda', new meta_tirocinioinvioazienda('tirocinioinvioazienda'));

	}());
