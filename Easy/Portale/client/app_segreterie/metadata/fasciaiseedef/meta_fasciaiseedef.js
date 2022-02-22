
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

    function meta_fasciaiseedef() {
        MetaData.apply(this, ["fasciaiseedef"]);
        this.name = 'meta_fasciaiseedef';
    }

    meta_fasciaiseedef.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_fasciaiseedef,
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
					case 'more':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
//$objCalcFieldConfig_more$
						break;
					case 'sconti':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
//$objCalcFieldConfig_sconti$
						break;
					case 'default':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
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
               var def = appMeta.Deferred("getNewRow-meta_fasciaiseedef");

				//$getNewRowInside$

				dt.autoIncrement('idfasciaiseedef', { minimum: 99990001 });

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

    window.appMeta.addMeta('fasciaiseedef', new meta_fasciaiseedef('fasciaiseedef'));

	}());
