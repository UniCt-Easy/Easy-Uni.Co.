(function() {

    var MetaData = window.appMeta.MetaSegreterieData;
	var utils = appMeta.utils;
    function meta_registry() {
        MetaData.apply(this, ["registry"]);
        this.name = 'meta_registry';
    }

	meta_registry.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_registry,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'istituti_princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'active', 'attivo', null, 20, null);
						this.describeAColumn(table, 'annotation', 'Annotazioni', null, 30, 400);
						this.describeAColumn(table, 'authorization_free', 'Esente ai fini dell\'autorizzazione EQUITALIA. (S/N)', null, 40, null);
						this.describeAColumn(table, 'badgecode', 'Codice badge', null, 50, 20);
						this.describeAColumn(table, 'birthdate', 'Data di nascita', null, 60, null);
						this.describeAColumn(table, 'ccp', 'Conto corrente postale di Riscossione', null, 70, 12);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 80, 16);
						this.describeAColumn(table, 'email_fe', 'Email_fe', null, 90, 200);
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 110, 40);
						this.describeAColumn(table, 'flag_pa', 'Applica lo split payment  (per le fatture di vendita)', null, 120, null);
						this.describeAColumn(table, 'flagbankitaliaproceeds', 'Regolarizzazione Riscossioni presso  T.P.S. - Banca d\'Italia', null, 130, null);
						this.describeAColumn(table, 'foreigncf', 'Codice fiscale estero', null, 140, 40);
						this.describeAColumn(table, 'forename', 'Nome', null, 150, 50);
						this.describeAColumn(table, 'gender', 'Sesso (M/F)', null, 160, null);
						this.describeAColumn(table, 'idexternal', 'Id chiave in altri database, usato in migrazioni o simili', null, 220, null);
						this.describeAColumn(table, 'ipa_fe', 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.', null, 290, 7);
						this.describeAColumn(table, 'location', 'ubicazione', null, 300, 50);
						this.describeAColumn(table, 'maritalsurname', 'Cognome acquisito', null, 310, 50);
						this.describeAColumn(table, 'multi_cf', 'Consenti duplicazione CF/P. IVA (S/N)', null, 320, null);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 330, 15);
						this.describeAColumn(table, 'pec_fe', 'Pec_fe', null, 340, 200);
						this.describeAColumn(table, 'rtf', 'allegati', null, 360, null);
						this.describeAColumn(table, 'sdi_defrifamm', 'Rif.Amministrazione di default per fattura elettronica', null, 370, 20);
						this.describeAColumn(table, 'sdi_norifamm', 'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica', null, 380, null);
						this.describeAColumn(table, 'surname', 'Cognome', null, 390, 50);
						this.describeAColumn(table, 'toredirect', 'E\' stato usato in qualche migrazione', null, 400, null);
						this.describeAColumn(table, 'txt', 'note testuali', null, 410, null);
						this.describeAColumn(table, 'ipa_perlapa', 'Ipa_perlapa', null, 460, 100);
						//$objCalcFieldConfig_istituti_princ$
						break;
					case 'istituti':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						//$objCalcFieldConfig_istituti$
						break;
					case 'studenti':
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						//$objCalcFieldConfig_studenti$
						break;
					case 'amministrativi_personale':
						this.describeAColumn(table, 'surname', 'Cognome', null, 20, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 30, 50);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'badgecode', 'Codice bedge', null, 50, 20);
						this.describeAColumn(table, 'active', 'Attivo', null, 100, null);
//$objCalcFieldConfig_amministrativi_personale$
						break;
					case 'amministrativi':
						this.describeAColumn(table, 'surname', 'Cognome', null, 20, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 30, 50);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'badgecode', 'Codice badge', null, 50, 20);
						this.describeAColumn(table, 'active', 'Attivo', null, 100, null);
//$objCalcFieldConfig_amministrativi$
						break;
					case 'docenti_doc':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						//$objCalcFieldConfig_docenti_doc$
						break;
					case 'docenti':
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
//$objCalcFieldConfig_docenti$
						break;
					case 'user':
						this.describeAColumn(table, 'title', 'Nome e Cognome', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						//$objCalcFieldConfig_user$
						break;
					case 'aziende':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'pic', 'Participant Identification Code (PIC)', null, 120, 10);
						this.describeAColumn(table, 'flag_pa', 'Ente pubblico', null, 1000, null);
