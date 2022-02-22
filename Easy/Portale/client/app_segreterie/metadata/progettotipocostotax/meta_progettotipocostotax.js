
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

    function meta_progettotipocostotax() {
        MetaData.apply(this, ["progettotipocostotax"]);
        this.name = 'meta_progettotipocostotax';
    }

    meta_progettotipocostotax.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostotax,
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
						this.describeAColumn(table, '!taxcode_tax_description', 'Descrizione', null, 31, null);
						this.describeAColumn(table, '!taxcode_tax_taxref', 'Codice ritenuta', null, 32, null);
						this.describeAColumn(table, '!taxcode_tax_active', 'Attivo', null, 30, null);
						objCalcFieldConfig['!taxcode_tax_description'] = { tableNameLookup:'tax', columnNameLookup:'description', columnNamekey:'taxcode' };
						objCalcFieldConfig['!taxcode_tax_taxref'] = { tableNameLookup:'tax', columnNameLookup:'taxref', columnNamekey:'taxcode' };
						objCalcFieldConfig['!taxcode_tax_active'] = { tableNameLookup:'tax', columnNameLookup:'active', columnNamekey:'taxcode' };
						this.describeAColumn(table, '!taxcode_tax_description', 'Descrizione', null, 32, null);
						this.describeAColumn(table, '!taxcode_tax_taxref', 'Codice ritenuta', null, 34, null);
						this.describeAColumn(table, '!taxcode_tax_active', 'Attivo', null, 33, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostotax");

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

    window.appMeta.addMeta('progettotipocostotax', new meta_progettotipocostotax('progettotipocostotax'));

	}());
