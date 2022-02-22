
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


(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_flowchart() {
		MetaData.apply(this, ["flowchart"]);
		this.name = 'meta_flowchart';
	}

	meta_flowchart.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_flowchart,
			superClass: MetaData.prototype,			

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, '!idcity_geo_city_title', 'id città (tabella geo_city)', null, 81, null);
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup: 'geo_city', columnNameLookup: 'title', columnNamekey: 'idcity' };
						//$objCalcFieldConfig_default$
						break;
					case 'seg':
						this.describeAColumn(table, 'codeflowchart', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'nlevel', 'N. livello', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
					case 'segamm':
						this.describeAColumn(table, 'idflowchart', 'Identificativo', null, 10, 34);
						this.describeAColumn(table, 'ayear', 'Anno esercizio', null, 20, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 150);
						this.describeAColumn(table, 'codeflowchart', 'Codice', null, 40, 50);
//$objCalcFieldConfig_segamm$
						break;
					//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segamm':
						table.columns["ayear"].caption = "Anno esercizio";
						table.columns["codeflowchart"].caption = "Codice";
						table.columns["idflowchart"].caption = "Identificativo";
						table.columns["nlevel"].caption = "Livello del nodo";
						table.columns["paridflowchart"].caption = "Nodo padre";
						table.columns["title"].caption = "Titolo";
						//$innerSetCaptionConfig_segamm$
						break;
					//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_flowchart");

				//$getNewRowInside$
				var esercizio = (new Date()).getFullYear().toString();
				if (!parentRow) {
					dt.defaults({ paridflowchart: esercizio.substring(2, 4), ayear: esercizio, nlevel: 1, printingorder: 'Amministrazione' });
				}
				else {
					dt.defaults({paridflowchart: parentRow.current.idflowchart, ayear: esercizio, nlevel: parentRow.current.nlevel + 1, printingorder: 'Amministrazione' });
				}
				dt.autoIncrement('idflowchart', { minimum: 9001, prefixField: 'paridflowchart', idLen: 4 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "codeflowchart asc , title desc";
					}
					case "segamm": {
						return "idflowchart asc , title desc";
					}
					case "segamm": {
						return "idflowchart asc , title desc, codeflowchart asc ";
					}
					case "seg": {
						return "codeflowchart asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title","codeflowchart");
				var rootCondition = window.jsDataQuery.eq("paridflowchart", (new Date()).getFullYear().toString().substr(2, 3));
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
		});

	window.appMeta.addMeta('flowchart', new meta_flowchart('flowchart'));

}());
