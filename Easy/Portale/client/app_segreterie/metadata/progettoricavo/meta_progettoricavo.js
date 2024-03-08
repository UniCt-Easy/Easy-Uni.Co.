(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoricavo() {
        MetaData.apply(this, ["progettoricavo"]);
        this.name = 'meta_progettoricavo';
    }

    meta_progettoricavo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoricavo,
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
						this.describeAColumn(table, 'idprogettotipocosto', 'Voce di ricavo', null, 10, null);
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'idposition', 'Tipo di contratto', null, 30, null);
						this.describeAColumn(table, 'idrendicontattivitaprogetto', 'Attività svolta', null, 40, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'idinc', 'incasso', null, 70, null);
						this.describeAColumn(table, 'idsal', 'Stato avanzamento lavori', null, 80, null);
						this.describeAColumn(table, 'idrelated', 'Chiave economico patrimoniale', null, 90, 50);
						this.describeAColumn(table, '!idinc_income_description', 'Descrizione incasso', null, 71, null);
						this.describeAColumn(table, '!idinc_income_ymov', 'Anno movimento incasso', null, 72, null);
						this.describeAColumn(table, '!idinc_income_nmov', 'Numero movimento incasso', null, 73, null);
						objCalcFieldConfig['!idinc_income_description'] = { tableNameLookup:'income', columnNameLookup:'description', columnNamekey:'idinc' };
						objCalcFieldConfig['!idinc_income_ymov'] = { tableNameLookup:'income', columnNameLookup:'ymov', columnNamekey:'idinc' };
						objCalcFieldConfig['!idinc_income_nmov'] = { tableNameLookup:'income', columnNameLookup:'nmov', columnNamekey:'idinc' };
						this.describeAColumn(table, '!idposition_position_title', 'Tipo di contratto', null, 31, null);
						objCalcFieldConfig['!idposition_position_title'] = { tableNameLookup:'position_alias1', columnNameLookup:'title', columnNamekey:'idposition' };
						this.describeAColumn(table, '!idprogettotipocosto_progettotipocosto_title', 'Voce di ricavo', null, 11, null);
						objCalcFieldConfig['!idprogettotipocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto_alias2', columnNameLookup:'title', columnNamekey:'idprogettotipocosto' };
						this.describeAColumn(table, '!idrelated_entrydetail_description', 'Chiave economico patrimoniale', null, 92, null);
						objCalcFieldConfig['!idrelated_entrydetail_description'] = { tableNameLookup:'entrydetail', columnNameLookup:'description', columnNamekey:'idrelated' };
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_description', 'Descrizione Attività svolta', null, 41, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_surname', 'Cognome Attività svolta', null, 41, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_forename', 'Nome Attività svolta', null, 42, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_extmatricula', 'Matricola Attività svolta', null, 43, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_contratto', 'Contratto Attività svolta', null, 44, null);
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto_alias2', columnNameLookup:'description', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idrendicontattivitaprogetto' };
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 81, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 82, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idsal' };
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
						table.columns["amount"].caption = "Importo";
						table.columns["doc"].caption = "Documento collegato";
						table.columns["docdate"].caption = "Data del documento collegato";
						table.columns["idinc"].caption = "incasso";
						table.columns["idposition"].caption = "Tipo di contratto";
						table.columns["idprogettotipocosto"].caption = "Voce di ricavo";
						table.columns["idrelated"].caption = "Chiave economico patrimoniale";
						table.columns["idrendicontattivitaprogetto"].caption = "Attività svolta";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["idworkpackage"].caption = "Workpackage";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoricavo");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoricavo', { minimum: 99990001 });

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
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('progettoricavo', new meta_progettoricavo('progettoricavo'));

	}());
