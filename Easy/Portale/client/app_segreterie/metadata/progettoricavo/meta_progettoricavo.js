
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

    function meta_progettoricavo() {
        MetaData.apply(this, ["progettoricavo"]);
        this.name = 'meta_progettoricavo';
    }

    meta_progettoricavo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoricavo,
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
						this.describeAColumn(table, 'amount', 'Importo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'doc', 'Documento collegato', null, 50, 35);
						this.describeAColumn(table, 'docdate', 'Data del documento collegato', null, 60, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Tipo di contratto', null, 31, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind_alias1', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
						this.describeAColumn(table, '!idinc_income_description', 'Descrizione incasso', null, 71, null);
						this.describeAColumn(table, '!idinc_income_ymov', 'Anno movimento incasso', null, 72, null);
						this.describeAColumn(table, '!idinc_income_nmov', 'Numero movimento incasso', null, 73, null);
						objCalcFieldConfig['!idinc_income_description'] = { tableNameLookup:'income', columnNameLookup:'description', columnNamekey:'idinc' };
						objCalcFieldConfig['!idinc_income_ymov'] = { tableNameLookup:'income', columnNameLookup:'ymov', columnNamekey:'idinc' };
						objCalcFieldConfig['!idinc_income_nmov'] = { tableNameLookup:'income', columnNameLookup:'nmov', columnNamekey:'idinc' };
						this.describeAColumn(table, '!idprogettotipocosto_progettotipocosto_title', 'Voce di ricavo', null, 11, null);
						objCalcFieldConfig['!idprogettotipocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto_alias2', columnNameLookup:'title', columnNamekey:'idprogettotipocosto' };
						this.describeAColumn(table, '!idrelated_entrydetail_description', 'Chiave economico patrimoniale', null, 92, null);
						objCalcFieldConfig['!idrelated_entrydetail_description'] = { tableNameLookup:'entrydetail', columnNameLookup:'description', columnNamekey:'idrelated' };
						this.describeAColumn(table, '!idrendicontattivitaprogetto_rendicontattivitaprogetto_description', 'Attività svolta', null, 41, null);
						objCalcFieldConfig['!idrendicontattivitaprogetto_rendicontattivitaprogetto_description'] = { tableNameLookup:'rendicontattivitaprogetto_alias1', columnNameLookup:'description', columnNamekey:'idrendicontattivitaprogetto' };
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 81, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 82, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idsal' };
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
						table.columns["amount"].caption = "Importo";
						table.columns["doc"].caption = "Documento collegato";
						table.columns["docdate"].caption = "Data del documento collegato";
						table.columns["idcontrattokind"].caption = "Tipo di contratto";
						table.columns["idinc"].caption = "Ricavo";
						table.columns["idrelated"].caption = "Chiave economico patrimoniale";
						table.columns["idrendicontattivitaprogetto"].caption = "Attività svolta";
						table.columns["idsal"].caption = "Stato avanzamento lavori";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["idprogettotipocosto"].caption = "Voce di ricavo";
						table.columns["idinc"].caption = "incasso";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoricavo");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoricavo', { minimum: 99990001 });

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
						return "idprogettotipocosto asc , idworkpackage asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('progettoricavo', new meta_progettoricavo('progettoricavo'));

	}());
