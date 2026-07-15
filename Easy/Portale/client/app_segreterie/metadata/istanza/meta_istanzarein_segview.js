(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzarein_segview() {
        MetaData.apply(this, ["istanzarein_segview"]);
        this.name = 'meta_istanzarein_segview';
    }

    meta_istanzarein_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzarein_segview,
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
					case 'rein_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 2000, null);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 3300, 101);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 5100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 5200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 5320, 1024);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui si vuole farsi reintegrare', null, 6100, 9);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione da cui si vuole farsi reintegrare', null, 6300, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui si vuole farsi reintegrare', null, 6500, null);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT Titolo di  studio da cui si vuole farsi reintegrare', null, 7120, 1024);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademico Titolo di  studio da cui si vuole farsi reintegrare', null, 7300, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di  studio da cui si vuole farsi reintegrare', null, 7700, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di  studio da cui si vuole farsi reintegrare', null, 7800, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di  studio da cui si vuole farsi reintegrare', null, 7900, null);
						this.describeAColumn(table, 'istanza_rein_darindec', 'Corso della rinuncia o decadenza ', null, 8000, null);
						this.describeAColumn(table, 'istanza_rein_datarindec', 'Data della rinuncia o decadenza ', null, 9000, null);
						this.describeAColumn(table, 'aa_rindec', 'Anno accademico della rinuncia o decadenza', null, 10000, 9);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 11200, 50);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 61000, null);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 62000, null);
//$objCalcFieldConfig_rein_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idistanza", "idiscrizione", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzarein_segview', new meta_istanzarein_segview('istanzarein_segview'));

	}());
