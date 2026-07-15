(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzasosp_segview() {
        MetaData.apply(this, ["istanzasosp_segview"]);
        this.name = 'meta_istanzasosp_segview';
    }

    meta_istanzasosp_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzasosp_segview,
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
					case 'sosp_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 5100, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 5600, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 6100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 6200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 6320, 1024);
						this.describeAColumn(table, 'iscrizioneattiveview_didprog_title', 'Corso Iscrizione', null, 7800, 1024);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_aa', 'AA Iscrizione', null, 9100, 9);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_anno', 'Anno Iscrizione', null, 9200, null);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_annofc', 'Anno F.C. Iscrizione', null, 9300, null);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 9300, 101);
						this.describeAColumn(table, 'iscrizioneattiveview_last_renew_annopt', 'Anno P.T. Iscrizione', null, 9400, null);
						this.describeAColumn(table, 'iscrizioneattiveview_status', 'Stato Iscrizione', null, 10200, 10);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanzaparent_aa', 'Anno accademico Istanza collegata', null, 11100, 9);
						this.describeAColumn(table, 'istanzaparent_data', 'Data Istanza collegata', 'g', 11300, null);
						this.describeAColumn(table, 'istanzaparent_idistanzakind', 'Tipologia Istanza collegata', null, 11800, null);
						this.describeAColumn(table, 'istanzaparent_idreg_studenti', 'Studente Istanza collegata', null, 11900, null);
						this.describeAColumn(table, 'istanza_sosp_motivo', 'Motivo', null, 54000, -1);
						this.describeAColumn(table, 'istanza_sosp_start', 'Data di Inizio', null, 55000, null);
						this.describeAColumn(table, 'istanza_sosp_stop', 'Data di fine', null, 56000, null);
//$objCalcFieldConfig_sosp_seg$
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

    window.appMeta.addMeta('istanzasosp_segview', new meta_istanzasosp_segview('istanzasosp_segview'));

	}());
