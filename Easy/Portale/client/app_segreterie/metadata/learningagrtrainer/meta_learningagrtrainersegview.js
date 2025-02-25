(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_learningagrtrainersegview() {
        MetaData.apply(this, ["learningagrtrainersegview"]);
        this.name = 'meta_learningagrtrainersegview';
    }

    meta_learningagrtrainersegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrtrainersegview,
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
						this.describeAColumn(table, 'title', 'Titolo del tirocinio ', null, 2000, -1);
						this.describeAColumn(table, 'learningagrtrainer_address', 'Indirizzo', null, 3000, 100);
						this.describeAColumn(table, 'learningagrtrainer_assicurazienda', 'Assicurazione dell\'azienda', null, 4000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuraziendacivile', 'Copertura responsabilità civile', null, 5000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuraziendaspost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 6000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuraziendaviagg', 'Copertura viaggi di lavoro', null, 7000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristituto', 'Assicurazione dell\'istituto', null, 8000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristitutocivile', 'Copertura responsabilità civile', null, 9000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristitutospost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 10000, null);
						this.describeAColumn(table, 'learningagrtrainer_assicuristitutoviagg', 'Copertura viaggi di lavoro', null, 11000, null);
						this.describeAColumn(table, 'learningagrtrainer_cap', 'CAP', null, 12000, 20);
						this.describeAColumn(table, 'learningagrtrainer_capacitaacquis', 'Capacità e competenze che verranno acquisite', null, 13000, -1);
						this.describeAColumn(table, 'learningagrtrainer_ectscf', 'Numero di crediti ECTS', null, 14000, null);
						this.describeAColumn(table, 'learningagrtrainer_ectstitle', 'Titolo ECTS', null, 15000, -1);
						this.describeAColumn(table, 'geo_city_title', 'Città', null, 18100, 65);
						this.describeAColumn(table, 'learningagrkind_title', 'Fase del tirocinio', null, 20200, 50);
						this.describeAColumn(table, 'learningagrtrainerkind_title', 'Tipologia', null, 21200, 50);
						this.describeAColumn(table, 'learningagrtrainervalut_title', 'Title Tipo di valutazione finale', null, 22200, 50);
						this.describeAColumn(table, 'learningagrtrainervalut_description', 'Description Tipo di valutazione finale', null, 22300, 256);
						this.describeAColumn(table, 'registryaziende_title', 'Azienda o ente', null, 25100, 101);
						this.describeAColumn(table, 'learningagrtrainer_location', 'Località', null, 26000, 20);
						this.describeAColumn(table, 'learningagrtrainer_oresettimana', 'Ore di lavoro alla settimana ', null, 27000, null);
						this.describeAColumn(table, 'learningagrtrainer_pianomonit', 'Piano di monitoraggio', null, 28000, -1);
						this.describeAColumn(table, 'learningagrtrainer_pianovalut', 'Piano di valutazione', null, 29000, -1);
						this.describeAColumn(table, 'learningagrtrainer_programma', 'Programma', null, 30000, -1);
						this.describeAColumn(table, 'learningagrtrainer_registrainemd', 'Registra l’attività nell’Europass Mobility Document', null, 31000, null);
						this.describeAColumn(table, 'learningagrtrainer_registraintor', 'Registra l’attività nel Transcript of records', null, 32000, null);
						this.describeAColumn(table, 'learningagrtrainer_sostaltro', 'Sostegni di qualunque altro tipo dell’azienda', 'fixed.2', 33000, null);
						this.describeAColumn(table, 'learningagrtrainer_sostazienda', 'Sostegno economico dell’azienda', 'fixed.2', 34000, null);
						this.describeAColumn(table, 'learningagrtrainer_start', 'Data inizio periodo ', null, 35000, null);
						this.describeAColumn(table, 'learningagrtrainer_stop', 'Data fine periodo ', null, 36000, null);
						this.describeAColumn(table, 'learningagrtrainer_voto', 'Voto', null, 37000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idbandomi", "idiscrizionebmi", "idlearningagrtrainer"];
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

    window.appMeta.addMeta('learningagrtrainersegview', new meta_learningagrtrainersegview('learningagrtrainersegview'));

	}());
