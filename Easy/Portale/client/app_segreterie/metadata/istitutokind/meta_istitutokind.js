(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istitutokind() {
        MetaData.apply(this, ["istitutokind"]);
        this.name = 'meta_istitutokind';
    }

    meta_istitutokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istitutokind,
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
						this.describeAColumn(table, 'idistitutokind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'tipoistituto', 'Tipologia', null, 20, 256);
						this.describeAColumn(table, 'tipoistitutoen', 'Tipologia (EN)', null, 30, 256);
						this.describeAColumn(table, 'tipoistitutosigla', 'Sigla', null, 40, 50);
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
				var def = appMeta.Deferred("getNewRow-meta_istitutokind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idistitutokind', { minimum: 99990001 });

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

    window.appMeta.addMeta('istitutokind', new meta_istitutokind('istitutokind'));

	}());
