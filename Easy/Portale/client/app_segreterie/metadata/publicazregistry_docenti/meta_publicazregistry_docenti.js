
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

    function meta_publicazregistry_docenti() {
        MetaData.apply(this, ["publicazregistry_docenti"]);
        this.name = 'meta_publicazregistry_docenti';
    }

    meta_publicazregistry_docenti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazregistry_docenti,
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
						objCalcFieldConfig['!idreg_docenti_registry_docenti_matricola'] = { tableNameLookup:'registry_docenti', columnNameLookup:'matricola', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_struttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_alias3_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_classconsorsuale_title'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idreg_docenti_registry_title', 'Denominazione', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_registry_cf', 'Codice fiscale', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_registry_p_iva', 'Partita iva', null, 15, null);
						this.describeAColumn(table, '!idreg_docenti_registry_active', 'attivo', null, 16, null);
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_matricola', 'Matricola', null, 11, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_codice', 'Codice SASD', null, 13, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_title', 'Settore Artistico Scientifico Disciplinare SASD', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_struttura_title', 'Denominazione Struttura di afferenza', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_struttura_strutturakind_title', 'Tipologia Tipologia delle strutture', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_registry_alias3_title', 'Istituto, Ente o Azienda', null, 15, null);
						this.describeAColumn(table, '!idreg_docenti_classconsorsuale_title', 'Classe consorsuale', null, 16, null);
						this.describeAColumn(table, '!idreg_docenti_contrattokind_title', 'Tipo', null, 62, null);
						objCalcFieldConfig['!idreg_docenti_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idreg_docenti_registry_alias1_title', 'Denominazione', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_registry_alias1_cf', 'Codice fiscale', null, 14, null);
						this.describeAColumn(table, '!idreg_docenti_registry_alias1_p_iva', 'Partita iva', null, 15, null);
						this.describeAColumn(table, '!idreg_docenti_registry_alias1_active', 'attivo', null, 16, null);
						this.describeAColumn(table, '!idreg_docenti_sasd_title', 'Denominazione SASD', null, 14, null);
						objCalcFieldConfig['!idreg_docenti_registry_alias1_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_alias1_cf'] = { tableNameLookup:'registry_alias1', columnNameLookup:'cf', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_alias1_p_iva'] = { tableNameLookup:'registry_alias1', columnNameLookup:'p_iva', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_alias1_active'] = { tableNameLookup:'registry_alias1', columnNameLookup:'active', columnNamekey:'idreg_docenti' };
//$objCalcFieldConfig_default$
						break;
					case 'docenti':
						objCalcFieldConfig['!idpublicaz_publicaz_title'] = { tableNameLookup:'publicaz', columnNameLookup:'title', columnNamekey:'idpublicaz' };
						objCalcFieldConfig['!idpublicaz_publicaz_title2'] = { tableNameLookup:'publicaz', columnNameLookup:'title2', columnNamekey:'idpublicaz' };
						objCalcFieldConfig['!idpublicaz_publicaz_annopub'] = { tableNameLookup:'publicaz', columnNameLookup:'annopub', columnNamekey:'idpublicaz' };
						objCalcFieldConfig['!idpublicaz_publicaz_editore'] = { tableNameLookup:'publicaz', columnNameLookup:'editore', columnNamekey:'idpublicaz' };
						objCalcFieldConfig['!idpublicaz_progetto_titolobreve'] = { tableNameLookup:'progetto', columnNameLookup:'titolobreve', columnNamekey:'idpublicaz' };
						this.describeAColumn(table, '!idpublicaz_publicaz_title', 'Titolo', null, 13, null);
						this.describeAColumn(table, '!idpublicaz_publicaz_title2', 'Sottotitolo', null, 13, null);
						this.describeAColumn(table, '!idpublicaz_publicaz_annopub', 'Anno pubblicazione', null, 14, null);
						this.describeAColumn(table, '!idpublicaz_publicaz_editore', 'Editore', null, 15, null);
						this.describeAColumn(table, '!idpublicaz_progetto_titolobreve', 'Idprogetto', null, 17, null);
						this.describeAColumn(table, '!idpublicaz_progetto_alias1_titolobreve', 'Idprogetto', null, 17, null);
						objCalcFieldConfig['!idpublicaz_progetto_alias1_titolobreve'] = { tableNameLookup:'progetto_alias1', columnNameLookup:'titolobreve', columnNamekey:'idpublicaz' };
//$objCalcFieldConfig_docenti$
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
						table.columns["idpublicaz"].caption = "Pubblicazione";
						table.columns["idreg_docenti"].caption = "Docente";
//$innerSetCaptionConfig_default$
						break;
					case 'docenti':
						table.columns["idpublicaz"].caption = "Pubblicazione";
//$innerSetCaptionConfig_docenti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_publicazregistry_docenti");

				//$getNewRowInside$


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

    window.appMeta.addMeta('publicazregistry_docenti', new meta_publicazregistry_docenti('publicazregistry_docenti'));

	}());
