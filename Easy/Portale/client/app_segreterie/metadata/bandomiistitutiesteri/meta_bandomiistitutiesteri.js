
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

    function meta_bandomiistitutiesteri() {
        MetaData.apply(this, ["bandomiistitutiesteri"]);
        this.name = 'meta_bandomiistitutiesteri';
    }

    meta_bandomiistitutiesteri.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomiistitutiesteri,
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
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_cf', 'Codice fiscale', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_p_iva', 'Partita iva', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_active', 'attivo', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_city_title', 'Città', null, 21, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_nation_title', 'Nazione', null, 21, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_name', 'Name', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_city', 'City', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_code', 'Code', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode', 'Institutional code', null, 20, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_referencenumber', 'Reference number', null, 20, null);
						objCalcFieldConfig['!idreg_istitutiesteri_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_cf'] = { tableNameLookup:'registry', columnNameLookup:'cf', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_p_iva'] = { tableNameLookup:'registry', columnNameLookup:'p_iva', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_active'] = { tableNameLookup:'registry', columnNameLookup:'active', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_geo_city_title'] = { tableNameLookup:'geo_city', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_geo_nation_title'] = { tableNameLookup:'geo_nation', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_name'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'name', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_city'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'city', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_code'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'code', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'institutionalcode', columnNamekey:'idreg_istitutiesteri' };
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_referencenumber'] = { tableNameLookup:'registry_istitutiesteri', columnNameLookup:'referencenumber', columnNamekey:'idreg_istitutiesteri' };
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_title', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_cf', 'Codice fiscale', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_p_iva', 'Partita iva', null, 25, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_active', 'attivo', null, 26, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_city_title', 'Città', null, 28, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_geo_nation_title', 'Nazione', null, 29, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_name', 'Name', null, 22, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_city', 'City', null, 23, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_code', 'Code', null, 24, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_institutionalcode', 'Institutional code', null, 25, null);
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_referencenumber', 'Reference number', null, 26, null);
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
               var def = appMeta.Deferred("getNewRow-meta_bandomiistitutiesteri");

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

    window.appMeta.addMeta('bandomiistitutiesteri', new meta_bandomiistitutiesteri('bandomiistitutiesteri'));

	}());
