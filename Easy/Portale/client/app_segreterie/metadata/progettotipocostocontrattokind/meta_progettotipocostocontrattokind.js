
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

    function meta_progettotipocostocontrattokind() {
        MetaData.apply(this, ["progettotipocostocontrattokind"]);
        this.name = 'meta_progettotipocostocontrattokind';
    }

    meta_progettotipocostocontrattokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostocontrattokind,
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
						this.describeAColumn(table, '!idcontrattokind_contrattokind_active', 'Attivo', null, 10, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_title', 'Tipologia', null, 11, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_oremaxgg', 'Ore di lavoro al giorno massime', null, 10, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_costolordoannuo', 'Costo lordo annuo', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_costolordoannuooneri', 'Costo lordo annuo e oneri', 'fixed.2', 10, null);
						this.describeAColumn(table, '!idcontrattokind_contrattokind_sortcode', 'Sortcode', null, 10, null);
						objCalcFieldConfig['!idcontrattokind_contrattokind_active'] = { tableNameLookup:'contrattokind', columnNameLookup:'active', columnNamekey:'idcontrattokind' };
						objCalcFieldConfig['!idcontrattokind_contrattokind_title'] = { tableNameLookup:'contrattokind', columnNameLookup:'title', columnNamekey:'idcontrattokind' };
						objCalcFieldConfig['!idcontrattokind_contrattokind_oremaxgg'] = { tableNameLookup:'contrattokind', columnNameLookup:'oremaxgg', columnNamekey:'idcontrattokind' };
						objCalcFieldConfig['!idcontrattokind_contrattokind_costolordoannuo'] = { tableNameLookup:'contrattokind', columnNameLookup:'costolordoannuo', columnNamekey:'idcontrattokind' };
						objCalcFieldConfig['!idcontrattokind_contrattokind_costolordoannuooneri'] = { tableNameLookup:'contrattokind', columnNameLookup:'costolordoannuooneri', columnNamekey:'idcontrattokind' };
						objCalcFieldConfig['!idcontrattokind_contrattokind_sortcode'] = { tableNameLookup:'contrattokind', columnNameLookup:'sortcode', columnNamekey:'idcontrattokind' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idcontrattokind"].caption = "Tipo di contratto";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostocontrattokind");

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

    window.appMeta.addMeta('progettotipocostocontrattokind', new meta_progettotipocostocontrattokind('progettotipocostocontrattokind'));

	}());
