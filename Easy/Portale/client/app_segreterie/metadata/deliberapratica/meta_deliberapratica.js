(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_deliberapratica() {
        MetaData.apply(this, ["deliberapratica"]);
        this.name = 'meta_deliberapratica';
    }

    meta_deliberapratica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_deliberapratica,
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
					case 'seg':
						this.describeAColumn(table, '!idpratica_registry_alias1_title', 'Studente', null, 72, null);
						this.describeAColumn(table, '!idpratica_iscrizione_anno', 'Anno di corso Iscrizione', null, 73, null);
						this.describeAColumn(table, '!idpratica_iscrizione_didprog_title', 'Denominazione Didattiche programmate', null, 73, null);
						this.describeAColumn(table, '!idpratica_iscrizione_didprog_aa', 'Anno accademico Didattiche programmate', null, 74, null);
						this.describeAColumn(table, '!idpratica_iscrizione_didprog_idsede', 'Sede Didattiche programmate', null, 75, null);
						this.describeAColumn(table, '!idpratica_iscrizione_annoaccademico_aa', 'Codice Anno Accademico', null, 72, null);
						this.describeAColumn(table, '!idpratica_istanzakind_title', 'Tipologia di istanza', null, 89, null);
						this.describeAColumn(table, '!idpratica_statuskind_alias1_title', 'Stato', null, 90, null);
						this.describeAColumn(table, '!idpratica_pratica_protnumero', 'Numero di protocollo', null, 90, null);
						this.describeAColumn(table, '!idpratica_pratica_protanno', 'Anno di protocollo', null, 91, null);
						objCalcFieldConfig['!idpratica_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_iscrizione_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_iscrizione_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_iscrizione_didprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_iscrizione_annoaccademico_aa'] = { tableNameLookup:'annoaccademico', columnNameLookup:'aa', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_istanzakind_title'] = { tableNameLookup:'istanzakind', columnNameLookup:'title', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_statuskind_alias1_title'] = { tableNameLookup:'statuskind_alias1', columnNameLookup:'title', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_pratica_protnumero'] = { tableNameLookup:'pratica', columnNameLookup:'protnumero', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_pratica_protanno'] = { tableNameLookup:'pratica', columnNameLookup:'protanno', columnNamekey:'idpratica' };
						this.describeAColumn(table, '!idpratica_iscrizione_annoaccademico_aa', 'Anno accademico Anno Accademico', null, 72, null);
						this.describeAColumn(table, '!idpratica_iscrizione_annoaccademico_alias1_aa', 'Anno accademico Anno Accademico', null, 72, null);
						this.describeAColumn(table, '!idpratica_istanzakind_alias1_title', 'Tipologia di istanza', null, 89, null);
						this.describeAColumn(table, '!idpratica_statuskind_alias2_title', 'Stato', null, 90, null);
						objCalcFieldConfig['!idpratica_iscrizione_annoaccademico_alias1_aa'] = { tableNameLookup:'annoaccademico_alias1', columnNameLookup:'aa', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_istanzakind_alias1_title'] = { tableNameLookup:'istanzakind_alias1', columnNameLookup:'title', columnNamekey:'idpratica' };
						objCalcFieldConfig['!idpratica_statuskind_alias2_title'] = { tableNameLookup:'statuskind_alias2', columnNameLookup:'title', columnNamekey:'idpratica' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_deliberapratica");

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

    window.appMeta.addMeta('deliberapratica', new meta_deliberapratica('deliberapratica'));

	}());
