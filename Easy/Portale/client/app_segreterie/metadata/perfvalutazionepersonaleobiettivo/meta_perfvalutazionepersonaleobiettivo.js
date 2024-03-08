(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonaleobiettivo() {
        MetaData.apply(this, ["perfvalutazionepersonaleobiettivo"]);
        this.name = 'meta_perfvalutazionepersonaleobiettivo';
    }

    meta_perfvalutazionepersonaleobiettivo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaleobiettivo,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 60, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 70, null);
						this.describeAColumn(table, 'note', 'Note', null, 140, -1);
						this.describeAColumn(table, '!perfvalutazionepersonalesoglia', 'Soglie', null, 50, null);
//$objCalcFieldConfig_default$
						break;
					case 'tuscia':
						this.describeAColumn(table, 'title', 'Obiettivo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Indicatore', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 60, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 70, null);
						this.describeAColumn(table, 'note', 'Note', null, 140, -1);
						this.describeAColumn(table, '!perfvalutazionepersonalesoglia', 'Target', null, 50, null);
//$objCalcFieldConfig_tuscia$
						break;
					case 'conattivita':
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 60, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 70, null);
						this.describeAColumn(table, 'note', 'Note', null, 140, -1);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title', 'Titolo Attività collegata', null, 153, null);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogetto_title', 'Identificativo Attività collegata', null, 150, null);
						this.describeAColumn(table, '!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogettoobiettivo_title', 'Identificativo Attività collegata', null, 150, null);
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_title'] = { tableNameLookup:'perfprogettoobiettivoattivita', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogetto_title'] = { tableNameLookup:'perfprogetto', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						objCalcFieldConfig['!idperfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogettoobiettivo_title'] = { tableNameLookup:'perfprogettoobiettivo', columnNameLookup:'title', columnNamekey:'idperfprogettoobiettivoattivita' };
						this.describeAColumn(table, '!perfvalutazionepersonalesoglia', 'Soglie', null, 50, null);
//$objCalcFieldConfig_conattivita$
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
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Titolo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
//$innerSetCaptionConfig_default$
						break;
					case 'tuscia':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Indicatore";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Obiettivo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
//$innerSetCaptionConfig_tuscia$
						break;
					case 'conattivita':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Titolo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
						table.columns["idperfprogettoobiettivoattivita"].caption = "Attività collegata";
//$innerSetCaptionConfig_conattivita$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonaleobiettivo");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonaleobiettivo', { minimum: 99990001 });

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
						return "title asc ";
					}
					case "tuscia": {
						return "title asc ";
					}
					case "conattivita": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfvalutazionepersonaleobiettivo', new meta_perfvalutazionepersonaleobiettivo('perfvalutazionepersonaleobiettivo'));

	}());
