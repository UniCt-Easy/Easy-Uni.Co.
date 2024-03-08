(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appelloattivform() {
        MetaData.apply(this, ["appelloattivform"]);
        this.name = 'meta_appelloattivform';
    }

    meta_appelloattivform.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appelloattivform,
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
					case 'seg_child':
						this.describeAColumn(table, '!idappello_appello_description', 'Descrizione', null, 21, null);
						this.describeAColumn(table, '!idappello_annoaccademico_aa', 'Anno accademico', null, 20, null);
						this.describeAColumn(table, '!idappello_appelloazionekind_title', 'Ordinario/Correttivo/Integrativo', null, 21, null);
						this.describeAColumn(table, '!idappello_appellokind_title', 'Tipologia', null, 21, null);
						this.describeAColumn(table, '!idappello_sessione_sessionekind_title', 'Tipologia Tipologie di sessione', null, 21, null);
						this.describeAColumn(table, '!idappello_sessione_start', 'Data di inizio Sessione', null, 22, null);
						this.describeAColumn(table, '!idappello_sessione_stop', 'Data di fine Sessione', null, 23, null);
						this.describeAColumn(table, '!idappello_appello_minvoto', 'Voto minimo', null, 20, null);
						this.describeAColumn(table, '!idappello_appello_basevoto', 'Votazione di base', null, 20, null);
						this.describeAColumn(table, '!idappello_appello_prointermedia', 'Prova intermedia', null, 20, null);
						this.describeAColumn(table, '!idappello_appello_posti', 'Numero massimo di posti', null, 20, null);
						this.describeAColumn(table, '!idappello_appello_prenotstart', 'Data di inizio prenotazioni', 'g', 20, null);
						this.describeAColumn(table, '!idappello_appello_penotend', 'Data fine delle prenotazioni', 'g', 20, null);
						this.describeAColumn(table, '!idappello_appello_publicato', 'Publicato', null, 20, null);
						objCalcFieldConfig['!idappello_appello_description'] = { tableNameLookup:'appello', columnNameLookup:'description', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_annoaccademico_aa'] = { tableNameLookup:'annoaccademico', columnNameLookup:'aa', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appelloazionekind_title'] = { tableNameLookup:'appelloazionekind', columnNameLookup:'title', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appellokind_title'] = { tableNameLookup:'appellokind', columnNameLookup:'title', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_sessione_sessionekind_title'] = { tableNameLookup:'sessionekind', columnNameLookup:'title', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_sessione_start'] = { tableNameLookup:'sessione', columnNameLookup:'start', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_sessione_stop'] = { tableNameLookup:'sessione', columnNameLookup:'stop', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_minvoto'] = { tableNameLookup:'appello', columnNameLookup:'minvoto', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_basevoto'] = { tableNameLookup:'appello', columnNameLookup:'basevoto', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_prointermedia'] = { tableNameLookup:'appello', columnNameLookup:'prointermedia', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_posti'] = { tableNameLookup:'appello', columnNameLookup:'posti', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_prenotstart'] = { tableNameLookup:'appello', columnNameLookup:'prenotstart', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_penotend'] = { tableNameLookup:'appello', columnNameLookup:'penotend', columnNamekey:'idappello' };
						objCalcFieldConfig['!idappello_appello_publicato'] = { tableNameLookup:'appello', columnNameLookup:'publicato', columnNamekey:'idappello' };
						this.describeAColumn(table, '!idappello_appello_description', 'Descrizione', null, 22, null);
						this.describeAColumn(table, '!idappello_annoaccademico_aa', 'Anno accademico', null, 22, null);
						this.describeAColumn(table, '!idappello_appelloazionekind_title', 'Ordinario/Correttivo/Integrativo', null, 29, null);
						this.describeAColumn(table, '!idappello_appellokind_title', 'Tipologia', null, 30, null);
						this.describeAColumn(table, '!idappello_sessione_sessionekind_title', 'Tipologia Tipologie di sessione', null, 31, null);
						this.describeAColumn(table, '!idappello_sessione_start', 'Data di inizio Sessione', null, 32, null);
						this.describeAColumn(table, '!idappello_sessione_stop', 'Data di fine Sessione', null, 33, null);
						this.describeAColumn(table, '!idappello_appello_minvoto', 'Voto minimo', null, 34, null);
						this.describeAColumn(table, '!idappello_appello_basevoto', 'Votazione di base', null, 35, null);
						this.describeAColumn(table, '!idappello_appello_prointermedia', 'Prova intermedia', null, 36, null);
						this.describeAColumn(table, '!idappello_appello_posti', 'Numero massimo di posti', null, 37, null);
						this.describeAColumn(table, '!idappello_appello_prenotstart', 'Data di inizio prenotazioni', 'g', 38, null);
						this.describeAColumn(table, '!idappello_appello_penotend', 'Data fine delle prenotazioni', 'g', 39, null);
						this.describeAColumn(table, '!idappello_appello_publicato', 'Publicato', null, 40, null);
//$objCalcFieldConfig_seg_child$
						break;
					case 'appello':
						this.describeAColumn(table, '!idattivform_didprog_title', 'Denominazione Didattica programmata', null, 36, null);
						this.describeAColumn(table, '!idattivform_didprog_annoaccademico_alias1_aa', 'Codice Anno Accademico', null, 35, null);
						this.describeAColumn(table, '!idattivform_didprog_sede_title', 'Denominazione Sedi', null, 36, null);
						this.describeAColumn(table, '!idattivform_insegn_denominazione', 'Denominazione Insegnamento', null, 42, null);
						this.describeAColumn(table, '!idattivform_insegn_codice', 'Codice Insegnamento', null, 43, null);
						this.describeAColumn(table, '!idattivform_insegninteg_denominazione', 'Denominazione Integrando', null, 43, null);
						this.describeAColumn(table, '!idattivform_insegninteg_codice', 'Codice Integrando', null, 44, null);
						this.describeAColumn(table, '!idattivform_attivform_tipovalutaz', 'Profitto o Idoneità', null, 48, null);
						this.describeAColumn(table, '!idattivform_sede_title', 'Sede', null, 54, null);
						objCalcFieldConfig['!idattivform_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_didprog_annoaccademico_alias1_aa'] = { tableNameLookup:'annoaccademico_alias1', columnNameLookup:'aa', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_didprog_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_insegninteg_denominazione'] = { tableNameLookup:'insegninteg', columnNameLookup:'denominazione', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_insegninteg_codice'] = { tableNameLookup:'insegninteg', columnNameLookup:'codice', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_attivform_tipovalutaz'] = { tableNameLookup:'attivform', columnNameLookup:'tipovalutaz', columnNamekey:'idattivform' };
						objCalcFieldConfig['!idattivform_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'idattivform' };
						this.describeAColumn(table, '!idattivform_didprog_annoaccademico_alias1_aa', 'Anno accademico Anno Accademico', null, 35, null);
//$objCalcFieldConfig_appello$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_appelloattivform");

				//$getNewRowInside$


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

    window.appMeta.addMeta('appelloattivform', new meta_appelloattivform('appelloattivform'));

	}());
