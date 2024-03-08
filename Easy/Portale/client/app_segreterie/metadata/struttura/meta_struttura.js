(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_struttura() {
        MetaData.apply(this, ["struttura"]);
        this.name = 'meta_struttura';
    }

    meta_struttura.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_struttura,
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
					case 'princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'codiceipa', 'Codice IPA', null, 40, null);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 200);
						this.describeAColumn(table, 'fax', 'Fax', null, 60, 50);
						this.describeAColumn(table, 'telefono', 'Telefono', null, 110, 50);
						this.describeAColumn(table, 'title_en', 'Denominazione (ENG)', null, 120, 1024);
						this.describeAColumn(table, 'active', 'Attivo', null, 250, null);
						this.describeAColumn(table, '!idaoo_aoo_title', 'AOO', null, 71, null);
						objCalcFieldConfig['!idaoo_aoo_title'] = { tableNameLookup:'aoo_alias2', columnNameLookup:'title', columnNamekey:'idaoo' };
						this.describeAColumn(table, '!idsede_sede_title', 'Sede', null, 81, null);
						objCalcFieldConfig['!idsede_sede_title'] = { tableNameLookup:'sede_alias1', columnNameLookup:'title', columnNamekey:'idsede' };
						this.describeAColumn(table, '!idstrutturakind_strutturakind_title', 'Tipo', null, 91, null);
						objCalcFieldConfig['!idstrutturakind_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstrutturakind' };
						this.describeAColumn(table, '!idupb_upb_title', 'UPB', null, 101, null);
						objCalcFieldConfig['!idupb_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idupb' };
//$objCalcFieldConfig_princ$
						break;
					case 'perf':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'codiceipa', 'Codice IPA', null, 40, null);
						this.describeAColumn(table, 'active', 'Attivo', null, 240, null);
//$objCalcFieldConfig_perf$
						break;
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'title_en', 'Denominazione (ENG)', null, 30, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 40, 50);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 200);
						this.describeAColumn(table, 'fax', 'Fax', null, 60, 50);
						this.describeAColumn(table, 'telefono', 'Telefono', null, 70, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 160, null);
//$objCalcFieldConfig_seg_child$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 160, null);
//$objCalcFieldConfig_default$
						break;
					case 'perfelenchi':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'active', 'Attivo', null, 160, null);
//$objCalcFieldConfig_perfelenchi$
						break;
					case 'perfelenchiparent':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'active', 'Attivo', null, 160, null);
						this.describeAColumn(table, '!idreg_appr_getregistrydocentiamministrativi_surname', 'Cognome Idreg_appr', null, 101, null);
						this.describeAColumn(table, '!idreg_appr_getregistrydocentiamministrativi_forename', 'Nome Idreg_appr', null, 102, null);
						this.describeAColumn(table, '!idreg_appr_getregistrydocentiamministrativi_extmatricula', 'Matricola Idreg_appr', null, 103, null);
						this.describeAColumn(table, '!idreg_appr_getregistrydocentiamministrativi_contratto', 'Contratto Idreg_appr', null, 104, null);
						objCalcFieldConfig['!idreg_appr_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg_appr' };
						objCalcFieldConfig['!idreg_appr_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg_appr' };
						objCalcFieldConfig['!idreg_appr_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg_appr' };
						objCalcFieldConfig['!idreg_appr_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg_appr' };
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_surname', 'Cognome Idreg_resp', null, 111, null);
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_forename', 'Nome Idreg_resp', null, 112, null);
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_extmatricula', 'Matricola Idreg_resp', null, 113, null);
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_contratto', 'Contratto Idreg_resp', null, 114, null);
						objCalcFieldConfig['!idreg_resp_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'surname', columnNamekey:'idreg_resp' };
						objCalcFieldConfig['!idreg_resp_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'forename', columnNamekey:'idreg_resp' };
						objCalcFieldConfig['!idreg_resp_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'extmatricula', columnNamekey:'idreg_resp' };
						objCalcFieldConfig['!idreg_resp_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'contratto', columnNamekey:'idreg_resp' };
						this.describeAColumn(table, '!idreg_valut_getregistrydocentiamministrativi_surname', 'Cognome Idreg_valut', null, 121, null);
						this.describeAColumn(table, '!idreg_valut_getregistrydocentiamministrativi_forename', 'Nome Idreg_valut', null, 122, null);
						this.describeAColumn(table, '!idreg_valut_getregistrydocentiamministrativi_extmatricula', 'Matricola Idreg_valut', null, 123, null);
						this.describeAColumn(table, '!idreg_valut_getregistrydocentiamministrativi_contratto', 'Contratto Idreg_valut', null, 124, null);
						objCalcFieldConfig['!idreg_valut_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi_alias2', columnNameLookup:'surname', columnNamekey:'idreg_valut' };
						objCalcFieldConfig['!idreg_valut_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi_alias2', columnNameLookup:'forename', columnNamekey:'idreg_valut' };
						objCalcFieldConfig['!idreg_valut_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi_alias2', columnNameLookup:'extmatricula', columnNamekey:'idreg_valut' };
						objCalcFieldConfig['!idreg_valut_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi_alias2', columnNameLookup:'contratto', columnNamekey:'idreg_valut' };
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_surname', 'Cognome Responsabile', null, 111, null);
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_forename', 'Nome Responsabile', null, 112, null);
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_extmatricula', 'Matricola Responsabile', null, 113, null);
						this.describeAColumn(table, '!idreg_resp_getregistrydocentiamministrativi_contratto', 'Contratto Responsabile', null, 114, null);
//$objCalcFieldConfig_perfelenchiparent$
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
						table.columns["idupb"].caption = "Unità previsionale di base (bilancio)";
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
						table.columns["active"].caption = "Attivo";
//$innerSetCaptionConfig_default$
						break;
					case 'perf':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["idupb"].caption = "UPB";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori ";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi una tantum";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance Progetti Strategici di altre UO";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei Progetti Strategici della UO";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
//$innerSetCaptionConfig_perf$
						break;
					case 'princ':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["active"].caption = "Attivo";
//$innerSetCaptionConfig_princ$
						break;
					case 'seg_child':
						table.columns["codiceipa"].caption = "Codice IPA";
//$innerSetCaptionConfig_seg_child$
						break;
					case 'perfelenchi':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["idupb"].caption = "Unità previsionale di base (bilancio)";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
						table.columns["paridstruttura"].caption = "U.O. madre";
//$innerSetCaptionConfig_perfelenchi$
						break;
					case 'perfelenchiparent':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["idupb"].caption = "Unità previsionale di base (bilancio)";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_perfelenchiparent$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_struttura");

				//$getNewRowInside$

				dt.autoIncrement('idstruttura', { minimum: 99990001 });

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
					case "perf": {
						return "title desc";
					}
					case "princ": {
						return "title asc ";
					}
					case "seg_child": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					case "perfelenchi": {
						return "title asc ";
					}
					case "perfelenchiparent": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title");
				var rootCondition = window.jsDataQuery.isNull("paridstruttura");
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
		});

    window.appMeta.addMeta('struttura', new meta_struttura('struttura'));

	}());
