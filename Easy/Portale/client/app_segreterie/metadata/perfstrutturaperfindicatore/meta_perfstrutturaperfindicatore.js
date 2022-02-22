
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

    function meta_perfstrutturaperfindicatore() {
        MetaData.apply(this, ["perfstrutturaperfindicatore"]);
        this.name = 'meta_perfstrutturaperfindicatore';
    }

    meta_perfstrutturaperfindicatore.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfstrutturaperfindicatore,
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
						this.describeAColumn(table, '!idperfindicatore_perfindicatore_title', 'Titolo', null, 22, null);
						this.describeAColumn(table, '!idperfindicatore_perfindicatorekind_title', 'Tipo indicatore', null, 23, null);
						this.describeAColumn(table, '!idperfindicatore_perfindicatore_description', 'Descrizione', null, 23, null);
						objCalcFieldConfig['!idperfindicatore_perfindicatore_title'] = { tableNameLookup:'perfindicatore', columnNameLookup:'title', columnNamekey:'idperfindicatore' };
						objCalcFieldConfig['!idperfindicatore_perfindicatorekind_title'] = { tableNameLookup:'perfindicatorekind', columnNameLookup:'title', columnNamekey:'idperfindicatore' };
						objCalcFieldConfig['!idperfindicatore_perfindicatore_description'] = { tableNameLookup:'perfindicatore', columnNameLookup:'description', columnNamekey:'idperfindicatore' };
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
               var def = appMeta.Deferred("getNewRow-meta_perfstrutturaperfindicatore");

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

			//$describeTree$
        });

    window.appMeta.addMeta('perfstrutturaperfindicatore', new meta_perfstrutturaperfindicatore('perfstrutturaperfindicatore'));

	}());
