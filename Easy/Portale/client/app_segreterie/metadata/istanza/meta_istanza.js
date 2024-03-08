(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza() {
        MetaData.apply(this, ["istanza"]);
        this.name = 'meta_istanza';
    }

    meta_istanza.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza,
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
					case 'seganagstusonpre':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Status', null, 81, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind_alias1', columnNameLookup:'title', columnNamekey:'idstatuskind' };
//$objCalcFieldConfig_seganagstusonpre$
						break;
					case 'cert_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_cert_seg$
						break;
					case 'sosp_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_sosp_seg$
						break;
					case 'rin_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 130, null);
//$objCalcFieldConfig_rin_seg$
						break;
					case 'tru_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 130, null);
//$objCalcFieldConfig_tru_seg$
						break;
					case 'eq_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 130, null);
//$objCalcFieldConfig_eq_seg$
						break;
					case 'pas_seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Status', null, 81, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind_alias3', columnNameLookup:'title', columnNamekey:'idstatuskind' };
//$objCalcFieldConfig_pas_seganagstu$
						break;
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 21, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 22, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Denominazione Didattica programmata', null, 21, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Status', null, 81, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias7', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias7', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind_alias2', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Sede Didattica programmata', null, 20, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
					case 'imm_segrin':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 620, null);
//$objCalcFieldConfig_imm_segrin$
						break;
					case 'imm_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 620, null);
//$objCalcFieldConfig_imm_seg$
						break;
					case 'imm_seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 21, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 22, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Denominazione Didattica programmata', null, 21, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Status', null, 81, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias6', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias6', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind_alias1', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Sede Didattica programmata', null, 20, null);
//$objCalcFieldConfig_imm_seganagstu$
						break;
					case 'imm_segpre':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 620, null);
//$objCalcFieldConfig_imm_segpre$
						break;
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 110, null);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 21, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 22, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Denominazione Didattica programmata', null, 21, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Status', null, 81, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog_alias5', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog_alias5', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Sede Didattica programmata', null, 20, null);
//$objCalcFieldConfig_imm_seganagstupre$
						break;
					case 'rein_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 620, null);
//$objCalcFieldConfig_rein_seg$
						break;
					case 'rein_seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 620, null);
//$objCalcFieldConfig_rein_seganagstu$
						break;
					case 'rimb_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_rimb_seg$
						break;
					case 'conseg_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_conseg_seg$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_seg$
						break;
					case 'segstudelenco':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segstudelenco$
						break;
					case 'segstuelenco':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_segstuelenco$
						break;
					case 'pas_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_pas_seg$
						break;
					case 'abbr_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_abbr_seg$
						break;
					case 'tri_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
//$objCalcFieldConfig_tri_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'pas_seganagstu':
						table.columns["iddidprog"].caption = "Didattica di destinazione";
//$innerSetCaptionConfig_pas_seganagstu$
						break;
					case 'eq_seg':
						table.columns["iddidprog"].caption = "Corso equipollente";
//$innerSetCaptionConfig_eq_seg$
						break;
					case 'rimb_seg':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["extension"].caption = "Tabella che estende il record";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idistanzakind"].caption = "Tipologia";
						table.columns["idreg_studenti"].caption = "Studente";
						table.columns["idstatuskind"].caption = "Status";
						table.columns["paridistanza"].caption = "Istanza collegata";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_rimb_seg$
						break;
					case 'conseg_seg':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_conseg_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza");

				//$getNewRowInside$

				dt.autoIncrement('idistanza', { minimum: 99990001 });

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

    window.appMeta.addMeta('istanza', new meta_istanza('istanza'));

	}());
