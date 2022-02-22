
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

    function meta_progettotipocostoinventorytree() {
        MetaData.apply(this, ["progettotipocostoinventorytree"]);
        this.name = 'meta_progettotipocostoinventorytree';
    }

    meta_progettotipocostoinventorytree.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostoinventorytree,
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
						this.describeAColumn(table, '!idinv_inventorytree_codeinv', 'Codice', null, 11, null);
						this.describeAColumn(table, '!idinv_inventorytree_description', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idinv_accmotive_codemotive', 'Codice causale di carico', null, 11, null);
						this.describeAColumn(table, '!idinv_accmotive_title', 'Denominazione causale di carico', null, 12, null);
						objCalcFieldConfig['!idinv_inventorytree_codeinv'] = { tableNameLookup:'inventorytree', columnNameLookup:'codeinv', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_inventorytree_description'] = { tableNameLookup:'inventorytree', columnNameLookup:'description', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idinv' };
						this.describeAColumn(table, '!idinv_inventorytree_codeinv', 'Codice', null, 12, null);
						this.describeAColumn(table, '!idinv_inventorytree_description', 'Denominazione', null, 14, null);
						this.describeAColumn(table, '!idinv_accmotive_codemotive', 'Codice causale di carico', null, 15, null);
						this.describeAColumn(table, '!idinv_accmotive_title', 'Denominazione causale di carico', null, 16, null);
						this.describeAColumn(table, '!idinv_accmotive_alias2_codemotive', 'Codice causale di carico', null, 15, null);
						this.describeAColumn(table, '!idinv_accmotive_alias2_title', 'Denominazione causale di carico', null, 16, null);
						objCalcFieldConfig['!idinv_accmotive_alias2_codemotive'] = { tableNameLookup:'accmotive_alias2', columnNameLookup:'codemotive', columnNamekey:'idinv' };
						objCalcFieldConfig['!idinv_accmotive_alias2_title'] = { tableNameLookup:'accmotive_alias2', columnNameLookup:'title', columnNamekey:'idinv' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostoinventorytree");

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

    window.appMeta.addMeta('progettotipocostoinventorytree', new meta_progettotipocostoinventorytree('progettotipocostoinventorytree'));

	}());
