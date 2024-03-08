(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryprogfinsegview() {
        MetaData.apply(this, ["registryprogfinsegview"]);
        this.name = 'meta_registryprogfinsegview';
    }

    meta_registryprogfinsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryprogfinsegview,
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
						this.describeAColumn(table, 'registryprogfin_code', 'Codice identificativo', null, 4000, 2048);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idregistryprogfin"];
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

    window.appMeta.addMeta('registryprogfinsegview', new meta_registryprogfinsegview('registryprogfinsegview'));

	}());
