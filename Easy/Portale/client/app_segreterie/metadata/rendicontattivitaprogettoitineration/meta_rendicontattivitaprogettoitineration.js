
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

    function meta_rendicontattivitaprogettoitineration() {
        MetaData.apply(this, ["rendicontattivitaprogettoitineration"]);
        this.name = 'meta_rendicontattivitaprogettoitineration';
    }

    meta_rendicontattivitaprogettoitineration.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoitineration,
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
						this.describeAColumn(table, 'iditineration', 'Missione', null, 10, null);
						this.describeAColumn(table, '!iditineration_itineration_description', 'Motivazione', null, 11, null);
						this.describeAColumn(table, '!iditineration_itineration_location', 'Località di destinazione', null, 12, null);
						this.describeAColumn(table, '!iditineration_itineration_start', 'Data inizio', null, 10, null);
						this.describeAColumn(table, '!iditineration_itineration_stop', 'Data fine', null, 10, null);
						objCalcFieldConfig['!iditineration_itineration_description'] = { tableNameLookup:'itineration', columnNameLookup:'description', columnNamekey:'iditineration' };
						objCalcFieldConfig['!iditineration_itineration_location'] = { tableNameLookup:'itineration', columnNameLookup:'location', columnNamekey:'iditineration' };
						objCalcFieldConfig['!iditineration_itineration_start'] = { tableNameLookup:'itineration', columnNameLookup:'start', columnNamekey:'iditineration' };
						objCalcFieldConfig['!iditineration_itineration_stop'] = { tableNameLookup:'itineration', columnNameLookup:'stop', columnNamekey:'iditineration' };
						this.describeAColumn(table, '!iditineration_itineration_start', 'data inizio', null, 10, null);
						this.describeAColumn(table, '!iditineration_itineration_stop', 'data fine', null, 10, null);
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
				var def = appMeta.Deferred("getNewRow-meta_rendicontattivitaprogettoitineration");

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

    window.appMeta.addMeta('rendicontattivitaprogettoitineration', new meta_rendicontattivitaprogettoitineration('rendicontattivitaprogettoitineration'));

	}());
