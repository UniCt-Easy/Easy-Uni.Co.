(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_praticasegistreinview() {
        MetaData.apply(this, ["praticasegistreinview"]);
        this.name = 'meta_praticasegistreinview';
    }

    meta_praticasegistreinview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticasegistreinview,
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
					case 'segistrein':
						this.describeAColumn(table, 'dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 3100, 9);
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia Tipologia Dichiarazione da convalidare', null, 3120, 50);
						this.describeAColumn(table, 'dichiar_date', 'Data Dichiarazione da convalidare', null, 3300, null);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 6100, 9);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 6300, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 6500, null);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 9120, 1024);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 9300, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 9700, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 9800, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 9900, null);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 10200, 50);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 12000, null);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 13000, null);
//$objCalcFieldConfig_segistrein$
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

			//$getSorting$

        });

    window.appMeta.addMeta('praticasegistreinview', new meta_praticasegistreinview('praticasegistreinview'));

	}());
