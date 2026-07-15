(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_esonerocarrieraview() {
        MetaData.apply(this, ["esonerocarrieraview"]);
        this.name = 'meta_esonerocarrieraview';
    }

    meta_esonerocarrieraview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonerocarrieraview,
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
					case 'carriera':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'esonero_carriera_annofcmax', 'Anno fuori corso massimo', null, 1000, null);
						this.describeAColumn(table, 'esonero_carriera_annofcmin', 'Anno fuori corso minimo', null, 2000, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 3000, 50);
						this.describeAColumn(table, 'esonero_carriera_annoiscrmax', 'Anno iscrizione massimo', null, 3000, null);
						this.describeAColumn(table, 'esonero_description', 'Descrizione', null, 4000, 256);
						this.describeAColumn(table, 'esonero_carriera_annoiscrmin', 'Anno iscrizione minimo', null, 4000, null);
						this.describeAColumn(table, 'esonero_applunavolta', 'Applicabile una sola volta', null, 5000, null);
						this.describeAColumn(table, 'esonero_carriera_cfaaprecmax', 'Crediti massimi anno precedente', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'esonero_carriera_cfaaprecmin', 'Crediti minimi anno precedente', 'fixed.2', 6000, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Sconto', null, 6200, 2024);
						this.describeAColumn(table, 'esoneroanskind_title', 'Tipologia Codice ANS', null, 7200, 50);
						this.describeAColumn(table, 'esoneroanskind_description', 'Descrizione Codice ANS', null, 7300, 256);
						this.describeAColumn(table, 'esonero_retroattivo', 'Retroattivo', null, 8000, null);
						this.describeAColumn(table, 'esonero_carriera_parttime', 'Part-time', null, 8000, null);
						this.describeAColumn(table, 'esonero_soloconisee', 'Applicabile solo con ISEE', null, 9000, null);
						this.describeAColumn(table, 'esonero_carriera_tutticfaaprec', 'Conseguiti tutti i crediti dell\'anno precedente', null, 9000, null);
//$objCalcFieldConfig_carriera$
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
					case "carriera": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonerocarrieraview', new meta_esonerocarrieraview('esonerocarrieraview'));

	}());
