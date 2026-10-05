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
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 31, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
//$objCalcFieldConfig_segmitr$
						break;
					case 'segistrein':
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
//$objCalcFieldConfig_segistrein$
						break;
					case 'segistpass':
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
//$objCalcFieldConfig_segistpass$
						break;
					case 'segmi':
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
//$objCalcFieldConfig_segmi$
						break;
					case 'segstudprat':
						this.describeAColumn(table, 'changesother', 'Changes other', null, 40, -1);
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 11, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idchanges_changes_title', 'Changes', null, 21, null);
						objCalcFieldConfig['!idchanges_changes_title'] = { tableNameLookup:'changes', columnNameLookup:'title', columnNamekey:'idchanges' };
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 31, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup:'changeskind_alias1', columnNameLookup:'title', columnNamekey:'idchangeskind' };
//$objCalcFieldConfig_segstudprat$
						break;
					case 'segistabbr':
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
//$objCalcFieldConfig_segistabbr$
						break;
					case 'segisttri':
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
//$objCalcFieldConfig_segisttri$
						break;
					case 'stutri':
						this.describeAColumn(table, '!idattivform_attivform_title', 'attività formativa', null, 41, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
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
						table.columns["changesother"].caption = "Changes other";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idchanges"].caption = "Changes";
						table.columns["idchangeskind"].caption = "Changes kind";
						table.columns["idconvalida"].caption = "Convalida";
						table.columns["idconvalidato"].caption = "Convalidato";
						table.columns["iddichiar"].caption = "Dichiarazione convalidata";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione della convalida";
						table.columns["idiscrizione_from"].caption = "Iscrizione del sostenimento";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "Learning agreements for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreements for traineersheep";
						table.columns["idpratica"].caption = "Pratica";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_segmitr$
						break;
					case 'segmi':
//$innerSetCaptionConfig_segmi$
						break;
					case 'segstudprat':
//$innerSetCaptionConfig_segstudprat$
						break;
					case 'segistpass':
//$innerSetCaptionConfig_segistpass$
						break;
					case 'segistabbr':
						table.columns["changesother"].caption = "Changes other";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idchanges"].caption = "Changes";
						table.columns["idchangeskind"].caption = "Changes kind";
						table.columns["idconvalida"].caption = "Convalida";
						table.columns["idconvalidato"].caption = "Convalidato";
						table.columns["iddichiar"].caption = "Dichiarazione convalidata";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione della convalida";
						table.columns["idiscrizione_from"].caption = "Iscrizione del sostenimento";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "Learning agreements for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreements for traineersheep";
						table.columns["idpratica"].caption = "Pratica";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_segistabbr$
						break;
					case 'segisttri':
						table.columns["changesother"].caption = "Changes other";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idchanges"].caption = "Changes";
						table.columns["idchangeskind"].caption = "Changes kind";
						table.columns["idconvalida"].caption = "Convalida";
						table.columns["idconvalidato"].caption = "Convalidato";
						table.columns["iddichiar"].caption = "Dichiarazione convalidata";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione della convalida";
						table.columns["idiscrizione_from"].caption = "Iscrizione del sostenimento";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "Learning agreements for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreements for traineersheep";
						table.columns["idpratica"].caption = "Pratica";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_segisttri$
						break;
					case 'segistrein':
						table.columns["changesother"].caption = "Changes other";
//$innerSetCaptionConfig_segistrein$
						break;
					case 'stutri':
						table.columns["changesother"].caption = "Changes other";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idchanges"].caption = "Changes";
						table.columns["idchangeskind"].caption = "Changes kind";
						table.columns["idconvalida"].caption = "Convalida";
						table.columns["idconvalidato"].caption = "Convalidato";
						table.columns["iddichiar"].caption = "Dichiarazione convalidata";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione della convalida";
						table.columns["idiscrizione_from"].caption = "Iscrizione del sostenimento";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "Learning agreements for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreements for traineersheep";
						table.columns["idpratica"].caption = "Pratica";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_stutri$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_convalidato");

				//$getNewRowInside$

				dt.autoIncrement('idconvalidato', { minimum: 99990001 });

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
					case "segistrein": {
						return "idattivform desc";
					}
					case "segistpass": {
						return "idattivform desc";
					}
					case "segmitr": {
						return "idattivform desc";
					}
					case "segmi": {
						return "idattivform desc";
					}
					case "segstudprat": {
						return "idattivform desc";
					}
					case "segistabbr": {
						return "idattivform desc";
					}
					case "segisttri": {
						return "idattivform desc";
					}
					case "stutri": {
						return "idattivform desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

		});

	window.appMeta.addMeta('convalidato', new meta_convalidato('convalidato'));

}());
