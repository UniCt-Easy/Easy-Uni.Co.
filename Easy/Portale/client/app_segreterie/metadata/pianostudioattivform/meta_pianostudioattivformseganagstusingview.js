(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudioattivformseganagstusingview() {
        MetaData.apply(this, ["pianostudioattivformseganagstusingview"]);
        this.name = 'meta_pianostudioattivformseganagstusingview';
    }

    meta_pianostudioattivformseganagstusingview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioattivformseganagstusingview,
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
					case 'seganagstusing':
						this.describeAColumn(table, 'attivform_title', 'Attività formativa del corso', null, 1100, -1);
						this.describeAColumn(table, 'sostenimento_data', 'Data Sostenimento', null, 2200, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito Esito Sostenimento', null, 3220, 50);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su Sostenimento', null, 4200, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode Sostenimento', null, 4300, null);
//$objCalcFieldConfig_seganagstusing$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idiscrizione", "idpianostudio", "idpianostudioattivform"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('pianostudioattivformseganagstusingview', new meta_pianostudioattivformseganagstusingview('pianostudioattivformseganagstusingview'));

	}());
