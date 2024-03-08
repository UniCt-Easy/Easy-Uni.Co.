(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_workpackage() {
        MetaData.apply(this, ["workpackage"]);
        this.name = 'meta_workpackage';
    }

    meta_workpackage.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_workpackage,
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
						this.describeAColumn(table, '!importattivita', 'Importa attività', null, 0, null);
						this.describeAColumn(table, '!titolobreve', 'Progetto', null, 0, null);
						this.describeAColumn(table, 'raggruppamento', 'Raggruppamento', null, 10, 2048);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'acronimo', 'Acronimo', null, 30, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 100, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 110, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Dipartimento', null, 51, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipo Dipartimento', null, 50, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_seg$
						break;
					case 'elenchi':
						this.describeAColumn(table, '!importattivita', 'Importa attività', null, 0, null);
						this.describeAColumn(table, 'raggruppamento', 'Raggruppamento', null, 10, 2048);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'acronimo', 'Acronimo', null, 30, 2048);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 100, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 110, null);
//$objCalcFieldConfig_elenchi$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["description"].caption = "Descrizione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idstruttura"].caption = "Dipartimento";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
						table.columns["title"].caption = "Titolo";
						table.columns["!titolobreve"].caption = "Progetto";
//$innerSetCaptionConfig_seg$
						break;
					case 'elenchi':
						table.columns["description"].caption = "Descrizione";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idstruttura"].caption = "Dipartimento";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_elenchi$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_workpackage");

				//$getNewRowInside$

				dt.autoIncrement('idworkpackage', { minimum: 99990001 });

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
					case "seg": {
						return "raggruppamento asc , title asc ";
					}
					case "elenchi": {
						return "raggruppamento asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('workpackage', new meta_workpackage('workpackage'));

	}());
