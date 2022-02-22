
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

    function meta_salprogettocosto() {
        MetaData.apply(this, ["salprogettocosto"]);
        this.name = 'meta_salprogettocosto';
    }

    meta_salprogettocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_salprogettocosto,
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
						this.describeAColumn(table, '!idprogettocosto_progettotipocosto_title', 'Voce di costo', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, '!idprogettocosto_contrattokind_title', 'Tipo di contratto', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_rendicontattivitaprogetto_workpackage_titolobreve', 'Titolo breve o acronimo Workpackage', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_rendicontattivitaprogetto_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_rendicontattivitaprogetto_workpackage_title', 'Titolo Workpackage', null, 22, null);
						this.describeAColumn(table, '!idprogettocosto_rendicontattivitaprogetto_description', 'Descrizione Attività svolta', null, 23, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_doc', 'Documento collegato', null, 20, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_docdate', 'Data del documento collegato', null, 20, null);
						this.describeAColumn(table, '!idprogettocosto_expense_description', 'Descrizione Spesa', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_expense_ymov', 'Anno movimento Spesa', null, 22, null);
						this.describeAColumn(table, '!idprogettocosto_expense_nmov', 'N.movimento Spesa', null, 23, null);
						this.describeAColumn(table, '!idprogettocosto_pettycash_description', 'Descrizione Fondo economale', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_pettycash_pettycode', 'Codice Fondo economale', null, 22, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_yoperation', 'Esercizio operazione', null, 20, null);
						this.describeAColumn(table, '!idprogettocosto_progettocosto_noperation', 'Numero operazione', null, 20, null);
						this.describeAColumn(table, '!idprogettocosto_sal_alias1_start', 'Data di inizio Stato avanzamento lavori', null, 21, null);
						this.describeAColumn(table, '!idprogettocosto_sal_alias1_stop', 'Data di fine Stato avanzamento lavori', null, 22, null);
						objCalcFieldConfig['!idprogettocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_amount'] = { tableNameLookup:'progettocosto', columnNameLookup:'amount', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_rendicontattivitaprogetto_workpackage_titolobreve'] = { tableNameLookup:'workpackage', columnNameLookup:'titolobreve', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_rendicontattivitaprogetto_workpackage_raggruppamento'] = { tableNameLookup:'workpackage', columnNameLookup:'raggruppamento', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_rendicontattivitaprogetto_workpackage_title'] = { tableNameLookup:'workpackage', columnNameLookup:'title', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto', columnNameLookup:'description', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_doc'] = { tableNameLookup:'progettocosto', columnNameLookup:'doc', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_docdate'] = { tableNameLookup:'progettocosto', columnNameLookup:'docdate', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_expense_description'] = { tableNameLookup:'expense', columnNameLookup:'description', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_expense_ymov'] = { tableNameLookup:'expense', columnNameLookup:'ymov', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_expense_nmov'] = { tableNameLookup:'expense', columnNameLookup:'nmov', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_pettycash_description'] = { tableNameLookup:'pettycash', columnNameLookup:'description', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_pettycash_pettycode'] = { tableNameLookup:'pettycash', columnNameLookup:'pettycode', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_yoperation'] = { tableNameLookup:'progettocosto', columnNameLookup:'yoperation', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_progettocosto_noperation'] = { tableNameLookup:'progettocosto', columnNameLookup:'noperation', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_sal_alias1_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idprogettocosto' };
						objCalcFieldConfig['!idprogettocosto_sal_alias1_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idprogettocosto' };
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
				var def = appMeta.Deferred("getNewRow-meta_salprogettocosto");

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

    window.appMeta.addMeta('salprogettocosto', new meta_salprogettocosto('salprogettocosto'));

	}());
