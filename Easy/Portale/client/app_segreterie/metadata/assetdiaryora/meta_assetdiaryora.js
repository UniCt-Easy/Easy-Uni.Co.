(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assetdiaryora() {
        MetaData.apply(this, ["assetdiaryora"]);
        this.name = 'meta_assetdiaryora';
    }

    meta_assetdiaryora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiaryora,
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
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 10, null);
						this.describeAColumn(table, '!title', 'Descrizione', null, 20, null);
						this.describeAColumn(table, 'start', 'Data e ora di inizio', 'g', 80, null);
						this.describeAColumn(table, 'stop', 'Data e ora di fine', 'g', 90, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 151, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 152, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
//$objCalcFieldConfig_seg$
						break;
					case 'segsal':
						this.describeAColumn(table, 'idassetdiary', 'Diario d\'uso', null, 20, null);
						this.describeAColumn(table, 'start', 'Data e ora di inizio', 'g', 30, null);
						this.describeAColumn(table, 'stop', 'Data e ora di fine', 'g', 40, null);
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 50, null);
//$objCalcFieldConfig_segsal$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segsal':
						table.columns["!title"].caption = "Descrizione";
						table.columns["amount"].caption = "Importo";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["start"].caption = "Data e ora di inizio";
						table.columns["stop"].caption = "Data e ora di fine";
						table.columns["idassetdiary"].caption = "Diario d'uso";
//$innerSetCaptionConfig_segsal$
						break;
					case 'seg':
						table.columns["!title"].caption = "Descrizione";
						table.columns["amount"].caption = "Importo";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["start"].caption = "Data e ora di inizio";
						table.columns["stop"].caption = "Data e ora di fine";
						table.columns["amount"].caption = "Importo";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["start"].caption = "Data e ora di inizio";
						table.columns["stop"].caption = "Data e ora di fine";
						table.columns["amount"].caption = "Importo";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["start"].caption = "Data e ora di inizio";
						table.columns["stop"].caption = "Data e ora di fine";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_assetdiaryora");

				//$getNewRowInside$

				dt.autoIncrement('idassetdiaryora', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "!title desc";
					}
					case "segsal": {
						return "!title desc";
					}
					case "segsal": {
						return "!title desc, start asc ";
					}
					case "segsal": {
						return "start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiaryora', new meta_assetdiaryora('assetdiaryora'));

	}());