//$objCalcFieldConfig_aziende$
						break;
					case 'istitutiesteri':
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						//$objCalcFieldConfig_istitutiesteri$
						break;
					case 'default':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						//$objCalcFieldConfig_default$
						break;
					case 'docenti_docente':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
//$objCalcFieldConfig_docenti_docente$
						break;
					case 'aziende_ro':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'pic', 'Participant Identification Code (PIC)', null, 120, 10);
						this.describeAColumn(table, 'flag_pa', 'Ente pubblico', null, 1000, null);
//$objCalcFieldConfig_aziende_ro$
						break;
					case 'uncategorized':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 70, 40);
						//$objCalcFieldConfig_uncategorized$
						break;
					case 'persone':
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 10, 40);
						this.describeAColumn(table, 'title', 'Cognome Nome', null, 20, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 40, 15);
						//$objCalcFieldConfig_persone$
						break;
					case 'servizi':
						this.describeAColumn(table, 'surname', 'Cognome', null, 20, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 30, 50);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'badgecode', 'Codice badge', null, 50, 20);
						this.describeAColumn(table, 'active', 'Attivo', null, 100, null);
//$objCalcFieldConfig_servizi$
						break;
					case 'solotitle':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						//$objCalcFieldConfig_solotitle$
						break;
					case 'docenti_docentenoaltro':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'active', 'attivo', null, 60, null);
//$objCalcFieldConfig_docenti_docentenoaltro$
						break;
										case 'didattica':
						this.describeAColumn(table, '!datafine', 'Data fine', null, 0, null);
						this.describeAColumn(table, '!datainizio', 'Data inizio', null, 0, null);
						this.describeAColumn(table, '!importattivita', 'Importa attività didattica', null, 0, null);
						this.describeAColumn(table, 'surname', 'Cognome', null, 20, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 30, 50);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'badgecode', 'Codice badge', null, 50, 20);
						this.describeAColumn(table, 'active', 'Attivo', null, 100, null);
