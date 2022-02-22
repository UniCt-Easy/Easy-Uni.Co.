
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

    function meta_pcsassunzionisimulate() {
        MetaData.apply(this, ["pcsassunzionisimulate"]);
        this.name = 'meta_pcsassunzionisimulate';
    }

    meta_pcsassunzionisimulate.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcsassunzionisimulate,
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
						this.describeAColumn(table, 'numeropersoneassunzione', 'Numero di persone su nuova assunzione', 'fixed.2', 10, null);
						this.describeAColumn(table, 'data', 'Data assunzione presunta', 'g', 30, null);
						this.describeAColumn(table, 'stipendio', 'Stipendio tabellare più basso', 'fixed.2', 40, null);
						this.describeAColumn(table, 'percentuale', 'Indicare la percentuale di stipendio da considerare.', 'fixed.2', 100, null);
						this.describeAColumn(table, 'totale', 'Totale anno in analisi', 'fixed.2', 110, null);
						this.describeAColumn(table, 'totale1', 'Totale anno in analisi +1', 'fixed.2', 120, null);
						this.describeAColumn(table, 'totale2', 'Totale anno in analisi +2', 'fixed.2', 130, null);
						this.describeAColumn(table, 'totale3', 'Totale anno in analisi +3', 'fixed.2', 140, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Qualifica/Categoria', null, 21, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
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
						table.columns["idcontrattokind_start"].caption = "Qualifica/Categoria di partenza";
						table.columns["idsasd"].caption = "SSD";
						table.columns["idstruttura"].caption = "Dipartimento";
						table.columns["legge"].caption = "Legge/Decreto";
						table.columns["nominativo"].caption = "Nominativo";
						table.columns["numeropersoneassunzione"].caption = "Numero di persone su nuova assunzione";
						table.columns["percentuale"].caption = "Indicare la percentuale di stipendio da considerare.";
						table.columns["stipendio"].caption = "Stipendio tabellare più basso";
						table.columns["totale"].caption = "Totale anno in analisi";
						table.columns["totale1"].caption = "Totale anno in analisi +1";
						table.columns["totale2"].caption = "Totale anno in analisi +2";
						table.columns["totale3"].caption = "Totale anno in analisi +3";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pcsassunzionisimulate");

				//$getNewRowInside$

				dt.autoIncrement('idpcsassunzionisimulate', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('pcsassunzionisimulate', new meta_pcsassunzionisimulate('pcsassunzionisimulate'));

	}());
