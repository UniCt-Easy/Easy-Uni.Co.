(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturaperfview() {
        MetaData.apply(this, ["strutturaperfview"]);
        this.name = 'meta_strutturaperfview';
    }

    meta_strutturaperfview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaperfview,
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
					case 'perf':
						this.describeAColumn(table, 'title', 'Denominazione', null, 2000, 1024);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 3000, 50);
						this.describeAColumn(table, 'struttura_codiceipa', 'Codice IPA', null, 4000, null);
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 10200, 50);
						this.describeAColumn(table, 'upb_title', 'UPB', null, 11200, 150);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione Struttura madre', null, 18100, 1024);
						this.describeAColumn(table, 'strutturakind_struttura_title', 'Tipologia Tipo Struttura madre', null, 18220, 50);
						this.describeAColumn(table, 'struttura_active', 'Attivo', null, 24000, null);
//$objCalcFieldConfig_perf$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "perf": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturaperfview', new meta_strutturaperfview('strutturaperfview'));

	}());
