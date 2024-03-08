(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassacsingconf() {
        MetaData.apply(this, ["tassacsingconf"]);
        this.name = 'meta_tassacsingconf';
    }

    meta_tassacsingconf.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassacsingconf,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'costomax', 'Costo massimo', 'fixed.2', 30, null);
						this.describeAColumn(table, 'numerosconto', 'Numero di insegnamenti per cui si applica lo sconto', null, 70, null);
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
				var def = appMeta.Deferred("getNewRow-meta_tassacsingconf");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idtassacsingconf', { minimum: 99990001 });

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

    window.appMeta.addMeta('tassacsingconf', new meta_tassacsingconf('tassacsingconf'));

	}());
