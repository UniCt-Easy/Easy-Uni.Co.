
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

    function meta_progettoattachkindprogettostatuskind() {
        MetaData.apply(this, ["progettoattachkindprogettostatuskind"]);
        this.name = 'meta_progettoattachkindprogettostatuskind';
    }

    meta_progettoattachkindprogettostatuskind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoattachkindprogettostatuskind,
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
						this.describeAColumn(table, '!idprogettostatuskind_progettostatuskind_title', 'Stato', null, 21, null);
						this.describeAColumn(table, '!idprogettostatuskind_progettostatuskind_sortcode', 'Ordinamento', null, 20, null);
						objCalcFieldConfig['!idprogettostatuskind_progettostatuskind_title'] = { tableNameLookup:'progettostatuskind', columnNameLookup:'title', columnNamekey:'idprogettostatuskind' };
						objCalcFieldConfig['!idprogettostatuskind_progettostatuskind_sortcode'] = { tableNameLookup:'progettostatuskind', columnNameLookup:'sortcode', columnNamekey:'idprogettostatuskind' };
						this.describeAColumn(table, '!idprogettostatuskind_progettostatuskind_sortcode', 'Sortcode', null, 20, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettoattachkindprogettostatuskind");

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

    window.appMeta.addMeta('progettoattachkindprogettostatuskind', new meta_progettoattachkindprogettostatuskind('progettoattachkindprogettostatuskind'));

	}());