//$objCalcFieldConfig_didattica$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'istituti':
						table.columns["idcity"].caption = "Comune";
						table.columns["idregistryclass"].caption = "Tipologia";
						table.columns["location"].caption = "Località";
						table.columns["active"].caption = "attivo";
						table.columns["annotation"].caption = "Annotazioni";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["birthdate"].caption = "Data di nascita";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["foreigncf"].caption = "Codice fiscale estero";
						table.columns["forename"].caption = "Nome";
						table.columns["gender"].caption = "Sesso (M/F)";
						table.columns["idaccmotivecredit"].caption = "ID Causale per i crediti (tabella accmotive)";
						table.columns["idaccmotivedebit"].caption = "Id della causale di debito (tabella accmotive) ";
						table.columns["idcategory"].caption = "ID Categoria (tabella category)";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idmaritalstatus"].caption = "ID Stato civile (tabella maritalstatus)";
						table.columns["idnation"].caption = "Id nazione (tabella geo_nation)";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["idregistrykind"].caption = "ID Classificazione Anagrafica (tabella registrykind)";
						table.columns["idtitle"].caption = "ID Titolo (tabella title)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["p_iva"].caption = "Partita iva";
						table.columns["residence"].caption = "Tipo residenza (chiave di tabella residence)";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["surname"].caption = "Cognome";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						//$innerSetCaptionConfig_istituti$
						break;
					case 'studenti':
						table.columns["idcity"].caption = "Comune di nascita";
						table.columns["idmaritalstatus"].caption = "Stato civile";
						table.columns["idnation"].caption = "Nazionalità";
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia fiscale";
						table.columns["idtitle"].caption = "Titolo";
						table.columns["residence"].caption = "Residenza";
						table.columns["active"].caption = "attivo";
						table.columns["annotation"].caption = "Annotazioni";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["birthdate"].caption = "Data di nascita";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["foreigncf"].caption = "Codice fiscale estero";
						table.columns["forename"].caption = "Nome";
						table.columns["gender"].caption = "Sesso (M/F)";
						table.columns["idaccmotivecredit"].caption = "ID Causale per i crediti (tabella accmotive)";
						table.columns["idaccmotivedebit"].caption = "Id della causale di debito (tabella accmotive) ";
						table.columns["idcategory"].caption = "ID Categoria (tabella category)";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idregistrykind"].caption = "ID Classificazione Anagrafica (tabella registrykind)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["p_iva"].caption = "Partita iva";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["surname"].caption = "Cognome";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						//$innerSetCaptionConfig_studenti$
						break;
					case 'amministrativi_personale':
						table.columns["active"].caption = "Attivo";
						table.columns["annotation"].caption = "Note";
						table.columns["badgecode"].caption = "Codice bedge";
						table.columns["foreigncf"].caption = "Codice Fiscale estero";
						table.columns["gender"].caption = "Genere";
						table.columns["idateco"].caption = "Classificazione Ateco";
						table.columns["idcategory"].caption = "Categoria protetta";
						table.columns["idclassconsorsuale"].caption = "Classe consorsuale";
						table.columns["idfonteindicebibliometrico"].caption = "Fonte";
						table.columns["idnace"].caption = "NACE";
						table.columns["idnaturagiur"].caption = "Natura Giuridica";
						table.columns["idnumerodip"].caption = "Numero di dipendenti";
						table.columns["idreg_istituti"].caption = "Istituto, Ente o Azienda";
						table.columns["idregistrykind"].caption = "Tipologia rapporto";
						table.columns["idsasd"].caption = "SASD";
						table.columns["idstruttura"].caption = "Struttura di afferenza";
						table.columns["indicebibliometrico"].caption = "Indice bibliometrico (H-Index)";
						table.columns["p_iva"].caption = "Partita IVA";
						table.columns["pic"].caption = "Participant Identification Code (PIC)";
						table.columns["ricevimento"].caption = "Orari di ricevimento";
						table.columns["soggiorno"].caption = "Permesso di soggiorno";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_amministrativi_personale$
						break;
					case 'amministrativi':
						table.columns["active"].caption = "Attivo";
						table.columns["annotation"].caption = "Note";
						table.columns["badgecode"].caption = "Codice bedge";
						table.columns["birthdate"].caption = "Data di nascita";
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["foreigncf"].caption = "Codice Fiscale estero";
						table.columns["forename"].caption = "Nome";
						table.columns["gender"].caption = "Genere";
						table.columns["idcategory"].caption = "Categoria protetta";
						table.columns["idcity"].caption = "Comune di nascita";
						table.columns["idmaritalstatus"].caption = "Stato civile";
						table.columns["idnation"].caption = "Nazionalità";
						table.columns["idregistryclass"].caption = "Tipologia fiscale";
						table.columns["idregistrykind"].caption = "Tipologia rapporto";
						table.columns["idtitle"].caption = "Titolo";
						table.columns["p_iva"].caption = "Partita IVA";
						table.columns["residence"].caption = "Residenza";
						table.columns["surname"].caption = "Cognome";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
												table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						table.columns["idaccmotivecredit"].caption = "Causale di credito";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
