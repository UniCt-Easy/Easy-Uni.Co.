
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

    function meta_bandomipropedeut() {
        MetaData.apply(this, ["bandomipropedeut"]);
        this.name = 'meta_bandomipropedeut';
    }

    meta_bandomipropedeut.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomipropedeut,
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
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice', null, 22, null);
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione', null, 21, null);
						objCalcFieldConfig['!idinsegn_insegn_codice'] = { tableNameLookup:'insegn', columnNameLookup:'codice', columnNamekey:'idinsegn' };
						objCalcFieldConfig['!idinsegn_insegn_denominazione'] = { tableNameLookup:'insegn', columnNameLookup:'denominazione', columnNamekey:'idinsegn' };
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice', null, 24, null);
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idinsegn_insegn_codice', 'Codice', null, 23, null);
						this.describeAColumn(table, '!idinsegn_insegn_denominazione', 'Denominazione', null, 23, null);
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
               var def = appMeta.Deferred("getNewRow-meta_bandomipropedeut");

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

    window.appMeta.addMeta('bandomipropedeut', new meta_bandomipropedeut('bandomipropedeut'));

	}());
