(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudioattivform() {
        MetaData.apply(this, ["pianostudioattivform"]);
        this.name = 'meta_pianostudioattivform';
    }

    meta_pianostudioattivform.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudioattivform,
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
					case 'seganagstusing':
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 11, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_data', 'Data Sostenimento', null, 21, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 23, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 24, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 25, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idsostenimentoesito_title', 'Esito Sostenimento', null, 20, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_data'] = { tableNameLookup:'sostenimento_alias1', columnNameLookup:'data', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento_alias1', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento_alias1', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento_alias1', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idsostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						/*
						objCalcFieldConfig['!idsostenimento_sostenimento_data'] = { tableNameLookup: 'sostenimento_alias2', columnNameLookup: 'data', columnNamekey: 'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						*/
						objCalcFieldConfig['!idsostenimento_sostenimento_data'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'data', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_data'] = { tableNameLookup:'sostenimento', columnNameLookup:'data', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 10, null);
						//this.describeAColumn(table, 'idattivform', 'Attività formativa del corso', null, 20, null);
						//this.describeAColumn(table, 'idattivform_scelta', 'Attività formativa che lo studente svolgerà', null, 30, null);
						//this.describeAColumn(table, 'idsostenimento', 'Sostenimento', null, 40, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 21, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa che lo studente svolgerà', null, 31, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 42, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 43, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 44, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 40, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 40, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform' };
//						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform_alias2', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
//						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
//						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
//						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'segstud':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 10, null);
						this.describeAColumn(table, '!idattivform_attivform_aa', 'Identificativo Attività formativa del corso', null, 21, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa Attività formativa del corso', null, 22, null);
						objCalcFieldConfig['!idattivform_attivform_aa'] = { tableNameLookup:'attivform', columnNameLookup:'aa', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_aa', 'Identificativo Attività formativa che lo studente svolgerà', null, 31, null);
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa Attività formativa che lo studente svolgerà', null, 32, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_aa'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'aa', columnNamekey:'idattivform_scelta' };
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_data', 'Data Sostenimento', null, 41, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_giudizio', 'Giudizio Sostenimento', null, 42, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 44, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 45, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 46, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idsostenimentoesito_title', 'Esito Sostenimento', null, 40, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_data'] = { tableNameLookup:'sostenimento', columnNameLookup:'data', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_giudizio'] = { tableNameLookup:'sostenimento', columnNameLookup:'giudizio', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idsostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segstud$
						break;
					case 'didprog':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 10, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 21, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa che lo studente svolgerà', null, 31, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 42, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 43, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 44, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 40, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Studente Sostenimento', null, 40, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento_alias2', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_didprog$
						break;
					case 'stupiano':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 10, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 21, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa che lo studente svolgerà', null, 31, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
//$objCalcFieldConfig_stupiano$
						break;
					case 'stusing':
						this.describeAColumn(table, 'anno', 'Anno di corso', null, 10, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa del corso', null, 21, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_scelta_attivform_title', 'Attività formativa che lo studente svolgerà', null, 31, null);
						objCalcFieldConfig['!idattivform_scelta_attivform_title'] = { tableNameLookup:'attivform_alias1', columnNameLookup:'title', columnNamekey:'idattivform_scelta' };
//$objCalcFieldConfig_stusing$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seganagstusing':
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idattivform"].caption = "Attività formativa del corso";
						table.columns["idattivform_scelta"].caption = "Attività formativa che lo studente svolgerà";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idpianostudio"].caption = "Piano di studi";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Sostenimento";
//$innerSetCaptionConfig_seganagstusing$
						break;
					case 'seganagstu':
						table.columns["anno"].caption = "Anno di corso";
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'didprog':
						table.columns["anno"].caption = "Anno di corso";
//$innerSetCaptionConfig_didprog$
						break;
					case 'segstud':
//$innerSetCaptionConfig_segstud$
						break;
					case 'stupiano':
//$innerSetCaptionConfig_stupiano$
						break;
					case 'stusing':
//$innerSetCaptionConfig_stusing$
						break;
					case 'prenot':
						table.columns["anno"].caption = "Anno di corso";
						table.columns["idattivform"].caption = "Attività formativa del corso";
						table.columns["idattivform_scelta"].caption = "Attività formativa che lo studente svolgerà";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idpianostudio"].caption = "Piano di studi";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Sostenimento";
//$innerSetCaptionConfig_prenot$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pianostudioattivform");

				//$getNewRowInside$

				dt.autoIncrement('idpianostudioattivform', { minimum: 99990001 });

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

    window.appMeta.addMeta('pianostudioattivform', new meta_pianostudioattivform('pianostudioattivform'));

	}());
