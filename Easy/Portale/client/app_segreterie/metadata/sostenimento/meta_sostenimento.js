(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sostenimento() {
        MetaData.apply(this, ["sostenimento"]);
        this.name = 'meta_sostenimento';
    }

    meta_sostenimento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sostenimento,
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
					case 'didprog':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_didprog$
						break;
					case 'segcons':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 70, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 80, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 90, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 110, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 120, 50);
						this.describeAColumn(table, 'protnumero', 'Numero Protocollo', null, 200, null);
						this.describeAColumn(table, 'protanno', 'Anno protocollo', null, 210, null);
//$objCalcFieldConfig_segcons$
						break;
					case 'seganagstustato':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstustato$
						break;
					case 'seganagstuconsmast':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstuconsmast$
						break;
					case 'seganagstuacc':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstuacc$
						break;
					case 'seganagstusing':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'segstud':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
//$objCalcFieldConfig_segstud$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa', null, 91, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'ingresso':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_ingresso$
						break;
					case 'default':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias4', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_default$
						break;
					case 'doc':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias4', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_doc$
						break;
					case 'stu':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idattivform_attivform_title', 'Attività formativa', null, 91, null);
						objCalcFieldConfig['!idattivform_attivform_title'] = { tableNameLookup:'attivform_alias2', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idprova_prova_title', 'Denominazione Prova', null, 101, null);
						this.describeAColumn(table, '!idprova_prova_start', 'Data e ora inizio Prova', 'g', 102, null);
						objCalcFieldConfig['!idprova_prova_title'] = { tableNameLookup:'prova', columnNameLookup:'title', columnNamekey:'idprova' };
						objCalcFieldConfig['!idprova_prova_start'] = { tableNameLookup:'prova', columnNameLookup:'start', columnNamekey:'idprova' };
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_stu$
						break;
					case 'stumastmast':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_stumastmast$
						break;
					case 'stusing':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 240, 50);
						this.describeAColumn(table, '!idsostenimentoesito_sostenimentoesito_title', 'Esito', null, 121, null);
						objCalcFieldConfig['!idsostenimentoesito_sostenimentoesito_title'] = { tableNameLookup:'sostenimentoesito', columnNameLookup:'title', columnNamekey:'idsostenimentoesito' };
//$objCalcFieldConfig_stusing$
						break;
					case 'piano':
						this.describeAColumn(table, 'data', 'Data', null, 20, null);
						this.describeAColumn(table, 'ects', 'ECTS', null, 40, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 50, 50);
						this.describeAColumn(table, 'livello', 'Livello', null, 160, null);
						this.describeAColumn(table, 'voto', 'Voto', 'fixed.2', 200, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 220, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 230, null);
//$objCalcFieldConfig_piano$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'ingresso':
						table.columns["ects"].caption = "ECTS";
						table.columns["idappello"].caption = "Appello";
						table.columns["idattivform"].caption = "Attività formativa";
						table.columns["idcorsostudio"].caption = "Corso studio";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idprova"].caption = "Prova";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Identificativo";
						table.columns["idsostenimentoesito"].caption = "Esito";
						table.columns["idtitolostudio"].caption = "Titolo di studio";
						table.columns["insecod"].caption = "Codice insegnamento";
						table.columns["insedesc"].caption = "Insegnamento";
						table.columns["paridsostenimento"].caption = "Sostenimento parziale di";
						table.columns["protanno"].caption = "Anno protocollo";
						table.columns["protnumero"].caption = "Numero Protocollo";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'seganagstu':
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'seganagstusing':
//$innerSetCaptionConfig_seganagstusing$
						break;
					case 'seganagstustato':
						table.columns["ects"].caption = "ECTS";
//$innerSetCaptionConfig_seganagstustato$
						break;
					case 'seganagstuconsmast':
						table.columns["ects"].caption = "ECTS";
//$innerSetCaptionConfig_seganagstuconsmast$
						break;
					case 'seganagstuacc':
						table.columns["ects"].caption = "ECTS";
//$innerSetCaptionConfig_seganagstuacc$
						break;
					case 'segcons':
//$innerSetCaptionConfig_segcons$
						break;
					case 'doc':
//$innerSetCaptionConfig_doc$
						break;
					case 'stu':
//$innerSetCaptionConfig_stu$
						break;
					case 'stumastmast':
						table.columns["ects"].caption = "ECTS";
						table.columns["idappello"].caption = "Appello";
						table.columns["idattivform"].caption = "Attività formativa";
						table.columns["idcorsostudio"].caption = "Corso studio";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idprova"].caption = "Prova";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Identificativo";
						table.columns["idsostenimentoesito"].caption = "Esito";
						table.columns["idtitolostudio"].caption = "Titolo di studio";
						table.columns["insecod"].caption = "Codice insegnamento";
						table.columns["insedesc"].caption = "Insegnamento";
						table.columns["paridsostenimento"].caption = "Sostenimento parziale di";
						table.columns["protanno"].caption = "Anno protocollo";
						table.columns["protnumero"].caption = "Numero Protocollo";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_stumastmast$
						break;
					case 'stusing':
//$innerSetCaptionConfig_stusing$
						break;
					case 'piano':
						table.columns["ects"].caption = "ECTS";
						table.columns["idappello"].caption = "Appello";
						table.columns["idattivform"].caption = "Attività formativa";
						table.columns["idcorsostudio"].caption = "Corso studio";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idprova"].caption = "Prova";
						table.columns["idreg"].caption = "Studente";
						table.columns["idsostenimento"].caption = "Identificativo";
						table.columns["idsostenimentoesito"].caption = "Esito";
						table.columns["idtitolostudio"].caption = "Titolo di studio";
						table.columns["insecod"].caption = "Codice insegnamento";
						table.columns["insedesc"].caption = "Insegnamento";
						table.columns["paridsostenimento"].caption = "Sostenimento parziale di";
						table.columns["protanno"].caption = "Anno protocollo";
						table.columns["protnumero"].caption = "Numero Protocollo";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_piano$
						break;
					case 'default':
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_sostenimento");

				//$getNewRowInside$

				dt.autoIncrement('idsostenimento', { minimum: 99990001 });

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
					case "seganagstu": {
						return "data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sostenimento', new meta_sostenimento('sostenimento'));

	}());
