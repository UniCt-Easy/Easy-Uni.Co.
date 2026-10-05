(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_esonerotitolostudioview() {
        MetaData.apply(this, ["esonerotitolostudioview"]);
        this.name = 'meta_esonerotitolostudioview';
    }

    meta_esonerotitolostudioview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonerotitolostudioview,
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
					case 'titolostudio':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'esonero_titolostudio_conseguitoincorso', 'Conseguito in corso', null, 1000, null);
						this.describeAColumn(table, 'esonero_titolostudio_dataconstutticf', 'Data limite per aver conseguito tutti i crediti formativi', null, 2000, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 3000, 50);
						this.describeAColumn(table, 'esonero_titolostudio_datalaurea', 'Data limite di conseguimento del titolo', null, 3000, null);
						this.describeAColumn(table, 'esonero_description', 'Descrizione', null, 4000, 256);
						this.describeAColumn(table, 'esonero_applunavolta', 'Applicabile una sola volta', null, 5000, null);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura didattica', null, 5100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura didattica', null, 5220, 50);
						this.describeAColumn(table, 'esonero_titolostudio_nellistituto', 'Solo per corsi dell\'istituto', null, 6000, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Sconto', null, 6200, 2024);
						this.describeAColumn(table, 'esonero_titolostudio_noabbr', 'Senza abbreviazioni di carriera', null, 7000, null);
						this.describeAColumn(table, 'esoneroanskind_title', 'Tipologia Codice ANS', null, 7200, 50);
						this.describeAColumn(table, 'esoneroanskind_description', 'Descrizione Codice ANS', null, 7300, 256);
						this.describeAColumn(table, 'esonero_retroattivo', 'Retroattivo', null, 8000, null);
						this.describeAColumn(table, 'esonero_titolostudio_noparttime', 'Senza aver effettuato iscrizioni part-time', null, 8000, null);
						this.describeAColumn(table, 'esonero_soloconisee', 'Applicabile solo con ISEE', null, 9000, null);
						this.describeAColumn(table, 'esonero_titolostudio_votomin', 'Voto minimo', null, 9000, null);
//$objCalcFieldConfig_titolostudio$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idesonero"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "titolostudio": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonerotitolostudioview', new meta_esonerotitolostudioview('esonerotitolostudioview'));

	}());
