(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryprogfinbandosegview() {
        MetaData.apply(this, ["registryprogfinbandosegview"]);
        this.name = 'meta_registryprogfinbandosegview';
    }

    meta_registryprogfinbandosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryprogfinbandosegview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 2048);
						this.describeAColumn(table, 'registryprogfinbando_number', 'Numero', null, 6000, 2048);
						this.describeAColumn(table, 'registryprogfinbando_scadenza', 'Deadline of submission', null, 7000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idregistryprogfin", "idregistryprogfinbando"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryprogfinbandosegview', new meta_registryprogfinbandosegview('registryprogfinbandosegview'));

	}());
