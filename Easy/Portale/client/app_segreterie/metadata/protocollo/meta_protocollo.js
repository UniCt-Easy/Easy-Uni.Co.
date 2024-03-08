(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollo() {
        MetaData.apply(this, ["protocollo"]);
        this.name = 'meta_protocollo';
    }

    meta_protocollo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollo,
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
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 10, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 20, null);
						this.describeAColumn(table, 'protdata', 'Data di protocollo', null, 30, null);
						this.describeAColumn(table, 'codiceregistro', 'Codice Registro (univoco nell\'Istituto)', null, 40, 1024);
						this.describeAColumn(table, 'codiceammipa', 'Codice IPA dell\'Istituto', null, 50, 50);
						this.describeAColumn(table, 'originemail', 'E-mail mittente', null, 80, 512);
						this.describeAColumn(table, 'originecodiceaoo', 'Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea', null, 90, 50);
						this.describeAColumn(table, 'origineidamm', 'Amministrazione pubblica mittente - Codice IPA', null, 100, 50);
						this.describeAColumn(table, 'oggetto', 'Oggetto del documento', null, 110, 1024);
						this.describeAColumn(table, 'annullato', 'Annullato', null, 120, null);
						this.describeAColumn(table, 'dataannullamento', 'Data di annullamento', 'g', 180, null);
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
                                               var def = appMeta.Deferred("getNewRow-meta_protocollo");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$				

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('protocollo', new meta_protocollo('protocollo'));

	}());
