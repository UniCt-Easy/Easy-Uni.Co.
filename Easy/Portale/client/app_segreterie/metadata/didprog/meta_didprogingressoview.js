(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogingressoview() {
        MetaData.apply(this, ["didprogingressoview"]);
        this.name = 'meta_didprogingressoview';
    }

    meta_didprogingressoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogingressoview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 4100, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 4600, null);
						this.describeAColumn(table, 'didprognumchiusokind_title', 'Numero chiuso', null, 14200, 50);
						this.describeAColumn(table, 'graduatoria_title', 'Graduatoria', null, 17200, 256);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 19200, 1024);
						this.describeAColumn(table, 'geo_nationlang_lang', 'Lingua di erogazione', null, 20400, 64);
						this.describeAColumn(table, 'geo_nationlang2_lang', 'Seconda lingua di erogazione', null, 21400, 64);
						this.describeAColumn(table, 'geo_nationlangvis_lang', 'Lingua di visualizzazione', null, 22400, 64);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia Tipologia Sessione', null, 24320, 50);
						this.describeAColumn(table, 'sessione_start', 'Data di inizio Sessione', null, 24400, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine Sessione', null, 24500, null);
						this.describeAColumn(table, 'titolokind_title', 'Titolo di studi', null, 25200, 50);
//$objCalcFieldConfig_ingresso$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idcorsostudio"];
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

    window.appMeta.addMeta('didprogingressoview', new meta_didprogingressoview('didprogingressoview'));

	}());
