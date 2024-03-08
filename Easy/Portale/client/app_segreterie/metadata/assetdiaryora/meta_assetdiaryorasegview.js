(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_assetdiaryorasegview() {
        MetaData.apply(this, ["assetdiaryorasegview"]);
        this.name = 'meta_assetdiaryorasegview';
    }

    meta_assetdiaryorasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiaryorasegview,
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
					case 'seg':
						this.describeAColumn(table, 'assetdiaryora_amount', 'Importo', 'fixed.2', 1000, null);
						this.describeAColumn(table, 'assetdiaryora_start', 'Data e ora di inizio', 'g', 8000, null);
						this.describeAColumn(table, 'assetdiaryora_stop', 'Data e ora di fine', 'g', 9000, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato avanzamento lavori', null, 15100, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato avanzamento lavori', null, 15400, null);
//$objCalcFieldConfig_seg$
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
					case "seg": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiaryorasegview', new meta_assetdiaryorasegview('assetdiaryorasegview'));

	}());
