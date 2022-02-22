
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

    function meta_attivformcaratteristicaora() {
        MetaData.apply(this, ["attivformcaratteristicaora"]);
        this.name = 'meta_attivformcaratteristicaora';
    }

    meta_attivformcaratteristicaora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformcaratteristicaora,
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
					case 'erogata':
						this.describeAColumn(table, 'ora', 'Ore', null, 100, null);
						this.describeAColumn(table, '!idorakind_orakind_title', 'Tipo', null, 91, null);
						objCalcFieldConfig['!idorakind_orakind_title'] = { tableNameLookup:'orakind', columnNameLookup:'title', columnNamekey:'idorakind' };
//$objCalcFieldConfig_erogata$
						break;
					case 'default':
						this.describeAColumn(table, 'ora', 'Ore', null, 100, null);
						this.describeAColumn(table, '!idorakind_orakind_title', 'Tipo', null, 91, null);
						objCalcFieldConfig['!idorakind_orakind_title'] = { tableNameLookup:'orakind', columnNameLookup:'title', columnNamekey:'idorakind' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idorakind"].caption = "Tipo";
						table.columns["ora"].caption = "Ore";
//$innerSetCaptionConfig_default$
						break;
					case 'erogata':
						table.columns["idorakind"].caption = "Tipo";
//$innerSetCaptionConfig_erogata$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_attivformcaratteristicaora");

				//$getNewRowInside$

				dt.autoIncrement('idattivformcaratteristicaora', { minimum: 99990001 });

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

    window.appMeta.addMeta('attivformcaratteristicaora', new meta_attivformcaratteristicaora('attivformcaratteristicaora'));

	}());
