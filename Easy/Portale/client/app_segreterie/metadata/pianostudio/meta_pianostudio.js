
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

    function meta_pianostudio() {
        MetaData.apply(this, ["pianostudio"]);
        this.name = 'meta_pianostudio';
    }

    meta_pianostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudio,
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
					case 'seganagstusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 51, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 51, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'segstud':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
//$objCalcFieldConfig_segstud$
						break;
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 51, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
//$objCalcFieldConfig_didprog$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seganagstusing':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seganagstusing$
						break;
					case 'seganagstu':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'segstud':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_segstud$
						break;
					case 'didprog':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_didprog$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_pianostudio");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idpianostudio', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					idreg : 0,
					idiscrizione : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seganagstusing": {
						return "aa desc";
					}
					case "seganagstu": {
						return "aa desc";
					}
					case "segstud": {
						return "aa desc";
					}
					case "didprog": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudio', new meta_pianostudio('pianostudio'));

	}());
