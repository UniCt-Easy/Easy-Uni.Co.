(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pcsassunzionisimulate() {
        MetaData.apply(this, ["pcsassunzionisimulate"]);
        this.name = 'meta_pcsassunzionisimulate';
    }

    meta_pcsassunzionisimulate.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcsassunzionisimulate,
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
						this.describeAColumn(table, 'idposition_start', 'Qualifica/Categoria di partenza', null, 10, null);
						this.describeAColumn(table, 'idposition', 'Qualifica/Categoria', null, 20, null);
						this.describeAColumn(table, 'data', 'Data assunzione presunta', 'g', 30, null);
						this.describeAColumn(table, 'stipendio', 'Stipendio tabellare più basso', 'fixed.2', 40, null);
						this.describeAColumn(table, 'idsasd', 'SSD', null, 50, null);
						this.describeAColumn(table, 'nominativo', 'Nominativo', null, 60, 150);
						this.describeAColumn(table, 'idstruttura', 'Dipartimento', null, 70, null);
						this.describeAColumn(table, 'legge', 'Legge/Decreto', null, 80, 250);
						this.describeAColumn(table, 'finanziamento', 'Finanziamento', null, 90, 150);
						this.describeAColumn(table, 'percentuale', 'Indicare la percentuale di stipendio da considerare.', 'fixed.2', 100, null);
						this.describeAColumn(table, 'numeropersoneassunzione', 'Numero di persone su nuova assunzione', 'fixed.2', 110, null);
						this.describeAColumn(table, 'totale', 'Totale anno in analisi', 'fixed.2', 200, null);
						this.describeAColumn(table, 'totale1', 'Totale anno in analisi +1', 'fixed.2', 210, null);
						this.describeAColumn(table, 'totale2', 'Totale anno in analisi +2', 'fixed.2', 220, null);
						this.describeAColumn(table, 'totale3', 'Totale anno in analisi +3', 'fixed.2', 230, null);
						this.describeAColumn(table, '!idposition_position_title', 'Qualifica/Categoria', null, 21, null);
						objCalcFieldConfig['!idposition_position_title'] = { tableNameLookup:'position', columnNameLookup:'title', columnNamekey:'idposition' };
						this.describeAColumn(table, '!idposition_start_position_title', 'Qualifica/Categoria di partenza', null, 11, null);
						objCalcFieldConfig['!idposition_start_position_title'] = { tableNameLookup:'position_alias1', columnNameLookup:'title', columnNamekey:'idposition_start' };
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SSD', null, 51, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SSD', null, 52, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Dipartimento', null, 71, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipo Dipartimento', null, 70, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
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
						table.columns["data"].caption = "Data assunzione presunta";
						table.columns["finanziamento"].caption = "Finanziamento";
						table.columns["idposition"].caption = "Qualifica/Categoria";
						table.columns["idposition_start"].caption = "Qualifica/Categoria di partenza";
						table.columns["idsasd"].caption = "SSD";
						table.columns["idstruttura"].caption = "Dipartimento";
						table.columns["legge"].caption = "Legge/Decreto";
						table.columns["nominativo"].caption = "Nominativo";
						table.columns["numeropersoneassunzione"].caption = "Numero di persone su nuova assunzione";
						table.columns["percentuale"].caption = "Indicare la percentuale di stipendio da considerare.";
						table.columns["stipendio"].caption = "Stipendio tabellare più basso";
						table.columns["totale"].caption = "Totale anno in analisi";
						table.columns["totale1"].caption = "Totale anno in analisi +1";
						table.columns["totale2"].caption = "Totale anno in analisi +2";
						table.columns["totale3"].caption = "Totale anno in analisi +3";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pcsassunzionisimulate");

				//$getNewRowInside$

				dt.autoIncrement('idpcsassunzionisimulate', { minimum: 99990001 });

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
						return "year asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('pcsassunzionisimulate', new meta_pcsassunzionisimulate('pcsassunzionisimulate'));

	}());
