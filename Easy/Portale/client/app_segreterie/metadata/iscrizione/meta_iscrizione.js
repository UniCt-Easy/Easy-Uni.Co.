(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_iscrizione() {
		MetaData.apply(this, ["iscrizione"]);
		this.name = 'meta_iscrizione';
	}

	meta_iscrizione.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_iscrizione,
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
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_didprog$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 52, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Sede Didattica programmata', null, 50, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias1', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias1', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias1', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias1', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seganagstuacc':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Prova di accesso', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Prova di accesso', null, 52, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias2', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias2', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias3', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias3', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstuacc$
						break;
					case 'seganagstumast':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Master', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Master', null, 52, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias3', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias3', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias4', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias4', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstumast$
						break;
					case 'seganagstustato':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Esame di stato', null, 51, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Esame di stato', null, 52, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias4', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias4', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias5', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias5', columnNameLookup:'aa', columnNamekey:'iddidprog' };
//$objCalcFieldConfig_seganagstustato$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_seg$
						break;
					case 'ingresso':
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup: 'registry', columnNameLookup: 'title', columnNamekey: 'idreg' };
												objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_ingresso$
						break;
					case 'stato':
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_stato$
						break;
					case 'dotmas':
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_dotmas$
						break;
					case 'seganagstusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'default':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 30, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_default$
						break;
					case 'stuaccesso':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_stuaccesso$
						break;
					case 'stu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_stu$
						break;
					case 'stumast':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_stumast$
						break;
					case 'stusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_stusing$
						break;
					case 'diderog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 61, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg' };
						//objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_diderog$
						break;
					case 'onlydidprog':
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_onlydidprog$
						break;
					case 'segsing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_segsing$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'dotmas':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_dotmas$
						break;
					case 'stato':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_stato$
						break;
					case 'seganagstu':
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'didprog':
//$innerSetCaptionConfig_didprog$
						break;
					case 'seg':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seg$
						break;
					case 'seganagstuacc':
						table.columns["iddidprog"].caption = "Prova di accesso";
//$innerSetCaptionConfig_seganagstuacc$
						break;
					case 'seganagstusing':
//$innerSetCaptionConfig_seganagstusing$
						break;
					case 'seganagstumast':
						table.columns["iddidprog"].caption = "Master";
//$innerSetCaptionConfig_seganagstumast$
						break;
					case 'seganagstustato':
						table.columns["ct"].caption = "new Date()";
						table.columns["cu"].caption = "appMeta.security.sysEnv.idcustomuser";
						table.columns["iddidprog"].caption = "Esame di stato";
						table.columns["lt"].caption = "new Date()";
						table.columns["lu"].caption = "appMeta.security.sysEnv.idcustomuser";
//$innerSetCaptionConfig_seganagstustato$
						break;
					case 'default':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_default$
						break;
					case 'stuaccesso':
//$innerSetCaptionConfig_stuaccesso$
						break;
					case 'stu':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Prova di accesso";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_stu$
						break;
					case 'stumast':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Master";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_stumast$
						break;
					case 'stusing':
//$innerSetCaptionConfig_stusing$
						break;
					case 'onlydidprog':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_onlydidprog$
						break;
					case 'segsing':
//$innerSetCaptionConfig_segsing$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_iscrizione");

				//$getNewRowInside$

				dt.autoIncrement('idiscrizione', { minimum: 99990001 });

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
					case "didprog": {
						return "idreg desc";
					}
					case "seg": {
						return "iddidprog desc, idreg desc";
					}
					case "dotmas": {
						return "idreg desc";
					}
					case "stato": {
						return "idreg desc";
					}
					case "seganagstu": {
						return "data desc";
					}
					case "seganagstuacc": {
						return "data desc";
					}
					case "seganagstusing": {
						return "data desc";
					}
					case "seganagstumast": {
						return "data desc";
					}
					case "seganagstustato": {
						return "data desc";
					}
					case "default": {
						return "idreg desc";
					}
					case "stuaccesso": {
						return "data desc";
					}
					case "stu": {
						return "data desc";
					}
					case "stumast": {
						return "data desc";
					}
					case "stusing": {
						return "data desc";
					}
					case "onlydidprog": {
						return "idreg desc";
					}
					case "segsing": {
						return "data desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

		});

	window.appMeta.addMeta('iscrizione', new meta_iscrizione('iscrizione'));

}());
