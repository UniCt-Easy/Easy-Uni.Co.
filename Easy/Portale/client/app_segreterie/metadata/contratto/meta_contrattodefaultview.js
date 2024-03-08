(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattodefaultview() {
        MetaData.apply(this, ["contrattodefaultview"]);
        this.name = 'meta_contrattodefaultview';
    }

    meta_contrattodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattodefaultview,
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
					case 'default':
						this.describeAColumn(table, 'contrattokind_title', 'Tipologia di contratto', null, 1200, 50);
						this.describeAColumn(table, 'inquadramento_title', 'Denominazione Inquadramento', null, 2200, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito Inquadramento', null, 2300, null);
						this.describeAColumn(table, 'contratto_start', 'Inizio', null, 3000, null);
						this.describeAColumn(table, 'contratto_stop', 'Fine', null, 4000, null);
						this.describeAColumn(table, 'contratto_parttime', 'Part-time %', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'contratto_tempdef', 'Tempo definito', null, 7000, null);
						this.describeAColumn(table, 'contratto_tempindet', 'Tempo indeterminato', null, 8000, null);
						this.describeAColumn(table, 'contratto_scatto', 'Scatto', null, 11000, null);
						this.describeAColumn(table, 'contratto_classe', 'Classe', null, 12000, null);
						this.describeAColumn(table, 'contratto_percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 14000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontratto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('contrattodefaultview', new meta_contrattodefaultview('contrattodefaultview'));

	}());
