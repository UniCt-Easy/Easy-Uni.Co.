
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

    function meta_analisiannualedefaultview() {
        MetaData.apply(this, ["analisiannualedefaultview"]);
        this.name = 'meta_analisiannualedefaultview';
    }

    meta_analisiannualedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_analisiannualedefaultview,
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
					case 'default':
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'analisiannuale_costopt', 'Costo di un punto organico', 'fixed.2', 30, null);
						this.describeAColumn(table, 'analisiannuale_incrementodocenti1', 'Punti percentuali di incremento annuale degli stipendi per i docenti anno successivo', 'fixed.2', 40, null);
						this.describeAColumn(table, 'analisiannuale_tasse1', 'Tasse studenti anno successivo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'analisiannuale_ffo1', 'FFO anno successivo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'analisiannuale_incrementodocenti2', 'Punti percentuali di incremento annuale degli stipendi per i docenti secondo anno successivo', 'fixed.2', 70, null);
						this.describeAColumn(table, 'analisiannuale_tasse2', 'Tasse studenti  secondo anno successivo', 'fixed.2', 80, null);
						this.describeAColumn(table, 'analisiannuale_ffo2', 'FFO  secondo anno successivo', 'fixed.2', 90, null);
						this.describeAColumn(table, 'analisiannuale_incrementodocenti3', 'Punti percentuali di incremento annuale degli stipendi per i docenti terzo anno successivo', 'fixed.2', 100, null);
						this.describeAColumn(table, 'analisiannuale_tasse3', 'Tasse studenti terzo anno successivo', 'fixed.2', 110, null);
						this.describeAColumn(table, 'analisiannuale_ffo3', 'FFO terzo anno successivo', 'fixed.2', 120, null);
						this.describeAColumn(table, 'analisiannuale_programmazionetriennale1', 'Programmazione triennale anno successivo', 'fixed.2', 170, null);
						this.describeAColumn(table, 'analisiannuale_programmazionetriennale2', 'Programmazione triennale secondo anno successivo', 'fixed.2', 180, null);
						this.describeAColumn(table, 'analisiannuale_programmazionetriennale3', 'Programmazione triennale terzo anno successivo', 'fixed.2', 190, null);
						this.describeAColumn(table, 'analisiannuale_contrattiincarichiinsegnamento1', 'Contratti per incarichi di insegnamento anno successivo', 'fixed.2', 200, null);
						this.describeAColumn(table, 'analisiannuale_contrattiincarichiinsegnamento2', 'Contratti per incarichi di insegnamento secondo anno successivo', 'fixed.2', 210, null);
						this.describeAColumn(table, 'analisiannuale_contrattiincarichiinsegnamento3', 'Contratti per incarichi di insegnamento terzo anno successivo', 'fixed.2', 220, null);
						this.describeAColumn(table, 'analisiannuale_fondocontrattazioneintegrativa1', 'Fondo contrattazione integrativa anno successivo', 'fixed.2', 230, null);
						this.describeAColumn(table, 'analisiannuale_fondocontrattazioneintegrativa2', 'Fondo contrattazione integrativa secondo anno successivo', 'fixed.2', 240, null);
						this.describeAColumn(table, 'analisiannuale_fondocontrattazioneintegrativa3', 'Fondo contrattazione integrativa terzo anno successivo', 'fixed.2', 250, null);
						this.describeAColumn(table, 'analisiannuale_contrattiincarichiinsegnamento0', 'Contratti per incarichi di insegnamento anno corrente', 'fixed.2', 260, null);
						this.describeAColumn(table, 'analisiannuale_ffo0', 'FFO anno corrente', 'fixed.2', 270, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidirPTA0', 'Finanziamenti esterni per dirigenti e personale TA anno corrente', 'fixed.2', 280, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidirPTA1', 'Finanziamenti esterni per dirigenti e personale TA anno successivo', 'fixed.2', 290, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidirPTA2', 'Finanziamenti esterni per dirigenti e personale TA secondo anno successivo', 'fixed.2', 300, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidirPTA3', 'Finanziamenti esterni per dirigenti e personale TA terzo anno successivo', 'fixed.2', 310, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidocenti0', 'Finanziamenti esterni per docenti anno corrente', 'fixed.2', 320, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidocenti1', 'Finanziamenti esterni per docenti anno successivo', 'fixed.2', 330, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidocenti2', 'Finanziamenti esterni per docenti secondo anno successivo', 'fixed.2', 340, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternidocenti3', 'Finanziamenti esterni per docenti terzo anno successivo', 'fixed.2', 350, null);
						this.describeAColumn(table, 'analisiannuale_fondocontrattazioneintegrativa0', 'Fondo contrattazione integrativa anno corrente', 'fixed.2', 360, null);
						this.describeAColumn(table, 'analisiannuale_programmazionetriennale0', 'Programmazione triennale terzo anno corrente', 'fixed.2', 370, null);
						this.describeAColumn(table, 'analisiannuale_speseDG0', 'Direttore Generale anno corrente', 'fixed.2', 380, null);
						this.describeAColumn(table, 'analisiannuale_speseDG1', 'Direttore Generale anno successivo', 'fixed.2', 390, null);
						this.describeAColumn(table, 'analisiannuale_speseDG2', 'Direttore Generale secondo anno successivo', 'fixed.2', 400, null);
						this.describeAColumn(table, 'analisiannuale_speseDG3', 'Direttore Generale terzo anno successivo', 'fixed.2', 410, null);
						this.describeAColumn(table, 'analisiannuale_spesedirPTA0', 'Spese per dirigenti e personale TA anno corrente', 'fixed.2', 420, null);
						this.describeAColumn(table, 'analisiannuale_spesedirPTA1', 'Spese di dirigenti e personale TA anno successivo', 'fixed.2', 430, null);
						this.describeAColumn(table, 'analisiannuale_spesedirPTA2', 'Spese di dirigenti e personale TA secondo anno successivo', 'fixed.2', 440, null);
						this.describeAColumn(table, 'analisiannuale_spesedirPTA3', 'Spese di dirigenti e personale TA terzo anno successivo', 'fixed.2', 450, null);
						this.describeAColumn(table, 'analisiannuale_spesedocenti0', 'Spese di personale docente anno corrente', 'fixed.2', 460, null);
						this.describeAColumn(table, 'analisiannuale_spesedocenti1', 'Spese di personale docente anno successivo', 'fixed.2', 470, null);
						this.describeAColumn(table, 'analisiannuale_spesedocenti2', 'Spese di personale docente secondo anno successivo', 'fixed.2', 480, null);
						this.describeAColumn(table, 'analisiannuale_spesedocenti3', 'Spese di personale docente terzo anno successivo', 'fixed.2', 490, null);
						this.describeAColumn(table, 'analisiannuale_tasse0', 'Tasse studenti anno correntre', 'fixed.2', 500, null);
						this.describeAColumn(table, 'analisiannuale_totspesepersonalecaricoateneo0', 'Totale spese di personale a carico Ateneo anno corrente', 'fixed.2', 510, null);
						this.describeAColumn(table, 'analisiannuale_totspesepersonalecaricoateneo1', 'Totale spese di personale a carico Ateneo anno successivo', 'fixed.2', 520, null);
						this.describeAColumn(table, 'analisiannuale_totspesepersonalecaricoateneo2', 'Totale spese di personale a carico Ateneo secondo anno successivo', 'fixed.2', 530, null);
						this.describeAColumn(table, 'analisiannuale_totspesepersonalecaricoateneo3', 'Totale spese di personale a carico Ateneo terzo anno successivo', 'fixed.2', 540, null);
						this.describeAColumn(table, 'analisiannuale_trattamentostipintegrativoCEL0', 'Trattamento stipendiale integrativo CEL anno corrente', 'fixed.2', 560, null);
						this.describeAColumn(table, 'analisiannuale_trattamentostipintegrativoCEL1', 'Trattamento stipendiale integrativo CEL anno successivo', 'fixed.2', 570, null);
						this.describeAColumn(table, 'analisiannuale_trattamentostipintegrativoCEL2', 'Trattamento stipendiale integrativo CEL secondo anno successivo', 'fixed.2', 580, null);
						this.describeAColumn(table, 'analisiannuale_trattamentostipintegrativoCEL3', 'Trattamento stipendiale integrativo CEL terzo anno successivo', 'fixed.2', 590, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternicontrattiincarichiinsegnamento0', 'Finanziamenti esterni per contratti per incarichi di insegnamento anno corrente', 'fixed.2', 600, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternicontrattiincarichiinsegnamento1', 'Finanziamenti esterni per contratti per incarichi di insegnamento anno successivo', 'fixed.2', 610, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternicontrattiincarichiinsegnamento2', 'Finanziamenti esterni per contratti per incarichi di insegnamento secondo anno successivo', 'fixed.2', 620, null);
						this.describeAColumn(table, 'analisiannuale_finanzesternicontrattiincarichiinsegnamento3', 'Finanziamenti esterni per contratti per incarichi di insegnamento terzo anno successivo', 'fixed.2', 630, null);
						this.describeAColumn(table, 'analisiannuale_speseriduzione0', 'Spese a riduzione', 'fixed.2', 640, null);
						this.describeAColumn(table, 'analisiannuale_speseriduzione1', 'Spese a riduzione anno successivo', 'fixed.2', 650, null);
						this.describeAColumn(table, 'analisiannuale_speseriduzione2', 'Spese a riduzione secondo anno successivo', 'fixed.2', 660, null);
						this.describeAColumn(table, 'analisiannuale_speseriduzione3', 'Spese a riduzione terzo anno successivo', 'fixed.2', 670, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["year"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('analisiannualedefaultview', new meta_analisiannualedefaultview('analisiannualedefaultview'));

	}());
