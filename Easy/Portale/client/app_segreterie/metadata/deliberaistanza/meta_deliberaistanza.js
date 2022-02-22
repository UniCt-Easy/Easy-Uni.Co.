
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

    function meta_deliberaistanza() {
        MetaData.apply(this, ["deliberaistanza"]);
        this.name = 'meta_deliberaistanza';
    }

    meta_deliberaistanza.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_deliberaistanza,
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
						this.describeAColumn(table, '!idistanza_registry_title', 'Studente', null, 22, null);
						this.describeAColumn(table, '!idistanza_annoaccademico_aa', 'Anno accademico', null, 22, null);
						this.describeAColumn(table, '!idistanza_istanza_alias14_data', 'Data', 'g', 26, null);
						this.describeAColumn(table, '!idistanza_istanzakind_title', 'Tipologia', null, 27, null);
						this.describeAColumn(table, '!idistanza_statuskind_alias1_title', 'Status', null, 29, null);
						this.describeAColumn(table, '!idistanza_istanza_alias14_protanno', 'Anno di protocollo', null, 30, null);
						this.describeAColumn(table, '!idistanza_istanza_alias14_protnumero', 'Numero di protocollo', null, 31, null);
						objCalcFieldConfig['!idistanza_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_annoaccademico_aa'] = { tableNameLookup:'annoaccademico', columnNameLookup:'aa', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_alias14_data'] = { tableNameLookup:'istanza_alias14', columnNameLookup:'data', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanzakind_title'] = { tableNameLookup:'istanzakind', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_statuskind_alias1_title'] = { tableNameLookup:'statuskind_alias1', columnNameLookup:'title', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_alias14_protanno'] = { tableNameLookup:'istanza_alias14', columnNameLookup:'protanno', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_alias14_protnumero'] = { tableNameLookup:'istanza_alias14', columnNameLookup:'protnumero', columnNamekey:'idistanza' };
						this.describeAColumn(table, '!idistanza_istanza_data', 'Data', 'g', 26, null);
						this.describeAColumn(table, '!idistanza_istanza_protanno', 'Anno di protocollo', null, 30, null);
						this.describeAColumn(table, '!idistanza_istanza_protnumero', 'Numero di protocollo', null, 31, null);
						objCalcFieldConfig['!idistanza_istanza_data'] = { tableNameLookup:'istanza', columnNameLookup:'data', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_protanno'] = { tableNameLookup:'istanza', columnNameLookup:'protanno', columnNamekey:'idistanza' };
						objCalcFieldConfig['!idistanza_istanza_protnumero'] = { tableNameLookup:'istanza', columnNameLookup:'protnumero', columnNamekey:'idistanza' };
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
               var def = appMeta.Deferred("getNewRow-meta_deliberaistanza");

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

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "idistanza asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('deliberaistanza', new meta_deliberaistanza('deliberaistanza'));

	}());
