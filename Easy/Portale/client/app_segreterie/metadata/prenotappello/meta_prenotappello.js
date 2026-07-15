(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_prenotappello() {
        MetaData.apply(this, ["prenotappello"]);
        this.name = 'meta_prenotappello';
    }

    meta_prenotappello.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_prenotappello,
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
					case 'appello':
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Corso Iscrizione', null, 21, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione', null, 22, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_idsede', 'Sede Iscrizione', null, 23, null);
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione' };
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Denominazione Iscrizione', null, 21, null);
//$objCalcFieldConfig_appello$
						break;
					case 'doc':
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Corso Iscrizione', null, 21, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione', null, 22, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_idsede', 'Sede Iscrizione', null, 23, null);
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione' };
						this.describeAColumn(table, '!idreg_registry_title', 'Studente', null, 11, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg' };
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Denominazione Iscrizione', null, 21, null);
//$objCalcFieldConfig_doc$
						break;
					case 'stupiano':
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_stupiano$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'doc':
						table.columns["idappello"].caption = "Appello";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idpianostudio"].caption = "Piano di studi";
						table.columns["idpianostudioattivform"].caption = "Studente e attività formativa del suo piano di studi";
						table.columns["idprova"].caption = "Prova";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_doc$
						break;
					case 'appello':
						table.columns["idpianostudioattivform"].caption = "attività formativa del piano di studi";
//$innerSetCaptionConfig_appello$
						break;
					case 'stupiano':
//$innerSetCaptionConfig_stupiano$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_prenotappello");

				//$getNewRowInside$

				dt.autoIncrement('idprenotappello', { minimum: 99990001 });

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
					case "appello": {
						return "idreg asc ";
					}
					case "stupiano": {
						return "idreg asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('prenotappello', new meta_prenotappello('prenotappello'));

	}());
