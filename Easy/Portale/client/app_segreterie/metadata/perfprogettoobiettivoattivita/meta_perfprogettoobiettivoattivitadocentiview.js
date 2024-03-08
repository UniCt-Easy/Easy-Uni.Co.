(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivoattivitadocentiview() {
        MetaData.apply(this, ["perfprogettoobiettivoattivitadocentiview"]);
        this.name = 'meta_perfprogettoobiettivoattivitadocentiview';
    }

    meta_perfprogettoobiettivoattivitadocentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivoattivitadocentiview,
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
					case 'docenti':
						this.describeAColumn(table, 'perfprogetto_title', 'Progetto Strategico', null, 1200, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivo_title', 'Obiettivo strategico', null, 2100, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivoattivitaparent_title', 'Attività madre', null, 3400, 1024);
						this.describeAColumn(table, 'title', 'Titolo', null, 4000, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datainizioprevista', 'Data inizio prevista', 'g', 5000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datafineprevista', 'Data fine prevista', 'g', 6000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datainizioeffettiva', 'Data inizio effettiva', 'g', 7000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_datafineeffettiva', 'Data fine effettiva', 'g', 8000, null);
						this.describeAColumn(table, 'perfprogettoobiettivoattivita_completamento', 'Percentuale di completamento', 'fixed.2', 9000, null);
						this.describeAColumn(table, 'account_title', 'Denominazione Voce di costo', null, 18100, 150);
						this.describeAColumn(table, 'account_ayear', 'Esercizio Voce di costo', null, 18200, null);
						this.describeAColumn(table, 'account_codeacc', 'Codice conto Voce di costo', null, 18300, 50);
						this.describeAColumn(table, 'upb_title', 'Unità previsionale di base (UPB)', null, 19200, 150);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docenti": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivoattivitadocentiview', new meta_perfprogettoobiettivoattivitadocentiview('perfprogettoobiettivoattivitadocentiview'));

	}());
