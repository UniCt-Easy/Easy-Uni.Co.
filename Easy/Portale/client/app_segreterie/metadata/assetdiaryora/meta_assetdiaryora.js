
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

    function meta_assetdiaryora() {
        MetaData.apply(this, ["assetdiaryora"]);
        this.name = 'meta_assetdiaryora';
    }

    meta_assetdiaryora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assetdiaryora,
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
						this.describeAColumn(table, 'amount', 'Amount', 'fixed.2', 10, null);
						this.describeAColumn(table, '!title', 'Descrizione', null, 20, null);
						this.describeAColumn(table, 'start', 'Data e ora di inizio', 'g', 80, null);
						this.describeAColumn(table, 'stop', 'Data e ora di fine', 'g', 90, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 151, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 152, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal', columnNameLookup:'stop', columnNamekey:'idsal' };
//$objCalcFieldConfig_seg$
						break;
					case 'segsal':
						this.describeAColumn(table, 'amount', 'Amount', 'fixed.2', 10, null);
						this.describeAColumn(table, '!title', 'Descrizione', null, 20, null);
						this.describeAColumn(table, 'start', 'Data e ora di inizio', 'g', 80, null);
						this.describeAColumn(table, 'stop', 'Data e ora di fine', 'g', 90, null);
						this.describeAColumn(table, '!idsal_sal_start', 'Data di inizio Stato avanzamento lavori', null, 151, null);
						this.describeAColumn(table, '!idsal_sal_stop', 'Data di fine Stato avanzamento lavori', null, 152, null);
						objCalcFieldConfig['!idsal_sal_start'] = { tableNameLookup:'sal_alias1', columnNameLookup:'start', columnNamekey:'idsal' };
						objCalcFieldConfig['!idsal_sal_stop'] = { tableNameLookup:'sal_alias1', columnNameLookup:'stop', columnNamekey:'idsal' };
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
					case 'segsal':
						table.columns["!title"].caption = "Descrizione";
//$innerSetCaptionConfig_segsal$
						break;
					case 'seg':
						table.columns["!title"].caption = "Descrizione";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_assetdiaryora");

				//$getNewRowInside$

				dt.autoIncrement('idassetdiaryora', { minimum: 99990001 });

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
						return "!title desc";
					}
					case "segsal": {
						return "!title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('assetdiaryora', new meta_assetdiaryora('assetdiaryora'));

	}());
