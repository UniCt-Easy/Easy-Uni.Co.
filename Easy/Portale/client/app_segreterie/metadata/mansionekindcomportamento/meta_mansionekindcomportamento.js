
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_mansionekindcomportamento() {
        MetaData.apply(this, ["mansionekindcomportamento"]);
        this.name = 'meta_mansionekindcomportamento';
    }

    meta_mansionekindcomportamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mansionekindcomportamento,
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
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_title', 'Titolo', null, 23, null);
						this.describeAColumn(table, '!idperfcomportamento_perfcomportamento_description', 'Descrizione', null, 23, null);
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_title'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'title', columnNamekey:'idperfcomportamento' };
						objCalcFieldConfig['!idperfcomportamento_perfcomportamento_description'] = { tableNameLookup:'perfcomportamento', columnNameLookup:'description', columnNamekey:'idperfcomportamento' };
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
						table.columns["idperfcomportamento"].caption = "Codice";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_mansionekindcomportamento");

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

    window.appMeta.addMeta('mansionekindcomportamento', new meta_mansionekindcomportamento('mansionekindcomportamento'));

	}());