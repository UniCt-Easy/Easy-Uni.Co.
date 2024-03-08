(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandodsserviziodatepres() {
        MetaData.apply(this, ["bandodsserviziodatepres"]);
        this.name = 'meta_bandodsserviziodatepres';
    }

    meta_bandodsserviziodatepres.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodsserviziodatepres,
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
						this.describeAColumn(table, 'data', 'Data di presentazione delle richieste', 'g', 20, null);
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
				var def = appMeta.Deferred("getNewRow-meta_bandodsserviziodatepres");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idbandodsserviziodatepres', { minimum: 99990001 });

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

    window.appMeta.addMeta('bandodsserviziodatepres', new meta_bandodsserviziodatepres('bandodsserviziodatepres'));

	}());
