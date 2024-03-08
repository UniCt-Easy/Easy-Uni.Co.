(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_esonerodefaultview() {
        MetaData.apply(this, ["esonerodefaultview"]);
        this.name = 'meta_esonerodefaultview';
    }

    meta_esonerodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonerodefaultview,
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
					case 'default':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 50);
						this.describeAColumn(table, 'esonero_description', 'Descrizione', null, 40, 256);
						this.describeAColumn(table, 'esonero_applunavolta', 'Applicabile una sola volta', null, 50, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Sconto', null, 60, 2024);
						this.describeAColumn(table, 'esoneroanskind_title', 'Tipologia Codice ANS', null, 70, 50);
						this.describeAColumn(table, 'esoneroanskind_description', 'Descrizione Codice ANS', null, 70, 256);
						this.describeAColumn(table, 'esonero_retroattivo', 'Retroattivo', null, 80, null);
						this.describeAColumn(table, 'esonero_soloconisee', 'Applicabile solo con ISEE', null, 90, null);
//$objCalcFieldConfig_default$
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
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonerodefaultview', new meta_esonerodefaultview('esonerodefaultview'));

	}());
