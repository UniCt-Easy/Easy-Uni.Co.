(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_nullaosta() {
        MetaData.apply(this, ["nullaosta"]);
        this.name = 'meta_nullaosta';
    }

    meta_nullaosta.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_nullaosta,
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
					case 'segisteq':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segisteq$
						break;
					case 'segistsosp':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segistsosp$
						break;
					case 'segistrin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segistrin$
						break;
					case 'segisttru':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segisttru$
						break;
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagstupre$
						break;
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
//$objCalcFieldConfig_segistrein$
						break;
					case 'segpratica':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_segpratica$
						break;
					case 'imm_seganagstu':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 60, null);
//$objCalcFieldConfig_imm_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_nullaosta");

				//$getNewRowInside$

				dt.autoIncrement('idnullaosta', { minimum: 99990001 });

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

    window.appMeta.addMeta('nullaosta', new meta_nullaosta('nullaosta'));

	}());
