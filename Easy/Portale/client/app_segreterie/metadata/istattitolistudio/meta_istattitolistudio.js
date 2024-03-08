(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istattitolistudio() {
        MetaData.apply(this, ["istattitolistudio"]);
        this.name = 'meta_istattitolistudio';
    }

    meta_istattitolistudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istattitolistudio,
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
						this.describeAColumn(table, 'idistattitolistudio', 'Codice', null, 10, null);
						this.describeAColumn(table, 'titolo', 'Titolo di studio', null, 20, 1024);
						this.describeAColumn(table, 'tipo', 'Tipo di scuola/istituto, Corso/classe di corsi accademici', null, 30, 1024);
						this.describeAColumn(table, 'sinonimi', 'Sinonimi', null, 70, 1024);
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
				var def = appMeta.Deferred("getNewRow-meta_istattitolistudio");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idistattitolistudio', { minimum: 99990001 });

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

    window.appMeta.addMeta('istattitolistudio', new meta_istattitolistudio('istattitolistudio'));

	}());
