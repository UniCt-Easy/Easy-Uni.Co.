
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

    function meta_progettocosto() {
        MetaData.apply(this, ["progettocosto"]);
        this.name = 'meta_progettocosto';
    }

    meta_progettocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettocosto,
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
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 90, null);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 100, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Tipo di contratto', null, 31, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
						this.describeAColumn(table, '!idexp_expense_description', 'Descrizione Spesa', null, 71, null);
						this.describeAColumn(table, '!idexp_expense_ymov', 'Anno movimento Spesa', null, 72, null);
						this.describeAColumn(table, '!idexp_expense_nmov', 'N.movimento Spesa', null, 73, null);
						objCalcFieldConfig['!idexp_expense_description'] = { tableNameLookup:'expense', columnNameLookup:'description', columnNamekey:'idexp' };
						objCalcFieldConfig['!idexp_expense_ymov'] = { tableNameLookup:'expense', columnNameLookup:'ymov', columnNamekey:'idexp' };
						objCalcFieldConfig['!idexp_expense_nmov'] = { tableNameLookup:'expense', columnNameLookup:'nmov', columnNamekey:'idexp' };
						this.describeAColumn(table, '!idpettycash_pettycash_description', 'Descrizione Fondo economale', null, 81, null);
						this.describeAColumn(table, '!idpettycash_pettycash_pettycode', 'Codice Fondo economale', null, 82, null);
						objCalcFieldConfig['!idpettycash_pettycash_description'] = { tableNameLookup:'pettycash', columnNameLookup:'description', columnNamekey:'idpettycash' };
						objCalcFieldConfig['!idpettycash_pettycash_pettycode'] = { tableNameLookup:'pettycash', columnNameLookup:'pettycode', columnNamekey:'idpettycash' };
						this.describeAColumn(table, '!idprogettotipocosto_progettotipocosto_title', 'Voce di costo', null, 11, null);
						objCalcFieldConfig['!idprogettotipocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto_alias1', columnNameLookup:'title', columnNamekey:'idprogettotipocosto' };
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_description', 'Attività svolta', null, 41, null);
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto', columnNameLookup:'description', columnNamekey:'idrendicontattivitaprogetto' };
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 121, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 122, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
//$objCalcFieldConfig_seg$
						break;
					case 'segprg':
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 30, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 90, null);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 100, null);
//$objCalcFieldConfig_segprg$
						break;
					case 'segsal':
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, 'yoperation', 'Esercizio operazione', null, 90, null);
						this.describeAColumn(table, 'noperation', 'Numero operazione', null, 100, null);
//$objCalcFieldConfig_segsal$
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
						table.columns["amount"].caption = "Importo";
						table.columns["doc"].caption = "Documento collegato";
						table.columns["docdate"].caption = "Data del documento collegato";
						table.columns["idcontrattokind"].caption = "Tipo di contratto";
						table.columns["idexp"].caption = "Spesa";
						table.columns["idpettycash"].caption = "Fondo economale";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idprogettotipocosto"].caption = "Voce di costo";
						table.columns["idrelated"].caption = "Chiave economico patrimoniale";
						table.columns["idrendicontattivitaprogetto"].caption = "Attività svolta";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["noperation"].caption = "Numero operazione";
						table.columns["yoperation"].caption = "Esercizio operazione";
//$innerSetCaptionConfig_seg$
						break;
					case 'segprg':
						table.columns["amount"].caption = "Importo";
//$innerSetCaptionConfig_segprg$
						break;
					case 'segsal':
						table.columns["amount"].caption = "Importo";
//$innerSetCaptionConfig_segsal$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettocosto");

				//$getNewRowInside$

				dt.autoIncrement('idprogettocosto', { minimum: 99990001 });

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
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					case "segprg": {
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					case "segprg": {
						return "idworkpackage asc , idprogettotipocosto asc ";
					}
					case "segsal": {
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettocosto', new meta_progettocosto('progettocosto'));

	}());
