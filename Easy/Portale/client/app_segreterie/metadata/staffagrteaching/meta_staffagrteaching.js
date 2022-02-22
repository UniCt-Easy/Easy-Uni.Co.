
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

    function meta_staffagrteaching() {
        MetaData.apply(this, ["staffagrteaching"]);
        this.name = 'meta_staffagrteaching';
    }

    meta_staffagrteaching.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_staffagrteaching,
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
						this.describeAColumn(table, '!idisced2013_isced2013_detailedfield', 'Mansione', null, 31, null);
						objCalcFieldConfig['!idisced2013_isced2013_detailedfield'] = { tableNameLookup:'isced2013', columnNameLookup:'detailedfield', columnNamekey:'idisced2013' };
						this.describeAColumn(table, '!idnation_geo_nation_title', 'Lingua in cui svolge l’attività', null, 61, null);
						objCalcFieldConfig['!idnation_geo_nation_title'] = { tableNameLookup:'geo_nation_alias1', columnNameLookup:'title', columnNamekey:'idnation' };
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_idreg_docenti_title', 'Docente', null, 81, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_idreg_docenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idreg_resp_registry_title', 'Responsabile', null, 91, null);
						objCalcFieldConfig['!idreg_resp_registry_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg_resp' };
						this.describeAColumn(table, '!idreg_respestero_registry_title', 'Responsabile estero', null, 101, null);
						objCalcFieldConfig['!idreg_respestero_registry_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg_respestero' };
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Docente', null, 81, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
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
               var def = appMeta.Deferred("getNewRow-meta_staffagrteaching");

				//$getNewRowInside$

				dt.autoIncrement('idstaffagrteaching', { minimum: 99990001 });

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

    window.appMeta.addMeta('staffagrteaching', new meta_staffagrteaching('staffagrteaching'));

	}());
