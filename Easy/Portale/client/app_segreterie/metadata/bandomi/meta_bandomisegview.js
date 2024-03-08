(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomisegview() {
        MetaData.apply(this, ["bandomisegview"]);
        this.name = 'meta_bandomisegview';
    }

    meta_bandomisegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomisegview,
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
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 1000, 9);
						this.describeAColumn(table, 'title', 'Titolo del bando', null, 3000, -1);
						this.describeAColumn(table, 'bandomi_cfminimi', 'Crediti formativi minimi per l\'accesso', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'bandomi_codice', 'Codice identificativo', null, 5000, 50);
						this.describeAColumn(table, 'bandomi_datariferimentorequisiti', 'Data di riferimento per il calcolo dei requisiti', null, 6000, null);
						this.describeAColumn(table, 'bandomi_durata', 'Durata', null, 7000, null);
						this.describeAColumn(table, 'programmami_acronimo', 'Programma per la mobilità di riferimento', null, 8400, 50);
						this.describeAColumn(table, 'accordoscambiomi_title', 'Accordo di scambio per la mobilità internazionale', null, 9100, -1);
						this.describeAColumn(table, 'assicurazione_societaassicura', 'Società assicurativa Assicurazione', null, 10100, 1024);
						this.describeAColumn(table, 'assicurazione_datascadenza', 'Data di scadenza Assicurazione', null, 10300, null);
						this.describeAColumn(table, 'bandomobilitaintkind_title', 'Tipologia', null, 11200, 200);
						this.describeAColumn(table, 'duratakind_title', 'Durata', null, 12200, 50);
						this.describeAColumn(table, 'graduatoria_title', 'Graduatoria', null, 13200, 256);
						this.describeAColumn(table, 'residence_description', 'Residenza', null, 14200, 60);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di riferimento', null, 15100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura di riferimento', null, 15220, 50);
						this.describeAColumn(table, 'bandomi_iscrittonellanno', 'Solo per iscritti nell\'anno', null, 16000, null);
						this.describeAColumn(table, 'bandomi_maxpreferenze', 'Numero massimo di preferenze', null, 17000, null);
						this.describeAColumn(table, 'bandomi_mediaminima', 'Mendia minima', 'fixed.2', 18000, null);
						this.describeAColumn(table, 'bandomi_nessundebito', 'Nessun debito formativo', null, 19000, null);
						this.describeAColumn(table, 'bandomi_numeroesamiminimo', 'Numero minimo di esami', null, 20000, null);
						this.describeAColumn(table, 'bandomi_startcandidature', 'Data di inizio delle candidature', 'g', 21000, null);
						this.describeAColumn(table, 'bandomi_startgraduatoria', 'Data di inizio della graduatoria', 'g', 22000, null);
						this.describeAColumn(table, 'bandomi_startpermanenza', 'Data di inizio del periodo all\'estero', null, 23000, null);
						this.describeAColumn(table, 'bandomi_startpresentazione', 'Data di inizio delle presentazioni dei Learning Agreement', 'g', 24000, null);
						this.describeAColumn(table, 'bandomi_stopcadidature', 'Data di fine di presentazione delle candidature', 'g', 25000, null);
						this.describeAColumn(table, 'bandomi_stopgraduatoria', 'Data di fine della graduatoria', 'g', 26000, null);
						this.describeAColumn(table, 'bandomi_stoppermanenza', 'Data di fine di permanenza all\'estero', null, 27000, null);
						this.describeAColumn(table, 'bandomi_stoppresentazione', 'Data di fine delle presentazioni dei Learning Agreement', 'g', 28000, null);
						this.describeAColumn(table, 'bandomi_testodomanda', 'Testo della intestazione della domanda di ammissione', null, 29000, -1);
						this.describeAColumn(table, 'bandomi_titolodomanda', 'Titolo della domanda di ammissione', null, 30000, -1);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idbandomi"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('bandomisegview', new meta_bandomisegview('bandomisegview'));

	}());
