(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettouomembro() {
        MetaData.apply(this, ["perfprogettouomembro"]);
        this.name = 'meta_perfprogettouomembro';
    }

    meta_perfprogettouomembro.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettouomembro,
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
						this.describeAColumn(table, 'idreg', 'Membro', null, 10, null);
						this.describeAColumn(table, 'idafferenza', 'Afferenza', null, 20, null);
						this.describeAColumn(table, 'agile', 'Lavoro agile', null, 30, null);
						this.describeAColumn(table, '!idafferenza_afferenza_start', 'Dal Afferenza', 'g', 22, null);
						this.describeAColumn(table, '!idafferenza_afferenza_stop', 'Al Afferenza', 'g', 23, null);
						this.describeAColumn(table, '!idafferenza_afferenza_idstruttura_title', 'Denominazione Afferenza', null, 21, null);
						this.describeAColumn(table, '!idafferenza_afferenza_idstruttura_paridstruttura', 'U.O. madre Afferenza', null, 22, null);
						this.describeAColumn(table, '!idafferenza_afferenza_idmansionekind_title', 'Mansione Afferenza', null, 20, null);
						objCalcFieldConfig['!idafferenza_afferenza_start'] = { tableNameLookup:'afferenza', columnNameLookup:'start', columnNamekey:'idafferenza' };
						objCalcFieldConfig['!idafferenza_afferenza_stop'] = { tableNameLookup:'afferenza', columnNameLookup:'stop', columnNamekey:'idafferenza' };
						objCalcFieldConfig['!idafferenza_afferenza_idstruttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idafferenza' };
						objCalcFieldConfig['!idafferenza_afferenza_idstruttura_paridstruttura'] = { tableNameLookup:'struttura', columnNameLookup:'paridstruttura', columnNamekey:'idafferenza' };
						objCalcFieldConfig['!idafferenza_afferenza_idmansionekind_title'] = { tableNameLookup:'mansionekind', columnNameLookup:'title', columnNamekey:'idafferenza' };
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome', null, 12, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome', null, 14, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
//$objCalcFieldConfig_default$
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
						table.columns["agile"].caption = "Lavoro agile";
						table.columns["idafferenza"].caption = "Afferenza";
						table.columns["idreg"].caption = "Membro";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettouomembro");

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

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "idreg_amministrativi asc ";
					}
					case "default": {
						return "idreg asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfprogettouomembro', new meta_perfprogettouomembro('perfprogettouomembro'));

	}());
