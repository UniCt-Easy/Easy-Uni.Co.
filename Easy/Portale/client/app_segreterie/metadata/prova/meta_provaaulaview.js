(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_provaaulaview() {
        MetaData.apply(this, ["provaaulaview"]);
        this.name = 'meta_provaaulaview';
    }

    meta_provaaulaview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provaaulaview,
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
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
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
				return ["idprova"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "aula": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('provaaulaview', new meta_provaaulaview('provaaulaview'));

	}());
