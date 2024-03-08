(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_convalidato() {
		MetaData.apply(this, ["convalidato"]);
		this.name = 'meta_convalidato';
	}

	meta_convalidato.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_convalidato,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'segmitr':
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa', null, 31, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup: 'attivform', columnNameLookup: 'title', columnNamekey: 'idattivform' };
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 81, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 82, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Denominazione Didattica programmata', null, 81, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup: 'didprog', columnNameLookup: 'title', columnNamekey: 'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup: 'didprog', columnNameLookup: 'aa', columnNamekey: 'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup: 'sede', columnNameLookup: 'title', columnNamekey: 'iddidprog' };
						this.describeAColumn(table, '!idiscrizione_iscrizione_anno', 'Anno di corso Iscrizione della convalida', null, 91, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_aa', 'Anno accademico Iscrizione della convalida', null, 93, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Denominazione Iscrizione della convalida', null, 91, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione della convalida', null, 92, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_idsede', 'Sede Iscrizione della convalida', null, 93, null);
						objCalcFieldConfig['!idiscrizione_iscrizione_anno'] = { tableNameLookup: 'iscrizione', columnNameLookup: 'anno', columnNamekey: 'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_aa'] = { tableNameLookup: 'iscrizione', columnNameLookup: 'aa', columnNamekey: 'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_title'] = { tableNameLookup: 'didprog', columnNameLookup: 'title', columnNamekey: 'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_aa'] = { tableNameLookup: 'didprog', columnNameLookup: 'aa', columnNamekey: 'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_idsede'] = { tableNameLookup: 'didprog', columnNameLookup: 'idsede', columnNamekey: 'idiscrizione' };
						this.describeAColumn(table, '!idlearningagrtrainer_learningagrtrainer_title', 'Learning agreements for traineersheep', null, 141, null);
						this.describeAColumn(table, '!idpratica_pratica_idreg_title', 'Denominazione Pratica', null, 151, null);
						this.describeAColumn(table, '!idpratica_pratica_iddidprog_title', 'Denominazione Pratica', null, 151, null);
						this.describeAColumn(table, '!idpratica_pratica_iddidprog_aa', 'Anno accademico Pratica', null, 152, null);
						this.describeAColumn(table, '!idpratica_pratica_iddidprog_idsede', 'Sede Pratica', null, 153, null);
						objCalcFieldConfig['!idpratica_pratica_idreg_title'] = { tableNameLookup: 'registry', columnNameLookup: 'title', columnNamekey: 'idpratica' };
						objCalcFieldConfig['!idpratica_pratica_iddidprog_title'] = { tableNameLookup: 'didprog', columnNameLookup: 'title', columnNamekey: 'idpratica' };
						objCalcFieldConfig['!idpratica_pratica_iddidprog_aa'] = { tableNameLookup: 'didprog', columnNameLookup: 'aa', columnNamekey: 'idpratica' };
						objCalcFieldConfig['!idpratica_pratica_iddidprog_idsede'] = { tableNameLookup: 'didprog', columnNameLookup: 'idsede', columnNamekey: 'idpratica' };
						objCalcFieldConfig['!idlearningagrtrainer_learningagrtrainer_title'] = { tableNameLookup: 'learningagrtrainer_alias1', columnNameLookup: 'title', columnNamekey: 'idlearningagrtrainer' };
						this.describeAColumn(table, '!idistanza_istanza_imm_idistanza_data', 'Data Istanza', 'g', 122, null);
						this.describeAColumn(table, '!idistanza_istanza_imm_idistanza_aa', 'Anno accademico Istanza', null, 122, null);
						this.describeAColumn(table, '!idistanza_istanza_imm_idistanza_idsede', 'Sede Istanza', null, 123, null);
						this.describeAColumn(table, '!idistanza_istanza_imm_idistanzakind_title', 'Stato Istanza', null, 121, null);
						this.describeAColumn(table, '!idistanza_istanza_imm_idreg_studenti_anno', 'Anno di corso Istanza', null, 121, null);
						this.describeAColumn(table, '!idistanza_istanza_imm_iddidprog_iddidprog', 'Didattica programmata Istanza', null, 122, null);
						this.describeAColumn(table, '!idistanza_istanza_imm_iddidprog_aa', 'Anno accademico Istanza', null, 123, null);
						objCalcFieldConfig['!idistanza_istanza_imm_idistanza_data'] = { tableNameLookup: 'istanza', columnNameLookup: 'data', columnNamekey: 'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_imm_idistanza_aa'] = { tableNameLookup: 'didprog', columnNameLookup: 'aa', columnNamekey: 'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_imm_idistanza_idsede'] = { tableNameLookup: 'didprog', columnNameLookup: 'idsede', columnNamekey: 'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_imm_idistanzakind_title'] = { tableNameLookup: 'statuskind', columnNameLookup: 'title', columnNamekey: 'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_imm_idreg_studenti_anno'] = { tableNameLookup: 'iscrizione', columnNameLookup: 'anno', columnNamekey: 'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_imm_iddidprog_iddidprog'] = { tableNameLookup: 'iscrizione', columnNameLookup: 'iddidprog', columnNamekey: 'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_imm_iddidprog_aa'] = { tableNameLookup: 'iscrizione', columnNameLookup: 'aa', columnNamekey: 'idistanza' };
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 31, null);
						//$objCalcFieldConfig_segmitr$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup: 'attivform', columnNameLookup: 'title', columnNamekey: 'idattivform' };
						this.describeAColumn(table, '!idchanges_changes_title', 'Changes', null, 21, null);
						objCalcFieldConfig['!idchanges_changes_title'] = { tableNameLookup: 'changes', columnNameLookup: 'title', columnNamekey: 'idchanges' };
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 51, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup: 'changeskind', columnNameLookup: 'title', columnNamekey: 'idchangeskind' };
						//$objCalcFieldConfig_segistrein$
						break;
					case 'segistpass':
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup: 'attivform', columnNameLookup: 'title', columnNamekey: 'idattivform' };
						this.describeAColumn(table, '!idchanges_changes_title', 'Changes', null, 21, null);
						objCalcFieldConfig['!idchanges_changes_title'] = { tableNameLookup: 'changes', columnNameLookup: 'title', columnNamekey: 'idchanges' };
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 51, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup: 'changeskind', columnNameLookup: 'title', columnNamekey: 'idchangeskind' };
						//$objCalcFieldConfig_segistpass$
						break;
					//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType) {
				var def = appMeta.Deferred("getNewRow-meta_convalidato");

				var realParentObjectRow = parentRow;
				if (editType === "segmitr") {
					var realParentTableName = "convalida";
					var realParentTable = dt.dataset.tables["convalida"];
					if (!realParentTable) {
						console.log("ERROR: la tabella " + realParentTableName + "  non esiste nel dataset");
						return def.resolve(null);
					}
					if (!realParentTable.rows.length) {
						console.log("ERROR: la tabella " + realParentTableName + "  non ha righe");
						return def.resolve(null);
					}
					realParentObjectRow = realParentTable.rows[0].getRow();
				}
				//$getNewRowInside$

				dt.autoIncrement('idconvalidato', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(realParentObjectRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},




			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segistrein": {
						return "idattivform desc";
					}
					case "segistpass": {
						return "idattivform desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

		});

	window.appMeta.addMeta('convalidato', new meta_convalidato('convalidato'));

}());
