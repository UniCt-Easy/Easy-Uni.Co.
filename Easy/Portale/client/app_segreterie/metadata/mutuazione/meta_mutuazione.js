
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

    function meta_mutuazione() {
        MetaData.apply(this, ["mutuazione"]);
        this.name = 'meta_mutuazione';
    }

    meta_mutuazione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mutuazione,
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
						this.describeAColumn(table, 'riferimento', 'Di riferimento per il canale', null, 50, null);
						this.describeAColumn(table, '!idcanale_from_canale_title', 'Canale mutuato', null, 41, null);
						objCalcFieldConfig['!idcanale_from_canale_title'] = { tableNameLookup:'canale_alias1', columnNameLookup:'title', columnNamekey:'idcanale_from' };
						objCalcFieldConfig['!idcanale_from_canale_title'] = { tableNameLookup:'canale_alias2', columnNameLookup:'title', columnNamekey:'idcanale_from' };
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
						table.columns["idcanale"].caption = "Canale mutuante";
						table.columns["idcanale_from"].caption = "Canale mutuato";
						table.columns["json"].caption = "Mutuazione";
						table.columns["riferimento"].caption = "Di riferimento per il canale";
						table.columns["title"].caption = "Mutuazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_mutuazione");

				//$getNewRowInside$

				dt.autoIncrement('idmutuazione', { minimum: 99990001 });

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
					case "default": {
						return "riferimento desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('mutuazione', new meta_mutuazione('mutuazione'));

	}());
