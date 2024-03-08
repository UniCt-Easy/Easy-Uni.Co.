(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettocosto() {
        MetaData.apply(this, ["progettocosto"]);
        this.name = 'meta_progettocosto';
    }

    meta_progettocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettocosto,
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
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 90, null);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 100, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_start', 'Data e ora di inizio Diario d\'uso del bene strumentale', 'g', 142, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_stop', 'Data e ora di fine Diario d\'uso del bene strumentale', 'g', 143, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_idassetdiary_idpiece', 'Bene strumentale Diario d\'uso del bene strumentale', null, 141, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_idassetdiary_idreg', 'Operatore Diario d\'uso del bene strumentale', null, 142, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_idassetdiary_orepreventivate', 'Ore di utilizzo complessive preventivate Diario d\'uso del bene strumentale', null, 143, null);
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_start'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'start', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_stop'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'stop', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_idassetdiary_idpiece'] = { tableNameLookup:'assetdiary', columnNameLookup:'idpiece', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_idassetdiary_idreg'] = { tableNameLookup:'assetdiary', columnNameLookup:'idreg', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_idassetdiary_orepreventivate'] = { tableNameLookup:'assetdiary', columnNameLookup:'orepreventivate', columnNamekey:'idassetdiaryora' };
						this.describeAColumn(table, '!idexp_expense_description', 'Descrizione Spesa', null, 71, null);
						this.describeAColumn(table, '!idexp_expense_ymov', 'Anno movimento Spesa', null, 72, null);
						this.describeAColumn(table, '!idexp_expense_nmov', 'N.movimento Spesa', null, 73, null);
						objCalcFieldConfig['!idexp_expense_description'] = { tableNameLookup:'expense', columnNameLookup:'description', columnNamekey:'idexp' };
						objCalcFieldConfig['!idexp_expense_ymov'] = { tableNameLookup:'expense', columnNameLookup:'ymov', columnNamekey:'idexp' };
						objCalcFieldConfig['!idexp_expense_nmov'] = { tableNameLookup:'expense', columnNameLookup:'nmov', columnNamekey:'idexp' };
						this.describeAColumn(table, '!idpettycash_pettycash_description', 'Descrizione Fondo economale', null, 81, null);
						this.describeAColumn(table, '!idpettycash_pettycash_pettycode', 'Codice Fondo economale', null, 82, null);
						objCalcFieldConfig['!idpettycash_pettycash_description'] = { tableNameLookup:'pettycash', columnNameLookup:'description', columnNamekey:'idpettycash' };
						objCalcFieldConfig['!idpettycash_pettycash_pettycode'] = { tableNameLookup:'pettycash', columnNameLookup:'pettycode', columnNamekey:'idpettycash' };
						this.describeAColumn(table, '!idposition_position_title', 'Tipo di contratto', null, 31, null);
						objCalcFieldConfig['!idposition_position_title'] = { tableNameLookup:'position', columnNameLookup:'title', columnNamekey:'idposition' };
						this.describeAColumn(table, '!idprogettotipocosto_progettotipocosto_title', 'Voce di costo', null, 11, null);
						objCalcFieldConfig['!idprogettotipocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto_alias1', columnNameLookup:'title', columnNamekey:'idprogettotipocosto' };
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_description', 'Descrizione Attività svolta', null, 41, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_surname', 'Cognome Attività svolta', null, 41, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_forename', 'Nome Attività svolta', null, 42, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_extmatricula', 'Matricola Attività svolta', null, 43, null);
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_contratto', 'Contratto Attività svolta', null, 44, null);
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto_alias1', columnNameLookup:'description', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idrendicontattivitaprogetto' };
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_idreg_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idrendicontattivitaprogetto' };
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 201, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 202, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
						this.describeAColumn(table, '!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_year', 'Anno Uso del bene strumentale', null, 152, null);
						this.describeAColumn(table, '!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_amount', 'Importo Uso del bene strumentale', 'fixed.2', 154, null);
						this.describeAColumn(table, '!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idsalprogettoassetworkpackage_idpiece', 'Bene Strumentale Uso del bene strumentale', null, 151, null);
						this.describeAColumn(table, '!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idsalprogettoassetworkpackage_percentuale', 'Percentuale Uso del bene strumentale', 'fixed.2', 152, null);
						this.describeAColumn(table, '!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idmese_title', 'Mese Uso del bene strumentale', null, 150, null);
						objCalcFieldConfig['!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_year'] = { tableNameLookup:'salprogettoassetworkpackagemese', columnNameLookup:'year', columnNamekey:'idsalprogettoassetworkpackagemese' };
						objCalcFieldConfig['!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_amount'] = { tableNameLookup:'salprogettoassetworkpackagemese', columnNameLookup:'amount', columnNamekey:'idsalprogettoassetworkpackagemese' };
						objCalcFieldConfig['!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idsalprogettoassetworkpackage_idpiece'] = { tableNameLookup:'salprogettoassetworkpackage', columnNameLookup:'idpiece', columnNamekey:'idsalprogettoassetworkpackagemese' };
						objCalcFieldConfig['!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idsalprogettoassetworkpackage_percentuale'] = { tableNameLookup:'salprogettoassetworkpackage', columnNameLookup:'percentuale', columnNamekey:'idsalprogettoassetworkpackagemese' };
						objCalcFieldConfig['!idsalprogettoassetworkpackagemese_salprogettoassetworkpackagemese_idmese_title'] = { tableNameLookup:'mese', columnNameLookup:'title', columnNamekey:'idsalprogettoassetworkpackagemese' };
//$objCalcFieldConfig_seg$
						break;
					case 'segprg':
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 30, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 90, null);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 100, null);
//$objCalcFieldConfig_segprg$
						break;
					case 'segsal':
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 30, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 60, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 70, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 100, null);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 110, null);
//$objCalcFieldConfig_segsal$
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
						table.columns["amount"].caption = "Importo";
						table.columns["doc"].caption = "Documento collegato";
						table.columns["docdate"].caption = "Data del documento collegato";
						table.columns["idassetdiaryora"].caption = "Diario d'uso del bene strumentale";
						table.columns["idexp"].caption = "Spesa";
						table.columns["idpettycash"].caption = "Fondo economale";
						table.columns["idposition"].caption = "Tipo di contratto";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idprogettotipocosto"].caption = "Voce di costo";
						table.columns["idrelated"].caption = "Chiave economico patrimoniale";
						table.columns["idrendicontattivitaprogetto"].caption = "Attività svolta";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["idsalprogettoassetworkpackagemese"].caption = "Uso del bene strumentale";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["noperation"].caption = "Numero operazione";
						table.columns["yoperation"].caption = "Esercizio operazione";
//$innerSetCaptionConfig_seg$
						break;
					case 'segprg':
//$innerSetCaptionConfig_segprg$
						break;
					case 'segsal':
//$innerSetCaptionConfig_segsal$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettocosto");

				//$getNewRowInside$

				dt.autoIncrement('idprogettocosto', { minimum: 99990001 });

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
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					case "segprg": {
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					case "segprg": {
						return "idworkpackage asc , idprogettotipocosto asc ";
					}
					case "segsal": {
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					case "segsal": {
						return "idworkpackage asc , idprogettotipocosto asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettocosto', new meta_progettocosto('progettocosto'));

	}());
