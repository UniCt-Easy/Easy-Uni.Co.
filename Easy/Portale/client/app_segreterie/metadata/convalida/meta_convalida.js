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
						this.describeAColumn(table, 'idiscrizionebmi', 'Iscrizione al bando di mobilità internazionale', null, 100, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 160, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 170, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 180, null);
//$objCalcFieldConfig_segmitr$
						break;
					case 'segstudprat':
						this.describeAColumn(table, '!idconvalidakind_convalidakind_title', 'Tipologia', null, 51, null);
						objCalcFieldConfig['!idconvalidakind_convalidakind_title'] = { tableNameLookup:'convalidakind', columnNameLookup:'title', columnNamekey:'idconvalidakind' };
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_data', 'Data Iscrizione al bando di mobilità internazionale', 'g', 102, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idreg_title', 'Denominazione Iscrizione al bando di mobilità internazionale', null, 101, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_anno', 'Anno di corso Iscrizione al bando di mobilità internazionale', null, 101, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog', 'Didattica programmata Iscrizione al bando di mobilità internazionale', null, 102, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_aa', 'Anno accademico Iscrizione al bando di mobilità internazionale', null, 103, null);
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_data'] = { tableNameLookup:'iscrizionebmi', columnNameLookup:'data', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog'] = { tableNameLookup:'iscrizione', columnNameLookup:'iddidprog', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizionebmi' };
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
						this.describeAColumn(table, '!idconvalidakind_convalidakind_title', 'Tipologia', null, 51, null);
						objCalcFieldConfig['!idconvalidakind_convalidakind_title'] = { tableNameLookup:'convalidakind', columnNameLookup:'title', columnNamekey:'idconvalidakind' };
						this.describeAColumn(table, '!iddichiar_dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 60, null);
						this.describeAColumn(table, '!iddichiar_dichiar_extension', 'Tabella che estende il record Dichiarazione da convalidare', null, 60, null);
						objCalcFieldConfig['!iddichiar_dichiar_aa'] = { tableNameLookup:'dichiar', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_extension'] = { tableNameLookup:'dichiar', columnNameLookup:'extension', columnNamekey:'iddichiar' };
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 71, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 72, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Denominazione Didattica programmata', null, 71, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!idiscrizione_iscrizione_anno', 'Anno di corso Iscrizione', null, 81, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_aa', 'Anno accademico Iscrizione', null, 83, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Denominazione Iscrizione', null, 81, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione', null, 82, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_idsede', 'Sede Iscrizione', null, 83, null);
						objCalcFieldConfig['!idiscrizione_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione' };
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione da cui convalidare i sostenimenti', null, 91, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui convalidare i sostenimenti', null, 93, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione da cui convalidare i sostenimenti', null, 91, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione da cui convalidare i sostenimenti', null, 92, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione da cui convalidare i sostenimenti', null, 93, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_data', 'Data Iscrizione al bando di mobilità internazionale', 'g', 102, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idreg_title', 'Denominazione Iscrizione al bando di mobilità internazionale', null, 101, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_anno', 'Anno di corso Iscrizione al bando di mobilità internazionale', null, 101, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog', 'Didattica programmata Iscrizione al bando di mobilità internazionale', null, 102, null);
						this.describeAColumn(table, '!idiscrizionebmi_iscrizionebmi_idiscrizione_aa', 'Anno accademico Iscrizione al bando di mobilità internazionale', null, 103, null);
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_data'] = { tableNameLookup:'iscrizionebmi', columnNameLookup:'data', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_iddidprog'] = { tableNameLookup:'iscrizione', columnNameLookup:'iddidprog', columnNamekey:'idiscrizionebmi' };
						objCalcFieldConfig['!idiscrizionebmi_iscrizionebmi_idiscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizionebmi' };
						this.describeAColumn(table, '!idistanza_istanza_aa', 'Anno accademico Istanza', null, 110, null);
						this.describeAColumn(table, '!idistanza_istanza_extension', 'Tabella che estende il record Istanza', null, 110, null);
						objCalcFieldConfig['!idistanza_istanza_aa'] = { tableNameLookup:'istanza', columnNameLookup:'aa', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_extension'] = { tableNameLookup:'istanza', columnNameLookup:'extension', columnNamekey:'idistanza' };
						this.describeAColumn(table, '!idlearningagrtrainer_learningagrtrainer_title', 'Learning agreement for traineersheep', null, 131, null);
						objCalcFieldConfig['!idlearningagrtrainer_learningagrtrainer_title'] = { tableNameLookup:'learningagrtrainer', columnNameLookup:'title', columnNamekey:'idlearningagrtrainer' };
						this.describeAColumn(table, '!idistanza_istanza_pas_aa', 'Anno accademico Istanza', null, 112, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_data', 'Data Istanza', 'g', 112, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_title', 'Tipologia Istanza', null, 111, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_title', 'Denominazione Istanza', null, 111, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_title', 'Denominazione Istanza', null, 111, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_aa', 'Anno accademico Istanza', null, 112, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_idsede', 'Sede Istanza', null, 113, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_title', 'Stato Istanza', null, 111, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_anno', 'Anno di corso Istanza', null, 111, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_iddidprog', 'Didattica programmata Istanza', null, 112, null);
						this.describeAColumn(table, '!idistanza_istanza_pas_aa', 'Anno accademico Istanza', null, 113, null);
						objCalcFieldConfig['!idistanza_istanza_pas_aa'] = { tableNameLookup:'istanza', columnNameLookup:'aa', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_data'] = { tableNameLookup:'istanza', columnNameLookup:'data', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_title'] = { tableNameLookup:'istanza', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_title'] = { tableNameLookup:'istanza', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_title'] = { tableNameLookup:'istanza', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_aa'] = { tableNameLookup:'istanza', columnNameLookup:'aa', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_idsede'] = { tableNameLookup:'istanza', columnNameLookup:'idsede', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_title'] = { tableNameLookup:'istanza', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_anno'] = { tableNameLookup:'istanza', columnNameLookup:'anno', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_iddidprog'] = { tableNameLookup:'istanza', columnNameLookup:'iddidprog', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_pas_aa'] = { tableNameLookup:'istanza', columnNameLookup:'aa', columnNamekey:'idistanza' };
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
						this.describeAColumn(table, '!idconvalidakind_convalidakind_title', 'Tipologia', null, 51, null);
						objCalcFieldConfig['!idconvalidakind_convalidakind_title'] = { tableNameLookup:'convalidakind', columnNameLookup:'title', columnNamekey:'idconvalidakind' };
//$objCalcFieldConfig_segmi$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

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

			//$getSorting$

        });

    window.appMeta.addMeta('convalida', new meta_convalida('convalida'));

	}());
