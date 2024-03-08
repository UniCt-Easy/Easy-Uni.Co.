(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assicurazione() {
        MetaData.apply(this, ["assicurazione"]);
        this.name = 'meta_assicurazione';
    }

    meta_assicurazione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assicurazione,
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
						this.describeAColumn(table, 'societaassicura', 'Società assicurativa', null, 10, 1024);
						this.describeAColumn(table, 'datarilascio', 'Data di rilascio', null, 20, null);
						this.describeAColumn(table, 'datascadenza', 'Data di scadenza', null, 30, null);
						this.describeAColumn(table, 'infortunisullavoro', 'Infortunio sul lavoro', null, 50, null);
						this.describeAColumn(table, 'rca', 'Rca', null, 70, null);
						this.describeAColumn(table, 'spostamenti', 'Spostamenti', null, 90, null);
						this.describeAColumn(table, 'viaggi', 'Viaggi', null, 100, null);
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
				var def = appMeta.Deferred("getNewRow-meta_assicurazione");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idassicurazione', { minimum: 99990001 });

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

    window.appMeta.addMeta('assicurazione', new meta_assicurazione('assicurazione'));

	}());