//$innerSetCaptionConfig_amministrativi$
						break;
					case 'docenti_doc':
						table.columns["idcity"].caption = "Comune di nascita";
						table.columns["idmaritalstatus"].caption = "Stato civile";
						table.columns["idnation"].caption = "Nazionalità";
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia fiscale";
						table.columns["idtitle"].caption = "Titolo";
						table.columns["residence"].caption = "Residenza";
						//$innerSetCaptionConfig_docenti_doc$
						break;
					case 'docenti':
						table.columns["idcity"].caption = "Comune di nascita";
						table.columns["idmaritalstatus"].caption = "Stato civile";
						table.columns["idnation"].caption = "Nazionalità";
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia fiscale";
						table.columns["idtitle"].caption = "Titolo";
						table.columns["residence"].caption = "Residenza";
						table.columns["active"].caption = "attivo";
						table.columns["annotation"].caption = "Annotazioni";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["foreigncf"].caption = "Codice fiscale estero";
						table.columns["gender"].caption = "Sesso (M/F)";
						table.columns["idaccmotivecredit"].caption = "ID Causale per i crediti (tabella accmotive)";
						table.columns["idaccmotivedebit"].caption = "Id della causale di debito (tabella accmotive) ";
						table.columns["idcategory"].caption = "ID Categoria (tabella category)";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idregistrykind"].caption = "ID Classificazione Anagrafica (tabella registrykind)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["p_iva"].caption = "Partita iva";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						//$innerSetCaptionConfig_docenti$
						break;
					case 'istituti_princ':
						table.columns["idcity"].caption = "Comune";
						table.columns["idmaritalstatus"].caption = "ID Stato civile (tabella maritalstatus)";
						table.columns["idnation"].caption = "Id nazione (tabella geo_nation)";
						table.columns["idregistryclass"].caption = "ID Tipologie classificazione (tabella registryclass)";
						table.columns["idtitle"].caption = "ID Titolo (tabella title)";
						table.columns["residence"].caption = "Tipo residenza (chiave di tabella residence)";
						//$innerSetCaptionConfig_istituti_princ$
						break;
					case 'user':
						table.columns["idcity"].caption = "Comune di nascita";
						table.columns["idmaritalstatus"].caption = "Stato civile";
						table.columns["idnation"].caption = "Nazionalità";
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia fiscale";
						table.columns["idtitle"].caption = "Titolo";
						table.columns["residence"].caption = "Residenza";
						table.columns["title"].caption = "Nome e Cognome";
						//$innerSetCaptionConfig_user$
						break;
					case 'aziende':
						table.columns["flag_pa"].caption = "Ente pubblico";
						table.columns["idcategory"].caption = "Categoria";
						table.columns["idregistrykind"].caption = "Classificazione";
//$innerSetCaptionConfig_aziende$
						break;
					case 'istitutiesteri':
						table.columns["idcity"].caption = "Città";
						table.columns["idnation"].caption = "Nazione";
						table.columns["idregistryclass"].caption = "Tipologia";
						table.columns["location"].caption = "Città";
						table.columns["residence"].caption = "UE/Extra UE";
						//$innerSetCaptionConfig_istitutiesteri$
						break;
					case 'default':
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia";
						table.columns["idcity"].caption = "id città (tabella geo_city)";
						//$innerSetCaptionConfig_default$
						break;
					case 'docenti_docente':
//$innerSetCaptionConfig_docenti_docente$
						break;
					case 'aziende_ro':
//$innerSetCaptionConfig_aziende_ro$
						break;
					case 'uncategorized':
						table.columns["idaccmotivecredit"].caption = "Causale per i crediti";
						table.columns["idaccmotivedebit"].caption = "Causale di debito";
						//$innerSetCaptionConfig_uncategorized$
						break;
					case 'persone':
						table.columns["active"].caption = "attivo";
						table.columns["annotation"].caption = "Annotazioni";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["birthdate"].caption = "Data di nascita";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["foreigncf"].caption = "Codice fiscale estero";
						table.columns["forename"].caption = "Nome";
						table.columns["gender"].caption = "Sesso (M/F)";
						table.columns["idaccmotivecredit"].caption = "ID Causale per i crediti (tabella accmotive)";
						table.columns["idaccmotivedebit"].caption = "Id della causale di debito (tabella accmotive) ";
						table.columns["idcategory"].caption = "ID Categoria (tabella category)";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idcity"].caption = "id città (tabella geo_city)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idmaritalstatus"].caption = "ID Stato civile (tabella maritalstatus)";
						table.columns["idnation"].caption = "Id nazione (tabella geo_nation)";
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia";
						table.columns["idregistrykind"].caption = "ID Classificazione Anagrafica (tabella registrykind)";
						table.columns["idtitle"].caption = "ID Titolo (tabella title)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["p_iva"].caption = "Partita iva";
						table.columns["residence"].caption = "Tipo residenza (chiave di tabella residence)";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["surname"].caption = "Cognome";
						table.columns["title"].caption = "Cognome Nome";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						//$innerSetCaptionConfig_persone$
						break;
					case 'servizi':
