
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

    function meta_costoscontodefdettaglio() {
        MetaData.apply(this, ["costoscontodefdettaglio"]);
        this.name = 'meta_costoscontodefdettaglio';
    }

    meta_costoscontodefdettaglio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodefdettaglio,
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
					case 'riepilogo':
						this.describeAColumn(table, 'idfasciaiseedef', 'Fascia ISEE', null, 40, null);
						this.describeAColumn(table, 'idratadef', 'Rata', null, 50, null);
						this.describeAColumn(table, 'importo', 'Importo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'parama', 'Parametro A', 'fixed.2', 70, null);
						this.describeAColumn(table, 'paramb', 'Parametro B', 'fixed.2', 80, null);
						this.describeAColumn(table, 'paramc', 'Parametro C', 'fixed.2', 90, null);
						this.describeAColumn(table, 'paramd', 'Parametro D', 'fixed.2', 100, null);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 110, null);
						this.describeAColumn(table, '!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title', 'Voce di dettaglio', null, 31, null);
						objCalcFieldConfig['!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title'] = { tableNameLookup:'costoscontodefdettagliokind', columnNameLookup:'title', columnNamekey:'idcostoscontodefdettagliokind' };
						this.describeAColumn(table, '!idfasciaiseedef_fasciaiseedef_idfasciaisee', 'Fascia ISEE', null, 41, null);
						objCalcFieldConfig['!idfasciaiseedef_fasciaiseedef_idfasciaisee'] = { tableNameLookup:'fasciaiseedef', columnNameLookup:'idfasciaisee', columnNamekey:'idfasciaiseedef' };
						this.describeAColumn(table, '!idratadef_ratadef_idratakind', 'Rata', null, 51, null);
						objCalcFieldConfig['!idratadef_ratadef_idratakind'] = { tableNameLookup:'ratadef', columnNameLookup:'idratakind', columnNamekey:'idratadef' };
//$objCalcFieldConfig_riepilogo$
						break;
					case 'more':
						this.describeAColumn(table, 'idfasciaiseedef', 'Fascia ISEE', null, 40, null);
						this.describeAColumn(table, 'idratadef', 'Rata', null, 50, null);
						this.describeAColumn(table, 'importo', 'Importo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'parama', 'Parametro A', 'fixed.2', 70, null);
						this.describeAColumn(table, 'paramb', 'Parametro B', 'fixed.2', 80, null);
						this.describeAColumn(table, 'paramc', 'Parametro C', 'fixed.2', 90, null);
						this.describeAColumn(table, 'paramd', 'Parametro D', 'fixed.2', 100, null);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 110, null);
						this.describeAColumn(table, '!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title', 'Voce di dettaglio', null, 31, null);
						objCalcFieldConfig['!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title'] = { tableNameLookup:'costoscontodefdettagliokind', columnNameLookup:'title', columnNamekey:'idcostoscontodefdettagliokind' };
						this.describeAColumn(table, '!idfasciaiseedef_fasciaiseedef_idfasciaisee', 'Fascia ISEE', null, 41, null);
						objCalcFieldConfig['!idfasciaiseedef_fasciaiseedef_idfasciaisee'] = { tableNameLookup:'fasciaiseedef', columnNameLookup:'idfasciaisee', columnNamekey:'idfasciaiseedef' };
						this.describeAColumn(table, '!idratadef_ratadef_idratakind', 'Rata', null, 51, null);
						objCalcFieldConfig['!idratadef_ratadef_idratakind'] = { tableNameLookup:'ratadef', columnNameLookup:'idratakind', columnNamekey:'idratadef' };
//$objCalcFieldConfig_more$
						break;
					case 'sconti':
						this.describeAColumn(table, 'idfasciaiseedef', 'Fascia ISEE', null, 40, null);
						this.describeAColumn(table, 'idratadef', 'Rata', null, 50, null);
						this.describeAColumn(table, 'importo', 'Importo', 'fixed.2', 60, null);
						this.describeAColumn(table, 'parama', 'Parametro A', 'fixed.2', 70, null);
						this.describeAColumn(table, 'paramb', 'Parametro B', 'fixed.2', 80, null);
						this.describeAColumn(table, 'paramc', 'Parametro C', 'fixed.2', 90, null);
						this.describeAColumn(table, 'paramd', 'Parametro D', 'fixed.2', 100, null);
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 110, null);
						this.describeAColumn(table, '!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title', 'Voce di dettaglio', null, 31, null);
						objCalcFieldConfig['!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title'] = { tableNameLookup:'costoscontodefdettagliokind', columnNameLookup:'title', columnNamekey:'idcostoscontodefdettagliokind' };
						this.describeAColumn(table, '!idfasciaiseedef_fasciaiseedef_idfasciaisee', 'Fascia ISEE', null, 41, null);
						objCalcFieldConfig['!idfasciaiseedef_fasciaiseedef_idfasciaisee'] = { tableNameLookup:'fasciaiseedef', columnNameLookup:'idfasciaisee', columnNamekey:'idfasciaiseedef' };
						this.describeAColumn(table, '!idratadef_ratadef_idratakind', 'Rata', null, 51, null);
						objCalcFieldConfig['!idratadef_ratadef_idratakind'] = { tableNameLookup:'ratadef', columnNameLookup:'idratakind', columnNamekey:'idratadef' };
//$objCalcFieldConfig_sconti$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'riepilogo':
						table.columns["idcostoscontodefdettagliokind"].caption = "Voce di dettaglio";
						table.columns["idfasciaiseedef"].caption = "Fascia ISEE";
						table.columns["idratadef"].caption = "Rata";
//$innerSetCaptionConfig_riepilogo$
						break;
					case 'more':
						table.columns["idcostoscontodefdettagliokind"].caption = "Voce di dettaglio";
						table.columns["idfasciaiseedef"].caption = "Fascia ISEE";
						table.columns["idratadef"].caption = "Rata";
//$innerSetCaptionConfig_more$
						break;
					case 'sconti':
						table.columns["idcostoscontodefdettagliokind"].caption = "Voce di dettaglio";
						table.columns["idfasciaiseedef"].caption = "Fascia ISEE";
						table.columns["idratadef"].caption = "Rata";
//$innerSetCaptionConfig_sconti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_costoscontodefdettaglio");

				//$getNewRowInside$

				dt.autoIncrement('idcostoscontodefdettaglio', { minimum: 99990001 });

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
					case "riepilogo": {
						return "idfasciaiseedef asc , idratadef asc ";
					}
					case "more": {
						return "idfasciaiseedef asc , idratadef asc ";
					}
					case "sconti": {
						return "idfasciaiseedef asc , idratadef asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodefdettaglio', new meta_costoscontodefdettaglio('costoscontodefdettaglio'));

	}());
