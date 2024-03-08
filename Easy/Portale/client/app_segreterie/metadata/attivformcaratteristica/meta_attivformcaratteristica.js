(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_attivformcaratteristica() {
        MetaData.apply(this, ["attivformcaratteristica"]);
        this.name = 'meta_attivformcaratteristica';
    }

    meta_attivformcaratteristica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformcaratteristica,
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
						this.describeAColumn(table, 'cf', 'Crediti', 'fixed.2', 10, null);
						this.describeAColumn(table, 'profess', 'Professionalizzante', null, 60, null);
						this.describeAColumn(table, '!idambitoareadisc_ambitoareadisc_title', 'Ambito o area disciplinare', null, 31, null);
						objCalcFieldConfig['!idambitoareadisc_ambitoareadisc_title'] = { tableNameLookup:'ambitoareadisc', columnNameLookup:'title', columnNamekey:'idambitoareadisc' };
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SASD', null, 51, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SASD', null, 52, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
						this.describeAColumn(table, '!idsasdgruppo_sasdgruppo_title', 'Gruppo', null, 41, null);
						objCalcFieldConfig['!idsasdgruppo_sasdgruppo_title'] = { tableNameLookup:'sasdgruppo', columnNameLookup:'title', columnNamekey:'idsasdgruppo' };
						this.describeAColumn(table, '!idtipoattform_tipoattform_title', 'Tipo di attività formativa', null, 21, null);
						objCalcFieldConfig['!idtipoattform_tipoattform_title'] = { tableNameLookup:'tipoattform', columnNameLookup:'title', columnNamekey:'idtipoattform' };
						this.describeAColumn(table, '!attivformcaratteristicaora', 'Ore', null, 70, null);
//$objCalcFieldConfig_default$
						break;
					case 'erogata':
						this.describeAColumn(table, 'cf', 'Crediti', 'fixed.2', 10, null);
						this.describeAColumn(table, 'profess', 'Professionalizzante', null, 60, null);
						this.describeAColumn(table, '!idambitoareadisc_ambitoareadisc_title', 'Ambito o area disciplinare', null, 31, null);
						objCalcFieldConfig['!idambitoareadisc_ambitoareadisc_title'] = { tableNameLookup:'ambitoareadisc', columnNameLookup:'title', columnNamekey:'idambitoareadisc' };
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SASD', null, 51, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SASD', null, 52, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
						this.describeAColumn(table, '!idsasdgruppo_sasdgruppo_title', 'Gruppo', null, 41, null);
						objCalcFieldConfig['!idsasdgruppo_sasdgruppo_title'] = { tableNameLookup:'sasdgruppo', columnNameLookup:'title', columnNamekey:'idsasdgruppo' };
						this.describeAColumn(table, '!idtipoattform_tipoattform_title', 'Tipo di attività formativa', null, 21, null);
						objCalcFieldConfig['!idtipoattform_tipoattform_title'] = { tableNameLookup:'tipoattform', columnNameLookup:'title', columnNamekey:'idtipoattform' };
						this.describeAColumn(table, '!attivformcaratteristicaora', 'Ore', null, 70, null);
//$objCalcFieldConfig_erogata$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'erogata':
						table.columns["cf"].caption = "Crediti";
						table.columns["idambitoareadisc"].caption = "Ambito o area disciplinare";
						table.columns["idsasd"].caption = "SASD";
						table.columns["idsasdgruppo"].caption = "Gruppo";
						table.columns["idtipoattform"].caption = "Tipo di attività formativa";
						table.columns["json"].caption = "Caratteristiche";
						table.columns["profess"].caption = "Professionalizzante";
						table.columns["title"].caption = "Caratteristiche";
//$innerSetCaptionConfig_erogata$
						break;
					case 'default':
						table.columns["cf"].caption = "Crediti";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_attivformcaratteristica");

				//$getNewRowInside$

				dt.autoIncrement('idattivformcaratteristica', { minimum: 99990001 });

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
						return "idtipoattform desc, idambitoareadisc desc, idsasdgruppo desc, idsasd desc";
					}
					case "erogata": {
						return "title desc, idtipoattform desc, idambitoareadisc desc, idsasdgruppo desc, idsasd desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('attivformcaratteristica', new meta_attivformcaratteristica('attivformcaratteristica'));

	}());
