(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_learningagrstud() {
        MetaData.apply(this, ["learningagrstud"]);
        this.name = 'meta_learningagrstud';
    }

    meta_learningagrstud.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrstud,
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
						this.describeAColumn(table, 'note', 'Note', null, 80, -1);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 90, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 100, null);
						this.describeAColumn(table, 'department', 'Dipartimento estero', null, 150, 2048);
						this.describeAColumn(table, '!ideqf_eqf_level', 'Livello EQF', null, 161, null);
						objCalcFieldConfig['!ideqf_eqf_level'] = { tableNameLookup:'eqf', columnNameLookup:'level', columnNamekey:'ideqf' };
						this.describeAColumn(table, '!idlearningagrkind_learningagrkind_title', 'Tipologia di learning agreement', null, 51, null);
						objCalcFieldConfig['!idlearningagrkind_learningagrkind_title'] = { tableNameLookup:'learningagrkind', columnNameLookup:'title', columnNamekey:'idlearningagrkind' };
						this.describeAColumn(table, '!idmobilityperiodtype_mobilityperiodtype_title', 'Periodo', null, 181, null);
						objCalcFieldConfig['!idmobilityperiodtype_mobilityperiodtype_title'] = { tableNameLookup:'mobilityperiodtype', columnNameLookup:'title', columnNamekey:'idmobilityperiodtype' };
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title', 'Istituto', null, 71, null);
						objCalcFieldConfig['!idreg_istitutiesteri_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Dipartimento locale', null, 171, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipo Dipartimento locale', null, 170, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_seg$
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
						table.columns["department"].caption = "Dipartimento estero";
						table.columns["ideqf"].caption = "Livello EQF";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idlearningagrkind"].caption = "Tipologia di learning agreement";
						table.columns["idmobilityperiodtype"].caption = "Periodo";
						table.columns["idreg_istitutiesteri"].caption = "Istituto";
						table.columns["idstruttura"].caption = "Dipartimento locale";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_learningagrstud");

				//$getNewRowInside$

				dt.autoIncrement('idlearningagrstud', { minimum: 99990001 });

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

    window.appMeta.addMeta('learningagrstud', new meta_learningagrstud('learningagrstud'));

	}());
