(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionestatoview() {
        MetaData.apply(this, ["iscrizionestatoview"]);
        this.name = 'meta_iscrizionestatoview';
    }

    meta_iscrizionestatoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionestatoview,
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
					case 'stato':
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
//$objCalcFieldConfig_stato$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "stato": {
						return "registry_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizionestatoview', new meta_iscrizionestatoview('iscrizionestatoview'));

	}());
