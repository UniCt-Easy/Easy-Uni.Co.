(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registry_docenti() {
        MetaData.apply(this, ["registry_docenti"]);
        this.name = 'meta_registry_docenti';
    }

    meta_registry_docenti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_docenti,
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
					case 'docenti_doc':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 10, 50);
//$objCalcFieldConfig_docenti_doc$
						break;
					case 'docenti':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 10, 50);
//$objCalcFieldConfig_docenti$
						break;
					case 'docenti_docente':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 10, 50);
//$objCalcFieldConfig_docenti_docente$
						break;
					case 'default':
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_title', 'Classe consorsuale', null, 51, null);
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_title'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'title', columnNamekey:'idclassconsorsuale' };
						this.describeAColumn(table, '!idreg_istituti_registry_istituti_title', 'Istituto, Ente o Azienda', null, 41, null);
						objCalcFieldConfig['!idreg_istituti_registry_istituti_title'] = { tableNameLookup:'registry_alias4', columnNameLookup:'title', columnNamekey:'idreg_istituti' };
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SASD', null, 21, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SASD', null, 22, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura di afferenza', null, 31, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Struttura di afferenza', null, 31, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura_alias2', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
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
					case 'docenti':
						table.columns["cv"].caption = "Curriculum Vitae";
						table.columns["idclassconsorsuale"].caption = "Classe consorsuale";
						table.columns["idfonteindicebibliometrico"].caption = "Fonte";
						table.columns["idreg"].caption = "Codice Istituto";
						table.columns["idreg_istituti"].caption = "Istituto, Ente o Azienda";
						table.columns["idsasd"].caption = "SASD";
						table.columns["idstruttura"].caption = "Struttura di afferenza";
						table.columns["indicebibliometrico"].caption = "Indice bibliometrico (H-Index)";
						table.columns["matricola"].caption = "Matricola";
						table.columns["ricevimento"].caption = "Orari di ricevimento";
						table.columns["soggiorno"].caption = "Permesso di soggiorno";
//$innerSetCaptionConfig_docenti$
						break;
					case 'docenti_docente':
//$innerSetCaptionConfig_docenti_docente$
						break;
					case 'docenti_docentenoaltro':
						table.columns["cv"].caption = "Curriculum Vitae";
						table.columns["idclassconsorsuale"].caption = "Classe consorsuale";
						table.columns["idfonteindicebibliometrico"].caption = "Fonte";
						table.columns["idreg"].caption = "Codice Istituto";
						table.columns["idreg_istituti"].caption = "Istituto, Ente o Azienda";
						table.columns["idsasd"].caption = "SASD";
						table.columns["idstruttura"].caption = "Struttura di afferenza";
						table.columns["indicebibliometrico"].caption = "Indice bibliometrico (H-Index)";
						table.columns["matricola"].caption = "Matricola";
						table.columns["ricevimento"].caption = "Orari di ricevimento";
						table.columns["soggiorno"].caption = "Permesso di soggiorno";
//$innerSetCaptionConfig_docenti_docentenoaltro$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_docenti");

				//$getNewRowInside$


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
					case "docenti_doc": {
						return "title asc ";
					}
					case "docenti": {
						return "title asc ";
					}
					case "docenti_docente": {
						return "title asc ";
					}
					case "docenti_docentenoaltro": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_docenti', new meta_registry_docenti('registry_docenti'));

	}());
