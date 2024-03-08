(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_provastatoview() {
        MetaData.apply(this, ["provastatoview"]);
        this.name = 'meta_provastatoview';
    }

    meta_provastatoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provastatoview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'prova_start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'prova_stop', 'Data e ora fine', 'g', 30, null);
//$objCalcFieldConfig_stato$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprova", "iddidprog", "idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "stato": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('provastatoview', new meta_provastatoview('provastatoview'));

	}());
