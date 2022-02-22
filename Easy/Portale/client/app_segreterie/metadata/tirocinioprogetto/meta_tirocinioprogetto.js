
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

    function meta_tirocinioprogetto() {
        MetaData.apply(this, ["tirocinioprogetto"]);
        this.name = 'meta_tirocinioprogetto';
    }

    meta_tirocinioprogetto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioprogetto,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, -1);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'competenze', 'Competenze', null, 40, -1);
						this.describeAColumn(table, 'datafineeffettiva', 'Data fine effettiva', null, 50, null);
						this.describeAColumn(table, 'datafineprevista', 'Data fine prevista', null, 60, null);
						this.describeAColumn(table, 'datainizioeffettiva', 'Data inizio effettiva', null, 70, null);
						this.describeAColumn(table, 'datainizioprevista', 'Data inizio prevista', null, 80, null);
						this.describeAColumn(table, 'dataverbale', 'Data verbale', null, 90, null);
						this.describeAColumn(table, 'description_en', 'Descrizione in inglese', null, 100, -1);
						this.describeAColumn(table, 'ore', 'Ore', null, 200, null);
						this.describeAColumn(table, 'tempiaccesso', 'Tempi di accesso', null, 230, -1);
						this.describeAColumn(table, 'title_en', 'Titolo in inglese', null, 240, -1);
						this.describeAColumn(table, '!idaoo_aoo_title', 'Area organizzativa omogenea', null, 111, null);
						objCalcFieldConfig['!idaoo_aoo_title'] = { tableNameLookup:'aoo', columnNameLookup:'title', columnNamekey:'idaoo' };
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Tutor', null, 121, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idsede_sede_title', 'Sede', null, 151, null);
						objCalcFieldConfig['!idsede_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'idsede' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Struttura didattica', null, 161, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Struttura didattica', null, 161, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						this.describeAColumn(table, '!idtirociniostato_tirociniostato_title', 'Stato del tirocinio', null, 191, null);
						objCalcFieldConfig['!idtirociniostato_tirociniostato_title'] = { tableNameLookup:'tirociniostato', columnNameLookup:'title', columnNamekey:'idtirociniostato' };
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
						table.columns["datafineeffettiva"].caption = "Data fine effettiva";
						table.columns["datafineprevista"].caption = "Data fine prevista";
						table.columns["datainizioeffettiva"].caption = "Data inizio effettiva";
						table.columns["datainizioprevista"].caption = "Data inizio prevista";
						table.columns["dataverbale"].caption = "Data verbale";
						table.columns["description"].caption = "Descrizione";
						table.columns["description_en"].caption = "Descrizione in inglese";
						table.columns["idaoo"].caption = "Area organizzativa omogenea";
						table.columns["idreg_docenti"].caption = "Tutor";
						table.columns["idreg_referente"].caption = "Referente dell'azienda";
						table.columns["idreg_studenti"].caption = "Studente";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstruttura"].caption = "Struttura didattica";
						table.columns["idtirociniostato"].caption = "Stato del tirocinio";
						table.columns["ore"].caption = "Ore";
						table.columns["protanno"].caption = "Anno protocollo";
						table.columns["protnumero"].caption = "Numero Protocollo";
						table.columns["tempiaccesso"].caption = "Tempi di accesso";
						table.columns["title"].caption = "Titolo";
						table.columns["title_en"].caption = "Titolo in inglese";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tirocinioprogetto");

				//$getNewRowInside$

				dt.autoIncrement('idtirocinioprogetto', { minimum: 99990001 });

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
					case "seg": {
						return "title desc, description desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirocinioprogetto', new meta_tirocinioprogetto('tirocinioprogetto'));

	}());
