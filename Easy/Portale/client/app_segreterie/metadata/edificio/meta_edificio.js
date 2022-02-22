
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

    function meta_edificio() {
        MetaData.apply(this, ["edificio"]);
        this.name = 'meta_edificio';
    }

    meta_edificio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_edificio,
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
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'cap', 'CAP', null, 40, 20);
						this.describeAColumn(table, 'code', 'Codice', null, 50, 128);
						this.describeAColumn(table, 'latitude', 'Latitudine', 'fixed.7', 90, null);
						this.describeAColumn(table, 'location', 'Località', null, 100, 20);
						this.describeAColumn(table, 'longitude', 'Longitudine', 'fixed.7', 110, null);
						this.describeAColumn(table, '!idcity_geo_city_title', 'Città', null, 61, null);
						objCalcFieldConfig['!idcity_geo_city_title'] = { tableNameLookup:'geo_city_alias1', columnNameLookup:'title', columnNamekey:'idcity' };
						this.describeAColumn(table, '!idnation_geo_nation_title', 'Nazione', null, 71, null);
						objCalcFieldConfig['!idnation_geo_nation_title'] = { tableNameLookup:'geo_nation_alias1', columnNameLookup:'title', columnNamekey:'idnation' };
//$objCalcFieldConfig_seg_child$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'address', 'Indirizzo', null, 30, 100);
						this.describeAColumn(table, 'cap', 'CAP', null, 40, 20);
						this.describeAColumn(table, 'code', 'Codice', null, 50, 128);
						this.describeAColumn(table, 'location', 'Località', null, 100, 20);
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
						table.columns["address"].caption = "Indirizzo";
						table.columns["cap"].caption = "CAP";
						table.columns["code"].caption = "Codice";
						table.columns["idcity"].caption = "Città";
						table.columns["idedificio"].caption = "Edificio";
						table.columns["idnation"].caption = "Nazione";
						table.columns["idsede"].caption = "Sede";
						table.columns["latitude"].caption = "Latitudine";
						table.columns["location"].caption = "Località";
						table.columns["longitude"].caption = "Longitudine";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_edificio");

				//$getNewRowInside$

				dt.autoIncrement('idedificio', { minimum: 99990001 });

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
					case "seg_child": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('edificio', new meta_edificio('edificio'));

	}());
