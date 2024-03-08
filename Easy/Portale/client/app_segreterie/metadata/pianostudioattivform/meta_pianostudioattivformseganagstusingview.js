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
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seganagstusing':
						this.describeAColumn(table, 'attivform_title', 'Attività formativa del corso', null, 30, -1);
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

        });

    window.appMeta.addMeta('pianostudioattivformseganagstusingview', new meta_pianostudioattivformseganagstusingview('pianostudioattivformseganagstusingview'));

	}());
