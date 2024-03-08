(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_analisiannuale() {
        MetaData.apply(this, ["analisiannuale"]);
        this.name = 'meta_analisiannuale';
    }

    meta_analisiannuale.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_analisiannuale,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, '!denominatore0', 'Totale denominatore anno corrente', 'fixed.2', 0, null);
						this.describeAColumn(table, '!denominatore1', 'Totale denominatore anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!denominatore2', 'Denominatore secondo anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!denominatore3', 'Denominatore terzo anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!idattach_cessazione', 'Importa file cessazioni', null, 0, null);
						this.describeAColumn(table, '!importfilecontratti', 'Importa file dei contratti', null, 0, null);
						this.describeAColumn(table, '!importstipendi', 'Importa file degli stipendi', null, 0, null);
						this.describeAColumn(table, '!indicatore0', 'Indicatore spese di personale anno corrente', 'fixed.2', 0, null);
						this.describeAColumn(table, '!indicatore1', 'Indicatore spese di personale anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!indicatore2', 'Indicatore spese di personale secondo anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!indicatore3', 'Indicatore spese di personale terzo anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!numeratore0', 'Totale numeratore anno corrente', 'fixed.2', 0, null);
						this.describeAColumn(table, '!numeratore1', 'Totale numeratore anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!numeratore2', 'Totale denominatore secondo anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!numeratore3', 'Totale numeratore terzo anno successivo', 'fixed.2', 0, null);
						this.describeAColumn(table, '!year1', 'Anno successivo', null, 0, null);
						this.describeAColumn(table, '!year2', 'Secondo anno successivo', null, 0, null);
						this.describeAColumn(table, '!year3', 'Terzo anno successivo', null, 0, null);
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 4096);
						this.describeAColumn(table, 'costopt', 'Costo di un punto organico', 'fixed.2', 30, null);
						this.describeAColumn(table, 'incrementodocenti1', 'Punti percentuali di incremento annuale degli stipendi per i docenti anno successivo', 'fixed.2', 40, null);
						this.describeAColumn(table, 'tasse1', 'Tasse studenti anno successivo', 'fixed.2', 50, null);
						this.describeAColumn(table, 'ffo1', 'FFO anno successivo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'incrementodocenti2', 'Punti percentuali di incremento annuale degli stipendi per i docenti secondo anno successivo', 'fixed.2', 70, null);
						this.describeAColumn(table, 'tasse2', 'Tasse studenti  secondo anno successivo', 'fixed.2', 80, null);
						this.describeAColumn(table, 'ffo2', 'FFO  secondo anno successivo', 'fixed.2', 90, null);
						this.describeAColumn(table, 'incrementodocenti3', 'Punti percentuali di incremento annuale degli stipendi per i docenti terzo anno successivo', 'fixed.2', 100, null);
						this.describeAColumn(table, 'tasse3', 'Tasse studenti terzo anno successivo', 'fixed.2', 110, null);
						this.describeAColumn(table, 'ffo3', 'FFO terzo anno successivo', 'fixed.2', 120, null);
						this.describeAColumn(table, 'programmazionetriennale1', 'Programmazione triennale anno successivo', 'fixed.2', 170, null);
						this.describeAColumn(table, 'programmazionetriennale2', 'Programmazione triennale secondo anno successivo', 'fixed.2', 180, null);
						this.describeAColumn(table, 'programmazionetriennale3', 'Programmazione triennale terzo anno successivo', 'fixed.2', 190, null);
						this.describeAColumn(table, 'contrattiincarichiinsegnamento1', 'Contratti per incarichi di insegnamento anno successivo', 'fixed.2', 200, null);
						this.describeAColumn(table, 'contrattiincarichiinsegnamento2', 'Contratti per incarichi di insegnamento secondo anno successivo', 'fixed.2', 210, null);
						this.describeAColumn(table, 'contrattiincarichiinsegnamento3', 'Contratti per incarichi di insegnamento terzo anno successivo', 'fixed.2', 220, null);
						this.describeAColumn(table, 'fondocontrattazioneintegrativa1', 'Fondo contrattazione integrativa anno successivo', 'fixed.2', 230, null);
						this.describeAColumn(table, 'fondocontrattazioneintegrativa2', 'Fondo contrattazione integrativa secondo anno successivo', 'fixed.2', 240, null);
						this.describeAColumn(table, 'fondocontrattazioneintegrativa3', 'Fondo contrattazione integrativa terzo anno successivo', 'fixed.2', 250, null);
						this.describeAColumn(table, 'contrattiincarichiinsegnamento0', 'Contratti per incarichi di insegnamento anno corrente', 'fixed.2', 260, null);
						this.describeAColumn(table, 'ffo0', 'FFO anno corrente', 'fixed.2', 270, null);
						this.describeAColumn(table, 'finanzesternidirPTA0', 'Finanziamenti esterni per dirigenti e personale TA anno corrente', 'fixed.2', 280, null);
						this.describeAColumn(table, 'finanzesternidirPTA1', 'Finanziamenti esterni per dirigenti e personale TA anno successivo', 'fixed.2', 290, null);
						this.describeAColumn(table, 'finanzesternidirPTA2', 'Finanziamenti esterni per dirigenti e personale TA secondo anno successivo', 'fixed.2', 300, null);
						this.describeAColumn(table, 'finanzesternidirPTA3', 'Finanziamenti esterni per dirigenti e personale TA terzo anno successivo', 'fixed.2', 310, null);
						this.describeAColumn(table, 'finanzesternidocenti0', 'Finanziamenti esterni per docenti anno corrente', 'fixed.2', 320, null);
						this.describeAColumn(table, 'finanzesternidocenti1', 'Finanziamenti esterni per docenti anno successivo', 'fixed.2', 330, null);
						this.describeAColumn(table, 'finanzesternidocenti2', 'Finanziamenti esterni per docenti secondo anno successivo', 'fixed.2', 340, null);
						this.describeAColumn(table, 'finanzesternidocenti3', 'Finanziamenti esterni per docenti terzo anno successivo', 'fixed.2', 350, null);
						this.describeAColumn(table, 'fondocontrattazioneintegrativa0', 'Fondo contrattazione integrativa anno corrente', 'fixed.2', 360, null);
						this.describeAColumn(table, 'programmazionetriennale0', 'Programmazione triennale terzo anno corrente', 'fixed.2', 370, null);
						this.describeAColumn(table, 'speseDG0', 'Direttore Generale anno corrente', 'fixed.2', 380, null);
						this.describeAColumn(table, 'speseDG1', 'Direttore Generale anno successivo', 'fixed.2', 390, null);
						this.describeAColumn(table, 'speseDG2', 'Direttore Generale secondo anno successivo', 'fixed.2', 400, null);
						this.describeAColumn(table, 'speseDG3', 'Direttore Generale terzo anno successivo', 'fixed.2', 410, null);
						this.describeAColumn(table, 'spesedirPTA0', 'Spese per dirigenti e personale TA anno corrente', 'fixed.2', 420, null);
						this.describeAColumn(table, 'spesedirPTA1', 'Spese di dirigenti e personale TA anno successivo', 'fixed.2', 430, null);
						this.describeAColumn(table, 'spesedirPTA2', 'Spese di dirigenti e personale TA secondo anno successivo', 'fixed.2', 440, null);
						this.describeAColumn(table, 'spesedirPTA3', 'Spese di dirigenti e personale TA terzo anno successivo', 'fixed.2', 450, null);
						this.describeAColumn(table, 'spesedocenti0', 'Spese di personale docente anno corrente', 'fixed.2', 460, null);
						this.describeAColumn(table, 'spesedocenti1', 'Spese di personale docente anno successivo', 'fixed.2', 470, null);
						this.describeAColumn(table, 'spesedocenti2', 'Spese di personale docente secondo anno successivo', 'fixed.2', 480, null);
						this.describeAColumn(table, 'spesedocenti3', 'Spese di personale docente terzo anno successivo', 'fixed.2', 490, null);
						this.describeAColumn(table, 'tasse0', 'Tasse studenti anno correntre', 'fixed.2', 500, null);
						this.describeAColumn(table, 'totspesepersonalecaricoateneo0', 'Totale spese di personale a carico Ateneo anno corrente', 'fixed.2', 510, null);
						this.describeAColumn(table, 'totspesepersonalecaricoateneo1', 'Totale spese di personale a carico Ateneo anno successivo', 'fixed.2', 520, null);
						this.describeAColumn(table, 'totspesepersonalecaricoateneo2', 'Totale spese di personale a carico Ateneo secondo anno successivo', 'fixed.2', 530, null);
						this.describeAColumn(table, 'totspesepersonalecaricoateneo3', 'Totale spese di personale a carico Ateneo terzo anno successivo', 'fixed.2', 540, null);
						this.describeAColumn(table, 'trattamentostipintegrativoCEL0', 'Trattamento stipendiale integrativo CEL anno corrente', 'fixed.2', 560, null);
						this.describeAColumn(table, 'trattamentostipintegrativoCEL1', 'Trattamento stipendiale integrativo CEL anno successivo', 'fixed.2', 570, null);
						this.describeAColumn(table, 'trattamentostipintegrativoCEL2', 'Trattamento stipendiale integrativo CEL secondo anno successivo', 'fixed.2', 580, null);
						this.describeAColumn(table, 'trattamentostipintegrativoCEL3', 'Trattamento stipendiale integrativo CEL terzo anno successivo', 'fixed.2', 590, null);
						this.describeAColumn(table, 'finanzesternicontrattiincarichiinsegnamento0', 'Finanziamenti esterni per contratti per incarichi di insegnamento anno corrente', 'fixed.2', 600, null);
						this.describeAColumn(table, 'finanzesternicontrattiincarichiinsegnamento1', 'Finanziamenti esterni per contratti per incarichi di insegnamento anno successivo', 'fixed.2', 610, null);
						this.describeAColumn(table, 'finanzesternicontrattiincarichiinsegnamento2', 'Finanziamenti esterni per contratti per incarichi di insegnamento secondo anno successivo', 'fixed.2', 620, null);
						this.describeAColumn(table, 'finanzesternicontrattiincarichiinsegnamento3', 'Finanziamenti esterni per contratti per incarichi di insegnamento terzo anno successivo', 'fixed.2', 630, null);
						this.describeAColumn(table, 'speseriduzione0', 'Spese a riduzione', 'fixed.2', 640, null);
						this.describeAColumn(table, 'speseriduzione1', 'Spese a riduzione anno successivo', 'fixed.2', 650, null);
						this.describeAColumn(table, 'speseriduzione2', 'Spese a riduzione secondo anno successivo', 'fixed.2', 660, null);
						this.describeAColumn(table, 'speseriduzione3', 'Spese a riduzione terzo anno successivo', 'fixed.2', 670, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["!denominatore0"].caption = "Totale denominatore anno corrente";
						table.columns["!denominatore1"].caption = "Totale denominatore anno successivo";
						table.columns["!denominatore2"].caption = "Denominatore secondo anno successivo";
						table.columns["!denominatore3"].caption = "Denominatore terzo anno successivo";
						table.columns["!indicatore0"].caption = "Indicatore spese di personale anno corrente";
						table.columns["!indicatore1"].caption = "Indicatore spese di personale anno successivo";
						table.columns["!indicatore2"].caption = "Indicatore spese di personale secondo anno successivo";
						table.columns["!indicatore3"].caption = "Indicatore spese di personale terzo anno successivo";
						table.columns["!numeratore0"].caption = "Totale numeratore anno corrente";
						table.columns["!numeratore1"].caption = "Totale numeratore anno successivo";
						table.columns["!numeratore2"].caption = "Totale denominatore secondo anno successivo";
						table.columns["!numeratore3"].caption = "Totale numeratore terzo anno successivo";
						table.columns["!year1"].caption = "Anno successivo";
						table.columns["!year2"].caption = "Secondo anno successivo";
						table.columns["!year3"].caption = "Terzo anno successivo";
						table.columns["contrattiincarichiinsegnamento0"].caption = "Contratti per incarichi di insegnamento anno corrente";
						table.columns["contrattiincarichiinsegnamento1"].caption = "Contratti per incarichi di insegnamento anno successivo";
						table.columns["contrattiincarichiinsegnamento2"].caption = "Contratti per incarichi di insegnamento secondo anno successivo";
						table.columns["contrattiincarichiinsegnamento3"].caption = "Contratti per incarichi di insegnamento terzo anno successivo";
						table.columns["costopt"].caption = "Costo di un punto organico";
						table.columns["ffo0"].caption = "FFO anno corrente";
						table.columns["ffo1"].caption = "FFO anno successivo";
						table.columns["ffo2"].caption = "FFO  secondo anno successivo";
						table.columns["ffo3"].caption = "FFO terzo anno successivo";
						table.columns["finanzesternicontrattiincarichiinsegnamento0"].caption = "Finanziamenti esterni per contratti per incarichi di insegnamento anno corrente";
						table.columns["finanzesternicontrattiincarichiinsegnamento1"].caption = "Finanziamenti esterni per contratti per incarichi di insegnamento anno successivo";
						table.columns["finanzesternicontrattiincarichiinsegnamento2"].caption = "Finanziamenti esterni per contratti per incarichi di insegnamento secondo anno successivo";
						table.columns["finanzesternicontrattiincarichiinsegnamento3"].caption = "Finanziamenti esterni per contratti per incarichi di insegnamento terzo anno successivo";
						table.columns["finanzesternidirPTA0"].caption = "Finanziamenti esterni per dirigenti e personale TA anno corrente";
						table.columns["finanzesternidirPTA1"].caption = "Finanziamenti esterni per dirigenti e personale TA anno successivo";
						table.columns["finanzesternidirPTA2"].caption = "Finanziamenti esterni per dirigenti e personale TA secondo anno successivo";
						table.columns["finanzesternidirPTA3"].caption = "Finanziamenti esterni per dirigenti e personale TA terzo anno successivo";
						table.columns["finanzesternidocenti0"].caption = "Finanziamenti esterni per docenti anno corrente";
						table.columns["finanzesternidocenti1"].caption = "Finanziamenti esterni per docenti anno successivo";
						table.columns["finanzesternidocenti2"].caption = "Finanziamenti esterni per docenti secondo anno successivo";
						table.columns["finanzesternidocenti3"].caption = "Finanziamenti esterni per docenti terzo anno successivo";
						table.columns["fondocontrattazioneintegrativa0"].caption = "Fondo contrattazione integrativa anno corrente";
						table.columns["fondocontrattazioneintegrativa1"].caption = "Fondo contrattazione integrativa anno successivo";
						table.columns["fondocontrattazioneintegrativa2"].caption = "Fondo contrattazione integrativa secondo anno successivo";
						table.columns["fondocontrattazioneintegrativa3"].caption = "Fondo contrattazione integrativa terzo anno successivo";
						table.columns["incrementodocenti1"].caption = "Punti percentuali di incremento annuale degli stipendi per i docenti anno successivo";
						table.columns["incrementodocenti2"].caption = "Punti percentuali di incremento annuale degli stipendi per i docenti secondo anno successivo";
						table.columns["incrementodocenti3"].caption = "Punti percentuali di incremento annuale degli stipendi per i docenti terzo anno successivo";
						table.columns["programmazionetriennale0"].caption = "Programmazione triennale terzo anno corrente";
						table.columns["programmazionetriennale1"].caption = "Programmazione triennale anno successivo";
						table.columns["programmazionetriennale2"].caption = "Programmazione triennale secondo anno successivo";
						table.columns["programmazionetriennale3"].caption = "Programmazione triennale terzo anno successivo";
						table.columns["speseDG0"].caption = "Direttore Generale anno corrente";
						table.columns["speseDG1"].caption = "Direttore Generale anno successivo";
						table.columns["speseDG2"].caption = "Direttore Generale secondo anno successivo";
						table.columns["speseDG3"].caption = "Direttore Generale terzo anno successivo";
						table.columns["spesedirPTA0"].caption = "Spese per dirigenti e personale TA anno corrente";
						table.columns["spesedirPTA1"].caption = "Spese di dirigenti e personale TA anno successivo";
						table.columns["spesedirPTA2"].caption = "Spese di dirigenti e personale TA secondo anno successivo";
						table.columns["spesedirPTA3"].caption = "Spese di dirigenti e personale TA terzo anno successivo";
						table.columns["spesedocenti0"].caption = "Spese di personale docente anno corrente";
						table.columns["spesedocenti1"].caption = "Spese di personale docente anno successivo";
						table.columns["spesedocenti2"].caption = "Spese di personale docente secondo anno successivo";
						table.columns["spesedocenti3"].caption = "Spese di personale docente terzo anno successivo";
						table.columns["speseriduzione0"].caption = "Spese a riduzione";
						table.columns["speseriduzione1"].caption = "Spese a riduzione anno successivo";
						table.columns["speseriduzione2"].caption = "Spese a riduzione secondo anno successivo";
						table.columns["speseriduzione3"].caption = "Spese a riduzione terzo anno successivo";
						table.columns["tasse0"].caption = "Tasse studenti anno correntre";
						table.columns["tasse1"].caption = "Tasse studenti anno successivo";
						table.columns["tasse2"].caption = "Tasse studenti  secondo anno successivo";
						table.columns["tasse3"].caption = "Tasse studenti terzo anno successivo";
						table.columns["title"].caption = "Titolo";
						table.columns["totspesepersonalecaricoateneo0"].caption = "Totale spese di personale a carico Ateneo anno corrente";
						table.columns["totspesepersonalecaricoateneo1"].caption = "Totale spese di personale a carico Ateneo anno successivo";
						table.columns["totspesepersonalecaricoateneo2"].caption = "Totale spese di personale a carico Ateneo secondo anno successivo";
						table.columns["totspesepersonalecaricoateneo3"].caption = "Totale spese di personale a carico Ateneo terzo anno successivo";
						table.columns["trattamentostipintegrativoCEL0"].caption = "Trattamento stipendiale integrativo CEL anno corrente";
						table.columns["trattamentostipintegrativoCEL1"].caption = "Trattamento stipendiale integrativo CEL anno successivo";
						table.columns["trattamentostipintegrativoCEL2"].caption = "Trattamento stipendiale integrativo CEL secondo anno successivo";
						table.columns["trattamentostipintegrativoCEL3"].caption = "Trattamento stipendiale integrativo CEL terzo anno successivo";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_analisiannuale");

				//$getNewRowInside$

				//dt.autoIncrement('year', { minimum: 99990001 });
				dt.autoIncrement('idanalisiannuale', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},








			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "year asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('analisiannuale', new meta_analisiannuale('analisiannuale'));

	}());
