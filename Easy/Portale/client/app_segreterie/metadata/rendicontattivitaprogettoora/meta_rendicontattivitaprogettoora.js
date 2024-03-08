(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettoora() {
        MetaData.apply(this, ["rendicontattivitaprogettoora"]);
        this.name = 'meta_rendicontattivitaprogettoora';
    }

    meta_rendicontattivitaprogettoora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoora,
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
						this.describeAColumn(table, '!titleancestor', 'Descrizione', null, 10, null);
						this.describeAColumn(table, 'data', 'Data', null, 30, null);
						this.describeAColumn(table, 'ore', 'Numero di ore', null, 70, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato di avanzamento lavori', null, 131, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato di avanzamento lavori', null, 132, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
//$objCalcFieldConfig_seg$
						break;
					case 'segsal':
						this.describeAColumn(table, 'data', 'Data', null, 30, null);
						this.describeAColumn(table, 'ore', 'Numero di ore', null, 70, null);
//$objCalcFieldConfig_segsal$
						break;
					case 'personale':
						this.describeAColumn(table, 'data', 'Data', null, 40, null);
						this.describeAColumn(table, 'ore', 'Numero di ore', null, 50, null);
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Titolo breve o acronimo Progetto', null, 11, null);
						this.describeAColumn(table, '!idprogetto_progetto_start', 'Data di inizio Progetto', null, 12, null);
						this.describeAColumn(table, '!idprogetto_progetto_stop', 'Data di fine Progetto', null, 13, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_start'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'start', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_stop'] = { tableNameLookup:'progetto_alias2', columnNameLookup:'stop', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_description', 'Attività', null, 31, null);
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto', columnNameLookup:'description', columnNamekey:'idrendicontattivitaprogetto' };
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato di avanzamento lavori', null, 61, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato di avanzamento lavori', null, 62, null);
						this.describeAColumn(table, '!idsal_sal_datablocco', 'Data di Blocco Stato di avanzamento lavori', null, 63, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_datablocco'] = { tableNameLookup:'sal', columnNameLookup:'datablocco', columnNamekey:'idsal' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 21, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 22, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage', columnNameLookup:'title', columnNamekey:'idworkpackage' };
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
					case 'seg':
						table.columns["!titleancestor"].caption = "Descrizione";
						table.columns["data"].caption = "Data";
						table.columns["idrendicontattivitaprogetto"].caption = "attività di progetto";
						table.columns["idsal"].caption = "Stato di avanzamento lavori";
						table.columns["ore"].caption = "Numero di ore";
//$innerSetCaptionConfig_seg$
						break;
					case 'segsal':
						table.columns["!titleancestor"].caption = "Descrizione";
						table.columns["idrendicontattivitaprogetto"].caption = "Attività";
						table.columns["idworkpackage"].caption = "Workpackage";
//$innerSetCaptionConfig_segsal$
						break;
					case 'personale':
						table.columns["!titleancestor"].caption = "Attività";
						table.columns["idprogetto"].caption = "Progetto";
//$innerSetCaptionConfig_personale$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_rendicontattivitaprogettoora");

				//$getNewRowInside$

				dt.autoIncrement('idrendicontattivitaprogettoora', { minimum: 99990001 });

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
						return "data asc ";
					}
					case "segsal": {
						return "data asc ";
					}
					case "personale": {
						return "data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettoora', new meta_rendicontattivitaprogettoora('rendicontattivitaprogettoora'));

	}());
