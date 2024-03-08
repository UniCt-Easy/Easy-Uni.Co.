(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryclass() {
        MetaData.apply(this, ["registryclass"]);
        this.name = 'meta_registryclass';
    }

    meta_registryclass.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryclass,
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
					case 'aziende':
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_aziende$
						break;
					case 'persone':
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_persone$
						break;
					case 'default':
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'flagbadgecode', 'Codice badge visibile', null, 40, null);
						this.describeAColumn(table, 'flagbadgecode_forced', 'Codice badge obbligatorio', null, 50, null);
						this.describeAColumn(table, 'flagCF', 'Codice fiscale visibile', null, 60, null);
						this.describeAColumn(table, 'flagcf_forced', 'Codice fiscale obbligatorio', null, 70, null);
						this.describeAColumn(table, 'flagcfbutton', 'Bottone \"calcola codice fiscale\" visibile', null, 80, null);
						this.describeAColumn(table, 'flagextmatricula', 'Matricola esterna visibile', null, 90, null);
						this.describeAColumn(table, 'flagextmatricula_forced', 'Matricola esterna obbligatoria', null, 100, null);
						this.describeAColumn(table, 'flagfiscalresidence', 'Campo residenza visibile', null, 110, null);
						this.describeAColumn(table, 'flagfiscalresidence_forced', 'inserimento residenza obbligatorio', null, 120, null);
						this.describeAColumn(table, 'flagforeigncf', 'Codice fiscale estero visibile', null, 130, null);
						this.describeAColumn(table, 'flagforeigncf_forced', 'Codice fiscale estero obbligatorio', null, 140, null);
						this.describeAColumn(table, 'flaghuman', 'Persona fisica', null, 150, null);
						this.describeAColumn(table, 'flaginfofromcfbutton', 'Bottone \"Comune, Data da C.F.\" visibile', null, 160, null);
						this.describeAColumn(table, 'flagmaritalstatus', 'Campo stato civile visibile', null, 170, null);
						this.describeAColumn(table, 'flagmaritalstatus_forced', 'Campo stato civile obbligatorio', null, 180, null);
						this.describeAColumn(table, 'flagmaritalsurname', 'Cognome acquisito visibile', null, 190, null);
						this.describeAColumn(table, 'flagmaritalsurname_forced', 'Cognome acquisito obbligatorio', null, 200, null);
						this.describeAColumn(table, 'flagothers', 'campo non usato', null, 210, null);
						this.describeAColumn(table, 'flagothers_forced', 'campo non usato', null, 220, null);
						this.describeAColumn(table, 'flagp_iva', 'Partita iva visibile', null, 230, null);
						this.describeAColumn(table, 'flagp_iva_forced', 'Partita iva obbligatoria', null, 240, null);
						this.describeAColumn(table, 'flagqualification', 'campo \"Titolo\" visibile', null, 250, null);
						this.describeAColumn(table, 'flagqualification_forced', 'campo \"Titolo\" obbligatorio', null, 260, null);
						this.describeAColumn(table, 'flagresidence', 'Usato congiuntamente a flagresidence_forced per stabilire se l\'indirizzo di residenza ? obbligatorio, Da solo non ha un gran significato poich? non esiste un campo indirizzo di residenza', null, 270, null);
						this.describeAColumn(table, 'flagresidence_forced', 'Informazioni sulla residenza obbligatorie', null, 280, null);
						this.describeAColumn(table, 'flagtitle', 'Campo Denominazione diverso da cognome+nome, inserito manualmente', null, 290, null);
						this.describeAColumn(table, 'flagtitle_forced', 'Non usato, il campo denominazione  ? sempre obbligatorio in un modo o nell\'altro', null, 300, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_registryclass");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registryclass', new meta_registryclass('registryclass'));

	}());
