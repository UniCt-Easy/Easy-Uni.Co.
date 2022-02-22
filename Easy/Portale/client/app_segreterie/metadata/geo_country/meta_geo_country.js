
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

    function meta_geo_country() {
        MetaData.apply(this, ["geo_country"]);
        this.name = 'meta_geo_country';
    }

    meta_geo_country.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_country,
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
					case 'segchild':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'province', 'sigla provincia', null, 60, null);
						this.describeAColumn(table, 'start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 80, null);
						this.describeAColumn(table, '!newcountry_geo_country_title', 'id nuova provincia in cui questa � confluita', null, 41, null);
						objCalcFieldConfig['!newcountry_geo_country_title'] = { tableNameLookup:'geo_country_alias1', columnNameLookup:'title', columnNamekey:'newcountry' };
						this.describeAColumn(table, '!oldcountry_geo_country_title', 'id provincia da cui questa � confluita', null, 51, null);
						objCalcFieldConfig['!oldcountry_geo_country_title'] = { tableNameLookup:'geo_country_alias3', columnNameLookup:'title', columnNamekey:'oldcountry' };
//$objCalcFieldConfig_segchild$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'province', 'sigla provincia', null, 60, null);
						this.describeAColumn(table, 'start', 'data inizio', null, 70, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 80, null);
//$objCalcFieldConfig_seg$
						break;
					case 'default':
						this.describeAColumn(table, 'start', 'Inizio validit�', null, 10, null);
						this.describeAColumn(table, 'stop', 'Fine validit�', null, 20, null);
						this.describeAColumn(table, 'title', 'Provincia', null, 30, 50);
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
					case 'segchild':
						table.columns["idregion"].caption = "Regione";
//$innerSetCaptionConfig_segchild$
						break;
					case 'seg':
						table.columns["idregion"].caption = "Regione";
//$innerSetCaptionConfig_seg$
						break;
					case 'default':
						table.columns["idregion"].caption = "Regione";
						table.columns["start"].caption = "Inizio validit�";
						table.columns["stop"].caption = "Fine validit�";
						table.columns["title"].caption = "Provincia";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_geo_country");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idcountry', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segchild": {
						return "title asc ";
					}
					case "seg": {
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

    window.appMeta.addMeta('geo_country', new meta_geo_country('geo_country'));

	}());
