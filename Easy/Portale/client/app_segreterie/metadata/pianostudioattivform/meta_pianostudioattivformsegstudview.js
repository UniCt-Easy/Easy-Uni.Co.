(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudioattivformsegstudview() {
        MetaData.apply(this, ["pianostudioattivformsegstudview"]);
        this.name = 'meta_pianostudioattivformsegstudview';
    }

    meta_pianostudioattivformsegstudview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioattivformsegstudview,
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
					case 'segstud':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 1000, null);
						this.describeAColumn(table, 'attivform_title', 'Attività formativa Attività formativa del corso', null, 2100, -1);
						this.describeAColumn(table, 'attivform_aa', 'Identificativo Attività formativa del corso', null, 2500, 9);
						this.describeAColumn(table, 'attivformscelta_title', 'Attività formativa Attività formativa che lo studente svolgerà', null, 3100, -1);
						this.describeAColumn(table, 'attivformscelta_aa', 'Identificativo Attività formativa che lo studente svolgerà', null, 3500, 9);
						this.describeAColumn(table, 'sostenimento_data', 'Data Sostenimento', null, 4200, null);
						this.describeAColumn(table, 'sostenimento_giudizio', 'Giudizio Sostenimento', null, 4500, 50);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito Esito Sostenimento', null, 5220, 50);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 6000, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su Sostenimento', null, 6200, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode Sostenimento', null, 6300, null);
//$objCalcFieldConfig_segstud$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio", "idpianostudio", "idattivform_scelta", "idpianostudioattivform"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('pianostudioattivformsegstudview', new meta_pianostudioattivformsegstudview('pianostudioattivformsegstudview'));

	}());
