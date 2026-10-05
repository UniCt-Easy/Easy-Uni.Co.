(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_praticaseganagstuview() {
        MetaData.apply(this, ["praticaseganagstuview"]);
        this.name = 'meta_praticaseganagstuview';
    }

    meta_praticaseganagstuview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticaseganagstuview,
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
					case 'seganagstu':
						this.describeAColumn(table, 'dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 1100, 9);
						this.describeAColumn(table, 'dichiar_extension', 'Tabella che estende il record Dichiarazione da convalidare', null, 1400, 200);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 2100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 2300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 2500, null);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 4100, 9);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 4300, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 4500, null);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 5120, 1024);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 5300, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 5700, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 5800, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 5900, null);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 6200, 50);
//$objCalcFieldConfig_seganagstu$
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

    window.appMeta.addMeta('praticaseganagstuview', new meta_praticaseganagstuview('praticaseganagstuview'));

	}());
