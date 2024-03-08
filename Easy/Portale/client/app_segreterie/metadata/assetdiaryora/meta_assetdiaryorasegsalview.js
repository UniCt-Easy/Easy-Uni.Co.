(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assetdiaryorasegsalview() {
        MetaData.apply(this, ["assetdiaryorasegsalview"]);
        this.name = 'meta_assetdiaryorasegsalview';
    }

    meta_assetdiaryorasegsalview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiaryorasegsalview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'segsal':
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Identificativo', null, 1100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Identificativo', null, 1200, 2048);
						this.describeAColumn(table, 'asset_ninventory', 'Numero inventario Bene strumentale Diario d\'uso', null, 2220, null);
						this.describeAColumn(table, 'asset_idasset', 'Identificativo Bene strumentale Diario d\'uso', null, 2230, null);
						this.describeAColumn(table, 'asset_idpiece', 'Numero parte Bene strumentale Diario d\'uso', null, 2240, null);
						this.describeAColumn(table, 'asset_rfid', 'Codice RFID Bene strumentale Diario d\'uso', null, 2260, 30);
						this.describeAColumn(table, 'registry_title', 'Denominazione Operatore Diario d\'uso', null, 2430, 101);
						this.describeAColumn(table, 'assetdiaryora_start', 'Data e ora di inizio', 'g', 3000, null);
						this.describeAColumn(table, 'assetdiaryora_stop', 'Data e ora di fine', 'g', 4000, null);
						this.describeAColumn(table, 'assetdiaryora_amount', 'Importo', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato avanzamento lavori', null, 6100, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato avanzamento lavori', null, 6400, null);
//$objCalcFieldConfig_segsal$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idassetdiary", "idworkpackage", "idassetdiaryora"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segsal": {
						return "";
					}
					case "segsal": {
						return "assetdiaryora_start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiaryorasegsalview', new meta_assetdiaryorasegsalview('assetdiaryorasegsalview'));

	}());
