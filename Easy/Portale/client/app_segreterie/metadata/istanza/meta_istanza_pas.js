(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_pas() {
        MetaData.apply(this, ["istanza_pas"]);
        this.name = 'meta_istanza_pas';
    }

    meta_istanza_pas.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_pas,
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
					case 'seganagstu':
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione di partenza', null, 511, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione di partenza', null, 513, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione di partenza', null, 511, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione di partenza', null, 512, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione di partenza', null, 513, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione_alias6', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione_alias6', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno_cognome', 'Cognome Iscrizione di partenza', null, 510, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno_inquadramento', 'Inquadramento Iscrizione di partenza', null, 510, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno_matricola', 'Matricola Iscrizione di partenza', null, 510, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno_nome', 'Nome Iscrizione di partenza', null, 510, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno_ruolo', 'Ruolo Iscrizione di partenza', null, 510, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno_cognome'] = { tableNameLookup:'importcontrattistipendiview', columnNameLookup:'cognome', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno_inquadramento'] = { tableNameLookup:'importcontrattistipendiview', columnNameLookup:'inquadramento', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno_matricola'] = { tableNameLookup:'importcontrattistipendiview', columnNameLookup:'matricola', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno_nome'] = { tableNameLookup:'importcontrattistipendiview', columnNameLookup:'nome', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno_ruolo'] = { tableNameLookup:'importcontrattistipendiview', columnNameLookup:'ruolo', columnNamekey:'idiscrizione_from' };
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_pas");

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

    window.appMeta.addMeta('istanza_pas', new meta_istanza_pas('istanza_pas'));

	}());
