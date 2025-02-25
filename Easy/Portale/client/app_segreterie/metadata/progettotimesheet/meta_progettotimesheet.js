(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotimesheet() {
        MetaData.apply(this, ["progettotimesheet"]);
        this.name = 'meta_progettotimesheet';
    }

    meta_progettotimesheet.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotimesheet,
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
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						//this.describeAColumn(table, 'idmese', 'Mese', null, 20, null);
						//this.describeAColumn(table, 'idsal', 'SAL', null, 30, null);
						this.describeAColumn(table, 'idtimesheettemplate', 'Template', null, 40, 60);
						//this.describeAColumn(table, 'idprogetto', 'Progetto principale', null, 50, null);
						this.describeAColumn(table, 'title', 'Descrizione', null, 60, 2048);
						this.describeAColumn(table, 'output', 'Formato', null, 70, null);
						this.describeAColumn(table, 'multilinetype', 'Separa le ore per tipologia', null, 150, null);
						this.describeAColumn(table, '!idmese_mese_title', 'Mese', null, 21, null);
						objCalcFieldConfig['!idmese_mese_title'] = { tableNameLookup:'mese_alias1', columnNameLookup:'title', columnNamekey:'idmese' };
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Titolo breve o acronimo Progetto principale', null, 51, null);
						this.describeAColumn(table, '!idprogetto_progetto_start', 'Data di inizio Progetto principale', null, 52, null);
						this.describeAColumn(table, '!idprogetto_progetto_stop', 'Data di fine Progetto principale', null, 53, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto_alias1', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_start'] = { tableNameLookup:'progetto_alias1', columnNameLookup:'start', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_stop'] = { tableNameLookup:'progetto_alias1', columnNameLookup:'stop', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_datablocco'] = { tableNameLookup:'sal', columnNameLookup:'datablocco', columnNamekey:'idsal' };
						this.describeAColumn(table, '!idsal_sal_numerosal', 'Numero SAL', null, 31, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio SAL', null, 32, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine SAL', null, 33, null);
						this.describeAColumn(table, '!idsal_sal_datablocco', 'Data di Blocco SAL', null, 34, null);
						objCalcFieldConfig['!idsal_sal_numerosal'] = { tableNameLookup:'sal', columnNameLookup:'numerosal', columnNamekey:'idsal' };
						this.describeAColumn(table, '!idrendicontaltrokind_rendicontaltrokind_title', 'Idrendicontaltrokind', null, 71, null);
						objCalcFieldConfig['!idrendicontaltrokind_rendicontaltrokind_title'] = { tableNameLookup:'rendicontaltrokind', columnNameLookup:'title', columnNamekey:'idrendicontaltrokind' };
//$objCalcFieldConfig_default$
						break;
					case 'personale':
						this.describeAColumn(table, 'year', 'Anno', null, 20, null);
						this.describeAColumn(table, 'idtimesheettemplate', 'Template', null, 50, 60);
						this.describeAColumn(table, 'title', 'Descrizione', null, 70, 2048);
						this.describeAColumn(table, 'output', 'Formato', null, 150, null);
						this.describeAColumn(table, 'multilinetype', 'Separa le ore per tipologia', null, 160, null);
//$objCalcFieldConfig_personale$
						break;
					case 'datipersonali':
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'idmese', 'Mese', null, 20, null);
						this.describeAColumn(table, 'idsal', 'SAL', null, 30, null);
						this.describeAColumn(table, 'idtimesheettemplate', 'Template', null, 40, 60);
						this.describeAColumn(table, 'idprogetto', 'Progetto principale', null, 50, null);
						this.describeAColumn(table, 'title', 'Descrizione', null, 60, 2048);
						this.describeAColumn(table, 'output', 'Formato', null, 70, null);
						this.describeAColumn(table, 'multilinetype', 'Separa le ore per tipologia', null, 150, null);
						this.describeAColumn(table, '!idmese_mese_title', 'Mese', null, 21, null);
						objCalcFieldConfig['!idmese_mese_title'] = { tableNameLookup:'mese', columnNameLookup:'title', columnNamekey:'idmese' };
						this.describeAColumn(table, '!idprogetto_progetto_titolobreve', 'Titolo breve o acronimo Progetto principale', null, 51, null);
						this.describeAColumn(table, '!idprogetto_progetto_start', 'Data di inizio Progetto principale', null, 52, null);
						this.describeAColumn(table, '!idprogetto_progetto_stop', 'Data di fine Progetto principale', null, 53, null);
						objCalcFieldConfig['!idprogetto_progetto_titolobreve'] = { tableNameLookup:'progetto', columnNameLookup:'titolobreve', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_start'] = { tableNameLookup:'progetto', columnNameLookup:'start', columnNamekey:'idprogetto' };
						objCalcFieldConfig['!idprogetto_progetto_stop'] = { tableNameLookup:'progetto', columnNameLookup:'stop', columnNamekey:'idprogetto' };
						this.describeAColumn(table, '!idsal_sal_numerosal', 'Numero SAL', null, 31, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio SAL', null, 32, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine SAL', null, 33, null);
						this.describeAColumn(table, '!idsal_sal_datablocco', 'Data di Blocco SAL', null, 34, null);
						objCalcFieldConfig['!idsal_sal_numerosal'] = { tableNameLookup:'sal', columnNameLookup:'numerosal', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_datablocco'] = { tableNameLookup:'sal', columnNameLookup:'datablocco', columnNamekey:'idsal' };
						this.describeAColumn(table, '!idrendicontaltrokind_rendicontaltrokind_title', 'Idrendicontaltrokind', null, 71, null);
						objCalcFieldConfig['!idrendicontaltrokind_rendicontaltrokind_title'] = { tableNameLookup:'rendicontaltrokind', columnNameLookup:'title', columnNamekey:'idrendicontaltrokind' };
//$objCalcFieldConfig_datipersonali$
						break;
					case 'personalecosto':
						this.describeAColumn(table, '!importaltreattivita', 'Importa altre attività', null, 0, null);
						this.describeAColumn(table, '!importattivitadidattica', 'Importa attività didattica', null, 0, null);
						this.describeAColumn(table, 'year', 'Anno', null, 20, null);
						this.describeAColumn(table, 'idtimesheettemplate', 'Template', null, 50, 60);
						this.describeAColumn(table, 'title', 'Descrizione', null, 70, 2048);
						this.describeAColumn(table, 'output', 'Formato', null, 150, null);
//$objCalcFieldConfig_personalecosto$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'personale':
						table.columns["!legendacalendario"].caption = "Legenda";
						table.columns["collapseteachingother"].caption = "Mostra attività istituzionali su una sola riga";
						table.columns["idmese"].caption = "Mese";
						table.columns["idprogetto"].caption = "Progetto principale";
						table.columns["idreg"].caption = "Membro del progetto";
						table.columns["idsal"].caption = "SAL";
						table.columns["idtimesheettemplate"].caption = "Template";
						table.columns["intestazioneallsheet"].caption = "Intestazione in  tutti i fogli";
						table.columns["multilinetype"].caption = "Separa le ore per tipologia";
						table.columns["output"].caption = "Formato";
						table.columns["riepilogoanno"].caption = "Inserisci il riepilogo annuale";
						table.columns["sede"].caption = "Sede di svolgimento delle attività";
						table.columns["showactivitiesrow"].caption = "Visualizza la riga con il totale in attività di ricerca";
						table.columns["showotheractivitiesrow"].caption = "Visualizza la riga con la differenza con il totale giornaliero";
						table.columns["title"].caption = "Descrizione";
						table.columns["withworkpackage"].caption = "Visualizza i Workpackage";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_personale$
						break;
					case 'default':
						table.columns["sede"].caption = "Sede di svolgimento delle attività";
//$innerSetCaptionConfig_default$
						break;
					case 'datipersonali':
//$innerSetCaptionConfig_datipersonali$
						break;
					case 'personalecosto':
						table.columns["idrendicontaltrokind"].caption = "Tipo di alte attività che verrà importato";
//$innerSetCaptionConfig_personalecosto$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotimesheet");

				//$getNewRowInside$

				dt.autoIncrement('idprogettotimesheet', { minimum: 99990001 });

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
						return "year desc, title asc ";
					}
					case "personale": {
						return "year desc, title asc ";
					}
					case "datipersonali": {
						return "year desc, title asc ";
					}
					case "personale": {
						return "idreg asc , year desc, idmese asc , title asc ";
					}
					case "datipersonali": {
						return "year desc, idmese asc , title asc ";
					}
					case "default": {
						return "year desc, idmese asc , title asc ";
					}
					case "personalecosto": {
						return "idreg asc , year desc, idmese asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettotimesheet', new meta_progettotimesheet('progettotimesheet'));

	}());
