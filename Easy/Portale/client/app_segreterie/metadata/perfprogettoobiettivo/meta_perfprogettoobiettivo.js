(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivo() {
        MetaData.apply(this, ["perfprogettoobiettivo"]);
        this.name = 'meta_perfprogettoobiettivo';
    }

    meta_perfprogettoobiettivo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivo,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'peso', 'Peso per il progetto', 'fixed.2', 60, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 130, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Referente dell\'obiettivo', null, 21, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Referente dell\'obiettivo', null, 22, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Referente dell\'obiettivo', null, 23, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Referente dell\'obiettivo', null, 24, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi_alias1', columnNameLookup:'contratto', columnNamekey:'idreg' };
//$objCalcFieldConfig_default$
						break;
					case 'amministrativi':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, -1);
						this.describeAColumn(table, 'peso', 'Peso per il progetto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 100, null);
//$objCalcFieldConfig_amministrativi$
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
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["peso"].caption = "Peso per il progetto";
						table.columns["title"].caption = "Titolo";
						table.columns["idattach"].caption = "Relazione finale";
						table.columns["idreg"].caption = "Referente del progetto";
						table.columns["idreg"].caption = "Referente dell'obiettivo";
//$innerSetCaptionConfig_default$
						break;
					case 'amministrativi':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["idattach"].caption = "Relazione finale";
						table.columns["idreg"].caption = "Referente dell'obiettivo";
						table.columns["peso"].caption = "Peso per il progetto";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_amministrativi$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoobiettivo");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettoobiettivo', { minimum: 99990001 });

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
					case "default": {
						return "title desc";
					}
					case "amministrativi": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivo', new meta_perfprogettoobiettivo('perfprogettoobiettivo'));

	}());
