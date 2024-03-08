(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_convalidante() {
        MetaData.apply(this, ["convalidante"]);
        this.name = 'meta_convalidante';
    }

    meta_convalidante.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_convalidante,
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
					case 'segmi':
						this.describeAColumn(table, 'changes', 'Changes', null, 20, null);
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, 'idiscrizionebmi', 'Iscrizione al bando di mobilit? internazionale', null, 100, null);
//$objCalcFieldConfig_segmi$
						break;
					case 'segstudprat':
						this.describeAColumn(table, 'changes', 'Changes', null, 20, null);
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 41, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup:'changeskind', columnNameLookup:'title', columnNamekey:'idchangeskind' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 161, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 161, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_title', 'Title Progetto del tirocinio', null, 171, null);
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_description', 'Description Progetto del tirocinio', null, 172, null);
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_title'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'title', columnNamekey:'idtirocinioprogetto' };
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_description'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'description', columnNamekey:'idtirocinioprogetto' };
//$objCalcFieldConfig_segstudprat$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'changes', 'Changes', null, 20, null);
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 41, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup:'changeskind', columnNameLookup:'title', columnNamekey:'idchangeskind' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 161, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 161, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
//$objCalcFieldConfig_segistrein$
						break;
					case 'segistpass':
						this.describeAColumn(table, 'changes', 'Changes', null, 20, null);
						this.describeAColumn(table, 'changesother', 'Changes other', null, 30, -1);
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 41, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup:'changeskind', columnNameLookup:'title', columnNamekey:'idchangeskind' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 161, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 161, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_title', 'Title Progetto del tirocinio', null, 171, null);
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_description', 'Description Progetto del tirocinio', null, 172, null);
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_title'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'title', columnNamekey:'idtirocinioprogetto' };
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_description'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'description', columnNamekey:'idtirocinioprogetto' };
//$objCalcFieldConfig_segistpass$
						break;
					case 'segistabbr':
						this.describeAColumn(table, '!idchangeskind_changeskind_title', 'Changes kind', null, 41, null);
						objCalcFieldConfig['!idchangeskind_changeskind_title'] = { tableNameLookup:'changeskind', columnNameLookup:'title', columnNamekey:'idchangeskind' };
						this.describeAColumn(table, '!idsostenimento_sostenimento_voto', 'Voto Sostenimento', 'fixed.2', 162, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votosu', 'Su Sostenimento', null, 163, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_votolode', 'Lode Sostenimento', null, 164, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idattivform_title', 'Attività formativa Sostenimento', null, 161, null);
						this.describeAColumn(table, '!idsostenimento_sostenimento_idreg_title', 'Denominazione Sostenimento', null, 161, null);
						objCalcFieldConfig['!idsostenimento_sostenimento_voto'] = { tableNameLookup:'sostenimento', columnNameLookup:'voto', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votosu'] = { tableNameLookup:'sostenimento', columnNameLookup:'votosu', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_votolode'] = { tableNameLookup:'sostenimento', columnNameLookup:'votolode', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idattivform_title'] = { tableNameLookup:'attivform', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						objCalcFieldConfig['!idsostenimento_sostenimento_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idsostenimento' };
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_title', 'Title Progetto del tirocinio', null, 171, null);
						this.describeAColumn(table, '!idtirocinioprogetto_tirocinioprogetto_description', 'Description Progetto del tirocinio', null, 172, null);
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_title'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'title', columnNamekey:'idtirocinioprogetto' };
						objCalcFieldConfig['!idtirocinioprogetto_tirocinioprogetto_description'] = { tableNameLookup:'tirocinioprogetto', columnNameLookup:'description', columnNamekey:'idtirocinioprogetto' };
//$objCalcFieldConfig_segistabbr$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_convalidante");

				//$getNewRowInside$

				dt.autoIncrement('idconvalidante', { minimum: 99990001 });

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
					case "segstudprat": {
						return "idsostenimento desc";
					}
					case "segistrein": {
						return "idsostenimento desc";
					}
					case "segistpass": {
						return "idsostenimento desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('convalidante', new meta_convalidante('convalidante'));

	}());
