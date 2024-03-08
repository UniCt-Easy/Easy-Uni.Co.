(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_decadenza() {
        MetaData.apply(this, ["decadenza"]);
        this.name = 'meta_decadenza';
    }

    meta_decadenza.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_decadenza,
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
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 30, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 70, null);
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 30, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 70, null);
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
				var def = appMeta.Deferred("getNewRow-meta_decadenza");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('iddecadenza', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					idreg_studenti : 0,
					idiscrizione : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seganagstu": {
						return "idreg_studenti asc , idiscrizione asc ";
					}
					case "seg": {
						return "idreg_studenti asc , idiscrizione asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('decadenza', new meta_decadenza('decadenza'));

	}());
