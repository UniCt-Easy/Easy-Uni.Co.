(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_provaaulaaulaview() {
        MetaData.apply(this, ["provaaulaaulaview"]);
        this.name = 'meta_provaaulaaulaview';
    }

    meta_provaaulaaulaview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provaaulaaulaview,
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
					case 'aula':
						this.describeAColumn(table, 'prova_title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'prova_start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'prova_stop', 'Data e ora fine', 'g', 30, null);
//$objCalcFieldConfig_aula$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaula", "idsede", "idprova", "idedificio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('provaaulaaulaview', new meta_provaaulaaulaview('provaaulaaulaview'));

	}());
