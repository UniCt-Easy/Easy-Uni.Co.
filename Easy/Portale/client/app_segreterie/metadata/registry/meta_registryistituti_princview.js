(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryistituti_princview() {
        MetaData.apply(this, ["registryistituti_princview"]);
        this.name = 'meta_registryistituti_princview';
    }

    meta_registryistituti_princview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryistituti_princview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'istituti_princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 101);
						this.describeAColumn(table, 'registry_istituti_codicemiur', 'Codice MIUR', null, 1000, 50);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 2000, null);
						this.describeAColumn(table, 'registry_istituti_codiceustat', 'Codice USTAT', null, 2000, 50);
						this.describeAColumn(table, 'registry_annotation', 'Annotazioni', null, 3000, 400);
						this.describeAColumn(table, 'registry_istituti_comune', 'Comune', null, 3000, 64);
						this.describeAColumn(table, 'registry_authorization_free', 'Esente ai fini dell\'autorizzazione EQUITALIA. (S/N)', null, 4000, null);
						this.describeAColumn(table, 'istitutokind_tipoistituto', 'Tipologia', null, 4200, 256);
						this.describeAColumn(table, 'registry_badgecode', 'Codice badge', null, 5000, 20);
						this.describeAColumn(table, 'registry_istituti_idistitutoustat', 'Codice USTAT', null, 5000, null);
						this.describeAColumn(table, 'registry_birthdate', 'Data di nascita', null, 6000, null);
						this.describeAColumn(table, 'registry_ccp', 'Conto corrente postale di Riscossione', null, 7000, 12);
						this.describeAColumn(table, 'registry_istituti_nome', 'Denominazione breve', null, 7000, null);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 8000, 16);
						this.describeAColumn(table, 'registry_istituti_sortcode', 'Sortcode', null, 8000, null);
						this.describeAColumn(table, 'registry_email_fe', 'Email_fe', null, 9000, 200);
						this.describeAColumn(table, 'registry_istituti_title_en', 'Denominazione (ENG)', null, 9000, 256);
						this.describeAColumn(table, 'registry_extmatricula', 'Matricola', null, 11000, 40);
						this.describeAColumn(table, 'registry_flag_pa', 'Applica lo split payment  (per le fatture di vendita)', null, 12000, null);
						this.describeAColumn(table, 'registry_flagbankitaliaproceeds', 'Regolarizzazione Riscossioni presso  T.P.S. - Banca d\'Italia', null, 13000, null);
						this.describeAColumn(table, 'registry_foreigncf', 'Codice fiscale estero', null, 14000, 40);
						this.describeAColumn(table, 'registry_forename', 'Nome', null, 15000, 50);
						this.describeAColumn(table, 'registry_gender', 'Sesso (M/F)', null, 16000, null);
						this.describeAColumn(table, 'accmotive_codemotive', 'Codice ID Causale per i crediti (tabella accmotive)', null, 17100, 50);
						this.describeAColumn(table, 'accmotive_title', 'Denominazione ID Causale per i crediti (tabella accmotive)', null, 17200, 150);
						this.describeAColumn(table, 'accmotive_registry_codemotive', 'Codice Id della causale di debito (tabella accmotive) ', null, 18100, 50);
						this.describeAColumn(table, 'accmotive_registry_title', 'Denominazione Id della causale di debito (tabella accmotive) ', null, 18200, 150);
						this.describeAColumn(table, 'category_description', 'ID Categoria (tabella category)', null, 19200, 50);
						this.describeAColumn(table, 'centralizedcategory_description', 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)', null, 20200, 50);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 21100, 65);
						this.describeAColumn(table, 'registry_idexternal', 'Id chiave in altri database, usato in migrazioni o simili', null, 22000, null);
						this.describeAColumn(table, 'maritalstatus_description', 'ID Stato civile (tabella maritalstatus)', null, 23200, 50);
						this.describeAColumn(table, 'geo_nation_title', 'Id nazione (tabella geo_nation)', null, 24300, 65);
						this.describeAColumn(table, 'registryclass_description', 'ID Tipologie classificazione (tabella registryclass)', null, 26200, 150);
						this.describeAColumn(table, 'registrykind_description', 'ID Classificazione Anagrafica (tabella registrykind)', null, 27200, 50);
						this.describeAColumn(table, 'title_description', 'ID Titolo (tabella title)', null, 28200, 50);
						this.describeAColumn(table, 'registry_ipa_fe', 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.', null, 29000, 7);
						this.describeAColumn(table, 'registry_location', 'ubicazione', null, 30000, 50);
						this.describeAColumn(table, 'registry_maritalsurname', 'Cognome acquisito', null, 31000, 50);
						this.describeAColumn(table, 'registry_multi_cf', 'Consenti duplicazione CF/P. IVA (S/N)', null, 32000, null);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 33000, 15);
						this.describeAColumn(table, 'registry_pec_fe', 'Pec_fe', null, 34000, 200);
						this.describeAColumn(table, 'residence_description', 'Tipo residenza (chiave di tabella residence)', null, 35200, 60);
						this.describeAColumn(table, 'registry_rtf', 'allegati', null, 36000, null);
						this.describeAColumn(table, 'registry_sdi_defrifamm', 'Rif.Amministrazione di default per fattura elettronica', null, 37000, 20);
						this.describeAColumn(table, 'registry_sdi_norifamm', 'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica', null, 38000, null);
						this.describeAColumn(table, 'registry_surname', 'Cognome', null, 39000, 50);
						this.describeAColumn(table, 'registry_toredirect', 'E\' stato usato in qualche migrazione', null, 40000, null);
						this.describeAColumn(table, 'registry_txt', 'note testuali', null, 41000, null);
						this.describeAColumn(table, 'registry_ipa_perlapa', 'Ipa_perlapa', null, 46000, 100);
//$objCalcFieldConfig_istituti_princ$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "istituti_princ": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryistituti_princview', new meta_registryistituti_princview('registryistituti_princview'));

	}());
