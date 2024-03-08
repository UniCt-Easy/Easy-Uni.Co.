(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivoattivita() {
        MetaData.apply(this, ["perfprogettoobiettivoattivita"]);
        this.name = 'meta_perfprogettoobiettivoattivita';
    }

    meta_perfprogettoobiettivoattivita.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivoattivita,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 40, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 50, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 60, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 70, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 80, null);
						this.describeAColumn(table, '!idacc_accountminusable_title', 'Denominazione Voce di costo', null, 181, null);
						this.describeAColumn(table, '!idacc_accountminusable_codeacc', 'Codice Voce di costo', null, 182, null);
						this.describeAColumn(table, '!idacc_accountminusable_accountkind', 'Tipo Voce di costo', null, 183, null);
						this.describeAColumn(table, '!idacc_accountminusable_ayear', 'Anno Voce di costo', null, 184, null);
						objCalcFieldConfig['!idacc_accountminusable_title'] = { tableNameLookup:'accountminusable', columnNameLookup:'title', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_accountminusable_codeacc'] = { tableNameLookup:'accountminusable', columnNameLookup:'codeacc', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_accountminusable_accountkind'] = { tableNameLookup:'accountminusable', columnNameLookup:'accountkind', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_accountminusable_ayear'] = { tableNameLookup:'accountminusable', columnNameLookup:'ayear', columnNamekey:'idacc' };
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Chi svolge l’attività', null, 31, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Chi svolge l’attività', null, 32, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Chi svolge l’attività', null, 33, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Chi svolge l’attività', null, 34, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idupb_upb_title', 'Unità previsionale di base (UPB)', null, 191, null);
						objCalcFieldConfig['!idupb_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idupb' };
//$objCalcFieldConfig_default$
						break;
					case 'docenti':
						this.describeAColumn(table, 'title', 'Titolo', null, 40, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 50, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 60, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 70, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 80, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 90, null);
//$objCalcFieldConfig_docenti$
						break;
					case 'elenchi':
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 40, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 50, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 60, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 70, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 80, null);
//$objCalcFieldConfig_elenchi$
						break;
					case 'riepilogo':
						this.describeAColumn(table, 'title', 'Titolo', null, 40, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 60, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 70, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 80, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 90, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 100, null);
						this.describeAColumn(table, '!idacc_accountminusable_title', 'Denominazione Voce di costo', null, 181, null);
						this.describeAColumn(table, '!idacc_accountminusable_codeacc', 'Codice Voce di costo', null, 182, null);
						this.describeAColumn(table, '!idacc_accountminusable_accountkind', 'Tipo Voce di costo', null, 183, null);
						this.describeAColumn(table, '!idacc_accountminusable_ayear', 'Anno Voce di costo', null, 184, null);
						objCalcFieldConfig['!idacc_accountminusable_title'] = { tableNameLookup:'accountminusable', columnNameLookup:'title', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_accountminusable_codeacc'] = { tableNameLookup:'accountminusable', columnNameLookup:'codeacc', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_accountminusable_accountkind'] = { tableNameLookup:'accountminusable', columnNameLookup:'accountkind', columnNamekey:'idacc' };
						objCalcFieldConfig['!idacc_accountminusable_ayear'] = { tableNameLookup:'accountminusable', columnNameLookup:'ayear', columnNamekey:'idacc' };
						this.describeAColumn(table, '!idperfprogettoobiettivo_perfprogettoobiettivo_title', 'Obiettivo strategico', null, 21, null);
						objCalcFieldConfig['!idperfprogettoobiettivo_perfprogettoobiettivo_title'] = { tableNameLookup:'perfprogettoobiettivo_alias1', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivo' };
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Chi svolge l’attività', null, 51, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Chi svolge l’attività', null, 52, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Chi svolge l’attività', null, 53, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Chi svolge l’attività', null, 54, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idupb_upb_title', 'Unità previsionale di base (UPB)', null, 191, null);
						objCalcFieldConfig['!idupb_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idupb' };
						this.describeAColumn(table, '!paridperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title', 'Attività madre', null, 31, null);
						objCalcFieldConfig['!paridperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias2', columnNameLookup:'title', columnNamekey:'paridperfprogettoobiettivoattivita' };
//$objCalcFieldConfig_riepilogo$
						break;
					case 'referenti':
						this.describeAColumn(table, 'title', 'Titolo', null, 50, 1024);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', 'g', 60, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', 'g', 70, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', 'g', 80, null);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', 'g', 90, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 100, null);
//$objCalcFieldConfig_referenti$
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
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
						table.columns["idacc"].caption = "Voce di costo";
						table.columns["idupb"].caption = "Unità previsionale di base (UPB)";
//$innerSetCaptionConfig_default$
						break;
					case 'docenti':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
						table.columns["idperfprogetto"].caption = "Progetto Strategico";
						table.columns["idperfprogettoobiettivo"].caption = "Obiettivo strategico";
//$innerSetCaptionConfig_docenti$
						break;
					case 'elenchi':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idacc"].caption = "Voce di costo";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["idupb"].caption = "Unità previsionale di base (UPB)";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_elenchi$
						break;
					case 'riepilogo':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idacc"].caption = "Voce di costo";
						table.columns["idperfprogetto"].caption = "Progetto Strategico";
						table.columns["idperfprogettoobiettivo"].caption = "Obiettivo strategico";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["idupb"].caption = "Unità previsionale di base (UPB)";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_riepilogo$
						break;
					case 'referenti':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["description"].caption = "Descrizione";
						table.columns["idacc"].caption = "Voce di costo";
						table.columns["idperfprogetto"].caption = "Progetto Strategico";
						table.columns["idperfprogettoobiettivo"].caption = "Obiettivo strategico";
						table.columns["idreg"].caption = "Chi svolge l’attività";
						table.columns["idupb"].caption = "Unità previsionale di base (UPB)";
						table.columns["paridperfprogettoobiettivoattivita"].caption = "Attività madre";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_referenti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoobiettivoattivita");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoobiettivoattivita', { minimum: 99990001 });

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
						return "datainizioprevista asc ";
					}
					case "default": {
						return "ct asc ";
					}
					case "docenti": {
						return "ct asc ";
					}
					case "elenchi": {
						return "ct asc ";
					}
					case "riepilogo": {
						return "ct asc ";
					}
					case "referenti": {
						return "ct asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title", "datainizioprevista", "datafineprevista");
				var rootCondition = window.jsDataQuery.eq("paridperfprogettoobiettivoattivita", 5);
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
        });

    window.appMeta.addMeta('perfprogettoobiettivoattivita', new meta_perfprogettoobiettivoattivita('perfprogettoobiettivoattivita'));

	}());
