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
						this.describeAColumn(table, 'annoaccademico_didprog_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'annoaccademico_iscrizione_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'annoaccademico_iscrizione_1_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 10, 101);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 20, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 20, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 30, 1024);
						this.describeAColumn(table, 'istanza_idistanzakind', 'Istanza', null, 50, null);
						this.describeAColumn(table, 'istanza_idreg_studenti', 'Istanza', null, 50, null);
						this.describeAColumn(table, 'istanza_aa', 'Istanza', null, 50, 9);
						this.describeAColumn(table, 'istanza_data', 'Istanza', 'g', 50, null);
						this.describeAColumn(table, 'istanza_iddidprog', 'Istanza', null, 50, null);
						this.describeAColumn(table, 'istanza_idstatuskind', 'Istanza', null, 50, null);
						this.describeAColumn(table, 'istanza_idiscrizione', 'Istanza', null, 50, null);
						this.describeAColumn(table, 'dichiar_idreg', 'Studente Dichiarazione da convalidare', null, 100, null);
						this.describeAColumn(table, 'dichiar_date', 'Data Dichiarazione da convalidare', null, 100, null);
						this.describeAColumn(table, 'iscrizione_pratica_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'iscrizione_pratica_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 110, null);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 120, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 120, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 120, null);
						this.describeAColumn(table, 'istanzakind_title', 'Tipologia di istanza', null, 180, 50);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 190, 50);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 210, null);
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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('praticasegstudview', new meta_praticasegstudview('praticasegstudview'));

	}());
