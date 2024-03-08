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
						this.describeAColumn(table, 'annoaccademico_iscrizione_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'annoaccademico_iscrizione_1_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'dichiar_idreg', 'Studente Dichiarazione da convalidare', null, 10, null);
						this.describeAColumn(table, 'dichiar_date', 'Data Dichiarazione da convalidare', null, 10, null);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 20, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 20, null);
						this.describeAColumn(table, 'iscrizione_pratica_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 40, null);
						this.describeAColumn(table, 'iscrizione_pratica_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 40, null);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 50, 50);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 50, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 50, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 50, null);
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
