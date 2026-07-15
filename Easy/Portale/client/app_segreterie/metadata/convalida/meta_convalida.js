(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_convalida() {
        MetaData.apply(this, ["convalida"]);
        this.name = 'meta_convalida';
    }

    meta_convalida.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_convalida,
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
					case 'segmitr':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'iddichiar', 'Dichiarazione da convalidare', null, 60, null);
						this.describeAColumn(table, 'iddidprog', 'Didattica programmata', null, 70, null);
						this.describeAColumn(table, 'idiscrizione', 'Iscrizione', null, 80, null);
						this.describeAColumn(table, 'idpratica', 'pratica di convalida', null, 140, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segmitr$
						break;
					case 'segstudprat':
						this.describeAColumn(table, 'idconvalidakind', 'Tipologia', null, 10, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 30, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 40, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 60, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 70, null);
						this.describeAColumn(table, 'idiscrizionebmi', 'Iscrizione al bando di mobilità internazionale', null, 100, null);
						this.describeAColumn(table, 'idlearningagrstud', 'learning agreement for studies', null, 120, null);
						this.describeAColumn(table, 'idlearningagrtrainer', 'Learning agreement for traineersheep', null, 130, null);
						this.describeAColumn(table, '!idconvalidakind_convalidakind_title', 'Tipologia', null, 11, null);
						objCalcFieldConfig['!idconvalidakind_convalidakind_title'] = { tableNameLookup:'convalidakind', columnNameLookup:'title', columnNamekey:'idconvalidakind' };
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_data', 'Data Iscrizione al bando di mobilità internazionale', 'g', 102, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idreg_title', 'Identificativo Iscrizione al bando di mobilità internazionale', null, 100, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_anno', 'Anno di corso Iscrizione al bando di mobilità internazionale', null, 101, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_aa', 'Anno accademico Iscrizione al bando di mobilità internazionale', null, 102, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog', 'Didattica programmata Iscrizione al bando di mobilità internazionale', null, 103, null);
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_data'] = { tableNameLookup:'iscrizionebmi', columnNameLookup:'data', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog'] = { tableNameLookup:'iscrizione', columnNameLookup:'iddidprog', columnNamekey:'idiscrizionebmi' };
						this.describeAColumn(table, '!idlearningagrstud_learningagrstud_department', 'learning agreement for studies', null, 120, null);
						objCalcFieldConfig['!idlearningagrstud_learningagrstud_department'] = { tableNameLookup:'learningagrstud', columnNameLookup:'department', columnNamekey:'idlearningagrstud' };
						this.describeAColumn(table, '!idlearningagrtrainer_learningagrtrainer_title', 'Learning agreement for traineersheep', null, 131, null);
						objCalcFieldConfig['!idlearningagrtrainer_learningagrtrainer_title'] = { tableNameLookup:'learningagrtrainer', columnNameLookup:'title', columnNamekey:'idlearningagrtrainer' };
//$objCalcFieldConfig_segstudprat$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segistrein$
						break;
					case 'segistpass':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segistpass$
						break;
					case 'segistabbr':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segistabbr$
						break;
					case 'segmi':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segmi$
						break;
					case 'segisttri':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 20, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segisttri$
						break;
					case 'stutri':
						this.describeAColumn(table, 'cf', 'Crediti formativi', 'fixed.2', 10, null);
						this.describeAColumn(table, 'cfintegrazione', 'Crediti formativi di integrazione', 'fixed.2', 20, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 40, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 50, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 60, null);
						this.describeAColumn(table, '!convalidante', 'Convalidanti', null, 70, null);
						this.describeAColumn(table, '!convalidato', 'Convalidati', null, 80, null);
//$objCalcFieldConfig_stutri$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segmitr':
						table.columns["cf"].caption = "Crediti formativi";
						table.columns["cfintegrazione"].caption = "Crediti formativi di integrazione";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_segmitr$
						break;
					case 'segmi':
						table.columns["idconvalidakind"].caption = "Tipologia";
						table.columns["iddichiar"].caption = "Dichiarazione da convalidare";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizione_from"].caption = "Iscrizione da cui convalidare i sostenimenti";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "learning agreement for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreement for traineersheep";
						table.columns["idpratica"].caption = "pratica di convalida";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_segmi$
						break;
					case 'segstudprat':
//$innerSetCaptionConfig_segstudprat$
						break;
					case 'segistpass':
//$innerSetCaptionConfig_segistpass$
						break;
					case 'segistabbr':
//$innerSetCaptionConfig_segistabbr$
						break;
					case 'segisttri':
//$innerSetCaptionConfig_segisttri$
						break;
					case 'segistrein':
//$innerSetCaptionConfig_segistrein$
						break;
					case 'stutri':
						table.columns["cf"].caption = "Crediti formativi";
						table.columns["cfintegrazione"].caption = "Crediti formativi di integrazione";
						table.columns["idconvalidakind"].caption = "Tipologia";
						table.columns["iddichiar"].caption = "Dichiarazione da convalidare";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizione_from"].caption = "Iscrizione da cui convalidare i sostenimenti";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "learning agreement for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreement for traineersheep";
						table.columns["idpratica"].caption = "pratica di convalida";
						table.columns["idreg"].caption = "Studente";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_stutri$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_convalida");

				//$getNewRowInside$

				dt.autoIncrement('idconvalida', { minimum: 99990001 });

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
					case "segmitr": {
						return "idconvalida asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('convalida', new meta_convalida('convalida'));

	}());
