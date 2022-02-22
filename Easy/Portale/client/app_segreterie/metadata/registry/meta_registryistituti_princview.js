
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 101);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 20, null);
						this.describeAColumn(table, 'registry_annotation', 'Annotazioni', null, 30, 400);
						this.describeAColumn(table, 'registry_authorization_free', 'Esente ai fini dell\'autorizzazione EQUITALIA. (S/N)', null, 40, null);
						this.describeAColumn(table, 'registry_badgecode', 'Codice badge', null, 50, 20);
						this.describeAColumn(table, 'registry_birthdate', 'Data di nascita', null, 60, null);
						this.describeAColumn(table, 'registry_ccp', 'Conto corrente postale di Riscossione', null, 70, 12);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 80, 16);
						this.describeAColumn(table, 'registry_email_fe', 'Email_fe', null, 90, 200);
						this.describeAColumn(table, 'registry_extmatricula', 'Matricola', null, 110, 40);
						this.describeAColumn(table, 'registry_flag_pa', 'Applica lo split payment  (per le fatture di vendita)', null, 120, null);
						this.describeAColumn(table, 'registry_flagbankitaliaproceeds', 'Regolarizzazione Riscossioni presso  T.P.S. - Banca d\'Italia', null, 130, null);
						this.describeAColumn(table, 'registry_foreigncf', 'Codice fiscale estero', null, 140, 40);
						this.describeAColumn(table, 'registry_forename', 'Nome', null, 150, 50);
						this.describeAColumn(table, 'registry_gender', 'Sesso (M/F)', null, 160, null);
						this.describeAColumn(table, 'accmotive_codemotive', 'Codice ID Causale per i crediti (tabella accmotive)', null, 170, 50);
						this.describeAColumn(table, 'accmotive_title', 'Denominazione ID Causale per i crediti (tabella accmotive)', null, 170, 150);
						this.describeAColumn(table, 'accmotive_registry_codemotive', 'Codice Id della causale di debito (tabella accmotive) ', null, 180, 50);
						this.describeAColumn(table, 'accmotive_registry_title', 'Denominazione Id della causale di debito (tabella accmotive) ', null, 180, 150);
						this.describeAColumn(table, 'category_description', 'ID Categoria (tabella category)', null, 190, 50);
						this.describeAColumn(table, 'centralizedcategory_description', 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)', null, 200, 50);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 210, 65);
						this.describeAColumn(table, 'registry_idexternal', 'Id chiave in altri database, usato in migrazioni o simili', null, 220, null);
						this.describeAColumn(table, 'maritalstatus_description', 'ID Stato civile (tabella maritalstatus)', null, 230, 50);
						this.describeAColumn(table, 'geo_nation_title', 'Id nazione (tabella geo_nation)', null, 240, 65);
						this.describeAColumn(table, 'registryclass_description', 'ID Tipologie classificazione (tabella registryclass)', null, 260, 150);
						this.describeAColumn(table, 'registrykind_description', 'ID Classificazione Anagrafica (tabella registrykind)', null, 270, 50);
						this.describeAColumn(table, 'title_description', 'ID Titolo (tabella title)', null, 280, 50);
						this.describeAColumn(table, 'registry_ipa_fe', 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.', null, 290, 7);
						this.describeAColumn(table, 'registry_location', 'ubicazione', null, 300, 50);
						this.describeAColumn(table, 'registry_maritalsurname', 'Cognome acquisito', null, 310, 50);
						this.describeAColumn(table, 'registry_multi_cf', 'Consenti duplicazione CF/P. IVA (S/N)', null, 320, null);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 330, 15);
						this.describeAColumn(table, 'registry_pec_fe', 'Pec_fe', null, 340, 200);
						this.describeAColumn(table, 'residence_description', 'Tipo residenza (chiave di tabella residence)', null, 350, 60);
						this.describeAColumn(table, 'registry_rtf', 'allegati', null, 360, null);
						this.describeAColumn(table, 'registry_sdi_defrifamm', 'Rif.Amministrazione di default per fattura elettronica', null, 370, 20);
						this.describeAColumn(table, 'registry_sdi_norifamm', 'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica', null, 380, null);
						this.describeAColumn(table, 'registry_surname', 'Cognome', null, 390, 50);
						this.describeAColumn(table, 'registry_toredirect', 'E\' stato usato in qualche migrazione', null, 400, null);
						this.describeAColumn(table, 'registry_txt', 'note testuali', null, 410, null);
						this.describeAColumn(table, 'registry_ipa_perlapa', 'Ipa_perlapa', null, 460, 100);
						this.describeAColumn(table, 'registry_istituti_codicemiur', 'Codice MIUR', null, 10, 50);
						this.describeAColumn(table, 'registry_istituti_codiceustat', 'Codice USTAT', null, 20, 50);
						this.describeAColumn(table, 'registry_istituti_comune', 'Comune', null, 30, 64);
						this.describeAColumn(table, 'istitutokind_tipoistituto', 'Tipologia', null, 40, 256);
						this.describeAColumn(table, 'registry_istituti_idistitutoustat', 'Codice USTAT', null, 50, null);
						this.describeAColumn(table, 'registry_istituti_nome', 'Denominazione breve', null, 70, null);
						this.describeAColumn(table, 'registry_istituti_sortcode', 'Sortcode', null, 80, null);
						this.describeAColumn(table, 'registry_istituti_title_en', 'Denominazione (ENG)', null, 90, 256);
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
