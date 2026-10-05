(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzatru_segview() {
        MetaData.apply(this, ["istanzatru_segview"]);
        this.name = 'meta_istanzatru_segview';
    }

    meta_istanzatru_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzatru_segview,
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
					case 'tru_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 2300, 101);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 6100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 6200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 6320, 1024);
						this.describeAColumn(table, 'iscrizioneattiveview_didprog_title', 'Corso Iscrizione', null, 7800, 1024);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_aa', 'AA Iscrizione', null, 9100, 9);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_anno', 'Anno Iscrizione', null, 9200, null);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_annofc', 'Anno F.C. Iscrizione', null, 9300, null);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_annopt', 'Anno P.T. Iscrizione', null, 9400, null);
						this.describeAColumn(table, 'iscrizioneattiveview_status', 'Stato Iscrizione', null, 10200, 10);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 12000, null);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 13000, null);
						this.describeAColumn(table, 'registryistituti_title', 'Istituto di destinazione', null, 54100, 101);
//$objCalcFieldConfig_tru_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idistanza", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzatru_segview', new meta_istanzatru_segview('istanzatru_segview'));

	}());
