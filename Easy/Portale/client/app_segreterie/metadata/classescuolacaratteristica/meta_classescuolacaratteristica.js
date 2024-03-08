(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classescuolacaratteristica() {
        MetaData.apply(this, ["classescuolacaratteristica"]);
        this.name = 'meta_classescuolacaratteristica';
    }

    meta_classescuolacaratteristica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classescuolacaratteristica,
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
					case 'classe':
						this.describeAColumn(table, 'cf', 'Crediti', 'fixed.2', 60, null);
						this.describeAColumn(table, 'cfmin', 'Crediti min', 'fixed.2', 60, null);
						this.describeAColumn(table, 'cfmax', 'Crediti max', 'fixed.2', 70, null);
						this.describeAColumn(table, 'obblig', 'Obbligatorio', null, 80, null);
						this.describeAColumn(table, 'profess', 'Professionalizzante', null, 90, null);
						this.describeAColumn(table, '!idambitoareadisc_ambitoareadisc_title', 'Ambito o area disciplinare', null, 31, null);
						objCalcFieldConfig['!idambitoareadisc_ambitoareadisc_title'] = { tableNameLookup:'ambitoareadisc', columnNameLookup:'title', columnNamekey:'idambitoareadisc' };
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SASD', null, 51, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SASD', null, 52, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
						this.describeAColumn(table, '!idsasdgruppo_sasdgruppo_title', 'Gruppo', null, 41, null);
						objCalcFieldConfig['!idsasdgruppo_sasdgruppo_title'] = { tableNameLookup:'sasdgruppo', columnNameLookup:'title', columnNamekey:'idsasdgruppo' };
						this.describeAColumn(table, '!idtipoattform_tipoattform_title', 'Tipo di attività formativa', null, 11, null);
						objCalcFieldConfig['!idtipoattform_tipoattform_title'] = { tableNameLookup:'tipoattform', columnNameLookup:'title', columnNamekey:'idtipoattform' };
						this.describeAColumn(table, '!idtipoattform_2_tipoattform_title', 'Tipo della seconda attività formativa', null, 21, null);
						objCalcFieldConfig['!idtipoattform_2_tipoattform_title'] = { tableNameLookup:'tipoattform_alias1', columnNameLookup:'title', columnNamekey:'idtipoattform_2' };
//$objCalcFieldConfig_classe$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'classe':
						table.columns["cf"].caption = "Crediti";
						table.columns["cfmax"].caption = "Crediti max";
						table.columns["cfmin"].caption = "Crediti min";
						table.columns["idambitoareadisc"].caption = "Ambito o area disciplinare";
						table.columns["idsasd"].caption = "SASD";
						table.columns["idsasdgruppo"].caption = "Gruppo";
						table.columns["idtipoattform"].caption = "Tipo di attività formativa";
						table.columns["idtipoattform_2"].caption = "Tipo della seconda attività formativa";
						table.columns["obblig"].caption = "Obbligatorio";
						table.columns["profess"].caption = "Professionalizzante";
//$innerSetCaptionConfig_classe$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_classescuolacaratteristica");

				//$getNewRowInside$

				dt.autoIncrement('idclassescuolacaratteristica', { minimum: 99990001 });

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
					case "classe": {
						return "idtipoattform asc , idambitoareadisc asc , idsasd asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('classescuolacaratteristica', new meta_classescuolacaratteristica('classescuolacaratteristica'));

	}());
