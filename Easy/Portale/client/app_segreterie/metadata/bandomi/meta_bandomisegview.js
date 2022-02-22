
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Titolo del bando', null, 30, -1);
						this.describeAColumn(table, 'bandomi_cfminimi', 'Crediti formativi minimi per l\'accesso', 'fixed.2', 40, null);
						this.describeAColumn(table, 'bandomi_codice', 'Codice identificativo', null, 50, 50);
						this.describeAColumn(table, 'bandomi_datariferimentorequisiti', 'Data di riferimento per il calcolo dei requisiti', null, 60, null);
						this.describeAColumn(table, 'bandomi_durata', 'Durata', null, 70, null);
						this.describeAColumn(table, 'programmami_acronimo', 'Programma per la mobilità di riferimento', null, 80, 50);
						this.describeAColumn(table, 'accordoscambiomi_title', 'Accordo di scambio per la mobilità internazionale', null, 90, -1);
						this.describeAColumn(table, 'assicurazione_societaassicura', 'Società assicurativa Assicurazione', null, 100, 1024);
						this.describeAColumn(table, 'assicurazione_datascadenza', 'Data di scadenza Assicurazione', null, 100, null);
						this.describeAColumn(table, 'bandomobilitaintkind_title', 'Tipologia', null, 110, 200);
						this.describeAColumn(table, 'duratakind_title', 'Durata', null, 120, 50);
						this.describeAColumn(table, 'graduatoria_title', 'Graduatoria', null, 130, 256);
						this.describeAColumn(table, 'residence_description', 'Residenza', null, 140, 60);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di riferimento', null, 150, 1024);
						this.describeAColumn(table, 'bandomi_iscrittonellanno', 'Solo per iscritti nell\'anno', null, 160, null);
						this.describeAColumn(table, 'bandomi_maxpreferenze', 'Numero massimo di preferenze', null, 170, null);
						this.describeAColumn(table, 'bandomi_mediaminima', 'Mendia minima', 'fixed.2', 180, null);
						this.describeAColumn(table, 'bandomi_nessundebito', 'Nessun debito formativo', null, 190, null);
						this.describeAColumn(table, 'bandomi_numeroesamiminimo', 'Numero minimo di esami', null, 200, null);
						this.describeAColumn(table, 'bandomi_startcandidature', 'Data di inizio delle candidature', 'g', 210, null);
						this.describeAColumn(table, 'bandomi_startgraduatoria', 'Data di inizio della graduatoria', 'g', 220, null);
						this.describeAColumn(table, 'bandomi_startpermanenza', 'Data di inizio del periodo all\'estero', null, 230, null);
						this.describeAColumn(table, 'bandomi_startpresentazione', 'Data di inizio delle presentazioni dei Learning Agreement', 'g', 240, null);
						this.describeAColumn(table, 'bandomi_stopcadidature', 'Data di fine di presentazione delle candidature', 'g', 250, null);
						this.describeAColumn(table, 'bandomi_stopgraduatoria', 'Data di fine della graduatoria', 'g', 260, null);
						this.describeAColumn(table, 'bandomi_stoppermanenza', 'Data di fine di permanenza all\'estero', null, 270, null);
						this.describeAColumn(table, 'bandomi_stoppresentazione', 'Data di fine delle presentazioni dei Learning Agreement', 'g', 280, null);
						this.describeAColumn(table, 'bandomi_testodomanda', 'Testo della intestazione della domanda di ammissione', null, 290, -1);
						this.describeAColumn(table, 'bandomi_titolodomanda', 'Titolo della domanda di ammissione', null, 300, -1);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
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
