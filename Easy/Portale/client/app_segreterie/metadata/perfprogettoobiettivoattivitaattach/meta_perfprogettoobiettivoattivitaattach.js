(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivoattivitaattach() {
        MetaData.apply(this, ["perfprogettoobiettivoattivitaattach"]);
        this.name = 'meta_perfprogettoobiettivoattivitaattach';
    }

    meta_perfprogettoobiettivoattivitaattach.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivoattivitaattach,
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
						this.describeAColumn(table, 'data', 'Data Inserimento', 'g', 90, null);
						this.describeAColumn(table, '!idattach_attach_filename', 'Allegato', 'skipNChar.40', 10, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
//$objCalcFieldConfig_default$
						break;
					case 'perfprog':
						this.describeAColumn(table, 'data', 'Data Inserimento', 'g', 90, null);
						this.describeAColumn(table, '!idattach_attach_filename', 'Allegato', 'skipNChar.40', 30, null);
						objCalcFieldConfig['!idattach_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach' };
						this.describeAColumn(table, '!idperfprogettoobiettivo_perfprogettoobiettivo_title', 'Obiettivo', null, 11, null);
						objCalcFieldConfig['!idperfprogettoobiettivo_perfprogettoobiettivo_title'] = { tableNameLookup:'perfprogettoobiettivo_alias2', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivo' };
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title', 'Titolo Attività', null, 21, null);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datainizioprevista', 'Data inizio prevista Attività', 'g', 22, null);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datafineprevista', 'Data fine prevista Attività', 'g', 23, null);
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias2', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datainizioprevista'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias2', columnNameLookup:'datainizioprevista', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datafineprevista'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias2', columnNameLookup:'datafineprevista', columnNamekey:'idperfprogettoobiettivoattivita' };
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title', 'Titolo Attività', null, 23, null);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogetto_title', 'Identificativo Attività', null, 20, null);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogettoobiettivo_title', 'Identificativo Attività', null, 20, null);
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogetto_title'] = { tableNameLookup:'perfprogetto', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogettoobiettivo_title'] = { tableNameLookup:'perfprogettoobiettivo', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivo_perfprogettoobiettivo_title'] = { tableNameLookup:'perfprogettoobiettivo_alias3', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivo' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias4', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datainizioprevista'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias4', columnNameLookup:'datainizioprevista', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_datafineprevista'] = { tableNameLookup:'perfprogettoobiettivoattivita_alias4', columnNameLookup:'datafineprevista', columnNamekey:'idperfprogettoobiettivoattivita' };
						this.describeAColumn(table, '!idattach_attach_filename', 'Allegato', null, 30, null);
//$objCalcFieldConfig_perfprog$
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
						table.columns["idattach"].caption = "Allegato";
						table.columns["data"].caption = "Data Inserimento";
//$innerSetCaptionConfig_default$
						break;
					case 'perfprog':
						table.columns["ct"].caption = "Data";
						table.columns["data"].caption = "Data Inserimento";
						table.columns["idattach"].caption = "Allegato";
						table.columns["idperfprogettoobiettivo"].caption = "Obiettivo";
						table.columns["idperfprogettoobiettivoattivita"].caption = "Attività";
//$innerSetCaptionConfig_perfprog$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettoobiettivoattivitaattach");

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

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivoattivitaattach', new meta_perfprogettoobiettivoattivitaattach('perfprogettoobiettivoattivitaattach'));

	}());
