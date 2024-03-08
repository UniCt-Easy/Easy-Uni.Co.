(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneateneores() {
        MetaData.apply(this, ["perfvalutazioneateneores"]);
        this.name = 'meta_perfvalutazioneateneores';
    }

    meta_perfvalutazioneateneores.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneateneores,
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
					case 'default':
						this.describeAColumn(table, 'indicatore', 'Indicatore', null, 40, 1024);
						this.describeAColumn(table, 'target', 'Target', null, 50, 1024);
						this.describeAColumn(table, 'valoreraggiunto', 'Valore raggiunto', null, 60, 1024);
						this.describeAColumn(table, 'percentualeraggiunta', 'Percentuale raggiunta', 'fixed.2', 70, null);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 100, null);
						this.describeAColumn(table, 'fonte', 'Fonte', null, 110, 1024);
						this.describeAColumn(table, 'Note', 'Note', null, 170, -1);
						this.describeAColumn(table, '!idperfmission_perfmission_title', 'Missione istituzionale', null, 11, null);
						objCalcFieldConfig['!idperfmission_perfmission_title'] = { tableNameLookup:'perfmission', columnNameLookup:'title', columnNamekey:'idperfmission' };
						this.describeAColumn(table, '!idreg_registry_title', 'Compilatore', null, 161, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
//$objCalcFieldConfig_default$
						break;
					case 'personale':
						this.describeAColumn(table, 'indicatore', 'Indicatore', null, 40, 1024);
						this.describeAColumn(table, 'target', 'Target', null, 50, 1024);
						this.describeAColumn(table, 'valoreraggiunto', 'Valore raggiunto', null, 60, 1024);
						this.describeAColumn(table, 'percentualeraggiunta', 'Percentuale raggiunta', 'fixed.2', 70, null);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 100, null);
						this.describeAColumn(table, 'fonte', 'Fonte', null, 110, 1024);
						this.describeAColumn(table, 'Note', 'Note', null, 170, -1);
//$objCalcFieldConfig_personale$
						break;
					case 'consoglie':
						this.describeAColumn(table, 'indicatore', 'Indicatore', null, 40, 1024);
						this.describeAColumn(table, 'valoreraggiunto', 'Valore raggiunto', null, 60, 1024);
						this.describeAColumn(table, 'percentualeraggiunta', 'Percentuale raggiunta', 'fixed.2', 70, null);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 100, null);
						this.describeAColumn(table, 'fonte', 'Fonte', null, 110, 1024);
						this.describeAColumn(table, 'Note', 'Note', null, 170, -1);
						this.describeAColumn(table, '!idperfmission_perfmission_title', 'Missione istituzionale', null, 11, null);
						objCalcFieldConfig['!idperfmission_perfmission_title'] = { tableNameLookup:'perfmission', columnNameLookup:'title', columnNamekey:'idperfmission' };
						this.describeAColumn(table, '!idreg_getdocentiamministrativiresponsabili_surname', 'Cognome Compilatore', null, 162, null);
						this.describeAColumn(table, '!idreg_getdocentiamministrativiresponsabili_forename', 'Nome Compilatore', null, 163, null);
						this.describeAColumn(table, '!idreg_getdocentiamministrativiresponsabili_extmatricula', 'Matr. Compilatore', null, 164, null);
						this.describeAColumn(table, '!idreg_getdocentiamministrativiresponsabili_ruolo', 'Ruolo Compilatore', null, 165, null);
						this.describeAColumn(table, '!idreg_getdocentiamministrativiresponsabili_struttura', 'U.O. Compilatore', null, 166, null);
						this.describeAColumn(table, '!idreg_getdocentiamministrativiresponsabili_contratto', 'Contr. Compilatore', null, 167, null);
						objCalcFieldConfig['!idreg_getdocentiamministrativiresponsabili_surname'] = { tableNameLookup:'getdocentiamministrativiresponsabili', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getdocentiamministrativiresponsabili_forename'] = { tableNameLookup:'getdocentiamministrativiresponsabili', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getdocentiamministrativiresponsabili_extmatricula'] = { tableNameLookup:'getdocentiamministrativiresponsabili', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getdocentiamministrativiresponsabili_ruolo'] = { tableNameLookup:'getdocentiamministrativiresponsabili', columnNameLookup:'ruolo', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getdocentiamministrativiresponsabili_struttura'] = { tableNameLookup:'getdocentiamministrativiresponsabili', columnNameLookup:'struttura', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getdocentiamministrativiresponsabili_contratto'] = { tableNameLookup:'getdocentiamministrativiresponsabili', columnNameLookup:'contratto', columnNamekey:'idreg' };
//$objCalcFieldConfig_consoglie$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["fonte"].caption = "Fonte";
						table.columns["idperfmission"].caption = "Missione istituzionale";
						table.columns["indicatore"].caption = "Indicatore";
						table.columns["percentualeraggiunta"].caption = "Percentuale raggiunta";
						table.columns["peso"].caption = "Peso";
						table.columns["target"].caption = "Target";
						table.columns["valoreraggiunto"].caption = "Valore raggiunto";
						table.columns["idreg"].caption = "Compilatore";
//$innerSetCaptionConfig_default$
						break;
					case 'personale':
						table.columns["fonte"].caption = "Fonte";
						table.columns["idperfmission"].caption = "Missione istituzionale";
						table.columns["idreg"].caption = "Compilatore";
						table.columns["indicatore"].caption = "Indicatore";
						table.columns["percentualeraggiunta"].caption = "Percentuale raggiunta";
						table.columns["peso"].caption = "Peso";
						table.columns["target"].caption = "Target";
						table.columns["valoreraggiunto"].caption = "Valore raggiunto";
//$innerSetCaptionConfig_personale$
						break;
					case 'consoglie':
						table.columns["fonte"].caption = "Fonte";
						table.columns["idperfmission"].caption = "Missione istituzionale";
						table.columns["idreg"].caption = "Compilatore";
						table.columns["indicatore"].caption = "Indicatore";
						table.columns["percentualeraggiunta"].caption = "Percentuale raggiunta";
						table.columns["peso"].caption = "Peso";
						table.columns["target"].caption = "Target";
						table.columns["valoreraggiunto"].caption = "Valore raggiunto";
//$innerSetCaptionConfig_consoglie$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneateneores");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazioneateneores', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazioneateneores', new meta_perfvalutazioneateneores('perfvalutazioneateneores'));

	}());
