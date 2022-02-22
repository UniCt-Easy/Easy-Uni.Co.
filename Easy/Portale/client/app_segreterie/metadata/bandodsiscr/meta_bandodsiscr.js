
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

    function meta_bandodsiscr() {
        MetaData.apply(this, ["bandodsiscr"]);
        this.name = 'meta_bandodsiscr';
    }

    meta_bandodsiscr.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodsiscr,
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
						this.describeAColumn(table, 'cfbonus', 'Crediti bonus', 'fixed.2', 20, null);
						this.describeAColumn(table, '!idaccreditokind_accreditokind_title', 'Modalità di accredito', null, 31, null);
						objCalcFieldConfig['!idaccreditokind_accreditokind_title'] = { tableNameLookup:'accreditokind', columnNameLookup:'title', columnNamekey:'idaccreditokind' };
//$objCalcFieldConfig_seg$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'cfbonus', 'Crediti bonus', 'fixed.2', 20, null);
						this.describeAColumn(table, '!idaccreditokind_accreditokind_title', 'Modalità di accredito', null, 31, null);
						objCalcFieldConfig['!idaccreditokind_accreditokind_title'] = { tableNameLookup:'accreditokind', columnNameLookup:'title', columnNamekey:'idaccreditokind' };
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandodsiscr");

				//$getNewRowInside$

				dt.autoIncrement('idbandodsiscr', { minimum: 99990001 });

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

    window.appMeta.addMeta('bandodsiscr', new meta_bandodsiscr('bandodsiscr'));

	}());
