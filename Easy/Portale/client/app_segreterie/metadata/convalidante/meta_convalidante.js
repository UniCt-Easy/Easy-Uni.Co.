(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_convalidante() {
        MetaData.apply(this, ["convalidante"]);
        this.name = 'meta_convalidante';
    }

    meta_convalidante.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_convalidante,
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
					case 'segmi':
						this.describeAColumn(table, 'changes', 'Changes', null, 20, null);
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, 'idchangeskind', 'Changes kind', null, 40, null);
						this.describeAColumn(table, 'idsostenimento', 'Sostenimento', null, 160, null);
//$objCalcFieldConfig_segmi$
						break;
					case 'segstudprat':
						this.describeAColumn(table, 'idsostenimento', 'Sostenimento', null, 10, null);
						this.describeAColumn(table, 'idtirocinioprogetto', 'Progetto del tirocinio', null, 20, null);
						this.describeAColumn(table, 'changes', 'Changes', null, 30, null);
						this.describeAColumn(table, 'changesother', 'Changes other', null, 40, -1);
						this.describeAColumn(table, 'idchangeskind', 'Changes kind', null, 50, null);
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 51, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup:'changeskind', columnNameLookup:'title', columnNamekey:'idchangeskind' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 12, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 13, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 14, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_data', 'Data Sostenimento', null, 15, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 10, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 10, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_data'] = { tableNameLookup:'sostenimento', columnNameLookup:'data', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_title', 'Titolo Progetto del tirocinio', null, 21, null);
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_description', 'Descrizione Progetto del tirocinio', null, 22, null);
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_title'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'title', columnNamekey:'idtirocinioprogetto' };
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_description'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'description', columnNamekey:'idtirocinioprogetto' };
//$objCalcFieldConfig_segstudprat$
						break;
					case 'segistrein':
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 160, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segistrein$
						break;
					case 'segistpass':
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 160, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segistpass$
						break;
					case 'segistabbr':
						this.describeAColumn(table, 'idsostenimento', 'Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 160, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segistabbr$
						break;
					case 'segisttri':
						this.describeAColumn(table, 'idsostenimento', 'Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 160, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segisttri$
						break;
					case 'stutri':
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 160, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 160, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
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
					case 'segmi':
						table.columns["changesother"].caption = "Changes other";
						table.columns["idchangeskind"].caption = "Changes kind";
						table.columns["idconvalida"].caption = "Convalida";
						table.columns["iddichiar"].caption = "Altro titolo";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione della convalida";
						table.columns["idiscrizione_from"].caption = "Iscrizione del sostenimento";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "Learning agreements for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreements for traineership";
						table.columns["idpratica"].caption = "Pratica";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Sostenimento";
						table.columns["idtirocinioprogetto"].caption = "Progetto del tirocinio";
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
						table.columns["changesother"].caption = "Changes other";
//$innerSetCaptionConfig_segistrein$
						break;
					case 'stutri':
						table.columns["changesother"].caption = "Changes other";
						table.columns["idchangeskind"].caption = "Changes kind";
						table.columns["idconvalida"].caption = "Convalida";
						table.columns["iddichiar"].caption = "Altro titolo";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione della convalida";
						table.columns["idiscrizione_from"].caption = "Iscrizione del sostenimento";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idlearningagrstud"].caption = "Learning agreements for studies";
						table.columns["idlearningagrtrainer"].caption = "Learning agreements for traineership";
						table.columns["idpratica"].caption = "Pratica";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Sostenimento";
						table.columns["idtirocinioprogetto"].caption = "Progetto del tirocinio";
//$innerSetCaptionConfig_stutri$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_convalidante");

				//$getNewRowInside$

				dt.autoIncrement('idconvalidante', { minimum: 99990001 });

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
					case "segstudprat": {
						return "idsostenimento desc";
					}
					case "segistrein": {
						return "idsostenimento desc";
					}
					case "segistpass": {
						return "idsostenimento desc";
					}
					case "segmi": {
						return "changes asc ";
					}
					case "segistabbr": {
						return "idsostenimento desc";
					}
					case "segisttri": {
						return "idsostenimento desc";
					}
					case "stutri": {
						return "idsostenimento desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('convalidante', new meta_convalidante('convalidante'));

	}());
