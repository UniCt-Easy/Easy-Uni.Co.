(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_learningagrtrainer() {
        MetaData.apply(this, ["learningagrtrainer"]);
        this.name = 'meta_learningagrtrainer';
    }

    meta_learningagrtrainer.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrtrainer,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo del tirocinio ', null, 20, -1);
						this.describeAColumn(table, 'address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'assicurazienda', 'Assicurazione dell\'azienda', null, 40, null);
						this.describeAColumn(table, 'assicuraziendacivile', 'Copertura responsabilità civile', null, 50, null);
						this.describeAColumn(table, 'assicuraziendaspost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 60, null);
						this.describeAColumn(table, 'assicuraziendaviagg', 'Copertura viaggi di lavoro', null, 70, null);
						this.describeAColumn(table, 'assicuristituto', 'Assicurazione dell\'istituto', null, 80, null);
						this.describeAColumn(table, 'assicuristitutocivile', 'Copertura responsabilità civile', null, 90, null);
						this.describeAColumn(table, 'assicuristitutospost', 'Copertura infortuni negli spostamenti per e dal lavoro', null, 100, null);
						this.describeAColumn(table, 'assicuristitutoviagg', 'Copertura viaggi di lavoro', null, 110, null);
						this.describeAColumn(table, 'cap', 'CAP', null, 120, 20);
						this.describeAColumn(table, 'capacitaacquis', 'Capacità e competenze che verranno acquisite', null, 130, -1);
						this.describeAColumn(table, 'ectscf', 'Numero di crediti ECTS', null, 140, null);
						this.describeAColumn(table, 'ectstitle', 'Titolo ECTS', null, 150, -1);
						this.describeAColumn(table, 'location', 'Località', null, 260, 20);
						this.describeAColumn(table, 'oresettimana', 'Ore di lavoro alla settimana ', null, 270, null);
						this.describeAColumn(table, 'pianomonit', 'Piano di monitoraggio', null, 280, -1);
						this.describeAColumn(table, 'pianovalut', 'Piano di valutazione', null, 290, -1);
						this.describeAColumn(table, 'programma', 'Programma', null, 300, -1);
						this.describeAColumn(table, 'registrainemd', 'Registra l’attività nell’Europass Mobility Document', null, 310, null);
						this.describeAColumn(table, 'registraintor', 'Registra l’attività nel Transcript of records', null, 320, null);
						this.describeAColumn(table, 'sostaltro', 'Sostegni di qualunque altro tipo dell’azienda', 'fixed.2', 330, null);
						this.describeAColumn(table, 'sostazienda', 'Sostegno economico dell’azienda', 'fixed.2', 340, null);
						this.describeAColumn(table, 'start', 'Data inizio periodo ', null, 350, null);
						this.describeAColumn(table, 'stop', 'Data fine periodo ', null, 360, null);
						this.describeAColumn(table, 'voto', 'Voto', null, 370, null);
						this.describeAColumn(table, '!idcity_geo_city_title', 'Città', null, 181, null);
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup:'geo_city', columnNameLookup:'title', columnNamekey:'idcity' };
						this.describeAColumn(table, '!idlearningagrkind_learningagrkind_title', 'Fase del tirocinio', null, 201, null);
						objCalcFieldConfig['!idlearningagrkind_learningagrkind_title'] = { tableNameLookup:'learningagrkind_alias1', columnNameLookup:'title', columnNamekey:'idlearningagrkind' };
						this.describeAColumn(table, '!idlearningagrtrainerkind_learningagrtrainerkind_title', 'Tipologia', null, 211, null);
						objCalcFieldConfig['!idlearningagrtrainerkind_learningagrtrainerkind_title'] = { tableNameLookup:'learningagrtrainerkind', columnNameLookup:'title', columnNamekey:'idlearningagrtrainerkind' };
						this.describeAColumn(table, '!idlearningagrtrainervalut_learningagrtrainervalut_title', 'Title Tipo di valutazione finale', null, 221, null);
						this.describeAColumn(table, '!idlearningagrtrainervalut_learningagrtrainervalut_description', 'Description Tipo di valutazione finale', null, 222, null);
						objCalcFieldConfig['!idlearningagrtrainervalut_learningagrtrainervalut_title'] = { tableNameLookup:'learningagrtrainervalut', columnNameLookup:'title', columnNamekey:'idlearningagrtrainervalut' };
						objCalcFieldConfig['!idlearningagrtrainervalut_learningagrtrainervalut_description'] = { tableNameLookup:'learningagrtrainervalut', columnNameLookup:'description', columnNamekey:'idlearningagrtrainervalut' };
						this.describeAColumn(table, '!idreg_aziende_registry_title', 'Azienda o ente', null, 251, null);
						objCalcFieldConfig['!idreg_aziende_registry_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_aziende' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["address"].caption = "Indirizzo";
						table.columns["assicurazienda"].caption = "Assicurazione dell'azienda";
						table.columns["assicuraziendacivile"].caption = "Copertura responsabilità civile";
						table.columns["assicuraziendaspost"].caption = "Copertura infortuni negli spostamenti per e dal lavoro";
						table.columns["assicuraziendaviagg"].caption = "Copertura viaggi di lavoro";
						table.columns["assicuristituto"].caption = "Assicurazione dell'istituto";
						table.columns["assicuristitutocivile"].caption = "Copertura responsabilità civile";
						table.columns["assicuristitutospost"].caption = "Copertura infortuni negli spostamenti per e dal lavoro";
						table.columns["assicuristitutoviagg"].caption = "Copertura viaggi di lavoro";
						table.columns["cap"].caption = "CAP";
						table.columns["capacitaacquis"].caption = "Capacità e competenze che verranno acquisite";
						table.columns["ectscf"].caption = "Numero di crediti ECTS";
						table.columns["ectstitle"].caption = "Titolo ECTS";
						table.columns["idcity"].caption = "Città";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idlearningagrkind"].caption = "Fase del tirocinio";
						table.columns["idlearningagrtrainerkind"].caption = "Tipologia";
						table.columns["idlearningagrtrainervalut"].caption = "Tipo di valutazione finale";
						table.columns["idnation"].caption = "Nazione";
						table.columns["idreg_aziende"].caption = "Azienda o ente";
						table.columns["location"].caption = "Località";
						table.columns["oresettimana"].caption = "Ore di lavoro alla settimana ";
						table.columns["pianomonit"].caption = "Piano di monitoraggio";
						table.columns["pianovalut"].caption = "Piano di valutazione";
						table.columns["registrainemd"].caption = "Registra l’attività nell’Europass Mobility Document";
						table.columns["registraintor"].caption = "Registra l’attività nel Transcript of records";
						table.columns["sostaltro"].caption = "Sostegni di qualunque altro tipo dell’azienda";
						table.columns["sostazienda"].caption = "Sostegno economico dell’azienda";
						table.columns["start"].caption = "Data inizio periodo ";
						table.columns["stop"].caption = "Data fine periodo ";
						table.columns["title"].caption = "Titolo del tirocinio ";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_learningagrtrainer");

				//$getNewRowInside$

				dt.autoIncrement('idlearningagrtrainer', { minimum: 99990001 });

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
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('learningagrtrainer', new meta_learningagrtrainer('learningagrtrainer'));

	}());
