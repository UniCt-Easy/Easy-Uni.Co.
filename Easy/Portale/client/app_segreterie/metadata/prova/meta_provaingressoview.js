(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_provaingressoview() {
        MetaData.apply(this, ["provaingressoview"]);
        this.name = 'meta_provaingressoview';
    }

    meta_provaingressoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provaingressoview,
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
					case 'ingresso':
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 50);
						this.describeAColumn(table, 'prova_start', 'Data e ora inizio', 'g', 2000, null);
						this.describeAColumn(table, 'prova_stop', 'Data e ora fine', 'g', 3000, null);
//$objCalcFieldConfig_ingresso$
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
					case "ingresso": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('provaingressoview', new meta_provaingressoview('provaingressoview'));

	}());
