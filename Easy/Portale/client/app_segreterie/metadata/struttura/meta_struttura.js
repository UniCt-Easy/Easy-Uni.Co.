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
						table.columns["active"].caption = "Attivo";
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
//$innerSetCaptionConfig_default$
						break;
					case 'perf':
						table.columns["idupb"].caption = "UPB";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori ";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi una tantum";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance Progetti Strategici di altre UO";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei Progetti Strategici della UO";
//$innerSetCaptionConfig_perf$
						break;
					case 'princ':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["active"].caption = "Attivo";
//$innerSetCaptionConfig_princ$
						break;
					case 'seg_child':
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
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title", "idstrutturakind");
				var rootCondition = window.jsDataQuery.isNull("paridstruttura");
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
		});

    window.appMeta.addMeta('struttura', new meta_struttura('struttura'));

	}());
