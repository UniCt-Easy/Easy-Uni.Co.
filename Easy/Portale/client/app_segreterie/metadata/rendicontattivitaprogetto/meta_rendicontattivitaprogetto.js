(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogetto() {
        MetaData.apply(this, ["rendicontattivitaprogetto"]);
        this.name = 'meta_rendicontattivitaprogetto';
    }

    meta_rendicontattivitaprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogetto,
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
					case 'doc':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_doc$
						break;
					case 'anagamm':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Titolo breve o acronimo Progetto', null, 11, null);
						this.describeAColumn(table, '!idprogetto_progetto_start', 'Data di inizio Progetto', null, 12, null);
						this.describeAColumn(table, '!idprogetto_progetto_stop', 'Data di fine Progetto', null, 13, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_start'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'start', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_stop'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'stop', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title', 'Tipo di attività', null, 131, null);
						objCalcFieldConfig['!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title'] = { tableNameLookup:'rendicontattivitaprogettokind', columnNameLookup:'title', columnNamekey:'idrendicontattivitaprogettokind' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 21, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 22, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_start', 'Data di inizio Workpackage', null, 23, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_stop', 'Data di fine Workpackage', null, 24, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'title', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_start'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'start', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_stop'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'stop', columnNamekey:'idworkpackage' };
//$objCalcFieldConfig_anagamm$
						break;
					case 'anag':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Titolo breve o acronimo Progetto', null, 11, null);
						this.describeAColumn(table, '!idprogetto_progetto_start', 'Data di inizio Progetto', null, 12, null);
						this.describeAColumn(table, '!idprogetto_progetto_stop', 'Data di fine Progetto', null, 13, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto_alias3', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_start'] = { tableNameLookup:'progetto_alias3', columnNameLookup:'start', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_stop'] = { tableNameLookup:'progetto_alias3', columnNameLookup:'stop', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title', 'Tipo di attività', null, 131, null);
						objCalcFieldConfig['!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title'] = { tableNameLookup:'rendicontattivitaprogettokind', columnNameLookup:'title', columnNamekey:'idrendicontattivitaprogettokind' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 21, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 22, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_start', 'Data di inizio Workpackage', null, 23, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_stop', 'Data di fine Workpackage', null, 24, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'title', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_start'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'start', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_stop'] = { tableNameLookup:'workpackage_alias1', columnNameLookup:'stop', columnNamekey:'idworkpackage' };
//$objCalcFieldConfig_anag$
						break;
					case 'seg':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, '!raggruppamento', 'Raggruppamento', null, 0, null);
						this.describeAColumn(table, '!titolobreve', 'Progetto', null, 0, null);
						this.describeAColumn(table, '!wp', 'Workpackage', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Partecipante', null, 11, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Partecipante', null, 12, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Partecipante', null, 13, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Partecipante', null, 14, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'contratto', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title', 'Tipo di attività', null, 131, null);
						objCalcFieldConfig['!idrendicontattivitaprogettokind_rendicontattivitaprogettokind_title'] = { tableNameLookup:'rendicontattivitaprogettokind', columnNameLookup:'title', columnNamekey:'idrendicontattivitaprogettokind' };
//$objCalcFieldConfig_seg$
						break;
					case 'docente':
						this.describeAColumn(table, '!datafine', 'Data fine', null, 0, null);
						this.describeAColumn(table, '!datainizio', 'Data inizio', null, 0, null);
						this.describeAColumn(table, '!importattivita', 'Importa attività', null, 0, null);
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_docente$
						break;
					case 'segsal':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_segsal$
						break;
					case 'personale':
						this.describeAColumn(table, '!orerendicont', 'Numero di ore rendicontate', null, 0, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_personale$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'doc':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_doc$
						break;
					case 'anagamm':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iditineration"].caption = "Missione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Partecipante";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Numero di ore preventivate";
						table.columns["stop"].caption = "Data fine prevista";
						table.columns["idrendicontattivitaprogettokind"].caption = "Tipo di attività";
//$innerSetCaptionConfig_anagamm$
						break;
					case 'anag':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_anag$
						break;
					case 'seg':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iditineration"].caption = "Missione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Partecipante";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Numero di ore preventivate";
						table.columns["stop"].caption = "Data fine prevista";
						table.columns["idrendicontattivitaprogettokind"].caption = "Tipo di attività";
						table.columns["!titolobreve"].caption = "Progetto";
						table.columns["!wp"].caption = "Workpackage";
						table.columns["!raggruppamento"].caption = "Raggruppamento";
//$innerSetCaptionConfig_seg$
						break;
					case 'docente':
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
						table.columns["!datafine"].caption = "Data fine";
						table.columns["!datainizio"].caption = "Data inizio";
//$innerSetCaptionConfig_docente$
						break;
					case 'segsal':
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iditineration"].caption = "Missione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Partecipante";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Numero di ore preventivate";
						table.columns["stop"].caption = "Data fine prevista";
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_segsal$
						break;
					case 'personale':
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["iditineration"].caption = "Missione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idreg"].caption = "Partecipante";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["orepreventivate"].caption = "Numero di ore preventivate";
						table.columns["stop"].caption = "Data fine prevista";
						table.columns["!orerendicont"].caption = "Numero di ore rendicontate";
//$innerSetCaptionConfig_personale$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontattivitaprogetto");

				//$getNewRowInside$

				dt.autoIncrement('idrendicontattivitaprogetto', { minimum: 99990001 });

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
					case "doc": {
						return "datainizioprevista asc ";
					}
					case "anagamm": {
						return "datainizioprevista asc ";
					}
					case "anag": {
						return "datainizioprevista asc ";
					}
					case "seg": {
						return "datainizioprevista asc ";
					}
					case "docente": {
						return "datainizioprevista asc ";
					}
					case "segsal": {
						return "datainizioprevista asc ";
					}
					case "personale": {
						return "datainizioprevista asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogetto', new meta_rendicontattivitaprogetto('rendicontattivitaprogetto'));

	}());
