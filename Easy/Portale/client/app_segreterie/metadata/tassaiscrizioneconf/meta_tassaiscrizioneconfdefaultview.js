(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassaiscrizioneconfdefaultview() {
        MetaData.apply(this, ["tassaiscrizioneconfdefaultview"]);
        this.name = 'meta_tassaiscrizioneconfdefaultview';
    }

    meta_tassaiscrizioneconfdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaiscrizioneconfdefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 3000, 2024);
						this.describeAColumn(table, 'aamax', 'Anno accademico massimo', null, 4000, 9);
						this.describeAColumn(table, 'aamin', 'Anno accademico minimo', null, 5000, 9);
						this.describeAColumn(table, 'tassaiscrizioneconf_annofcmax', 'Anno di iscrizione fuori corso massimo', null, 6000, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_annofcmin', 'Anno di iscrizione fuori corso minimo', null, 7000, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_annomax', 'Anno di iscrizione massimo', null, 8000, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_annomin', 'Anno di iscrizione minimo', null, 9000, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_corsostudio', 'Codice del corso di studio', null, 10000, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_didprog', 'Codice della didattica programmata', null, 11000, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_didprogcurr', 'Codice del curriculum', null, 12000, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_didprogori', 'Codice dell\'orientamento', null, 13000, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_corsisingoli', 'Corsi singoli', null, 14000, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Costo', null, 15200, 2024);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 20100, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 20600, null);
						this.describeAColumn(table, 'corsostudiokind_title', 'Tipo di corso', null, 21200, 50);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 22100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 22200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 22320, 1024);
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 23200, 256);
						this.describeAColumn(table, 'didprogori_title', 'orientamento', null, 24200, 256);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Dipartimento - Scuola', null, 25100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Dipartimento - Scuola', null, 25220, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtassaiscrizioneconf"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tassaiscrizioneconfdefaultview', new meta_tassaiscrizioneconfdefaultview('tassaiscrizioneconfdefaultview'));

	}());
