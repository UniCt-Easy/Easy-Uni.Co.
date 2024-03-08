(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattoammview() {
        MetaData.apply(this, ["contrattoammview"]);
        this.name = 'meta_contrattoammview';
    }

    meta_contrattoammview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattoammview,
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
					case 'amm':
						this.describeAColumn(table, 'contrattokind_title', 'Tipologia di contratto', null, 1200, 50);
						this.describeAColumn(table, 'inquadramento_title', 'Denominazione Inquadramento', null, 2200, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito Inquadramento', null, 2300, null);
						this.describeAColumn(table, 'contratto_start', 'Inizio', null, 3000, null);
						this.describeAColumn(table, 'contratto_stop', 'Fine', null, 4000, null);
						this.describeAColumn(table, 'contratto_parttime', 'Part-time %', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'contratto_tempindet', 'Tempo indeterminato', null, 8000, null);
						this.describeAColumn(table, 'contratto_scatto', 'Scatto', null, 11000, null);
						this.describeAColumn(table, 'contratto_datarivalutazione', 'Data di prossima rivalutazione', null, 13000, null);
						this.describeAColumn(table, 'contratto_percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 14000, null);
//$objCalcFieldConfig_amm$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idcontratto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "amm": {
						return "contratto_start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('contrattoammview', new meta_contrattoammview('contrattoammview'));

	}());
