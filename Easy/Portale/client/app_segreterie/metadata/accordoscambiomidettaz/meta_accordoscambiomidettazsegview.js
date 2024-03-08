(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accordoscambiomidettazsegview() {
        MetaData.apply(this, ["accordoscambiomidettazsegview"]);
        this.name = 'meta_accordoscambiomidettazsegview';
    }

    meta_accordoscambiomidettazsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomidettazsegview,
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
						this.describeAColumn(table, 'registryaziende_title', 'Azienda', null, 30, 101);
						this.describeAColumn(table, 'accordoscambiomidettaz_numstud', 'Numero di studenti', null, 40, null);
						this.describeAColumn(table, 'accordoscambiomidettaz_stipula', 'Data di stipula', null, 50, null);
						this.describeAColumn(table, 'accordoscambiomidettaz_stop', 'Data di termine', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg_aziende", "idaccordoscambiomi", "idaccordoscambiomidettaz"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('accordoscambiomidettazsegview', new meta_accordoscambiomidettazsegview('accordoscambiomidettazsegview'));

	}());
