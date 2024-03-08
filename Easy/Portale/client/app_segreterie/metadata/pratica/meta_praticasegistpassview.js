(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_praticasegistpassview() {
        MetaData.apply(this, ["praticasegistpassview"]);
        this.name = 'meta_praticasegistpassview';
    }

    meta_praticasegistpassview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticasegistpassview,
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
					case 'segistpass':
						this.describeAColumn(table, 'dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 30, 9);
						this.describeAColumn(table, 'dichiar_extension', 'Tabella che estende il record Dichiarazione da convalidare', null, 30, 200);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 50, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 50, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 50, 9);
						this.describeAColumn(table, 'iscrizione_pratica_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 60, null);
						this.describeAColumn(table, 'iscrizione_pratica_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 60, null);
						this.describeAColumn(table, 'iscrizione_pratica_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 60, 9);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 100, 50);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademco Titolo studio da cui si vogliono convalidare i sostenimenti', null, 110, 9);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT', null, 10, 1024);
						this.describeAColumn(table, 'istattitolistudio_idistattitolistudio', 'Titolo ISTAT Titolo ISTAT', null, 10, null);
//$objCalcFieldConfig_segistpass$
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

    window.appMeta.addMeta('praticasegistpassview', new meta_praticasegistpassview('praticasegistpassview'));

	}());
