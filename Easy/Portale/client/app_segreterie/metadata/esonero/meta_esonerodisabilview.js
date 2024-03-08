(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_esonerodisabilview() {
        MetaData.apply(this, ["esonerodisabilview"]);
        this.name = 'meta_esonerodisabilview';
    }

    meta_esonerodisabilview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonerodisabilview,
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
					case 'disabil':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'esonero_description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'esonero_applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Sconto', null, 60, 2024);
						this.describeAColumn(table, 'esoneroanskind_title', 'Tipologia Codice ANS', null, 70, 50);
						this.describeAColumn(table, 'esoneroanskind_description', 'Descrizione Codice ANS', null, 70, 256);
						this.describeAColumn(table, 'esonero_retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'esonero_soloconisee', 'Applicabile solo con ISEE', null, 90, null);
						this.describeAColumn(table, 'esonero_disabil_percmax', 'Percentuale massima', 'fixed.2', 20, null);
						this.describeAColumn(table, 'esonero_disabil_percmin', 'Percentuale minima', 'fixed.2', 30, null);
//$objCalcFieldConfig_disabil$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idesonero"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "disabil": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonerodisabilview', new meta_esonerodisabilview('esonerodisabilview'));

	}());
