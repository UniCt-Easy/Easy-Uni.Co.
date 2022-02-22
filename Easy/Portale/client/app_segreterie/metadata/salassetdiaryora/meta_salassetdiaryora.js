
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

    function meta_salassetdiaryora() {
        MetaData.apply(this, ["salassetdiaryora"]);
        this.name = 'meta_salassetdiaryora';
    }

    meta_salassetdiaryora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_salassetdiaryora,
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
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_amount', 'Amount', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_!title', '!title', null, 11, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_start', 'Data e ora di inizio', 'g', 10, null);
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora_stop', 'Data e ora di fine', 'g', 10, null);
						this.describeAColumn(table, '!idassetdiaryora_sal_alias1_start', 'Data di inizio Stato avanzamento lavori', null, 11, null);
						this.describeAColumn(table, '!idassetdiaryora_sal_alias1_stop', 'Data di fine Stato avanzamento lavori', null, 12, null);
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_amount'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'amount', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_!title'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'!title', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_start'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'start', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora_stop'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'stop', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_sal_alias1_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idassetdiaryora' };
						objCalcFieldConfig['!idassetdiaryora_sal_alias1_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idassetdiaryora' };
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora__x0021_title', '!title', null, 11, null);
						objCalcFieldConfig['!idassetdiaryora_assetdiaryora__x0021_title'] = { tableNameLookup:'assetdiaryora', columnNameLookup:'!title', columnNamekey:'idassetdiaryora' };
						this.describeAColumn(table, '!idassetdiaryora_assetdiaryora__x0021_title', 'Descrizione', null, 11, null);
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
				var def = appMeta.Deferred("getNewRow-meta_salassetdiaryora");

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

    window.appMeta.addMeta('salassetdiaryora', new meta_salassetdiaryora('salassetdiaryora'));

	}());
