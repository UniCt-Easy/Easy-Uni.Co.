(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimentosegconsview() {
        MetaData.apply(this, ["sostenimentosegconsview"]);
        this.name = 'meta_sostenimentosegconsview';
    }

    meta_sostenimentosegconsview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimentosegconsview,
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
					case 'segcons':
						this.describeAColumn(table, 'registry_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'sostenimento_data', 'Data', null, 2000, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 3100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 3200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 3320, 1024);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT Titolo di studio', null, 4120, 1024);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademico Titolo di studio', null, 4300, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di studio', null, 4700, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di studio', null, 4800, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di studio', null, 4900, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 5100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 5300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 5500, null);
						this.describeAColumn(table, 'prova_title', 'Denominazione Prova', null, 6100, 50);
						this.describeAColumn(table, 'prova_start', 'Data e ora inizio Prova', 'g', 6200, null);
						this.describeAColumn(table, 'sostenimento_voto', 'Voto', 'fixed.2', 7000, null);
						this.describeAColumn(table, 'sostenimento_votosu', 'Su', null, 8000, null);
						this.describeAColumn(table, 'sostenimento_votolode', 'Lode', null, 9000, null);
						this.describeAColumn(table, 'sostenimentoesito_title', 'Esito', null, 10200, 50);
						this.describeAColumn(table, 'sostenimento_ects', 'ECTS', null, 11000, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 12000, 50);
						this.describeAColumn(table, 'sostenimento_protnumero', 'Numero Protocollo', null, 20000, null);
						this.describeAColumn(table, 'sostenimento_protanno', 'Anno protocollo', null, 21000, null);
//$objCalcFieldConfig_segcons$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idsostenimento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('sostenimentosegconsview', new meta_sostenimentosegconsview('sostenimentosegconsview'));

	}());
