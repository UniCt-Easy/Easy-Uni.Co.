(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattoprevview() {
        MetaData.apply(this, ["contrattoprevview"]);
        this.name = 'meta_contrattoprevview';
    }

    meta_contrattoprevview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattoprevview,
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
					case 'prev':
						this.describeAColumn(table, 'contrattokind_title', 'Tipologia di contratto', null, 1200, 50);
						this.describeAColumn(table, 'inquadramento_title', 'Denominazione Inquadramento', null, 2200, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito Inquadramento', null, 2300, null);
						this.describeAColumn(table, 'contratto_percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 3000, null);
						this.describeAColumn(table, 'contratto_start', 'Inizio', null, 4000, null);
						this.describeAColumn(table, 'contratto_datarivalutazione', 'Data di prossima rivalutazione', null, 5000, null);
						this.describeAColumn(table, 'contratto_stop', 'Fine', null, 6000, null);
						this.describeAColumn(table, 'contratto_parttime', 'Part-time %', 'fixed.2', 7000, null);
						this.describeAColumn(table, 'contratto_tempindet', 'Tempo indeterminato', null, 8000, null);
						this.describeAColumn(table, 'contratto_scatto', 'Scatto', null, 11000, null);
						this.describeAColumn(table, 'contratto_classe', 'Classe', null, 12000, null);
//$objCalcFieldConfig_prev$
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

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('contrattoprevview', new meta_contrattoprevview('contrattoprevview'));

	}());
