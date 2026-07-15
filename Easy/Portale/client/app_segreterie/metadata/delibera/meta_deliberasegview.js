(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_deliberasegview() {
        MetaData.apply(this, ["deliberasegview"]);
        this.name = 'meta_deliberasegview';
    }

    meta_deliberasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_deliberasegview,
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
						this.describeAColumn(table, 'delibera_data', 'Data', 'g', 2000, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 4200, 50);
						this.describeAColumn(table, 'oggetto', 'Oggetto', null, 5000, 512);
						this.describeAColumn(table, 'delibera_testo', 'Testo', null, 8000, -1);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura', null, 13100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura', null, 13220, 50);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddelibera"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('deliberasegview', new meta_deliberasegview('deliberasegview'));

	}());