//$innerSetCaptionConfig_servizi$
						break;
					case 'solotitle':
						table.columns["active"].caption = "attivo";
						table.columns["annotation"].caption = "Annotazioni";
						table.columns["authorization_free"].caption = "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)";
						table.columns["badgecode"].caption = "Codice badge";
						table.columns["birthdate"].caption = "Data di nascita";
						table.columns["ccp"].caption = "Conto corrente postale di Riscossione";
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["extension"].caption = "tabella che estende il record";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["flag_pa"].caption = "Applica lo split payment  (per le fatture di vendita)";
						table.columns["flagbankitaliaproceeds"].caption = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia";
						table.columns["foreigncf"].caption = "Codice fiscale estero";
						table.columns["forename"].caption = "Nome";
						table.columns["gender"].caption = "Sesso (M/F)";
						table.columns["idaccmotivecredit"].caption = "ID Causale per i crediti (tabella accmotive)";
						table.columns["idaccmotivedebit"].caption = "Id della causale di debito (tabella accmotive) ";
						table.columns["idcategory"].caption = "ID Categoria (tabella category)";
						table.columns["idcentralizedcategory"].caption = "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)";
						table.columns["idcity"].caption = "id città (tabella geo_city)";
						table.columns["idexternal"].caption = "Id chiave in altri database, usato in migrazioni o simili";
						table.columns["idmaritalstatus"].caption = "ID Stato civile (tabella maritalstatus)";
						table.columns["idnation"].caption = "Id nazione (tabella geo_nation)";
						table.columns["idreg"].caption = "Identificativo";
						table.columns["idregistryclass"].caption = "Tipologia";
						table.columns["idregistrykind"].caption = "ID Classificazione Anagrafica (tabella registrykind)";
						table.columns["idtitle"].caption = "ID Titolo (tabella title)";
						table.columns["ipa_fe"].caption = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.";
						table.columns["location"].caption = "ubicazione";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maritalsurname"].caption = "Cognome acquisito";
						table.columns["multi_cf"].caption = "Consenti duplicazione CF/P. IVA (S/N)";
						table.columns["p_iva"].caption = "Partita iva";
						table.columns["residence"].caption = "Tipo residenza (chiave di tabella residence)";
						table.columns["rtf"].caption = "allegati";
						table.columns["sdi_defrifamm"].caption = "Rif.Amministrazione di default per fattura elettronica";
						table.columns["sdi_norifamm"].caption = "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica";
						table.columns["surname"].caption = "Cognome";
						table.columns["title"].caption = "Denominazione";
						table.columns["toredirect"].caption = "E' stato usato in qualche migrazione";
						table.columns["txt"].caption = "note testuali";
						//$innerSetCaptionConfig_solotitle$
						break;
					case 'docenti_docentenoaltro':
//$innerSetCaptionConfig_docenti_docentenoaltro$
						break;
										case 'didattica':
						table.columns["!datafine"].caption = "Data fine";
						table.columns["!datainizio"].caption = "Data inizio";
//$innerSetCaptionConfig_didattica$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType) {
				var def = appMeta.Deferred("getNewRow-meta_registry");

				//$getNewRowInside$

				dt.autoIncrement('idreg', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},




			isValid: function (r) {
				var def = appMeta.Deferred("isValid-meta_registry");
				var self = this;
				utils._if((r.current.cf != null) || (r.p_iva != null))
					._then(function () {
						appMeta.CodiceFiscale.CodiceFiscaleValido(r, self.q).then((res) => {
							var obj = res;
							if (!obj.isValid) {
								// CF valorizzato ma errato
								def.resolve(obj);
								return $.Deferred().reject().promise();
							}
						})
					}).run()
					.then(function () {
						appMeta.PartitaIva.controllaPartitaIva(r).then((res) => {
							var obj = res;
							if (!obj.isValid) {
								// Piva valorizzata ma errata
								def.resolve(obj);
								return $.Deferred().reject().promise();
							}
							else {
								// Piva valorizzata e corretta
								return def.from(self.superClass.isValid.call(self, r)).promise();
							}
						})
					})
					;

				return def.promise();
			},
		


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "uncategorized": {
						return "title asc , idregistryclass asc ";
					}
					case "persone": {
						return "title asc ";
					}
					case "solotitle": {
						return "title asc ";
					}
					case "docenti_docentenoaltro": {
						return "title asc ";
					}
					case "aziende_ro": {
						return "title asc ";
					}
					case "docenti_docente": {
						return "title asc ";
					}
					case "amministrativi": {
						return "surname asc , forename asc ";
					}
					case "aziende": {
						return "title asc ";
					}
					case "docenti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry', new meta_registry('registry'));

	}());
