
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

    function meta_pcsassunzioni() {
        MetaData.apply(this, ["pcsassunzioni"]);
        this.name = 'meta_pcsassunzioni';
    }

    meta_pcsassunzioni.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcsassunzioni,
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
						this.describeAColumn(table, 'data', 'Data assunzione presunta', 'g', 30, null);
						this.describeAColumn(table, 'stipendio', 'Stipendio tabellare più basso', 'fixed.2', 40, null);
						this.describeAColumn(table, 'nominativo', 'Nominativo', null, 60, 150);
						this.describeAColumn(table, 'legge', 'Legge/Decreto', null, 80, 250);
						this.describeAColumn(table, 'finanziamento', 'Finanziamento', null, 90, 150);
						this.describeAColumn(table, 'percentuale', 'Indicare la percentuale di stipendio da considerare.', 'fixed.2', 100, null);
						this.describeAColumn(table, 'totale', 'Totale anno in analisi', 'fixed.2', 110, null);
						this.describeAColumn(table, 'totale1', 'Totale anno in analisi +1', 'fixed.2', 120, null);
						this.describeAColumn(table, 'totale2', 'Totale anno in analisi +2', 'fixed.2', 130, null);
						this.describeAColumn(table, 'totale3', 'Totale anno in analisi +3', 'fixed.2', 140, null);
						this.describeAColumn(table, 'numeropersoneassunzione', 'Numero di persone su nuova assunzione', 'fixed.2', 200, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Qualifica/Categoria', null, 21, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind_alias2', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
						this.describeAColumn(table, '!idcontrattokind_start_contrattokind_title', 'Qualifica/Categoria di partenza', null, 11, null);
						objCalcFieldConfig['!idcontrattokind_start_contrattokind_title'] = { tableNameLookup:'contrattokind_alias3', columnNameLookup:'title', columnNamekey:'idcontrattokind_start' };
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SSD', null, 51, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SSD', null, 52, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Dipartimento', null, 71, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipologia Dipartimento', null, 71, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_default$
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
						table.columns["data"].caption = "Data assunzione presunta";
						table.columns["finanziamento"].caption = "Finanziamento";
						table.columns["idcontrattokind"].caption = "Qualifica/Categoria";
						table.columns["idstruttura"].caption = "Dipartimento";
						table.columns["legge"].caption = "Legge/Decreto";
						table.columns["nominativo"].caption = "Nominativo";
						table.columns["percentuale"].caption = "Percentuale stipendio";
						table.columns["totale"].caption = "Totale anno in analisi";
						table.columns["totale1"].caption = "Totale anno in analisi +1";
						table.columns["totale2"].caption = "Totale anno in analisi +2";
						table.columns["totale3"].caption = "Totale anno in analisi +3";
						table.columns["idcontrattokind_start"].caption = "Qualifica/Categoria di partenza";
						table.columns["stipendio"].caption = "Stipendio tabellare più alto";
						table.columns["idsasd"].caption = "SSD";
						table.columns["percentuale"].caption = "Indicare la percentuale di stipendio da considerare. Nel caso di più assunzioni o progressioni indicare una percentuale superiore al 100%";
						table.columns["numeropersoneassunzione"].caption = "Numero di persone su nuova assunzione";
						table.columns["stipendio"].caption = "Stipendio tabellare più basso";
						table.columns["percentuale"].caption = "Indicare la percentuale di stipendio da considerare.";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pcsassunzioni");

				//$getNewRowInside$

				dt.autoIncrement('idpcsassunzioni', { minimum: 99990001 });

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
						return "year asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pcsassunzioni', new meta_pcsassunzioni('pcsassunzioni'));

	}());
