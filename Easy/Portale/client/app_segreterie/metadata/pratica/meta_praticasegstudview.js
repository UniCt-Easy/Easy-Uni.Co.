(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_praticasegstudview() {
        MetaData.apply(this, ["praticasegstudview"]);
        this.name = 'meta_praticasegstudview';
    }

    meta_praticasegstudview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticasegstudview,
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
					case 'segstud':
						this.describeAColumn(table, 'registry_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 2100, 9);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 2500, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 3100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 3200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 3320, 1024);
						this.describeAColumn(table, 'istanza_aa', 'Istanza', null, 5100, 9);
						this.describeAColumn(table, 'istanza_data', 'Istanza', 'g', 5300, null);
						this.describeAColumn(table, 'istanza_iddidprog', 'Istanza', null, 5600, null);
						this.describeAColumn(table, 'istanza_idiscrizione', 'Istanza', null, 5700, null);
						this.describeAColumn(table, 'istanza_idistanzakind', 'Istanza', null, 5800, null);
						this.describeAColumn(table, 'istanza_idreg_studenti', 'Istanza', null, 5900, null);
						this.describeAColumn(table, 'istanza_idstatuskind', 'Istanza', null, 6000, null);
						this.describeAColumn(table, 'dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 10100, 9);
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia Tipologia Dichiarazione da convalidare', null, 10120, 50);
						this.describeAColumn(table, 'dichiar_date', 'Data Dichiarazione da convalidare', null, 10300, null);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 11100, 9);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 11500, null);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 12120, 1024);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 12300, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 12700, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 12800, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 12900, null);
						this.describeAColumn(table, 'istanzakind_title', 'Tipologia di istanza', null, 18200, 50);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 19200, 50);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 20000, null);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 21000, null);
//$objCalcFieldConfig_segstud$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idistanza", "idpratica", "idiscrizione", "idcorsostudio", "idistanzakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segstud": {
						return "registry_title desc, didprog_title desc";
					}
					case "segstud": {
						return "registry_title desc, didprog_title desc, didprog_aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('praticasegstudview', new meta_praticasegstudview('praticasegstudview'));

	}());
