(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudioattivformdidprogview() {
        MetaData.apply(this, ["pianostudioattivformdidprogview"]);
        this.name = 'meta_pianostudioattivformdidprogview';
    }

    meta_pianostudioattivformdidprogview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioattivformdidprogview,
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
					case 'didprog':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 20, null);
						this.describeAColumn(table, 'attivform_title', 'Attività formativa del corso', null, 30, -1);
						this.describeAColumn(table, 'attivform_scelta_title', 'Attività formativa che lo studente svolgerà', null, 40, -1);
//$objCalcFieldConfig_didprog$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio", "idpianostudio", "idpianostudioattivform"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('pianostudioattivformdidprogview', new meta_pianostudioattivformdidprogview('pianostudioattivformdidprogview'));

	}());
